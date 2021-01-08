namespace PlayFab.PlayStreamModels
{
    public class CharacterConsumedItemEventData : PlayStreamEventBase
	{
		public string CatalogVersion;

		public string ItemId;

		public string ItemInstanceId;

		public string PlayerId;

		public uint PreviousUsesRemaining;

		public string TitleId;

		public uint UsesRemaining;
	}
}
