using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class CatalogItemBundleInfo
	{
		public List<string> BundledItems;

		public List<string> BundledResultTables;

		public Dictionary<string, uint> BundledVirtualCurrencies;
	}
}
