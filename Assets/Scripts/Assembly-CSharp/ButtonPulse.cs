using System;
using UnityEngine;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animation))]
public class ButtonPulse : MonoBehaviour
{
	private void Awake()
	{
		this.Initialize();
	}

	private void Initialize()
	{
		if (this.m_initialized)
		{
			return;
		}
		this.m_button = base.GetComponent<Button>();
		this.m_button.SetInputDelegate(new Button.InputDelegate(this.OnButtonInput));
		this.m_animation = base.GetComponent<Animation>();
		if (this.m_button.EventToSend.EventName == "UIEvent")
		{
			this.m_buttonEvent = (UIEvent.Type)Enum.Parse(typeof(UIEvent.Type), this.m_button.EventToSend.GetParameters()[0].stringValue);
		}
		EventManager.Connect(new EventManager.OnEvent<PulseButtonEvent>(this.ReceivePulseButtonEvent));
		this.m_initialized = true;
	}

	private void OnEnable()
	{
		if (this.m_playAutomatically)
		{
			this.ReceivePulseButtonEvent(new PulseButtonEvent(this.m_buttonEvent, true));
		}
	}

	private void OnDisable()
	{
		EventManager.Disconnect(new EventManager.OnEvent<PulseButtonEvent>(this.ReceivePulseButtonEvent));
	}

	private void OnButtonInput(InputEvent input)
	{
		this.m_animation.Stop();
	}

	public void Pulse()
	{
		this.Initialize();
		this.m_animation.Play(this.m_animationName);
	}

	public void StopPulse()
	{
		EventManager.Send(new PulseButtonEvent(this.m_buttonEvent, false));
	}

	private void ReceivePulseButtonEvent(PulseButtonEvent data)
	{
		if (data.buttonEvent == this.m_buttonEvent)
		{
			if (data.pulse)
			{
				this.m_animation.Play(this.m_animationName);
			}
			else
			{
				this.m_animation.Stop();
			}
		}
	}

	public string m_animationName = "ButtonPulse";

	public bool m_playAutomatically;

	private Button m_button;

	private UIEvent.Type m_buttonEvent;

	private Animation m_animation;

	private bool m_initialized;
}
