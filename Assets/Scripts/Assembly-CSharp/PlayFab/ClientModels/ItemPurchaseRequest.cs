using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ItemPurchaseRequest : PlayFabRequestCommon
	{
		public string Annotation;

		public string ItemId;

		public uint Quantity;

		public List<string> UpgradeFromItems;
	}
}
