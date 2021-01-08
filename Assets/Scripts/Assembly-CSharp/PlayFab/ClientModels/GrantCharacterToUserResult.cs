using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GrantCharacterToUserResult : PlayFabResultCommon
	{
		public string CharacterId;

		public string CharacterType;

		public bool Result;
	}
}
