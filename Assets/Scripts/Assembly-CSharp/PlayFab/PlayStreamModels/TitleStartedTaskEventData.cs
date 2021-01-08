namespace PlayFab.PlayStreamModels
{
    public class TitleStartedTaskEventData : PlayStreamEventBase
	{
		public string DeveloperId;

		public object Parameter;

		public string ScheduledByUserId;

		public NameIdentifier ScheduledTask;

		public string TaskInstanceId;

		public string TaskType;

		public string UserId;
	}
}
