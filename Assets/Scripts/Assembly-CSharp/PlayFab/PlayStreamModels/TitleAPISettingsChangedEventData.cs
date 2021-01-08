namespace PlayFab.PlayStreamModels
{
    public class TitleAPISettingsChangedEventData : PlayStreamEventBase
	{
		public string DeveloperId;

		public APISettings PreviousSettingsValues;

		public APISettings SettingsValues;

		public string UserId;
	}
}
