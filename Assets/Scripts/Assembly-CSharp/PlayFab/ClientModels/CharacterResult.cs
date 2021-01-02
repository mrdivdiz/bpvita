using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class CharacterResult : PlayFabResultCommon
	{
		public string CharacterId;

		public string CharacterName;

		public string CharacterType;
	}
}
