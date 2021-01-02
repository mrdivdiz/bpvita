using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class MembershipModel
	{
		public bool IsActive;

		public DateTime MembershipExpiration;

		public string MembershipId;

		public DateTime? OverrideExpiration;

		public List<SubscriptionModel> Subscriptions;
	}
}
