using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;
using UnityEngine.Serialization;

public class DoubleRewardButton : WPFMonoBehaviour
{
	private bool CanShowDisabledButton()
	{
		return !Singleton<BuildCustomizationLoader>.Instance.IsOdyssey;
	}

	public LevelComplete LevelComplete
	{
		get
		{
			return this.levelComplete;
		}
		set
		{
			this.levelComplete = value;
		}
	}

	private void Awake()
	{
		this.enabledIcon = base.transform.Find("Button/EnabledIcon").gameObject;
		this.disabledIcon = base.transform.Find("Button/DisabledIcon").gameObject;
		this.texts = base.transform.Find("Button/Texts").gameObject;
		this.button = base.transform.Find("Button/Button").gameObject;
		this.snoutCoins = base.transform.Find("Button/SnoutCoins").gameObject;
		this.colliders = base.GetComponentsInChildren<Collider>();
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_videoNotFoundDialog);
		this.videoNotFoundDialog = gameObject.GetComponent<TextDialog>();
		this.videoNotFoundDialog.transform.position = WPFMonoBehaviour.hudCamera.transform.position + new Vector3(0f, 0f, 1f);
		this.videoNotFoundDialog.Close();
		this.SetRewardText(this.snoutCoins.transform);
		this.Disable();
	}

	private void Start()
	{
		this.Localize(this.texts.transform);
	}

	private void OnDestroy()
	{
		if (Singleton<DoubleRewardManager>.IsInstantiated())
		{
			DoubleRewardManager instance = Singleton<DoubleRewardManager>.Instance;
			instance.OnInitialize = (Action)Delegate.Remove(instance.OnInitialize, new Action(this.Enable));
			DoubleRewardManager instance2 = Singleton<DoubleRewardManager>.Instance;
			instance2.OnAdWatched = (Action)Delegate.Remove(instance2.OnAdWatched, new Action(this.DoubleRewardAdWatched));
			DoubleRewardManager instance3 = Singleton<DoubleRewardManager>.Instance;
			instance3.OnAdLoaded = (Action<bool>)Delegate.Remove(instance3.OnAdLoaded, new Action<bool>(this.AdLoadedResponse));
			DoubleRewardManager instance4 = Singleton<DoubleRewardManager>.Instance;
			instance4.OnAdFailed = (Action)Delegate.Remove(instance4.OnAdFailed, new Action(this.AdFailed));
			DoubleRewardManager instance5 = Singleton<DoubleRewardManager>.Instance;
			instance5.OnConfirmationFailed = (Action)Delegate.Remove(instance5.OnConfirmationFailed, new Action(this.OnConfirmationFailed));
		}
	}

	private void Localize(Transform texts)
	{
		if (texts == null)
		{
			return;
		}
		TextMesh[] componentsInChildren = texts.GetComponentsInChildren<TextMesh>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			TextMeshLocale component = componentsInChildren[i].GetComponent<TextMeshLocale>();
			if (!(component == null))
			{
				component.RefreshTranslation(componentsInChildren[i].text);
				component.enabled = false;
				componentsInChildren[i].text = string.Format(componentsInChildren[i].text, Singleton<DoubleRewardManager>.Instance.FormattedRewardTime);
				this.Wrap(componentsInChildren[i]);
			}
		}
	}

	private void SetRewardText(Transform texts)
	{
		TextMesh[] componentsInChildren = texts.GetComponentsInChildren<TextMesh>();
		string text = string.Format("+{0}", Singleton<DoubleRewardManager>.Instance.RewardCoins);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].text = text;
		}
	}

	private void Wrap(TextMesh target)
	{
		if (TextMeshHelper.UsesKanjiCharacters())
		{
			TextMeshHelper.Wrap(target, this.maxKanjiCharactersInLine, false);
		}
		else
		{
			TextMeshHelper.Wrap(target, this.maxCharacterInLine, false);
		}
	}

	public void Show()
	{
		if (Singleton<DoubleRewardManager>.Instance.CurrentStatus == DoubleRewardManager.Status.Initialized)
		{
			this.Enable();
		}
		else
		{
			DoubleRewardManager instance = Singleton<DoubleRewardManager>.Instance;
			instance.OnInitialize = (Action)Delegate.Combine(instance.OnInitialize, new Action(this.Enable));
		}
	}

	private void Enable()
	{
		for (int i = 0; i < this.colliders.Length; i++)
		{
			this.colliders[i].enabled = false;
		}
		if (Singleton<DoubleRewardManager>.Instance.HasDoubleReward)
		{
			return;
		}
		if (Singleton<DoubleRewardManager>.Instance.HasAd)
		{
			Singleton<NetworkManager>.Instance.CheckAccess(new NetworkManager.OnCheckResponseDelegate(this.OnNetworkCheck));
		}
		else if (Singleton<DoubleRewardManager>.Instance.LoadingAd)
		{
			this.SetRenderers(this.texts, false);
			this.SetRenderers(this.enabledIcon, false);
			this.SetRenderers(this.snoutCoins, false);
			this.SetRenderers(this.disabledIcon, false);
			this.SetRenderers(this.button, false);
			DoubleRewardManager instance = Singleton<DoubleRewardManager>.Instance;
			instance.OnAdLoaded = (Action<bool>)Delegate.Combine(instance.OnAdLoaded, new Action<bool>(this.AdLoadedResponse));
		}
		else
		{
			this.SetRenderers(this.texts, false);
			this.SetRenderers(this.enabledIcon, false);
			this.SetRenderers(this.snoutCoins, false);
			this.SetRenderers(this.disabledIcon, false);
			this.SetRenderers(this.button, false);
			DoubleRewardManager instance2 = Singleton<DoubleRewardManager>.Instance;
			instance2.OnAdLoaded = (Action<bool>)Delegate.Combine(instance2.OnAdLoaded, new Action<bool>(this.AdLoadedResponse));
			Singleton<DoubleRewardManager>.Instance.RefreshAd();
		}
	}

	private void OnNetworkCheck(bool hasInternet)
	{
		if (hasInternet && HatchManager.IsLoggedIn && this != null)
		{
			base.StartCoroutine(this.ShowAnimation());
		}
	}

	private void SetRenderers(GameObject target, bool mode)
	{
		if (target == null)
		{
			return;
		}
		Renderer[] componentsInChildren = target.GetComponentsInChildren<Renderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = mode;
		}
	}

	private void AdLoadedResponse(bool success)
	{
		DoubleRewardManager instance = Singleton<DoubleRewardManager>.Instance;
		instance.OnAdLoaded = (Action<bool>)Delegate.Remove(instance.OnAdLoaded, new Action<bool>(this.AdLoadedResponse));
		this.Enable();
	}

	private void Disable()
	{
		this.SetRenderers(this.texts, false);
		this.SetRenderers(this.enabledIcon, false);
		this.SetRenderers(this.snoutCoins, false);
		this.SetRenderers(this.disabledIcon, false);
		this.SetRenderers(this.button, false);
		for (int i = 0; i < this.colliders.Length; i++)
		{
			this.colliders[i].enabled = false;
		}
	}

	public void WatchDoubleRewardAd()
	{
		if (this.isWatchingAd)
		{
			return;
		}
		if (Singleton<DoubleRewardManager>.Instance.HasAd)
		{
			this.isWatchingAd = true;
			DoubleRewardManager instance = Singleton<DoubleRewardManager>.Instance;
			instance.OnAdWatched = (Action)Delegate.Combine(instance.OnAdWatched, new Action(this.DoubleRewardAdWatched));
			DoubleRewardManager instance2 = Singleton<DoubleRewardManager>.Instance;
			instance2.OnAdFailed = (Action)Delegate.Combine(instance2.OnAdFailed, new Action(this.AdFailed));
			DoubleRewardManager instance3 = Singleton<DoubleRewardManager>.Instance;
			instance3.OnConfirmationFailed = (Action)Delegate.Combine(instance3.OnConfirmationFailed, new Action(this.OnConfirmationFailed));
			Singleton<DoubleRewardManager>.Instance.PlayAd();
			if (this.unlockGo != null)
			{
				this.unlockGo.SetActive(true);
			}
		}
		else
		{
			this.AdFailed();
		}
	}

	public void UnlockUI()
	{
		GameTime.Pause(false);
		Singleton<GuiManager>.Instance.enabled = true;
		this.isWatchingAd = false;
		if (this.unlockGo != null)
		{
			this.unlockGo.SetActive(false);
		}
	}

	private void AdFailed()
	{
		if (!this.confirmationFailedDialog || !this.confirmationFailedDialog.IsOpen)
		{
			this.videoNotFoundDialog.Open();
		}
		this.snoutCoins.SetActive(false);
		this.texts.SetActive(false);
		this.enabledIcon.SetActive(false);
		this.button.SetActive(false);
		this.disabledIcon.SetActive(false);
		for (int i = 0; i < this.colliders.Length; i++)
		{
			this.colliders[i].enabled = false;
		}
		this.UnlockUI();
	}

	private void OnConfirmationFailed()
	{
		this.isWatchingAd = false;
		if (this.confirmationFailedDialog == null)
		{
			this.confirmationFailedDialog = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_confirmationFailedDialog).GetComponent<TextDialog>();
			this.confirmationFailedDialog.transform.position = WPFMonoBehaviour.hudCamera.transform.position;
			this.confirmationFailedDialog.transform.position += Vector3.forward;
			this.confirmationFailedDialog.Close();
		}
		if (!this.videoNotFoundDialog || !this.videoNotFoundDialog.IsOpen)
		{
			this.confirmationFailedDialog.Open();
		}
		this.Enable();
	}

	private void DoubleRewardAdWatched()
	{
		int value = Singleton<GameConfigurationManager>.Instance.GetValue<int>("level_complete_snout_reward", "One");
		int value2 = Singleton<GameConfigurationManager>.Instance.GetValue<int>("level_complete_snout_reward", "Two");
		int value3 = Singleton<GameConfigurationManager>.Instance.GetValue<int>("level_complete_snout_reward", "Three");
		int num = 0;
		num += Singleton<DoubleRewardManager>.Instance.RewardCoins;
		SnoutButton.Instance.AddParticles(base.gameObject, Singleton<DoubleRewardManager>.Instance.RewardCoins, 0f, 0f);
		if (this.levelComplete && (this.levelComplete.CoinsCollectedNow & LevelComplete.CoinsCollected.Challenge1) == LevelComplete.CoinsCollected.Challenge1)
		{
			SnoutButton.Instance.AddParticles(this.starOne, value, 0f, 0f);
			num += value;
		}
		if (this.levelComplete && (this.levelComplete.CoinsCollectedNow & LevelComplete.CoinsCollected.Challenge2) == LevelComplete.CoinsCollected.Challenge2)
		{
			SnoutButton.Instance.AddParticles(this.starTwo, value2, 0f, 0f);
			num += value2;
		}
		if (this.levelComplete && (this.levelComplete.CoinsCollectedNow & LevelComplete.CoinsCollected.Challenge3) == LevelComplete.CoinsCollected.Challenge3)
		{
			SnoutButton.Instance.AddParticles(this.starThree, value3, 0f, 0f);
			num += value3;
		}
		GameProgress.AddSnoutCoins(num);
		this.UnlockUI();
		this.Disable();
		DoubleRewardManager instance = Singleton<DoubleRewardManager>.Instance;
		instance.OnAdWatched = (Action)Delegate.Remove(instance.OnAdWatched, new Action(this.DoubleRewardAdWatched));
		DoubleRewardManager instance2 = Singleton<DoubleRewardManager>.Instance;
		instance2.OnAdFailed = (Action)Delegate.Remove(instance2.OnAdFailed, new Action(this.AdFailed));
		this.isWatchingAd = false;
	}

	private IEnumerator UpdateText(TextMesh target, Func<string> update)
	{
		target.text = update();
		this.Wrap(target);
		yield return new WaitForSeconds(0.1f);
		yield break;
	}

	private IEnumerator ShowAnimation()
	{
		if (this.sklAnimation != null)
		{
			this.sklAnimation.state.SetAnimation(0, "Intro1", false);
		}
		yield return null;
		this.SetRenderers(this.texts, true);
		this.SetRenderers(this.enabledIcon, true);
		this.SetRenderers(this.snoutCoins, true);
		this.SetRenderers(this.disabledIcon, false);
		this.SetRenderers(this.button, true);
		for (int i = 0; i < this.colliders.Length; i++)
		{
			this.colliders[i].enabled = true;
		}
		yield break;
	}

	[SerializeField]
	private GameObject starOne;

	[SerializeField]
	private GameObject starTwo;

	[SerializeField]
	private GameObject starThree;

	[SerializeField]
	[FormerlySerializedAs("animation")]
	private SkeletonAnimation sklAnimation;

	[SerializeField]
	private int maxCharacterInLine;

	[SerializeField]
	private int maxKanjiCharactersInLine;

	[SerializeField]
	private GameObject unlockGo;

	private Collider[] colliders;

	private GameObject enabledIcon;

	private GameObject disabledIcon;

	private GameObject texts;

	private GameObject button;

	private GameObject snoutCoins;

	private TextDialog videoNotFoundDialog;

	private TextDialog confirmationFailedDialog;

	private LevelComplete levelComplete;

	private bool isWatchingAd;
}
