using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ScriptExecutionError
	{
		public string Error;

		public string Message;

		public string StackTrace;
	}
}
