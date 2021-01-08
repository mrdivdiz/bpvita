using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetFriendLeaderboardAroundPlayerRequest : PlayFabRequestCommon
	{
		public bool? IncludeFacebookFriends;

		public bool? IncludeSteamFriends;

		public int? MaxResultsCount;

		public string PlayFabId;

		public PlayerProfileViewConstraints ProfileConstraints;

		public string StatisticName;

		public int? Version;
	}
}
