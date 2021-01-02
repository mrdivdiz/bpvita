using System;

namespace PlayFab.PlayStreamModels
{
	public class GameServerHostStoppedEventData : PlayStreamEventBase
	{
		public string InstanceId;

		public string InstanceProvider;

		public string InstanceType;

		public string Region;

		public string ServerBuildVersion;

		public string ServerHost;

		public string ServerIPV6Address;

		public DateTime StartTime;

		public GameServerHostStopReason? StopReason;

		public DateTime StopTime;

		public string TitleId;
	}
}
