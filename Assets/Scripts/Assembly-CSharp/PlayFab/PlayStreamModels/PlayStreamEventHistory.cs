using System;

namespace PlayFab.PlayStreamModels
{
	[Serializable]
	public class PlayStreamEventHistory
	{
		public string ParentEventId;

		public string ParentTriggerId;

		public bool TriggeredEvents;
	}
}
