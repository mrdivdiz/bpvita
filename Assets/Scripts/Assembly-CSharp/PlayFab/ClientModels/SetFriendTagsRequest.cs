using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class SetFriendTagsRequest : PlayFabRequestCommon
	{
		public string FriendPlayFabId;

		public List<string> Tags;
	}
}
