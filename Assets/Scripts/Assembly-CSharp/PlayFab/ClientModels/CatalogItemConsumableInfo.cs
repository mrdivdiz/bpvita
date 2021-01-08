using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class CatalogItemConsumableInfo
	{
		public uint? UsageCount;

		public uint? UsagePeriod;

		public string UsagePeriodGroup;
	}
}
