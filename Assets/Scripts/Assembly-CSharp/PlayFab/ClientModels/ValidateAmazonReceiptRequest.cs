using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ValidateAmazonReceiptRequest : PlayFabRequestCommon
	{
		public string CatalogVersion;

		public string CurrencyCode;

		public int PurchasePrice;

		public string ReceiptId;

		public string UserId;
	}
}
