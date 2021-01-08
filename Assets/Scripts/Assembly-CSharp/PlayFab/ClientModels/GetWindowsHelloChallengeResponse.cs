using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetWindowsHelloChallengeResponse : PlayFabResultCommon
	{
		public string Challenge;
	}
}
