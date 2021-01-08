using UnityEngine;

public class InGameInAppPurchaseMenu : MonoBehaviour
{
	public event OnClose onClose;

	private void Awake()
	{
		this.m_dialog = base.transform.Find("Dialog").GetComponent<Dialog>();
		this.m_loader = base.transform.Find("Dialog").Find("PurchaseLoader").gameObject;
		this.m_loader.SetActive(false);
		if (this.m_dialog)
		{
			this.m_dialog.Close();
		}
	}

	private void OnCloseFbLikeDialog()
	{
		if (this.onClose != null)
		{
			this.onClose();
			this.onClose = null;
		}
	}

	private void OnCloseDialog()
	{
		if (this.onClose != null)
		{
			this.onClose();
			this.onClose = null;
		}
	}

	private void OnEnable()
	{
		IapManager.onPurchaseSucceeded += this.HandleIapManageronPurchaseSucceeded;
		IapManager.onPurchaseFailed += this.HandleIapManageronPurchaseFailed;
		if (this.m_dialog)
		{
			this.m_dialog.onClose += this.OnCloseDialog;
		}
	}

	private void OnDisable()
	{
		IapManager.onPurchaseSucceeded -= this.HandleIapManageronPurchaseSucceeded;
		IapManager.onPurchaseFailed -= this.HandleIapManageronPurchaseFailed;
		if (this.m_dialog)
		{
			this.m_dialog.onClose -= this.OnCloseDialog;
		}
	}

	public void PurchaseBlueprintPackSmall()
	{
		this.Purchase(IapManager.InAppPurchaseItemType.BlueprintSmall);
	}

	public void PurchaseBlueprintPackMedium()
	{
		this.Purchase(IapManager.InAppPurchaseItemType.BlueprintMedium);
	}

	public void PurchaseBlueprintPackLarge()
	{
		this.Purchase(IapManager.InAppPurchaseItemType.BlueprintLarge);
	}

	public void PurchaseUnlockFullVersion()
	{
		this.Purchase(IapManager.InAppPurchaseItemType.UnlockFullVersion);
	}

	public void PurchaseSpecialSandbox()
	{
		this.Purchase(IapManager.InAppPurchaseItemType.UnlockSpecialSandbox);
	}

	private void Purchase(IapManager.InAppPurchaseItemType type)
	{
		this.m_loader.SetActive(true);
		Singleton<IapManager>.Instance.PurchaseItem(type);
	}

	public void OpenDialog()
	{
		this.SetVisible(true);
	}

	private void HandleIapManageronPurchaseSucceeded(IapManager.InAppPurchaseItemType type)
	{
		this.SetVisible(false);
	}

	private void HandleIapManageronPurchaseFailed(IapManager.InAppPurchaseItemType type)
	{
		this.m_loader.SetActive(false);
	}

	public void SetVisible(bool visible)
	{
		if (visible)
		{
			if (this.m_dialog)
			{
				this.m_dialog.Open();
			}
			this.m_loader.SetActive(!visible);
		}
		else if (this.m_dialog)
		{
			this.m_dialog.Close();
		}
		if (!visible && this.onClose != null)
		{
			this.onClose();
			this.onClose = null;
		}
	}

	private GameObject m_loader;

	private Dialog m_dialog;

	public delegate void OnClose();
}
