using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class OpenTradeRequest : PlayFabRequestCommon
	{
		public List<string> AllowedPlayerIds;

		public List<string> OfferedInventoryInstanceIds;

		public List<string> RequestedCatalogItemIds;
	}
}
