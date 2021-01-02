using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DailyRewardBundle
{
	public List<DailyReward> GetRewards(int level)
	{
		if (this.isBundle)
		{
			return this.rewards;
		}
        UnityEngine.Random.InitState(RewardSystem.RandomSeed(level));
		int index = UnityEngine.Random.Range(0, this.rewards.Count);
		return new List<DailyReward>
		{
			this.rewards[index]
		};
	}

	[SerializeField]
	private bool isBundle;

	[SerializeField]
	private List<DailyReward> rewards;
}
