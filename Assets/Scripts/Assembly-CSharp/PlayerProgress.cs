using System;
using System.Collections.Generic;

public class PlayerProgress : Singleton<PlayerProgress>
{
	public bool Initialized { get; private set; }

	public int Level { get; private set; }

	public int Experience { get; private set; }

	public int PendingExperience { get; private set; }

	public int MaxLevel { get; private set; }

	public bool LevelUpPending
	{
		get
		{
			return this.PendingExperience >= 0;
		}
	}

	public int ExperienceToNextLevel
	{
		get
		{
			if (this.experienceTable == null)
			{
				return this.Experience;
			}
			if (this.experienceTable.ContainsKey(this.Level + 1))
			{
				return this.experienceTable[this.Level + 1];
			}
			if (this.experienceTable.ContainsKey(this.MaxLevel))
			{
				return this.experienceTable[this.MaxLevel];
			}
			return this.Experience;
		}
	}

	private void Awake()
	{
		base.SetAsPersistant();
		this.LoadData();
		EventManager.Connect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
	}

	private void OnPlayerChanged(PlayerChangedEvent data)
	{
		this.LoadData();
	}

	private void Start()
	{
		if (Singleton<GameConfigurationManager>.Instance.HasData)
		{
			this.UpdateExperienceTable();
		}
		else
		{
			GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
			instance.OnHasData = (Action)Delegate.Combine(instance.OnHasData, new Action(this.UpdateExperienceTable));
		}
	}

	public void Initialize(int level, int experience, int pendingExperience)
	{
		this.Level = level;
		this.Experience = experience;
		this.PendingExperience = pendingExperience;
		this.SaveData();
		this.UpdateExperienceTable();
		this.FirePlayerProgressEvent();
	}

	private void LoadData()
	{
		this.PendingExperience = GameProgress.GetInt("player_pending_experience", -1, GameProgress.Location.Local, null);
		this.Experience = GameProgress.GetInt("player_experience", 0, GameProgress.Location.Local, null);
		this.Level = GameProgress.GetInt("player_level", 1, GameProgress.Location.Local, null);
		this.FirePlayerProgressEvent();
	}

	private void SaveData()
	{
		GameProgress.SetInt("player_level", this.Level, GameProgress.Location.Local);
		GameProgress.SetInt("player_experience", this.Experience, GameProgress.Location.Local);
		GameProgress.SetInt("player_pending_experience", this.PendingExperience, GameProgress.Location.Local);
	}

	private void UpdateExperienceTable()
	{
		GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
		instance.OnHasData = (Action)Delegate.Remove(instance.OnHasData, new Action(this.UpdateExperienceTable));
		ConfigData config = Singleton<GameConfigurationManager>.Instance.GetConfig("player_experience_table");
		if (config == null || config.Count == 0)
		{
			return;
		}
		this.MaxLevel = 0;
		this.experienceTable = new Dictionary<int, int>();
		for (int i = 0; i < config.Count; i++)
		{
			int num;
			int value;
			if (int.TryParse(config.Keys[i], out num) && int.TryParse(config.Values[i], out value))
			{
				if (!this.experienceTable.ContainsKey(num))
				{
					this.experienceTable.Add(num, value);
				}
				if (num > this.MaxLevel)
				{
					this.MaxLevel = num;
				}
			}
		}
		if (PlayerProgress.pendingExperienceTypes != null && PlayerProgress.pendingExperienceTypes.Count > 0)
		{
			foreach (KeyValuePair<ExperienceType, int> keyValuePair in PlayerProgress.pendingExperienceTypes)
			{
				for (int j = 0; j < keyValuePair.Value; j++)
				{
					this.AddExperience(keyValuePair.Key);
				}
			}
		}
		this.FirePlayerProgressEvent();
	}

	public void FirePlayerProgressEvent()
	{
		this.AddExperience(PlayerProgress.ExperienceType.UnknownSource);
	}

	public int AddExperience(ExperienceType experienceType)
	{
		int num = this.ExperienceCount(experienceType);
		this.AddExperience(num);
		this.SendFlurryExperienceGained(num, experienceType);
		return num;
	}

	public int AddExperience(ExperienceType[] experienceType)
	{
		int num = 0;
		for (int i = 0; i < experienceType.Length; i++)
		{
			num += this.AddExperience(experienceType[i]);
		}
		return num;
	}

