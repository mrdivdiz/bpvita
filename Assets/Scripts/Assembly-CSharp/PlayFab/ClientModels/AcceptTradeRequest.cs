using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class AcceptTradeRequest : PlayFabRequestCommon
	{
		public List<string> AcceptedInventoryInstanceIds;

		public string OfferingPlayerId;

		public string TradeId;
	}
}
