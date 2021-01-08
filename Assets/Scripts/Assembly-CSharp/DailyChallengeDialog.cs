using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DailyChallengeDialog : WPFMonoBehaviour
{
	private static Vector3 DefaultPosition
	{
		get
		{
			if (WPFMonoBehaviour.hudCamera)
			{
				return WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 10f;
			}
			return Vector3.zero;
		}
	}

	public static bool DialogOpen
	{
		get
		{
			return DailyChallengeDialog.s_dialogOpen;
		}
	}

	private void Awake()
	{
		DailyChallengeDialog.instance = this;
		this.localizer = new RefreshLocalizer(base.transform.Find("TimeLeft/Text").GetComponent<TextMesh>());
		this.localizer.Update = (() => string.Format("{0}h {1}m", Singleton<DailyChallenge>.Instance.DailyChallengeTimeLeft.Hours, Singleton<DailyChallenge>.Instance.DailyChallengeTimeLeft.Minutes));
		UnityEngine.Object.DontDestroyOnLoad(this);
		SceneManager.sceneLoaded += this.OnSceneLoaded;
	}

	private void OnEnable()
	{
		Singleton<GuiManager>.Instance.GrabPointer(this);
		Singleton<KeyListener>.Instance.GrabFocus(this);
		KeyListener.keyReleased += this.HandleKeyRelease;
		EventManager.Send(new UIEvent(UIEvent.Type.OpenedDailyChallengeDialog));
		base.StartCoroutine(this.UpdateTimeLeft());
		DailyChallengeDialog.s_dialogOpen = true;
	}

	private void OnDisable()
	{
		if (Singleton<GuiManager>.IsInstantiated())
		{
			Singleton<GuiManager>.Instance.ReleasePointer(this);
		}
		if (Singleton<KeyListener>.IsInstantiated())
		{
			Singleton<KeyListener>.Instance.ReleaseFocus(this);
		}
		EventManager.Send(new UIEvent(UIEvent.Type.ClosedDailyChallengeDialog));
		KeyListener.keyReleased -= this.HandleKeyRelease;
		DailyChallengeDialog.s_dialogOpen = false;
	}

	private void HandleKeyRelease(KeyCode key)
	{
		if (key == KeyCode.Escape)
		{
			this.Close();
		}
	}

	private void OnDestroy()
	{
		this.localizer.Dispose();
		SceneManager.sceneLoaded -= this.OnSceneLoaded;
	}

	public static DailyChallengeDialog Create()
	{
		if (DailyChallengeDialog.instance)
		{
			return DailyChallengeDialog.instance;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_dailyChallengeDialog);
		gameObject.transform.position = DailyChallengeDialog.DefaultPosition;
		return DailyChallengeDialog.instance;
	}

	public void Open()
	{
		base.gameObject.SetActive(true);
	}

	public void Open(Dialog.OnClose OnClose)
	{
		this.OnClose = (Dialog.OnClose)Delegate.Combine(this.OnClose, OnClose);
		base.gameObject.SetActive(true);
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
		if (this.OnClose != null)
		{
			this.OnClose();
			this.OnClose = null;
		}
	}

	public void OpenChallengeLevel(int index)
	{
		if (!Singleton<DailyChallenge>.Instance.Initialized)
		{
			return;
		}
		if (index < 0 || index >= Singleton<DailyChallenge>.Instance.Count)
		{
			return;
		}
		int levelIndex = Singleton<DailyChallenge>.Instance.Challenges[index].levelIndex;
		int episodeIndex = Singleton<DailyChallenge>.Instance.Challenges[index].episodeIndex;
		if (Singleton<GameManager>.Instance.IsInGame() && levelIndex == Singleton<GameManager>.Instance.CurrentLevel && episodeIndex == Singleton<GameManager>.Instance.CurrentEpisodeIndex)
		{
			this.Close();
			WPFMonoBehaviour.levelManager.SetGameState(LevelManager.GameState.Continue);
			return;
		}
		int page = (levelIndex <= 14) ? 1 : ((levelIndex <= 29) ? 2 : 3);
		if (LevelInfo.IsLevelUnlocked(episodeIndex, levelIndex))
		{
			BackgroundMask.SetParent(base.transform);
			Singleton<GameManager>.Instance.LoadLevelSelectionAndLevel(DailyChallengeDialog.LevelSelectionPages[episodeIndex], levelIndex);
			this.OnGameLevelLoaded = (Action)Delegate.Combine(this.OnGameLevelLoaded, new Action(delegate()
			{
				BackgroundMask.SetParent(null);
				this.gameObject.SetActive(false);
			}));
		}
		else
		{
			Singleton<GameManager>.Instance.LoadLevelSelection(DailyChallengeDialog.LevelSelectionPages[episodeIndex], true);
			this.OnSceneWasLoaded = (Action)Delegate.Combine(this.OnSceneWasLoaded, new Action(delegate()
			{
				this.gameObject.SetActive(false);
				if (!WPFMonoBehaviour.levelSelector)
				{
					return;
				}
				if (WPFMonoBehaviour.levelSelector.CurrentPage > page)
				{
					for (int i = 0; i < WPFMonoBehaviour.levelSelector.CurrentPage - page; i++)
					{
						WPFMonoBehaviour.levelSelector.PreviousPage();
					}
				}
				else if (WPFMonoBehaviour.levelSelector.CurrentPage < page)
				{
					for (int j = 0; j < page - WPFMonoBehaviour.levelSelector.CurrentPage; j++)
					{
						WPFMonoBehaviour.levelSelector.NextPage();
					}
				}
			}));
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		base.transform.position = DailyChallengeDialog.DefaultPosition;
		if (this.OnSceneWasLoaded != null)
		{
			this.OnSceneWasLoaded();
			this.OnSceneWasLoaded = null;
		}
		if (Singleton<GameManager>.Instance.IsInGame() && this.OnGameLevelLoaded != null)
		{
			this.OnGameLevelLoaded();
			this.OnGameLevelLoaded = null;
		}
	}

	public void ChangeLootCrate()
	{
		LootCrateType lootCrateType = Singleton<DailyChallenge>.Instance.TodaysLootCrate(0);
		if (lootCrateType != LootCrateType.Wood)
		{
			if (lootCrateType != LootCrateType.Metal)
			{
				if (lootCrateType == LootCrateType.Gold)
				{
					Singleton<DailyChallenge>.Instance.SetDailyLootCrate(LootCrateType.Wood);
				}
			}
			else
			{
				Singleton<DailyChallenge>.Instance.SetDailyLootCrate(LootCrateType.Gold);
			}
		}
		else
		{
			Singleton<DailyChallenge>.Instance.SetDailyLootCrate(LootCrateType.Metal);
		}
	}

	public void ChangeDays()
	{
		for (int i = 0; i < Singleton<DailyChallenge>.Instance.Count; i++)
		{
			this.ChangeDay(i);
		}
	}

	public void ChangeDay(int index)
	{
		if (index < 0 || index >= Singleton<DailyChallenge>.Instance.Count)
		{
			return;
		}
		int num = Singleton<DailyChallenge>.Instance.Challenges[index].levelIndex;
		int num2 = Singleton<DailyChallenge>.Instance.Challenges[index].episodeIndex;
		if (++num >= LevelInfo.GetLevelNames(num2).Count)
		{
			num = 0;
			num2 = ((num2 < 5) ? (num2 + 1) : 0);
			Singleton<DailyChallenge>.Instance.SetDailyChallenge(index, num2, num);
		}
		else
		{
			Singleton<DailyChallenge>.Instance.SetDailyChallenge(index, num2, num);
		}
	}

	private IEnumerator UpdateTimeLeft()
	{
		this.localizer.Target.gameObject.SetActive(false);
		while ((!Singleton<DailyChallenge>.IsInstantiated() || !Singleton<DailyChallenge>.Instance.Initialized) && base.gameObject.activeInHierarchy)
		{
			yield return null;
		}
		this.localizer.Target.gameObject.SetActive(true);
		while (Singleton<DailyChallenge>.Instance.HasChallenge && base.gameObject.activeInHierarchy)
		{
			TimeSpan ts = Singleton<DailyChallenge>.Instance.DailyChallengeTimeLeft;
			if (this.NeedsUpdate(ts))
			{
				this.localizer.Refresh();
			}
			yield return null;
		}
		yield break;
	}

	private bool NeedsUpdate(TimeSpan time)
	{
		bool result = time.Hours != this.prevHour || time.Minutes != this.prevMinutes;
		this.prevHour = time.Hours;
		this.prevMinutes = time.Minutes;
		return result;
	}

	public void OpenLootCrateShop()
	{
		if (Singleton<BuildCustomizationLoader>.Instance.IAPEnabled)
		{
			if (WPFMonoBehaviour.levelManager == null && CompactEpisodeSelector.Instance != null)
			{
				CompactEpisodeSelector.Instance.gameObject.SetActive(false);
				base.gameObject.SetActive(false);
				Singleton<IapManager>.Instance.GetShop().Open(delegate
				{
					CompactEpisodeSelector.Instance.gameObject.SetActive(true);
					base.gameObject.SetActive(true);
				}, "LootCrates");
			}
			else
			{
				base.gameObject.SetActive(false);
				Singleton<IapManager>.Instance.GetShop().Open(delegate
				{
					base.gameObject.SetActive(true);
				}, "LootCrates");
			}
		}
	}

	[SerializeField]
	private AnimationCurve ribbonCurve;

	[SerializeField]
	private float ribbonAnimTime;

	[SerializeField]
	private GameObject ribbon;

	private int prevHour = -1;

	private int prevMinutes = -1;

	private string timeLeftlocalizationKey;

	private static bool s_dialogOpen;

	private RefreshLocalizer localizer;

	private Dialog.OnClose OnClose;

	private static DailyChallengeDialog instance;

	private Action OnSceneWasLoaded;

	private Action OnGameLevelLoaded;

	private static readonly string[] LevelSelectionPages = new string[]
	{
		"Episode1LevelSelection",
		"Episode3LevelSelection",
		"Episode4LevelSelection",
		"Episode2LevelSelection",
		"Episode5LevelSelection",
		"Episode6LevelSelection"
	};
}
