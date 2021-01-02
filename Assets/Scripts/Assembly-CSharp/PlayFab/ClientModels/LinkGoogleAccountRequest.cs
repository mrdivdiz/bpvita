using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LinkGoogleAccountRequest : PlayFabRequestCommon
	{
		public bool? ForceLink;

		public string ServerAuthCode;
	}
}
