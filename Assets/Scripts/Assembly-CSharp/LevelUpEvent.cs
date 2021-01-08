public class LevelUpEvent : EventManager.Event
{
	public LevelUpEvent(int newLevel)
	{
		this.newLevel = newLevel;
	}

	public int newLevel;
}
