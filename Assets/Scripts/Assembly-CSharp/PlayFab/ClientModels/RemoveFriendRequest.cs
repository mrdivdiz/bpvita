using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class RemoveFriendRequest : PlayFabRequestCommon
	{
		public string FriendPlayFabId;
	}
}
