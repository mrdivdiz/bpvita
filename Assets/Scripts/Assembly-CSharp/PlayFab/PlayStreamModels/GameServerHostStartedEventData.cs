using System;

namespace PlayFab.PlayStreamModels
{
	public class GameServerHostStartedEventData : PlayStreamEventBase
	{
		public string InstanceId;

		public string InstanceProvider;

		public string InstanceType;

		public string Region;

		public string ServerBuildVersion;

		public string ServerHost;

		public string ServerIPV6Address;

		public DateTime StartTime;

		public string TitleId;
	}
}
