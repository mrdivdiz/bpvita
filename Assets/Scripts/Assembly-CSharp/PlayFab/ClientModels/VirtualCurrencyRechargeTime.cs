using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class VirtualCurrencyRechargeTime
	{
		public int RechargeMax;

		public DateTime RechargeTime;

		public int SecondsToRecharge;
	}
}
