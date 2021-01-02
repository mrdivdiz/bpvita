using System;
using System.Collections;
using UnityEngine;

public class DoubleRewardIcon : MonoBehaviour
{
	public static DoubleRewardIcon Instance
	{
		get
		{
			return DoubleRewardIcon.instance;
		}
	}

	private void Awake()
	{
		if (DoubleRewardIcon.instance == null || DoubleRewardIcon.instance == this)
		{
			this.renderers = base.GetComponentsInChildren<MeshRenderer>();
			DoubleRewardIcon.instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void OnEnable()
	{
		base.StartCoroutine(this.UpdateTimeField());
	}

	private void OnDisable()
	{
		base.StopAllCoroutines();
	}

	private IEnumerator UpdateTimeField()
	{
		while (base.enabled)
		{
			float remaining = Singleton<DoubleRewardManager>.Instance.DoubleRewardTimeRemaining;
			if (remaining <= 0f)
			{
				base.gameObject.SetActive(false);
				yield break;
			}
			TimeSpan time = TimeSpan.FromSeconds((double)remaining);
			if (this.NeedsUpdate(time))
			{
				string text;
				if (time.Hours > 0)
				{
					text = string.Format("{0}h {1}m {2}s", time.Hours, time.Minutes, time.Seconds);
				}
				else if (time.Minutes > 0)
				{
					text = string.Format("{0}m {1}s", time.Minutes, time.Seconds);
				}
				else
				{
					text = string.Format("{0}s", time.Seconds);
				}
				for (int i = 0; i < this.timeFields.Length; i++)
				{
					this.timeFields[i].text = text;
				}
			}
			yield return null;
		}
		yield break;
	}

	private bool NeedsUpdate(TimeSpan time)
	{
		bool result = time.Hours != this.prevHours || time.Minutes != this.prevMinutes || time.Seconds != this.prevSeconds;
		this.prevHours = time.Hours;
		this.prevMinutes = time.Minutes;
		this.prevSeconds = time.Seconds;
		return result;
	}

	public void SetSortingLayer(string layer)
	{
		for (int i = 0; i < this.renderers.Length; i++)
		{
			this.renderers[i].sortingLayerName = layer;
		}
	}

	[SerializeField]
	private TextMesh[] timeFields;

	[SerializeField]
	private MeshRenderer[] renderers;

	private int prevHours;

	private int prevMinutes;

	private int prevSeconds;

	private static DoubleRewardIcon instance;
}
