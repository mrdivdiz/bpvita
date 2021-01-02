using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class PlayerProfileModel
	{
		public List<AdCampaignAttributionModel> AdCampaignAttributions;

		public string AvatarUrl;

		public DateTime? BannedUntil;

		public List<ContactEmailInfoModel> ContactEmailAddresses;

		public DateTime? Created;

		public string DisplayName;

		public DateTime? LastLogin;

		public List<LinkedPlatformAccountModel> LinkedAccounts;

		public List<LocationModel> Locations;

		public List<MembershipModel> Memberships;

		public LoginIdentityProvider? Origination;

		public string PlayerId;

		public string PublisherId;

		public List<PushNotificationRegistrationModel> PushNotificationRegistrations;

		public List<StatisticModel> Statistics;

		public List<TagModel> Tags;

		public string TitleId;

		public uint? TotalValueToDateInUSD;

		public List<ValueToDateModel> ValuesToDate;
	}
}
