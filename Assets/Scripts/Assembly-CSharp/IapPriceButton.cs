using System.Collections.Generic;
using UnityEngine;

public class IapPriceButton : MonoBehaviour
{
	private void FetchProductInfo()
	{
		if (Singleton<IapManager>.IsInstantiated())
		{
			if (!this.isProductListHandlerAttached)
			{
				IapManager.onProductListReceived += this.OnProductListReceived;
				this.isProductListHandlerAttached = true;
			}
			this.SetPriceIndicator(Shop.PriceIndicator.Loading, null);
			if (Singleton<IapManager>.Instance.Status != IapManager.InAppPurchaseStatus.FetchingItems)
			{
				Singleton<IapManager>.Instance.FetchPurchasableItemList();
			}
		}
	}

	private void OnEnable()
	{
		if (!Singleton<IapManager>.IsInstantiated())
		{
			this.SetPriceIndicator(Shop.PriceIndicator.NotConnected, null);
		}
		else if (Singleton<IapManager>.Instance.IsItemPurchased(this.m_purchaseType))
		{
			this.SetPriceIndicator(Shop.PriceIndicator.Purchased, null);
		}
		else if (Singleton<IapManager>.Instance.ProductList == null)
		{
			this.FetchProductInfo();
		}
		else
		{
			string prodId = Singleton<IapManager>.Instance.GetProductIdByItem(this.m_purchaseType);
			IAPProductInfo iapproductInfo = null;
			if (!string.IsNullOrEmpty(prodId))
			{
                foreach (IAPProductInfo x in Singleton<IapManager>.Instance.ProductList)
                {
                    if (x.productId == prodId)
                    {
                        iapproductInfo = x;
                        break;
                    }
                }
            }
			if (Singleton<IapManager>.Instance.IsItemPurchased(this.m_purchaseType))
			{
				this.SetPriceIndicator(Shop.PriceIndicator.Purchased, null);
			}
			else if (iapproductInfo != null && !string.IsNullOrEmpty(iapproductInfo.formattedPrice))
			{
				this.SetPriceIndicator(Shop.PriceIndicator.Price, iapproductInfo.formattedPrice);
			}
			else
			{
				this.SetPriceIndicator(Shop.PriceIndicator.NotConnected, null);
			}
		}
		IapManager.onPurchaseSucceeded += this.UnlockScreen;
		IapManager.onPurchaseFailed += this.UnlockScreen;
	}

	private void OnDisable()
	{
		if (this.isProductListHandlerAttached)
		{
			IapManager.onProductListReceived -= this.OnProductListReceived;
			this.isProductListHandlerAttached = false;
		}
		IapManager.onPurchaseSucceeded -= this.UnlockScreen;
		IapManager.onPurchaseFailed -= this.UnlockScreen;
	}

	private void LockScreen()
	{
		this.m_LockOverlay.SetActive(true);
		Singleton<GuiManager>.Instance.IsEnabled = false;
	}

	private void UnlockScreen(IapManager.InAppPurchaseItemType type = IapManager.InAppPurchaseItemType.Undefined)
	{
		this.m_LockOverlay.SetActive(false);
		Singleton<GuiManager>.Instance.IsEnabled = true;
	}

	private void SetPriceIndicator(Shop.PriceIndicator indicatorType, string formattedPrice = null)
	{
		if (indicatorType == Shop.PriceIndicator.Purchased)
		{
			this.m_loadingIndicator.gameObject.SetActive(false);
			this.m_notConnectedIndicator.gameObject.SetActive(false);
			this.m_priceText.GetComponent<Renderer>().enabled = false;
			this.m_purchasedIndicator.gameObject.SetActive(true);
			Button component = base.GetComponent<Button>();
			if (component)
			{
				UnityEngine.Object.Destroy(component);
			}
		}
		else
		{
			this.m_loadingIndicator.gameObject.SetActive(indicatorType == Shop.PriceIndicator.Loading);
			this.m_notConnectedIndicator.gameObject.SetActive(indicatorType == Shop.PriceIndicator.NotConnected);
			this.m_priceText.GetComponent<Renderer>().enabled = (indicatorType == Shop.PriceIndicator.Price);
		}
		if (formattedPrice != null)
		{
			this.m_priceText.GetComponent<TextMesh>().text = formattedPrice;
		}
	}

	private void OnProductListReceived(List<IAPProductInfo> products, string error)
	{
		if (products != null && products.Count > 0)
		{
			string prodId = Singleton<IapManager>.Instance.GetProductIdByItem(this.m_purchaseType);
            IAPProductInfo iapproductInfo = null;
            foreach (IAPProductInfo x in Singleton<IapManager>.Instance.ProductList)
            {
                if (x.productId == prodId)
                {
                    iapproductInfo = x;
                    break;
                }
            }
            if (iapproductInfo != null && string.IsNullOrEmpty(iapproductInfo.formattedPrice))
			{
				this.SetPriceIndicator(Shop.PriceIndicator.Price, iapproductInfo.formattedPrice);
			}
			else
			{
				this.SetPriceIndicator(Shop.PriceIndicator.NotConnected, null);
			}
		}
		else
		{
			this.SetPriceIndicator(Shop.PriceIndicator.NotConnected, null);
		}
	}

	private string GetFormattedPrice()
	{
		if (Singleton<IapManager>.Instance.ProductList != null)
		{
			string prodId = Singleton<IapManager>.Instance.GetProductIdByItem(this.m_purchaseType);
			if (!string.IsNullOrEmpty(prodId))
			{
                IAPProductInfo iapproductInfo = null;
                foreach (IAPProductInfo x in Singleton<IapManager>.Instance.ProductList)
                {
                    if (x.productId == prodId)
                    {
                        iapproductInfo = x;
                        break;
                    }
                }
                return (iapproductInfo == null || iapproductInfo.formattedPrice == null) ? null : Singleton<IapManager>.Instance.PreparePrice(iapproductInfo.formattedPrice);
			}
		}
		return null;
	}

	public void Purchase()
	{
		string formattedPrice = this.GetFormattedPrice();
		if (string.IsNullOrEmpty(formattedPrice))
		{
			this.FetchProductInfo();
		}
		else if (Singleton<IapManager>.IsInstantiated() && !Singleton<IapManager>.Instance.IsItemPurchased(this.m_purchaseType))
		{
			this.LockScreen();
			Singleton<IapManager>.Instance.PurchaseItem(this.m_purchaseType);
		}
	}

	public GameObject m_loadingIndicator;

	public GameObject m_notConnectedIndicator;

	public GameObject m_purchasedIndicator;

	public GameObject m_priceText;

	public GameObject m_LockOverlay;

	public IapManager.InAppPurchaseItemType m_purchaseType;

	private bool isProductListHandlerAttached;
}
