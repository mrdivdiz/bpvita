using System;
using System.Collections;
using UnityEngine;

public class AdReward : IDisposable
{
	public AdReward(string placement)
	{
		this.placement = placement;
		this.SetState(AdReward.State.Stalled, true);
	}

	public bool Disposed
	{
		get
		{
			return this.disposed;
		}
	}

	~AdReward()
	{
		this.Dispose();
	}

	public void Dispose()
	{
		if (!this.disposed)
		{
			this.OnFailed = null;
			this.OnReady = null;
			this.OnAdFinished = null;
			this.OnLoading = null;
			this.OnCancel = null;
			this.OnConfirmationFailed = null;
			if (Singleton<NetworkManager>.IsInstantiated())
			{
				Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.HasInternet));
				Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.PlayRewardVideo));
			}
			this.disposed = true;
			GC.SuppressFinalize(this);
		}
	}

	public void Stall()
	{
		if (Singleton<NetworkManager>.IsInstantiated())
		{
			Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.HasInternet));
			Singleton<NetworkManager>.Instance.UnsubscribeFromResponse(new NetworkManager.OnCheckResponseDelegate(this.PlayRewardVideo));
		}
		this.SetState(AdReward.State.Stalled, false);
	}

	public void Play()
	{
		Singleton<GuiManager>.Instance.enabled = false;
		Singleton<NetworkManager>.Instance.CheckAccess(new NetworkManager.OnCheckResponseDelegate(this.PlayRewardVideo));
	}

	public void Load()
	{
		if (AdvertisementHandler.IsAdvertisementReady(this.placement))
		{
			this.SetState(AdReward.State.Ready, false);
		}
		else
		{
			this.SetState(AdReward.State.Loading, false);
		}
	}

	private void SetState(State state, bool forced = false)
	{
		if (state == this.state && !forced)
		{
			return;
		}
		this.state = state;
		switch (state)
		{
			case AdReward.State.Loading:
				if (this.OnLoading != null)
				{
					this.OnLoading();
				}
				this.StartLoading();
				break;
			case AdReward.State.WaitingFail:
				CoroutineRunner.Instance.StartCoroutine(this.FailureWait());
				break;
			case AdReward.State.Failed:
				if (this.OnFailed != null)
				{
					this.OnFailed();
				}
				break;
			case AdReward.State.Ready:
				if (this.OnReady != null)
				{
					this.OnReady();
				}
				break;
			case AdReward.State.Finished:
				if (this.OnAdFinished != null)
				{
					this.OnAdFinished();
				}
				break;
			case AdReward.State.Stalled:
				if (this.OnFailed != null)
				{
					this.OnFailed();
				}
				break;
			case AdReward.State.Cancelled:
				if (this.OnCancel != null)
				{
					this.OnCancel();
				}
				break;
			case AdReward.State.ConfirmationFailed:
				if (this.OnConfirmationFailed != null)
				{
					this.OnConfirmationFailed();
				}
				break;
		}
	}

	private void StartLoading()
	{
		if (UnityEngine.Application.internetReachability != NetworkReachability.NotReachable)
		{
			Singleton<NetworkManager>.Instance.CheckAccess(new NetworkManager.OnCheckResponseDelegate(this.HasInternet));
		}
		else
		{
			this.SetState(AdReward.State.Failed, false);
		}
	}

	private void HasInternet(bool internet)
	{
		if (this.state == AdReward.State.Stalled)
		{
			return;
		}
		if (!internet)
		{
			this.SetState(AdReward.State.Failed, false);
		}
		else if (internet && this.state == AdReward.State.Loading)
		{
			this.RefreshVideo();
		}
	}

	public void RefreshVideo()
	{
		CoroutineRunner.Instance.StartCoroutine(this.CheckVideoTimeout());
	}

	private void PlayRewardVideo(bool canPlay)
	{
		if (canPlay)
		{
			if (this.OnAdPlayFailed != null)
			{
				this.OnAdPlayFailed();
			}
		}
		else
		{
			if (this.OnAdPlayFailed != null)
			{
				this.OnAdPlayFailed();
			}
			this.SetState(AdReward.State.Failed, false);
		}
		Singleton<GuiManager>.Instance.enabled = true;
	}

	private IEnumerator DelayedAction(float delay, Action action)
	{
		if (action == null)
		{
			yield break;
		}
		yield return new WaitForRealSeconds(delay);
		if (!this.disposed)
		{
			action();
		}
		yield break;
	}

	private IEnumerator CheckVideoTimeout()
	{
		float counter = 0f;
		while (counter <= 10f)
		{
			counter += Time.unscaledDeltaTime;
			if (AdvertisementHandler.IsAdvertisementReady(this.placement))
			{
				break;
			}
			if (this.state == AdReward.State.Stalled || this.disposed)
			{
				yield break;
			}
			yield return null;
		}
		yield break;
	}

	private IEnumerator FailureWait()
	{
		float counter = 0f;
		while (counter <= 10f)
		{
			counter += Time.unscaledDeltaTime;
			if (this.state == AdReward.State.Stalled || this.disposed)
			{
				yield break;
			}
			yield return null;
		}
		if (this.state == AdReward.State.WaitingFail)
		{
			this.SetState(AdReward.State.Failed, false);
		}
		yield break;
	}

	public Action OnFailed;

	public Action OnReady;

	public Action OnAdFinished;

	public Action OnLoading;

	public Action OnCancel;

	public Action OnConfirmationFailed;

	public Action OnAdPlayFailed;

	private const float TIMEOUT_LENGTH = 10f;

	private bool disposed;

	private bool wasPaused;

	private bool waitingFailure;

	private string placement;

	private State state;

	private enum State
	{
		Loading,
		WaitingFail,
		Failed,
		Ready,
		Finished,
		Stalled,
		Cancelled,
		WaitingConfirmation,
		ConfirmationFailed
	}
}
