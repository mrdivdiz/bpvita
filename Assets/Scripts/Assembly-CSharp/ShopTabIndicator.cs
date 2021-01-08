using UnityEngine;

public class ShopTabIndicator : MonoBehaviour
{
	private void OnEnable()
	{
		this.UpdateInidicator(IapManager.InAppPurchaseItemType.Undefined);
		IapManager.onPurchaseSucceeded += this.UpdateInidicator;
	}

	private void OnDisable()
	{
		IapManager.onPurchaseSucceeded -= this.UpdateInidicator;
	}

	private void UpdateInidicator(IapManager.InAppPurchaseItemType type)
	{
		if (Singleton<IapManager>.IsInstantiated())
		{
			base.GetComponent<Renderer>().enabled = Singleton<IapManager>.Instance.IsItemPurchased(this.m_purchaseItem);
		}
	}

	public IapManager.InAppPurchaseItemType m_purchaseItem;
}
