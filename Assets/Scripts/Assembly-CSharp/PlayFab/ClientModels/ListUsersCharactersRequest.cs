using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ListUsersCharactersRequest : PlayFabRequestCommon
	{
		public string PlayFabId;
	}
}
