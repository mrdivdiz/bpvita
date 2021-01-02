using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class RedeemCouponResult : PlayFabResultCommon
	{
		public List<ItemInstance> GrantedItems;
	}
}
