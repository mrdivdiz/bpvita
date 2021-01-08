using System;
using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
	[Serializable]
	public class PlayerProfile
	{
		public List<AdCampaignAttribution> AdCampaignAttributions;

		public string AvatarUrl;

		public DateTime? BannedUntil;

		public List<ContactEmailInfo> ContactEmailAddresses;

		public DateTime? Created;

		public string DisplayName;

		public DateTime? LastLogin;

		public List<PlayerLinkedAccount> LinkedAccounts;

		public Dictionary<string, PlayerLocation> Locations;

		public LoginIdentityProvider? Origination;

		public string PlayerId;

		public List<PlayerStatistic> PlayerStatistics;

		public string PublisherId;

		public List<PushNotificationRegistration> PushNotificationRegistrations;

		public Dictionary<string, int> Statistics;

		public List<string> Tags;

		public string TitleId;

		public uint? TotalValueToDateInUSD;

		public Dictionary<string, uint> ValuesToDate;

		public Dictionary<string, int> VirtualCurrencyBalances;
	}
}
