namespace PlayFab.PlayStreamModels
{
    public class PlayerStatisticDeletedEventData : PlayStreamEventBase
	{
		public uint StatisticId;

		public string StatisticName;

		public int? StatisticPreviousValue;

		public string TitleId;

		public uint Version;
	}
}
