using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ContactEmailInfoModel
	{
		public string EmailAddress;

		public string Name;

		public EmailVerificationStatus? VerificationStatus;
	}
}
