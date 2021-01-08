internal struct RewardDataHolder
{
	public int TimerMode
	{
		get
		{
			return this.mTimerMode;
		}
		set
		{
			this.mTimerMode = value;
		}
	}

	public int Level
	{
		get
		{
			return this.mLevel;
		}
		set
		{
			this.mLevel = value;
		}
	}

	public int PendingRewardLevel
	{
		get
		{
			return this.mPendingRewardLevel;
		}
		set
		{
			this.mPendingRewardLevel = value;
		}
	}

	public int RewardTime
	{
		get
		{
			return this.mRewardTime;
		}
		set
		{
			this.mRewardTime = value;
		}
	}

	public int ResetTime
	{
		get
		{
			return this.mResetTime;
		}
		set
		{
			this.mResetTime = value;
		}
	}

	public int ServerTime
	{
		get
		{
			return this.mServerTime;
		}
		set
		{
			this.mServerTime = value;
		}
	}

	public int ServerTimeUpdated
	{
		get
		{
			return this.mServerTimeUpdated;
		}
		set
		{
			this.mServerTimeUpdated = value;
		}
	}

	public int RandomSeed
	{
		get
		{
			return this.mRandomSeed;
		}
		set
		{
			this.mRandomSeed = value;
		}
	}

	private int mTimerMode;

	private int mLevel;

	private int mPendingRewardLevel;

	private int mRewardTime;

	private int mResetTime;

	private int mServerTime;

	private int mServerTimeUpdated;

	private int mRandomSeed;
}
