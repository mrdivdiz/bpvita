using System;
using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
	[Serializable]
	public class ExecuteCloudScriptResult
	{
		public int APIRequestsIssued;

		public ScriptExecutionError Error;

		public double ExecutionTimeSeconds;

		public string FunctionName;

		public object FunctionResult;

		public bool? FunctionResultTooLarge;

		public int HttpRequestsIssued;

		public List<LogStatement> Logs;

		public bool? LogsTooLarge;

		public uint MemoryConsumedBytes;

		public double ProcessorTimeSeconds;

		public int Revision;
	}
}
