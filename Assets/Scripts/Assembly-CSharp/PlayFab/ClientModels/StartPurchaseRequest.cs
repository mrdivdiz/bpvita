using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class StartPurchaseRequest : PlayFabRequestCommon
	{
		public string CatalogVersion;

		public List<ItemPurchaseRequest> Items;

		public string StoreId;
	}
}
