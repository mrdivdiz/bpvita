using UnityEngine;

public class OpenIapDialog : MonoBehaviour
{
	private void Start()
	{
		this.m_iapMenu.OpenDialog();
	}

	public InGameInAppPurchaseMenu m_iapMenu;
}
