using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class UpdatePlayerStatisticsRequest : PlayFabRequestCommon
	{
		public List<StatisticUpdate> Statistics;
	}
}
