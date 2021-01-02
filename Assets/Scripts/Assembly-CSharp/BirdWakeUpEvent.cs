public struct BirdWakeUpEvent : EventManager.Event
{
	public BirdWakeUpEvent(Bird bird)
	{
		this.bird = bird;
	}

	public Bird bird;
}
