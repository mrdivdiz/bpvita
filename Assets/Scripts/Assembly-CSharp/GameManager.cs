using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	public GameData gameData
	{
		get
		{
			return this.m_gameData;
		}
	}

	public static bool Initialized
	{
		get
		{
			return Singleton<GameManager>.instance != null && Singleton<GameManager>.instance.m_gameData != null;
		}
	}

	public bool IsInGame()
	{
		return this.m_gameState == GameManager.GameState.Level;
	}

	public GameState GetPrevGameState()
	{
		return this.m_prevGameState;
	}

	public GameState GetGameState()
	{
		return this.m_gameState;
	}

	public EpisodeType CurrentEpisodeType
	{
		get
		{
			return this.m_currentEpisodeType;
		}
	}

	public string CurrentEpisode
	{
		get
		{
			return this.m_currentEpisode;
		}
	}

	public int CurrentEpisodeIndex
	{
		get
		{
			return this.m_currentEpisodeIndex;
		}
	}

	public int CurrentLevel
	{
		get
		{
			return this.m_currentLevel;
		}
	}

	public string CurrentLevelLabel
	{
		get
		{
			if (this.m_currentEpisodeType == GameManager.EpisodeType.Normal)
			{
				return LevelSelector.DifferentiatedLevelLabel(this.m_currentLevel);
			}
			if (this.m_currentEpisodeType == GameManager.EpisodeType.Sandbox)
			{
				return this.m_currentSandboxIdentifier.Substring(2);
			}
			if (this.m_currentEpisodeType == GameManager.EpisodeType.Race)
			{
				return this.m_currentRaceLevelIdentifier.Substring(2);
			}
			return "X";
		}
	}

	public string CurrentEpisodeLabel
	{
		get
		{
			if (this.m_currentEpisodeType == GameManager.EpisodeType.Normal)
			{
				for (int i = 0; i < this.m_gameData.m_episodeLevels.Count; i++)
				{
					if (this.m_gameData.m_episodeLevels[i].Name == this.m_currentEpisode)
					{
						return this.m_gameData.m_episodeLevels[i].Label;
					}
				}
			}
			else
			{
				if (this.m_currentEpisodeType == GameManager.EpisodeType.Sandbox)
				{
					return "S";
				}
				if (this.m_currentEpisodeType == GameManager.EpisodeType.Race)
				{
					return "R";
				}
			}
			return "X";
		}
	}

	public string CurrentLevelIdentifier
	{
		get
		{
			string text = string.Empty;
			try
			{
				if (this.m_gameState == GameManager.GameState.CakeRaceMenu)
				{
					text = "CakeRaceMenu";
				}
				else if (this.m_gameState == GameManager.GameState.WorkShop)
				{
					text = "WorkShop";
				}
				else if (this.m_gameState == GameManager.GameState.KingPigFeeding)
				{
					text = "Feed";
				}
				else if (this.m_currentEpisodeType == GameManager.EpisodeType.Normal)
				{
					text = this.CurrentEpisodeLabel + "-" + this.CurrentLevelLabel;
				}
				else if (this.m_currentEpisodeType == GameManager.EpisodeType.Sandbox)
				{
					if (this.m_gameState == GameManager.GameState.Level)
					{
						text = this.m_currentSandboxIdentifier;
					}
					else
					{
						text = this.m_currentEpisode;
					}
				}
				else if (this.m_currentEpisodeType == GameManager.EpisodeType.Race)
				{
					text = this.m_currentRaceLevelIdentifier;
				}
				else
				{
					text = SceneManager.GetActiveScene().name;
				}
			}
			catch
			{
				text = SceneManager.GetActiveScene().name;
			}
			return (!string.IsNullOrEmpty(text)) ? text : "none";
		}
	}

	public string CurrentSceneName
	{
		get
		{
			if (this.m_gameState == GameManager.GameState.Level)
			{
				return this.m_currentLevelName;
			}
			return SceneManager.GetActiveScene().name;
		}
	}

	public string ScreenFlurryIdentifier
	{
		get
		{
			if (this.m_gameState == GameManager.GameState.Level)
			{
				return this.CurrentLevelIdentifier;
			}
			if (this.m_gameState == GameManager.GameState.LevelSelection)
			{
				int num = 0;
				GameObject gameObject = GameObject.Find("LevelSelector");
				if (gameObject)
				{
					num = gameObject.GetComponent<LevelSelector>().CurrentPage;
				}
				string text = string.Empty;
				if (this.m_currentEpisodeType == GameManager.EpisodeType.Normal)
				{
					text = this.m_gameData.m_episodeLevels[this.m_currentEpisodeIndex].FlurryID;
				}
				else if (this.m_currentEpisodeType == GameManager.EpisodeType.Sandbox)
				{
					text = "SB";
				}
				else if (this.m_currentEpisodeType == GameManager.EpisodeType.Race)
				{
					text = "Race";
				}
				return string.Concat(new object[]
				{
					text,
					" ",
					num,
					"/3"
				});
			}
			return this.GetGameState().ToString();
		}
	}

	public bool OverrideInFlightMusic
	{
		get
		{
			return this.m_gameData.m_episodeLevels[this.m_currentEpisodeIndex].OverrideInFlightMusic;
		}
	}

	public GameObject OverriddenInFlightMusic
	{
		get
		{
			if (this.m_currentEpisodeType == GameManager.EpisodeType.Normal)
			{
				return this.m_gameData.m_episodeLevels[this.m_currentEpisodeIndex].InFlightMusic;
			}
			return this.m_gameData.commonAudioCollection.InFlightMusic;
		}
	}

	public bool OverrideBuildMusic
	{
		get
		{
			return this.m_gameData.m_episodeLevels[this.m_currentEpisodeIndex].OverrideBuildMusic;
		}
	}

	public GameObject OverriddenBuildMusic
	{
		get
		{
			if (this.m_currentEpisodeType == GameManager.EpisodeType.Normal)
			{
				return this.m_gameData.m_episodeLevels[this.m_currentEpisodeIndex].BuildingMusic;
			}
			return this.m_gameData.commonAudioCollection.BuildMusic;
		}
	}

	public string OpeningCutscene
	{
		get
		{
			return this.m_openingCutscene;
		}
	}

	public string EndingCutscene
	{
		get
		{
			return this.m_endingCutscene;
		}
	}

	public string MidCutscene
	{
		get
		{
			return this.m_midCutscene;
		}
	}

	public bool IsCutsceneStartedFromLevelSelection
	{
		get
		{
			return this.m_isCutsceneStartedFromLevelSelection;
		}
	}

	public int LevelCount
	{
		get
		{
			return this.m_levels.Count;
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if (this.m_openLevel)
		{
			this.LoadLevel(this.m_openLevelIndex);
			this.m_openLevel = false;
		}
	}

	public string SandboxToOpenForCurrentLevel
	{
		get
		{
			foreach (LevelRewardData.SandboxUnlock sandboxUnlock in this.m_levelRewardData.sandboxUnlocks)
			{
				if (sandboxUnlock.levelIdentifier == this.CurrentLevelIdentifier)
				{
					return sandboxUnlock.sandboxIdentifier;
				}
			}
			return string.Empty;
		}
	}

	public bool IsNextPageComingSoon()
	{
		return (this.CurrentLevel + 1 == 14 && this.m_pagesComingSoonBitmask > 0) || (this.CurrentLevel + 1 == 29 && this.m_pagesComingSoonBitmask > 1);
	}

	public void SetLoadingLevelGameState(GameState state)
	{
		this.m_loadingLevelGameState = state;
		GameObject gameObject = new GameObject();
		gameObject.AddComponent<LevelUnloadNotifier>();
	}

	public void OpenEpisode(LevelSelector episodeLevels)
	{
		this.m_currentEpisode = SceneManager.GetActiveScene().name;
		this.m_currentEpisodeType = GameManager.EpisodeType.Normal;
		this.m_currentEpisodeIndex = episodeLevels.EpisodeIndex;
		this.m_openingCutscene = episodeLevels.OpeningCutscene;
		this.m_midCutscene = episodeLevels.MidCutscene;
		this.m_endingCutscene = episodeLevels.EndingCutscene;
		this.m_levels = new List<EpisodeLevelInfo>(episodeLevels.Levels);
		this.m_starlevelLimits = new List<int>(episodeLevels.StarLevelLimits);
		this.m_pagesComingSoonBitmask = Convert.ToInt32(episodeLevels.m_pageTwoComingSoon) + Convert.ToInt32(episodeLevels.m_pageThreeComingSoon);
	}

	public void OpenSandboxEpisode(SandboxSelector sandboxLevels)
	{
		this.m_currentEpisode = SceneManager.GetActiveScene().name;
		this.m_sandboxSelector = sandboxLevels;
		this.m_currentEpisodeType = GameManager.EpisodeType.Sandbox;
	}

	public void OpenRaceEpisode(RaceLevelSelector raceLevels)
	{
		this.m_currentEpisode = SceneManager.GetActiveScene().name;
		this.m_currentEpisodeType = GameManager.EpisodeType.Race;
	}

	public void CloseEpisode()
	{
		this.m_currentEpisode = null;
		this.m_levels.Clear();
	}

	public void OnLevelUnloading()
	{
		if (this.m_loadingLevelGameState != GameManager.GameState.Undefined)
		{
			this.m_prevGameState = this.m_gameState;
			this.m_gameState = this.m_loadingLevelGameState;
			this.m_loadingLevelGameState = GameManager.GameState.Undefined;
		}
	}

	public void LoadMainMenu(bool showLoadingScreen)
	{
		Singleton<Loader>.Instance.LoadLevel("MainMenu", GameManager.GameState.MainMenu, showLoadingScreen, true);
	}

	public void LoadKingPigFeed(bool showLoadingScreen)
	{
		Singleton<Loader>.Instance.LoadLevel("KingPigFeed", GameManager.GameState.KingPigFeeding, showLoadingScreen, true);
	}

	public void LoadWorkshop(bool showLoadingScreen)
	{
		Singleton<Loader>.Instance.LoadLevel("Workshop", GameManager.GameState.WorkShop, showLoadingScreen, true);
	}

	public int NextLevel()
	{
		int num = this.m_currentLevel;
		if (this.m_currentLevel < this.m_levels.Count - 1 && this.m_levels[this.m_currentLevel + 1] == this.GetCurrentRowJokerLevel())
		{
			num++;
		}
		if (this.m_currentLevel < this.m_levels.Count - 1)
		{
			num++;
		}
		return num;
	}

	public void LoadNextLevel()
	{
		if (this.m_currentEpisodeType == GameManager.EpisodeType.Race)
		{
			this.LoadRaceLevel(this.NextRaceLevel());
			return;
		}
		int num = this.NextLevel();
		bool flag = LevelInfo.IsLevelUnlocked(this.CurrentEpisodeIndex, num);
		bool flag2 = true;
		bool flag3 = false;
		bool flag4 = num % 5 == 0;
		int num2 = num / 5;
		bool flag5 = GameProgress.IsLevelAdUnlocked(LevelInfo.GetLevelNames(this.CurrentEpisodeIndex)[num2 * 5]);
		bool flag6 = LevelInfo.IsLevelUnlocked(this.CurrentEpisodeIndex, num2 * 5);
		if (flag4 && !flag5 && !flag6)
		{
			EventManager.Send(new UIEvent(UIEvent.Type.LevelSelection));
		}
		else if (LevelInfo.IsContentLimited(this.CurrentEpisodeIndex, num) && Singleton<BuildCustomizationLoader>.Instance.IsChina && GameProgress.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_stars", 0, GameProgress.Location.Local, null) != 3 && GameProgress.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_stars", 0, GameProgress.Location.Local, null) != 0)
		{
			LevelInfo.DisplayContentLimitNotification();
			GameProgress.SetBool("show_content_limit_popup", true, GameProgress.Location.Local);
			EventManager.Send(new UIEvent(UIEvent.Type.LevelSelection));
		}
		else if (flag3 && !flag2 && flag)
		{
			EventManager.Send(new UIEvent(UIEvent.Type.LevelSelection));
		}
		else
		{
			if (Singleton<BuildCustomizationLoader>.Instance.IsChina && GameProgress.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_stars", 0, GameProgress.Location.Local, null) == 3 && GameProgress.GetMinimumLockedLevel(this.CurrentEpisodeIndex) <= this.CurrentLevel + 1)
			{
				GameProgress.SetMinimumLockedLevel(this.CurrentEpisodeIndex, GameProgress.GetMinimumLockedLevel(this.CurrentEpisodeIndex) + 1);
			}
			this.m_currentLevel = num;
			this.LoadLevel(this.CurrentLevel);
		}
		if (this.m_currentEpisode != string.Empty)
		{
			int num3 = this.m_currentLevel / 15;
			int num4 = this.m_currentLevel / 5;
			if (num4 % 3 == 2 && this.m_currentLevel % 5 == 3 && !flag2)
			{
				num3++;
			}
			UserSettings.SetInt(this.m_currentEpisode + "_active_page", num3);
		}
	}

	public void LoadNextLevelAfterCutScene()
	{
		this.LoadLevel(this.NextLevel());
	}

	public LevelLoader CurrentLevelLoader()
	{
		string text;
		if (this.m_currentEpisodeType == GameManager.EpisodeType.Sandbox)
		{
			if (this.m_sandboxSelector == null)
			{
				text = this.GetSandboxLevelData(this.m_currentSandboxIdentifier).m_levelLoaderPath.Remove(0, "Assets/Resources/".Length);
			}
			else
			{
				text = this.m_sandboxSelector.FindLevel(this.m_currentSandboxIdentifier).m_levelLoaderPath.Remove(0, "Assets/Resources/".Length);
			}
		}
		else if (this.m_currentEpisodeType == GameManager.EpisodeType.Race)
		{
			text = this.gameData.FindRaceLevel(this.m_currentRaceLevelIdentifier).m_levelLoaderPath.Remove(0, "Assets/Resources/".Length);
		}
		else
		{
			if (this.m_currentLevel >= this.m_levels.Count)
			{
				return null;
			}
			text = this.m_levels[this.m_currentLevel].levelLoaderPath.Remove(0, "Assets/Resources/".Length);
		}
		int startIndex = text.LastIndexOf('.');
		text = text.Remove(startIndex);
		GameObject gameObject = (GameObject)Resources.Load(text, typeof(GameObject));
		return gameObject.GetComponent<LevelLoader>();
	}

	public void LoadLevel(int index)
	{
		this.m_currentLevel = index;
		this.m_currentLevelName = this.m_levels[index].sceneName;
		Singleton<Loader>.Instance.LoadLevel("LevelStub", GameManager.GameState.Level, true, true);
	}

	public void LoadLevel(string sceneName)
	{
		for (int i = 0; i < this.m_levels.Count; i++)
		{
			if (this.m_levels[i].sceneName == sceneName)
			{
				this.LoadLevel(i);
				break;
			}
		}
	}

	public void LoadSandboxLevel(string sandboxIdentifier, int sandboxBundleIndex = 0)
	{
		this.m_currentSandboxIdentifier = sandboxIdentifier;
		if (this.m_sandboxSelector == null)
		{
			this.m_currentLevelName = this.GetSandboxLevelData(sandboxIdentifier).SceneName;
			this.m_currentEpisodeType = GameManager.EpisodeType.Sandbox;
		}
		else
		{
			this.m_currentLevelName = this.m_sandboxSelector.FindLevelFile(sandboxIdentifier);
		}
		Singleton<Loader>.Instance.LoadLevel("LevelStub", GameManager.GameState.Level, true, true);
	}

	private SandboxLevels.LevelData GetSandboxLevelData(string identifier)
	{
		return this.m_gameData.m_sandboxLevels.GetLevelData(identifier);
	}

	public void LoadRaceLevel(string raceLevelIdentifier)
	{
		this.m_currentRaceLevelIdentifier = raceLevelIdentifier;
		this.m_currentLevelName = this.gameData.FindRaceLevel(raceLevelIdentifier).SceneName;
		this.m_currentEpisodeType = GameManager.EpisodeType.Race;
		Singleton<Loader>.Instance.LoadLevel("LevelStub", GameManager.GameState.Level, true, true);
	}

	public void LoadRaceLevelFromLevelCompleteMenu(string raceLevelIdentifier)
	{
		RaceLevels.LevelData levelData = this.gameData.m_raceLevels.GetLevelData(raceLevelIdentifier);
		int levelIndex = this.gameData.m_raceLevels.GetLevelIndex(raceLevelIdentifier);
		if (LevelInfo.IsContentLimited(-1, levelIndex))
		{
			GameProgress.SetBool("show_content_limit_popup", true, GameProgress.Location.Local);
			EventManager.Send(new UIEvent(UIEvent.Type.EpisodeSelection));
		}
		else
		{
			this.m_currentRaceLevelIdentifier = raceLevelIdentifier;
			this.m_currentLevelName = levelData.SceneName;
			this.m_currentEpisode = "RaceLevelSelection";
			this.m_currentEpisodeType = GameManager.EpisodeType.Race;
			Singleton<Loader>.Instance.LoadLevel("LevelStub", GameManager.GameState.Level, true, true);
		}
	}

	public void LoadUnlockedLevelFromLevelCompleteMenu(string levelName)
	{
		this.m_currentLevel = this.GetCurrentRowJokerLevelIndex();
		this.m_currentLevelName = levelName;
		Singleton<Loader>.Instance.LoadLevel(levelName, GameManager.GameState.Level, true, true);
	}

	public void LoadStarLevelTransition(string sceneName)
	{
		for (int i = 0; i < this.m_levels.Count; i++)
		{
			if (this.m_levels[i].sceneName == sceneName)
			{
				this.LoadStarLevelTransition(this.m_levels[i]);
				break;
			}
		}
	}

	public void LoadStarLevelTransition(EpisodeLevelInfo level)
	{
		if (this.gameData.m_episodeLevels[this.m_currentEpisodeIndex].m_showStarLevelTransition)
		{
			this.m_currentLevel = this.m_levels.IndexOf(level);
			this.m_currentLevelName = level.sceneName;
			Singleton<Loader>.Instance.LoadLevel("StarLevelTransition", GameManager.GameState.StarLevelCutscene, true, true);
		}
		else
		{
			this.LoadLevel(level.sceneName);
		}
	}

	public void LoadLevelAfterCutScene(EpisodeLevelInfo level, string cutScene)
	{
		this.m_currentLevel = this.m_levels.IndexOf(level);
		this.m_currentLevelName = level.sceneName;
		Singleton<Loader>.Instance.LoadLevel(cutScene, GameManager.GameState.Cutscene, true, true);
	}

	public void LoadStarLevelAfterTransition()
	{
		Singleton<Loader>.Instance.LoadLevel("LevelStub", GameManager.GameState.Level, true, true);
	}

	public void LoadSandboxLevelSelection()
	{
		GameTime.Pause(false);
		UserSettings.SetBool(CompactEpisodeSelector.IsEpisodeToggledKey, true);
		Singleton<Loader>.Instance.LoadLevel("EpisodeSelection", GameManager.GameState.EpisodeSelection, true, true);
	}

	public void LoadRaceLevelSelection()
	{
		GameTime.Pause(false);
		Singleton<Loader>.Instance.LoadLevel("RaceLevelSelection", GameManager.GameState.RaceLevelSelection, true, true);
	}

	public void LoadSandboxLevelSelectionAndOpenIapMenu()
	{
		this.LoadSandboxLevelSelection();
	}

	public void ReloadCurrentLevel(bool showLoadingScreen)
	{
		GameProgress.SetString("REPLAY_LEVEL", SceneManager.GetActiveScene().name, GameProgress.Location.Local);
		Singleton<Loader>.Instance.LoadLevel(SceneManager.GetActiveScene().name, this.m_gameState, showLoadingScreen, true);
	}

	public void LoadOpeningCutscene()
	{
		Singleton<Loader>.Instance.LoadLevel(this.OpeningCutscene, GameManager.GameState.Cutscene, true, true);
	}

	public void LoadMidCutscene(bool isStartedFromLevelSelection = false)
	{
		this.m_isCutsceneStartedFromLevelSelection = isStartedFromLevelSelection;
		Singleton<Loader>.Instance.LoadLevel(this.MidCutscene, GameManager.GameState.Cutscene, true, true);
	}

	public void LoadEndingCutscene()
	{
		if (this.HasMidCutsceneEnabled())
		{
			this.LoadMidCutscene(false);
		}
		else
		{
			Singleton<Loader>.Instance.LoadLevel(this.EndingCutscene, GameManager.GameState.Cutscene, true, true);
		}
	}

	public void LoadEpisodeSelection(bool showLoadingScreen)
	{
		Singleton<Loader>.Instance.LoadLevel("EpisodeSelection", GameManager.GameState.EpisodeSelection, showLoadingScreen, true);
	}

	public void LoadCakeRaceMenu(bool showLoadingScreen = false)
	{
		Singleton<Loader>.Instance.LoadLevel("CakeRaceMenu", GameManager.GameState.CakeRaceMenu, showLoadingScreen, true);
	}

	public void LoadLevelSelection(string episode, bool showLoadingScreen)
	{
		Singleton<Loader>.Instance.LoadLevel(episode, GameManager.GameState.LevelSelection, showLoadingScreen, true);
	}

	public void LoadLevelSelectionAndLevel(string episode, int levelIndex)
	{
		this.m_openLevel = true;
		this.m_openLevelIndex = levelIndex;
		Singleton<Loader>.Instance.LoadLevel(episode, GameManager.GameState.LevelSelection, true, false);
	}

	public void LoadCheatsPanel()
	{
		Singleton<Loader>.Instance.LoadLevel("CheatsPanel", GameManager.GameState.CheatsPanel, true, true);
	}

	public bool CurrentStarLevelUnlocked()
	{
		int num = 0;
		int num2 = this.m_currentLevel / 5 * 5;
		if (this.m_levels.Count < 5)
		{
			return false;
		}
		for (int i = num2; i < num2 + 4; i++)
		{
			num += GameProgress.GetInt(this.m_levels[i].sceneName + "_stars", 0, GameProgress.Location.Local, null);
		}
		return num >= this.m_starlevelLimits[(num2 + 4) / 5];
	}

	public bool CurrentEpisodeThreeStarred()
	{
		if (this.m_currentEpisodeType == GameManager.EpisodeType.Normal)
		{
			bool flag = true;
			int num = 0;
			while (num < this.m_levels.Count && flag)
			{
				flag &= (GameProgress.GetInt(this.m_levels[num].sceneName + "_stars", 0, GameProgress.Location.Local, null) == 3);
				num++;
			}
			return flag;
		}
		if (this.m_currentEpisodeType == GameManager.EpisodeType.Race)
		{
			bool flag2 = true;
			for (int i = 0; i < this.gameData.m_raceLevels.Levels.Count; i++)
			{
				flag2 &= (GameProgress.GetInt(this.gameData.m_raceLevels.Levels[i].SceneName + "_stars", 0, GameProgress.Location.Local, null) == 3);
			}
			return flag2;
		}
		return false;
	}

	public bool CurrentEpisodeThreeStarredNormalLevels()
	{
		if (this.m_currentEpisodeType != GameManager.EpisodeType.Normal)
		{
			return false;
		}
		if (!this.IsEpisodeCompletable())
		{
			return false;
		}
		bool flag = true;
		int num = 0;
		while (num < this.m_levels.Count && flag)
		{
			flag &= (GameProgress.GetInt(this.m_levels[num].sceneName + "_stars", 0, GameProgress.Location.Local, null) == 3);
			num++;
		}
		return flag;
	}

	public bool CurrentEpisodeThreeStarredSpecialLevels()
	{
		if (this.m_currentEpisodeType != GameManager.EpisodeType.Normal)
		{
			return false;
		}
		if (!this.IsEpisodeCompletable())
		{
			return false;
		}
		bool flag = true;
		int num = 4;
		while (num < this.m_levels.Count && flag)
		{
			flag &= (GameProgress.GetInt(this.m_levels[num].sceneName + "_stars", 0, GameProgress.Location.Local, null) == 3);
			num += 5;
		}
		return flag;
	}

	private bool IsEpisodeCompletable()
	{
		return this.m_levels.Count == this.gameData.m_episodeLevels[this.CurrentEpisodeIndex].TotalLevelCount;
	}

	public EpisodeLevelInfo GetCurrentRowJokerLevel()
	{
		int num = this.m_currentLevel / 5 * 5;
		return (this.m_levels.Count < 5) ? null : this.m_levels[num + 4];
	}

	public int GetCurrentRowJokerLevelIndex()
	{
		int num = this.m_currentLevel / 5 * 5;
		return num + 4;
	}

	public void InitializeTestLevelState()
	{
		this.m_currentLevelName = SceneManager.GetActiveScene().name;
		LevelLoader[] array = UnityEngine.Object.FindObjectsOfType<LevelLoader>();
		if (array.Length > 0)
		{
			this.m_currentLevelName = array[0].SceneName;
		}
		LevelManager[] array2 = UnityEngine.Object.FindObjectsOfType<LevelManager>();
		if (array2.Length > 0)
		{
			this.m_gameState = GameManager.GameState.Level;
			this.m_currentEpisodeType = GameManager.EpisodeType.Normal;
			LevelManager levelManager = array2[0];
			if (levelManager.m_sandbox)
			{
				this.m_currentEpisodeType = GameManager.EpisodeType.Sandbox;
			}
			else if (levelManager.m_raceLevel)
			{
				this.m_currentEpisodeType = GameManager.EpisodeType.Race;
			}
			if (this.m_currentEpisodeType == GameManager.EpisodeType.Sandbox)
			{
				foreach (SandboxLevels.LevelData levelData in this.gameData.m_sandboxLevels.Levels)
				{
					if (levelData.SceneName == this.m_currentLevelName)
					{
						this.m_currentSandboxIdentifier = levelData.m_identifier;
						break;
					}
				}
			}
			else if (this.m_currentEpisodeType == GameManager.EpisodeType.Race)
			{
				foreach (RaceLevels.LevelData levelData2 in this.gameData.m_raceLevels.Levels)
				{
					if (levelData2.SceneName == this.m_currentLevelName)
					{
						this.m_currentRaceLevelIdentifier = levelData2.m_identifier;
						break;
					}
				}
			}
			else
			{
				for (int i = 0; i < this.gameData.m_episodeLevels.Count; i++)
				{
					List<EpisodeLevelInfo> levelInfos = this.gameData.m_episodeLevels[i].LevelInfos;
					for (int j = 0; j < levelInfos.Count; j++)
					{
						if (levelInfos[j].sceneName == this.m_currentLevelName)
						{
							this.m_currentEpisodeIndex = i;
							this.m_currentEpisode = this.m_gameData.m_episodeLevels[this.m_currentEpisodeIndex].Name;
							this.m_currentLevel = j;
							break;
						}
					}
				}
			}
		}
	}

	private void Awake()
	{
		base.SetAsPersistant();
		if (Bundle.initialized)
		{
			this.gameData.commonAudioCollection.Initialize();
		}
		else
		{
			Bundle.AssetBundlesLoaded = (Action)Delegate.Combine(Bundle.AssetBundlesLoaded, new Action(delegate()
			{
				this.gameData.commonAudioCollection.Initialize();
			}));
		}
        EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.OnReceivedUIEvent));
		SceneManager.sceneLoaded += this.OnSceneLoaded;
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.OnReceivedUIEvent));
		SceneManager.sceneLoaded -= this.OnSceneLoaded;
	}

	private void OnApplicationFocus(bool focus)
	{
		Resources.UnloadUnusedAssets();
	}

	private IEnumerator Start()
	{
		while (!Bundle.initialized)
		{
			yield return null;
		}
        yield break;
	}

	public void Quit(string message)
	{
		Application.Quit();
	}

	private void OnReceivedUIEvent(UIEvent data)
	{
		if (data.type != UIEvent.Type.ClosedLootWheel)
		{
			return;
		}
		if (Singleton<IapManager>.IsInstantiated() && Singleton<IapManager>.Instance.IsShopPageOpened())
		{
			return;
		}
		if (SnoutCoinShopPopup.DialogOpen)
		{
			return;
		}
		int requiredLevel = PlayerLevelRequirement.GetRequiredLevel("cake_race");
		if (requiredLevel >= 0 && Singleton<PlayerProgress>.Instance.Level >= requiredLevel && !GameProgress.HasKey("CakeRaceUnlockShown", GameProgress.Location.Local, null))
		{
			GameProgress.SetBool("CakeRaceUnlockShown", false, GameProgress.Location.Local);
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.gameData.m_cakeRaceUnlockedPopup);
			gameObject.transform.position = WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 2f;
		}
	}

	public void CreateMenuBackground()
	{
		string @string = GameProgress.GetString("MenuBackground", string.Empty, GameProgress.Location.Local, null);
		GameObject gameObject = null;
		if (@string != string.Empty)
		{
			gameObject = (GameObject)Resources.Load("Environment/Background/" + @string, typeof(GameObject));
		}
		if (!gameObject)
		{
			gameObject = (GameObject)Resources.Load("Environment/Background/Background_Jungle_01_SET", typeof(GameObject));
		}
		UnityEngine.Object.Instantiate<GameObject>(gameObject, Vector3.forward * 10f, Quaternion.identity);
	}

	public string NextRaceLevel()
	{
		for (int i = 0; i < this.gameData.m_raceLevels.Levels.Count - 1; i++)
		{
			if (this.gameData.m_raceLevels.Levels[i].m_identifier == this.m_currentRaceLevelIdentifier)
			{
				return this.gameData.m_raceLevels.Levels[i + 1].m_identifier;
			}
		}
		return "UndefinedRaceLevel";
	}

	public string CurrentLevelLeaderboard()
	{
		RaceLevels.LevelData levelData = this.gameData.FindRaceLevel(this.m_currentRaceLevelIdentifier);
		if (levelData != null)
		{
			return levelData.m_leaderboardId;
		}
		return string.Empty;
	}

	public bool IsLastLevelInEpisode()
	{
        EpisodeType currentEpisodeType = this.m_currentEpisodeType;
		if (currentEpisodeType != GameManager.EpisodeType.Normal)
		{
			return currentEpisodeType != GameManager.EpisodeType.Sandbox && currentEpisodeType == GameManager.EpisodeType.Race && this.m_currentRaceLevelIdentifier == this.gameData.m_raceLevels.Levels[this.gameData.m_raceLevels.Levels.Count - 1].m_identifier;
		}
		return this.m_currentLevel == this.m_levels.Count - 2;
	}

	public bool HasMidCutsceneEnabled()
	{
		return (this.CurrentEpisodeIndex == 4 || this.CurrentEpisodeIndex == 5) && this.m_currentLevel == 13;
	}

	public bool HasNextLevel()
	{
        EpisodeType currentEpisodeType = this.m_currentEpisodeType;
		if (currentEpisodeType != GameManager.EpisodeType.Normal)
		{
			return currentEpisodeType != GameManager.EpisodeType.Sandbox && currentEpisodeType == GameManager.EpisodeType.Race && !this.IsLastLevelInEpisode();
		}
		return (this.CurrentLevel + 1) % 5 != 0 && !this.IsNextPageComingSoon() && !this.IsLastLevelInEpisode();
	}

	public bool HasCutScene()
	{
        EpisodeType currentEpisodeType = this.m_currentEpisodeType;
		if (currentEpisodeType != GameManager.EpisodeType.Normal)
		{
			return currentEpisodeType != GameManager.EpisodeType.Sandbox && currentEpisodeType != GameManager.EpisodeType.Race && false;
		}
		return (this.IsLastLevelInEpisode() && !string.IsNullOrEmpty(this.m_endingCutscene)) || (this.HasMidCutsceneEnabled() && !string.IsNullOrEmpty(this.m_midCutscene));
	}

	[SerializeField]
	private GameData m_gameData;

	[SerializeField]
	private LevelRewardData m_levelRewardData;

	private GameState m_prevGameState;

	private GameState m_gameState;

	private GameState m_loadingLevelGameState;

	private int m_currentLevel;

	private int m_currentEpisodeIndex;

	private int m_pagesComingSoonBitmask;

	private EpisodeType m_currentEpisodeType;

	private string m_currentSandboxIdentifier;

	private string m_currentRaceLevelIdentifier;

	private string m_currentLevelName = string.Empty;

	private string m_currentEpisode = string.Empty;

	private List<EpisodeLevelInfo> m_levels = new List<EpisodeLevelInfo>();

	private SandboxSelector m_sandboxSelector;

	private List<int> m_starlevelLimits = new List<int>();

	private string m_openingCutscene;

	private string m_endingCutscene;

	private string m_midCutscene;

	private bool m_isCutsceneStartedFromLevelSelection;

	private bool m_openLevel;

	private int m_openLevelIndex;

	private const string StubLevelName = "LevelStub";

	public enum GameState
	{
		Undefined,
		MainMenu,
		EpisodeSelection,
		LevelSelection,
		Level,
		Cutscene,
		CheatsPanel,
		StarLevelCutscene,
		SandboxLevelSelection,
		RaceLevelSelection,
		KingPigFeeding,
		WorkShop,
		CakeRaceMenu
	}

	public enum EpisodeType
	{
		Undefined,
		Normal,
		Sandbox,
		Race
	}
}
