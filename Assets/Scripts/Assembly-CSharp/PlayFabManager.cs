using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Json;
using PlayFab.SharedModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayFabManager : Singleton<PlayFabManager>
{
	public PlayFabLeaderboard Leaderboard { get; private set; }

	public PlayFabMatchMaking MatchMaking { get; private set; }

	public PlayFabUserHandling Users { get; private set; }

	public bool Initialized
	{
		get
		{
			return this.initialized;
		}
	}

	public bool IsSendingChunkCache { get; private set; }

	public string SessionTicket { get; private set; }

	private void Awake()
	{
		base.SetAsPersistant();
		this.sendCache = new Dictionary<string, string>();
		this.initialized = false;
		PlayFabSettings.TitleId = this.GetPlayFabTitleID();
		this.Leaderboard = base.gameObject.AddComponent<PlayFabLeaderboard>();
		this.MatchMaking = base.gameObject.AddComponent<PlayFabMatchMaking>();
		this.Users = base.gameObject.AddComponent<PlayFabUserHandling>();
		HatchManager.onLogout = (Action)Delegate.Combine(HatchManager.onLogout, new Action(this.Logout));
	}

	private string GetPlayFabTitleID()
	{
		if (HatchManager.IsProductionBuild())
		{
			return this.productionTitleID;
		}
		return this.devTitleID;
	}

	private void ResetCakeRacePersonalBests()
	{
		for (int i = 0; i < 7; i++)
		{
			string key = string.Format("cake_race_track_{0}_pb", i);
			if (GameProgress.HasKey(key, GameProgress.Location.Local, null))
			{
				GameProgress.DeleteKey(key, GameProgress.Location.Local);
			}
		}
	}

	private bool HasCakeRacePersonalBests()
	{
		for (int i = 0; i < 7; i++)
		{
			string key = string.Format("cake_race_track_{0}_pb", i);
			if (GameProgress.HasKey(key, GameProgress.Location.Local, null))
			{
				return true;
			}
		}
		return false;
	}

	public void Login(HatchManager.HatchPlayer player)
	{
		GetPlayerCombinedInfoRequestParams infoRequestParameters = new GetPlayerCombinedInfoRequestParams
		{
			GetUserAccountInfo = true,
			GetPlayerStatistics = true
		};
		LoginWithCustomIDRequest request2 = new LoginWithCustomIDRequest
		{
			TitleId = this.GetPlayFabTitleID(),
			CustomId = player.HatchID,
			CreateAccount = new bool?(true),
			InfoRequestParameters = infoRequestParameters
		};
		PlayFabClientAPI.LoginWithCustomID(request2, new Action<LoginResult>(this.OnLoginSuccess), new Action<PlayFabError>(this.OnLoginError), null, null);
	}

	private void OnLoginSuccess(LoginResult result)
	{
		string arg = string.Empty;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[PlayFabManager] - OnLoginSuccessfull!\n");
		stringBuilder.AppendFormat("SessionTicket: {0}\n", result.SessionTicket);
		stringBuilder.AppendFormat("PlayFabId: {0}\n", result.PlayFabId);
		stringBuilder.AppendFormat("NewlyCreated: {0}\n", result.NewlyCreated);
		stringBuilder.AppendFormat("LastLoginTime: {0}\n", result.LastLoginTime);
		if (result.CustomData != null && result.CustomData is JsonObject)
		{
			stringBuilder.AppendLine("CustomData: " + JsonWrapper.SerializeObject(result.CustomData));
		}
		bool flag = this.HasCakeRacePersonalBests();
		GameProgress.DeleteKey("Statistics_" + PlayFabLeaderboard.Leaderboard.CakeRaceWins.ToString(), GameProgress.Location.Local);
		GameProgress.DeleteKey("Statistics_" + PlayFabLeaderboard.Leaderboard.CakeRaceWins.ToString() + "_Version", GameProgress.Location.Local);
		if (result.InfoResultPayload != null)
		{
			stringBuilder.Append("InfoResultPayload.AccountInfo:\n");
			UserAccountInfo accountInfo = result.InfoResultPayload.AccountInfo;
			if (accountInfo != null && accountInfo.TitleInfo != null)
			{
				stringBuilder.AppendFormat("DisplayName: {0}\n", accountInfo.TitleInfo.DisplayName);
				HatchManager.CurrentPlayer.AddPlayFabDisplayName(accountInfo.TitleInfo.DisplayName);
			}
			if (accountInfo != null && accountInfo.FacebookInfo != null)
			{
				arg = accountInfo.FacebookInfo.FacebookId;
			}
			stringBuilder.Append("InfoResultPayload.PlayerStatistics:\n");
			List<StatisticValue> playerStatistics = result.InfoResultPayload.PlayerStatistics;
			if (playerStatistics != null)
			{
				foreach (StatisticValue statisticValue in playerStatistics)
				{
					stringBuilder.AppendFormat("{0}: {1}\n", statisticValue.StatisticName, statisticValue.Value);
					GameProgress.SetInt("Statistics_" + statisticValue.StatisticName, statisticValue.Value, GameProgress.Location.Local);
					GameProgress.SetInt("Statistics_" + statisticValue.StatisticName + "_Version", (int)statisticValue.Version, GameProgress.Location.Local);
					if (statisticValue.StatisticName == PlayFabLeaderboard.Leaderboard.CakeRaceWins.ToString() && flag && statisticValue.Value <= 0)
					{
						this.ResetCakeRacePersonalBests();
					}
				}
			}
		}
		stringBuilder.AppendLine("result.Request: " + result.Request.ToString());
		this.SessionTicket = result.SessionTicket;
		this.initialized = true;
		if (this.OnLogin != null)
		{
			this.OnLogin(result.PlayFabId, arg);
		}
		this.OnFacebookNameCallback(string.Empty, string.Empty);
	}

	private void OnFacebookNameCallback(string firstName, string lastName)
	{
		string arg = (!string.IsNullOrEmpty(firstName)) ? firstName : "guest";
		string text = (!string.IsNullOrEmpty(lastName) && lastName.Length >= 1) ? lastName : "-";
		string text2 = string.Format("{0}{1}", arg, text[0]);
		if (string.IsNullOrEmpty(lastName))
		{
			text2 += HatchManager.CurrentPlayer.HatchCustomerID.Substring(0, 6);
		}
		int num = 24 - HatchManager.CurrentPlayer.HatchCustomerID.Length;
		if (text2.Length > num)
		{
			text2 = text2.Substring(0, num);
		}
		string text3 = string.Format("{0}|{1}", text2, HatchManager.CurrentPlayer.HatchCustomerID);
		this.SetDisplayName(text3.ToString());
	}

	private void OnLoginError(PlayFabError error)
	{
		if (this.OnLogin != null)
		{
			this.OnLogin(string.Empty, string.Empty);
		}
	}

	public void Logout()
	{
		this.sendCache = new Dictionary<string, string>();
		this.initialized = false;
	}

	public void GetTitleData(List<string> keys, Action<GetTitleDataResult> cb, Action<PlayFabError> errorCb)
	{
		GetTitleDataRequest request = new GetTitleDataRequest
		{
			Keys = keys
		};
		PlayFabClientAPI.GetTitleData(request, cb, errorCb, null, null);
	}

	private void SetDisplayName(string displayName)
	{
		if (!this.initialized)
		{
			return;
		}
		if (!string.IsNullOrEmpty(HatchManager.CurrentPlayer.PlayFabDisplayName) && HatchManager.CurrentPlayer.PlayFabDisplayName.Equals(displayName))
		{
			return;
		}
		UpdateUserTitleDisplayNameRequest request = new UpdateUserTitleDisplayNameRequest
		{
			DisplayName = displayName
		};
		PlayFabClientAPI.UpdateUserTitleDisplayName(request, new Action<UpdateUserTitleDisplayNameResult>(this.OnUpdateUserTitleDisplayNameUpdated), new Action<PlayFabError>(this.OnError), null, null);
	}

	private void OnUpdateUserTitleDisplayNameUpdated(UpdateUserTitleDisplayNameResult result)
	{
		HatchManager.CurrentPlayer.AddPlayFabDisplayName(result.DisplayName);
	}

	public void UpdateUserData(Dictionary<string, string> data, UserDataPermission permission)
	{
		if (!this.initialized)
		{
			return;
		}
		base.StartCoroutine(this.UpdateUserDataInChunks(data, permission));
	}

	private IEnumerator UpdateUserDataInChunks(Dictionary<string, string> data, UserDataPermission permission)
	{
		this.AddToPendingCloudCache(data, permission);
		if (this.IsSendingChunkCache || this.waitingForMoreData)
		{
			if (this.waitingForMoreData)
			{
				this.waitForSeconds = 2f;
			}
			yield break;
		}
		this.waitingForMoreData = true;
		this.waitForSeconds = 2f;
		while (this.waitForSeconds > 0f)
		{
			this.waitForSeconds -= GameTime.RealTimeDelta;
			yield return null;
		}
		this.waitingForMoreData = false;
		EventManager.Send(new PlayFabEvent(PlayFabEvent.Type.UserDataUploadStarted));
		UserDataPermission sendPermission = UserDataPermission.Private;
		while (this.Initialized && this.UpdateDictionaryChunk(10, sendPermission))
		{
			while (this.IsSendingChunkCache)
			{
				yield return null;
			}
			if (sendPermission == UserDataPermission.Private)
			{
				sendPermission = UserDataPermission.Public;
			}
			else
			{
				sendPermission = UserDataPermission.Private;
			}
		}
		EventManager.Send(new PlayFabEvent(PlayFabEvent.Type.UserDataUploadEnded));
		yield break;
	}

	private bool UpdateDictionaryChunk(int maxChunkSize, UserDataPermission newPermission)
	{
		if (this.IsSendingChunkCache)
		{
			if (this.sendCache.Count == 0)
			{
				this.IsSendingChunkCache = false;
			}
			return this.pendingCloudData.Count > 0;
		}
		this.sendCachePermission = newPermission;
		this.IsSendingChunkCache = true;
		this.sendCache.Clear();
		Dictionary<string, PendingData>.KeyCollection keys = this.pendingCloudData.Keys;
		string[] array = new string[this.pendingCloudData.Count];
		keys.CopyTo(array, 0);
		for (int i = 0; i < array.Length; i++)
		{
			if (i >= maxChunkSize || this.pendingCloudData[array[i]].Permission != this.sendCachePermission)
			{
				break;
			}
			this.sendCache.Add(array[i], this.pendingCloudData[array[i]].Data);
			this.pendingCloudData.Remove(array[i]);
		}
		if (this.sendCache.Count > 0)
		{
			UpdateUserDataRequest request = new UpdateUserDataRequest
			{
				Data = this.sendCache,
				Permission = new UserDataPermission?(this.sendCachePermission)
			};
			PlayFabClientAPI.UpdateUserData(request, new Action<UpdateUserDataResult>(this.OnUserDataUpdated), new Action<PlayFabError>(this.OnUserDataUpdateError), null, null);
		}
		else
		{
			this.IsSendingChunkCache = false;
		}
		return this.pendingCloudData.Count > 0;
	}

	private void AddToPendingCloudCache(Dictionary<string, string> data, UserDataPermission permission)
	{
		if (this.pendingCloudData == null)
		{
			this.pendingCloudData = new Dictionary<string, PendingData>();
		}
		foreach (KeyValuePair<string, string> keyValuePair in data)
		{
			if (this.pendingCloudData.ContainsKey(keyValuePair.Key))
			{
				this.pendingCloudData[keyValuePair.Key].SetData(keyValuePair.Value, permission);
			}
			else
			{
				this.pendingCloudData.Add(keyValuePair.Key, new PendingData(keyValuePair.Value, permission));
			}
		}
	}

	private void OnUserDataUpdated(UpdateUserDataResult result)
	{
		if (this.Initialized)
		{
			this.IsSendingChunkCache = false;
			this.sendCache.Clear();
		}
	}

	private void OnUserDataUpdateError(PlayFabError error)
	{
		if (this.sendCache != null && this.sendCache.Count > 0)
		{
			this.AddToPendingCloudCache(this.sendCache, this.sendCachePermission);
			this.sendCache.Clear();
		}
		base.StartCoroutine(this.WaitAndResend());
	}

	private IEnumerator WaitAndResend()
	{
		float seconds = 10f;
		while (seconds > 0f)
		{
			seconds -= GameTime.RealTimeDelta;
			yield return null;
		}
		this.IsSendingChunkCache = false;
		yield break;
	}

	private void OnError(PlayFabError error)
	{
	}

	private void OnSuccess(PlayFabResultCommon result)
	{
	}

	[SerializeField]
	private string productionTitleID = "27DC";

	[SerializeField]
	private string devTitleID = "7988";

	private bool initialized;

	private UserDataPermission sendCachePermission;

	private Dictionary<string, string> sendCache;

	private Dictionary<string, PendingData> pendingCloudData;

	public Action<string, string> OnLogin;

	private bool waitingForMoreData;

	private float waitForSeconds = 2f;

	public enum SyncType
	{
		None,
		IntArray,
		Base64String,
		Base64StringArray
	}

	public class DeltaData
	{
		public DeltaData(string data, SyncType syncType)
		{
			this.Data = data;
			this.DataSyncType = syncType;
		}

		public string Data { get; private set; }

		public SyncType DataSyncType { get; private set; }
	}

	private class PendingData
	{
		public PendingData(string data, UserDataPermission permission)
		{
			this.SetData(data, permission);
		}

		public string Data { get; private set; }

		public UserDataPermission Permission { get; private set; }

		public void SetData(string data, UserDataPermission permission)
		{
			this.Data = data;
			this.Permission = permission;
		}
	}
}
