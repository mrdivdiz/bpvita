using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class TitleAddedCloudScriptEventData : PlayStreamEventBase
	{
		public string DeveloperId;

		public bool Published;

		public int Revision;

		public List<string> ScriptNames;

		public string UserId;

		public int Version;
	}
}
