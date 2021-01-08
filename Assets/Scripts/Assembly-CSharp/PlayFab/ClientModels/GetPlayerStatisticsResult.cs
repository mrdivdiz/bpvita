using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayerStatisticsResult : PlayFabResultCommon
	{
		public List<StatisticValue> Statistics;
	}
}
