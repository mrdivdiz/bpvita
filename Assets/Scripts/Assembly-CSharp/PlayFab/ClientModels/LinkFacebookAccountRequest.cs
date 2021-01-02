using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LinkFacebookAccountRequest : PlayFabRequestCommon
	{
		public string AccessToken;

		public bool? ForceLink;
	}
}
