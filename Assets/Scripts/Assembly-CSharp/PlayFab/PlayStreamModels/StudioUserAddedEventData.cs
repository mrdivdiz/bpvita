using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class StudioUserAddedEventData : PlayStreamEventBase
	{
		public string AuthenticationId;

		public AuthenticationProvider? AuthenticationProvider;

		public string AuthenticationProviderId;

		public string Email;

		public string InvitationId;

		public string PlayFabId;

		public List<string> StudioPermissions;

		public Dictionary<string, string> TitlePermissions;
	}
}
