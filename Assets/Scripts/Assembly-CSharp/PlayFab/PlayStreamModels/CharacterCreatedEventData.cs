using System;

namespace PlayFab.PlayStreamModels
{
	public class CharacterCreatedEventData : PlayStreamEventBase
	{
		public string CharacterName;

		public DateTime Created;

		public string PlayerId;

		public string TitleId;
	}
}
