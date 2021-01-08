using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class PlayerRealMoneyPurchaseEventData : PlayStreamEventBase
	{
		public string OrderId;

		public uint OrderTotal;

		public string PaymentProvider;

		public PaymentType? PaymentType;

		public List<string> PurchasedProduct;

		public string TitleId;

		public Currency? TransactionCurrency;

		public string TransactionId;

		public uint? TransactionTotal;
	}
}
