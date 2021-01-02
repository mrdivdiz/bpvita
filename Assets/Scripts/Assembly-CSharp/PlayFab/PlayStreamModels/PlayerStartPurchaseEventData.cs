using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class PlayerStartPurchaseEventData : PlayStreamEventBase
	{
		public string CatalogVersion;

		public List<CartItem> Contents;

		public string OrderId;

		public string StoreId;

		public string TitleId;
	}
}
