namespace PlayFab.PlayStreamModels
{
    public class TitleRequestedLimitChangeEventData : PlayStreamEventBase
	{
		public string DeveloperId;

		public string LevelName;

		public string LimitDisplayName;

		public string LimitId;

		public string PreviousLevelName;

		public double? PreviousPriceUSD;

		public double? PreviousValue;

		public double? PriceUSD;

		public string TransactionId;

		public MetricUnit? Unit;

		public string UserId;

		public double? Value;
	}
}
