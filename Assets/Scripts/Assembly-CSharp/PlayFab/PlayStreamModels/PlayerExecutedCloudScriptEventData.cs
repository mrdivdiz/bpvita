namespace PlayFab.PlayStreamModels
{
    public class PlayerExecutedCloudScriptEventData : PlayStreamEventBase
	{
		public ExecuteCloudScriptResult CloudScriptExecutionResult;

		public string FunctionName;

		public string TitleId;
	}
}
