public class PlayerChangedEvent : EventManager.Event
{
	public PlayerChangedEvent(string playerName)
	{
		this.playerName = playerName;
	}

	public string playerName;
}
