using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyChallenge : Singleton<DailyChallenge>
{
	public TimeSpan DailyChallengeTimeLeft
	{
		get
		{
			if (this.initialized)
			{
				return new TimeSpan(0, 0, 0, Mathf.RoundToInt(Singleton<TimeManager>.Instance.TimeLeft("daily_challenge_timer")));
			}
			return default(TimeSpan);
		}
	}

	public int Count
	{
		get
		{
			return (this.dailyChallenges != null) ? this.dailyChallenges.Length : 0;
		}
	}

	public ChallengeInfo[] Challenges
	{
		get
		{
			return this.dailyChallenges;
		}
	}

	public bool HasChallenge
	{
		get
		{
			return this.dailyChallenges != null;
		}
	}

	public bool Initialized
	{
		get
		{
			return this.initialized;
		}
	}

	public int Left
	{
		get
		{
			if (!this.HasChallenge)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < this.dailyChallenges.Length; i++)
			{
				if (!this.dailyChallenges[i].collected)
				{
					num++;
				}
			}
			return num;
		}
	}

	private bool FirstChallengeCollected
	{
		get
		{
			return GameProgress.GetBool("FirstChallengeCollected", false, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetBool("FirstChallengeCollected", value, GameProgress.Location.Local);
		}
	}

	private void Awake()
	{
		base.SetAsPersistant();
		this.dailyChallengeProgram = new DailyChallengeProgram();
		base.StartCoroutine(this.WaitFor(new Func<bool>(this.CanInitialize), new Action(this.Initialize)));
		EventManager.Connect(new EventManager.OnEvent<GameLevelLoaded>(this.OnLevelLoaded));
		EventManager.Connect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameLevelLoaded>(this.OnLevelLoaded));
		EventManager.Disconnect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
	}

	private void OnLevelLoaded(GameLevelLoaded data)
	{
		LevelManager levelManager = WPFMonoBehaviour.levelManager;
		if (levelManager != null && levelManager.CurrentGameMode is BaseGameMode && !levelManager.m_sandbox && !levelManager.m_raceLevel)
		{
			int index = 0;
			if (this.IsDailyChallenge(data.episodeIndex, data.levelIndex, out index) && !this.dailyChallenges[index].collected)
			{
				DailyLevel daily = Singleton<GameManager>.instance.gameData.m_dailyChallengeData.GetDaily(this.dailyChallenges[index].DailyKey);
				Vector3 position;
				if (daily != null && daily.GetPosition(this.dailyChallenges[index].positionIndex, out position))
				{
					GameObject gameObject = WPFMonoBehaviour.gameData.m_lootCrates[(int)this.TodaysLootCrate(index)];
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject, position, Quaternion.identity);
					LootCrate component = gameObject2.GetComponent<LootCrate>();
					LootCrate lootCrate = component;
					lootCrate.OnCollect = (Action)Delegate.Combine(lootCrate.OnCollect, new Action(delegate()
					{
						this.OnDailyRewardCollected(index);
					}));
					LootCrate lootCrate2 = component;
					lootCrate2.RewardExperience = (Func<int>)Delegate.Combine(lootCrate2.RewardExperience, new Func<int>(this.RewardExperience));
					component.SetAnalyticData(index, this.dailyChallenges[index].adRevealed);
					this.dailyChallenges[index].revealed = true;
					UnityEngine.Debug.LogWarning("Instantiated " + gameObject.name + " at position " + position.ToString());
				}
			}
		}
	}

	private void OnPlayerChanged(PlayerChangedEvent data)
	{
		if (!this.initialized)
		{
			return;
		}
		this.initialized = false;
		base.StartCoroutine(this.WaitFor(new Func<bool>(this.CanInitialize), new Action(this.Initialize)));
	}

	private bool CanInitialize()
	{
		return LootCrateRewards.Initialized && Singleton<TimeManager>.Instance.Initialized && Singleton<GameConfigurationManager>.Instance.HasData && this.dailyChallengeProgram.Initialized && Singleton<PredefinedRewards>.Instance && Singleton<PredefinedRewards>.Instance.Initialized;
	}

	private void Initialize()
	{
		if (this.initialized)
		{
			return;
		}
		Hashtable values = Singleton<GameConfigurationManager>.Instance.GetValues("daily_challenge");
		if (values != null)
		{
			this.challengeConfigs = new ChallengeConfigs(values);
		}
		if (Singleton<TimeManager>.Instance.HasTimer("daily_challenge_timer"))
		{
			Singleton<TimeManager>.Instance.Subscribe("daily_challenge_timer", new OnTimedOut(this.OnDailyRewardEnded));
			this.dailyChallenges = this.LoadDailyChallenges();
		}
		else
		{
			this.CreateNewChallenges();
		}
		this.initialized = true;
		if (this.OnInitialize != null)
		{
			this.OnInitialize();
			this.OnInitialize = null;
		}
		base.StartCoroutine(this.WaitForTimeManager());
	}

	private IEnumerator WaitForTimeManager()
	{
		while (!Singleton<TimeManager>.IsInstantiated())
		{
			yield return null;
		}
		if (Singleton<TimeManager>.Instance.Initialized)
		{
			this.AddNotifications();
		}
		else
		{
			Singleton<TimeManager>.Instance.OnInitialize += this.AddNotifications;
		}
		yield break;
	}

	private void AddNotifications()
	{
		Singleton<TimeManager>.Instance.OnInitialize -= this.AddNotifications;
	}

	private void OnDailyRewardEnded(int secondsAgo)
	{
		this.CreateNewChallenges();
		if (this.OnDailyChallengeChanged != null)
		{
			this.OnDailyChallengeChanged();
		}
	}

	private void OnDailyRewardCollected(int index)
	{
		if (this.dailyChallenges == null || index < 0 || index >= this.dailyChallenges.Length)
		{
			return;
		}
		if (!this.FirstChallengeCollected && index == 0)
		{
			this.FirstChallengeCollected = true;
		}
		this.dailyChallenges[index].collected = true;
		this.SaveDailyChallenge(this.dailyChallenges[index], index);
	}

	private int RewardExperience()
	{
		ResourceBar.Instance.ShowItem(ResourceBar.Item.PlayerProgress, true, true);
		int num = 0;
		for (int i = 0; i < this.dailyChallenges.Length; i++)
		{
			if (this.dailyChallenges[i].collected)
			{
				num++;
			}
		}
		PlayerProgress.ExperienceType experienceType = PlayerProgress.ExperienceType.DailyLootCrateCollected1st;
		if (num == 2)
		{
			experienceType = PlayerProgress.ExperienceType.DailyLootCrateCollected2nd;
		}
		else if (num == 3)
		{
			experienceType = PlayerProgress.ExperienceType.DailyLootCrateCollected3rd;
		}
		return Singleton<PlayerProgress>.Instance.AddExperience(experienceType);
	}

	private void CreateNewChallenges()
	{
		this.dailyChallenges = new ChallengeInfo[3];
		for (int i = 0; i < 3; i++)
		{
			this.dailyChallenges[i] = DailyChallenge.ChallengeInfo.Empty;
		}
		for (int j = 0; j < 3; j++)
		{
			this.dailyChallenges[j] = this.CreateNewChallenge(this.TodaysLootCrate(j), 0);
		}
		this.SaveDailyChallenges(this.dailyChallenges);
		this.CreateNewTimer();
	}

	private ChallengeInfo CreateNewChallenge(LootCrateType type, int tryCount = 0)
	{
		if (tryCount > 100)
		{
			return default(ChallengeInfo);
		}
		float num = UnityEngine.Random.Range(0f, 100f);
		float unlockLevelChance = this.challengeConfigs.GetUnlockLevelChance(type);
		float num2 = unlockLevelChance + this.challengeConfigs.GetLockedLevelChance1(type);
		float num3 = num2 + this.challengeConfigs.GetLockedLevelChance2(type);
		float num4 = num3 + this.challengeConfigs.GetUnlockedJokerLevelChance(type);
		float num5 = num4 + this.challengeConfigs.GetLockedJokerLevelChanche(type);
		List<ChallengeInfo> list;
		List<ChallengeInfo> list2;
		List<ChallengeInfo> list3;
		List<ChallengeInfo> list4;
		List<ChallengeInfo> list5;
		this.GetPossibleLevels(type, out list, out list2, out list3, out list4, out list5);
        ChallengeInfo challengeInfo;
		if (num < unlockLevelChance && list.Count > 0)
		{
			challengeInfo = list[UnityEngine.Random.Range(0, list.Count)];
		}
		else if (num < num2 && list2.Count > 0)
		{
			challengeInfo = list2[UnityEngine.Random.Range(0, list2.Count)];
		}
		else if (num < num3 && list3.Count > 0)
		{
			challengeInfo = list3[UnityEngine.Random.Range(0, list3.Count)];
		}
		else if (num < num3 && list3.Count <= 0 && list2.Count > 0)
		{
			challengeInfo = list2[UnityEngine.Random.Range(0, list2.Count)];
		}
		else if (num < num3 && list3.Count <= 0 && list.Count > 0)
		{
			challengeInfo = list[UnityEngine.Random.Range(0, list.Count)];
		}
		else if (num < num4 && list4.Count > 0)
		{
			challengeInfo = list4[UnityEngine.Random.Range(0, list4.Count)];
		}
		else if (num <= num5 && list5.Count > 0)
		{
			challengeInfo = list5[UnityEngine.Random.Range(0, list5.Count)];
		}
		else if (num <= num5 && list5.Count <= 0 && list4.Count > 0)
		{
			challengeInfo = list4[UnityEngine.Random.Range(0, list4.Count)];
		}
		else
		{
			challengeInfo = this.CreateNewChallenge(type, tryCount + 1);
		}
		if (this.IsDailyChallenge(challengeInfo) && !string.IsNullOrEmpty(challengeInfo.levelName))
		{
			challengeInfo = this.CreateNewChallenge(type, tryCount);
		}
		DailyLevel daily = Singleton<GameManager>.instance.gameData.m_dailyChallengeData.GetDaily(challengeInfo.DailyKey);
		if (daily != null)
		{
			do
			{
				challengeInfo.positionIndex = UnityEngine.Random.Range(0, daily.Count);
			}
			while (!daily.ValidPositionIndex(challengeInfo.positionIndex));
		}
		return challengeInfo;
	}

	private void CreateNewTimer()
	{
		DateTime currentTime = Singleton<TimeManager>.Instance.CurrentTime;
		DateTime time = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day);
		time = time.AddDays(1.0);
		if (Singleton<TimeManager>.Instance.HasTimer("daily_challenge_timer"))
		{
			Singleton<TimeManager>.Instance.RemoveTimer("daily_challenge_timer");
		}
		Singleton<TimeManager>.Instance.CreateTimer("daily_challenge_timer", time, new OnTimedOut(this.OnDailyRewardEnded));
	}

	private void GetPossibleLevels(LootCrateType type, out List<ChallengeInfo> unlockedLevels, out List<ChallengeInfo> lockedLevels1, out List<ChallengeInfo> lockedLevels2, out List<ChallengeInfo> unlockedJokerLevels, out List<ChallengeInfo> lockedJokerLevels)
	{
		int num = this.challengeConfigs.MaxUnlockDistance1(type);
		int num2 = this.challengeConfigs.MaxUnlockDistance2(type);
		unlockedLevels = new List<ChallengeInfo>();
		lockedLevels1 = new List<ChallengeInfo>();
		lockedLevels2 = new List<ChallengeInfo>();
		unlockedJokerLevels = new List<ChallengeInfo>();
		lockedJokerLevels = new List<ChallengeInfo>();
		if (!this.FirstChallengeCollected && !this.IsDailyChallenge(0, 0, 0))
		{
			unlockedLevels.Add(new ChallengeInfo(LevelInfo.GetLevelNames(0)[0], 0, 0));
			return;
		}
		for (int i = 0; i < 6; i++)
		{
			List<string> levelNames = LevelInfo.GetLevelNames(i);
			int num3 = 0;
			for (int j = 0; j < levelNames.Count; j++)
			{
				if (LevelInfo.IsStarLevel(i, j) && LevelInfo.IsLevelUnlocked(i, j))
				{
					unlockedJokerLevels.Add(new ChallengeInfo(levelNames[j], i, j));
				}
				else if (LevelInfo.IsStarLevel(i, j) && !LevelInfo.IsLevelUnlocked(i, j))
				{
					num3++;
					lockedJokerLevels.Add(new ChallengeInfo(levelNames[j], i, j));
				}
				else if (LevelInfo.IsLevelUnlocked(i, j))
				{
					unlockedLevels.Add(new ChallengeInfo(levelNames[j], i, j));
				}
				else if (num3 < num)
				{
					num3++;
					lockedLevels1.Add(new ChallengeInfo(levelNames[j], i, j));
				}
				else
				{
					num3++;
					lockedLevels2.Add(new ChallengeInfo(levelNames[j], i, j));
				}
				if (num3 >= num && num3 >= num2)
				{
					break;
				}
			}
		}
	}

	public LootCrateType TodaysLootCrate(int index)
	{
		DateTime date = DateTime.Today;
		if (Singleton<TimeManager>.IsInstantiated())
		{
			date = Singleton<TimeManager>.Instance.CurrentTime;
		}
		return (!this.overrideLoot) ? this.dailyChallengeProgram.GetLootCrateType(date, index) : this.lootCrate;
	}

	public LootCrateType TomorrowsLootCrate(int index)
	{
		DateTime dateTime = DateTime.Today;
		if (Singleton<TimeManager>.IsInstantiated())
		{
			dateTime = Singleton<TimeManager>.Instance.CurrentTime;
		}
		return this.dailyChallengeProgram.GetLootCrateType(dateTime.AddDays(1.0), index);
	}

	public bool DailyChallengeCollected(int index)
	{
		return this.dailyChallenges[index].collected;
	}

	public bool AllLocationsRevealed()
	{
		for (int i = 0; i < this.dailyChallenges.Length; i++)
		{
			if (!this.dailyChallenges[i].revealed)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsLocationRevealed(int index)
	{
		return this.dailyChallenges[index].revealed;
	}

	public void SetLocationsRevealed()
	{
		for (int i = 0; i < this.dailyChallenges.Length; i++)
		{
			this.SetLocationRevealed(i);
		}
	}

	public void SetLocationRevealed(int index)
	{
		this.dailyChallenges[index].revealed = true;
		this.SaveDailyChallenge(this.dailyChallenges[index], index);
	}

	public void SetLocationAdRevealed(int index)
	{
		this.dailyChallenges[index].adRevealed = true;
		this.SaveDailyChallenge(this.dailyChallenges[index], index);
	}

	public bool IsDailyChallenge(ChallengeInfo info)
	{
		if (this.dailyChallenges == null)
		{
			return false;
		}
		for (int i = 0; i < this.dailyChallenges.Length; i++)
		{
			if (this.dailyChallenges[i].Equals(info))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsDailyChallenge(int epIndex, int lvlIndex, int posIndex)
	{
		if (this.dailyChallenges == null)
		{
			return false;
		}
		for (int i = 0; i < this.dailyChallenges.Length; i++)
		{
			if (this.dailyChallenges[i].episodeIndex == epIndex && this.dailyChallenges[i].levelIndex == lvlIndex && this.dailyChallenges[i].positionIndex == posIndex)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsDailyChallenge(string levelName, out int index)
	{
		index = -1;
		if (this.dailyChallenges == null)
		{
			return false;
		}
		for (int i = 0; i < this.dailyChallenges.Length; i++)
		{
			if (this.dailyChallenges[i].levelName == levelName)
			{
				index = i;
				return true;
			}
		}
		return false;
	}

	public bool IsDailyChallenge(int episodeIndex, int levelIndex, out int index)
	{
		index = -1;
		if (this.dailyChallenges == null)
		{
			return false;
		}
		for (int i = 0; i < this.dailyChallenges.Length; i++)
		{
			if (this.dailyChallenges[i].episodeIndex == episodeIndex && this.dailyChallenges[i].levelIndex == levelIndex)
			{
				index = i;
				return true;
			}
		}
		return false;
	}

	private void SaveDailyChallenges(ChallengeInfo[] infos)
	{
		if (infos == null)
		{
			return;
		}
		for (int i = 0; i < infos.Length; i++)
		{
			this.SaveDailyChallenge(infos[i], i);
		}
	}

	private void SaveDailyChallenge(ChallengeInfo info, int index)
	{
		GameProgress.SetString(string.Format("DailyChallenge_{0}_LevelName", index), info.levelName, GameProgress.Location.Local);
		GameProgress.SetInt(string.Format("DailyChallenge_{0}_EpisodeIndex", index), info.episodeIndex, GameProgress.Location.Local);
		GameProgress.SetInt(string.Format("DailyChallenge_{0}_LevelIndex", index), info.levelIndex, GameProgress.Location.Local);
		GameProgress.SetInt(string.Format("DailyChallenge_{0}_PositionIndex", index), info.positionIndex, GameProgress.Location.Local);
		GameProgress.SetBool(string.Format("DailyChallenge_{0}_Collected", index), info.collected, GameProgress.Location.Local);
		GameProgress.SetBool(string.Format("DailyChallenge_{0}_Revealed", index), info.revealed, GameProgress.Location.Local);
		GameProgress.SetBool(string.Format("DailyChallenge_{0}_AdRevealed", index), info.adRevealed, GameProgress.Location.Local);
	}

	private ChallengeInfo[] LoadDailyChallenges()
	{
        ChallengeInfo[] array = new ChallengeInfo[3];
		for (int i = 0; i < 3; i++)
		{
			array[i] = this.LoadDailyChallenge(i);
		}
		return array;
	}

	private ChallengeInfo LoadDailyChallenge(int index)
	{
		return new ChallengeInfo(GameProgress.GetString(string.Format("DailyChallenge_{0}_LevelName", index), string.Empty, GameProgress.Location.Local, null), GameProgress.GetInt(string.Format("DailyChallenge_{0}_EpisodeIndex", index), -1, GameProgress.Location.Local, null), GameProgress.GetInt(string.Format("DailyChallenge_{0}_LevelIndex", index), -1, GameProgress.Location.Local, null), GameProgress.GetInt(string.Format("DailyChallenge_{0}_PositionIndex", index), -1, GameProgress.Location.Local, null), GameProgress.GetBool(string.Format("DailyChallenge_{0}_Collected", index), false, GameProgress.Location.Local, null), GameProgress.GetBool(string.Format("DailyChallenge_{0}_Revealed", index), Singleton<BuildCustomizationLoader>.Instance.IsOdyssey, GameProgress.Location.Local, null), GameProgress.GetBool(string.Format("DailyChallenge_{0}_AdRevealed", index), false, GameProgress.Location.Local, null));
	}

	private void DeleteDailyChallenges()
	{
		for (int i = 0; i < 3; i++)
		{
			this.DeleteDailyChallenge(i);
		}
	}

	private void DeleteDailyChallenge(int index)
	{
		GameProgress.DeleteKey(string.Format("DailyChallenge_{0}_LevelName", index), GameProgress.Location.Local);
		GameProgress.DeleteKey(string.Format("DailyChallenge_{0}_EpisodeIndex", index), GameProgress.Location.Local);
		GameProgress.DeleteKey(string.Format("DailyChallenge_{0}_LevelIndex", index), GameProgress.Location.Local);
		GameProgress.DeleteKey(string.Format("DailyChallenge_{0}_PositionIndex", index), GameProgress.Location.Local);
		GameProgress.DeleteKey(string.Format("DailyChallenge_{0}_Collected", index), GameProgress.Location.Local);
		GameProgress.DeleteKey(string.Format("DailyChallenge_{0}_Revealed", index), GameProgress.Location.Local);
		GameProgress.DeleteKey(string.Format("DailyChallenge_{0}_AdRevealed", index), GameProgress.Location.Local);
	}

	public void SetDailyChallenge(int challengeIndex, int episodeIndex, int levelIndex)
	{
	}

	public void SetDailyLootCrate(LootCrateType type)
	{
	}

	public void ForceNewChallenge()
	{
	}

	private IEnumerator WaitFor(Func<bool> function, Action OnFinish)
	{
		while (!function())
		{
			yield return null;
		}
		if (OnFinish != null)
		{
			OnFinish();
		}
		yield break;
	}

	public Action OnInitialize;

	public Action OnDailyChallengeChanged;

	private const int CHALLENGE_COUNT = 3;

	private const string TIMER_ID = "daily_challenge_timer";

	private const string CONFIG_ID = "daily_challenge";

	private bool initialized;

	private ChallengeInfo[] dailyChallenges;

	private DailyChallengeProgram dailyChallengeProgram;

	private ChallengeConfigs challengeConfigs;

	private bool overrideLoot;

	private LootCrateType lootCrate;

	public struct ChallengeInfo
	{
		public ChallengeInfo(string levelName, int episodeIndex, int levelIndex)
		{
			this.levelName = levelName;
			this.episodeIndex = episodeIndex;
			this.levelIndex = levelIndex;
			this.positionIndex = 0;
			this.collected = false;
			this.revealed = Singleton<BuildCustomizationLoader>.instance.IsOdyssey;
			this.adRevealed = false;
		}

		public ChallengeInfo(string levelName, int episodeIndex, int levelIndex, int positionIndex, bool collected, bool revealed, bool adRevealed)
		{
			this.levelName = levelName;
			this.episodeIndex = episodeIndex;
			this.levelIndex = levelIndex;
			this.positionIndex = positionIndex;
			this.collected = collected;
			this.revealed = revealed;
			this.adRevealed = adRevealed;
		}

		public static ChallengeInfo Empty
		{
			get
			{
				return new ChallengeInfo(null, -1, -1);
			}
		}

		public string DailyKey
		{
			get
			{
				return string.Format("{0}-{1}", this.episodeIndex, this.levelIndex);
			}
		}

		public string ImageKey
		{
			get
			{
				return string.Format("{0}-{1}-{2}.png", DailyChallenge.ChallengeInfo.episodes[this.episodeIndex], this.LevelCode, this.positionIndex);
			}
		}

		public string Location
		{
			get
			{
				return string.Format("{0}-{1}", DailyChallenge.ChallengeInfo.episodes[this.episodeIndex], this.LevelCode);
			}
		}

		private string LevelCode
		{
			get
			{
				return ((this.levelIndex + 1) % 5 != 0) ? (this.levelIndex + 1 - this.levelIndex / 5).ToString() : DailyChallenge.ChallengeInfo.jokerLevelNames[this.levelIndex / 5];
			}
		}

		public override string ToString()
		{
			return string.Format("LevelName: '{0}', EpisodeIndex: '{1}', LevelIndex: '{2}', PositionIndex: '{3}'", new object[]
			{
				this.levelName,
				this.episodeIndex,
				this.levelIndex,
				this.positionIndex
			});
		}

		public override bool Equals(object obj)
		{
			if (obj is ChallengeInfo)
			{
                ChallengeInfo challengeInfo = (ChallengeInfo)obj;
				return challengeInfo.episodeIndex == this.episodeIndex && challengeInfo.levelIndex == this.levelIndex && challengeInfo.positionIndex == this.positionIndex;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		private static readonly string[] jokerLevelNames = new string[]
		{
			"I",
			"II",
			"III",
			"IV",
			"V",
			"VI",
			"VII",
			"VIII",
			"IX"
		};

		private static readonly int[] episodes = new int[]
		{
			1,
			3,
			4,
			2,
			5,
			6
		};

		public string levelName;

		public int episodeIndex;

		public int levelIndex;

		public int positionIndex;

		public bool collected;

		public bool revealed;

		public bool adRevealed;
	}

	public struct ChallengeConfigs
	{
		public ChallengeConfigs(Hashtable data)
		{
			this.unlockedLevelChance = new Dictionary<LootCrateType, float>();
			this.unlockedLevelChance.Add(LootCrateType.Wood, (!data.ContainsKey("unlocked_chance_wood")) ? 0f : float.Parse(data["unlocked_chance_wood"] as string));
			this.unlockedLevelChance.Add(LootCrateType.Metal, (!data.ContainsKey("unlocked_chance_metal")) ? 0f : float.Parse(data["unlocked_chance_metal"] as string));
			this.unlockedLevelChance.Add(LootCrateType.Gold, (!data.ContainsKey("unlocked_chance_gold")) ? 0f : float.Parse(data["unlocked_chance_gold"] as string));
			this.lockedLevelChance1 = new Dictionary<LootCrateType, float>();
			this.lockedLevelChance1.Add(LootCrateType.Wood, (!data.ContainsKey("1_locked_chance_wood")) ? 0f : float.Parse(data["1_locked_chance_wood"] as string));
			this.lockedLevelChance1.Add(LootCrateType.Metal, (!data.ContainsKey("1_locked_chance_metal")) ? 0f : float.Parse(data["1_locked_chance_metal"] as string));
			this.lockedLevelChance1.Add(LootCrateType.Gold, (!data.ContainsKey("1_locked_chance_gold")) ? 0f : float.Parse(data["1_locked_chance_gold"] as string));
			this.lockedLevelChance2 = new Dictionary<LootCrateType, float>();
			this.lockedLevelChance2.Add(LootCrateType.Wood, (!data.ContainsKey("2_locked_chance_wood")) ? 0f : float.Parse(data["2_locked_chance_wood"] as string));
			this.lockedLevelChance2.Add(LootCrateType.Metal, (!data.ContainsKey("2_locked_chance_metal")) ? 0f : float.Parse(data["2_locked_chance_metal"] as string));
			this.lockedLevelChance2.Add(LootCrateType.Gold, (!data.ContainsKey("2_locked_chance_gold")) ? 0f : float.Parse(data["2_locked_chance_gold"] as string));
			this.unlockedJokerLevelChance = new Dictionary<LootCrateType, float>();
			this.unlockedJokerLevelChance.Add(LootCrateType.Wood, (!data.ContainsKey("unlocked_joker_level_wood")) ? 0f : float.Parse(data["unlocked_joker_level_wood"] as string));
			this.unlockedJokerLevelChance.Add(LootCrateType.Metal, (!data.ContainsKey("unlocked_joker_level_metal")) ? 0f : float.Parse(data["unlocked_joker_level_metal"] as string));
			this.unlockedJokerLevelChance.Add(LootCrateType.Gold, (!data.ContainsKey("unlocked_joker_level_gold")) ? 0f : float.Parse(data["unlocked_joker_level_gold"] as string));
			this.lockedJokerLevelChance = new Dictionary<LootCrateType, float>();
			this.lockedJokerLevelChance.Add(LootCrateType.Wood, (!data.ContainsKey("locked_joker_level_wood")) ? 0f : float.Parse(data["locked_joker_level_wood"] as string));
			this.lockedJokerLevelChance.Add(LootCrateType.Metal, (!data.ContainsKey("locked_joker_level_metal")) ? 0f : float.Parse(data["locked_joker_level_metal"] as string));
			this.lockedJokerLevelChance.Add(LootCrateType.Gold, (!data.ContainsKey("locked_joker_level_gold")) ? 0f : float.Parse(data["locked_joker_level_gold"] as string));
			this.maxUnlockDistance1 = new Dictionary<LootCrateType, int>();
			this.maxUnlockDistance1.Add(LootCrateType.Wood, (!data.ContainsKey("1_max_unlock_distance_wood")) ? 0 : int.Parse(data["1_max_unlock_distance_wood"] as string));
			this.maxUnlockDistance1.Add(LootCrateType.Metal, (!data.ContainsKey("1_max_unlock_distance_metal")) ? 0 : int.Parse(data["1_max_unlock_distance_metal"] as string));
			this.maxUnlockDistance1.Add(LootCrateType.Gold, (!data.ContainsKey("1_max_unlock_distance_gold")) ? 0 : int.Parse(data["1_max_unlock_distance_gold"] as string));
			this.maxUnlockDistance2 = new Dictionary<LootCrateType, int>();
			this.maxUnlockDistance2.Add(LootCrateType.Wood, (!data.ContainsKey("2_max_unlock_distance_wood")) ? 0 : int.Parse(data["2_max_unlock_distance_wood"] as string));
			this.maxUnlockDistance2.Add(LootCrateType.Metal, (!data.ContainsKey("2_max_unlock_distance_metal")) ? 0 : int.Parse(data["2_max_unlock_distance_metal"] as string));
			this.maxUnlockDistance2.Add(LootCrateType.Gold, (!data.ContainsKey("2_max_unlock_distance_gold")) ? 0 : int.Parse(data["2_max_unlock_distance_gold"] as string));
		}

		public float GetUnlockLevelChance(LootCrateType type)
		{
			switch (type)
			{
			case LootCrateType.Wood:
			case LootCrateType.Bronze:
				return this.unlockedLevelChance[LootCrateType.Metal];
			case LootCrateType.Metal:
			case LootCrateType.Gold:
			case LootCrateType.Marble:
				return this.unlockedLevelChance[LootCrateType.Gold];
			default:
				return this.unlockedLevelChance[LootCrateType.Wood];
			}
		}

		public float GetLockedLevelChance1(LootCrateType type)
		{
			switch (type)
			{
			case LootCrateType.Wood:
			case LootCrateType.Bronze:
				return this.lockedLevelChance1[LootCrateType.Metal];
			case LootCrateType.Metal:
			case LootCrateType.Gold:
			case LootCrateType.Marble:
				return this.lockedLevelChance1[LootCrateType.Gold];
			default:
				return this.lockedLevelChance1[LootCrateType.Wood];
			}
		}

		public float GetLockedLevelChance2(LootCrateType type)
		{
			switch (type)
			{
			case LootCrateType.Wood:
			case LootCrateType.Bronze:
				return this.lockedLevelChance2[LootCrateType.Metal];
			case LootCrateType.Metal:
			case LootCrateType.Gold:
			case LootCrateType.Marble:
				return this.lockedLevelChance2[LootCrateType.Gold];
			default:
				return this.lockedLevelChance2[LootCrateType.Wood];
			}
		}

		public float GetUnlockedJokerLevelChance(LootCrateType type)
		{
			switch (type)
			{
			case LootCrateType.Wood:
			case LootCrateType.Bronze:
				return this.unlockedJokerLevelChance[LootCrateType.Metal];
			case LootCrateType.Metal:
			case LootCrateType.Gold:
			case LootCrateType.Marble:
				return this.unlockedJokerLevelChance[LootCrateType.Gold];
			default:
				return this.unlockedJokerLevelChance[LootCrateType.Wood];
			}
		}

		public float GetLockedJokerLevelChanche(LootCrateType type)
		{
			switch (type)
			{
			case LootCrateType.Wood:
			case LootCrateType.Bronze:
				return this.lockedJokerLevelChance[LootCrateType.Metal];
			case LootCrateType.Metal:
			case LootCrateType.Gold:
			case LootCrateType.Marble:
				return this.lockedJokerLevelChance[LootCrateType.Gold];
			default:
				return this.lockedJokerLevelChance[LootCrateType.Wood];
			}
		}

		public int MaxUnlockDistance1(LootCrateType type)
		{
			switch (type)
			{
			case LootCrateType.Wood:
			case LootCrateType.Bronze:
				return this.maxUnlockDistance1[LootCrateType.Metal];
			case LootCrateType.Metal:
			case LootCrateType.Gold:
			case LootCrateType.Marble:
				return this.maxUnlockDistance1[LootCrateType.Gold];
			default:
				return this.maxUnlockDistance1[LootCrateType.Wood];
			}
		}

		public int MaxUnlockDistance2(LootCrateType type)
		{
			switch (type)
			{
			case LootCrateType.Wood:
			case LootCrateType.Bronze:
				return this.maxUnlockDistance2[LootCrateType.Metal];
			case LootCrateType.Metal:
			case LootCrateType.Gold:
			case LootCrateType.Marble:
				return this.maxUnlockDistance2[LootCrateType.Gold];
			default:
				return this.maxUnlockDistance2[LootCrateType.Wood];
			}
		}

		private const string CFG_LOOT_CRATE_INTERVAL = "loot_crate_interval";

		private const string CFG_UNLOCKED_LEVEL_WOOD = "unlocked_chance_wood";

		private const string CFG_1_LOCKED_LEVEL_WOOD = "1_locked_chance_wood";

		private const string CFG_2_LOCKED_LEVEL_WOOD = "2_locked_chance_wood";

		private const string CFG_UNLOCKED_JOKER_LEVEL_WOOD = "unlocked_joker_level_wood";

		private const string CFG_LOCKED_JOKER_LEVEL_WOOD = "locked_joker_level_wood";

		private const string CFG_1_MAX_UNLOCK_DISTANCE_WOOD = "1_max_unlock_distance_wood";

		private const string CFG_2_MAX_UNLOCK_DISTANCE_WOOD = "2_max_unlock_distance_wood";

		private const string CFG_UNLOCKED_LEVEL_METAL = "unlocked_chance_metal";

		private const string CFG_1_LOCKED_LEVEL_METAL = "1_locked_chance_metal";

		private const string CFG_2_LOCKED_LEVEL_METAL = "2_locked_chance_metal";

		private const string CFG_1_MAX_UNLOCK_DISTANCE_METAL = "1_max_unlock_distance_metal";

		private const string CFG_2_MAX_UNLOCK_DISTANCE_METAL = "2_max_unlock_distance_metal";

		private const string CFG_UNLOCKED_JOKER_LEVEL_METAL = "unlocked_joker_level_metal";

		private const string CFG_LOCKED_JOKER_LEVEL_METAL = "locked_joker_level_metal";

		private const string CFG_UNLOCKED_LEVEL_GOLD = "unlocked_chance_gold";

		private const string CFG_1_LOCKED_LEVEL_GOLD = "1_locked_chance_gold";

		private const string CFG_2_LOCKED_LEVEL_GOLD = "2_locked_chance_gold";

		private const string CFG_1_MAX_UNLOCK_DISTANCE_GOLD = "1_max_unlock_distance_gold";

		private const string CFG_2_MAX_UNLOCK_DISTANCE_GOLD = "2_max_unlock_distance_gold";

		private const string CFG_UNLOCKED_JOKER_LEVEL_GOLD = "unlocked_joker_level_gold";

		private const string CFG_LOCKED_JOKER_LEVEL_GOLD = "locked_joker_level_gold";

		private Dictionary<LootCrateType, float> unlockedLevelChance;

		private Dictionary<LootCrateType, float> lockedLevelChance1;

		private Dictionary<LootCrateType, float> lockedLevelChance2;

		private Dictionary<LootCrateType, float> unlockedJokerLevelChance;

		private Dictionary<LootCrateType, float> lockedJokerLevelChance;

		private Dictionary<LootCrateType, int> maxUnlockDistance1;

		private Dictionary<LootCrateType, int> maxUnlockDistance2;
	}
}
