using System;
using UnityEngine;

public class DoubleRewardManager : Singleton<DoubleRewardManager>
{
	public bool HasAd
	{
		get
		{
			return this.hasAd;
		}
	}

	public bool LoadingAd
	{
		get
		{
			return this.loadingAd;
		}
	}

	public Status CurrentStatus
	{
		get
		{
			return this.status;
		}
	}

	public float DoubleRewardTimeRemaining
	{
		get
		{
			return this.doubleRewardEndTime - Time.realtimeSinceStartup;
		}
	}

	public bool HasDoubleReward
	{
		get
		{
			return this.DoubleRewardTimeRemaining > 0f;
		}
	}

	public int RewardCoins
	{
		get
		{
			return this.rewardCoins;
		}
	}

	public string FormattedRewardTime
	{
		get
		{
			TimeSpan time = TimeSpan.FromSeconds((double)Mathf.Clamp((float)this.rewardTime, 0f, float.MaxValue));
			if (time.TotalMinutes > 0.0)
			{
				return TimeFormatter.Format2Minutes(time);
			}
			return TimeFormatter.Format2Seconds(time);
		}
	}

	public string FormattedDoubleRewardTimeRemaining
	{
		get
		{
			TimeSpan time = TimeSpan.FromSeconds((double)Mathf.Clamp(this.DoubleRewardTimeRemaining, 0f, float.MaxValue));
			if (time.TotalMinutes > 0.0)
			{
				return TimeFormatter.Format2Minutes(time);
			}
			return TimeFormatter.Format2Seconds(time);
		}
	}

	private float TimeSinceLastCheck
	{
		get
		{
			if (this.lastCheckTime < 0f)
			{
				return float.MaxValue;
			}
			return Time.realtimeSinceStartup - this.lastCheckTime;
		}
	}

	private void Awake()
	{
		base.SetAsPersistant();
		this.status = DoubleRewardManager.Status.Uninitialized;
		this.lastCheckTime = -1f;
		if (Singleton<GameConfigurationManager>.Instance.HasData)
		{
			this.rewardTime = Singleton<GameConfigurationManager>.Instance.GetValue<int>("double_reward_duration", "seconds");
			this.rewardCoins = Singleton<GameConfigurationManager>.Instance.GetValue<int>("double_reward_coin_reward", "coin_reward");
			this.Initialize();
		}
		else
		{
			GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
			instance.OnHasData = (Action)Delegate.Combine(instance.OnHasData, new Action(delegate ()
			{
				this.rewardTime = Singleton<GameConfigurationManager>.Instance.GetValue<int>("double_reward_duration", "seconds");
				this.rewardCoins = Singleton<GameConfigurationManager>.Instance.GetValue<int>("double_reward_coin_reward", "coin_reward");
				this.Initialize();
			}));
		}
	}

	private void Initialize()
	{
		this.adReward = new AdReward(AdvertisementHandler.DoubleRewardPlacement);
		this.adReward.OnReady = (Action)Delegate.Combine(adReward.OnReady, new Action(this.OnAdReady));
		this.adReward.OnFailed = (Action)Delegate.Combine(adReward.OnFailed, new Action(this.OnAdFailure));
		this.adReward.OnAdFinished = (Action)Delegate.Combine(adReward.OnAdFinished, new Action(this.OnAdFinished));
		this.adReward.OnLoading = (Action)Delegate.Combine(adReward.OnLoading, new Action(this.OnAdLoading));
		this.adReward.OnCancel = (Action)Delegate.Combine(adReward.OnCancel, new Action(this.OnAdCancel));
		this.adReward.OnConfirmationFailed = (Action)Delegate.Combine(adReward.OnConfirmationFailed, new Action(this.OnAdConfirmationFailed));
		this.adReward.Load();
		this.serverTime = new ServerTime();
		this.serverTime.StatusChanged += this.OnServerTimeStatusChanged;
		this.serverTime.RefreshServerTime();
	}

	private void OnDestroy()
	{
		if (this.adReward != null)
		{
			this.adReward.Dispose();
		}
		if (this.serverTime != null)
		{
			this.serverTime.Destroy();
		}
	}

	private void OnAdReady()
	{
		this.hasAd = true;
		this.loadingAd = false;
		if (this.OnAdLoaded != null)
		{
			this.OnAdLoaded(true);
			this.OnAdLoaded = null;
		}
	}

	private void OnAdFailure()
	{
		this.hasAd = false;
		this.loadingAd = false;
		if (this.OnAdFailed != null)
		{
			this.OnAdFailed();
			this.OnAdLoaded = null;
		}
	}

	private void OnAdFinished()
	{
		this.hasAd = false;
		if (this.OnAdWatched != null)
		{
			this.OnAdWatched();
			this.OnAdWatched = null;
		}
	}

	private void OnAdLoading()
	{
		this.hasAd = false;
		this.loadingAd = true;
	}

	private void OnAdCancel()
	{
	}

	private void OnAdConfirmationFailed()
	{
		this.adReward.Load();
		if (this.OnConfirmationFailed != null)
		{
			this.OnConfirmationFailed();
			this.OnConfirmationFailed = null;
		}
	}

	private void OnServerTimeStatusChanged(int serverTime)
	{
		this.lastCheckTime = Time.realtimeSinceStartup;
		int doubleRewardStartTime = GameProgress.GetDoubleRewardStartTime();
		if (doubleRewardStartTime > 0)
		{
			int num = doubleRewardStartTime + this.rewardTime - serverTime;
			if (num > 0)
			{
				this.doubleRewardEndTime = Time.realtimeSinceStartup + (float)num;
			}
			else
			{
				this.doubleRewardEndTime = -1f;
			}
		}
		else
		{
			this.doubleRewardEndTime = -1f;
		}
		if (this.status == DoubleRewardManager.Status.Uninitialized)
		{
			this.status = DoubleRewardManager.Status.Initialized;
			if (this.OnInitialize != null)
			{
				this.OnInitialize();
			}
		}
	}

	private void SetDoubleRewardStartTime(bool success, int time)
	{
		if (success)
		{
			GameProgress.SetDoubleRewardStartTime(time);
			this.doubleRewardEndTime = Time.realtimeSinceStartup + (float)this.rewardTime;
			if (DoubleRewardIcon.Instance != null)
			{
				DoubleRewardIcon.Instance.gameObject.SetActive(true);
			}
		}
	}

	public void RefreshServerTime()
	{
		this.serverTime.RefreshServerTime();
	}

	public void RefreshAd()
	{
		if (!this.loadingAd)
		{
			this.adReward.Load();
		}
	}

	public void PlayAd()
	{
		if (this.hasAd)
		{
			this.adReward.Play();
		}
	}

	public Action OnInitialize;

	public Action OnAdWatched;

	public Action OnAdFailed;

	public Action<bool> OnAdLoaded;

	public Action OnConfirmationFailed;

	private AdReward adReward;

	private ServerTime serverTime;

	private int rewardTime;

	private int rewardCoins;

	private float lastCheckTime;

	private float doubleRewardEndTime;

	private bool hasAd;

	private bool loadingAd;

	private Status status;

	public enum Status
	{
		Uninitialized,
		Initialized,
		Error
	}
}
