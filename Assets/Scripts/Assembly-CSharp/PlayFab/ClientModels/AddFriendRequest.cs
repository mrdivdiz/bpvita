using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class AddFriendRequest : PlayFabRequestCommon
	{
		public string FriendEmail;

		public string FriendPlayFabId;

		public string FriendTitleDisplayName;

		public string FriendUsername;
	}
}
