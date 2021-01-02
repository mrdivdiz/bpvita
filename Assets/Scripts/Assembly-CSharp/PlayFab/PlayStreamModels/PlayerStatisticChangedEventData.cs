namespace PlayFab.PlayStreamModels
{
    public class PlayerStatisticChangedEventData : PlayStreamEventBase
	{
		public StatisticAggregationMethod? AggregationMethod;

		public uint StatisticId;

		public string StatisticName;

		public int? StatisticPreviousValue;

		public int StatisticValue;

		public string TitleId;

		public uint Version;
	}
}
