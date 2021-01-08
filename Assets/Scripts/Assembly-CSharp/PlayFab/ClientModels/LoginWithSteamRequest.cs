using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LoginWithSteamRequest : PlayFabRequestCommon
	{
		public bool? CreateAccount;

		public string EncryptedRequest;

		public GetPlayerCombinedInfoRequestParams InfoRequestParameters;

		public bool? LoginTitlePlayerAccountEntity;

		public string PlayerSecret;

		public string SteamTicket;

		public string TitleId;
	}
}
