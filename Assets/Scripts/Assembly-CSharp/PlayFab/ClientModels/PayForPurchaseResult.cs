using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class PayForPurchaseResult : PlayFabResultCommon
	{
		public uint CreditApplied;

		public string OrderId;

		public string ProviderData;

		public string ProviderToken;

		public string PurchaseConfirmationPageURL;

		public string PurchaseCurrency;

		public uint PurchasePrice;

		public TransactionStatus? Status;

		public Dictionary<string, int> VCAmount;

		public Dictionary<string, int> VirtualCurrency;
	}
}
