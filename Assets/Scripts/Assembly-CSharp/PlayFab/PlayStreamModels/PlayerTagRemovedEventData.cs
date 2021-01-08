namespace PlayFab.PlayStreamModels
{
    public class PlayerTagRemovedEventData : PlayStreamEventBase
	{
		public string Namespace;

		public string TagName;

		public string TitleId;
	}
}
