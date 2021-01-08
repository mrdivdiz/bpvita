using System;
using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
	public class PlayerInventoryItemAddedEventData : PlayStreamEventBase
	{
		public string Annotation;

		public List<string> BundleContents;

		public string CatalogVersion;

		public string Class;

		public string CouponCode;

		public string DisplayName;

		public DateTime? Expiration;

		public string InstanceId;

		public string ItemId;

		public uint? RemainingUses;

		public string TitleId;
	}
}
