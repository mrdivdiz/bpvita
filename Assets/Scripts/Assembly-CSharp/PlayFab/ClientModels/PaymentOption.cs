using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class PaymentOption
	{
		public string Currency;

		public uint Price;

		public string ProviderName;

		public uint StoreCredit;
	}
}
