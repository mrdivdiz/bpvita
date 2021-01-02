using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPaymentTokenRequest : PlayFabRequestCommon
	{
		public string TokenProvider;
	}
}
