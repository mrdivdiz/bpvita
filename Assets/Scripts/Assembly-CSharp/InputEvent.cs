using UnityEngine;

public struct InputEvent
{
	public InputEvent(EventType type, Vector3 position)
	{
		this.type = type;
		this.position = position;
	}

	public EventType type;

	public Vector3 position;

	public enum EventType
	{
		Press,
		Release,
		MouseEnter,
		MouseLeave,
		MouseReturn,
		Drag
	}
}
