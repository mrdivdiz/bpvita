using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class CancelTradeResponse : PlayFabResultCommon
	{
		public TradeInfo Trade;
	}
}
