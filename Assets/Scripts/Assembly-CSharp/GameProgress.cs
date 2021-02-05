using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
	private static bool EnableAutoSave { get; set; }

	public static bool Initialized
	{
		get
		{
			return GameProgress.instance != null && GameProgress.instance.m_gameData != null;
		}
	}

	private void Awake()
	{
		this.m_gameData = Singleton<GameManager>.Instance.gameData;
		GameProgress.instance = this;
		GameProgress.m_currentPlayer = null;
		GameProgress.ChangePlayer(string.Empty);
		UnityEngine.Object.DontDestroyOnLoad(this);
		EventManager.Connect(new EventManager.OnEvent<LoadLevelEvent>(this.ReceiveLoadingLevelEvent));
		HatchManager.onLogout = (Action)Delegate.Combine(HatchManager.onLogout, new Action(this.OnLogoutActions));
		GameProgress.EnableAutoSave = true;
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<LoadLevelEvent>(this.ReceiveLoadingLevelEvent));
		HatchManager.onLogout = (Action)Delegate.Remove(HatchManager.onLogout, new Action(this.OnLogoutActions));
	}

	private void Update()
	{
		if (GameProgress.EnableAutoSave && GameProgress.m_data.ChangedSinceLastSave && GameProgress.m_lastSaveOk)
		{
			GameProgress.m_lastSaveOk = GameProgress.m_data.Save();
		}
	}

	private void OnLogoutActions()
	{
		GameProgress.EnableAutoSave = false;
	}

	public static void ChangePlayer(string identifier = "")
	{
		if (GameProgress.m_currentPlayer != null && GameProgress.m_currentPlayer == identifier)
		{
			return;
		}
		bool flag = GameProgress.m_currentPlayer == null || !GameProgress.m_currentPlayer.Equals(identifier);
		GameProgress.m_currentPlayer = identifier;
		string path = "Progress.dat";
		string key = "56SA%FG42Dv5#4aG67f2";
		if (!string.IsNullOrEmpty(GameProgress.m_currentPlayer))
		{
			path = string.Format("Progress_{0}.dat", GameProgress.m_currentPlayer);
			key = string.Format("{0}{1}", GameProgress.m_currentPlayer, "z9dD2wS2,h");
		}
		GameProgress.m_data = new SettingsData(Path.Combine("ux0:" + Path.DirectorySeparatorChar + "data", path), true, key);
		GameProgress.m_data.Load();
		bool isNewGameProgress = false;
		if (!GameProgress.m_data.GetBool("GameProgress_initialized", false))
		{
			isNewGameProgress = true;
			GameProgress.InitializeGameProgressData();
		}
		GameProgress.instance.UpgradeDataFormatVersion(isNewGameProgress);
		if (flag)
		{
			GameProgress.Save();
			EventManager.Send(new PlayerChangedEvent(GameProgress.m_currentPlayer));
		}
		GameProgress.EnableAutoSave = true;
	}

	public static void InitializeGameProgressData()
	{
		if (!GameProgress.GetRaceLevelUnlocked("R-1"))
		{
			GameProgress.SetRaceLevelUnlocked("R-1", true);
			GameProgress.SetButtonUnlockState("RaceLevelButton_R-1", GameProgress.ButtonUnlockState.Unlocked);
		}
		GameProgress.m_data.SetBool("GameProgress_initialized", true);
		GameProgress.m_data.SetString("InstallVersion", Singleton<BuildCustomizationLoader>.Instance.ApplicationVersion);
	}

	private void OnApplicationPause(bool paused)
	{
		if (paused)
		{
			GameProgress.m_lastSaveOk = GameProgress.m_data.Save();
		}
	}

	public static string GetInstallVersionString()
	{
		return GameProgress.GetString("InstallVersion", "1.8.0", GameProgress.Location.Local, null);
	}

	public static void SetFullVersionUnlocked(bool unlock)
	{
		//return true;
		//GameProgress.m_data.SetBool("FullVersionUnlocked", unlock);
		GameProgress.m_data.SetBool("FullVersionUnlocked", true);
	}

	public static bool HasStarterPack()
	{
		return GameProgress.m_data.GetBool("StarterPack", false);
	}

	public static void SetStarterPack(bool unlock)
	{
		if (!GameProgress.GetPermanentBlueprint())
		{
			GameProgress.SetPermanentBlueprint(unlock);
		}
		if (unlock && !GameProgress.GetSandboxUnlocked("S-F"))
		{
			GameProgress.SetSandboxUnlocked("S-F", unlock);
			GameProgress.UnlockButton("EpisodeButtonSandbox");
		}
		GameProgress.m_data.SetBool("StarterPack", unlock);
	}

	public static bool GetFullVersionUnlocked()
	{
		return true;
		//return !Singleton<BuildCustomizationLoader>.Instance.IsContentLimited || GameProgress.m_data.GetBool("FullVersionUnlocked", false);
	}

	public static void SetLevelCompleted(string levelName)
	{
		GameProgress.m_data.SetInt(levelName + "_completed", 1);
	}

	public static bool IsLevelCompleted(string levelName)
	{
		return GameProgress.m_data.GetInt(levelName + "_completed", 0) == 1;
	}

	[Obsolete("Obsolete in 2.2.0")]
	public static void SetLevelAdUnlocked(string levelName)
	{
		GameProgress.m_data.SetInt(levelName + "_ad_unlocked", 1);
	}

	public static bool IsLevelAdUnlocked(string levelName)
	{
		return GameProgress.m_data.GetInt(levelName + "_ad_unlocked", 0) == 1;
	}

	public static void SetShowRowUnlockStarEffect(int episodeIndex, int row, bool show)
	{
		GameProgress.m_data.SetBool(string.Concat(new object[]
		{
			"star_effect_ep_",
			episodeIndex,
			"_row_",
			row
		}), show);
	}

	public static bool GetShowRowUnlockStarEffect(int episodeIndex, int row)
	{
		return GameProgress.m_data.GetBool(string.Concat(new object[]
		{
			"star_effect_ep_",
			episodeIndex,
			"_row_",
			row
		}), false);
	}

	public static bool IsChallengeCompleted(string levelName, int challengeNumber)
	{
		return GameProgress.m_data.GetInt(levelName + "_challenge_" + challengeNumber, 0) > 0;
	}

	public static void SetChallengeCompletedWithoutCoins(string levelName, int challengeNumber)
	{
		GameProgress.m_data.SetInt(levelName + "_challenge_" + challengeNumber, 1);
	}

	public static void SetChallengeCompleted(string levelName, int challengeNumber, bool completed, bool snoutCoinsCollected = true)
	{
		bool isOdyssey = Singleton<BuildCustomizationLoader>.Instance.IsOdyssey;
		if (completed && !isOdyssey)
		{
			GameProgress.m_data.SetInt(levelName + "_challenge_" + challengeNumber, (!snoutCoinsCollected) ? 1 : 2);
		}
		else if (completed && isOdyssey)
		{
			GameProgress.m_data.SetInt(levelName + "_challenge_" + challengeNumber, 1);
		}
		else
		{
			GameProgress.m_data.SetInt(levelName + "_challenge_" + challengeNumber, 0);
		}
	}

	public static void SetDoubleRewardStartTime(int serverTime)
	{
		GameProgress.m_data.SetInt("double_reward_start_time", serverTime);
	}

	public static int GetDoubleRewardStartTime()
	{
		return GameProgress.m_data.GetInt("double_reward_start_time", -1);
	}

	public static bool HasCollectedSnoutCoins(string levelName, int challengeNumber)
	{
		return GameProgress.m_data.GetInt(levelName + "_challenge_" + challengeNumber, 0) >= 2;
	}

	public static bool IsEpisodeThreeStarred(string episode)
	{
		return GameProgress.m_data.GetBool(episode + "_3starred", false);
	}

	public static void SetEpisodeThreeStarred(string episode, bool completed)
	{
		GameProgress.m_data.SetBool(episode + "_3starred", completed);
	}

	public static void SetSandboxUnlocked(string sandboxIdentifier, bool unlocked)
	{
		GameProgress.m_data.SetBool("sandbox_unlocked_" + sandboxIdentifier, unlocked);
	}

	public static bool GetSandboxUnlocked(string sandboxIdentifier)
	{
		return GameProgress.m_data.GetBool("sandbox_unlocked_" + sandboxIdentifier, false);
	}

	public static void SetRaceLevelUnlocked(string levelIdentifier, bool unlocked)
	{
		GameProgress.m_data.SetBool("race_level_unlocked_" + levelIdentifier, unlocked);
	}

	public static bool GetRaceLevelUnlocked(string levelIdentifier)
	{
		return GameProgress.m_data.GetBool("race_level_unlocked_" + levelIdentifier, false);
	}

	public static void SetRaceLevelPartUnlocked(string levelIdentifier, string partName, bool unlocked)
	{
		GameProgress.m_data.SetBool("race_level_part_unlocked_" + levelIdentifier + "_" + partName, unlocked);
	}

	public static bool GetRaceLevelPartUnlocked(string levelIdentifier, string partName)
	{
		return GameProgress.m_data.GetBool("race_level_part_unlocked_" + levelIdentifier + "_" + partName, false);
	}

	public static void UnlockButton(string buttonId)
	{
		if (GameProgress.GetButtonUnlockState(buttonId) == GameProgress.ButtonUnlockState.Locked)
		{
			GameProgress.SetButtonUnlockState(buttonId, GameProgress.ButtonUnlockState.UnlockNow);
		}
	}

	public static void SetButtonUnlockState(string buttonId, ButtonUnlockState state)
	{
		GameProgress.m_data.SetInt("button_unlock_" + buttonId, (int)state);
	}

	public static ButtonUnlockState GetButtonUnlockState(string buttonId)
	{
		return (ButtonUnlockState)GameProgress.m_data.GetInt("button_unlock_" + buttonId, 0);
	}

	public static int GetTutorialBookOpenCount()
	{
		return GameProgress.m_data.GetInt("TutorialBookOpenCount", 0);
	}

	public static void IncreaseTutorialBookOpenCount()
	{
		int num = GameProgress.GetTutorialBookOpenCount();
		num++;
		GameProgress.m_data.SetInt("TutorialBookOpenCount", num);
	}

	public static int GetTutorialBookLastOpenedPage()
	{
		return GameProgress.m_data.GetInt("TutorialBookLastOpenedPage", 0);
	}

	public static void SetTutorialBookLastOpenedPage(int page)
	{
		GameProgress.m_data.SetInt("TutorialBookLastOpenedPage", page);
	}

	public static int GetTutorialBookFirstOpenedPage()
	{
		return GameProgress.m_data.GetInt("TutorialBookFirstOpenedPage", 1000000);
	}

	public static void SetTutorialBookFirstOpenedPage(int page)
	{
		GameProgress.m_data.SetInt("TutorialBookFirstOpenedPage", page);
	}

	public static void AddSandboxStar(string levelName, string starName, bool snoutCoinsCollected = false)
	{
		string key = levelName + "_star_" + starName;
		int @int = GameProgress.m_data.GetInt(key, 0);
		if (@int == 0)
		{
			GameProgress.m_data.SetInt(key, (!snoutCoinsCollected) ? 1 : 2);
			string key2 = levelName + "_stars";
			int num = GameProgress.m_data.GetInt(key2, 0);
			num++;
			GameProgress.m_data.SetInt(key2, num);
		}
		else if (@int == 1 && snoutCoinsCollected)
		{
			GameProgress.m_data.SetInt(key, 2);
		}
	}

	public static int GetSandboxStarCollectCount(string levelName, string starName)
	{
		string key = levelName + "_star_" + starName;
		return GameProgress.m_data.GetInt(key, 0);
	}

	public static void AddPartBox(string levelName, string partBoxName)
	{
		string key = levelName + "_part_" + partBoxName;
		if (GameProgress.m_data.GetInt(key, 0) == 0)
		{
			GameProgress.m_data.SetInt(key, 1);
			string key2 = levelName + "_parts";
			int @int = GameProgress.m_data.GetInt(key2, 0);
			GameProgress.m_data.SetInt(key2, @int + 1);
		}
	}

	public static bool HasSandboxStar(string levelName, string starName)
	{
		string key = levelName + "_star_" + starName;
		return GameProgress.m_data.GetInt(key, 0) > 0;
	}

	public static bool HasPartBox(string levelName, string partBoxName)
	{
		string key = levelName + "_part_" + partBoxName;
		return GameProgress.m_data.GetInt(key, 0) > 0;
	}

	public static int SandboxStarCount(string levelName)
	{
		string key = levelName + "_stars";
		return GameProgress.m_data.GetInt(key, 0);
	}

	public static bool HasBestTime(string levelName)
	{
		return GameProgress.m_data.HasKey(levelName + "_time");
	}

	public static void SetBestTime(string levelName, float time)
	{
		GameProgress.m_data.SetFloat(levelName + "_time", time);
	}

	public static float GetBestTime(string levelName)
	{
		return GameProgress.m_data.GetFloat(levelName + "_time", 10000f);
	}

	public static void AddSecretSkull()
	{
		string key = "SkullsCollected";
		int num = GameProgress.m_data.GetInt(key, 0);
		num++;
		GameProgress.m_data.SetInt(key, num);
	}

	public static int MaxSkullCount()
	{
		return 45;
	}

	public static int SecretSkullCount()
	{
		string key = "SkullsCollected";
		return GameProgress.m_data.GetInt(key, 0);
	}

	public static void AddSecretStatue()
	{
		string key = "StatuesFound";
		int num = GameProgress.m_data.GetInt(key, 0);
		num++;
		GameProgress.m_data.SetInt(key, num);
	}


	public static int MaxStatueCount()
	{
		return 15;
	}

	public static int SecretStatueCount()
	{
		string key = "StatuesFound";
		return GameProgress.m_data.GetInt(key, 0);
	}

	public static int BluePrintCount()
	{
		return GameProgress.m_data.GetInt("Blueprints_Available", 0);
	}

	public static void SetBluePrintCount(int count)
	{
		GameProgress.m_data.SetInt("Blueprints_Available", count);
	}

	public static void AddBluePrints(int count)
	{
		int num = GameProgress.m_data.GetInt("Blueprints_Available", 0);
		num += count;
		GameProgress.m_data.SetInt("Blueprints_Available", num);
	}

	public static int NightVisionCount()
	{
		return GameProgress.m_data.GetInt("NightVisions_Available", 0);
	}

	public static void SetNightVisionCount(int count)
	{
		GameProgress.m_data.SetInt("NightVisions_Available", count);
	}

	public static void AddNightVision(int count)
	{
		int num = GameProgress.m_data.GetInt("NightVisions_Available", 0);
		num += count;
		GameProgress.m_data.SetInt("NightVisions_Available", num);
	}

	public static void SetPermanentBlueprint(bool unlock)
	{
		GameProgress.m_data.SetBool("PermanentBlueprint", unlock);
	}

	public static bool GetPermanentBlueprint()
	{
		return GameProgress.m_data.GetBool("PermanentBlueprint", false);
	}

	public static int SuperGlueCount()
	{
		return GameProgress.m_data.GetInt("SuperGlue_Available", 0);
	}

	public static void SetSuperGlueCount(int count)
	{
		GameProgress.m_data.SetInt("SuperGlue_Available", count);
	}

	public static void AddSuperGlue(int count)
	{
		int num = GameProgress.m_data.GetInt("SuperGlue_Available", 0);
		num += count;
		GameProgress.m_data.SetInt("SuperGlue_Available", num);
	}

	public static int SuperMagnetCount()
	{
		return GameProgress.m_data.GetInt("SuperMagnet_Available", 0);
	}

	public static void SetSuperMagnetCount(int count)
	{
		GameProgress.m_data.SetInt("SuperMagnet_Available", count);
	}

	public static void AddSuperMagnet(int count)
	{
		int num = GameProgress.m_data.GetInt("SuperMagnet_Available", 0);
		num += count;
		GameProgress.m_data.SetInt("SuperMagnet_Available", num);
	}

	public static int TurboChargeCount()
	{
		return GameProgress.m_data.GetInt("TurboCharge_Available", 0);
	}

	public static void SetTurboChargeCount(int count)
	{
		GameProgress.m_data.SetInt("TurboCharge_Available", count);
	}

	public static void AddTurboCharge(int count)
	{
		int num = GameProgress.m_data.GetInt("TurboCharge_Available", 0);
		num += count;
		GameProgress.m_data.SetInt("TurboCharge_Available", num);
	}

	public static int SnoutCoinCount()
	{
		return GameProgress.m_data.GetInt("SnoutCoins", 0);
	}

	public static void SetSnoutCoinCount(int count)
	{
		GameProgress.m_data.SetInt("SnoutCoins", count);
	}

	public static void AddSnoutCoins(int count)
	{
		if (Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			return;
		}
		int num = GameProgress.m_data.GetInt("SnoutCoins", 0);
		num += count;
		GameProgress.m_data.SetInt("SnoutCoins", num);
	}

	public static bool UseSnoutCoins(int amount)
	{
		int num = GameProgress.m_data.GetInt("SnoutCoins", 0);
		if (num >= amount)
		{
			num -= amount;
			GameProgress.m_data.SetInt("SnoutCoins", num);
			return true;
		}
		return false;
	}

	public static int ScrapCount()
	{
		return GameProgress.m_data.GetInt("Scrap", 0);
	}

	public static void SetScrapCount(int count)
	{
		GameProgress.m_data.SetInt("Scrap", count);
		if (GameProgress.OnScrapAmountChanged != null)
		{
			GameProgress.OnScrapAmountChanged();
		}
	}

	public static void AddScrap(int count)
	{
		int num = GameProgress.m_data.GetInt("Scrap", 0);
		num += count;
		GameProgress.m_data.SetInt("Scrap", num);
		if (GameProgress.OnScrapAmountChanged != null)
		{
			GameProgress.OnScrapAmountChanged();
		}
	}

	public static bool UseScrap(int amount)
	{
		int num = GameProgress.m_data.GetInt("Scrap", 0);
		if (num >= amount)
		{
			num -= amount;
			GameProgress.m_data.SetInt("Scrap", num);
			if (GameProgress.OnScrapAmountChanged != null)
			{
				GameProgress.OnScrapAmountChanged();
			}
			return true;
		}
		return false;
	}

	public static int AncientPiggiesRevealed()
	{
		return GameProgress.m_data.GetInt("Ancient_Pigs_Revealed", 0);
	}

	public static void AddAncientPiggiesRevealed(int count)
	{
		int num = GameProgress.m_data.GetInt("Ancient_Pigs_Revealed", 0);
		num += count;
		GameProgress.m_data.SetInt("Ancient_Pigs_Revealed", num);
	}

	public static int DessertCount(string dessertName)
	{
		return GameProgress.m_data.GetInt(dessertName, 0);
	}

	public static void SetDessertCount(string dessertName, int count)
	{
		GameProgress.m_data.SetInt(dessertName, count);
	}

	public static void EatDesserts(string dessertName, int count)
	{
		if (count > 0)
		{
			int num = GameProgress.DessertCount(dessertName);
			int num2 = num - count;
			if (num2 < 0)
			{
				num2 = 0;
				GameProgress.AddEatenDesserts(num);
			}
			else
			{
				GameProgress.AddEatenDesserts(count);
			}
			GameProgress.SetDessertCount(dessertName, num2);
		}
	}

	public static void AddDesserts(string dessertName, int count)
	{
		if (count > 0)
		{
			if (!GameProgress.m_data.GetBool("ChiefPigExploded", false))
			{
				GameProgress.m_data.SetBool("ChiefPigExploded", true);
			}
			int num = GameProgress.DessertCount(dessertName);
			GameProgress.SetDessertCount(dessertName, num + count);
			GameProgress.m_data.SetInt("TotalDessertCount", GameProgress.m_data.GetInt("TotalDessertCount", 0) + count);
		}
	}

	public static int EatenDessertsCount()
	{
		return GameProgress.m_data.GetInt("EatenDessertsCount", 0);
	}

	private static void SetEatenDessertsCount(int count)
	{
		GameProgress.m_data.SetInt("EatenDessertsCount", count);
	}

	private static void AddEatenDesserts(int count)
	{
		int num = GameProgress.EatenDessertsCount();
		GameProgress.SetEatenDessertsCount(num + count);
		num = GameProgress.m_data.GetInt("TotalDessertCount", 0);
		num -= count;
		GameProgress.m_data.SetInt("TotalDessertCount", (num >= 0) ? num : 0);
	}

	public static int TotalDessertCount()
	{
		return GameProgress.m_data.GetInt("TotalDessertCount", 0);
	}

	public static int AddSandboxParts(BasePart.PartType part, int count, bool showUnlockAnimations = true)
	{
		if (showUnlockAnimations)
		{
			GameProgress.m_data.AddToInt("part_unlocked_" + part.ToString(), count, int.MinValue, int.MaxValue);
		}
		return GameProgress.m_data.AddToInt("part_" + part.ToString(), count, int.MinValue, int.MaxValue);
	}

	public static int AddSandboxParts(string levelName, BasePart.PartType part, int count, bool showUnlockAnimations = true)
	{
		if (showUnlockAnimations)
		{
			GameProgress.m_data.AddToInt(levelName + "_part_unlocked_" + part.ToString(), count, int.MinValue, int.MaxValue);
		}
		return GameProgress.m_data.AddToInt(levelName + "_part_" + part.ToString(), count, int.MinValue, int.MaxValue);
	}

	public static int GetSandboxPartCount(BasePart.PartType part)
	{
		return GameProgress.m_data.GetInt("part_" + part.ToString(), 0);
	}

	public static int GetSandboxPartCount(string levelName, BasePart.PartType part)
	{
		string key = levelName + "_part_" + part.ToString();
		return GameProgress.m_data.GetInt(key, 0);
	}

	public static int GetUnlockedSandboxPartCount(BasePart.PartType part)
	{
		return GameProgress.m_data.GetInt("part_unlocked_" + part.ToString(), 0);
	}

	public static int GetUnlockedSandboxPartCount(string levelName, BasePart.PartType part)
	{
		string key = levelName + "_part_unlocked_" + part.ToString();
		return GameProgress.m_data.GetInt(key, 0);
	}

	public static void SetUnlockedSandboxPartCount(BasePart.PartType part, int count)
	{
		GameProgress.m_data.SetInt("part_unlocked_" + part.ToString(), count);
	}

	public static void SetUnlockedSandboxPartCount(string levelName, BasePart.PartType part, int count)
	{
		string key = levelName + "_part_unlocked_" + part.ToString();
		GameProgress.m_data.SetInt(key, count);
	}

	public static int GetRaceLevelUnlockedStars()
	{
		string key = "race_level_unlocked_stars";
		return GameProgress.m_data.GetInt(key, 0);
	}

	public static void SetRaceLevelUnlockedStars(int value)
	{
		string key = "race_level_unlocked_stars";
		GameProgress.m_data.SetInt(key, value);
	}

	public static void AddRaceLevelUnlockedStars(int value)
	{
		string key = "race_level_unlocked_stars";
		int @int = GameProgress.m_data.GetInt(key, 0);
		GameProgress.m_data.SetInt(key, @int + value);
	}

	public static bool AllLevelsUnlocked()
	{
		return GameProgress.m_data.GetBool("UnlockAllLevels", false);
	}

	public static bool AllFreeLevelsUnlocked()
	{
		return GameProgress.m_data.GetBool("UnlockAllFreeLevels", false);
	}

	public static string[] GetTimerIds()
	{
		string @string = GameProgress.m_data.GetString("TimerIds", string.Empty);
		if (string.IsNullOrEmpty(@string))
		{
			return new string[0];
		}
		return @string.Split(new char[]
		{
			','
		});
	}

	public static void SetTimerIds(string[] ids)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < ids.Length; i++)
		{
			stringBuilder.Append(ids[i]);
			if (i < ids.Length - 1)
			{
				stringBuilder.Append(',');
			}
		}
		GameProgress.m_data.SetString("TimerIds", stringBuilder.ToString());
	}

	public static T GetTimerData<T>(string timerId, string timerValue)
	{
		return GameProgress.m_data.Get(string.Format("{0}_{1}", timerId, timerValue), default(T));
	}

	public static void SetTimerData<T>(string timerId, string timerValue, T value)
	{
		GameProgress.m_data.Set(string.Format("{0}_{1}", timerId, timerValue), value);
	}

	public static void RemoveTimerData(string timerId, string timerValue)
	{
		GameProgress.m_data.DeleteKey(string.Format("{0}_{1}", timerId, timerValue));
	}

	public static void SetInt(string key, int value, Location location = GameProgress.Location.Local)
	{
		if ((location & GameProgress.Location.Local) == GameProgress.Location.Local)
		{
			GameProgress.m_data.SetInt(key, value);
		}
	}

	public static int GetInt(string key, int defaultValue = 0, Location location = GameProgress.Location.Local, Action<int> response = null)
	{
		int @int = GameProgress.m_data.GetInt(key, defaultValue);
		if (response != null)
		{
			response(@int);
		}
		return @int;
	}

	public static void SetFloat(string key, float value, Location location = GameProgress.Location.Local)
	{
		GameProgress.m_data.SetFloat(key, value);
	}

	public static float GetFloat(string key, float defaultValue = 0f, Location location = GameProgress.Location.Local, Action<float> response = null)
	{
		float @float = GameProgress.m_data.GetFloat(key, defaultValue);
		if (response != null)
		{
			response(@float);
		}
		return @float;
	}

	public static void SetString(string key, string value, Location location = GameProgress.Location.Local)
	{
		GameProgress.m_data.SetString(key, value);
	}

	public static string GetString(string key, string defaultValue = "", Location location = GameProgress.Location.Local, Action<string> response = null)
	{
		string @string = GameProgress.m_data.GetString(key, defaultValue);
		if (response != null)
		{
			response(@string);
		}
		return @string;
	}

	public static void SetBool(string key, bool value, Location location = GameProgress.Location.Local)
	{
		GameProgress.m_data.SetBool(key, value);
	}

	public static bool GetBool(string key, bool defaultValue = false, Location location = GameProgress.Location.Local, Action<bool> response = null)
	{
		bool @bool = GameProgress.m_data.GetBool(key, defaultValue);
		if (response != null)
		{
			response(@bool);
		}
		return @bool;
	}

	public static bool HasKey(string key, Location location = GameProgress.Location.Local, Action<bool> response = null)
	{
		bool flag = GameProgress.m_data.HasKey(key);
		if (response != null)
		{
			response(flag);
		}
		return flag;
	}

	public static void DeleteKey(string key, Location location = GameProgress.Location.Local)
	{
		GameProgress.m_data.DeleteKey(key);
	}

	public static void DeleteAll()
	{
		GameProgress.m_data.DeleteAll();
	}

	public static void Save()
	{
		GameProgress.m_lastSaveOk = GameProgress.m_data.Save();
	}

	public static void Load()
	{
		GameProgress.m_data.Load();
	}

	private void UpgradeDataFormatVersion(bool isNewGameProgress = false)
	{
		int num = GameProgress.GetInt("DataFormatVersion", 1, GameProgress.Location.Local, null);
		if (num == 1)
		{
			for (int i = 1; i <= 4; i++)
			{
				if (GameProgress.m_data.GetBool("sandbox_unlocked_" + i.ToString(), false))
				{
					GameProgress.m_data.SetBool("sandbox_unlocked_S-" + i.ToString(), true);
					GameProgress.m_data.DeleteKey("sandbox_unlocked_" + i.ToString());
				}
				if (GameProgress.GetButtonUnlockState("SandboxLevelButton_" + i.ToString()) == GameProgress.ButtonUnlockState.Unlocked)
				{
					GameProgress.SetButtonUnlockState("SandboxLevelButton_S-" + i.ToString(), GameProgress.ButtonUnlockState.Unlocked);
					GameProgress.m_data.DeleteKey("button_unlock_SandboxLevelButton_" + i.ToString());
				}
			}
			num = 2;
			GameProgress.SetInt("DataFormatVersion", num, GameProgress.Location.Local);
		}
		if (num == 2)
		{
			UserSettings.SetInt("Episode2LevelSelection_active_page", 0);
			num = 3;
			GameProgress.SetInt("DataFormatVersion", num, GameProgress.Location.Local);
		}
		if (num == 3)
		{
			num = 4;
			GameProgress.SetInt("DataFormatVersion", num, GameProgress.Location.Local);
		}
		if (num == 4)
		{
			try
			{
				for (int j = 0; j < 6; j++)
				{
					List<string> levelNames = LevelInfo.GetLevelNames(j);
					for (int k = 0; k < levelNames.Count; k++)
					{
						if (GameProgress.m_data.GetBool(levelNames[k] + "_challenge_" + 1, false))
						{
							GameProgress.m_data.DeleteKey(levelNames[k] + "_challenge_" + 1);
							GameProgress.m_data.SetInt(levelNames[k] + "_challenge_" + 1, 1);
						}
						if (GameProgress.m_data.GetBool(levelNames[k] + "_challenge_" + 2, false))
						{
							GameProgress.m_data.DeleteKey(levelNames[k] + "_challenge_" + 2);
							GameProgress.m_data.SetInt(levelNames[k] + "_challenge_" + 2, 1);
						}
					}
				}
				foreach (RaceLevels.LevelData level in Singleton<GameManager>.Instance.gameData.m_raceLevels.Levels)
				{
					string arg = level.SceneName;
					if (GameProgress.m_data.GetBool(arg + "_challenge_" + 1, false))
					{
						GameProgress.m_data.DeleteKey(arg + "_challenge_" + 1);
						GameProgress.m_data.SetInt(arg + "_challenge_" + 1, 1);
					}
					if (GameProgress.m_data.GetBool(arg + "_challenge_" + 2, false))
					{
						GameProgress.m_data.DeleteKey(arg + "_challenge_" + 2);
						GameProgress.m_data.SetInt(arg + "_challenge_" + 2, 1);
					}
				}
			}
			catch
			{
			}
			num = 5;
			GameProgress.SetInt("DataFormatVersion", num, GameProgress.Location.Local);
		}
		if (num == 5)
		{
			int[] array = new int[3];
			int[] array2 = new int[3];
			int num2 = 0;
			int num3 = 0;
			int num4 = GameProgress.SecretSkullCount();
			int num5 = GameProgress.SecretStatueCount();
			foreach (Episode episode in GameProgress.instance.m_gameData.m_episodeLevels)
			{
				int num6 = 0;
				foreach (EpisodeLevelInfo episodeLevelInfo in episode.LevelInfos)
				{
					int @int = GameProgress.GetInt(episodeLevelInfo.sceneName + "_stars", 0, GameProgress.Location.Local, null);
					bool flag = LevelInfo.IsStarLevel(num3, num6);
					for (int l = 0; l < Mathf.Clamp(@int, 0, 3); l++)
					{
						if (flag)
						{
							array2[l]++;
						}
						else
						{
							array[l]++;
						}
					}
					num6++;
				}
				num3++;
			}
			foreach (SandboxLevels.LevelData levelData in GameProgress.instance.m_gameData.m_sandboxLevels.Levels)
			{
				num2 += GameProgress.GetInt(levelData.SceneName + "_stars", 0, GameProgress.Location.Local, null);
			}
			foreach (RaceLevels.LevelData levelData2 in GameProgress.instance.m_gameData.m_raceLevels.Levels)
			{
				int int2 = GameProgress.GetInt(levelData2.SceneName + "_stars", 0, GameProgress.Location.Local, null);
				for (int m = 0; m < Mathf.Clamp(int2, 0, 3); m++)
				{
					array[m]++;
				}
			}
			Dictionary<PlayerProgress.ExperienceType, int> dictionary = new Dictionary<PlayerProgress.ExperienceType, int>();
			int num7 = 0;
			int num8 = 3;
			for (int n = 0; n < 3; n++)
			{
				if (array[n] > 0)
				{
					dictionary.Add((PlayerProgress.ExperienceType)(num7 + n), array[n]);
				}
				if (array2[n] > 0)
				{
					dictionary.Add((PlayerProgress.ExperienceType)(num8 + n), array2[n]);
				}
			}
			if (num2 > 0)
			{
				dictionary.Add(PlayerProgress.ExperienceType.StarBoxCollectedSandbox, num2);
			}
			if (num4 > 0)
			{
				dictionary.Add(PlayerProgress.ExperienceType.HiddenSkullFound, num4);
				if (num4 >= GameProgress.MaxSkullCount())
				{
					dictionary.Add(PlayerProgress.ExperienceType.AllHiddenSkullsFound, 1);
				}
			}
			if (num5 > 0)
			{
				dictionary.Add(PlayerProgress.ExperienceType.HiddenStatueFound, num5);
				if (num4 >= GameProgress.MaxStatueCount())
				{
					dictionary.Add(PlayerProgress.ExperienceType.AllHiddenStatuesFound, 1);
				}
			}
			PlayerProgress.AddPendingExperience(dictionary);
			num = 6;
			GameProgress.SetInt("DataFormatVersion", num, GameProgress.Location.Local);
		}
		GameProgress.SetString("LastKnownVersion", Singleton<BuildCustomizationLoader>.Instance.ApplicationVersion, GameProgress.Location.Local);
	}

	public static string GetLastKnownVersionString()
	{
		return GameProgress.GetString("LastKnownVersion", "1.8.0", GameProgress.Location.Local, null);
	}

	public static int GetAllStars()
	{
		int num = 0;
		foreach (Episode episode in GameProgress.instance.m_gameData.m_episodeLevels)
		{
			foreach (EpisodeLevelInfo episodeLevelInfo in episode.LevelInfos)
			{
				num += GameProgress.m_data.GetInt(episodeLevelInfo.sceneName + "_stars", 0);
			}
		}
		foreach (SandboxLevels.LevelData levelData in GameProgress.instance.m_gameData.m_sandboxLevels.Levels)
		{
			num += GameProgress.m_data.GetInt(levelData.SceneName + "_stars", 0);
		}
		foreach (RaceLevels.LevelData levelData2 in GameProgress.instance.m_gameData.m_raceLevels.Levels)
		{
			num += GameProgress.m_data.GetInt(levelData2.SceneName + "_stars", 0);
		}
		return num;
	}

	private void ReceiveLoadingLevelEvent(LoadLevelEvent data)
	{
		if (data.nextGameState == GameManager.GameState.Level)
		{
			GameProgress.m_data.BackupData();
		}
	}

	public static int ExperienceGiven(PlayerProgress.ExperienceType expType, string identifier = "")
	{
		return GameProgress.m_data.GetInt(string.Format("exp_{0}{1}", expType.ToString(), identifier), 0);
	}

	public static void ReportExperienceGiven(PlayerProgress.ExperienceType expType, string identifier = "")
	{
		string key = string.Format("exp_{0}{1}", expType.ToString(), identifier);
		int @int = GameProgress.m_data.GetInt(key, 0);
		GameProgress.m_data.SetInt(key, @int + 1);
	}

	public static void SetMinimumLockedLevel(int episode, int level)
	{
		GameProgress.m_data.SetInt("MinimumLockedLevel" + episode, level);
	}

	public static int GetMinimumLockedLevel(int episode)
	{
		return GameProgress.m_data.GetInt("MinimumLockedLevel" + episode, 6);
	}

	public static int GetLootcrateAmount(LootCrateType crateType)
	{
		return GameProgress.m_data.GetInt(string.Format("Crate_amount_{0}", crateType.ToString()), 0);
	}

	public static void AddLootcrate(LootCrateType crateType, int amount = 1)
	{
		GameProgress.m_data.AddToInt(string.Format("Crate_amount_{0}", crateType.ToString()), amount, int.MinValue, int.MaxValue);
	}

	public static void RemoveLootcrate(LootCrateType crateType)
	{
		GameProgress.m_data.AddToInt(string.Format("Crate_amount_{0}", crateType.ToString()), -1, 0, int.MaxValue);
	}

	public static Action OnScrapAmountChanged;

	public static Action OnProgressSaved;

	private const Location DEFAULT_SAVE_LOCATION = GameProgress.Location.Local;

	private const Location DEFAULT_LOAD_LOCATION = GameProgress.Location.Local;

	private const string NULL_VALUE = "NULL";

	[SerializeField]
	private GameData m_gameData;

	private static GameProgress instance;

	private static SettingsData m_data;

	private static string m_currentPlayer;

	private static bool m_lastSaveOk = true;

	[Flags]
	public enum Location
	{
		Local = 1,
		Hatch = 2
	}

	public enum ButtonUnlockState
	{
		Locked,
		Unlocked,
		UnlockNow
	}
}
