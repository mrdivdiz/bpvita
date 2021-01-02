using System;
using System.Collections;
using UnityEngine;

public class CoroutineRunner : Singleton<CoroutineRunner>
{
	public new static CoroutineRunner Instance
	{
		get
		{
			if (Singleton<CoroutineRunner>.instance == null)
			{
				Singleton<CoroutineRunner>.instance = UnityEngine.Object.FindObjectOfType<CoroutineRunner>();
				if (Singleton<CoroutineRunner>.instance == null)
				{
					GameObject gameObject = new GameObject("CoroutineRunner (Singleton)", new Type[]
					{
						typeof(CoroutineRunner)
					});
					Singleton<CoroutineRunner>.instance = gameObject.GetComponent<CoroutineRunner>();
				}
			}
			return Singleton<CoroutineRunner>.instance;
		}
	}

	private void Awake()
	{
		base.SetAsPersistant();
	}

	public void DelayAction(Action action, float seconds, bool realTime = true)
	{
		base.StartCoroutine(CoroutineRunner.DelayActionSequence(action, seconds, realTime));
	}

	public static IEnumerator DelayActionSequence(Action action, float seconds, bool realTime)
	{
		float secondsLeft = seconds;
		while (secondsLeft > 0f)
		{
			secondsLeft -= ((!realTime) ? GameTime.DeltaTime : GameTime.RealTimeDelta);
			yield return null;
		}
		if (action != null)
		{
			action();
		}
		yield break;
	}

	public static IEnumerator DelayFrames(Action action, int frames)
	{
		while (frames > 0)
		{
			frames--;
			yield return null;
		}
		if (action != null)
		{
			action();
		}
		yield break;
	}

	public static IEnumerator MoveObject(Transform tf, Vector3 position, float time, bool useLocalPosition = false)
	{
		float counter = 0f;
		float deltaTime = 1f / time;
		Vector3 originalPosition = (!useLocalPosition) ? tf.position : tf.localPosition;
		while (counter < time)
		{
			if (useLocalPosition)
			{
				tf.localPosition = Vector3.Lerp(originalPosition, position, counter * deltaTime);
			}
			else
			{
				tf.position = Vector3.Lerp(originalPosition, position, counter * deltaTime);
			}
			counter += Time.deltaTime;
			yield return null;
		}
		if (useLocalPosition)
		{
			tf.localPosition = position;
		}
		else
		{
			tf.position = position;
		}
		yield break;
	}

	public static IEnumerator DeltaAction(float duration, bool realTime, Action<float> action)
	{
		float durationLeft = duration;
		for (;;)
		{
			yield return null;
			durationLeft -= ((!realTime) ? Time.deltaTime : Time.unscaledDeltaTime);
			if (action == null)
			{
				break;
			}
			if (durationLeft <= 0f)
			{
				action(0f);
			}
			else
			{
				action(durationLeft / duration);
			}
			if (durationLeft <= 0f)
			{
				goto Block_4;
			}
		}
		yield break;
		Block_4:
		yield break;
	}
}
