using System.Collections.Generic;
using UnityEngine;

public class StarBox : OneTimeCollectable
{
	public static event Collected onCollected;

	public event Collected onCollect;

	public static List<StarBox> StarBoxes
	{
		get
		{
			return StarBox.starBoxes;
		}
	}

	protected virtual void Awake()
	{
		StarBox.starBoxes.Add(this);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		StarBox.starBoxes.Remove(this);
	}

	public override bool IsDisabled()
	{
		return false;
	}

	protected override string GetNameKey()
	{
		string result = string.Empty;
		if (base.transform.parent != null && base.transform.parent.name.Contains("FloatingStarBox"))
		{
			result = base.transform.parent.name;
		}
		else if (base.transform.parent && base.transform.parent.name == "StarBoxes")
		{
			result = base.name;
		}
		else
		{
			this.DisableGoal(true);
		}
		return result;
	}

	public override void OnCollected()
	{
		int sandboxStarCollectCount = GameProgress.GetSandboxStarCollectCount(Singleton<GameManager>.Instance.CurrentSceneName, base.NameKey);
		if (sandboxStarCollectCount <= 1)
		{
			int num = Singleton<GameConfigurationManager>.Instance.GetValue<int>("star_box_snout_value", "amount");
			if (num > 0 && !Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
			{
				GameProgress.AddSandboxStar(Singleton<GameManager>.Instance.CurrentSceneName, base.NameKey, true);
				num = ((!Singleton<DoubleRewardManager>.Instance.HasDoubleReward) ? num : (num * 2));
				GameProgress.AddSnoutCoins(num);
				Singleton<PlayerProgress>.Instance.AddExperience(PlayerProgress.ExperienceType.StarBoxCollectedSandbox);
				base.ShowXPParticles();
				for (int i = 0; i < num; i++)
				{
					SnoutCoinSingle.Spawn(base.transform.position - Vector3.forward, 1f * (float)i);
				}
			}
			else if (sandboxStarCollectCount < 1)
			{
				GameProgress.AddSandboxStar(Singleton<GameManager>.Instance.CurrentSceneName, base.NameKey, false);
			}
		}
		if (StarBox.onCollected != null)
		{
			StarBox.onCollected();
		}
		if (this.onCollect != null)
		{
			this.onCollect();
		}
	}

	private static List<StarBox> starBoxes = new List<StarBox>();

	public delegate void Collected();
}
