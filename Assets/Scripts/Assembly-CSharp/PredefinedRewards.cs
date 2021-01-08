using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredefinedRewards : Singleton<PredefinedRewards>
{
	public bool Initialized
	{
		get
		{
			return this.initialized;
		}
	}

	public bool AllRewardsGiven
	{
		get
		{
			return this.RewardsGiven >= this.rewardsAmount;
		}
	}

	private bool FirstRewardGiven
	{
		get
		{
			return GameProgress.GetBool("Pre_FirstRewardGiven", false, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetBool("Pre_FirstRewardGiven", value, GameProgress.Location.Local);
		}
	}

	private int RewardsGiven
	{
		get
		{
			return GameProgress.GetInt("Pre_RewardsGiven", 0, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetInt("Pre_RewardsGiven", value, GameProgress.Location.Local);
		}
	}

	private void Awake()
	{
		base.SetAsPersistant();
		if (Singleton<GameConfigurationManager>.Instance.HasData)
		{
			this.Initialize();
		}
		else
		{
			GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
			instance.OnHasData = (Action)Delegate.Combine(instance.OnHasData, new Action(this.Initialize));
		}
	}

	private void Initialize()
	{
		this.rewards = new List<BasePart.PartType>();
		Hashtable values = Singleton<GameConfigurationManager>.Instance.GetValues("first_predefined_reward");
		Hashtable values2 = Singleton<GameConfigurationManager>.Instance.GetValues("predefined_rewards");
		if (values.ContainsKey("reward"))
		{
			object obj;
			if (!this.TryParse(typeof(BasePart.PartType), values["reward"] as string, out obj))
			{
				return;
			}
			this.firstReward = (BasePart.PartType)obj;
		}
		if (values2.ContainsKey("amount") && int.TryParse(values2["amount"] as string, out this.rewardsAmount))
		{
			for (int i = 0; i < this.rewardsAmount; i++)
			{
				if (!values2.ContainsKey("reward_" + i.ToString()))
				{
					return;
				}
				object obj2;
				if (!this.TryParse(typeof(BasePart.PartType), values2["reward_" + i.ToString()] as string, out obj2))
				{
					return;
				}
				BasePart.PartType type = (BasePart.PartType)obj2;
				if (!this.GetRewardGiven(type))
				{
					this.rewards.Add((BasePart.PartType)obj2);
				}
			}
		}
		this.initialized = true;
	}

	private bool TryParse(Type type, string value, out object target)
	{
		target = null;
		try
		{
			target = Enum.Parse(type, value);
			return target != null;
		}
		catch (ArgumentException ex)
		{
			if (ex is ArgumentNullException)
			{
			}
		}
		return false;
	}

	public bool GetReward(BasePart.PartTier tier, out BasePart part)
	{
		part = null;
		if (this.rewards != null && this.rewards.Count > 0)
		{
			int num = UnityEngine.Random.Range(0, this.rewards.Count);
			int num2 = num;
			do
			{
				num++;
				if (num >= this.rewards.Count)
				{
					num = 0;
				}
				BasePart.PartType type = (!this.FirstRewardGiven) ? this.firstReward : this.rewards[num];
				List<BasePart> customParts = CustomizationManager.GetCustomParts(type, tier, true);
				if (customParts.Count > 0)
				{
					int num3 = UnityEngine.Random.Range(0, customParts.Count);
					int num4 = num3;
					do
					{
						num3++;
						if (num3 >= customParts.Count)
						{
							num3 = 0;
						}
						if (customParts[num3].craftable)
						{
							part = customParts[num3];
							if (this.FirstRewardGiven)
							{
								this.SetRewardGiven(type, true);
							}
							else
							{
								this.FirstRewardGiven = true;
							}
							num = num2;
							num3 = num4;
						}
					}
					while (num3 != num4);
				}
			}
			while (num != num2);
		}
		return part != null;
	}

	public static PredefinedRewards Create()
	{
		if (Singleton<PredefinedRewards>.Instance == null)
		{
			GameObject gameObject = new GameObject("PredefinedRewards (Singleton)");
			return gameObject.AddComponent<PredefinedRewards>();
		}
		return Singleton<PredefinedRewards>.Instance;
	}

	private bool GetRewardGiven(BasePart.PartType type)
	{
		return GameProgress.GetBool("Pre_RewardGiven_" + type.ToString(), false, GameProgress.Location.Local, null);
	}

	private void SetRewardGiven(BasePart.PartType type, bool given)
	{
		if (given && this.rewards.Contains(type))
		{
			this.rewards.Remove(type);
		}
		if (given)
		{
			this.RewardsGiven++;
		}
		GameProgress.SetBool("Pre_RewardGiven_" + type.ToString(), given, GameProgress.Location.Local);
	}

	private BasePart.PartType firstReward;

	private List<BasePart.PartType> rewards;

	private bool initialized;

	private int rewardsAmount;
}
