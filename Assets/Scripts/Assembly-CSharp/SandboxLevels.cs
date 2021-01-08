using System;
using System.Collections.Generic;
using UnityEngine;

public class SandboxLevels : MonoBehaviour
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

	public string ClearAchievement
	{
		get
		{
			return this.m_clearAchievement;
		}
	}

	public string ThreeStarAchievement
	{
		get
		{
			return this.m_3starAchievement;
		}
	}

	public string SpecialThreeStarAchievement
	{
		get
		{
			return this.m_special3StarAchievement;
		}
	}

	public List<LevelData> Levels
	{
		get
		{
			return this.m_levels;
		}
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

	[SerializeField]
	private string m_name;

	[SerializeField]
	private string m_label;

	[SerializeField]
	private string m_flurryID;

	[SerializeField]
	private string m_clearAchievement;

	[SerializeField]
	private string m_3starAchievement;

	[SerializeField]
	private string m_special3StarAchievement;

	[SerializeField]
	private List<LevelData> m_levels = new List<LevelData>();

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

		public int m_starBoxCount;

		public string m_levelLoaderPath;

		public string m_levelLoaderGUID;

		private string m_sceneName;
	}
}
