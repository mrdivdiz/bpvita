namespace PlayFab.PlayStreamModels
{
    public class PlayerVirtualCurrencyBalanceChangedEventData : PlayStreamEventBase
	{
		public string OrderId;

		public string TitleId;

		public int VirtualCurrencyBalance;

		public string VirtualCurrencyName;

		public int VirtualCurrencyPreviousBalance;
	}
}
