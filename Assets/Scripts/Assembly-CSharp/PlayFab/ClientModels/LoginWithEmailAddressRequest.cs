using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LoginWithEmailAddressRequest : PlayFabRequestCommon
	{
		public string Email;

		public GetPlayerCombinedInfoRequestParams InfoRequestParameters;

		public bool? LoginTitlePlayerAccountEntity;

		public string Password;

		public string TitleId;
	}
}
