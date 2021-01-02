using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class AcceptTradeResponse : PlayFabResultCommon
	{
		public TradeInfo Trade;
	}
}
