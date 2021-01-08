using System;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : Singleton<RewardSystem>
{
	public List<DailyRewardBundle> Rewards
	{
		get
		{
			return this.rewards;
		}
	}

	public bool HasTime
	{
		get
		{
			return this.mServerTime != null && this.mServerTime.GetStatus() == ServerTime.Status.STATUS_OK;
		}
	}

	public static int AmountOfDays
	{
		get
		{
			return 30;
		}
	}

	public static int CurrentLevel
	{
		get
		{
			return RewardSystem.CurrentRewardStatus.Level;
		}
	}

	public static int PendingRewardLevel
	{
		get
		{
			return RewardSystem.CurrentRewardStatus.PendingRewardLevel;
		}
	}

	public static bool FreezeResetTime
	{
		get
		{
			return RewardSystem.mFreezeResetTime;
		}
		set
		{
			RewardSystem.mFreezeResetTime = value;
		}
	}

	private void Awake()
	{
		if (!Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		base.SetAsPersistant();
		this.mServerTime = new ServerTime();
		this.mServerTime.StatusChanged += this.HandleRewardLogic;
		RewardSystem.CurrentRewardStatus = this.LoadSavedData();
		this.HandleServerTime();
	}

	private void OnDestroy()
	{
		if (this.mLoginListener)
		{
			HatchManager.onLoginSuccess = (Action)Delegate.Remove(HatchManager.onLoginSuccess, new Action(this.HandleServerTime));
		}
		if (this.mServerTime != null)
		{
			this.mServerTime.Destroy();
		}
	}

	public void HandleServerTime()
	{
		if (HatchManager.IsLoggedIn)
		{
			RewardSystem.CurrentRewardStatus = this.LoadSavedData();
			this.mServerTime.RefreshServerTime();
		}
		else if (!this.mLoginListener)
		{
			this.mLoginListener = true;
			HatchManager.onLoginSuccess = (Action)Delegate.Combine(HatchManager.onLoginSuccess, new Action(this.HandleServerTime));
		}
	}

	public static int RandomSeed(int level)
	{
		return RewardSystem.CurrentRewardStatus.RandomSeed + level;
	}

	public static RewardIcon.State GetRewardStateForDay(int dayIndex)
	{
		int level = RewardSystem.CurrentRewardStatus.Level;
		RewardIcon.State result;
		if (dayIndex == level && Singleton<RewardSystem>.Instance.SecondsToNextReward() <= 0)
		{
			result = RewardIcon.State.ClaimNow;
		}
		else if (dayIndex < level)
		{
			result = RewardIcon.State.Claimed;
		}
		else
		{
			result = RewardIcon.State.NotAvailable;
		}
		return result;
	}

	public void ResetData()
	{
		this.SaveData(new RewardDataHolder
		{
			RewardTime = -1,
			Level = 0,
			TimerMode = ((!Singleton<BuildCustomizationLoader>.Instance.CheatsEnabled) ? 0 : RewardSystem.CurrentRewardStatus.TimerMode),
			RandomSeed = UnityEngine.Random.Range(0, int.MaxValue),
			ServerTime = -1,
			ResetTime = -1,
			ServerTimeUpdated = -1,
			PendingRewardLevel = -1
		});
	}

	public int GetTimerMode()
	{
		return RewardSystem.CurrentRewardStatus.TimerMode;
	}

	public void ChangeTimerMode()
	{
		if (Singleton<BuildCustomizationLoader>.Instance.CheatsEnabled)
		{
			if (RewardSystem.CurrentRewardStatus.TimerMode < 4)
			{
				RewardSystem.CurrentRewardStatus.TimerMode = RewardSystem.CurrentRewardStatus.TimerMode + 1;
			}
			else
			{
				RewardSystem.CurrentRewardStatus.TimerMode = 0;
			}
		}
		else
		{
			RewardSystem.CurrentRewardStatus.TimerMode = 0;
		}
		GameProgress.SetInt("AmazonTimerMode", RewardSystem.CurrentRewardStatus.TimerMode, GameProgress.Location.Local);
		RewardSystem.CurrentRewardStatus = this.LoadSavedData();
		this.mNeedReset = true;
	}

	public void OpenDialog()
	{
		if (this.rewardDialog != null)
		{
			this.rewardDialog.Open();
		}
	}

	public void SetDialogView(RewardDialog dialog)
	{
		this.rewardDialog = dialog;
		this.HandleServerTime();
	}

	private RewardDataHolder LoadSavedData()
	{
		return new RewardDataHolder
		{
			Level = this.GetSavedRewardLevel(),
			RewardTime = this.GetSavedRewardTime(),
			ResetTime = this.GetSavedResetTime(),
			TimerMode = this.GetSavedTimerMode(),
			RandomSeed = this.GetSavedRandomSeed(),
			PendingRewardLevel = this.GetSavedPendingRewardLevel()
		};
	}

	private int GetSavedTimerMode()
	{
		return GameProgress.GetInt("AmazonTimerMode", 0, GameProgress.Location.Local, null);
	}

	private int GetSavedRewardLevel()
	{
		return GameProgress.GetInt("AmazonRewardLevel", 0, GameProgress.Location.Local, null);
	}

	private int GetSavedRewardTime()
	{
		return GameProgress.GetInt("AmazonRewardTime", 0, GameProgress.Location.Local, null);
	}

	private int GetSavedResetTime()
	{
		return GameProgress.GetInt("AmazonResetTime", 0, GameProgress.Location.Local, null);
	}

	private int GetSavedRandomSeed()
	{
		return GameProgress.GetInt("AmazonRandomRewardSeed", UnityEngine.Random.Range(0, int.MaxValue), GameProgress.Location.Local, null);
	}

	private int GetSavedPendingRewardLevel()
	{
		return GameProgress.GetInt("AmazonPendingRewardLevel", 0, GameProgress.Location.Local, null);
	}

	private RewardDataHolder CalculateNewTimers(int time)
	{
		RewardDataHolder result = default(RewardDataHolder);
		result.ServerTime = time;
		result.ServerTimeUpdated = Mathf.RoundToInt(Time.realtimeSinceStartup);
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		DateTime dateTime2 = dateTime.AddSeconds((double)time);
		DateTime dateTime3;
		DateTime dateTime4;
		if (Singleton<BuildCustomizationLoader>.Instance.CheatsEnabled)
		{
			dateTime3 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, dateTime2.Hour, dateTime2.Minute, dateTime2.Second, DateTimeKind.Utc);
			dateTime4 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, dateTime2.Hour, dateTime2.Minute, dateTime2.Second, DateTimeKind.Utc);
			switch (RewardSystem.CurrentRewardStatus.TimerMode)
			{
			case 0:
			{
				DateTime dateTime5 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, 0, 0, 0, DateTimeKind.Utc);
				dateTime3 = dateTime5.AddDays(1.0);
				DateTime dateTime6 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, 0, 0, 0, DateTimeKind.Utc);
				dateTime4 = dateTime6.AddDays(2.0);
				break;
			}
			case 1:
				dateTime3 = dateTime3.AddMinutes(15.0);
				dateTime4 = dateTime4.AddMinutes(30.0);
				break;
			case 2:
				dateTime3 = dateTime3.AddMinutes(5.0);
				dateTime4 = dateTime4.AddMinutes(15.0);
				break;
			case 3:
				dateTime3 = dateTime3.AddMinutes(1.0);
				dateTime4 = dateTime4.AddMinutes(1.0).AddSeconds(15.0);
				break;
			case 4:
				dateTime3 = dateTime3.AddSeconds(5.0);
				dateTime4 = dateTime4.AddSeconds(10.0);
				break;
			}
		}
		else
		{
			DateTime dateTime7 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, 0, 0, 0, DateTimeKind.Utc);
			dateTime3 = dateTime7.AddDays(1.0);
			DateTime dateTime8 = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, 0, 0, 0, DateTimeKind.Utc);
			dateTime4 = dateTime8.AddDays(2.0);
		}
		result.RewardTime = Convert.ToInt32(dateTime3.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
		result.ResetTime = Convert.ToInt32(dateTime4.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
		return result;
	}

	public bool IsRewardReady()
	{
		return this.SecondsToNextReward() <= 0 || RewardSystem.PendingRewardLevel >= 0;
	}

	public int SecondsToNextReward()
	{
		int num = this.SecondsToTriggerTime(RewardSystem.CurrentRewardStatus.ServerTime, RewardSystem.CurrentRewardStatus.RewardTime);
		return num - (Mathf.RoundToInt(Time.realtimeSinceStartup) - RewardSystem.CurrentRewardStatus.ServerTimeUpdated);
	}

	public int SecondsToNextReset()
	{
		int num = this.SecondsToTriggerTime(RewardSystem.CurrentRewardStatus.ServerTime, RewardSystem.CurrentRewardStatus.ResetTime);
		return num - (Mathf.RoundToInt(Time.realtimeSinceStartup) - RewardSystem.CurrentRewardStatus.ServerTimeUpdated);
	}

	private int CurrentTime()
	{
		return RewardSystem.CurrentRewardStatus.ServerTime + (Mathf.RoundToInt(Time.realtimeSinceStartup) - RewardSystem.CurrentRewardStatus.ServerTimeUpdated);
	}

	private int SecondsToTriggerTime(int currentTime, int triggerTime)
	{
		return triggerTime - currentTime;
	}

	private string TimeToNextTriggerText(int currentTime, int triggerTime)
	{
		int num = triggerTime - currentTime;
		if (num <= 60)
		{
			return (triggerTime - currentTime).ToString() + " seconds";
		}
		if (num <= 3600)
		{
			return ((int)Math.Round((double)(triggerTime - currentTime) / 60.0)).ToString() + " minutes";
		}
		return ((int)Math.Round((double)(triggerTime - currentTime) / 3600.0)).ToString() + " hours";
	}

	private void SaveData(RewardDataHolder data)
	{
		GameProgress.SetInt("AmazonPendingRewardLevel", data.PendingRewardLevel, GameProgress.Location.Local);
		GameProgress.SetInt("AmazonRandomRewardSeed", data.RandomSeed, GameProgress.Location.Local);
		GameProgress.SetInt("AmazonRewardTime", data.RewardTime, GameProgress.Location.Local);
		GameProgress.SetInt("AmazonResetTime", data.ResetTime, GameProgress.Location.Local);
		GameProgress.SetInt("AmazonRewardLevel", data.Level, GameProgress.Location.Local);
		GameProgress.SetInt("AmazonTimerMode", data.TimerMode, GameProgress.Location.Local);
	}

	private PrizeType GetRewardObjectType(int level)
	{
		PrizeType result;
		switch (level % 4)
		{
		case 1:
			result = PrizeType.SuperMagnet;
			break;
		case 2:
			result = PrizeType.SuperGlue;
			break;
		case 3:
			result = PrizeType.SuperMechanic;
			break;
		default:
			result = PrizeType.TurboCharge;
			break;
		}
		return result;
	}

	private void GiveReward(DailyRewardBundle rewardBundle)
	{
		if (rewardBundle == null)
		{
			return;
		}
		List<DailyReward> list = rewardBundle.GetRewards(RewardSystem.CurrentRewardStatus.PendingRewardLevel);
		if (list == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			DailyReward dailyReward = list[i];
			string customTypeOfGain = "Odyssey daily reward";
			switch (dailyReward.prize)
			{
			case PrizeType.SuperGlue:
				GameProgress.AddSuperGlue(dailyReward.prizeCount);
				if (Singleton<IapManager>.Instance != null)
				{
					Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.SuperGlueSingle, dailyReward.prizeCount, customTypeOfGain);
				}
				break;
			case PrizeType.SuperMagnet:
				GameProgress.AddSuperMagnet(dailyReward.prizeCount);
				if (Singleton<IapManager>.Instance != null)
				{
					Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.SuperMagnetSingle, dailyReward.prizeCount, customTypeOfGain);
				}
				break;
			case PrizeType.TurboCharge:
				GameProgress.AddTurboCharge(dailyReward.prizeCount);
				if (Singleton<IapManager>.Instance != null)
				{
					Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.TurboChargeSingle, dailyReward.prizeCount, customTypeOfGain);
				}
				break;
			case PrizeType.SuperMechanic:
				GameProgress.AddBluePrints(dailyReward.prizeCount);
				if (Singleton<IapManager>.Instance != null)
				{
					Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.BlueprintSingle, dailyReward.prizeCount, customTypeOfGain);
				}
				break;
			case PrizeType.NightVision:
				GameProgress.AddNightVision(dailyReward.prizeCount);
				if (Singleton<IapManager>.Instance != null)
				{
					Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.NightVisionSingle, dailyReward.prizeCount, customTypeOfGain);
				}
				break;
			}
		}
	}

	private void HandleRewardLogic(int time)
	{
		if (this.mNeedReset)
		{
			this.mNeedReset = false;
			RewardDataHolder rewardDataHolder = this.CalculateNewTimers(time);
			RewardSystem.CurrentRewardStatus.ServerTime = time;
			RewardSystem.CurrentRewardStatus.RewardTime = rewardDataHolder.RewardTime;
			RewardSystem.CurrentRewardStatus.ResetTime = rewardDataHolder.ResetTime;
			RewardSystem.CurrentRewardStatus.ServerTimeUpdated = rewardDataHolder.ServerTimeUpdated;
			this.SaveData(RewardSystem.CurrentRewardStatus);
		}
		if (this.ResetTimePassed(time, RewardSystem.CurrentRewardStatus.ResetTime) || RewardSystem.CurrentRewardStatus.Level >= RewardSystem.AmountOfDays)
		{
			if (RewardSystem.CurrentRewardStatus.Level >= RewardSystem.AmountOfDays)
			{
				this.mNeedReset = true;
			}
			this.ResetData();
			RewardSystem.CurrentRewardStatus = this.LoadSavedData();
			this.HandleRewardLogic(time);
			return;
		}
		if (this.EligibleForReward(time, RewardSystem.CurrentRewardStatus.RewardTime))
		{
			int level = RewardSystem.CurrentRewardStatus.Level;
			RewardDataHolder data = this.CalculateNewTimers(time);
			data.Level = RewardSystem.CurrentRewardStatus.Level;
			data.TimerMode = RewardSystem.CurrentRewardStatus.TimerMode;
			RewardSystem.CurrentRewardStatus.ServerTime = time;
			this.SaveData(data);
			if (this.rewardDialog != null)
			{
				if (!this.rewardDialog.gameObject.activeInHierarchy)
				{
					this.OpenDialog();
				}
				RewardSystem.CurrentRewardStatus.PendingRewardLevel = level;
			}
		}
		else
		{
			RewardSystem.CurrentRewardStatus.ServerTime = time;
			RewardSystem.CurrentRewardStatus.ServerTimeUpdated = Mathf.RoundToInt(Time.realtimeSinceStartup);
		}
	}

	public void RefreshData()
	{
		this.mServerTime.RefreshServerTime();
	}

	public void ClaimReward()
	{
		int currentTime = this.CurrentTime();
		if (!RewardSystem.mFreezeResetTime && this.ResetTimePassed(currentTime, RewardSystem.CurrentRewardStatus.ResetTime))
		{
			this.mServerTime.RefreshServerTime();
			return;
		}
		if (this.EligibleForReward(currentTime, RewardSystem.CurrentRewardStatus.RewardTime))
		{
			RewardSystem.CurrentRewardStatus.PendingRewardLevel = RewardSystem.CurrentRewardStatus.Level;
		}
		else if (RewardSystem.CurrentRewardStatus.PendingRewardLevel < 0)
		{
			return;
		}
		DailyRewardBundle rewardBundle = this.rewards[RewardSystem.CurrentRewardStatus.PendingRewardLevel];
		this.GiveReward(rewardBundle);
		RewardSystem.CurrentRewardStatus.PendingRewardLevel = -1;
		RewardSystem.CurrentRewardStatus.Level = RewardSystem.CurrentRewardStatus.Level + 1;
		this.mNeedReset = true;
		this.mServerTime.RefreshServerTime();
	}

	private bool ResetTimePassed(int currentTime, int resetTime)
	{
		return !RewardSystem.mFreezeResetTime && resetTime > 0 && currentTime > resetTime;
	}

	private bool EligibleForReward(int currentTime, int rewardTime)
	{
		return this.mServerTime.GetStatus() == ServerTime.Status.STATUS_OK && (currentTime >= rewardTime || rewardTime == -1);
	}

	[SerializeField]
	private List<DailyRewardBundle> rewards;

	public RewardDialog rewardDialog;

	private static bool mFreezeResetTime;

	private const string RANDOM_REWARD_SEED_KEY = "AmazonRandomRewardSeed";

	private const string PENDING_REWARD_LEVEL_KEY = "AmazonPendingRewardLevel";

	private const string LEVEL_KEY = "AmazonRewardLevel";

	private const string REWARD_KEY = "AmazonRewardTime";

	private const string RESET_KEY = "AmazonResetTime";

	private const string TIMER_KEY = "AmazonTimerMode";

	private const string TAG = "LOG - RewardSystem, ";

	private bool mLoginListener;

	private ServerTime mServerTime;

	private bool mNeedReset;

	private static RewardDataHolder CurrentRewardStatus;
}
