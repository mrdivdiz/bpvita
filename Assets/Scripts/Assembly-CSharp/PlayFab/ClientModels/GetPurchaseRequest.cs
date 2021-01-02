using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPurchaseRequest : PlayFabRequestCommon
	{
		public string OrderId;
	}
}
