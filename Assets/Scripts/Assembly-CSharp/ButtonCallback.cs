using System;
using UnityEngine;

public class ButtonCallback : MonoBehaviour
{
	public void OkButtonPressed()
	{
		if (this.onOkCallback != null)
		{
			this.onOkCallback();
		}
	}

	public void CancelButtonPressed()
	{
		if (this.onCancelCallback != null)
		{
			this.onCancelCallback();
		}
	}

	public Action onOkCallback;

	public Action onCancelCallback;
}
