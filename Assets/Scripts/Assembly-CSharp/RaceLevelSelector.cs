using System.Collections.Generic;
using UnityEngine;

public class RaceLevelSelector : WPFMonoBehaviour
{
	public List<RaceLevels.LevelData> Levels
	{
		get
		{
			return this.m_raceLevels.Levels;
		}
	}

	public RaceLevels.LevelData FindLevel(string identifier)
	{
		return this.m_raceLevels.GetLevelData(identifier);
	}

	public string FindLevelFile(string identifier)
	{
		RaceLevels.LevelData levelData = this.m_raceLevels.GetLevelData(identifier);
		if (levelData != null)
		{
			return levelData.SceneName;
		}
		return "UndefinedRaceLevelFile";
	}

	private void OnEnable()
	{
		KeyListener.keyPressed += this.HandleKeyListenerkeyPressed;
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
		GameCenterManager.onAuthenticationSucceeded += this.ShowLeaderboardButton;
		IapManager.onPurchaseSucceeded += this.HandleIapManagerOnPurchaseSucceeded;
	}

	private void OnDisable()
	{
		KeyListener.keyPressed -= this.HandleKeyListenerkeyPressed;
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
		GameCenterManager.onAuthenticationSucceeded -= this.ShowLeaderboardButton;
		IapManager.onPurchaseSucceeded -= this.HandleIapManagerOnPurchaseSucceeded;
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
		Singleton<GameManager>.Instance.OpenRaceEpisode(this);
		this.ShowLeaderboardButton(false);
	}

	public void LoadRaceLevel(string identifier)
	{
		Singleton<GameManager>.Instance.LoadRaceLevel(identifier);
	}

	public void GoToEpisodeSelection()
	{
		Singleton<GameManager>.Instance.LoadEpisodeSelection(false);
	}

	public void ShowLeaderboardButton(bool show)
	{
		if (!Singleton<SocialGameManager>.IsInstantiated())
		{
			return;
		}
		Transform transform = base.transform.Find("LeaderboardButton");
		if (transform != null && transform.gameObject)
		{
			transform.gameObject.SetActive(show || Singleton<SocialGameManager>.Instance.Authenticated);
		}
	}

	public void OpenLeaderboard()
	{
		if (Singleton<SocialGameManager>.IsInstantiated())
		{
			Singleton<SocialGameManager>.Instance.ShowLeaderboardsView();
		}
	}

	public void ReceiveUIEvent(UIEvent data)
	{
		if (data.type == UIEvent.Type.OpenUnlockFullVersionIapMenu)
		{
			Singleton<IapManager>.Instance.EnableUnlockFullVersionPurchasePage();
		}
	}

	private void HandleKeyListenerkeyPressed(KeyCode obj)
	{
		if (obj == KeyCode.Escape)
		{
			this.GoToEpisodeSelection();
		}
	}

	private void HandleIapManagerOnPurchaseSucceeded(IapManager.InAppPurchaseItemType type)
	{
	}

	private const string RACELEVEL_BUNDLE = "Episode_Race_Levels";

	public RaceLevels m_raceLevels;

	public GameObject m_partialPageContentLimitedOverlay;
}
