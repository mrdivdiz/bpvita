using System;
using System.Collections.Generic;
using UnityEngine;

public class SandboxLevelButton : MonoBehaviour
{
	private void OnEnable()
	{
		if (this.m_sandboxSelector != null && this.m_sandboxIdentifier.Equals("S-F") && GameProgress.GetSandboxUnlocked(this.m_sandboxIdentifier))
		{
			UnlockSandboxSequence component = base.GetComponent<UnlockSandboxSequence>();
			GameProgress.ButtonUnlockState buttonUnlockState = GameProgress.GetButtonUnlockState("SandboxLevelButton_" + this.m_sandboxIdentifier);
			if (component == null && buttonUnlockState == GameProgress.ButtonUnlockState.Locked)
			{
				base.gameObject.AddComponent<UnlockSandboxSequence>();
			}
			Button component2 = base.GetComponent<Button>();
			component2.MethodToCall.SetMethod(this.m_sandboxSelector, "LoadSandboxLevel", this.m_sandboxIdentifier);
			string str = WPFMonoBehaviour.gameData.m_sandboxLevels.GetLevelData(this.m_sandboxIdentifier).m_starBoxCount.ToString();
			this.m_starsText.text = GameProgress.SandboxStarCount(this.m_sandboxSelector.FindLevelFile(this.m_sandboxIdentifier)).ToString() + "/" + str;
			for (int i = 0; i < this.hideOnContentUnlocked.Length; i++)
			{
				this.hideOnContentUnlocked[i].SetActive(false);
			}
			for (int j = 0; j < this.hideOnContentLocked.Length; j++)
			{
				this.hideOnContentLocked[j].SetActive(true);
			}
		}
	}

	private void Awake()
	{
		if (this.m_sandboxIdentifier.Equals("S-M"))
		{
			Transform transform = base.transform.Find("Price");
			if (transform != null)
			{
				this.priceLabels = transform.GetComponentsInChildren<TextMesh>();
				if (this.priceLabels != null && this.priceLabels.Length > 0)
				{
					for (int i = 0; i < this.priceLabels.Length; i++)
					{
						this.priceLabels[i].text = string.Empty;
					}
				}
			}
		}
	}

