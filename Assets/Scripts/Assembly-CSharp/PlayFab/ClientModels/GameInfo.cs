using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GameInfo
	{
		public string BuildVersion;

		public string GameMode;

		public string GameServerData;

		public GameInstanceState? GameServerStateEnum;

		public DateTime? LastHeartbeat;

		public string LobbyID;

		public int? MaxPlayers;

		public List<string> PlayerUserIds;

		public Region? Region;

		public uint RunTime;

		public string ServerHostname;

		public string ServerIPV6Address;

		public int? ServerPort;

		public string StatisticName;

		public Dictionary<string, string> Tags;
	}
}
