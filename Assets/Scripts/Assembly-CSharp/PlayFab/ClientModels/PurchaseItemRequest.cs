using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class PurchaseItemRequest : PlayFabRequestCommon
	{
		public string CatalogVersion;

		public string CharacterId;

		public string ItemId;

		public int Price;

		public string StoreId;

		public string VirtualCurrency;
	}
}
