public struct DragStartedEvent : EventManager.Event
{
	public DragStartedEvent(BasePart.PartType partType)
	{
		this.partType = partType;
	}

	public BasePart.PartType partType;
}
