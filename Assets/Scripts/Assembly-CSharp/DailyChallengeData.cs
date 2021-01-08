using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DailyChallengeData : ScriptableObject
{
	public int Count
	{
		get
		{
			return this.dailyLevels.Count;
		}
	}

	private void OnEnable()
	{
		if (this.dailyLevels == null)
		{
			this.dailyLevels = new List<DailyLevel>();
		}
	}

	public void AddDaily(DailyLevel daily)
	{
		if (this.GetDaily(daily.GetKey()) == null)
		{
			this.dailyLevels.Add(daily);
		}
	}

	public DailyLevel GetDaily(string key)
	{
		for (int i = 0; i < this.dailyLevels.Count; i++)
		{
			if (this.dailyLevels[i].GetKey().Equals(key))
			{
				return this.dailyLevels[i];
			}
		}
		return null;
	}

	[SerializeField]
	private List<DailyLevel> dailyLevels;
}
