namespace PlayFab.PlayStreamModels
{
    public class TitleInitiatedPlayerPasswordResetEventData : PlayStreamEventBase
	{
		public string DeveloperId;

		public string PasswordResetId;

		public string PlayerId;

		public string PlayerRecoveryEmailAddress;

		public string UserId;
	}
}
