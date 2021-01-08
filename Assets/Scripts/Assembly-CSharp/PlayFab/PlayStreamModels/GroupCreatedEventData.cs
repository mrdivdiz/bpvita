namespace PlayFab.PlayStreamModels
{
    public class GroupCreatedEventData : PlayStreamEventBase
	{
		public string CreatorEntityId;

		public string CreatorEntityType;

		public string EntityChain;

		public string GroupName;
	}
}