	private void Start()
	{
		if (this.isBigSandboxButton && base.transform.parent != null)
		{
			this.m_sandboxSelector = base.transform.parent.GetComponent<SandboxSelector>();
		}
		if (this.m_sandboxSelector == null && base.transform.parent != null && base.transform.parent.parent != null)
		{
			this.m_sandboxSelector = base.transform.parent.parent.GetComponent<SandboxSelector>();
		}
		this.starSet = base.transform.Find("StarSet");
		if (this.starSet != null && !this.isBigSandboxButton)
		{
			this.starSet.parent = base.transform.parent;
		}
		UnlockSandboxSequence component = base.GetComponent<UnlockSandboxSequence>();
		bool flag = GameProgress.GetSandboxUnlocked(this.m_sandboxIdentifier);
		bool isOdyssey = Singleton<BuildCustomizationLoader>.Instance.IsOdyssey;
		if (isOdyssey && (this.m_sandboxIdentifier.Equals("S-M") || this.m_sandboxIdentifier.Equals("S-F")))
		{
			flag = true;
		}
		if (!flag && this.m_sandboxIdentifier.Equals("S-M"))
		{
			UnityEngine.Debug.LogError("SandboxLevelButton S-M");
			int cost = this.GetUnlockPrice(this.m_sandboxIdentifier);
			this.AddSMSandboxUnlockDialog(base.GetComponent<Button>(), cost, this.m_sandboxIdentifier, () => GameProgress.SnoutCoinCount() >= cost);
		}
		else if (!flag && this.m_sandboxIdentifier.Equals("S-F"))
		{
			this.AddBuyFieldOfDreamsButton(base.GetComponent<Button>());
		}
		else if (!flag && !isOdyssey)
		{
			if (SandboxLevelButton.sandboxUnlockDialog == null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Singleton<GameManager>.Instance.gameData.m_sandboxUnlockDialog);
				gameObject.transform.position = new Vector3(0f, 0f, -10f);
				SandboxLevelButton.sandboxUnlockDialog = gameObject.GetComponent<SandboxUnlockDialog>();
				SandboxLevelButton.sandboxUnlockDialog.Close();
			}
			int cost = this.GetUnlockPrice(this.m_sandboxIdentifier);
			this.AddSandboxUnlockDialog(base.GetComponent<Button>(), SandboxLevelButton.sandboxUnlockDialog, this.m_sandboxIdentifier, cost, () => GameProgress.SnoutCoinCount() >= cost);
		}
		else if (!flag && isOdyssey)
		{
			TooltipInfo component2 = base.GetComponent<TooltipInfo>();
			if (component2 != null)
			{
				this.setTooltipButton = base.GetComponent<Button>();
				this.setTooltipButton.MethodToCall.SetMethod(component2, "Show");
			}
		}
		GameProgress.ButtonUnlockState buttonUnlockState = GameProgress.GetButtonUnlockState("SandboxLevelButton_" + this.m_sandboxIdentifier);
		if (flag)
		{
			if (component == null && buttonUnlockState == GameProgress.ButtonUnlockState.Locked)
			{
				base.gameObject.AddComponent<UnlockSandboxSequence>();
			}
			Button component3 = base.GetComponent<Button>();
			component3.MethodToCall.SetMethod(this.m_sandboxSelector, "LoadSandboxLevel", this.m_sandboxIdentifier);
			string str = WPFMonoBehaviour.gameData.m_sandboxLevels.GetLevelData(this.m_sandboxIdentifier).m_starBoxCount.ToString();
			this.m_starsText.text = GameProgress.SandboxStarCount(this.m_sandboxSelector.FindLevelFile(this.m_sandboxIdentifier)).ToString() + "/" + str;
			for (int i = 0; i < this.hideOnContentUnlocked.Length; i++)
			{
				this.hideOnContentUnlocked[i].SetActive(false);
			}
		}
		else if (!flag && this.m_starsText != null)
		{
			string arg = WPFMonoBehaviour.gameData.m_sandboxLevels.GetLevelData(this.m_sandboxIdentifier).m_starBoxCount.ToString();
			this.m_starsText.text = string.Format("{0}/{1}", 0, arg);
			for (int j = 0; j < this.hideOnContentLocked.Length; j++)
			{
				this.hideOnContentLocked[j].SetActive(false);
			}
		}
	}

	private void Update()
	{
		if (this.setTooltipButton != null)
		{
			this.setTooltipButton.Lock(false);
		}
	}

	private void AddSMSandboxUnlockDialog(Button button, int cost, string levelIdentifier, Func<bool> requirements)
	{
		GameData gameData = Singleton<GameManager>.Instance.gameData;
		if (gameData.m_lpaUnlockDialog != null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(gameData.m_lpaUnlockDialog);
			TextDialog dialog = gameObject.GetComponent<TextDialog>();
			gameObject.transform.position = new Vector3(0f, 0f, -10f);
			button.MethodToCall.SetMethod(dialog, "Open");
			dialog.ConfirmButtonText = string.Format("[snout] {0}", cost);
			dialog.Close();
			dialog.ShowConfirmEnabled = (() => true);
			dialog.SetOnConfirm(delegate
			{
				if (!GameProgress.GetSandboxUnlocked(levelIdentifier) && requirements() && GameProgress.UseSnoutCoins(cost))
				{
					GameProgress.SetSandboxUnlocked(levelIdentifier, true);
					GameProgress.SetButtonUnlockState("SandboxLevelButton_" + levelIdentifier, GameProgress.ButtonUnlockState.Locked);
					Singleton<GameManager>.Instance.ReloadCurrentLevel(true);
					this.ReportUnlockSandbox(cost, levelIdentifier);
					UnityEngine.Object.DontDestroyOnLoad(Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinUse));
				}
				else if (!requirements() && Singleton<IapManager>.IsInstantiated())
				{
					dialog.Close();
					Singleton<IapManager>.Instance.OpenShopPage(new Action(dialog.Open), "SnoutCoinShop");
				}
				else
				{
					dialog.Close();
				}
			});
		}
		if (this.priceLabels != null && this.priceLabels.Length > 0)
		{
			string text = string.Format("[snout] {0}", cost);
			for (int i = 0; i < this.priceLabels.Length; i++)
			{
				this.priceLabels[i].text = text;
				TextMeshSpriteIcons.EnsureSpriteIcon(this.priceLabels[i]);
			}
		}
	}

	private void AddSandboxUnlockDialog(Button button, SandboxUnlockDialog dialog, string levelIdentifier, int price, Func<bool> requirements)
	{
		button.MethodToCall.SetMethod(this, "OpenSandboxUnlockDialog");
		this.onOpenUnlockDialog = delegate()
		{
			dialog.SandboxIdentifier = levelIdentifier;
			dialog.Cost = price;
			dialog.ShowConfirmEnabled = requirements;
			dialog.SetOnConfirm(delegate
			{
				if (!GameProgress.GetSandboxUnlocked(levelIdentifier) && requirements() && GameProgress.UseSnoutCoins(price))
				{
					GameProgress.SetSandboxUnlocked(levelIdentifier, true);
					GameProgress.SetButtonUnlockState("SandboxLevelButton_" + levelIdentifier, GameProgress.ButtonUnlockState.Locked);
					Singleton<GameManager>.Instance.ReloadCurrentLevel(true);
					this.ReportUnlockSandbox(price, levelIdentifier);
					EventManager.Connect(new EventManager.OnEvent<LevelLoadedEvent>(this.DelayedPurchaseSound));
				}
				else if (!requirements() && Singleton<IapManager>.IsInstantiated())
				{
					dialog.Close();
					Singleton<IapManager>.Instance.OpenShopPage(new Action(dialog.Open), "SnoutCoinShop");
				}
				else
				{
					dialog.Close();
				}
			});
		};
	}

	private void DelayedPurchaseSound(LevelLoadedEvent data)
	{
		EventManager.Disconnect(new EventManager.OnEvent<LevelLoadedEvent>(this.DelayedPurchaseSound));
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinUse);
	}

	private void ReportUnlockSandbox(int cost, string levelIdentifier)
	{
	}

	private void AddBuyFieldOfDreamsButton(Button button)
	{
		this.episodeSelector = GameObject.Find("EpisodeSelector");
		button.MethodToCall.SetMethod(this, "OpenFieldOfDreamsShopPage");
		button.Lock(false);
	}

	public void OpenSandboxUnlockDialog()
	{
		if (this.onOpenUnlockDialog != null)
		{
			this.onOpenUnlockDialog();
		}
		if (SandboxLevelButton.sandboxUnlockDialog != null)
		{
			SandboxLevelButton.sandboxUnlockDialog.Open();
		}
	}

	public void OpenFieldOfDreamsShopPage()
	{
		if (Singleton<IapManager>.Instance != null)
		{
			this.episodeSelector.SetActive(false);
			Singleton<IapManager>.Instance.OpenShopPage(delegate
			{
				this.episodeSelector.SetActive(true);
			}, "FieldOfDreams");
		}
	}

	private int GetUnlockPrice(string identifier)
	{
		if (Singleton<IapManager>.Instance == null)
		{
			return int.MaxValue;
		}
		switch (identifier)
		{
		case "S-1":
		case "S-3":
		case "S-5":
		case "S-7":
		case "S-9":
			return Singleton<VirtualCatalogManager>.Instance.GetProductPrice("sandbox_normal_first_unlock");
		case "S-2":
		case "S-4":
		case "S-6":
		case "S-8":
		case "S-10":
			return Singleton<VirtualCatalogManager>.Instance.GetProductPrice("sandbox_normal_second_unlock");
		case "S-M":
			return Singleton<VirtualCatalogManager>.Instance.GetProductPrice("sandbox_lpa_unlock");
		}
		return int.MaxValue;
	}

	public string m_sandboxIdentifier;

	[SerializeField]
	private SandboxSelector m_sandboxSelector;

	[SerializeField]
	private TextMesh m_starsText;

	[SerializeField]
	public bool isBigSandboxButton;

	[SerializeField]
	private GameObject[] hideOnContentLocked;

	[SerializeField]
	private GameObject[] hideOnContentUnlocked;

	private Action onOpenUnlockDialog;

	private Transform starSet;

	private GameObject episodeSelector;

	private static SandboxUnlockDialog sandboxUnlockDialog;

	private Button setTooltipButton;

	private TextMesh[] priceLabels;
}
