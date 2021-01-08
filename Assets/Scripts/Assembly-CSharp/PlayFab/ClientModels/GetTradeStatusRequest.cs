using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetTradeStatusRequest : PlayFabRequestCommon
	{
		public string OfferingPlayerId;

		public string TradeId;
	}
}
