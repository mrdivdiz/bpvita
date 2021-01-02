namespace PlayFab.PlayStreamModels
{
    public class PlayerUpdatedContactEmailEventData : PlayStreamEventBase
	{
		public string EmailName;

		public string NewEmailAddress;

		public string PreviousEmailAddress;

		public string TitleId;
	}
}
