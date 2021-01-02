using System;

namespace PlayFab.PlayStreamModels
{
	public class PlayerCreatedEventData : PlayStreamEventBase
	{
		public DateTime Created;

		public string PublisherId;

		public string TitleId;
	}
}
