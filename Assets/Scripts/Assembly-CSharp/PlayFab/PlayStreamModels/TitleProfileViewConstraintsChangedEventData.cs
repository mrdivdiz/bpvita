namespace PlayFab.PlayStreamModels
{
    public class TitleProfileViewConstraintsChangedEventData : PlayStreamEventBase
	{
		public string DeveloperId;

		public string PreviousProfileViewConstraints;

		public string ProfileType;

		public string ProfileViewConstraints;

		public string UserId;
	}
}
