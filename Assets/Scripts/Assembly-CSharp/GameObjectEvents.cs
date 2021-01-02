using System;
using UnityEngine;

public class GameObjectEvents : MonoBehaviour
{
	private void OnEnable()
	{
		if (this.OnEnabled != null)
		{
			this.OnEnabled(true);
		}
	}

	private void OnDisable()
	{
		if (this.OnEnabled != null)
		{
			this.OnEnabled(false);
		}
	}

	private void OnBecameVisible()
	{
		if (this.OnVisible != null)
		{
			this.OnVisible(true);
		}
	}

	private void OnBecameInvisible()
	{
		if (this.OnVisible != null)
		{
			this.OnVisible(false);
		}
	}

	public Action<bool> OnVisible;

	public Action<bool> OnEnabled;
}
