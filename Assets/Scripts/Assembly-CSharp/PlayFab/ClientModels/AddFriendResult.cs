using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class AddFriendResult : PlayFabResultCommon
	{
		public bool Created;
	}
}
