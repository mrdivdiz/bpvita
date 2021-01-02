using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class PlayerStatisticVersion
	{
		public DateTime ActivationTime;

		public DateTime? DeactivationTime;

		public DateTime? ScheduledActivationTime;

		public DateTime? ScheduledDeactivationTime;

		public string StatisticName;

		public uint Version;
	}
}
