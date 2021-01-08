using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ConfirmPurchaseRequest : PlayFabRequestCommon
	{
		public string OrderId;
	}
}
