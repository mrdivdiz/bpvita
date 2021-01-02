namespace PlayFab.PlayStreamModels
{
    public class TitleUpdatedTaskEventData : PlayStreamEventBase
	{
		public string DeveloperId;

		public bool HasRenamed;

		public NameIdentifier ScheduledTask;

		public string UserId;
	}
}
