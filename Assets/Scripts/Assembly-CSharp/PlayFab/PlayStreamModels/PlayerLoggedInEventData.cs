namespace PlayFab.PlayStreamModels
{
    public class PlayerLoggedInEventData : PlayStreamEventBase
	{
		public EventLocation Location;

		public LoginIdentityProvider? Platform;

		public string PlatformUserId;

		public string TitleId;
	}
}
