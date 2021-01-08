using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayerTradesRequest : PlayFabRequestCommon
	{
		public TradeStatus? StatusFilter;
	}
}
