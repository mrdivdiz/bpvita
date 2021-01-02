using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseInfo : MonoBehaviour
{
	private void Start()
	{
        Sprite sprite = null;
        Sprite sprite2 = null;
		Transform transform = base.transform.Find("Icon");
		Transform transform2 = base.transform.Find("Deco");
		if (transform != null)
		{
			sprite = transform.GetComponent<Sprite>();
		}
		if (transform2 != null)
		{
			sprite2 = transform2.GetComponent<Sprite>();
		}
		if (sprite != null)
		{
			this.currentSpriteID = sprite.Id;
		}
		if (sprite2 != null)
		{
			this.currentEffectID = sprite2.Id;
		}
		this.countTf = base.transform.Find("Count");
		base.GetComponent<Collider>().enabled = false;
		this.SetCount(0, this.countTf);
		this.UpdateParameters();
		if (this.currencyType == IapManager.CurrencyType.RealMoney)
		{
			if (Singleton<IapManager>.IsInstantiated() && Singleton<IapManager>.Instance.PurchaseListInited)
			{
				this.UpdatePurchaseCount();
			}
			else
			{
				IapManager.onProductListParsed += this.UpdatePurchaseCount;
			}
		}
		else if (Singleton<VirtualCatalogManager>.IsInstantiated() && Singleton<VirtualCatalogManager>.Instance.HasCatalog)
		{
			this.UpdatePurchaseCount();
		}
		else
		{
			VirtualCatalogManager.onVirtualProductListParsed += this.UpdatePurchaseCount;
		}
		IapManager.onPurchaseSucceeded += this.OnPurchaseSucceeded;
	}

	private void OnDestroy()
	{
		IapManager.onProductListParsed -= this.UpdatePurchaseCount;
		VirtualCatalogManager.onVirtualProductListParsed -= this.UpdatePurchaseCount;
		if (this.offerTimeLocalizer != null)
		{
			this.offerTimeLocalizer.Dispose();
		}
		IapManager.onPurchaseSucceeded -= this.OnPurchaseSucceeded;
	}

	private void UpdateParameters()
	{
		Button component = base.GetComponent<Button>();
		if (component)
		{
			string text = (!this.isSaleItem) ? this.purchaseItem.ToString() : this.saleItem.ToString();
			List<MethodCaller.Parameter> parametersForInspector = component.MethodToCall.GetParametersForInspector();
			int count = parametersForInspector.Count;
			if (count == 4 && parametersForInspector[3].type != null)
			{
				component.MethodToCall.SetParameters(new object[]
				{
					text,
					this.currentSpriteID,
					this.currentEffectID,
					this.currentCount
				});
			}
			else if (count >= 3 && parametersForInspector[2].type != null)
			{
				component.MethodToCall.SetParameters(new object[]
				{
					text,
					this.currentSpriteID,
					this.currentCount
				});
			}
			else if (count >= 2 && parametersForInspector[1].type != null)
			{
				component.MethodToCall.SetParameters(new string[]
				{
					text,
					this.currentSpriteID
				});
			}
			else if (count >= 1 && parametersForInspector[0].type != null)
			{
				component.MethodToCall.SetParameter(text);
			}
		}
	}

	private void UpdatePurchaseCount()
	{
		if (this.currencyType == IapManager.CurrencyType.RealMoney)
		{
			if (Singleton<IapManager>.Instance.IsBundleProduct(this.purchaseItem))
			{
				if (Singleton<IapManager>.Instance.HasBundleInfo(this.purchaseItem))
				{
					using (IEnumerator<IapManager.BundleItem> enumerator = Singleton<IapManager>.Instance.GetBundleInfo(this.purchaseItem).GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							IapManager.BundleItem bundleItem = enumerator.Current;
							this.SetCount(bundleItem.count, this.countTf);
						}
					}
				}
				else
				{
					int num = 0;
					string[] names = Enum.GetNames(typeof(IapManager.BundleItem.BundleItemType));
					for (int i = 0; i < names.Length; i++)
					{
						num++;
					}
					if (num > 0)
					{
						this.SetCount(0, this.countTf);
					}
				}
			}
			else
			{
				this.currentCount = Singleton<IapManager>.Instance.GetPurchaseItemTypeCount(this.purchaseItem);
				this.SetCount(this.currentCount, this.countTf);
			}
		}
		else
		{
			Hashtable productRewards = Singleton<VirtualCatalogManager>.Instance.GetProductRewards(this.purchaseItem);
			if (productRewards != null)
			{
				IDictionaryEnumerator enumerator2 = productRewards.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object obj = enumerator2.Current;
						DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
						if (Enum.IsDefined(typeof(IapManager.BundleItem.BundleItemType), (string)dictionaryEntry.Key))
						{
							this.currentCount = int.Parse((string)dictionaryEntry.Value);
							this.SetCount(this.currentCount, this.countTf);
							break;
						}
						if (dictionaryEntry.Key.Equals("WoodenCrate"))
						{
							this.SetCount(1, this.countTf);
							break;
						}
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			else
			{
				this.SetCount(0, this.countTf);
			}
		}
		this.UpdateParameters();
	}

	private void SetCount(int count, Transform countTrans)
	{
		if (count > 0 || this.currencyType != IapManager.CurrencyType.SnoutCoin)
		{
			base.GetComponent<Collider>().enabled = this.colliderEnabled;
			if (countTrans)
			{
				countTrans.GetComponent<SpriteText>().Text = ((count != 0) ? ("x" + count.ToString()) : string.Empty);
			}
		}
		else
		{
			base.GetComponent<Collider>().enabled = false;
			if (countTrans)
			{
				countTrans.GetComponent<SpriteText>().Text = string.Empty;
			}
		}
	}

	public void EnableCollider(bool enable = true)
	{
		this.colliderEnabled = enable;
	}

	public void Show(bool show)
	{
		base.gameObject.SetActive(show);
		if (base.transform.parent != null)
		{
			base.transform.parent.position += Vector3.right * ((!show) ? this.xOffsetOnDisable : (-this.xOffsetOnDisable));
		}
	}

	public void Purchase()
	{
		EventManager.Send(new IapManager.PurchaseEvent((!this.isSaleItem) ? this.purchaseItem : this.saleItem));
	}

	private void OnPurchaseSucceeded(IapManager.InAppPurchaseItemType type)
	{
		if (!string.IsNullOrEmpty(this.currentSaleKey) && type == this.saleItem)
		{
			GameProgress.SetBool(this.currentSaleKey + "_used", true, GameProgress.Location.Local);
		}
	}

	public void CheckOnSale()
	{
		int num;
		this.isSaleItem = this.IsSaleOn(this.saleItem.ToString(), out num);
		if (this.isSaleItem && base.transform.parent != null && base.transform.parent.parent != null)
		{
			Transform transform = base.transform.parent.parent.Find("OfferBanner/OfferText");
			TextMesh textMesh = null;
			if (transform != null)
			{
				textMesh = transform.GetComponent<TextMesh>();
			}
			if (textMesh != null)
			{
				if (this.offerTimeLocalizer == null)
				{
					this.offerTimeLocalizer = new RefreshLocalizer(textMesh);
				}
				int days = num / 86400;
				int hours = num % 86400 / 3600;
				this.offerTimeLocalizer.Update = delegate()
				{
					if (days > 0)
					{
						return string.Format("{0}d {1}h", days, hours);
					}
					return string.Format("{0}h", hours);
				};
				this.offerTimeLocalizer.Refresh();
			}
		}
	}

	private bool IsSaleOn(string saleItemKey, out int saleLeft)
	{
		GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
		ConfigData config = instance.GetConfig("iap_sale_items");
		if (!Singleton<IapManager>.Instance.HasProduct(this.saleItem))
		{
			saleLeft = -1;
			return false;
		}
		if (config != null)
		{
			for (int i = 0; i < config.Keys.Length; i++)
			{
				if (config.Keys[i].StartsWith(saleItemKey))
				{
					string[] array = config[config.Keys[i]].Split(new char[]
					{
						'-'
					});
					int saleTimeLeft = Shop.GetSaleTimeLeft(array[0], (array.Length <= 1) ? string.Empty : array[1]);
					if (saleTimeLeft > 0 && !GameProgress.GetBool(config.Keys[i] + "_used", false, GameProgress.Location.Local, null))
					{
						saleLeft = saleTimeLeft;
						this.currentSaleKey = config.Keys[i];
						return true;
					}
				}
			}
		}
		saleLeft = -1;
		return false;
	}

	public IapManager.InAppPurchaseItemType purchaseItem;

	public IapManager.InAppPurchaseItemType saleItem;

	public IapManager.CurrencyType currencyType = IapManager.CurrencyType.SnoutCoin;

	public bool doUpdatePrice = true;

	public bool isSaleItem;

	public float xOffsetOnDisable;

	private int currentCount;

	private string currentSpriteID = string.Empty;

	private string currentEffectID = string.Empty;

	private Transform countTf;

	private bool colliderEnabled = true;

	private RefreshLocalizer offerTimeLocalizer;

	private string currentSaleKey = string.Empty;
}
