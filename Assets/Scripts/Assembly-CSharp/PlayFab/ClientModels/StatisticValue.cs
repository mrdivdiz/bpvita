using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class StatisticValue
	{
		public string StatisticName;

		public int Value;

		public uint Version;
	}
}
