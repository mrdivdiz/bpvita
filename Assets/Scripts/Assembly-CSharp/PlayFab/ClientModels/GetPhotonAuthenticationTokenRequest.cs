using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPhotonAuthenticationTokenRequest : PlayFabRequestCommon
	{
		public string PhotonApplicationId;
	}
}
