using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class RemoveSharedGroupMembersRequest : PlayFabRequestCommon
	{
		public List<string> PlayFabIds;

		public string SharedGroupId;
	}
}
