using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetLeaderboardAroundCharacterRequest : PlayFabRequestCommon
	{
		public string CharacterId;

		public string CharacterType;

		public int? MaxResultsCount;

		public string StatisticName;
	}
}
