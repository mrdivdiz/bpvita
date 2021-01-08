using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class EntityObjectsSetEventData : PlayStreamEventBase
	{
		public string EntityChain;

		public List<ObjectSet> Objects;
	}
}
