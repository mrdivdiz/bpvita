using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetFriendsListResult : PlayFabResultCommon
	{
		public List<FriendInfo> Friends;
	}
}
