using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class GroupRoleMembersAddedEventData : PlayStreamEventBase
	{
		public string EntityChain;

		public string GroupName;

		public List<Member> Members;

		public string RoleId;

		public string RoleName;
	}
}
