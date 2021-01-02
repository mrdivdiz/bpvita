using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class PayForPurchaseRequest : PlayFabRequestCommon
	{
		public string Currency;

		public string OrderId;

		public string ProviderName;

		public string ProviderTransactionId;
	}
}
