using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ItemInstance
	{
		public string Annotation;

		public List<string> BundleContents;

		public string BundleParent;

		public string CatalogVersion;

		public Dictionary<string, string> CustomData;

		public string DisplayName;

		public DateTime? Expiration;

		public string ItemClass;

		public string ItemId;

		public string ItemInstanceId;

		public DateTime? PurchaseDate;

		public int? RemainingUses;

		public string UnitCurrency;

		public uint UnitPrice;

		public int? UsesIncrementedBy;
	}
}
