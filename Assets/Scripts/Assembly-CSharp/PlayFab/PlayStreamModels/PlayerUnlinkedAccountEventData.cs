namespace PlayFab.PlayStreamModels
{
    public class PlayerUnlinkedAccountEventData : PlayStreamEventBase
	{
		public LoginIdentityProvider? Origination;

		public string OriginationUserId;

		public string TitleId;
	}
}
