using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class UserSteamInfo
	{
		public TitleActivationStatus? SteamActivationStatus;

		public string SteamCountry;

		public Currency? SteamCurrency;

		public string SteamId;
	}
}
