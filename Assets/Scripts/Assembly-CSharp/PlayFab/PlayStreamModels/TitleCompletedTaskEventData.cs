using System;

namespace PlayFab.PlayStreamModels
{
	public class TitleCompletedTaskEventData : PlayStreamEventBase
	{
		public DateTime? AbortedAt;

		public bool IsAborted;

		public TaskInstanceStatus? Result;

		public object Summary;

		public string TaskInstanceId;

		public string TaskType;
	}
}
