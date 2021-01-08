using System.Collections.Generic;
using UnityEngine;

public class LevelInfo
{
	public static void DisplayContentLimitNotification()
	{
		if (Singleton<BuildCustomizationLoader>.Instance.IsChina)
		{
			GameObject gameObject = LevelsUnlockDialog.Create();
			gameObject.SetActive(true);
		}
		else
		{
			EventManager.Send(new UIEvent(UIEvent.Type.OpenUnlockFullVersionIapMenu));
		}
	}

	public static bool IsContentLimited(int episodeIndex, int levelIndex = 0)
	{
		bool flag = GameProgress.GetFullVersionUnlocked() || (episodeIndex == 0 && levelIndex < 15) || (episodeIndex == -1 && levelIndex < 4) || (episodeIndex > 0 && levelIndex < 5);
		if (Singleton<BuildCustomizationLoader>.Instance.IsChina && episodeIndex >= 0)
		{
			if (!LevelInfo.IsStarLevel(episodeIndex, levelIndex) && levelIndex + 1 - (levelIndex + 1) / 5 + 1 == GameProgress.GetMinimumLockedLevel(episodeIndex) && LevelInfo.GetStars(episodeIndex, levelIndex) == 3)
			{
				GameProgress.SetMinimumLockedLevel(episodeIndex, GameProgress.GetMinimumLockedLevel(episodeIndex) + 1);
			}
			flag = (episodeIndex >= 0 && levelIndex + 1 - (levelIndex + 1) / 5 < GameProgress.GetMinimumLockedLevel(episodeIndex));
			if (LevelInfo.IsStarLevel(episodeIndex, levelIndex))
			{
				flag = true;
			}
		}
		return !flag;
	}

	public static bool IsNormalEpisode(int episodeIndex)
	{
		return episodeIndex >= 0 && episodeIndex < Singleton<GameManager>.Instance.gameData.m_episodeLevels.Count;
	}

	public static bool ValidLevelIndex(int episodeIndex, int levelIndex)
	{
		List<string> levelNames = LevelInfo.GetLevelNames(episodeIndex);
		return levelIndex >= 0 && levelIndex < levelNames.Count;
	}

	public static bool IsStarLevel(int episodeIndex, int levelIndex)
	{
		return (levelIndex + 1) % 5 == 0;
	}

	public static void GetStarLevelStars(int episodeIndex, int levelIndex, out int current, out int limit)
	{
		List<string> levelNames = LevelInfo.GetLevelNames(episodeIndex);
		current = 0;
		for (int i = 1; i < 5; i++)
		{
			current += GameProgress.GetInt(levelNames[levelIndex - i] + "_stars", 0, GameProgress.Location.Local, null);
		}
		limit = LevelInfo.GetStarLevelLimit(episodeIndex, levelIndex);
	}

	public static int GetStarLevelLimit(int episodeIndex, int levelIndex)
	{
		int index = levelIndex / 5;
		Episode episodeData = LevelInfo.GetEpisodeData(episodeIndex);
		return episodeData.StarLevelLimits[index];
	}

	public static int GetStars(int episodeIndex, int levelIndex)
	{
		List<string> levelNames = LevelInfo.GetLevelNames(episodeIndex);
		return GameProgress.GetInt(levelNames[levelIndex] + "_stars", 0, GameProgress.Location.Local, null);
	}

	public static bool IsLevelUnlocked(int episodeIndex, int levelIndex)
	{
		bool flag = LevelInfo.IsStarLevel(episodeIndex, levelIndex);
		if (GameProgress.AllLevelsUnlocked() || levelIndex == 0)
		{
			return true;
		}
		if (Singleton<BuildCustomizationLoader>.Instance.CheatsEnabled && GameProgress.AllFreeLevelsUnlocked() && !LevelInfo.IsContentLimited(episodeIndex, levelIndex))
		{
			return true;
		}
		int index = LevelInfo.PreviousNormalLevelIndex(episodeIndex, levelIndex);
		List<string> levelNames = LevelInfo.GetLevelNames(episodeIndex);
		bool result = GameProgress.IsLevelCompleted(levelNames[index]);
		if (!flag && !Singleton<BuildCustomizationLoader>.Instance.IsChina)
		{
			return result;
		}
		if (!flag && Singleton<BuildCustomizationLoader>.Instance.IsChina)
		{
			return true;
		}
		int num;
		int num2;
		LevelInfo.GetStarLevelStars(episodeIndex, levelIndex, out num, out num2);
		return num >= num2;
	}

	public static bool IsLevelCompleted(int episodeIndex, int levelIndex)
	{
		List<string> levelNames = LevelInfo.GetLevelNames(episodeIndex);
		return GameProgress.IsLevelCompleted(levelNames[levelIndex]);
	}

	public static List<string> GetLevelNames(int episodeIndex)
	{
		List<string> list = new List<string>();
		List<EpisodeLevelInfo> levelInfos = LevelInfo.GetEpisodeData(episodeIndex).LevelInfos;
		for (int i = 0; i < levelInfos.Count; i++)
		{
			list.Add(levelInfos[i].sceneName);
		}
		return list;
	}

