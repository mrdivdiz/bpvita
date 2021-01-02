using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class RegionInfo
	{
		public bool Available;

		public string Name;

		public string PingUrl;

		public Region? Region;
	}
}
