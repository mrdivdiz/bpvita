using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class CreateSharedGroupRequest : PlayFabRequestCommon
	{
		public string SharedGroupId;
	}
}
