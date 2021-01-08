using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class PurchaseItemResult : PlayFabResultCommon
	{
		public List<ItemInstance> Items;
	}
}
