using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class PlayerRedeemedCouponEventData : PlayStreamEventBase
	{
		public string CouponCode;

		public List<CouponGrantedInventoryItem> GrantedInventoryItems;

		public string TitleId;
	}
}
