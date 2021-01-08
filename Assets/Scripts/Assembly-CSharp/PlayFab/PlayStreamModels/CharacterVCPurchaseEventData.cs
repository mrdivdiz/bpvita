namespace PlayFab.PlayStreamModels
{
    public class CharacterVCPurchaseEventData : PlayStreamEventBase
	{
		public string CatalogVersion;

		public string CurrencyCode;

		public string ItemId;

		public string PlayerId;

		public string PurchaseId;

		public int Quantity;

		public string StoreId;

		public string TitleId;

		public uint UnitPrice;
	}
}
