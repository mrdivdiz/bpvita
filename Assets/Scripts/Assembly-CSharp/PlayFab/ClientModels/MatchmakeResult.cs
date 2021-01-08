using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class MatchmakeResult : PlayFabResultCommon
	{
		public string Expires;

		public string LobbyID;

		public int? PollWaitTimeMS;

		public string ServerHostname;

		public string ServerIPV6Address;

		public int? ServerPort;

		public MatchmakeStatus? Status;

		public string Ticket;
	}
}
