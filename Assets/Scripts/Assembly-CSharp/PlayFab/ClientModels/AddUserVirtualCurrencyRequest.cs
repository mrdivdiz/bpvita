using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class AddUserVirtualCurrencyRequest : PlayFabRequestCommon
	{
		public int Amount;

		public string VirtualCurrency;
	}
}
