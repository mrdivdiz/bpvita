using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LinkSteamAccountRequest : PlayFabRequestCommon
	{
		public bool? ForceLink;

		public string SteamTicket;
	}
}