	private int ExperienceCount(ExperienceType experienceType)
	{
		int num = 0;
		if (experienceType == PlayerProgress.ExperienceType.UnknownSource)
		{
			return num;
		}
		if (Singleton<GameConfigurationManager>.Instance.HasData && Singleton<GameConfigurationManager>.Instance.HasConfig("player_experience_types"))
		{
			string key = experienceType.ToString();
			ConfigData config = Singleton<GameConfigurationManager>.Instance.GetConfig("player_experience_types");
			int num2;
			if (config.HasKey(key) && int.TryParse(config[key], out num2))
			{
				num = num2;
			}
		}
		if (Singleton<DoubleRewardManager>.IsInstantiated() && Singleton<DoubleRewardManager>.Instance.CurrentStatus == DoubleRewardManager.Status.Initialized && Singleton<DoubleRewardManager>.Instance.HasDoubleReward)
		{
			return num * 2;
		}
		return num;
	}

	public void CheckLevelUp()
	{
		if (this.LevelUpPending)
		{
			int pendingExperience = this.PendingExperience;
			this.PendingExperience = -1;
			this.Level++;
			EventManager.Send(new LevelUpEvent(this.Level));
			this.AddExperience(pendingExperience);
			this.SendFlurryLevelUpGained();
		}
	}

	private void AddExperience(int amount)
	{
		int experienceToNextLevel = this.ExperienceToNextLevel;
		if (this.LevelUpPending)
		{
			this.PendingExperience += amount;
		}
		else
		{
			this.Experience += amount;
			if (this.experienceTable != null && this.Experience >= experienceToNextLevel)
			{
				this.PendingExperience = this.Experience - experienceToNextLevel;
				this.Experience = 0;
			}
		}
		this.SaveData();
		int experience = this.Experience;
		if (this.LevelUpPending)
		{
			experience = experienceToNextLevel;
		}
		EventManager.Send(new PlayerProgressEvent(this.Level, experience, experienceToNextLevel, this.PendingExperience));
	}

	public static void AddPendingExperience(Dictionary<ExperienceType, int> experiences)
	{
		if (PlayerProgress.pendingExperienceTypes == null)
		{
			PlayerProgress.pendingExperienceTypes = new Dictionary<ExperienceType, int>();
		}
		foreach (KeyValuePair<ExperienceType, int> keyValuePair in experiences)
		{
			if (keyValuePair.Value > 0)
			{
				if (PlayerProgress.pendingExperienceTypes.ContainsKey(keyValuePair.Key))
				{
					Dictionary<ExperienceType, int> dictionary = PlayerProgress.pendingExperienceTypes;
                    ExperienceType key = keyValuePair.Key;
					dictionary[key] = dictionary[key] + keyValuePair.Value;
				}
				else
				{
					PlayerProgress.pendingExperienceTypes.Add(keyValuePair.Key, keyValuePair.Value);
				}
			}
		}
	}

	private void SendFlurryExperienceGained(int amount, ExperienceType typeOfGain)
	{
	}

	private void SendFlurryLevelUpGained()
	{
	}

	private Dictionary<int, int> experienceTable;

	public const string EXPERIENCE_KEY = "player_experience";

	public const string PENDING_EXPERIENCE_KEY = "player_pending_experience";

	public const string LEVEL_KEY = "player_level";

	private const string EXPERIENCE_TABLE_KEY = "player_experience_table";

	private const string EXPERIENCE_TYPES_KEY = "player_experience_types";

	private static Dictionary<ExperienceType, int> pendingExperienceTypes;

	[Flags]
	public enum ExperienceType
	{
		UnknownSource = -1,
		LevelComplete1Star = 0,
		LevelComplete2Star = 1,
		LevelComplete3Star = 2,
		JokerLevelComplete1Star = 3,
		JokerLevelComplete2Star = 4,
		JokerLevelComplete3Star = 5,
		StarBoxCollectedSandbox = 6,
		PartBoxCollectedSandbox = 7,
		KingBurp = 8,
		HiddenSkullFound = 9,
		AllHiddenSkullsFound = 10,
		HiddenStatueFound = 11,
		AllHiddenStatuesFound = 12,
		CommonPartCrafted = 13,
		RarePartCrafted = 14,
		EpicPartCrafted = 15,
		NewCommonPartViewed = 16,
		NewRarePartViewed = 17,
		NewEpicPartViewed = 18,
		EveryplayVideoShared = 19,
		WinCakeRace = 20,
		LoseCakeRace = 21,
		DailyLootCrateCollected1st = 22,
		DailyLootCrateCollected2nd = 23,
		DailyLootCrateCollected3rd = 24,
		LegendaryPartCrafted = 25,
		NewLegendaryPartViewed = 26
	}
}
