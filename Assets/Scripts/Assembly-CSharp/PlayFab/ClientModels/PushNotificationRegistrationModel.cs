using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class PushNotificationRegistrationModel
	{
		public string NotificationEndpointARN;

		public PushNotificationPlatform? Platform;
	}
}
