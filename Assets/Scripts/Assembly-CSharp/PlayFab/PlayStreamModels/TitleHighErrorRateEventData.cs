namespace PlayFab.PlayStreamModels
{
    public class TitleHighErrorRateEventData : PlayStreamEventBase
	{
		public string AlertEventId;

		public AlertStates? AlertState;

		public string API;

		public string ErrorCode;

		public string GraphUrl;

		public AlertLevel? Level;
	}
}
