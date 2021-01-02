using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	private bool CakeRaceIntroShown
	{
		get
		{
			return GameProgress.GetBool("CakeRaceIntroShown", false, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetBool("CakeRaceIntroShown", value, GameProgress.Location.Local);
		}
	}

	private void Awake()
	{
		MainMenu.isGameHallExitOpened = false;
		this.shopButton = GameObject.Find("MainShopButton");
		this.m_crossPromotionOverlay = UnityEngine.Object.Instantiate<GameObject>(this.m_crossPromotionOverlay);
		this.m_crossPromotionOverlay.SetActive(false);
		if (this.m_settingsPopup != null)
		{
			this.m_settingsPopup.SetActive(false);
		}
		if (Singleton<BuildCustomizationLoader>.Instance.IAPEnabled)
		{
			if (GameProgress.GetSandboxUnlocked("S-F"))
			{
				this.m_iapButton.SetActive(false);
			}
		}
		else
		{
			this.m_iapButton.SetActive(false);
		}
		AnimatedButton animatedButton = this.cakeRaceButton;
		animatedButton.OnOpenAnimationEvent = (Action<Spine.Event>)Delegate.Combine(animatedButton.OnOpenAnimationEvent, new Action<Spine.Event>(this.OnCakeRaceUnlockAnimationEvent));
		HatchManager.onLoginSuccess = (Action)Delegate.Combine(HatchManager.onLoginSuccess, new Action(this.HideLockScreen));
		HatchManager.onLoginFailed = (Action)Delegate.Combine(HatchManager.onLoginFailed, new Action(this.HideLockScreen));
		HatchManager.onLogout = (Action)Delegate.Combine(HatchManager.onLogout, new Action(this.LoggedOut));
	}

	private void HideLockScreen()
	{
		this.lockScreen.SetActive(false);
	}

	private void LoggedOut()
	{
		this.lockScreen.SetActive(true);
		this.lockScreen.transform.position = WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 0.5f;
	}

	private void CheckRewardCallback(string rewardData)
	{
		RewardPigRescuePopup.ProcessReward(rewardData);
		if (RewardPigRescuePopup.HasRewardPending)
		{
			this.ShowRewardPopup();
		}
	}

	private void ShowRewardPopup()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_pigRescueRewardPrefab);
		gameObject.transform.position = -Vector3.forward * 20f;
	}

	private void OnEnable()
	{
		KeyListener.keyReleased += this.HandleKeyListenerKeyReleased;
		if (GameProgress.HasKey("CakeRaceUnlockShown", GameProgress.Location.Local, null) && !GameProgress.GetBool("CakeRaceUnlockShown", false, GameProgress.Location.Local, null))
		{
			this.ForceCakeRaceButton();
		}
	}

	private void OnDisable()
	{
		KeyListener.keyReleased -= this.HandleKeyListenerKeyReleased;
	}

	public bool IsUserInMainMenu()
	{
		if (!this.mainMenuNode.activeInHierarchy)
		{
			return false;
		}
		GameObject gameObject = GameObject.Find("StartButton");
		Vector3 position = gameObject.transform.position;
		Vector3 position2 = Singleton<GuiManager>.Instance.FindCamera().transform.position;
		RaycastHit raycastHit;
		return Physics.Raycast(position2, (position - position2) * 1.1f, out raycastHit) && raycastHit.collider.gameObject == gameObject;
	}

	private void HandleKeyListenerKeyReleased(KeyCode keyCode)
	{
		if (keyCode == KeyCode.Escape)
		{
			if (this.m_crossPromotionOverlay != null && this.m_crossPromotionOverlay.activeInHierarchy)
			{
				this.m_crossPromotionOverlay.GetComponent<CrossPromotionOverlay>().CloseDialog();
			}
			else if (this.creditsMenuInstance != null && this.creditsMenuInstance.activeInHierarchy)
			{
				this.CloseCredits();
			}
			else if (this.m_confirmationPopup != null && this.m_confirmationPopup.activeInHierarchy)
			{
				this.m_confirmationPopup.GetComponent<ConfirmationPopup>().DismissDialog();
			}
			else if (Singleton<SocialGameManager>.IsInstantiated() && Singleton<SocialGameManager>.Instance.ViewsActive())
			{
				Singleton<SocialGameManager>.Instance.CloseViews();
			}
			else if (this.mainMenuNode != null && this.mainMenuNode.activeInHierarchy)
			{
				this.OpenConfirmationPopup();
			}
		}
		if (keyCode == KeyCode.Return && this.m_confirmationPopup != null && this.m_confirmationPopup.activeInHierarchy)
		{
			Application.Quit();
		}
	}

	private void ShowGameCenterButton(bool show)
	{
		if (this.gcButton)
		{
			bool enabled = this.gcButton.GetComponent<Collider>().enabled;
			if (show)
			{
				this.gcButton.SetActive(DeviceInfo.ActiveDeviceFamily == DeviceInfo.DeviceFamily.Ios);
			}
			this.gcButton.GetComponent<Renderer>().enabled = (show || Singleton<SocialGameManager>.Instance.Authenticated);
			this.gcButton.GetComponent<Collider>().enabled = (show || Singleton<SocialGameManager>.Instance.Authenticated);
			if (enabled != this.gcButton.GetComponent<Collider>().enabled)
			{
				GameObject gameObject = GameObject.Find("InfoButtons");
				if (gameObject != null && this.bInfoButtonsOut)
				{
					gameObject.GetComponent<Animation>().Play();
				}
			}
		}
	}

	private void InitButtons(DeviceInfo.DeviceFamily platform)
	{
		GameObject gameObject = GameObject.Find("HDBadge");
		if (gameObject != null)
		{
			gameObject.SetActive(Singleton<BuildCustomizationLoader>.Instance.IsHDVersion && platform != DeviceInfo.DeviceFamily.Pc);
		}
		if (Singleton<SocialGameManager>.IsInstantiated())
		{
			this.ShowGameCenterButton(Singleton<SocialGameManager>.Instance.Authenticated);
		}
		if (this.shopButton)
		{
			this.shopButton.SetActive(Singleton<BuildCustomizationLoader>.Instance.IAPEnabled);
		}
	}

	private void OnDestroy()
	{
		GameCenterManager.onAuthenticationSucceeded -= this.ShowGameCenterButton;
		HatchManager.onLoginSuccess = (Action)Delegate.Remove(HatchManager.onLoginSuccess, new Action(this.HideLockScreen));
		HatchManager.onLoginFailed = (Action)Delegate.Remove(HatchManager.onLoginFailed, new Action(this.HideLockScreen));
		HatchManager.onLogout = (Action)Delegate.Remove(HatchManager.onLogout, new Action(this.LoggedOut));
	}

	private void Start()
	{
		this.gcButton = GameObject.Find("GameCenterButton");
		GameCenterManager.onAuthenticationSucceeded += this.ShowGameCenterButton;
		EventManager.Connect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
		this.creditsMenuInstance = UnityEngine.Object.Instantiate<GameObject>(this.creditsMenu);
		this.creditsMenuInstance.SetActive(false);
		this.InitButtons(DeviceInfo.ActiveDeviceFamily);
		if (!HatchManager.IsInitialized || DeviceInfo.ActiveDeviceFamily == DeviceInfo.DeviceFamily.WP8)
		{
			Transform transform = this.mainMenuNode.transform.FindChildRecursively("ToonsTvLayout");
			Transform transform2 = transform.Find("ToonsButton");
			Transform transform3 = transform.Find("RuffleButton");
			transform2.gameObject.SetActive(false);
			transform3.gameObject.SetActive(false);
			transform.GetComponent<FlowLayout>().Layout();
		}
	}

	private void OnPlayerChanged(PlayerChangedEvent data)
	{
		if (this.creditsMenuInstance != null)
		{
			UnityEngine.Object.Destroy(this.creditsMenuInstance);
		}
		this.creditsMenuInstance = UnityEngine.Object.Instantiate<GameObject>(this.creditsMenu);
		this.creditsMenuInstance.SetActive(false);
	}

	private void OnUpdateButtonPressed()
	{
		Singleton<URLManager>.Instance.OpenURL(URLManager.LinkType.BadPiggiesAppStore);
		Application.Quit();
	}

	public void OnToonsNewContentAvailable(int numOfNewItems)
	{
		string text = numOfNewItems.ToString();
		Transform transform = this.mainMenuNode.transform.FindChildRecursively("ToonsButton");
		Transform transform2 = transform.Find("Badge");
		if (transform != null)
		{
			TextMesh component = transform2.Find("Count").GetComponent<TextMesh>();
			component.text = text;
			TextMesh component2 = transform2.Find("CountShadow").GetComponent<TextMesh>();
			component2.text = text;
			transform2.GetComponent<Panel>().width = 2 + ((text.Length <= 2) ? 0 : (text.Length / 2));
			transform2.gameObject.SetActive(numOfNewItems > 0);
		}
	}

	public void ConnectShopToRestoreConfirmButton(Shop shop)
	{
		if (this.m_confirmationIAPRestoreSettingsButton != null)
		{
			this.m_confirmationIAPRestoreSettingsButton.MethodToCall.SetMethod(shop, "RestorePurchasedItems");
		}
	}

	public void OpenSandboxIAP()
	{
		Singleton<GameManager>.Instance.LoadSandboxLevelSelectionAndOpenIapMenu();
	}

	public void OpenUnlockFullVersionIAP()
	{
		Singleton<IapManager>.Instance.EnableUnlockFullVersionPurchasePage();
	}

	public void OpenLevelMenu()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		this.SendStartFlurryEvent();
		Singleton<GameManager>.Instance.LoadEpisodeSelection(false);
	}

	public void OpenCakeRaceMenu()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		if (this.cakeRaceRequirement.IsLocked)
		{
			if (this.cakeRaceLockedDialog == null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_cakeRaceLockedPopup);
				gameObject.transform.position = WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 2f;
				this.cakeRaceLockedDialog = gameObject.GetComponent<CakeRaceLockedDialog>();
			}
			this.cakeRaceLockedDialog.Open();
			this.cakeRaceLockedDialog.SetLevelRequirement(this.cakeRaceRequirement.RequiredLevel);
		}
		else if (this.CakeRaceIntroShown)
		{
			Singleton<GameManager>.Instance.LoadCakeRaceMenu(false);
		}
		else if (!this.CakeRaceIntroShown)
		{
			this.CakeRaceIntroShown = true;
			Singleton<Loader>.Instance.LoadLevel("CakeRaceIntro", GameManager.GameState.Cutscene, true, true);
		}
	}

	[ContextMenu("Show cake race unlock")]
	public void ForceCakeRaceButton()
	{
		this.cakeRaceLockScreen.SetActive(true);
		this.cakeRaceButton.transform.parent = null;
		this.cakeRaceButton.transform.position = new Vector3(this.cakeRaceButton.transform.position.x, this.cakeRaceButton.transform.position.y, this.cakeRaceLockScreen.transform.position.z - 1f);
		this.UnlockCakeRaceButton();
		this.CreateCakeRaceButtonTutorial();
	}

	public void UnlockCakeRaceButton()
	{
		this.cakeRaceButton.UnlockSequence(true);
	}

	private void OnCakeRaceUnlockAnimationEvent(Spine.Event e)
	{
		string name = e.Data.Name;
		if (name != null)
		{
			if (name == "LockBreak")
			{
				Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.jokerLevelUnlocked);
			}
		}
	}

	private void CreateCakeRaceButtonTutorial()
	{
		GameObject pointer = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_tutorialPointer);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_tutorialPointerClick);
		gameObject.SetActive(false);
		Tutorial.Pointer pointer2 = new Tutorial.Pointer(pointer, gameObject);
		Tutorial.PointerTimeLine pointerTimeLine = new Tutorial.PointerTimeLine(pointer2);
		List<Vector3> list = new List<Vector3>();
		list.Add(this.cakeRaceButton.transform.position + 21f * Vector3.down + Vector3.back);
		list.Add(this.cakeRaceButton.transform.position + 5f * Vector3.up + Vector3.back);
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.1f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Move(list, 2.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Press());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Release());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.75f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Hide());
		base.StartCoroutine(this.UpdateTimeline(pointerTimeLine));
	}

	private IEnumerator UpdateTimeline(Tutorial.PointerTimeLine timeline)
	{
		timeline.Start();
		for (;;)
		{
			if (timeline.IsFinished())
			{
				timeline.Start();
			}
			timeline.Update();
			yield return null;
		}
		yield break;
	}

	public void CloseCredits()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		this.mainMenuNode.SetActive(true);
		this.creditsMenuInstance.SetActive(false);
		if (Singleton<SocialGameManager>.IsInstantiated())
		{
			this.ShowGameCenterButton(Singleton<SocialGameManager>.Instance.Authenticated);
		}
	}

	public void OpenCredits()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		this.m_settingsPopup.SetActive(false);
		this.mainMenuNode.SetActive(false);
		this.creditsMenuInstance.SetActive(true);
	}

	public void OpenGameCenter()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		if (DeviceInfo.ActiveDeviceFamily == DeviceInfo.DeviceFamily.Ios)
		{
			if (Singleton<SocialGameManager>.Instance.Authenticated)
			{
				Singleton<SocialGameManager>.Instance.ShowAchievementsView();
			}
			else
			{
				Singleton<SocialGameManager>.Instance.Authenticate();
			}
		}
	}

	public void SocialButtonReset()
	{
		if (this.m_socialButton != null)
		{
			Transform transform = this.m_socialButton.transform.Find("BackgroundSocialBtn");
			if (this.m_socialButton && transform)
			{
				transform.Find("Arrow").localRotation = Quaternion.identity;
				this.bSocialButtonsOut = false;
				this.m_socialButton.GetComponent<Animation>().Stop();
				this.m_socialButton.GetComponent<Animation>().Rewind();
				transform.GetComponent<Animation>().Stop();
				transform.GetComponent<Animation>().Rewind();
			}
		}
	}

	public void SocialButtonpressed()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		GameObject gameObject = GameObject.Find("SocialButton");
		GameObject gameObject2 = GameObject.Find("BackgroundSocialBtn");
		if (gameObject.GetComponent<Animation>().isPlaying)
		{
			return;
		}
		bool reverse = this.bSocialButtonsOut;
		this.InitAnimationStates(reverse, new AnimationState[]
		{
			gameObject.GetComponent<Animation>()["SocialButtonSlide"],
			gameObject2.GetComponent<Animation>()["MainMenuArrowAnimation"]
		});
		gameObject2.GetComponent<Animation>().Play();
		gameObject.GetComponent<Animation>().Play();
		this.bSocialButtonsOut = !this.bSocialButtonsOut;
	}

	private void InitAnimationStates(bool reverse, params AnimationState[] states)
	{
		foreach (AnimationState animationState in states)
		{
			animationState.speed = (float)((!reverse) ? 1 : -1);
			animationState.time = ((!reverse) ? 0f : animationState.length);
		}
	}

	public void LaunchFacebook()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		Singleton<URLManager>.Instance.OpenURL(URLManager.LinkType.Facebook);
	}

	public void LaunchRenren()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		Singleton<URLManager>.Instance.OpenURL(URLManager.LinkType.Renren);
	}

	public void LaunchWeibos()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		Singleton<URLManager>.Instance.OpenURL(URLManager.LinkType.Weibos);
	}

	public void LaunchYoutubeFilm()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		Singleton<URLManager>.Instance.OpenURL(URLManager.LinkType.Youtube);
	}

	public void LaunchYoutubeFilmChina()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		Singleton<URLManager>.Instance.OpenURL(URLManager.LinkType.YoutubeChina);
	}

	public void LaunchTwitter()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		Singleton<URLManager>.Instance.OpenURL(URLManager.LinkType.Twitter);
	}

	public void LaunchMoreGames()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		Application.OpenURL("http://wapgame.189.cn");
	}

	public void ShowAboutScreen()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		GameObject original = Resources.Load("UI/AboutPage", typeof(GameObject)) as GameObject;
		UnityEngine.Object.Instantiate<GameObject>(original);
	}

	public void OpenShop()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
        if (Singleton<BuildCustomizationLoader>.Instance.IAPEnabled)
        {
            if (this.gearButtonAnimation != null && this.gearButtonAnimation.isPlaying)
            {
                return;
            }
            this.mainMenuNode.SetActive(false);
            Singleton<IapManager>.Instance.OpenShopPage(delegate
            {
                this.mainMenuNode.SetActive(true);
            }, null);
        }
    }

	public void OpenRovioProductsOverlay()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		this.m_crossPromotionOverlay.SetActive(true);
	}

	public void OpenToons()
	{
		if (MainMenu.isGameHallExitOpened)
		{
			return;
		}
		Application.OpenURL("https://www.youtube.com/user/RovioMobile");
	}

	public void OpenGamesVideoChannel()
	{
	}

	public void RestoreIAP()
	{
		Singleton<IapManager>.Instance.RestorePurchasedItems();
	}

	public void OpenConfirmationPopup()
	{
		this.m_confirmationPopup.SetActive(true);
	}

	public void SetFullscreen()
	{
		Singleton<GuiManager>.Instance.SetFullscreen();
	}

	public void SendStartFlurryEvent()
	{
	}

	private void OnApplicationFocus(bool focus)
	{
		if (focus && MainMenu.isGameHallExitOpened)
		{
			MainMenu.isGameHallExitOpened = false;
		}
	}

	private void OnApplicationPause(bool paused)
	{
		if (Singleton<SocialGameManager>.IsInstantiated())
		{
			if (paused)
			{
				this.ShowGameCenterButton(false);
			}
			else if (!paused)
			{
				this.ShowGameCenterButton(Singleton<SocialGameManager>.Instance.Authenticated);
			}
		}
	}

	[SerializeField]
	private GameObject mainMenuNode;

	[SerializeField]
	private GameObject creditsMenu;

	private GameObject creditsMenuInstance;

	[SerializeField]
	private GameObject m_confirmationPopup;

	[SerializeField]
	private GameObject m_PromoPopupPrefab;

	[SerializeField]
	private GameObject m_ShopDialog;

	[SerializeField]
	private GameObject m_ToonsDialog;

	[SerializeField]
	private GameObject m_settingsPopup;

	[SerializeField]
	private GameObject m_pigRescueRewardPrefab;

	[SerializeField]
	private GameObject m_crossPromotionOverlay;

	[SerializeField]
	private Button m_confirmationIAPRestoreSettingsButton;

	[SerializeField]
	private Animation gearButtonAnimation;

	[SerializeField]
	private PlayerLevelRequirement cakeRaceRequirement;

	[SerializeField]
	private GameObject lockScreen;

	[SerializeField]
	private GameObject cakeRaceLockScreen;

	[SerializeField]
	private AnimatedButton cakeRaceButton;

	[SerializeField]
	private GameObject optionsNotConnectedBubble;

	private CakeRaceLockedDialog cakeRaceLockedDialog;

	private GameObject gcButton;

	private GameObject shopButton;

	private bool bSocialButtonsOut;

	private bool bInfoButtonsOut;

	private static bool s_optionsBubbleShowed;

	[SerializeField]
	private GameObject m_socialButton;

	[SerializeField]
	private GameObject m_infoButton;

	[SerializeField]
	private GameObject m_iapButton;

	public Transform toonsButton;

	public Transform startLayout;

	[SerializeField]
	private GameObject m_xboxLayout;

	private static bool isGameHallExitOpened;
}
