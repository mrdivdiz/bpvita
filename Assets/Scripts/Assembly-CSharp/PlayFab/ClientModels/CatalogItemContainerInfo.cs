using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class CatalogItemContainerInfo
	{
		public List<string> ItemContents;

		public string KeyItemId;

		public List<string> ResultTableContents;

		public Dictionary<string, uint> VirtualCurrencyContents;
	}
}
