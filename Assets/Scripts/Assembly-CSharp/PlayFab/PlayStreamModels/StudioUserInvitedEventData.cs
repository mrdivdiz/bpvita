using System;
using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
	public class StudioUserInvitedEventData : PlayStreamEventBase
	{
		public AuthenticationProvider? AuthenticationProvider;

		public string AuthenticationProviderId;

		public string Email;

		public DateTime? InvitationExpires;

		public string InvitationId;

		public bool InvitedExistingUser;

		public string InvitorPlayFabId;

		public List<string> StudioPermissions;

		public Dictionary<string, string> TitlePermissions;
	}
}
