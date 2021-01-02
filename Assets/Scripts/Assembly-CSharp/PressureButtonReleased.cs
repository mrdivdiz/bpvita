public struct PressureButtonReleased : EventManager.Event
{
	public PressureButtonReleased(int _id)
	{
		this.id = _id;
	}

	public int id;
}
