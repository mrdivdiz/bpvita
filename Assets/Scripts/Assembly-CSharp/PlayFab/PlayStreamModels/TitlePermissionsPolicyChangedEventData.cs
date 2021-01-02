namespace PlayFab.PlayStreamModels
{
    public class TitlePermissionsPolicyChangedEventData : PlayStreamEventBase
	{
		public string DeveloperId;

		public string NewPolicy;

		public string PolicyName;

		public string UserId;
	}
}
