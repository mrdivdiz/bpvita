using System;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabUserHandling : MonoBehaviour
{
	private void Awake()
	{
		this.replayKeyCache = new List<string>();
		for (int i = 0; i < 7; i++)
		{
			this.replayKeyCache.Add(string.Format("replay_track_{0}", i));
		}
	}

	public void GetUserReplays(string playfabID, Action<GetUserDataResult> cb, Action<PlayFabError> errorCb)
	{
		GetUserDataRequest request = new GetUserDataRequest
		{
			PlayFabId = playfabID,
			Keys = this.replayKeyCache
		};
		PlayFabClientAPI.GetUserData(request, cb, errorCb, null, null);
	}

	private List<string> replayKeyCache;
}
