using System;

namespace PlayFab.PlayStreamModels
{
	public class TitleSecretKeyEventData : PlayStreamEventBase
	{
		public bool? Deleted;

		public string DeveloperId;

		public bool? Disabled;

		public DateTime? ExpiryDate;

		public string SecretKeyId;

		public string SecretKeyName;

		public string UserId;
	}
}
