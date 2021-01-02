using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public class GroupMembersRemovedEventData : PlayStreamEventBase
	{
		public string EntityChain;

		public string GroupName;

		public List<Member> Members;
	}
}
