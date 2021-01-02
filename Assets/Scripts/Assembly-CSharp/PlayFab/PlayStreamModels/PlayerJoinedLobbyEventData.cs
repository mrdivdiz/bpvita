namespace PlayFab.PlayStreamModels
{
    public class PlayerJoinedLobbyEventData : PlayStreamEventBase
	{
		public string GameMode;

		public string LobbyId;

		public string Region;

		public string ServerBuildVersion;

		public string ServerHost;

		public string ServerHostInstanceId;

		public string ServerIPV6Address;

		public uint ServerPort;

		public string TitleId;
	}
}
