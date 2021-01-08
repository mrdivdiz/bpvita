public struct PartCountChanged : EventManager.Event
{
	public PartCountChanged(BasePart.PartType partType, int count)
	{
		this.partType = partType;
		this.count = count;
	}

	public BasePart.PartType partType;

	public int count;
}
