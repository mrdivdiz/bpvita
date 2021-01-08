using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class UserDataRecord
	{
		public DateTime LastUpdated;

		public UserDataPermission? Permission;

		public string Value;
	}
}
