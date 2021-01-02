using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class StudioUserRemovedEventData : PlayStreamEventBase
	{
		public string AuthenticationId;

		public AuthenticationProvider? AuthenticationProvider;

		public string AuthenticationProviderId;

		public string PlayFabId;

		public List<string> StudioPermissions;

		public Dictionary<string, string> TitlePermissions;
	}
}
