namespace PlayFab.PlayStreamModels
{
    public class PlayerConsumedItemEventData : PlayStreamEventBase
	{
		public string CatalogVersion;

		public string ItemId;

		public string ItemInstanceId;

		public uint PreviousUsesRemaining;

		public string TitleId;

		public uint UsesRemaining;
	}
}
