using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class StartGameResult : PlayFabResultCommon
	{
		public string Expires;

		public string LobbyID;

		public string Password;

		public string ServerHostname;

		public string ServerIPV6Address;

		public int? ServerPort;

		public string Ticket;
	}
}
