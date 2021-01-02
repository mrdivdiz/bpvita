namespace PlayFab.PlayStreamModels
{
    public class GroupDeletedEventData : PlayStreamEventBase
	{
		public string DeleterEntityId;

		public string DeleterEntityType;

		public string EntityChain;

		public string GroupName;
	}
}
