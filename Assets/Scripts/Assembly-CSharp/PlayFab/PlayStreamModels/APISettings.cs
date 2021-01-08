using System;

namespace PlayFab.PlayStreamModels
{
	[Serializable]
	public class APISettings
	{
		public bool AllowClientToAddVirtualCurrency;

		public bool AllowClientToPostPlayerStatistics;

		public bool AllowClientToStartGames;

		public bool AllowClientToSubtractVirtualCurrency;

		public bool AllowNonUniquePlayerDisplayNames;

		public bool AllowServerToDeleteUsers;

		public bool DisableAPIAccess;

		public int? DisplayNameRandomSuffixLength;

		public bool EnableClientIPAddressObfuscation;

		public bool RequireCustomDataJSONFormat;

		public bool UseExternalGameServerProvider;

		public bool UseSandboxPayments;
	}
}
