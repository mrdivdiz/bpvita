using System;
using UnityEngine;

public class Bellows : BasePropulsion
{
	private float InflateDuration
	{
		get
		{
			return (!this.m_alienBellow) ? 0.3f : 0.15f;
		}
	}

	public static bool HasAlienBellows
	{
		get
		{
			return Bellows.m_alienBellowCount > 0;
		}
	}

	public override bool CanBeEnabled()
	{
		return this.m_isConnected;
	}

	public override bool HasOnOffToggle()
	{
		return false;
	}

	public override bool IsEnabled()
	{
		return this.m_enabled;
	}

	public override BasePart.Direction EffectDirection()
	{
		return BasePart.Rotate(BasePart.Direction.Right, this.m_gridRotation);
	}

	public override void InitializeEngine()
	{
		this.m_isConnected = (base.contraption.ComponentPartCount(base.ConnectedComponent) > 1);
	}

	private void Start()
	{
		this.m_timeBoostStarted = -1000f;
		if (this.m_alienBellow)
		{
			Bellows.m_alienBellowCount++;
		}
	}

	private void OnDestroy()
	{
		if (this.m_alienBellow)
		{
			Bellows.m_alienBellowCount--;
		}
	}

	public void FixedUpdate()
	{
		float num = Time.time - this.m_timeBoostStarted;
		if (num > 0.8f + this.InflateDuration)
		{
			this.m_enabled = false;
			return;
		}
		if (num < 0.5f)
		{
			this.m_enabled = true;
			float num2 = 1f - num / 0.5f;
			num2 = 1f - num2 * num2;
			float d = num2 * this.m_boostForce;
			Vector3 vector = base.transform.TransformDirection(this.m_direction);
			Vector3 position = base.transform.position + vector * 0.5f;
			Vector3 a = vector;
			base.rigidbody.AddForceAtPosition(d * a, position, ForceMode.Force);
		}
		Vector3 one = Vector3.one;
		one.y *= Bellows.CompressionScale(num);
		if (this.scaleTarget != null)
		{
			this.scaleTarget.localScale = one;
		}
		else
		{
			base.transform.localScale = one;
		}
	}

	protected override void OnTouch()
	{
		if (!this.m_isConnected)
		{
			return;
		}
		float num = Time.time - this.m_timeBoostStarted;
		if (num < 0.8f + this.InflateDuration)
		{
			return;
		}
		this.m_timeBoostStarted = Time.time;
		if (base.HasTag("Fart"))
		{
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.bellowsFarts, base.transform.position);
		}
		if (base.HasTag("Alien_part"))
		{
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.alienBellows, base.transform.position);
		}
		else
		{
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.bellowsPuff, base.transform.position);
		}
		this.smokeEmitter.Emit(UnityEngine.Random.Range(1, 2));
	}

	public static float CompressionScale(float time)
	{
		float t = 0f;
		if (time < 0.5f)
		{
			t = time / 0.5f;
		}
		else if (time < 0.8f)
		{
			t = 1f;
		}
		else if (time < 0.8f + ((!Bellows.HasAlienBellows) ? 0.3f : 0.15f))
		{
			t = 1f - (time - 0.5f - 0.3f) / ((!Bellows.HasAlienBellows) ? 0.3f : 0.15f);
		}
		return Mathf.Lerp(1f, 0.3f, t);
	}

	public Vector3 m_direction = Vector3.up;

	public bool m_enabled;

	[SerializeField]
	private bool m_alienBellow;

	public float m_boostForce = 10f;

	public const float BOOST_DURATION = 0.5f;

	public const float WAIT_DURATION = 0.3f;

	public const float INFLATE_DURATION = 0.3f;

	public const float ALIEN_INFLATE_DURATION = 0.15f;

	public const float COMPRESSED_SCALE = 0.3f;

	public ParticleSystem smokeEmitter;

	public Transform scaleTarget;

	protected float m_timeBoostStarted;

	protected float m_currentScale;

	private bool m_isConnected;

	private static int m_alienBellowCount;
}
