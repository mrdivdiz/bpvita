namespace PlayFab.PlayStreamModels
{
    public class TitleCatalogUpdatedEventData : PlayStreamEventBase
	{
		public string CatalogVersion;

		public bool Deleted;

		public string DeveloperId;

		public string UserId;
	}
}
