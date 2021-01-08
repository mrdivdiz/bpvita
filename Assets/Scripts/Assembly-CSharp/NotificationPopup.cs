using UnityEngine;

public class NotificationPopup : TextDialog
{
	protected override void OnEnable()
	{
		base.OnEnable();
		EventManager.Send(new UIEvent(UIEvent.Type.OpenedNotificationPopup));
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		EventManager.Send(new UIEvent(UIEvent.Type.ClosedNotificationPopup));
	}

	public void SetText(string message)
	{
		TextMesh[] componentsInChildren = this.m_text.GetComponentsInChildren<TextMesh>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].text = message;
		}
		TextMeshLocale[] componentsInChildren2 = this.m_text.GetComponentsInChildren<TextMeshLocale>();
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			componentsInChildren2[j].RefreshTranslation(null);
		}
	}

	public new void Close()
	{
		base.Close();
	}

	[SerializeField]
	private GameObject m_text;
}
