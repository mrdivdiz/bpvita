using System;
using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
	public abstract class PlayStreamEventBase
	{
		public string Source;

		public string EventId;

		public string EntityId;

		public string EntityType;

		public string EventNamespace;

		public string EventName;

		public DateTime Timestamp;

		public Dictionary<string, string> CustomTags;

		public List<object> History;

		public object Reserved;
	}
}
