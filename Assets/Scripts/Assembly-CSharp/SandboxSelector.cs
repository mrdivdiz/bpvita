using System;
using System.Collections.Generic;
using UnityEngine;

public class SandboxSelector : MonoBehaviour
{
	public List<SandboxLevels.LevelData> Levels
	{
		get
		{
			return this.m_sandboxLevels.Levels;
		}
	}

	public SandboxLevels.LevelData FindLevel(string identifier)
	{
		return this.m_sandboxLevels.GetLevelData(identifier);
	}

	public string FindLevelFile(string identifier)
	{
		SandboxLevels.LevelData levelData = this.m_sandboxLevels.GetLevelData(identifier);
		if (levelData != null)
		{
			return levelData.SceneName;
		}
		return "UndefinedSandboxFile";
	}

	private void Awake()
	{
		if (GameTime.IsPaused())
		{
			GameTime.Pause(false);
		}
	}

	private void Start()
	{
		Singleton<GameManager>.Instance.OpenSandboxEpisode(this);
		if (!Singleton<BuildCustomizationLoader>.Instance.IsOdyssey && !Singleton<BuildCustomizationLoader>.Instance.IAPEnabled && Singleton<BuildCustomizationLoader>.Instance.CustomerID != "nook")
		{
			UnityEngine.Object.Destroy(GameObject.Find("SandboxButtonSpecialIAP"));
		}
	}

	public void LoadSandboxLevel(string identifier)
	{
		Singleton<GameManager>.Instance.LoadSandboxLevel(identifier, 0);
	}

	public void GoToEpisodeSelection()
	{
		Singleton<GameManager>.Instance.LoadEpisodeSelection(false);
	}

	public void OpenIAPPopup()
	{
		CompactEpisodeSelector episodeSelector = CompactEpisodeSelector.Instance;
		Action onClose = null;
		if (episodeSelector != null)
		{
			episodeSelector.gameObject.SetActive(false);
			onClose = delegate()
			{
				episodeSelector.gameObject.SetActive(true);
			};
		}
		Singleton<IapManager>.Instance.OpenShopPage(onClose, "FieldOfDreams");
	}

	public static string SANDBOX_BUNDLE = "Episode_Sandbox_Levels";

	public static string SANDBOX_BUNDLE_2 = "Episode_Sandbox_Levels_2";

	public SandboxLevels m_sandboxLevels;
}
