namespace PlayFab.PlayStreamModels
{
    public class TitleDeletedTaskEventData : PlayStreamEventBase
	{
		public string DeveloperId;

		public NameIdentifier ScheduledTask;

		public string UserId;
	}
}
