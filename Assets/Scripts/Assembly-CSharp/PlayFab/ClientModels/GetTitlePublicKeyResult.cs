using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetTitlePublicKeyResult : PlayFabResultCommon
	{
		public string RSAPublicKey;
	}
}
