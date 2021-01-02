using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class StatisticUpdate
	{
		public string StatisticName;

		public int Value;

		public uint? Version;
	}
}
