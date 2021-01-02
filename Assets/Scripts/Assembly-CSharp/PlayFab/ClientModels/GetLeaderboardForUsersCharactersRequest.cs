using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetLeaderboardForUsersCharactersRequest : PlayFabRequestCommon
	{
		public int MaxResultsCount;

		public string StatisticName;
	}
}
