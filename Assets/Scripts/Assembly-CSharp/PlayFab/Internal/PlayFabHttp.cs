using System;
using System.Collections.Generic;
using System.Text;
using PlayFab.ClientModels;
using PlayFab.Json;
using PlayFab.Public;
using PlayFab.SharedModels;
using UnityEngine;

namespace PlayFab.Internal
{
    public class PlayFabHttp : SingletonMonoBehaviour<PlayFabHttp>
	{
		public static event ApiProcessingEvent<ApiProcessingEventArgs> ApiProcessingEventHandler;

		public static event ApiProcessErrorEvent ApiProcessingErrorEventHandler;

		public static int GetPendingMessages()
		{
			return (PlayFabHttp._internalHttp != null) ? PlayFabHttp._internalHttp.GetPendingMessages() : 0;
		}

		public static void SetHttp<THttpObject>(THttpObject httpObj) where THttpObject : IPlayFabHttp
		{
			PlayFabHttp._internalHttp = httpObj;
		}

		public static void SetAuthKey(string authKey)
		{
			PlayFabHttp._internalHttp.AuthKey = authKey;
		}

		public static void InitializeHttp()
		{
			if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
			{
				throw new PlayFabException(PlayFabExceptionCode.TitleNotSet, "You must set PlayFabSettings.TitleId before making API Calls.");
			}
			if (PlayFabHttp._internalHttp != null)
			{
				return;
			}
			Application.runInBackground = true;
			if (PlayFabSettings.RequestType == WebRequestType.HttpWebRequest)
			{
				PlayFabHttp._internalHttp = new PlayFabWebRequest();
			}
			if (PlayFabSettings.RequestType == WebRequestType.UnityWebRequest)
			{
				PlayFabHttp._internalHttp = new PlayFabUnityHttp();
			}
			if (PlayFabHttp._internalHttp == null)
			{
				PlayFabHttp._internalHttp = new PlayFabWww();
			}
			PlayFabHttp._internalHttp.InitializeHttp();
			SingletonMonoBehaviour<PlayFabHttp>.CreateInstance();
		}

		public static void InitializeLogger(IPlayFabLogger setLogger = null)
		{
			if (PlayFabHttp._logger != null)
			{
				throw new InvalidOperationException("Once initialized, the logger cannot be reset.");
			}
			if (setLogger == null)
			{
				setLogger = new PlayFabLogger();
			}
			PlayFabHttp._logger = setLogger;
		}

		public static void SimpleGetCall(string fullUrl, Action<byte[]> successCallback, Action<string> errorCallback)
		{
			PlayFabHttp.InitializeHttp();
			PlayFabHttp._internalHttp.SimpleGetCall(fullUrl, successCallback, errorCallback);
		}

		public static void SimplePutCall(string fullUrl, byte[] payload, Action successCallback, Action<string> errorCallback)
		{
			PlayFabHttp.InitializeHttp();
			PlayFabHttp._internalHttp.SimplePutCall(fullUrl, payload, successCallback, errorCallback);
		}

		protected internal static void MakeApiCall<TResult>(string apiEndpoint, PlayFabRequestCommon request, AuthType authType, Action<TResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null, bool allowQueueing = false) where TResult : PlayFabResultCommon
		{
			PlayFabHttp.InitializeHttp();
			PlayFabHttp.SendEvent(apiEndpoint, request, null, ApiProcessingEventType.Pre);
			CallRequestContainer reqContainer = new CallRequestContainer
			{
				ApiEndpoint = apiEndpoint,
				FullUrl = PlayFabSettings.GetFullUrl(apiEndpoint),
				CustomData = customData,
				Payload = Encoding.UTF8.GetBytes(JsonWrapper.SerializeObject(request)),
				ApiRequest = request,
				ErrorCallback = errorCallback,
				RequestHeaders = (extraHeaders ?? new Dictionary<string, string>())
			};
			foreach (KeyValuePair<string, string> keyValuePair in PlayFabHttp.GlobalHeaderInjection)
			{
				if (!reqContainer.RequestHeaders.ContainsKey(keyValuePair.Key))
				{
					reqContainer.RequestHeaders[keyValuePair.Key] = keyValuePair.Value;
				}
			}
			reqContainer.RequestHeaders["X-ReportErrorAsSuccess"] = "true";
			reqContainer.RequestHeaders["X-PlayFabSDK"] = "UnitySDK-2.39.180409";
			if (authType != AuthType.LoginSession)
			{
				if (authType == AuthType.EntityToken)
				{
					reqContainer.RequestHeaders["X-EntityToken"] = PlayFabHttp._internalHttp.EntityToken;
				}
			}
			else
			{
				reqContainer.RequestHeaders["X-Authorization"] = PlayFabHttp._internalHttp.AuthKey;
			}
			reqContainer.DeserializeResultJson = delegate()
			{
				reqContainer.ApiResult = JsonWrapper.DeserializeObject<TResult>(reqContainer.JsonResponse);
			};
			reqContainer.InvokeSuccessCallback = delegate()
			{
				if (resultCallback != null)
				{
					resultCallback((TResult)((object)reqContainer.ApiResult));
				}
			};
			if (allowQueueing && PlayFabHttp._apiCallQueue != null && !PlayFabHttp._internalHttp.SessionStarted)
			{
				for (int i = PlayFabHttp._apiCallQueue.Count - 1; i >= 0; i--)
				{
					if (PlayFabHttp._apiCallQueue[i].ApiEndpoint == apiEndpoint)
					{
						PlayFabHttp._apiCallQueue.RemoveAt(i);
					}
				}
				PlayFabHttp._apiCallQueue.Add(reqContainer);
			}
			else
			{
				PlayFabHttp._internalHttp.MakeApiCall(reqContainer);
			}
		}

