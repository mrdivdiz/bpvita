using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class AdCampaignAttributionModel
	{
		public DateTime AttributedAt;

		public string CampaignId;

		public string Platform;
	}
}
