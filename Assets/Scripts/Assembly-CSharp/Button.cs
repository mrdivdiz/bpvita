using System;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Button : Widget
{
	public EventSender EventToSend
	{
		get
		{
			return this.eventToSend;
		}
	}

	public MethodCaller MethodToCall
	{
		get
		{
			return this.methodToCall;
		}
	}

	public void Lock(bool lockState)
	{
		this.m_locked = lockState;
	}

	public void SetInputDelegate(InputDelegate handler)
	{
		this.m_inputDelegate = (InputDelegate)Delegate.Combine(this.m_inputDelegate, handler);
	}

	public void RemoveInputDelegate(InputDelegate handler)
	{
		this.m_inputDelegate = (InputDelegate)Delegate.Remove(this.m_inputDelegate, handler);
	}

	public void SetActivateOnRelease(bool activate)
	{
		this.activateOnRelease = activate;
	}

	private void Awake()
	{
		this.originalScale = base.transform.localScale;
		this.BindTarget();
		this.methodToCall.PrepareCall();
		this.eventToSend.PrepareSend();
		this.ButtonAwake();
		if (this.activateOnHold)
		{
			this.activateOnRelease = false;
		}
		if (this.activateOnPress)
		{
			this.activateOnRelease = false;
		}
		if (this.soundEffect == null && !this.disableSound)
		{
			this.soundEffect = Singleton<GuiManager>.Instance.DefaultButtonAudio;
		}
	}

	protected virtual void ButtonAwake()
	{
	}

	private void BindTarget()
	{
	}

	protected override void OnActivate()
	{
		if (this.eventToSend.HasEvent())
		{
			this.eventToSend.Send();
		}
		if (this.methodToCall.TargetComponent != null)
		{
			this.methodToCall.Call();
		}
	}

	protected override void OnInput(InputEvent input)
	{
		AudioManager instance = Singleton<AudioManager>.Instance;
		if (input.type == InputEvent.EventType.Press)
		{
			this.mouseOver = true;
			this.down = true;
			if (this.activateOnPress)
			{
				if (this.animate && this.soundEffect)
				{
					instance.Play2dEffect(this.soundEffect);
				}
				if (!this.m_locked)
				{
					base.Activate();
				}
			}
		}
		else if (input.type == InputEvent.EventType.Release)
		{
			this.down = false;
			if (this.activateOnRelease)
			{
				if (this.animate && this.soundEffect)
				{
					instance.Play2dEffect(this.soundEffect);
				}
				if (!this.m_locked)
				{
					base.Activate();
				}
			}
			if (this.activateOnPress)
			{
				base.Release();
			}
		}
		else if (input.type == InputEvent.EventType.MouseEnter)
		{
			this.mouseOver = true;
		}
		else if (input.type == InputEvent.EventType.MouseReturn)
		{
			this.down = true;
			if (this.activateOnPress)
			{
				base.Activate();
			}
		}
		else if (input.type == InputEvent.EventType.MouseLeave)
		{
			if (this.activateOnPress && this.down)
			{
				base.Release();
			}
			this.mouseOver = false;
			this.down = false;
		}
		if (this.m_inputDelegate != null)
		{
			this.m_inputDelegate(input);
		}
	}

	private void Update()
	{
		if (this.activateOnHold && this.down && !this.m_locked)
		{
			base.Activate();
		}
		if (this.animate)
		{
			bool flag = !this.down && this.mouseOver;
			if (DeviceInfo.UsesTouchInput)
			{
				flag = (this.down || this.mouseOver);
			}
			float num = base.transform.localScale.x / this.originalScale.x;
			if (flag && num < this.mouseOverScale)
			{
				num = Mathf.Min(num + GameTime.RealTimeDelta * 7f, this.mouseOverScale);
				base.transform.localScale = num * this.originalScale;
			}
			else if (!flag && num > 1f)
			{
				num = Mathf.Max(num - GameTime.RealTimeDelta * 7f, 1f);
				base.transform.localScale = num * this.originalScale;
			}
		}
		this.ButtonUpdate();
	}

	protected virtual void ButtonUpdate()
	{
	}

	[SerializeField]
	private MethodCaller methodToCall;

	[SerializeField]
	private GameObject messageTargetObject;

	[SerializeField]
	private string targetComponent;

	[SerializeField]
	private string methodToInvoke;

	[SerializeField]
	private string messageParameter;

	[SerializeField]
	private EventSender eventToSend = new EventSender();

	[SerializeField]
	private bool animate = true;

	[SerializeField]
	private float mouseOverScale = 1.2f;

	[SerializeField]
	private bool activateOnHold;

	[SerializeField]
	private bool activateOnPress;

	[SerializeField]
	protected AudioSource soundEffect;

	[SerializeField]
	private bool disableSound;

	private Component component;

	private MethodInfo methodInfo;

	private object[] parameterArray;

	private bool mouseOver;

	private bool down;

	private const float HoverSoundDelay = 0.15f;

	private Vector3 originalScale;

	private InputDelegate m_inputDelegate;

	private bool activateOnRelease = true;

	private bool m_locked;

	public delegate void InputDelegate(InputEvent input);
}
