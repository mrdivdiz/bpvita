namespace PlayFab.PlayStreamModels
{
    public class CharacterStatisticChangedEventData : PlayStreamEventBase
	{
		public string PlayerId;

		public string StatisticName;

		public int? StatisticPreviousValue;

		public int StatisticValue;

		public string TitleId;

		public uint Version;
	}
}
