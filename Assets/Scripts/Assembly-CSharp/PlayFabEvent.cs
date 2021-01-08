public struct PlayFabEvent : EventManager.Event
{
	public PlayFabEvent(Type type)
	{
		this.type = type;
	}

	public Type type;

	public enum Type
	{
		None,
		UserDataUploadStarted,
		UserDataUploadEnded,
		UserDeltaChangeUploadStarted,
		UserDeltaChangeUploadEnded,
		LocalDataUpdated
	}
}
