using System;
using System.Collections;
using UnityEngine;

public class LootWheelSpinner
{
	public LootWheelSpinner(Rigidbody wheel, Transform needle, LootWheel.WheelSlot[] slots)
	{
		this.m_wheel = wheel;
		this.m_needle = needle;
		this.m_slots = slots;
		this.m_spinning = false;
		this.m_needleMovement = new AnimationCurve();
		this.m_needleMovement.AddKey(new Keyframe(0f, 0f));
		this.m_needleMovement.AddKey(new Keyframe(1f, 1f));
	}

	public bool IsSpinning
	{
		get
		{
			return this.m_spinning;
		}
	}

	private float WheelRotation
	{
		get
		{
			return this.m_wheel.rotation.eulerAngles.z;
		}
		set
		{
			this.m_wheel.rotation = Quaternion.Euler(new Vector3(0f, 0f, value));
		}
	}

	public void Spin(LootWheel.WheelSlot target, float initialSpin, float velocity, float deceleration, float tickingRate, Action OnSpinEnd)
	{
		float num = target.RotationBegin - target.RotationEnd;
		if (num < 0f)
		{
			num += 360f;
		}
		float num2 = UnityEngine.Random.Range(1.5f, num - 1.5f);
		CoroutineRunner.Instance.StartCoroutine(this.SpinRoutine(initialSpin, velocity, target.RotationBegin - num2, deceleration, tickingRate, OnSpinEnd));
	}

	private IEnumerator SpinRoutine(float initialSpinTime, float angularVelocity, float targetRotation, float deceleration, float tickingRate, Action OnSpinEnd)
	{
		this.m_wheel.interpolation = RigidbodyInterpolation.Interpolate;
		deceleration = Mathf.Max(deceleration, 0.05f);
		this.m_spinning = true;
		float decelerationDist = angularVelocity / 2f * (angularVelocity / deceleration + 1f);
		float decelerationAngle;
		if (decelerationDist > targetRotation)
		{
			decelerationAngle = (targetRotation + decelerationDist) % 360f;
		}
		else
		{
			float num = Mathf.Ceil((targetRotation - decelerationDist) / -360f);
			decelerationAngle = targetRotation - decelerationDist + num * 360f;
		}
		CoroutineRunner.Instance.StartCoroutine(this.PlayTickSounds(tickingRate));
		CoroutineRunner.Instance.StartCoroutine(this.MoveNeedle());
		yield return CoroutineRunner.Instance.StartCoroutine(this.InitialSpin(initialSpinTime, angularVelocity));
		yield return CoroutineRunner.Instance.StartCoroutine(this.SpinTo(decelerationAngle, angularVelocity, deceleration));
		yield return CoroutineRunner.Instance.StartCoroutine(this.Decelerate(angularVelocity, deceleration));
		this.m_wheel.interpolation = RigidbodyInterpolation.None;
		this.m_spinning = false;
		if (OnSpinEnd != null)
		{
			OnSpinEnd();
		}
		yield break;
	}

	private IEnumerator InitialSpin(float spinTime, float angularVelocity)
	{
		this.m_currentSpinVelocity = angularVelocity;
		while (spinTime > 0f)
		{
			yield return new WaitForFixedUpdate();
			this.WheelRotation -= angularVelocity;
			spinTime -= Time.deltaTime;
		}
		yield break;
	}

	private IEnumerator SpinTo(float targetRotation, float angularVelocity, float deceleration)
	{
		float targetVelocity;
		int iterations;
		this.FindVelocity(targetRotation, this.WheelRotation, angularVelocity - deceleration, angularVelocity, out targetVelocity, out iterations);
		this.m_currentSpinVelocity = targetVelocity;
		for (int i = 0; i < iterations; i++)
		{
			yield return new WaitForFixedUpdate();
			this.WheelRotation -= targetVelocity;
		}
		yield break;
	}

	private void FindVelocity(float target, float current, float min, float max, out float velocity, out int iterations)
	{
		velocity = 0f;
		iterations = 0;
		float num = (current <= target) ? (360f - (target - current)) : (current - target);
		while (velocity < min || velocity > max)
		{
			iterations = Mathf.CeilToInt(num / max);
			velocity = num / (float)iterations;
			num += 360f;
		}
	}

	private IEnumerator Decelerate(float currentVelocity, float rate)
	{
		while (currentVelocity > 0f)
		{
			yield return new WaitForFixedUpdate();
			this.WheelRotation -= currentVelocity;
			currentVelocity -= rate;
			this.m_currentSpinVelocity = currentVelocity;
		}
		yield break;
	}

	private IEnumerator PlayTickSounds(float rate)
	{
		float current = 0f;
		AudioSource[] spinClicks = WPFMonoBehaviour.gameData.commonAudioCollection.lootWheelTickSounds;
		while (this.m_spinning)
		{
			current += this.m_currentSpinVelocity * Time.deltaTime;
			if (current > rate)
			{
				Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(spinClicks[UnityEngine.Random.Range(0, spinClicks.Length)]);
				current = 0f;
			}
			yield return null;
		}
		yield break;
	}

	private IEnumerator MoveNeedle()
	{
		Vector3 needleRotation = this.m_needle.rotation.eulerAngles;
		Vector3 wheelRotation = this.m_wheel.rotation.eulerAngles;
		float nextTick = this.NextSlotBegin(wheelRotation.z);
		float initialRotation = needleRotation.z;
		float range = 80f;
		float t = 0f;
		float rate = 5f;
		bool rising = false;
		float previousRotation = wheelRotation.z;
		while (this.m_spinning)
		{
			wheelRotation = this.m_wheel.rotation.eulerAngles;
			float currentRotation = wheelRotation.z;
			if (this.InRange(previousRotation, currentRotation, nextTick))
			{
				nextTick = this.NextSlotBegin(wheelRotation.z);
				rising = (t < 0.85f || rising);
			}
			float delta = this.m_needleMovement.Evaluate(t);
			needleRotation.z = initialRotation + delta * range;
			if (rising)
			{
				t += rate * Time.deltaTime;
				rising = (t < 1f);
				t = Mathf.Clamp01(t);
			}
			else
			{
				t -= rate * Time.deltaTime;
				t = Mathf.Clamp01(t);
			}
			this.m_needle.rotation = Quaternion.Euler(needleRotation);
			previousRotation = wheelRotation.z;
			yield return null;
		}
		while (t > 0f)
		{
			t -= rate * Time.deltaTime;
			float delta2 = this.m_needleMovement.Evaluate(t);
			needleRotation.z = initialRotation + delta2 * range;
			this.m_needle.rotation = Quaternion.Euler(needleRotation);
			yield return null;
		}
		yield break;
	}

	private float NextSlotBegin(float rotation)
	{
		for (int i = 0; i < this.m_slots.Length; i++)
		{
			float rotationBegin = this.m_slots[i].RotationBegin;
			float rotationEnd = this.m_slots[i].RotationEnd;
			if (this.InRange(rotationBegin, rotationEnd, rotation))
			{
				return rotationEnd;
			}
		}
		return 0f;
	}

	private bool InRange(float begin, float end, float value)
	{
		if (begin < end)
		{
			return (value < begin && value >= 0f) || (value < 360f && value > end);
		}
		return value < begin && value > end;
	}

	private Rigidbody m_wheel;

	private Transform m_needle;

	private AnimationCurve m_needleMovement;

	private bool m_spinning;

	private float m_currentSpinVelocity;

	private LootWheel.WheelSlot[] m_slots;
}
