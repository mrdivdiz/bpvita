using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayerStatisticVersionsResult : PlayFabResultCommon
	{
		public List<PlayerStatisticVersion> StatisticVersions;
	}
}
