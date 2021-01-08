using System;
using System.Collections.Generic;
using UnityEngine;

public class RaceLevels : MonoBehaviour
{
	public string Name
	{
		get
		{
			return this.m_name;
		}
	}

	public string Label
	{
		get
		{
			return this.m_label;
		}
	}

	public string FlurryID
	{
		get
		{
			return this.m_flurryID;
		}
	}

	public List<LevelData> Levels
	{
		get
		{
			return this.m_levels;
		}
	}

	public int GetLevelIndex(string identifier)
	{
		int result = -1;
		for (int i = 0; i < this.m_levels.Count; i++)
		{
			if (this.m_levels[i].m_identifier == identifier)
			{
				result = i;
				break;
			}
		}
		return result;
	}

	public LevelData GetLevelData(string identifier)
	{
		foreach (LevelData levelData in this.m_levels)
		{
			if (levelData.m_identifier == identifier)
			{
				return levelData;
			}
		}
		return null;
	}

	public List<LevelUnlockablePartsData> LevelUnlockables
	{
		get
		{
			return this.m_unlockables;
		}
	}

	public LevelUnlockablePartsData GetLevelUnlockableData(string identifier)
	{
		foreach (LevelUnlockablePartsData levelUnlockablePartsData in this.m_unlockables)
		{
			if (levelUnlockablePartsData.m_identifier == identifier)
			{
				return levelUnlockablePartsData;
			}
		}
		return null;
	}

	[SerializeField]
	private string m_name;

	[SerializeField]
	private string m_label;

	[SerializeField]
	private string m_flurryID;

	[SerializeField]
	private List<LevelData> m_levels = new List<LevelData>();

	[SerializeField]
	private List<LevelUnlockablePartsData> m_unlockables = new List<LevelUnlockablePartsData>();

	[Serializable]
	public class LevelData
	{
		public string SceneName
		{
			get
			{
				if (string.IsNullOrEmpty(this.m_sceneName))
				{
					this.m_sceneName = this.m_levelLoaderPath.Substring(this.m_levelLoaderPath.LastIndexOf('/') + 1);
					this.m_sceneName = this.m_sceneName.Remove(this.m_sceneName.LastIndexOf('_'));
				}
				return this.m_sceneName;
			}
		}

		public string m_identifier;

		public string m_leaderboardId;

		public string m_levelLoaderPath;

		public string m_levelLoaderGUID;

		private string m_sceneName;
	}

	[Serializable]
	public class LevelUnlockablePartsData
	{
		public string m_identifier;

		public string m_levelNumber;

		public List<UnlockableTier> m_tiers;
	}

	[Serializable]
	public class UnlockableTier
	{
		public int m_starLimit;

		public BasePart.PartType m_part;
	}
}
