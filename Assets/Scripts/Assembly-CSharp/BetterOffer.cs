using System;
using UnityEngine;

public class BetterOffer : MonoBehaviour
{
	private void Awake()
	{
		this.textMeshes = base.GetComponentsInChildren<TextMesh>();
	}

	private void Start()
	{
		string arg = string.Format("{0:0%}", this.CalculatePercentage());
		for (int i = 0; i < this.textMeshes.Length; i++)
		{
			TextMeshLocale component = this.textMeshes[i].gameObject.GetComponent<TextMeshLocale>();
			component.RefreshTranslation(null);
			component.enabled = false;
			this.textMeshes[i].text = string.Format(this.textMeshes[i].text, arg);
		}
	}

	private float CalculatePercentage()
	{
		this.purchaseInfo.CheckOnSale();
		IapManager.InAppPurchaseItemType inAppPurchaseItemType = (!this.purchaseInfo.isSaleItem) ? this.purchaseInfo.purchaseItem : this.purchaseInfo.saleItem;
		float num = (float)Singleton<IapManager>.Instance.GetPurchaseItemTypeCount(inAppPurchaseItemType);
		float num2 = (float)Singleton<IapManager>.Instance.GetPurchaseItemTypeCount(this.compareType);
		float price = this.GetPrice(inAppPurchaseItemType);
		float price2 = this.GetPrice(this.compareType);
		if (num == 0f || num2 == 0f || price == 0f || price2 == 0f)
		{
			return 0f;
		}
		return num / price / (num2 / price2) - 1f;
	}

	private float GetPrice(IapManager.InAppPurchaseItemType item)
	{
		if (!Singleton<IapManager>.IsInstantiated() || !Singleton<IapManager>.Instance.ReadyForTransaction)
		{
			return 0f;
		}
		string prodId = Singleton<IapManager>.Instance.GetProductIdByItem(item);
		if (!string.IsNullOrEmpty(prodId))
		{
            IAPProductInfo iapproductInfo = null;
            foreach (IAPProductInfo x in Singleton<IapManager>.Instance.ProductList)
            {
                if(x.productId == prodId)
                {
                    iapproductInfo = x;
                    break;
                }
            }
            if (iapproductInfo == null)
            {
                return 0f;
            }
			string s = (!string.IsNullOrEmpty(iapproductInfo.unformattedPrice)) ? iapproductInfo.unformattedPrice : iapproductInfo.formattedPrice;
			try
			{
				return float.Parse(s);
			}
			catch
			{
				return 0f;
			}
		}
		return 0f;
	}

	[SerializeField]
	private PurchaseInfo purchaseInfo;

	[SerializeField]
	private IapManager.InAppPurchaseItemType compareType = IapManager.InAppPurchaseItemType.SnoutCoinPackSmall;

	private TextMesh[] textMeshes;
}
