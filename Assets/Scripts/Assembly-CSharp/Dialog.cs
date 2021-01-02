using UnityEngine;

public class Dialog : MonoBehaviour
{
	public event OnClose onClose;

	public event OnOpen onOpen;

	public void Open()
	{
		base.gameObject.SetActive(true);
		if (this.onOpen != null)
		{
			this.onOpen();
		}
	}

	public void Close()
	{
		base.gameObject.SetActive(false);
		if (this.onClose != null)
		{
			this.onClose();
		}
	}

	private void OnEnable()
	{
		Singleton<GuiManager>.Instance.GrabPointer(this);
		Singleton<KeyListener>.Instance.GrabFocus(this);
		KeyListener.keyReleased += this.HandleKeyReleased;
	}

	private void OnDisable()
	{
		Singleton<GuiManager>.Instance.ReleasePointer(this);
		Singleton<KeyListener>.Instance.ReleaseFocus(this);
		KeyListener.keyReleased -= this.HandleKeyReleased;
	}

	private void HandleKeyReleased(KeyCode obj)
	{
		if (obj == KeyCode.Escape)
		{
			this.Close();
		}
	}

	public delegate void OnClose();

	public delegate void OnOpen();
}
