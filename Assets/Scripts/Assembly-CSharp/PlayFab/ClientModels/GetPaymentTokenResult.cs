using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPaymentTokenResult : PlayFabResultCommon
	{
		public string OrderId;

		public string ProviderToken;
	}
}
