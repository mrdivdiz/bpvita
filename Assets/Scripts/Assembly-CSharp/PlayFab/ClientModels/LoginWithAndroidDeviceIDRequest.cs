using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LoginWithAndroidDeviceIDRequest : PlayFabRequestCommon
	{
		public string AndroidDevice;

		public string AndroidDeviceId;

		public bool? CreateAccount;

		public string EncryptedRequest;

		public GetPlayerCombinedInfoRequestParams InfoRequestParameters;

		public bool? LoginTitlePlayerAccountEntity;

		public string OS;

		public string PlayerSecret;

		public string TitleId;
	}
}
