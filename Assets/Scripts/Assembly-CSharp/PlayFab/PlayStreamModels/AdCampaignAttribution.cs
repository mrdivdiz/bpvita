using System;

namespace PlayFab.PlayStreamModels
{
	[Serializable]
	public class AdCampaignAttribution
	{
		public DateTime AttributedAt;

		public string CampaignId;

		public string Platform;
	}
}
