using System;
using UnityEngine;

public class ExtraCoinsRewardButton : MonoBehaviour
{
	private void Awake()
	{
		this.SetStatus(ExtraCoinsRewardButton.Status.Uninitialized);
		if (this.labels != null && this.labels.Length > 0)
		{
			this.rewardAmount = Singleton<GameConfigurationManager>.Instance.GetValue<int>("extra_coins_video", "coin_reward");
			string text = string.Format(this.stringFormat, this.rewardAmount);
			TextMeshHelper.UpdateTextMeshes(this.labels, text, false);
		}
		this.Initialize();
	}

	private void Initialize()
	{
		if (this.initialized)
		{
			return;
		}
		this.adReward = new AdReward(AdvertisementHandler.ExtraCoinsRewardPlacement);
		AdReward adReward = this.adReward;
		adReward.OnReady = (Action)Delegate.Combine(adReward.OnReady, new Action(this.OnAdReady));
		AdReward adReward2 = this.adReward;
		adReward2.OnFailed = (Action)Delegate.Combine(adReward2.OnFailed, new Action(this.OnAdFailure));
		AdReward adReward3 = this.adReward;
		adReward3.OnAdFinished = (Action)Delegate.Combine(adReward3.OnAdFinished, new Action(this.OnAdFinished));
		AdReward adReward4 = this.adReward;
		adReward4.OnLoading = (Action)Delegate.Combine(adReward4.OnLoading, new Action(this.OnAdLoading));
		AdReward adReward5 = this.adReward;
		adReward5.OnCancel = (Action)Delegate.Combine(adReward5.OnCancel, new Action(this.OnAdCancel));
		AdReward adReward6 = this.adReward;
		adReward6.OnConfirmationFailed = (Action)Delegate.Combine(adReward6.OnConfirmationFailed, new Action(this.OnAdConfirmationFailed));
		this.adReward.Load();
		this.initialized = true;
	}

	public void OnPress()
	{
		if (this.status == ExtraCoinsRewardButton.Status.Initialized)
		{
			this.adReward.Play();
		}
	}

	public void SetStatus(Status newStatus)
	{
		if (newStatus != ExtraCoinsRewardButton.Status.Error)
		{
			if (newStatus != ExtraCoinsRewardButton.Status.Initialized)
			{
				if (newStatus == ExtraCoinsRewardButton.Status.Uninitialized)
				{
					this.loadSpinner.SetActive(true);
					this.errorContent.SetActive(false);
					this.buttonContent.SetActive(false);
				}
			}
			else
			{
				this.loadSpinner.SetActive(false);
				this.errorContent.SetActive(false);
				this.buttonContent.SetActive(true);
			}
		}
		else
		{
			this.loadSpinner.SetActive(false);
			this.errorContent.SetActive(true);
			this.buttonContent.SetActive(false);
		}
		this.status = newStatus;
	}

	private void OnDestroy()
	{
		if (this.adReward != null)
		{
			this.adReward.Dispose();
		}
	}

	private void OnAdReady()
	{
		this.hasAd = true;
		this.loadingAd = false;
		if (this.OnAdLoaded != null)
		{
			this.OnAdLoaded(true);
			this.OnAdLoaded = null;
		}
		this.SetStatus((this.rewardAmount <= 0) ? ExtraCoinsRewardButton.Status.Error : ExtraCoinsRewardButton.Status.Initialized);
	}

	private void OnAdFailure()
	{
		this.hasAd = false;
		this.loadingAd = false;
		if (this.OnAdFailed != null)
		{
			this.OnAdFailed();
			this.OnAdLoaded = null;
		}
		this.SetStatus(ExtraCoinsRewardButton.Status.Error);
	}

	private void OnAdFinished()
	{
		this.hasAd = false;
		if (this.OnAdWatched != null)
		{
			this.OnAdWatched();
			this.OnAdWatched = null;
		}
		if (this.rewardAmount > 0)
		{
			GameProgress.AddSnoutCoins(this.rewardAmount);
			base.gameObject.SetActive(false);
			GridLayout component = base.transform.parent.GetComponent<GridLayout>();
			if (component != null)
			{
				component.UpdateLayout();
			}
			SnoutButton.Instance.AddParticles(base.gameObject, this.rewardAmount, 1f / (float)this.rewardAmount, 0f);
			LevelManager.IncentiveVideoShown();
		}
	}

	private void OnAdLoading()
	{
		this.hasAd = false;
		this.loadingAd = true;
		this.SetStatus(ExtraCoinsRewardButton.Status.Uninitialized);
	}

	private void OnAdCancel()
	{
	}

	private void OnAdConfirmationFailed()
	{
		this.adReward.Load();
		if (this.OnConfirmationFailed != null)
		{
			this.OnConfirmationFailed();
			this.OnConfirmationFailed = null;
		}
	}

	[SerializeField]
	private TextMesh[] labels;

	[SerializeField]
	private string stringFormat = "{0}";

	[SerializeField]
	private GameObject loadSpinner;

	[SerializeField]
	private GameObject errorContent;

	[SerializeField]
	private GameObject buttonContent;

	public Action OnAdWatched;

	public Action OnAdFailed;

	public Action<bool> OnAdLoaded;

	public Action OnConfirmationFailed;

	private AdReward adReward;

	private bool hasAd;

	private bool loadingAd;

	private Status status;

	private int rewardAmount;

	private bool initialized;

	public enum Status
	{
		Uninitialized,
		Initialized,
		Error
	}
}
