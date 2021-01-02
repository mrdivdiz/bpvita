using System;
using System.Collections;
using UnityEngine;

public class LevelRowUnlockDialog : TextDialog
{
	protected override void Start()
	{
		base.Start();
		this.adReward = new AdReward(AdvertisementHandler.LevelRewardVideoPlacement);
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
		this.adReward.Load();
		base.onOpen += delegate()
		{
			if (this.adReward != null)
			{
				this.adReward.Load();
			}
		};
		base.onClose += delegate()
		{
			if (this.adReward != null)
			{
				this.adReward.Stall();
			}
		};
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_videoNotFoundDialog);
		gameObject.transform.position = WPFMonoBehaviour.hudCamera.transform.position + new Vector3(0f, 0f, 1f);
		this.videoNotFoundDialog = gameObject.GetComponent<TextDialog>();
		this.videoNotFoundDialog.Close();
	}

	private void OnDestroy()
	{
		if (this.adReward != null)
		{
			AdReward adReward = this.adReward;
			adReward.OnAdFinished = (Action)Delegate.Remove(adReward.OnAdFinished, new Action(this.OnAdFinished));
			AdReward adReward2 = this.adReward;
			adReward2.OnLoading = (Action)Delegate.Remove(adReward2.OnLoading, new Action(this.OnAdLoading));
			AdReward adReward3 = this.adReward;
			adReward3.OnCancel = (Action)Delegate.Remove(adReward3.OnCancel, new Action(this.OnAdCancelled));
			AdReward adReward4 = this.adReward;
			adReward4.OnFailed = (Action)Delegate.Remove(adReward4.OnFailed, new Action(this.OnAdFailed));
			AdReward adReward5 = this.adReward;
			adReward5.OnReady = (Action)Delegate.Remove(adReward5.OnReady, new Action(this.OnAdReady));
			this.adReward.Dispose();
		}
	}

	private void OnAdLoading()
	{
		this.watchButtonText.gameObject.SetActive(false);
		this.disabledAdButton.SetActive(false);
		this.enabledAdButton.SetActive(true);
		this.enabledWatchAdButton.MethodToCall.Reset();
		this.disabledWatchAdButton.MethodToCall.Reset();
		this.loadingIndicator.gameObject.SetActive(true);
		this.loading = true;
		this.hasAd = false;
		base.StartCoroutine(this.LoadingIndicator());
	}

	private void OnAdReady()
	{
		this.disabledAdButton.SetActive(false);
		this.enabledAdButton.SetActive(true);
		this.watchButtonText.gameObject.SetActive(true);
		this.enabledWatchAdButton.MethodToCall.SetMethod(this, "WatchAd");
		this.loadingIndicator.gameObject.SetActive(false);
		this.loading = false;
		this.hasAd = true;
	}

	private void OnAdFailed()
	{
		this.disabledAdButton.SetActive(true);
		this.enabledAdButton.SetActive(false);
		this.disabledWatchAdButton.MethodToCall.SetMethod(this, "WatchAd");
		this.loading = false;
		this.hasAd = false;
	}

	private void OnAdCancelled()
	{
		this.loading = false;
	}

	private void OnAdFinished()
	{
		if (this.OnAdFinishedSuccesfully != null)
		{
			this.OnAdFinishedSuccesfully();
		}
		this.loading = false;
	}

	public void WatchAd()
	{
		if (this.hasAd)
		{
			this.adReward.Play();
		}
		else
		{
			this.videoNotFoundDialog.Open();
		}
	}

	private IEnumerator LoadingIndicator()
	{
		float wait = 0.6f;
		this.loadingIndicator.text = string.Empty;
		yield return new WaitForSeconds(wait);
		while (this.loading)
		{
			if (!this.loadingIndicator.gameObject.activeInHierarchy || !this.loading)
			{
				yield break;
			}
			this.loadingIndicator.text = ".";
			yield return new WaitForSeconds(wait);
			if (!this.loadingIndicator.gameObject.activeInHierarchy || !this.loading)
			{
				yield break;
			}
			this.loadingIndicator.text = "..";
			yield return new WaitForSeconds(wait);
			if (!this.loadingIndicator.gameObject.activeInHierarchy || !this.loading)
			{
				yield break;
			}
			this.loadingIndicator.text = "...";
			yield return new WaitForSeconds(wait);
		}
		this.loadingIndicator.gameObject.SetActive(false);
		yield break;
	}

	public Action OnAdFinishedSuccesfully;

	[SerializeField]
	private GameObject enabledAdButton;

	[SerializeField]
	private GameObject disabledAdButton;

	[SerializeField]
	private Button enabledWatchAdButton;

	[SerializeField]
	private Button disabledWatchAdButton;

	[SerializeField]
	private TextMesh watchButtonText;

	[SerializeField]
	private TextMesh loadingIndicator;

	private TextDialog videoNotFoundDialog;

	private AdReward adReward;

	private bool loading;

	private bool hasAd;

	private string placement;
}
