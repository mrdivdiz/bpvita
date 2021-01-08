using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class CreateSharedGroupResult : PlayFabResultCommon
	{
		public string SharedGroupId;
	}
}
