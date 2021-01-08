using System;

namespace PlayFab.PlayStreamModels
{
	public class PlayerCompletedPasswordResetEventData : PlayStreamEventBase
	{
		public string CompletedFromIPAddress;

		public DateTime CompletionTimestamp;

		public PasswordResetInitiationSource? InitiatedBy;

		public string InitiatedFromIPAddress;

		public DateTime InitiationTimestamp;

		public DateTime LinkExpiration;

		public string PasswordResetId;

		public string RecoveryEmailAddress;

		public string TitleId;
	}
}
