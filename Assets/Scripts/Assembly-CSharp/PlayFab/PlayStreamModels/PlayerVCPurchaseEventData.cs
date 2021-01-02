namespace PlayFab.PlayStreamModels
{
    public class PlayerVCPurchaseEventData : PlayStreamEventBase
	{
		public string CatalogVersion;

		public string CurrencyCode;

		public string ItemId;

		public string PurchaseId;

		public int Quantity;

		public string StoreId;

		public string TitleId;

		public uint UnitPrice;
	}
}
