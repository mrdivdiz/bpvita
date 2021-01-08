using UnityEngine;

public class UnlockRoadHogsParts : TextDialog
{
	public string Cost
	{
		set
		{
			this.enabledOkButtonText.text = value;
			this.disabledOkButtonText.text = value;
		}
	}

	protected override void OnEnable()
	{
		Singleton<KeyListener>.Instance.GrabFocus(this);
		KeyListener.keyReleased += base.HandleKeyReleased;
		EventManager.Send(new UIEvent(UIEvent.Type.OpenedPurchaseRoadHogsParts));
		base.EnableConfirmButton();
		TextDialog.s_dialogOpen = true;
	}

	protected override void OnDisable()
	{
		this.isOpened = false;
		if (Singleton<KeyListener>.Instance)
		{
			Singleton<KeyListener>.Instance.ReleaseFocus(this);
		}
		KeyListener.keyReleased -= base.HandleKeyReleased;
		EventManager.Send(new UIEvent(UIEvent.Type.ClosedPurchaseRoadHogsParts));
		TextDialog.s_dialogOpen = false;
	}

	public new void Open()
	{
		base.Open();
	}

	public new void Close()
	{
		base.Close();
	}

	public new void Confirm()
	{
		base.Confirm();
	}

	public new void OpenShop()
	{
		base.OpenShop();
	}

	[SerializeField]
	private TextMesh enabledOkButtonText;

	[SerializeField]
	private TextMesh disabledOkButtonText;
}
