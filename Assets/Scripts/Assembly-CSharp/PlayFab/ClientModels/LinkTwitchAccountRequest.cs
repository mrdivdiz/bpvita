using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LinkTwitchAccountRequest : PlayFabRequestCommon
	{
		public string AccessToken;

		public bool? ForceLink;
	}
}
