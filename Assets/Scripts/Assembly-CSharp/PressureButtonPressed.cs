public struct PressureButtonPressed : EventManager.Event
{
	public PressureButtonPressed(int _id)
	{
		this.id = _id;
	}

	public int id;
}
