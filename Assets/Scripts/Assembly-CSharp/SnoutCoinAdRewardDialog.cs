using System;
using System.Collections;
using UnityEngine;

public class SnoutCoinAdRewardDialog : TextDialog
{
	protected override void Start()
	{
		base.Start();
		this.placement = AdvertisementHandler.SnoutCoinRewardVideoPlacement;		this.button = this.watchAdButton.GetComponent<Button>();
		this.rewardCount = this.GetSnoutCoinRewardCount();
		if (this.rewardCount > 0)
		{
			this.rewardAmountSpriteText.Text = string.Format("x{0}", this.rewardCount);
			this.SetState(SnoutCoinAdRewardDialog.State.Loading, true);
		}
		else
		{
			this.rewardAmountSpriteText.Text = string.Format("x{0}", 0);
			this.SetState(SnoutCoinAdRewardDialog.State.Failed, true);
		}
		base.onOpen += this.OnOpenResponse;
		base.onClose += this.OnClosedResponse;
	}

	private void OnOpenResponse()
	{
		if (this.rewardCount < 0)
		{
			this.rewardCount = this.GetSnoutCoinRewardCount();
		}
		if (this.rewardCount < 0)
		{
			return;
		}
		if (this.state == SnoutCoinAdRewardDialog.State.Failed || this.state == SnoutCoinAdRewardDialog.State.Finished || this.state == SnoutCoinAdRewardDialog.State.Stalled)
		{
			this.rewardAmountSpriteText.Text = string.Format("x{0}", this.rewardCount);
			this.SetState(SnoutCoinAdRewardDialog.State.Loading, false);
		}
	}

	private void OnDestroy()
	{
		base.onOpen -= this.OnOpenResponse;
		base.onClose -= this.OnClosedResponse;
		if (Singleton<NetworkManager>.IsInstantiated())
		{
			Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.HasInternet));
			Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.PlayRewardVideo));
		}	}

	private void OnClosedResponse()
	{
		Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.HasInternet));
		Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.PlayRewardVideo));
		this.SetState(SnoutCoinAdRewardDialog.State.Stalled, false);
	}

	private void SetState(State state, bool forced = false)
	{
		if (state == this.state && !forced)
		{
			return;
		}
		switch (state)
		{
		case SnoutCoinAdRewardDialog.State.Loading:
			this.OnLoading();
			break;
		case SnoutCoinAdRewardDialog.State.Failed:
			this.OnFailed();
			break;
		case SnoutCoinAdRewardDialog.State.Ready:
			this.OnReady();
			break;
		case SnoutCoinAdRewardDialog.State.Stalled:
			this.OnStalled();
			break;
		}
		this.state = state;
	}

	private void OnFailed()
	{
		this.failedIndicator.SetActive(true);
		this.successIndicator.SetActive(false);
		this.loadingIndicator.SetActive(false);
		this.button.MethodToCall.Reset();
	}

	private void OnLoading()
	{
		this.loadingIndicator.SetActive(true);
		this.successIndicator.SetActive(false);
		this.failedIndicator.SetActive(false);
		if (UnityEngine.Application.internetReachability != NetworkReachability.NotReachable)
		{
			Singleton<NetworkManager>.Instance.CheckAccess(new NetworkManager.OnCheckResponseDelegate(this.HasInternet));
		}
		else
		{
			this.SetState(SnoutCoinAdRewardDialog.State.Failed, false);
		}
	}

	private void OnReady()
	{
		this.successIndicator.SetActive(true);
		this.loadingIndicator.SetActive(false);
		this.failedIndicator.SetActive(false);
		this.button.MethodToCall.SetMethod(this, "StartRewardVideo");
	}

	private void OnStalled()
	{
		this.button.MethodToCall.Reset();
	}

	public new void Open()
	{
		base.Open();
	}

	public new void Close()
	{
		base.Close();
	}

	public new void Confirm()
	{
		base.Confirm();
	}

	private void HasInternet(bool internet)
	{
		if (this.state == SnoutCoinAdRewardDialog.State.Stalled)
		{
			return;
		}
		if (!internet)
		{
			this.SetState(SnoutCoinAdRewardDialog.State.Failed, false);
		}
		else if (internet && this.state == SnoutCoinAdRewardDialog.State.Loading)
		{
			this.RefreshVideo();
		}
	}

	private void RefreshVideo()
	{
		base.StartCoroutine(this.CheckVideoTimeout());
	}

	private IEnumerator CheckVideoTimeout()
	{
		float counter = 0f;
		while (counter <= 10f)
		{
			counter += Time.deltaTime;
			if (AdvertisementHandler.IsAdvertisementReady(AdvertisementHandler.SnoutCoinRewardVideoPlacement))
			{
				break;
			}
			if (this.state == SnoutCoinAdRewardDialog.State.Stalled)
			{
				yield break;
			}
			yield return null;
		}
		yield break;
	}

	public void StartRewardVideo()
	{
		Singleton<NetworkManager>.Instance.CheckAccess(new NetworkManager.OnCheckResponseDelegate(this.PlayRewardVideo));
	}

	private void PlayRewardVideo(bool hasInternet)
	{
		if (hasInternet)
		{
		}
		else
		{
			this.SetState(SnoutCoinAdRewardDialog.State.Failed, false);
		}
	}

	private IEnumerator DelayedAction(float delay, Action action)
	{
		if (action == null)
		{
			yield break;
		}
		yield return new WaitForSeconds(delay);
		action();
		yield break;
	}

	private int GetSnoutCoinRewardCount()
	{
		Hashtable productRewards = Singleton<VirtualCatalogManager>.Instance.GetProductRewards("video_ad_reward");
		if (productRewards == null)
		{
			return -1;
		}
		if (!productRewards.ContainsKey("SnoutCoin"))
		{
			return -1;
		}
		int result;
		if (int.TryParse(productRewards["SnoutCoin"] as string, out result))
		{
			return result;
		}
		return -1;
	}

	private const float TIMEOUT_LENGTH = 10f;

	[SerializeField]
	private GameObject watchAdButton;

	[SerializeField]
	private GameObject loadingIndicator;

	[SerializeField]
	private GameObject failedIndicator;

	[SerializeField]
	private GameObject successIndicator;

	[SerializeField]
	private SpriteText rewardAmountSpriteText;

	private int rewardCount;

	private Button button;

	private State state;

	private string placement;

	private enum State
	{
		Loading,
		Failed,
		Ready,
		Finished,
		Stalled
	}
}
