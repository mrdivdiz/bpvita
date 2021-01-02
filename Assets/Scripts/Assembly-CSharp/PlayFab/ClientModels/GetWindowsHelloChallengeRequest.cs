using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetWindowsHelloChallengeRequest : PlayFabRequestCommon
	{
		public string PublicKeyHint;

		public string TitleId;
	}
}
