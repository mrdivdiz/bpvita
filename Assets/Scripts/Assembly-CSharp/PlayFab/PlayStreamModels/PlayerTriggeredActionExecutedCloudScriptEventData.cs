namespace PlayFab.PlayStreamModels
{
    public class PlayerTriggeredActionExecutedCloudScriptEventData : PlayStreamEventBase
	{
		public ExecuteCloudScriptResult CloudScriptExecutionResult;

		public string FunctionName;

		public string TitleId;

		public object TriggeringEventData;

		public string TriggeringEventName;

		public PlayerProfile TriggeringPlayer;
	}
}
