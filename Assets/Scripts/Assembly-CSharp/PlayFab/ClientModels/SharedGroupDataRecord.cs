using System;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class SharedGroupDataRecord
	{
		public DateTime LastUpdated;

		public string LastUpdatedBy;

		public UserDataPermission? Permission;

		public string Value;
	}
}
