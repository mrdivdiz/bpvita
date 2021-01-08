using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class SendAccountRecoveryEmailRequest : PlayFabRequestCommon
	{
		public string Email;

		public string EmailTemplateId;

		public string TitleId;
	}
}