		internal void OnPlayFabApiResult(PlayFabResultCommon result)
		{
			LoginResult loginResult = result as LoginResult;
			RegisterPlayFabUserResult registerPlayFabUserResult = result as RegisterPlayFabUserResult;
			if (loginResult != null)
			{
				PlayFabHttp._internalHttp.AuthKey = loginResult.SessionTicket;
				if (loginResult.EntityToken != null)
				{
					PlayFabHttp._internalHttp.EntityToken = loginResult.EntityToken.EntityToken;
				}
			}
			else if (registerPlayFabUserResult != null)
			{
				PlayFabHttp._internalHttp.AuthKey = registerPlayFabUserResult.SessionTicket;
			}
		}

		private void OnEnable()
		{
			if (PlayFabHttp._logger != null)
			{
				PlayFabHttp._logger.OnEnable();
			}
		}

		private void OnDisable()
		{
			if (PlayFabHttp._logger != null)
			{
				PlayFabHttp._logger.OnDisable();
			}
		}

		private void OnDestroy()
		{
			if (PlayFabHttp._internalHttp != null)
			{
				PlayFabHttp._internalHttp.OnDestroy();
			}
			if (PlayFabHttp._logger != null)
			{
				PlayFabHttp._logger.OnDestroy();
			}
		}

		private void Update()
		{
			if (PlayFabHttp._internalHttp != null)
			{
				if (!PlayFabHttp._internalHttp.SessionStarted && PlayFabHttp._apiCallQueue != null)
				{
					foreach (CallRequestContainer reqContainer in PlayFabHttp._apiCallQueue)
					{
						PlayFabHttp._internalHttp.MakeApiCall(reqContainer);
					}
					PlayFabHttp._apiCallQueue = null;
				}
				PlayFabHttp._internalHttp.Update();
			}
		}

		public static bool IsClientLoggedIn()
		{
			return PlayFabHttp._internalHttp != null && !string.IsNullOrEmpty(PlayFabHttp._internalHttp.AuthKey);
		}

		public static void ForgetAllCredentials()
		{
			if (PlayFabHttp._internalHttp != null)
			{
				PlayFabHttp._internalHttp.AuthKey = null;
				PlayFabHttp._internalHttp.EntityToken = null;
			}
		}

		protected internal static PlayFabError GeneratePlayFabError(string apiEndpoint, string json, object customData)
		{
			JsonObject jsonObject = null;
			Dictionary<string, List<string>> errorDetails = null;
			try
			{
				jsonObject = JsonWrapper.DeserializeObject<JsonObject>(json);
			}
			catch (Exception)
			{
			}
			try
			{
				if (jsonObject != null && jsonObject.ContainsKey("errorDetails"))
				{
					errorDetails = JsonWrapper.DeserializeObject<Dictionary<string, List<string>>>(jsonObject["errorDetails"].ToString());
				}
			}
			catch (Exception)
			{
			}
			return new PlayFabError
			{
				ApiEndpoint = apiEndpoint,
				HttpCode = ((jsonObject == null || !jsonObject.ContainsKey("code")) ? 400 : Convert.ToInt32(jsonObject["code"])),
				HttpStatus = ((jsonObject == null || !jsonObject.ContainsKey("status")) ? "BadRequest" : ((string)jsonObject["status"])),
				Error = (PlayFabErrorCode)((jsonObject == null || !jsonObject.ContainsKey("errorCode")) ? 1123 : Convert.ToInt32(jsonObject["errorCode"])),
				ErrorMessage = ((jsonObject == null || !jsonObject.ContainsKey("errorMessage")) ? json : ((string)jsonObject["errorMessage"])),
				ErrorDetails = errorDetails,
				CustomData = customData
			};
		}

		protected internal static void SendErrorEvent(PlayFabRequestCommon request, PlayFabError error)
		{
			if (PlayFabHttp.ApiProcessingErrorEventHandler == null)
			{
				return;
			}
			try
			{
				PlayFabHttp.ApiProcessingErrorEventHandler(request, error);
			}
			catch (Exception ex)
			{
			}
		}

		protected internal static void SendEvent(string apiEndpoint, PlayFabRequestCommon request, PlayFabResultCommon result, ApiProcessingEventType eventType)
		{
			if (PlayFabHttp.ApiProcessingEventHandler == null)
			{
				return;
			}
			try
			{
				PlayFabHttp.ApiProcessingEventHandler(new ApiProcessingEventArgs
				{
					ApiEndpoint = apiEndpoint,
					EventType = eventType,
					Request = request,
					Result = result
				});
			}
			catch
			{
			}
		}

		protected internal static void ClearAllEvents()
		{
			PlayFabHttp.ApiProcessingEventHandler = null;
			PlayFabHttp.ApiProcessingErrorEventHandler = null;
		}

		private static IPlayFabHttp _internalHttp;

		private static List<CallRequestContainer> _apiCallQueue = new List<CallRequestContainer>();

		public static readonly Dictionary<string, string> GlobalHeaderInjection = new Dictionary<string, string>();

		private static IPlayFabLogger _logger;

		public delegate void ApiProcessingEvent<in TEventArgs>(TEventArgs e);

		public delegate void ApiProcessErrorEvent(PlayFabRequestCommon request, PlayFabError error);
	}
}
