namespace PlayFab.PlayStreamModels
{
    public class TitleLimitChangedEventData : PlayStreamEventBase
	{
		public string LimitDisplayName;

		public string LimitId;

		public double? PreviousPriceUSD;

		public double? PreviousValue;

		public double? PriceUSD;

		public string TransactionId;

		public MetricUnit? Unit;

		public double? Value;
	}
}
