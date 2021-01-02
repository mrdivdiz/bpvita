using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class PlayerAdRewardedEventData : PlayStreamEventBase
	{
		public List<string> ActionGroupDebugMessages;

		public string AdPlacementId;

		public string AdPlacementName;

		public string AdUnit;

		public string RewardId;

		public string RewardName;

		public string TitleId;

		public int? ViewsRemainingThisPeriod;
	}
}
