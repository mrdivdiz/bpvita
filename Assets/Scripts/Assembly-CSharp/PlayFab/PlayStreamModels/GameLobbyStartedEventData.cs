using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class GameLobbyStartedEventData : PlayStreamEventBase
	{
		public string CustomCommandLineData;

		public string CustomMatchmakerEndpoint;

		public string GameMode;

		public string GameServerData;

		public int? MaxPlayers;

		public string Region;

		public string ServerBuildVersion;

		public string ServerHost;

		public string ServerHostInstanceId;

		public string ServerIPV6Address;

		public uint ServerPort;

		public Dictionary<string, string> Tags;

		public string TitleId;
	}
}
