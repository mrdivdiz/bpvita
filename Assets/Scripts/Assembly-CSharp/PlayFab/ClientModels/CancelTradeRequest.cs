using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class CancelTradeRequest : PlayFabRequestCommon
	{
		public string TradeId;
	}
}
