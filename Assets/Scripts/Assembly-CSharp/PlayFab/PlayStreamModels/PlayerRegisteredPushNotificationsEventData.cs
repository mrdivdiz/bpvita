namespace PlayFab.PlayStreamModels
{
    public class PlayerRegisteredPushNotificationsEventData : PlayStreamEventBase
	{
		public string DeviceToken;

		public PushNotificationPlatform? Platform;

		public string TitleId;
	}
}
