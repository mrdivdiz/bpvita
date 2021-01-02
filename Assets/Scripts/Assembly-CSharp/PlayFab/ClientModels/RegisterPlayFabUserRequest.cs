using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class RegisterPlayFabUserRequest : PlayFabRequestCommon
	{
		public string DisplayName;

		public string Email;

		public string EncryptedRequest;

		public GetPlayerCombinedInfoRequestParams InfoRequestParameters;

		public bool? LoginTitlePlayerAccountEntity;

		public string Password;

		public string PlayerSecret;

		public bool? RequireBothUsernameAndEmail;

		public string TitleId;

		public string Username;
	}
}
