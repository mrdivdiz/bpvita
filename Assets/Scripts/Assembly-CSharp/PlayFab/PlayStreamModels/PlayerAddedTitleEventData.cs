namespace PlayFab.PlayStreamModels
{
    public class PlayerAddedTitleEventData : PlayStreamEventBase
	{
		public string DisplayName;

		public LoginIdentityProvider? Platform;

		public string PlatformUserId;

		public string TitleId;
	}
}
