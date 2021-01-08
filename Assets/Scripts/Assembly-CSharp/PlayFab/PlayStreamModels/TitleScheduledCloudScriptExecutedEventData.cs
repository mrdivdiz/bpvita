namespace PlayFab.PlayStreamModels
{
    public class TitleScheduledCloudScriptExecutedEventData : PlayStreamEventBase
	{
		public ExecuteCloudScriptResult CloudScriptExecutionResult;

		public string FunctionName;

		public NameId ScheduledTask;
	}
}
