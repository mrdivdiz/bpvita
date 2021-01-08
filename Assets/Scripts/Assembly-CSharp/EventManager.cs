using System;
using System.Collections;
using UnityEngine;

public static class EventManager
{
	public static void Send<T>(T data) where T : Event
    {
        OnEvent<T> handler = EventManager.EventTypeManager<T>.handler;
		if (handler != null)
		{
			handler(data);
		}
	}

	public static void Connect<T>(OnEvent<T> handler) where T : Event
    {
		EventManager.EventTypeManager<T>.handler = (OnEvent<T>)Delegate.Combine(EventManager.EventTypeManager<T>.handler, handler);
	}

	public static void Disconnect<T>(OnEvent<T> handler) where T : Event
    {
		EventManager.EventTypeManager<T>.handler = (OnEvent<T>)Delegate.Remove(EventManager.EventTypeManager<T>.handler, handler);
	}

	public static void SendOnNextUpdate<T>(MonoBehaviour sender, T data) where T : Event
    {
		sender.StartCoroutine(EventManager.SendCoroutine<T>(data));
	}

	public static IEnumerator SendCoroutine<T>(T data) where T : Event
    {
		yield return 0;
		EventManager.Send<T>(data);
		yield break;
	}

	public delegate void OnEvent<T>(T data) where T : Event;

	public interface Event
	{
	}

	private class EventTypeManager<T> where T : Event
    {
		public static OnEvent<T> handler;
	}
}
