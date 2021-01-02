using UnityEngine;

public class EpisodeButton : WPFMonoBehaviour
{
	public int Index
	{
		get
		{
			return this.m_episodeLevelsGameDataIndex;
		}
	}

	private void Awake()
	{
		if (string.IsNullOrEmpty(this.m_episodeBundleName))
		{
			GameManager.EpisodeType type = this.m_type;
			if (type != GameManager.EpisodeType.Normal)
			{
				if (type != GameManager.EpisodeType.Race)
				{
					if (type == GameManager.EpisodeType.Sandbox)
					{
						this.m_episodeBundleName = "Episode_Sandbox_Levels";
					}
				}
				else
				{
					this.m_episodeBundleName = "Episode_Race_Levels";
				}
			}
			else
			{
				this.m_episodeBundleName = Bundle.GetAssetBundleID(this.m_episodeLevelsGameDataIndex);
			}
		}
		//if (this.m_contentLock)
		//{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_contentLock);
			gameObject.transform.parent = base.gameObject.transform;
			gameObject.transform.localPosition = new Vector3(0f, -0.5f, 0f);
			gameObject.GetComponent<ContentLock>().Activate(false);
		//}
		/*if (!Bundle.HasBundle(this.m_episodeBundleName) && this.m_contentNotAvailable)
		{
			Button component = base.GetComponent<Button>();
			if (component != null)
			{
				UnityEngine.Object.DestroyImmediate(component);
			}
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.m_contentNotAvailable);
			gameObject2.transform.parent = base.gameObject.transform;
			gameObject2.transform.localPosition = new Vector3(0f, -0.5f, 0f);
			if (this.m_hideOnContentNotAvailable != null)
			{
				for (int i = 0; i < this.m_hideOnContentNotAvailable.Length; i++)
				{
					if (this.m_hideOnContentNotAvailable[i] != null)
					{
						this.m_hideOnContentNotAvailable[i].SetActive(false);
					}
				}
			}
		}*/
		if (this.m_newContent && Bundle.HasBundle(this.m_episodeBundleName) && GameProgress.GetBool(this.m_episodeBundleName + "_new_content", true, GameProgress.Location.Local, null))
		{
			Transform transform = base.transform.Find("NewTag");
			if (transform)
			{
				this.m_newContent = UnityEngine.Object.Instantiate<GameObject>(this.m_newContent);
				this.m_newContent.transform.parent = transform;
				this.m_newContent.transform.localPosition = Vector3.zero;
			}
			else
			{
				this.m_newContent = null;
			}
		}
		Transform transform2 = base.transform.Find("Background");
		if (transform2 != null)
		{
			this.materialInstance = transform2.GetComponent<Renderer>().material;
			this.materialInstance.color = this.m_bgcolor;
			AtlasMaterials.Instance.AddMaterialInstance(this.materialInstance);
		}
		int num = 0;
		int num2 = 0;
		if (this.m_type == GameManager.EpisodeType.Sandbox)
		{
			num = this.CalculateSandboxStars();
			foreach (SandboxLevels.LevelData levelData in WPFMonoBehaviour.gameData.m_sandboxLevels.Levels)
			{
				num2 += levelData.m_starBoxCount;
			}
		}
		else if (this.m_type == GameManager.EpisodeType.Race)
		{
			num = this.CalculateRaceLevelStars();
			num2 = 3 * WPFMonoBehaviour.gameData.m_raceLevels.Levels.Count;
		}
		else
		{
			num = this.CalculateEpisodeStars();
			num2 = 3 * WPFMonoBehaviour.gameData.m_episodeLevels[this.m_episodeLevelsGameDataIndex].LevelInfos.Count;
			if ((this.pageTwoComingSoon || this.pageThreeComingSoon) && num2 >= 90)
			{
				num2 -= 45 * ((!this.pageTwoComingSoon || !this.pageThreeComingSoon || num2 < 135) ? 1 : 2);
			}
		}
		Transform transform3 = base.transform.Find("StarText");
		if (transform3 != null)
		{
			transform3.GetComponent<TextMesh>().text = string.Concat(new object[]
			{
				string.Empty,
				num,
				"/",
				num2
			});
		}
		Transform transform4 = base.transform.Find("EpisodeAnimation");
		if (transform4 != null)
		{
			transform4.gameObject.AddComponent<UnityEngine.Rendering.SortingGroup>().sortingOrder = 1;
		}
	}

	private void OnDestroy()
	{
		if (AtlasMaterials.IsInstantiated)
		{
			AtlasMaterials.Instance.RemoveMaterialInstance(this.materialInstance);
		}
	}

	public void GoToLevelSelection(string levelSelectionPage)
	{
		if (this.m_newContent)
		{
			GameProgress.SetBool(this.m_episodeBundleName + "_new_content", false, GameProgress.Location.Local);
		}
		UserSettings.SetString(CompactEpisodeSelector.CurrentEpisodeKey, base.gameObject.name);
		Singleton<GameManager>.Instance.LoadLevelSelection(levelSelectionPage, false);
	}

	private int CalculateEpisodeStars()
	{
		int num = 0;
		foreach (EpisodeLevelInfo episodeLevelInfo in WPFMonoBehaviour.gameData.m_episodeLevels[this.m_episodeLevelsGameDataIndex].LevelInfos)
		{
			num += GameProgress.GetInt(episodeLevelInfo.sceneName + "_stars", 0, GameProgress.Location.Local, null);
		}
		return num;
	}

	private int CalculateSandboxStars()
	{
		int num = 0;
		foreach (SandboxLevels.LevelData levelData in WPFMonoBehaviour.gameData.m_sandboxLevels.Levels)
		{
			num += GameProgress.GetInt(levelData.SceneName + "_stars", 0, GameProgress.Location.Local, null);
		}
		return num;
	}

	private int CalculateRaceLevelStars()
	{
		int num = 0;
		foreach (RaceLevels.LevelData levelData in WPFMonoBehaviour.gameData.m_raceLevels.Levels)
		{
			num += GameProgress.GetInt(levelData.SceneName + "_stars", 0, GameProgress.Location.Local, null);
		}
		return num;
	}

	public Color m_bgcolor;

	[SerializeField]
	private GameManager.EpisodeType m_type = GameManager.EpisodeType.Normal;

	[SerializeField]
	private int m_episodeLevelsGameDataIndex;

	[SerializeField]
	private GameObject m_newContent;

	[SerializeField]
	private GameObject m_contentLock;

	[SerializeField]
	private GameObject m_contentNotAvailable;

	[SerializeField]
	private bool pageTwoComingSoon;

	[SerializeField]
	private bool pageThreeComingSoon;

	[SerializeField]
	private GameObject[] m_hideOnContentNotAvailable;

	[SerializeField]
	private string m_episodeBundleName = string.Empty;

	private Material materialInstance;
}
