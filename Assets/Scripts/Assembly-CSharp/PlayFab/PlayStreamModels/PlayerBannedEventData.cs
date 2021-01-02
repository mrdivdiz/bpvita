using System;

namespace PlayFab.PlayStreamModels
{
	public class PlayerBannedEventData : PlayStreamEventBase
	{
		public DateTime? BanExpiration;

		public string BanId;

		public string BanReason;

		public bool PermanentBan;

		public string TitleId;
	}
}
