using System.Collections.Generic;
using UnityEngine;

public class Episode : MonoBehaviour
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

	public bool OverrideInFlightMusic
	{
		get
		{
			return this.m_overrideInFlightMusic;
		}
	}

	public bool OverrideBuildMusic
	{
		get
		{
			return this.m_overrideBuildingMusic;
		}
	}

	public GameObject InFlightMusic
	{
		get
		{
			return this.inFlightMusic.LoadValue<GameObject>();
		}
	}

	public GameObject BuildingMusic
	{
		get
		{
			return this.buildingMusic.LoadValue<GameObject>();
		}
	}

	public List<EpisodeLevelInfo> LevelInfos
	{
		get
		{
			return this.m_levelInfos;
		}
	}

	public List<int> StarLevelLimits
	{
		get
		{
			return this.m_starLimits;
		}
	}

	public int TotalLevelCount
	{
		get
		{
			return this.totalLevelCount;
		}
	}

	private void Awake()
	{
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
	private bool m_overrideInFlightMusic;

	[SerializeField]
	private BundleDataObject inFlightMusic;

	[SerializeField]
	private bool m_overrideBuildingMusic;

	[SerializeField]
	private BundleDataObject buildingMusic;

	[SerializeField]
	private int totalLevelCount;

	public bool m_showStarLevelTransition = true;

	[HideInInspector]
	public List<EpisodeLevelInfo> m_levelInfos = new List<EpisodeLevelInfo>();

	[SerializeField]
	private List<int> m_starLimits = new List<int>();
}
