using System;

namespace PlayFab.PlayStreamModels
{
	public class SessionEndedEventData : PlayStreamEventBase
	{
		public bool Crashed;

		public DateTime EndTime;

		public double? KilobytesWritten;

		public double SessionLengthMs;

		public string TitleId;

		public string UserId;
	}
}