	public static bool AllBasicContentPlayed()
	{
		for (int i = 0; i < Singleton<GameManager>.Instance.gameData.m_episodeLevels.Count; i++)
		{
			Episode episodeData = LevelInfo.GetEpisodeData(i);
			for (int j = 0; j < episodeData.LevelInfos.Count; j++)
			{
				if ((!Singleton<BuildCustomizationLoader>.Instance.IsContentLimited || !LevelInfo.IsContentLimited(i, j)) && !LevelInfo.IsStarLevel(i, j) && !LevelInfo.IsLevelCompleted(i, j))
				{
					return false;
				}
			}
		}
		return true;
	}

	public static bool AllNonIapContentPlayed()
	{
		for (int i = 0; i < Singleton<GameManager>.Instance.gameData.m_episodeLevels.Count; i++)
		{
			Episode episodeData = LevelInfo.GetEpisodeData(i);
			for (int j = 0; j < episodeData.LevelInfos.Count; j++)
			{
				if ((!Singleton<BuildCustomizationLoader>.Instance.IsContentLimited || !LevelInfo.IsContentLimited(i, j)) && !LevelInfo.IsLevelCompleted(i, j))
				{
					return false;
				}
			}
		}
		foreach (SandboxLevels.LevelData levelData in Singleton<GameManager>.Instance.gameData.m_sandboxLevels.Levels)
		{
			if (GameProgress.SandboxStarCount(levelData.SceneName) == 0 && levelData.m_identifier != "S-F")
			{
				return false;
			}
		}
		return true;
	}

	public static bool AllContentPlayed()
	{
		for (int i = 0; i < Singleton<GameManager>.Instance.gameData.m_episodeLevels.Count; i++)
		{
			Episode episodeData = LevelInfo.GetEpisodeData(i);
			for (int j = 0; j < episodeData.LevelInfos.Count; j++)
			{
				if (!LevelInfo.IsLevelCompleted(i, j))
				{
					return false;
				}
			}
		}
		foreach (SandboxLevels.LevelData levelData in Singleton<GameManager>.Instance.gameData.m_sandboxLevels.Levels)
		{
			if (GameProgress.SandboxStarCount(levelData.SceneName) == 0)
			{
				return false;
			}
		}
		return true;
	}

	public static bool CanAdUnlockNextLevel(LevelManager levelManager = null)
	{
		int episodeIndex = Singleton<GameManager>.Instance.CurrentEpisodeIndex;
		int levelIndex = Singleton<GameManager>.Instance.NextLevel();
		if (levelManager != null && levelManager.m_raceLevel)
		{
			episodeIndex = -1;
			string text = Singleton<GameManager>.Instance.NextRaceLevel();
			for (int i = 0; i < Singleton<GameManager>.Instance.gameData.m_raceLevels.Levels.Count; i++)
			{
				if (text.Equals(Singleton<GameManager>.Instance.gameData.m_raceLevels.Levels[i].m_identifier))
				{
					levelIndex = i;
					break;
				}
			}
		}
		return LevelInfo.CanAdUnlock(episodeIndex, levelIndex);
	}

	public static bool CanAdUnlock(int episodeIndex, int levelIndex)
	{
		if (!Singleton<BuildCustomizationLoader>.Instance.IsContentLimited)
		{
			return false;
		}
		bool flag = false;
		List<string> list;
		if (episodeIndex == -1)
		{
			flag = true;
			list = new List<string>();
			List<string> list2 = new List<string>();
			for (int i = 0; i < Singleton<GameManager>.Instance.gameData.m_raceLevels.Levels.Count; i++)
			{
				list.Add(Singleton<GameManager>.Instance.gameData.m_raceLevels.Levels[i].SceneName);
				list2.Add(Singleton<GameManager>.Instance.gameData.m_raceLevels.Levels[i].m_identifier);
			}
		}
		else
		{
			list = LevelInfo.GetLevelNames(episodeIndex);
		}
		bool flag2 = true;
		if (!flag && LevelInfo.IsStarLevel(episodeIndex, levelIndex))
		{
			int num;
			int num2;
			LevelInfo.GetStarLevelStars(episodeIndex, levelIndex, out num, out num2);
			return !flag2 && num >= num2 && LevelInfo.IsContentLimited(episodeIndex, levelIndex);
		}
		int num3 = levelIndex - 1;
		if (!flag && num3 > 0 && LevelInfo.IsStarLevel(episodeIndex, num3))
		{
			num3--;
		}
		if (num3 < 0)
		{
			return true;
		}
		if (GameProgress.IsLevelCompleted(list[num3]) && levelIndex < list.Count && !GameProgress.IsLevelCompleted(list[levelIndex]) && LevelInfo.IsContentLimited(episodeIndex, (!flag) ? levelIndex : (levelIndex + 1)) && !flag2)
		{
			return true;
		}
		int num4 = levelIndex / 5;
		int num5 = num4 - 1;
		return !flag && !flag2 && num4 != 0 && (LevelInfo.IsLevelUnlocked(episodeIndex, num5 * 5) || !LevelInfo.IsContentLimited(episodeIndex, num5 * 5));
	}

	public static int PreviousNormalLevelIndex(int episodeIndex, int levelIndex)
	{
		return (!LevelInfo.IsStarLevel(episodeIndex, levelIndex - 1)) ? (levelIndex - 1) : (levelIndex - 2);
	}

	private static Episode GetEpisodeData(int episodeIndex)
	{
		return Singleton<GameManager>.Instance.gameData.m_episodeLevels[episodeIndex];
	}

	private const int LevelsPerRow = 5;

	private const string popupName = "ContentLimitNotification";
}
