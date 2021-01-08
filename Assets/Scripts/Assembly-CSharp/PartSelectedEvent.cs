public class PartSelectedEvent : EventManager.Event
{
	public PartSelectedEvent(BasePart.PartType type)
	{
		this.type = type;
	}

	public BasePart.PartType type;
}
