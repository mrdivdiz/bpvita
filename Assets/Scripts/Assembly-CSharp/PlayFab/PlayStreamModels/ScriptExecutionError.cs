using System;

namespace PlayFab.PlayStreamModels
{
	[Serializable]
	public class ScriptExecutionError
	{
		public string Error;

		public string Message;

		public string StackTrace;
	}
}
