using System;

namespace PlayFab.PlayStreamModels
{
	public class PlayerPasswordResetLinkSentEventData : PlayStreamEventBase
	{
		public PasswordResetInitiationSource? InitiatedBy;

		public string InitiatedFromIPAddress;

		public DateTime LinkExpiration;

		public string PasswordResetId;

		public string RecoveryEmailAddress;

		public string TitleId;
	}
}
