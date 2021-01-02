using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class RestoreIOSPurchasesRequest : PlayFabRequestCommon
	{
		public string ReceiptData;
	}
}
