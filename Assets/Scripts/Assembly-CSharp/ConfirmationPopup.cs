using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmationPopup : MonoBehaviour
{
	public event Action PopupClosed;

	public void DismissDialog()
	{
		base.gameObject.SetActive(false);
		if (this.PopupClosed != null)
		{
			this.PopupClosed();
		}
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
