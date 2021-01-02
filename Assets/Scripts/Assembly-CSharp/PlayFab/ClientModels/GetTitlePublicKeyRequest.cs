using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetTitlePublicKeyRequest : PlayFabRequestCommon
	{
		public string TitleId;

		public string TitleSharedSecret;
	}
}
