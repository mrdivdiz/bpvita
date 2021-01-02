using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener : Singleton<KeyListener>
{
	public static event Action<KeyCode> keyPressed;

	public static event Action<KeyCode> keyReleased;

	public static event Action<KeyCode> keyHold;

	public static event Action<float> mouseWheel;

	public void GrabFocus(object obj)
	{
		KeyListener.focusCount++;
		this.m_focusQueue.Add(obj);
	}

	public void ReleaseFocus(object obj)
	{
		KeyListener.focusCount--;
		this.m_focusQueue.Remove(obj);
	}

	private bool HasFocus(object obj)
	{
		return this.m_focusQueue[this.m_focusQueue.Count - 1] == obj;
	}

	private void InvokeDelegates<T>(Action<T> multicastDelegate, T arg)
	{
		Delegate[] invocationList = multicastDelegate.GetInvocationList();
		if (this.m_focusQueue.Count == 0)
		{
			foreach (Delegate @delegate in invocationList)
			{
				((Action<T>)@delegate)(arg);
			}
		}
		else
		{
			foreach (Delegate delegate2 in invocationList)
			{
				if (this.HasFocus(delegate2.Target))
				{
					((Action<T>)delegate2)(arg);
					break;
				}
			}
		}
	}

	private void Update()
	{
		if (!Singleton<GuiManager>.Instance.IsEnabled)
		{
			return;
		}
		if (KeyListener.keyPressed != null || KeyListener.keyReleased != null || KeyListener.keyHold != null)
		{
			for (int i = 0; i < this.m_hotkeys.Count; i++)
			{
				KeyCode keyCode = this.m_hotkeys[i];
				if (Input.GetKeyUp(keyCode) && KeyListener.keyReleased != null)
				{
					this.InvokeDelegates(KeyListener.keyReleased, keyCode);
				}
				if (Input.GetKeyDown(keyCode) && KeyListener.keyPressed != null)
				{
					this.InvokeDelegates(KeyListener.keyPressed, keyCode);
				}
				if (Input.GetKey(keyCode) && KeyListener.keyHold != null)
				{
					this.InvokeDelegates(KeyListener.keyHold, keyCode);
				}
			}
		}
		if (KeyListener.mouseWheel != null)
		{
			float axisRaw = Input.GetAxisRaw("Mouse ScrollWheel");
			if (axisRaw != 0f)
			{
				this.InvokeDelegates(KeyListener.mouseWheel, axisRaw);
			}
		}
	}

	private void Awake()
	{
		base.SetAsPersistant();
	}

	public List<KeyCode> m_hotkeys;

	private List<object> m_focusQueue = new List<object>();

	private static int focusCount;
}
