namespace PlayFab.PlayStreamModels
{
    public class GroupRoleDeletedEventData : PlayStreamEventBase
	{
		public string DeleterEntityId;

		public string DeleterEntityType;

		public string EntityChain;

		public string GroupName;

		public string RoleId;

		public string RoleName;
	}
}
