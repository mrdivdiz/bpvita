using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class OpenTradeResponse : PlayFabResultCommon
	{
		public TradeInfo Trade;
	}
}
