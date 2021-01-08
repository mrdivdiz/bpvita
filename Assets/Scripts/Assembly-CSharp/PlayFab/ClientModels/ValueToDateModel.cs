using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ValueToDateModel
	{
		public string Currency;

		public uint TotalValue;

		public string TotalValueAsDecimal;
	}
}
