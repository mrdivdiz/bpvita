using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ConsumeItemRequest : PlayFabRequestCommon
	{
		public string CharacterId;

		public int ConsumeCount;

		public string ItemInstanceId;
	}
}
