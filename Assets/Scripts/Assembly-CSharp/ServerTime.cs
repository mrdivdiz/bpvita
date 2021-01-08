using System;
using System.Collections;
using UnityEngine;

public class ServerTime
{
	public ServerTime()
	{
		this.mStatus = ServerTime.Status.STATUS_NOK;
	}

	public event Action<int> StatusChanged;

	public void Destroy()
	{
		this.StatusChanged = null;
	}

	public Status GetStatus()
	{
		return this.mStatus;
	}

	public void RefreshServerTime()
	{
		if (this.mPendingRequest)
		{
			return;
		}
		this.mPendingRequest = true;
		this.mStatus = ServerTime.Status.STATUS_NOK;
		if (UnityEngine.Application.internetReachability == NetworkReachability.NotReachable)
		{
			this.ServerTimeErrorCallback(0, "No internet connection");
			return;
		}
	}

	private void ServerTimeSuccessCallback(ulong currentTime)
	{
		int obj = (int)currentTime;
		this.mPendingRequest = false;
		this.mStatus = ServerTime.Status.STATUS_OK;
		if (this.StatusChanged != null)
		{
			this.StatusChanged(obj);
		}
	}

	private void ServerTimeErrorCallback(int errorCode, string message)
	{
		this.mPendingRequest = false;
		this.mStatus = ServerTime.Status.STATUS_NOK;
	}

	private const string TAG = "LOG - ServerTime, ";

	private bool mPendingRequest;

	private Status mStatus;

	public enum Status
	{
		STATUS_OK,
		STATUS_NOK
	}
}
