using System;

namespace PlayFab.PlayStreamModels
{
	public class TitleStatisticVersionChangedEventData : PlayStreamEventBase
	{
		public StatisticResetIntervalOption? ScheduledResetInterval;

		public DateTime? ScheduledResetTime;

		public string StatisticName;

		public uint StatisticVersion;
	}
}
