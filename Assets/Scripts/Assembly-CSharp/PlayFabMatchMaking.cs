using System;
using System.Text;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Json;
using UnityEngine;

public class PlayFabMatchMaking : MonoBehaviour
{
	public void FindOpponentReplay(int trackIndex, int playerLevel, int handiCap, Action<string> callback)
	{
		if (!Singleton<PlayFabManager>.Instance.Initialized)
		{
			return;
		}
		ExecuteCloudScriptRequest request = new ExecuteCloudScriptRequest
		{
			FunctionName = "fetchOpponentReplay",
			FunctionParameter = new
			{
				trackIndex = trackIndex,
				playerLevel = playerLevel,
				handicap = handiCap
			}
		};
		PlayFabClientAPI.ExecuteCloudScript(request, delegate(ExecuteCloudScriptResult result)
		{
			if (result.Logs != null)
			{
				foreach (LogStatement logStatement in result.Logs)
				{
					StringBuilder stringBuilder = new StringBuilder();
					if (logStatement.Data != null)
					{
						stringBuilder.AppendFormat("Data: '{0}'\n", logStatement.Data);
					}
					if (!string.IsNullOrEmpty(logStatement.Level))
					{
						stringBuilder.AppendFormat("Level: '{0}'\n", logStatement.Level);
					}
					if (!string.IsNullOrEmpty(logStatement.Message))
					{
						stringBuilder.AppendFormat("Message: '{0}'\n", logStatement.Message);
					}
				}
			}
			string key = "replay";
			string obj = string.Empty;
			UnityEngine.Debug.Log("[PlayFabManager] result.FunctionResult: " + JsonWrapper.SerializeObject(result.FunctionResult));
			JsonObject jsonObject = (JsonObject)result.FunctionResult;
			if (jsonObject != null)
			{
				if (jsonObject.ContainsKey(key) && jsonObject[key] is JsonObject && ((JsonObject)jsonObject[key]).ContainsKey("Value"))
				{
					obj = ((JsonObject)jsonObject[key])["Value"].ToString();
				}
				else
				{
					CakeRaceMenu.UseDefaultReplay = true;
				}
			}
			if (callback != null)
			{
				callback(obj);
			}
		}, delegate(PlayFabError error)
		{
			CakeRaceMenu.UseDefaultReplay = true;
			if (callback != null)
			{
				callback(string.Empty);
			}
		}, null, null);
	}

	public void GetCakeRaceWeek(Action<string, string> callback)
	{
		if (!Singleton<PlayFabManager>.Instance.Initialized)
		{
			return;
		}
		PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest
		{
			FunctionName = "fetchCakeRaceWeek"
		}, delegate(ExecuteCloudScriptResult result)
		{
			if (result.Logs != null)
			{
				foreach (LogStatement logStatement in result.Logs)
				{
					StringBuilder stringBuilder = new StringBuilder();
					if (logStatement.Data != null)
					{
						stringBuilder.AppendFormat("Data: '{0}'\n", logStatement.Data);
					}
					if (!string.IsNullOrEmpty(logStatement.Level))
					{
						stringBuilder.AppendFormat("Level: '{0}'\n", logStatement.Level);
					}
					if (!string.IsNullOrEmpty(logStatement.Message))
					{
						stringBuilder.AppendFormat("Message: '{0}'\n", logStatement.Message);
					}
				}
			}
			string arg = string.Empty;
			string arg2 = string.Empty;
			JsonObject jsonObject = (JsonObject)result.FunctionResult;
			if (jsonObject != null)
			{
				if (jsonObject.ContainsKey("week"))
				{
					arg = jsonObject["week"].ToString();
				}
				if (jsonObject.ContainsKey("daysleft"))
				{
					arg2 = jsonObject["daysleft"].ToString();
				}
			}
			if (callback != null)
			{
				callback(arg, arg2);
			}
		}, delegate(PlayFabError error)
		{
			if (callback != null)
			{
				callback(string.Empty, string.Empty);
			}
		}, null, null);
	}
}
