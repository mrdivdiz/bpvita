using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class RegisterForIOSPushNotificationRequest : PlayFabRequestCommon
	{
		public string ConfirmationMessage;

		public string DeviceToken;

		public bool? SendPushNotificationConfirmation;
	}
}
