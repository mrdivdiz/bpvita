using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ExecuteCloudScriptResult : PlayFabResultCommon
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
