using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class UpdateCharacterDataResult : PlayFabResultCommon
	{
		public uint DataVersion;
	}
}
