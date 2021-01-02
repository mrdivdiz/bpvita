using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class StoreItem
	{
		public object CustomData;

		public uint? DisplayPosition;

		public string ItemId;

		public Dictionary<string, uint> RealCurrencyPrices;

		public Dictionary<string, uint> VirtualCurrencyPrices;
	}
}
