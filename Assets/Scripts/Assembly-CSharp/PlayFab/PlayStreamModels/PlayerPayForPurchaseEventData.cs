using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class PlayerPayForPurchaseEventData : PlayStreamEventBase
	{
		public string OrderId;

		public string ProviderData;

		public string ProviderName;

		public string ProviderToken;

		public string PurchaseConfirmationPageURL;

		public string PurchaseCurrency;

		public uint PurchasePrice;

		public TransactionStatus? Status;

		public string TitleId;

		public Dictionary<string, int> VirtualCurrencyBalances;

		public Dictionary<string, int> VirtualCurrencyGrants;
	}
}
