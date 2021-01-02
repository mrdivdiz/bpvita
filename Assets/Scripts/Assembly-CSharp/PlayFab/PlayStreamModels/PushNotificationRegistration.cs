using System;

namespace PlayFab.PlayStreamModels
{
	[Serializable]
	public class PushNotificationRegistration
	{
		public string NotificationEndpointARN;

		public PushNotificationPlatform? Platform;
	}
}
