using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetTitleNewsRequest : PlayFabRequestCommon
	{
		public int? Count;
	}
}
