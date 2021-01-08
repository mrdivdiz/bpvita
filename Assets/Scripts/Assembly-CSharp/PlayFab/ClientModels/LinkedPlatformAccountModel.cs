using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LinkedPlatformAccountModel
	{
		public string Email;

		public LoginIdentityProvider? Platform;

		public string PlatformUserId;

		public string Username;
	}
}
