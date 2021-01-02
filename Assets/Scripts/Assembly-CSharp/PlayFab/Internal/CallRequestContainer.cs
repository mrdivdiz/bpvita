using System;
using System.Collections.Generic;
using System.Net;
using PlayFab.SharedModels;

namespace PlayFab.Internal
{
	public class CallRequestContainer
	{
		public HttpRequestState HttpState = HttpRequestState.Idle;

		public HttpWebRequest HttpRequest;

		public string ApiEndpoint;

		public string FullUrl;

		public byte[] Payload;

		public string JsonResponse;

		public PlayFabRequestCommon ApiRequest;

		public Dictionary<string, string> RequestHeaders;

		public PlayFabResultCommon ApiResult;

		public PlayFabError Error;

		public Action DeserializeResultJson;

		public Action InvokeSuccessCallback;

		public Action<PlayFabError> ErrorCallback;

		public object CustomData;
	}
}
