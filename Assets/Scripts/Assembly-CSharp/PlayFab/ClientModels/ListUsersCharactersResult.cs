using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ListUsersCharactersResult : PlayFabResultCommon
	{
		public List<CharacterResult> Characters;
	}
}
