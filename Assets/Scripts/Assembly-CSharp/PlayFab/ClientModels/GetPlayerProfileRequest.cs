using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayerProfileRequest : PlayFabRequestCommon
	{
		public string PlayFabId;

		public PlayerProfileViewConstraints ProfileConstraints;
	}
}
