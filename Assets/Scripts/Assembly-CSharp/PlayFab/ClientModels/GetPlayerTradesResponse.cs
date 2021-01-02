using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayerTradesResponse : PlayFabResultCommon
	{
		public List<TradeInfo> AcceptedTrades;

		public List<TradeInfo> OpenedTrades;
	}
}
