using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LoginWithGameCenterRequest : PlayFabRequestCommon
	{
		public bool? CreateAccount;

		public string EncryptedRequest;

		public GetPlayerCombinedInfoRequestParams InfoRequestParameters;

		public bool? LoginTitlePlayerAccountEntity;

		public string PlayerId;

		public string PlayerSecret;

		public string TitleId;
	}
}
