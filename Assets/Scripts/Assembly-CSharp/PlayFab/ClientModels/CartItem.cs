using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class CartItem
	{
		public string Description;

		public string DisplayName;

		public string ItemClass;

		public string ItemId;

		public string ItemInstanceId;

		public Dictionary<string, uint> RealCurrencyPrices;

		public Dictionary<string, uint> VCAmount;

		public Dictionary<string, uint> VirtualCurrencyPrices;
	}
}
