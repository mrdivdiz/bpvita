public struct PulseButtonEvent : EventManager.Event
{
	public PulseButtonEvent(UIEvent.Type buttonEvent, bool pulse = true)
	{
		this.buttonEvent = buttonEvent;
		this.pulse = pulse;
	}

	public UIEvent.Type buttonEvent;

	public bool pulse;
}
