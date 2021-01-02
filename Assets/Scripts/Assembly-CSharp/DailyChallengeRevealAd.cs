using System;
using System.Collections;
using UnityEngine;

public class DailyChallengeRevealAd : MonoBehaviour
{
	private void Awake()
	{
		DailyChallengeRevealAd.buttonId = null;
		this.adLoading.SetActive(false);
		this.adDisabled.SetActive(false);
		this.adEnabled.SetActive(false);
		this.adWatched.SetActive(false);
		if (DailyChallengeRevealAd.videoNotFoundDialog == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_videoNotFoundDialog);
			DailyChallengeRevealAd.videoNotFoundDialog = gameObject.GetComponent<TextDialog>();
			DailyChallengeRevealAd.videoNotFoundDialog.transform.position = WPFMonoBehaviour.hudCamera.transform.position + new Vector3(0f, 0f, 1f);
			DailyChallengeRevealAd.videoNotFoundDialog.Close();
		}
	}

	private void OnDestroy()
	{
		if (this.adReward != null)
		{
			this.adReward.Dispose();
		}
		if (Singleton<DailyChallenge>.IsInstantiated())
		{
			DailyChallenge instance = Singleton<DailyChallenge>.Instance;
			instance.OnInitialize = (Action)Delegate.Remove(instance.OnInitialize, new Action(this.Refresh));
			DailyChallenge instance2 = Singleton<DailyChallenge>.Instance;
			instance2.OnDailyChallengeChanged = (Action)Delegate.Remove(instance2.OnDailyChallengeChanged, new Action(this.Refresh));
		}
		if (Singleton<NetworkManager>.IsInstantiated())
		{
			Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.Initialize));
		}
	}

	private void Initialize(bool hasInternet)
	{
		this.checkingNetwork = false;
		if (!hasInternet)
		{
			return;
		}
		if (Singleton<DailyChallenge>.Instance.Initialized)
		{
			this.Refresh();
			DailyChallenge instance = Singleton<DailyChallenge>.Instance;
			instance.OnDailyChallengeChanged = (Action)Delegate.Combine(instance.OnDailyChallengeChanged, new Action(this.Refresh));
		}
		else
		{
			DailyChallenge instance2 = Singleton<DailyChallenge>.Instance;
			instance2.OnInitialize = (Action)Delegate.Combine(instance2.OnInitialize, new Action(this.Refresh));
			DailyChallenge instance3 = Singleton<DailyChallenge>.Instance;
			instance3.OnInitialize = (Action)Delegate.Combine(instance3.OnInitialize, new Action(delegate()
			{
				DailyChallenge instance4 = Singleton<DailyChallenge>.Instance;
				instance4.OnDailyChallengeChanged = (Action)Delegate.Combine(instance4.OnDailyChallengeChanged, new Action(this.Refresh));
			}));
		}
		this.initialized = true;
	}

	private void Refresh()
	{
		if (Singleton<DailyChallenge>.Instance.Challenges[this.challengeIndex].collected)
		{
			this.adDisabled.SetActive(false);
			this.adEnabled.SetActive(false);
			this.adLoading.SetActive(false);
			this.adWatched.SetActive(false);
		}
		else if (Singleton<DailyChallenge>.Instance.Challenges[this.challengeIndex].revealed)
		{
			this.EnableLevelButton();
		}
		else
		{
			this.adWatched.SetActive(false);
			this.InitAdReward();
			this.PrepareAd();
		}
		this.debugLootCrateLocation.text = Singleton<DailyChallenge>.Instance.Challenges[this.challengeIndex].Location;
	}

	private void OnEnable()
	{
		if (!this.initialized && !this.checkingNetwork)
		{
			this.checkingNetwork = true;
			Singleton<NetworkManager>.Instance.CheckAccess(new NetworkManager.OnCheckResponseDelegate(this.Initialize));
			if (!this.indicatorActive)
			{
				base.StartCoroutine(this.LoadingIndicator());
			}
		}
		else if (this.initialized)
		{
			this.Refresh();
		}
	}

	private void OnDisable()
	{
		base.StopAllCoroutines();
		this.indicatorActive = false;
	}

	private void InitAdReward()
	{
		if (this.adReward == null || this.adReward.Disposed)
		{
			this.adReward = new AdReward(AdvertisementHandler.DailyChallengeRevealPlacement);
			AdReward adReward = this.adReward;
			adReward.OnAdFinished = (Action)Delegate.Combine(adReward.OnAdFinished, new Action(this.OnAdFinished));
			AdReward adReward2 = this.adReward;
			adReward2.OnLoading = (Action)Delegate.Combine(adReward2.OnLoading, new Action(this.OnAdLoading));
			AdReward adReward3 = this.adReward;
			adReward3.OnCancel = (Action)Delegate.Combine(adReward3.OnCancel, new Action(this.OnAdCancelled));
			AdReward adReward4 = this.adReward;
			adReward4.OnFailed = (Action)Delegate.Combine(adReward4.OnFailed, new Action(this.OnAdFailed));
			AdReward adReward5 = this.adReward;
			adReward5.OnReady = (Action)Delegate.Combine(adReward5.OnReady, new Action(this.OnAdReady));
			AdReward adReward6 = this.adReward;
			adReward6.OnConfirmationFailed = (Action)Delegate.Combine(adReward6.OnConfirmationFailed, new Action(this.OnConfirmationFailed));
		}
	}

	private void PrepareAd()
	{
		if (Singleton<DailyChallenge>.Instance.IsLocationRevealed(this.challengeIndex))
		{
			this.EnableLevelButton();
		}
		else
		{
			this.adReward.Load();
		}
	}

	private void EnableLevelButton()
	{
		this.adDisabled.SetActive(false);
		this.adEnabled.SetActive(false);
		this.adLoading.SetActive(false);
		Singleton<DailyChallenge>.Instance.SetLocationRevealed(this.challengeIndex);
		if (Singleton<DailyChallenge>.Instance.DailyChallengeCollected(this.challengeIndex))
		{
			this.adWatched.SetActive(false);
		}
		else if (!Singleton<DailyChallenge>.Instance.DailyChallengeCollected(this.challengeIndex) && this.loaders.ImageReady)
		{
			this.adWatched.SetActive(true);
		}
		else
		{
			this.adWatched.SetActive(false);
			DailyChallengeLoader dailyChallengeLoader = this.loaders;
			dailyChallengeLoader.OnImageReady = (Action)Delegate.Combine(dailyChallengeLoader.OnImageReady, new Action(delegate()
			{
				if (this.adWatched != null)
				{
					this.adWatched.SetActive(true);
				}
			}));
		}
		this.debugLootCrateLocation.transform.parent.gameObject.SetActive(!Singleton<DailyChallenge>.Instance.DailyChallengeCollected(this.challengeIndex));
		this.debugLootCrateLocation.text = Singleton<DailyChallenge>.Instance.Challenges[this.challengeIndex].Location;
	}

	public void WatchAd()
	{
		if (this.adReady)
		{
			DailyChallengeRevealAd.buttonId = new int?(base.GetInstanceID());
			this.watching = true;
			this.adReward.Play();
		}
		else if (!this.adLoading)
		{
			this.adReward.Load();
		}
	}

	private void OnAdReady()
	{
		if (Singleton<DailyChallenge>.Instance.IsLocationRevealed(this.challengeIndex))
		{
			this.EnableLevelButton();
			return;
		}
		this.adEnabled.SetActive(true);
		this.adLoading.SetActive(false);
		this.adDisabled.SetActive(false);
		this.loading = false;
		this.adReady = true;
	}

	private void OnAdFailed()
	{
		if (Singleton<DailyChallenge>.Instance.IsLocationRevealed(this.challengeIndex))
		{
			this.EnableLevelButton();
			return;
		}
		if (this.watching && DailyChallengeRevealAd.videoNotFoundDialog != null)
		{
			DailyChallengeRevealAd.videoNotFoundDialog.Open();
		}
		this.adEnabled.SetActive(false);
		this.watching = false;
	}

	private void OnAdCancelled()
	{
		this.watching = false;
	}

	private void OnAdLoading()
	{
		if (Singleton<DailyChallenge>.Instance.IsLocationRevealed(this.challengeIndex))
		{
			this.EnableLevelButton();
			return;
		}
		this.adLoading.SetActive(true);
		this.adEnabled.SetActive(false);
		this.adDisabled.SetActive(false);
		this.adWatched.SetActive(false);
		this.adReady = false;
		this.loading = true;
		this.watching = false;
		if (base.gameObject.activeInHierarchy && !this.indicatorActive)
		{
			base.StartCoroutine(this.LoadingIndicator());
		}
	}

	private void OnAdFinished()
	{
		if (DailyChallengeRevealAd.buttonId == base.GetInstanceID())
		{
			this.adReward.Dispose();
			this.EnableLevelButton();
			Singleton<DailyChallenge>.Instance.SetLocationAdRevealed(this.challengeIndex);
		}
		else
		{
			this.InitAdReward();
			this.PrepareAd();
		}
		this.watching = false;
	}

	private void OnConfirmationFailed()
	{
		this.watching = false;
		if (DailyChallengeRevealAd.buttonId != base.GetInstanceID())
		{
			return;
		}
		if (DailyChallengeRevealAd.confirmationFailedDialog == null)
		{
			DailyChallengeRevealAd.confirmationFailedDialog = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_confirmationFailedDialog).GetComponent<TextDialog>();
			DailyChallengeRevealAd.confirmationFailedDialog.transform.position = WPFMonoBehaviour.hudCamera.transform.position;
			DailyChallengeRevealAd.confirmationFailedDialog.transform.position += Vector3.forward;
			DailyChallengeRevealAd.confirmationFailedDialog.Close();
		}
		DailyChallengeRevealAd.confirmationFailedDialog.Open();
		this.PrepareAd();
	}

	private IEnumerator LoadingIndicator()
	{
		this.indicatorActive = true;
		this.loadingIndicator.gameObject.SetActive(true);
		float wait = 0.6f;
		this.loadingIndicator.text = string.Empty;
		yield return new WaitForRealSeconds(wait);
		while (this.loading || this.checkingNetwork)
		{
			if (!this.loadingIndicator.gameObject.activeInHierarchy || (!this.loading && !this.checkingNetwork))
			{
				break;
			}
			this.loadingIndicator.text = ".";
			yield return new WaitForRealSeconds(wait);
			if (!this.loadingIndicator.gameObject.activeInHierarchy || (!this.loading && !this.checkingNetwork))
			{
				break;
			}
			this.loadingIndicator.text = "..";
			yield return new WaitForRealSeconds(wait);
			if (!this.loadingIndicator.gameObject.activeInHierarchy || (!this.loading && !this.checkingNetwork))
			{
				break;
			}
			this.loadingIndicator.text = "...";
			yield return new WaitForRealSeconds(wait);
		}
		this.loadingIndicator.gameObject.SetActive(false);
		this.indicatorActive = false;
		yield break;
	}

	private static int? buttonId;

	private static TextDialog videoNotFoundDialog;

	private static TextDialog confirmationFailedDialog;

	[SerializeField]
	private GameObject adEnabled;

	[SerializeField]
	private GameObject adDisabled;

	[SerializeField]
	private GameObject adWatched;

	[SerializeField]
	private GameObject adLoading;

	[SerializeField]
	private TextMesh loadingIndicator;

	[SerializeField]
	private int challengeIndex;

	[SerializeField]
	private DailyChallengeLoader loaders;

	[SerializeField]
	private TextMesh debugLootCrateLocation;

	private AdReward adReward;

	private bool loading;

	private bool adReady;

	private bool watching;

	private bool initialized;

	private bool checkingNetwork;

	private bool indicatorActive;
}
