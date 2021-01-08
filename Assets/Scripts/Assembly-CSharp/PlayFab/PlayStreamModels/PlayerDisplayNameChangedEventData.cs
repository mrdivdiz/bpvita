namespace PlayFab.PlayStreamModels
{
    public class PlayerDisplayNameChangedEventData : PlayStreamEventBase
	{
		public string DisplayName;

		public string PreviousDisplayName;

		public string TitleId;
	}
}
