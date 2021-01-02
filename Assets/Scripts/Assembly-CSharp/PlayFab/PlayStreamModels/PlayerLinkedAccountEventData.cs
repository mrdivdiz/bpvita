namespace PlayFab.PlayStreamModels
{
    public class PlayerLinkedAccountEventData : PlayStreamEventBase
	{
		public string Email;

		public LoginIdentityProvider? Origination;

		public string OriginationUserId;

		public string TitleId;

		public string Username;
	}
}
