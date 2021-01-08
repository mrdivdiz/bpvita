using System;

namespace PlayFab.PlayStreamModels
{
	[Serializable]
	public class ContactEmailInfo
	{
		public string EmailAddress;

		public string Name;

		public EmailVerificationStatus? VerificationStatus;
	}
}
