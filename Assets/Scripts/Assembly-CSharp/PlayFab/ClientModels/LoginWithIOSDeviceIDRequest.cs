using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LoginWithIOSDeviceIDRequest : PlayFabRequestCommon
	{
		public bool? CreateAccount;

		public string DeviceId;

		public string DeviceModel;

		public string EncryptedRequest;

		public GetPlayerCombinedInfoRequestParams InfoRequestParameters;

		public bool? LoginTitlePlayerAccountEntity;

		public string OS;

		public string PlayerSecret;

		public string TitleId;
	}
}
