namespace PlayFab.PlayStreamModels
{
    public class PlayerSetProfilePropertyEventData : PlayStreamEventBase
	{
		public PlayerProfileProperty? Property;

		public string TitleId;

		public object Value;
	}
}
