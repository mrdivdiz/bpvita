namespace PlayFab.PlayStreamModels
{
    public class PlayerPhotonSessionAuthenticatedEventData : PlayStreamEventBase
	{
		public string PhotonApplicationId;

		public PhotonServicesEnum? PhotonApplicationType;

		public string TitleId;
	}
}
