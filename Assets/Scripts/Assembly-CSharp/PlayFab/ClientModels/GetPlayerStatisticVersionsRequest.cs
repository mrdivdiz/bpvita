using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayerStatisticVersionsRequest : PlayFabRequestCommon
	{
		public string StatisticName;
	}
}
