public struct GameTimePaused : EventManager.Event
{
	public GameTimePaused(bool paused)
	{
		this.paused = paused;
	}

	public bool paused;
}
