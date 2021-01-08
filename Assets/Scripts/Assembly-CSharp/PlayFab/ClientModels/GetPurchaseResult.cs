using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPurchaseResult : PlayFabResultCommon
	{
		public string OrderId;

		public string PaymentProvider;

		public DateTime PurchaseDate;

		public string TransactionId;

		public string TransactionStatus;
	}
}
