namespace PlayFab.PlayStreamModels
{
    public class TitleClientRateLimitedEventData : PlayStreamEventBase
	{
		public string AlertEventId;

		public AlertStates? AlertState;

		public string API;

		public string ErrorCode;

		public string GraphUrl;

		public AlertLevel? Level;
	}
}
