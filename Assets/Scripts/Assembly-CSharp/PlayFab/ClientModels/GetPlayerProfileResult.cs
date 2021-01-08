using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayerProfileResult : PlayFabResultCommon
	{
		public PlayerProfileModel PlayerProfile;
	}
}
