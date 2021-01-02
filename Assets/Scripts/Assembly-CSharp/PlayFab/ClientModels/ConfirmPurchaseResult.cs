using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ConfirmPurchaseResult : PlayFabResultCommon
	{
		public List<ItemInstance> Items;

		public string OrderId;

		public DateTime PurchaseDate;
	}
}
