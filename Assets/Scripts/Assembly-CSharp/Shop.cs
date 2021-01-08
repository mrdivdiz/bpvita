using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Shop : WPFMonoBehaviour
{
	public SnoutCoinShopPopup SnoutCoinShop
	{
		get
		{
			return this.m_snoutCoinShop;
		}
	}

	private void Awake()
	{
		this.ShowOfferBanner(false);
		this.pageScroller = base.GetComponent<PageScroller>();
		this.pageScroller.PageCount = this.m_pages.Length;
		this.pageScroller.OnPageChanged += this.OnPageChanged;
		this.m_currentPage = 0;
		this.pageScroller.SetPage(this.m_currentPage);
		if (this.m_currentPage == 0)
		{
			this.OnPageChanged(-1, this.m_currentPage);
		}
		this.EnsureSnoutShop();
		this.m_BestValueRibbon.SetActive(false);
		this.m_MostPopularRibbon.SetActive(false);
		EventManager.Connect(new EventManager.OnEvent<IapManager.PurchaseEvent>(this.OnPurchaseItem));
		EventManager.Connect(new EventManager.OnEvent<LevelLoadedEvent>(this.OnLevelLoaded));
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.OnUIEvent));
		EventManager.Connect(new EventManager.OnEvent<PlayFabEvent>(this.OnPlayFabEvent));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<IapManager.PurchaseEvent>(this.OnPurchaseItem));
		EventManager.Disconnect(new EventManager.OnEvent<LevelLoadedEvent>(this.OnLevelLoaded));
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.OnUIEvent));
		EventManager.Disconnect(new EventManager.OnEvent<PlayFabEvent>(this.OnPlayFabEvent));
		if (this.subscribedToPurchaseEvents)
		{
			IapManager.onPurchaseSucceeded -= this.OnPurchaseSucceeded;
			IapManager.onPurchaseSucceeded -= this.UnlockScreen;
			IapManager.onPurchaseFailed -= this.UnlockScreen;
			IapManager.onRestorePurchaseComplete -= this.OnRestorePurchaseComplete;
			this.subscribedToPurchaseEvents = false;
		}
		if (this.m_LockOverlay != null)
		{
			UnityEngine.Object.Destroy(this.m_LockOverlay);
		}
	}

	private void OnLevelLoaded(LevelLoadedEvent data)
	{
		if (data.currentGameState == GameManager.GameState.MainMenu)
		{
			bool isGoldenLootCrateSale = this.IsSaleOn("GoldenLootCrateSale");
			bool flag = this.IsSaleOn("GoldenLootCratePack");
			bool isSnoutCoinPackMediumSale = this.IsSaleOn("SnoutCoinPackMediumSale");
			bool flag2 = this.IsSaleOn("SnoutCoinPackHugeSale");
			if (isSnoutCoinPackMediumSale || flag2)
			{
				DateTime minValue;
				if (!DateTime.TryParse(GameProgress.GetString("CoinCrazeSale_lastShown", DateTime.MinValue.ToShortDateString(), GameProgress.Location.Local, null), out minValue))
				{
					minValue = DateTime.MinValue;
				}
				if (DateTime.Today.Subtract(minValue).TotalHours > 12.0 && this.m_coinCrazePopupPrefab != null)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_coinCrazePopupPrefab, WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 2f, Quaternion.identity);
					TextDialog component = gameObject.GetComponent<TextDialog>();
					if (component != null)
					{
						this.waitingSalePopupAnswer = true;
						component.onClose += delegate ()
						{
							this.SendSalePopupFlurryEvent((!isSnoutCoinPackMediumSale) ? "SnoutCoinPackHugeSale" : "SnoutCoinPackMediumSale", "dismissed");
						};
						component.onShopPageOpened += delegate ()
						{
							this.SendSalePopupFlurryEvent((!isSnoutCoinPackMediumSale) ? "SnoutCoinPackHugeSale" : "SnoutCoinPackMediumSale", "went_to_shop");
						};
					}
					GameProgress.SetString("CoinCrazeSale_lastShown", DateTime.Today.ToShortDateString(), GameProgress.Location.Local);
				}
			}
			if (isGoldenLootCrateSale || flag)
			{
				DateTime minValue2;
				if (!DateTime.TryParse(GameProgress.GetString("CrateCrazeSale_lastShown", DateTime.MinValue.ToShortDateString(), GameProgress.Location.Local, null), out minValue2))
				{
					minValue2 = DateTime.MinValue;
				}
				double totalHours = minValue2.Subtract(DateTime.Now).TotalHours;
				if (totalHours > 12.0 && this.m_crateCrazePopupPrefab != null)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.m_crateCrazePopupPrefab, WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 5f, Quaternion.identity);
					TextDialog component2 = gameObject2.GetComponent<TextDialog>();
					if (component2 != null)
					{
						this.waitingSalePopupAnswer = true;
						component2.onClose += delegate ()
						{
							this.SendSalePopupFlurryEvent((!isGoldenLootCrateSale) ? "GoldenLootCratePack" : "GoldenLootCrateSale", "dismissed");
						};
						component2.onShopPageOpened += delegate ()
						{
							this.SendSalePopupFlurryEvent((!isGoldenLootCrateSale) ? "GoldenLootCratePack" : "GoldenLootCrateSale", "went_to_shop");
						};
					}
					GameProgress.SetString("CrateCrazeSale_lastShown", DateTime.Now.ToShortDateString(), GameProgress.Location.Local);
					Transform transform = gameObject2.transform.Find("Text_2");
					if (transform != null)
					{
						TextMesh component3 = transform.GetComponent<TextMesh>();
						TextMeshLocale component4 = transform.GetComponent<TextMeshLocale>();
						if (component3 != null && component4 != null)
						{
							if (flag)
							{
								component3.text = "CRATE_CRAZE_MESSAGE_02";
							}
							else if (isGoldenLootCrateSale)
							{
								component3.text = "CRATE_CRAZE_MESSAGE";
							}
							component4.RefreshTranslation(null);
						}
					}
				}
				this.ShowOfferBanner(true);
			}
		}
	}

	private void SendSalePopupFlurryEvent(string offerName, string action)
	{
	}

	private void HandleOnNotificationStatusChanged(bool enabled)
	{
	}

	private bool IsSaleOn(string identifier)
	{
		if (string.IsNullOrEmpty(identifier))
		{
			return false;
		}
		ConfigData config = Singleton<GameConfigurationManager>.Instance.GetConfig("iap_sale_items");
		if (config == null)
		{
			return false;
		}
		for (int i = 0; i < config.Count; i++)
		{
			if (config.Keys[i].StartsWith(identifier))
			{
				string text = config.Values[i];
				if (string.IsNullOrEmpty(text))
				{
					return false;
				}
				string[] array = text.Split(new char[]
				{
					'-'
				});
				if (array != null && array.Length > 0 && Shop.GetSaleTimeLeft(array[0], (array.Length <= 1) ? string.Empty : array[1]) > 0 && !GameProgress.GetBool(config.Keys[i] + "_used", false, GameProgress.Location.Local, null))
				{
					return true;
				}
			}
		}
		return false;
	}

	public void ShowOfferBanner(bool show)
	{
		if (this.m_offerBanner != null)
		{
			this.m_offerBanner.SetActive(show);
		}
	}

	public static DateTime ConvertStringToDate(string rawDate)
	{
		string[] formats = new string[]
		{
			"d.M.yy",
			"d.MM.yy",
			"dd.M.yy",
			"dd.MM.yy",
			"d.M.yyyy",
			"d.MM.yyyy",
			"dd.M.yyyy",
			"dd.MM.yyyy"
		};
		DateTime result;
		if (!string.IsNullOrEmpty(rawDate) && DateTime.TryParseExact(rawDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
		{
			return result;
		}
		return DateTime.MinValue;
	}

	public static int GetSaleTimeLeft(string saleStart, string saleEnd)
	{
		DateTime date = Shop.ConvertStringToDate(saleStart);
		DateTime date2 = Shop.ConvertStringToDate(saleEnd).AddDays(1.0);
		int num = TimeManager.ConvertDateTime2Seconds(date);
		int num2 = TimeManager.ConvertDateTime2Seconds(date2);
		if (num > 0 && num2 <= num)
		{
			num2 = num + 86400;
		}
		int currentEpochTime = Singleton<TimeManager>.Instance.CurrentEpochTime;
		if (num < currentEpochTime && num2 > currentEpochTime)
		{
			return num2 - currentEpochTime;
		}
		return -1;
	}

	private void Start()
	{
		if (Singleton<IapManager>.IsInstantiated() && !Singleton<IapManager>.Instance.UserInitiatedRestore)
		{
			base.transform.Find("RestoreButton").gameObject.SetActive(false);
		}
		this.isStarted = true;
		this.LayoutItems();
		this.m_confirmRestorePopup.transform.position = WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 5f;
		this.UpdateAllData();
	}

	private void EnsureSnoutShop()
	{
		if (this.m_snoutCoinShop == null && this.m_snoutCoinShopPrefab != null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_snoutCoinShopPrefab);
			gameObject.transform.parent = Singleton<IapManager>.Instance.transform;
			gameObject.transform.localPosition = Vector3.back * 6f;
			gameObject.name = this.m_snoutCoinShopPrefab.name;
			this.m_snoutCoinShop = gameObject.GetComponent<SnoutCoinShopPopup>();
			this.m_snoutCoinShop.UpdatePrices(this);
			gameObject.SetActive(false);
		}
	}

	private void OnEnable()
	{
		if (this.isStarted)
		{
			this.UpdateAllData();
		}
		if (!this.subscribedToPurchaseEvents)
		{
			IapManager.onPurchaseSucceeded += this.OnPurchaseSucceeded;
			IapManager.onPurchaseSucceeded += this.UnlockScreen;
			IapManager.onPurchaseFailed += this.UnlockScreen;
			IapManager.onRestorePurchaseComplete += this.OnRestorePurchaseComplete;
			this.subscribedToPurchaseEvents = true;
		}
		KeyListener.keyReleased += this.HandleKeyReleased;
		Singleton<KeyListener>.Instance.GrabFocus(this);
		this.UpdateLowerButtons(GameProgress.GetInt("LastShopPage", 0, GameProgress.Location.Local, null));
		this.UpdateBestPrices();
	}

	private void OnPlayFabEvent(PlayFabEvent data)
	{
		if (data.type == PlayFabEvent.Type.LocalDataUpdated)
		{
			this.UpdatePurchasedCounters();
		}
	}

	private void OnUIEvent(UIEvent data)
	{
		UIEvent.Type type = data.type;
		if (type != UIEvent.Type.OpenedSnoutCoinShop)
		{
			if (type == UIEvent.Type.ClosedSnoutCoinShop)
			{
				if (this.ducking)
				{
					base.gameObject.SetActive(true);
					this.ducking = false;
				}
			}
		}
		else if (base.gameObject.activeInHierarchy)
		{
			this.ducking = base.gameObject.activeInHierarchy;
			base.gameObject.SetActive(false);
		}
	}

	private void LockScreen()
	{
		this.m_LockOverlay.transform.parent = base.transform.parent;
		this.m_LockOverlay.SetActive(true);
		EventManager.Send(new UIEvent(UIEvent.Type.ShopLockedScreen));
	}

	public void UnlockScreen(IapManager.InAppPurchaseItemType type = IapManager.InAppPurchaseItemType.Undefined)
	{
		this.m_LockOverlay.SetActive(false);
		EventManager.Send(new UIEvent(UIEvent.Type.ShopUnlockedScreen));
	}

	private void UpdateAllData()
	{
		if (!this.isProductListHandlerAttached)
		{
			IapManager.onProductListReceived += this.OnProductListReceived;
			VirtualCatalogManager.onVirtualProductListParsed += this.OnVirtualProductListParsed;
			this.isProductListHandlerAttached = true;
		}
		if (Singleton<IapManager>.Instance.ProductList == null && Singleton<IapManager>.Instance.Status != IapManager.InAppPurchaseStatus.FetchingItems)
		{
			Singleton<IapManager>.Instance.FetchPurchasableItemList();
		}
		this.UpdatePrices(IapManager.CurrencyType.RealMoney, true);
		this.UpdatePurchasedCounters();
	}

	private void HandleKeyReleased(KeyCode keyCode)
	{
		if (keyCode == KeyCode.Escape && !this.m_LockOverlay.activeSelf)
		{
			this.Close();
		}
	}

	private void OnDisable()
	{
		if (this.isProductListHandlerAttached)
		{
			IapManager.onProductListReceived -= this.OnProductListReceived;
			VirtualCatalogManager.onVirtualProductListParsed -= this.OnVirtualProductListParsed;
			this.isProductListHandlerAttached = false;
		}
		if (this.subscribedToPurchaseEvents)
		{
			IapManager.onPurchaseSucceeded -= this.OnPurchaseSucceeded;
			IapManager.onPurchaseSucceeded -= this.UnlockScreen;
			IapManager.onPurchaseFailed -= this.UnlockScreen;
			IapManager.onRestorePurchaseComplete -= this.OnRestorePurchaseComplete;
			this.subscribedToPurchaseEvents = false;
		}
		KeyListener.keyReleased -= this.HandleKeyReleased;
		if (Singleton<KeyListener>.IsInstantiated())
		{
			Singleton<KeyListener>.Instance.ReleaseFocus(this);
		}
	}

	private void OnProductListReceived(List<IAPProductInfo> products, string error)
	{
		if (this.showFetchError && (products == null || products.Count == 0))
		{
			Singleton<IapManager>.Instance.ShowErrorPopup("IN_APP_PURCHASE_NOT_READY");
		}
		this.showFetchError = false;
		this.UpdatePrices(IapManager.CurrencyType.RealMoney, false);
		this.UpdatePurchasedCounters();
	}

	private void OnVirtualProductListParsed()
	{
		this.showFetchError = false;
		this.UpdatePrices(IapManager.CurrencyType.SnoutCoin, false);
		this.UpdatePurchasedCounters();
	}

	private void UpdateBestPrices()
	{
		List<ShopRibbon> list = new List<ShopRibbon>();
		Hashtable values = Singleton<GameConfigurationManager>.Instance.GetValues("shop_ribbons");
		if (values == null)
		{
			return;
		}
		IDictionaryEnumerator enumerator = values.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string[] array = dictionaryEntry.Key.ToString().Split(new char[]
				{
					'/'
				});
				if (array.Length >= 2)
				{
					ShopRibbon shopRibbon = new ShopRibbon();
					if (array[0].Equals("Android"))
					{
						shopRibbon.platform = RuntimePlatform.Android;
						shopRibbon.itemId = string.Empty;
						for (int i = 1; i < array.Length; i++)
						{
							if (i > 1)
							{
								ShopRibbon shopRibbon2 = shopRibbon;
								shopRibbon2.itemId += "/";
							}
							ShopRibbon shopRibbon3 = shopRibbon;
							shopRibbon3.itemId += array[i];
						}
						int num;
						if (int.TryParse(dictionaryEntry.Value.ToString(), out num) && Enum.IsDefined(typeof(ShopRibbon.Ribbon), num))
						{
							shopRibbon.ribbonType = (ShopRibbon.Ribbon)num;
							list.Add(shopRibbon);
						}
					}
				}
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		this.m_ribbons = list.ToArray();
		this.UpdateRibbons();
	}

	private void OnRestorePurchaseComplete(bool isSucceeded)
	{
		if (!isSucceeded)
		{
			Singleton<IapManager>.Instance.ShowErrorPopup("IN_APP_PURCHASE_NOT_READY");
		}
	}

	public string GetFormattedPrice(IapManager.InAppPurchaseItemType purchaseType)
	{
		if (!Singleton<IapManager>.Instance.SnoutCoinPurchasable(purchaseType))
		{
			if (Singleton<IapManager>.Instance.ProductList != null)
			{
				string prodId = Singleton<IapManager>.Instance.GetProductIdByItem(purchaseType);
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
		int productPrice = Singleton<VirtualCatalogManager>.Instance.GetProductPrice(purchaseType);
		if (productPrice == 2147483647 || productPrice < 0)
		{
			return null;
		}
		return string.Format("[snout] {0}", productPrice);
	}

	private void UpdatePrices(IapManager.CurrencyType updateType = IapManager.CurrencyType.RealMoney, bool updateAll = false)
	{
		if (updateAll || (updateType == IapManager.CurrencyType.RealMoney && Singleton<IapManager>.IsInstantiated()) || (updateType != IapManager.CurrencyType.RealMoney && Singleton<VirtualCatalogManager>.IsInstantiated()))
		{
			this.m_snoutCoinShop.UpdatePrices(this);
			PurchaseInfo[] componentsInChildren = base.gameObject.GetComponentsInChildren<PurchaseInfo>();
			foreach (PurchaseInfo purchaseInfo in componentsInChildren)
			{
				if (updateAll || purchaseInfo.currencyType == updateType)
				{
					purchaseInfo.CheckOnSale();
					string formattedSalePrice = (!purchaseInfo.isSaleItem) ? null : this.GetFormattedPrice(purchaseInfo.saleItem);
					this.SetPriceIndicator(purchaseInfo, this.GetFormattedPrice(purchaseInfo.purchaseItem), formattedSalePrice);
				}
			}
		}
	}

	public void SetPriceIndicator(PurchaseInfo infoData, string formattedPrice = null, string formattedSalePrice = null)
	{
		if (infoData.purchaseItem == IapManager.InAppPurchaseItemType.Undefined && !infoData.isSaleItem)
		{
			infoData.Show(false);
			return;
		}
		bool flag = Singleton<IapManager>.Instance.SnoutCoinPurchasable(infoData.purchaseItem);
		Transform transform = infoData.transform.FindChildRecursively("Price");
		Transform transform2 = infoData.transform.Find("Sale");
		if (transform2)
		{
			transform2.gameObject.SetActive(false);
		}
		Vector3 b = (!flag) ? Vector3.zero : (-Vector3.right * transform.transform.localPosition.x);
		Transform transform3 = transform.FindChildOrInstantiate("LoadingIndicator", this.m_loadingIndicator, transform.transform.position + b, transform.transform.rotation);
		Transform transform4 = transform.FindChildOrInstantiate("NotConnectedIndicator", this.m_notConnectedIndicator, transform.transform.position + b, transform.transform.rotation);
		Transform transform5 = transform.FindChildOrInstantiate("PurchasedIndicator", this.m_purchasedIndicator, transform.transform.position + b, transform.transform.rotation);
		Transform transform6 = infoData.transform.Find("HideIfPurchased");
		Renderer component = infoData.GetComponent<Renderer>();
		if (component != null)
		{
			Renderer[] componentsInChildren = transform3.GetComponentsInChildren<Renderer>();
			if (componentsInChildren != null)
			{
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].sortingLayerID = component.sortingLayerID;
				}
			}
			componentsInChildren = transform4.GetComponentsInChildren<Renderer>();
			if (componentsInChildren != null)
			{
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					componentsInChildren[j].sortingLayerID = component.sortingLayerID;
				}
			}
			componentsInChildren = transform5.GetComponentsInChildren<Renderer>();
			if (componentsInChildren != null)
			{
				for (int k = 0; k < componentsInChildren.Length; k++)
				{
					componentsInChildren[k].sortingLayerID = component.sortingLayerID;
				}
			}
		}
		transform3.gameObject.SetActive(false);
		transform4.gameObject.SetActive(false);
		transform5.gameObject.SetActive(false);
		bool flag2 = Singleton<IapManager>.Instance.IsItemPurchased(infoData.purchaseItem);
		Renderer[] componentsInChildren2 = transform.GetComponentsInChildren<Renderer>();
		for (int l = 0; l < 2; l++)
		{
			if ((infoData.doUpdatePrice || flag2) && l < componentsInChildren2.Length && componentsInChildren2[l] != null)
			{
				componentsInChildren2[l].enabled = false;
			}
		}
		if (Singleton<IapManager>.Instance.Status == IapManager.InAppPurchaseStatus.FetchingItems)
		{
			transform3.gameObject.SetActive(true);
		}
		else if (flag2)
		{
			infoData.EnableCollider(false);
			transform5.gameObject.SetActive(true);
			if (transform6 != null)
			{
				transform6.gameObject.SetActive(false);
			}
			Button component2 = infoData.GetComponent<Button>();
			if (component2)
			{
				UnityEngine.Object.Destroy(component2);
			}
		}
		else if (!string.IsNullOrEmpty(formattedPrice) || (infoData.isSaleItem && !string.IsNullOrEmpty(formattedSalePrice)))
		{
			infoData.EnableCollider(true);
			bool doUpdatePrice = infoData.doUpdatePrice;
			TextMesh[] componentsInChildren3 = transform.GetComponentsInChildren<TextMesh>();
			if (!string.IsNullOrEmpty(formattedPrice))
			{
				for (int m = 0; m < componentsInChildren3.Length; m++)
				{
					if (componentsInChildren2 != null && m < componentsInChildren2.Length && componentsInChildren2[m] != null)
					{
						componentsInChildren2[m].enabled = (doUpdatePrice || !flag2);
					}
					if (doUpdatePrice && m < componentsInChildren3.Length && componentsInChildren3[m] != null)
					{
						componentsInChildren3[m].text = formattedPrice;
						TextMeshSpriteIcons.EnsureSpriteIcon(componentsInChildren3[m]);
					}
				}
			}
			if (infoData.isSaleItem && transform2 != null && !string.IsNullOrEmpty(formattedSalePrice))
			{
				if (Singleton<IapManager>.Instance.IsCurrencyPack(infoData.saleItem))
				{
					Transform transform7 = transform2.Find("OldPrice");
					if (transform7)
					{
						Renderer[] componentsInChildren4 = transform7.GetComponentsInChildren<Renderer>();
						TextMesh[] componentsInChildren5 = transform7.GetComponentsInChildren<TextMesh>();
						for (int n = 0; n < componentsInChildren5.Length; n++)
						{
							if (componentsInChildren4 != null && n < componentsInChildren4.Length && componentsInChildren4[n] != null)
							{
								componentsInChildren4[n].enabled = (doUpdatePrice || !flag2);
							}
							if (doUpdatePrice && n < componentsInChildren5.Length && componentsInChildren5[n] != null)
							{
								if (!string.IsNullOrEmpty(formattedPrice))
								{
									componentsInChildren5[n].text = formattedPrice;
								}
								TextMeshSpriteIcons.EnsureSpriteIcon(componentsInChildren5[n]);
							}
						}
						for (int num = 0; num < componentsInChildren3.Length; num++)
						{
							if (doUpdatePrice && num < componentsInChildren3.Length && componentsInChildren3[num] != null)
							{
								componentsInChildren3[num].text = formattedSalePrice;
								TextMeshSpriteIcons.EnsureSpriteIcon(componentsInChildren3[num]);
							}
						}
						transform2.gameObject.SetActive(true);
					}
				}
				else
				{
					Transform transform8 = transform2.Find("Tag_pivot");
					if (transform8)
					{
						Renderer[] componentsInChildren6 = transform8.GetComponentsInChildren<Renderer>();
						TextMesh[] componentsInChildren7 = transform8.GetComponentsInChildren<TextMesh>();
						for (int num2 = 0; num2 < componentsInChildren7.Length; num2++)
						{
							if (componentsInChildren6 != null && num2 < componentsInChildren6.Length && componentsInChildren6[num2] != null)
							{
								componentsInChildren6[num2].enabled = (doUpdatePrice || !flag2);
							}
							if (doUpdatePrice && num2 < componentsInChildren7.Length && componentsInChildren7[num2] != null)
							{
								componentsInChildren7[num2].text = formattedSalePrice;
								TextMeshSpriteIcons.EnsureSpriteIcon(componentsInChildren7[num2]);
							}
						}
						transform2.gameObject.SetActive(true);
					}
				}
			}
		}
		else
		{
			infoData.EnableCollider(false);
			transform4.gameObject.SetActive(true);
			for (int num3 = 0; num3 < 2; num3++)
			{
				if (num3 < componentsInChildren2.Length && componentsInChildren2[num3] != null)
				{
					componentsInChildren2[num3].enabled = false;
				}
			}
		}
	}

	private bool IsPowerUpPage(string pageName)
	{
		return pageName.Equals("SuperGlue") || pageName.Equals("TurboCharge") || pageName.Equals("SuperMagnet") || pageName.Equals("SuperBluePrints") || pageName.Equals("NightVisions");
	}

	public void ChangeShopPage(string pageName, bool immediatly = false)
	{
		bool flag = pageName.Equals("PowerUps");
		bool flag2 = this.IsPowerUpPage(pageName);
		bool flag3 = this.IsPowerUpPage(this.m_pages[this.m_currentPage].name);
		if ((flag2 || flag) && flag && !flag3)
		{
			pageName = "SuperGlue";
		}
		for (int i = 0; i < this.m_pages.Length; i++)
		{
			if (this.m_pages[i].name == pageName)
			{
				if (immediatly)
				{
					base.GetComponent<PageScroller>().SetPage(i);
				}
				else
				{
					base.GetComponent<PageScroller>().ScrollToPage(i);
				}
				this.UpdateLowerButtons(i);
				break;
			}
		}
	}

	private void UpdateLowerButtons(int page)
	{
		this.m_restoreButton.SetActive(false);
		this.m_currentPage = page;
	}

	private void UpdateRibbons()
	{
		if (this.m_ribbons == null || this.m_ribbons.Length <= 0)
		{
			return;
		}
		for (int i = 0; i < this.m_ribbons.Length; i++)
		{
			this.m_ribbons[i].ribbon = this.AddRibbon(this.m_ribbons[i]);
			if (this.m_ribbons[i].ribbon == null)
			{
				this.m_ribbons[i].ribbon = this.m_snoutCoinShop.AddRibbon(this.m_ribbons[i]);
			}
		}
	}

	private GameObject AddRibbon(ShopRibbon ribbon)
	{
		Transform transform = this.m_ShopItems.transform.Find("Pages/" + ribbon.itemId);
		if (!transform || !transform.gameObject.activeInHierarchy)
		{
			return null;
		}
		string text = string.Empty;
		GameObject original = null;
		ShopRibbon.Ribbon ribbonType = ribbon.ribbonType;
		if (ribbonType != ShopRibbon.Ribbon.BestValue)
		{
			if (ribbonType == ShopRibbon.Ribbon.MostPopular)
			{
				text = "MostPopularRibbon";
				original = this.m_MostPopularRibbon;
			}
		}
		else
		{
			text = "BestValueRibbon";
			original = this.m_BestValueRibbon;
		}
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		Transform transform2 = transform.Find(text);
		GameObject gameObject;
		if (transform2 == null)
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
			gameObject.name = text;
		}
		else
		{
			gameObject = transform2.gameObject;
		}
		Vector3 position = transform.position;
		gameObject.transform.position = position + Vector3.back;
		gameObject.transform.parent = transform;
		gameObject.SetActive(true);
		return gameObject;
	}

	public void UpdatePurchasedCounters()
	{
		if (this.m_ShopToolBar == null)
		{
			return;
		}
		Transform transform = this.m_ShopToolBar.transform.Find("Pages");
		int num = transform.childCount;
		while (--num >= 0)
		{
			Transform child = transform.GetChild(num);
			Transform transform2 = child.Find("Counter/Text");
			if (transform2)
			{
				if (child.name == "SuperGlue")
				{
					transform2.GetComponent<TextMesh>().text = GameProgress.SuperGlueCount().ToString();
				}
				else if (child.name == "SuperMagnet")
				{
					transform2.GetComponent<TextMesh>().text = GameProgress.SuperMagnetCount().ToString();
				}
				else if (child.name == "TurboCharge")
				{
					transform2.GetComponent<TextMesh>().text = GameProgress.TurboChargeCount().ToString();
				}
				else if (child.name == "SuperBluePrints")
				{
					transform2.GetComponent<TextMesh>().text = GameProgress.BluePrintCount().ToString();
				}
				else if (child.name == "NightVisions")
				{
					transform2.GetComponent<TextMesh>().text = GameProgress.NightVisionCount().ToString();
				}
			}
		}
	}

	private void LayoutItems()
	{
		float num = 2f * WPFMonoBehaviour.hudCamera.orthographicSize * (float)Screen.width / (float)Screen.height;
		for (int i = 0; i < this.m_pages.Length; i++)
		{
			Vector3 localPosition = this.m_pages[i].transform.localPosition;
			localPosition.x = (float)i * num;
			this.m_pages[i].transform.localPosition = localPosition;
			this.m_pages[i].SetActive(true);
		}
	}

	private void OnPageChanged(int oldPage, int newPage)
	{
		Transform transform = this.m_ShopToolBar.transform.Find("Pages");
		if (oldPage >= 0)
		{
			Transform child = transform.GetChild(oldPage);
			Vector3 localPosition = child.localPosition;
			localPosition.y = 0f;
			base.StartCoroutine(this.MoveTo(child, child.localPosition, localPosition));
		}
		if (newPage >= 0)
		{
			Transform child2 = transform.GetChild(newPage);
			Vector3 localPosition2 = child2.localPosition;
			localPosition2.y = 0.4f;
			base.StartCoroutine(this.MoveTo(child2, child2.localPosition, localPosition2));
		}
		this.UpdateLowerButtons(newPage);
	}

	private void OnPurchaseSucceeded(IapManager.InAppPurchaseItemType type)
	{
		this.UpdatePurchasedCounters();
		if (base.gameObject.activeInHierarchy)
		{
			base.StartCoroutine(this.WaitAndUpdate());
		}
	}

	private IEnumerator WaitAndUpdate()
	{
		yield return null;
		this.UpdatePrices(IapManager.CurrencyType.RealMoney, false);
		yield break;
	}

	public void Open(Action onClose, string pageName = null)
	{
		if (Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			this.Close();
			return;
		}
		Singleton<IapManager>.Instance.UpdatePosition();
		if (this.m_snoutCoinShopPrefab != null && this.m_snoutCoinShopPrefab.name.Equals(pageName))
		{
			if (!this.m_snoutCoinShop.gameObject.activeInHierarchy)
			{
				this.m_snoutCoinShop.transform.localPosition = Vector3.back * 6f;
				this.m_snoutCoinShop.Open(onClose);
				this.UpdateLowerButtons(0);
			}
			return;
		}
		if (onClose != null)
		{
			this.m_onClose = (Action)Delegate.Combine(this.m_onClose, onClose);
		}
		if (!base.gameObject.activeSelf)
		{
			EventManager.Send(new UIEvent(UIEvent.Type.OpenIapMenu));
			base.gameObject.SetActive(true);
		}
		this.LayoutItems();
		if (!string.IsNullOrEmpty(pageName))
		{
			this.ChangeShopPage(pageName, true);
		}
		else
		{
			this.ChangeShopPage("LootCrates", true);
		}
	}

	public void Close()
	{
		if (base.gameObject.activeSelf)
		{
			EventManager.Send(new UIEvent(UIEvent.Type.CloseIapMenu));
			base.gameObject.SetActive(false);
		}
		if (this.m_onClose != null)
		{
			this.m_onClose();
		}
		this.m_onClose = null;
	}

	public void ConfirmSinglePurchase(string inAppPurchaseItemTypeAsString, string spriteID, string effectID, int itemCount, Action onClose)
	{
		if (Enum.IsDefined(typeof(IapManager.InAppPurchaseItemType), inAppPurchaseItemTypeAsString))
		{
			IapManager.InAppPurchaseItemType inAppPurchaseItemType = (IapManager.InAppPurchaseItemType)Enum.Parse(typeof(IapManager.InAppPurchaseItemType), inAppPurchaseItemTypeAsString);
			int price = Singleton<VirtualCatalogManager>.Instance.GetProductPrice(inAppPurchaseItemType);
			string itemKey = this.ItemLocalizationKey(inAppPurchaseItemType);
			string productLocalizationKey = Singleton<VirtualCatalogManager>.Instance.GetProductLocalizationKey(inAppPurchaseItemType);
			this.ShowConfirmationPopup(Singleton<GameManager>.Instance.gameData.m_purchaseProductConfirmDialog, inAppPurchaseItemTypeAsString, spriteID, effectID, itemKey, productLocalizationKey, price, itemCount, () => GameProgress.SnoutCoinCount() >= price, onClose);
		}
	}

	public void ConfirmPurchase(string inAppPurchaseItemTypeAsString, string spriteID, string effectID, int itemCount)
	{
		if (Enum.IsDefined(typeof(IapManager.InAppPurchaseItemType), inAppPurchaseItemTypeAsString))
		{
			IapManager.InAppPurchaseItemType inAppPurchaseItemType = (IapManager.InAppPurchaseItemType)Enum.Parse(typeof(IapManager.InAppPurchaseItemType), inAppPurchaseItemTypeAsString);
			int price = Singleton<VirtualCatalogManager>.Instance.GetProductPrice(inAppPurchaseItemType);
			string itemKey = this.ItemLocalizationKey(inAppPurchaseItemType);
			string productLocalizationKey = Singleton<VirtualCatalogManager>.Instance.GetProductLocalizationKey(inAppPurchaseItemType);
			this.ShowConfirmationPopup(Singleton<GameManager>.Instance.gameData.m_purchaseProductConfirmDialog, inAppPurchaseItemTypeAsString, spriteID, effectID, itemKey, productLocalizationKey, price, itemCount, () => GameProgress.SnoutCoinCount() >= price, null);
		}
	}

	public void ConfirmLootCratePurchase(string inAppPurchaseItemTypeAsString)
	{
		if (Enum.IsDefined(typeof(IapManager.InAppPurchaseItemType), inAppPurchaseItemTypeAsString))
		{
			IapManager.InAppPurchaseItemType inAppPurchaseItemType = (IapManager.InAppPurchaseItemType)Enum.Parse(typeof(IapManager.InAppPurchaseItemType), inAppPurchaseItemTypeAsString);
			int price = Singleton<VirtualCatalogManager>.Instance.GetProductPrice(inAppPurchaseItemType);
			string itemKey = this.ItemLocalizationKey(inAppPurchaseItemType);
			string productLocalizationKey = Singleton<VirtualCatalogManager>.Instance.GetProductLocalizationKey(inAppPurchaseItemType);
			this.ShowConfirmationPopup(Singleton<GameManager>.Instance.gameData.m_purchaseLootcrateConfirmDialog, inAppPurchaseItemTypeAsString, string.Empty, string.Empty, itemKey, productLocalizationKey, price, 0, () => GameProgress.SnoutCoinCount() >= price, null);
		}
	}

	private string ItemLocalizationKey(IapManager.InAppPurchaseItemType type)
	{
		switch (type)
		{
			case IapManager.InAppPurchaseItemType.BlueprintSmall:
			case IapManager.InAppPurchaseItemType.BlueprintMedium:
			case IapManager.InAppPurchaseItemType.BlueprintLarge:
			case IapManager.InAppPurchaseItemType.BlueprintHuge:
			case IapManager.InAppPurchaseItemType.BlueprintUltimate:
			case IapManager.InAppPurchaseItemType.BlueprintSingle:
				return "IAP_BLUEPRINT";
			case IapManager.InAppPurchaseItemType.SuperGlueSmall:
			case IapManager.InAppPurchaseItemType.SuperGlueMedium:
			case IapManager.InAppPurchaseItemType.SuperGlueLarge:
			case IapManager.InAppPurchaseItemType.SuperGlueHuge:
			case IapManager.InAppPurchaseItemType.SuperGlueUltimate:
			case IapManager.InAppPurchaseItemType.SuperGlueSingle:
				return "IAP_SUPER_GLUE";
			case IapManager.InAppPurchaseItemType.SuperMagnetSmall:
			case IapManager.InAppPurchaseItemType.SuperMagnetMedium:
			case IapManager.InAppPurchaseItemType.SuperMagnetLarge:
			case IapManager.InAppPurchaseItemType.SuperMagnetHuge:
			case IapManager.InAppPurchaseItemType.SuperMagnetUltimate:
			case IapManager.InAppPurchaseItemType.SuperMagnetSingle:
				return "IAP_SUPER_MAGNET";
			case IapManager.InAppPurchaseItemType.TurboChargeSmall:
			case IapManager.InAppPurchaseItemType.TurboChargeMedium:
			case IapManager.InAppPurchaseItemType.TurboChargeLarge:
			case IapManager.InAppPurchaseItemType.TurboChargeHuge:
			case IapManager.InAppPurchaseItemType.TurboChargeUltimate:
			case IapManager.InAppPurchaseItemType.TurboChargeSingle:
				return "IAP_TURBO_CHARGE";
			case IapManager.InAppPurchaseItemType.BundleStarterPack:
			case IapManager.InAppPurchaseItemType.BundleMediumPack:
			case IapManager.InAppPurchaseItemType.BundleBigPack:
			case IapManager.InAppPurchaseItemType.BundleHugePack:
				return "IAP_BUNDLE";
			case IapManager.InAppPurchaseItemType.NightVisionSmall:
			case IapManager.InAppPurchaseItemType.NightVisionMedium:
			case IapManager.InAppPurchaseItemType.NightVisionLarge:
			case IapManager.InAppPurchaseItemType.NightVisionHuge:
			case IapManager.InAppPurchaseItemType.NightVisionUltimate:
			case IapManager.InAppPurchaseItemType.NightVisionSingle:
				return "IAP_NIGHTVISION";
			case IapManager.InAppPurchaseItemType.WoodenLootCrate:
			case IapManager.InAppPurchaseItemType.WoodenLootCrateSale:
				return "IAP_WOODEN_LOOTCRATE";
		}
		return string.Empty;
	}

	private void ShowConfirmationPopup(GameObject dialogPrefab, string inAppPurchaseItemTypeAsString, string spriteID, string effectID, string itemKey, string descriptionKey, int cost, int itemCount, Func<bool> requirements, Action onClose = null)
	{
		if (dialogPrefab != null && this.confirmDialog == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(dialogPrefab);
			gameObject.transform.position = WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 5f;
			this.confirmDialog = gameObject.GetComponent<PurchaseProductConfirmDialog>();
			this.confirmDialog.Close();
		}
		if (this.confirmDialog != null)
		{
			this.confirmDialog.ItemCount = itemCount;
			this.confirmDialog.ItemSpriteID = spriteID;
			this.confirmDialog.EffectSpriteID = effectID;
			this.confirmDialog.Cost = cost;
			this.confirmDialog.ShowConfirmEnabled = null;
			this.confirmDialog.ItemLocalizationKey = itemKey;
			this.confirmDialog.ItemDescriptionKey = descriptionKey;
			this.confirmDialog.Open();
			bool shopWasOpen = base.gameObject.activeSelf;
			this.confirmDialog.SetOnConfirm(delegate
			{
				if (requirements())
				{
					this.PurchaseItem(inAppPurchaseItemTypeAsString);
				}
				else if (Singleton<IapManager>.IsInstantiated())
				{
					Singleton<IapManager>.Instance.OpenShopPage(delegate
					{
						if (shopWasOpen)
						{
							this.gameObject.SetActive(true);
						}
						this.confirmDialog.Open();
					}, "SnoutCoinShop");
					if (shopWasOpen)
					{
						this.gameObject.SetActive(false);
					}
					this.confirmDialog.Close();
				}
				else
				{
					this.confirmDialog.Close();
				}
			});
			this.confirmDialog.onClose += delegate ()
			{
				if (onClose != null)
				{
					onClose();
				}
				if (this.m_snoutCoinShop == null || !this.m_snoutCoinShop.gameObject.activeInHierarchy)
				{
					UnityEngine.Object.Destroy(this.confirmDialog.gameObject);
				}
				else if (!Singleton<IapManager>.IsInstantiated())
				{
					UnityEngine.Object.Destroy(this.confirmDialog.gameObject);
				}
			};
		}
	}

	private void OnPurchaseItem(IapManager.PurchaseEvent data)
	{
		this.PurchaseItem(data.itemType.ToString());
	}

	public void PurchaseItem(string inAppPurchaseItemTypeAsString)
	{
		if (!this.subscribedToPurchaseEvents)
		{
			IapManager.onPurchaseSucceeded += this.OnPurchaseSucceeded;
			IapManager.onPurchaseSucceeded += this.UnlockScreen;
			IapManager.onPurchaseFailed += this.UnlockScreen;
			IapManager.onRestorePurchaseComplete += this.OnRestorePurchaseComplete;
			this.subscribedToPurchaseEvents = true;
		}
		if (Enum.IsDefined(typeof(IapManager.InAppPurchaseItemType), inAppPurchaseItemTypeAsString))
		{
			IapManager.InAppPurchaseItemType purchaseId = (IapManager.InAppPurchaseItemType)Enum.Parse(typeof(IapManager.InAppPurchaseItemType), inAppPurchaseItemTypeAsString);
			if (purchaseId == IapManager.InAppPurchaseItemType.StarterPack)
			{
				if (this.starterPackDialog == null)
				{
					if (WPFMonoBehaviour.gameData.m_starterPackDialog != null)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_starterPackDialog);
						gameObject.transform.parent = base.transform.parent;
						gameObject.transform.localPosition = -Vector3.forward * 8f;
						this.starterPackDialog = gameObject.GetComponent<TextDialog>();
						if (this.starterPackDialog != null)
						{
							Transform transform = this.starterPackDialog.transform.Find("CoinCount");
							if (transform != null)
							{
								TextMeshFormattedLocale[] componentsInChildren = transform.GetComponentsInChildren<TextMeshFormattedLocale>();
								if (componentsInChildren != null)
								{
									int purchaseItemTypeCount = Singleton<IapManager>.Instance.GetPurchaseItemTypeCount(IapManager.InAppPurchaseItemType.StarterPack);
									for (int i = 0; i < componentsInChildren.Length; i++)
									{
										componentsInChildren[i].SetText("+{0} {1}", "SNOUT_COIN_PLURAL", new object[]
										{
											purchaseItemTypeCount
										});
									}
								}
							}
							this.starterPackDialog.ConfirmButtonText = this.GetFormattedPrice(purchaseId);
							this.starterPackDialog.SetOnConfirm(delegate
							{
								this.LockScreen();
								Singleton<IapManager>.Instance.PurchaseItem(purchaseId);
								this.starterPackDialog.Close();
							});
						}
						this.starterPackDialog.Open();
					}
				}
				else
				{
					this.starterPackDialog.Open();
				}
			}
			else if (string.IsNullOrEmpty(this.GetFormattedPrice(purchaseId)))
			{
				this.showFetchError = true;
				Singleton<IapManager>.Instance.FetchPurchasableItemList();
				this.UpdatePrices(IapManager.CurrencyType.RealMoney, false);
			}
			else
			{
				this.LockScreen();
				Singleton<IapManager>.Instance.PurchaseItem(purchaseId);
			}
		}
	}

	public void RestorePurchasedItems()
	{
		Singleton<IapManager>.Instance.RestorePurchasedItems();
		Dialog component = this.m_confirmRestorePopup.GetComponent<Dialog>();
		if (component != null)
		{
			component.Close();
		}
		GameObject gameObject = GameObject.Find("ConfirmationPopupRestore");
		if (gameObject != null)
		{
			gameObject.GetComponent<Dialog>().Close();
		}
	}

	public void ConfirmRestorePurchasedItems()
	{
		Dialog component = this.m_confirmRestorePopup.GetComponent<Dialog>();
		if (component != null)
		{
			component.Open();
		}
	}

	private IEnumerator MoveTo(Transform target, Vector3 from, Vector3 to)
	{
		float current = 0f;
		while (target.gameObject.activeInHierarchy && current < 0.15f)
		{
			target.localPosition = Vector3.Lerp(from, to, current / 0.15f);
			yield return null;
			current += Time.unscaledDeltaTime;
		}
		target.localPosition = to;
		yield break;
	}

	private const string SUPER_GLUE_KEY = "IAP_SUPER_GLUE";

	private const string SUPER_MAGNET_KEY = "IAP_SUPER_MAGNET";

	private const string TURBO_CHARGE_KEY = "IAP_TURBO_CHARGE";

	private const string NIGHTVISION_KEY = "IAP_NIGHTVISION";

	private const string LOOTCRATE_KEY = "IAP_WOODEN_LOOTCRATE";

	private const string BLUEPRINT_KEY = "IAP_BLUEPRINT";

	private const string BUNDLE_KEY = "IAP_BUNDLE";

	public GameObject m_SelectionBack;

	public GameObject m_BestValueRibbon;

	public GameObject m_MostPopularRibbon;

	public GameObject m_ShopItems;

	public GameObject m_ShopToolBar;

	public GameObject m_scrollPivot;

	public GameObject m_loadingIndicator;

	public GameObject m_notConnectedIndicator;

	public GameObject m_purchasedIndicator;

	public GameObject m_confirmRestorePopup;

	public GameObject m_LockOverlay;

	public GameObject m_snoutCoinShopPrefab;

	public GameObject m_crateCrazePopupPrefab;

	public GameObject m_coinCrazePopupPrefab;

	public GameObject m_offerBanner;

	public GameObject m_restoreButton;

	private SnoutCoinShopPopup m_snoutCoinShop;

	private TextDialog starterPackDialog;

	private ShopRibbon[] m_ribbons;

	public GameObject[] m_pages;

	private int m_currentPage = -1;

	private PageScroller pageScroller;

	private Action m_onClose;

	private bool isProductListHandlerAttached;

	private bool isStarted;

	private bool showFetchError;

	private bool ducking;

	private bool subscribedToPurchaseEvents;

	private bool waitingSalePopupAnswer;

	private PurchaseProductConfirmDialog confirmDialog;

	public enum PriceIndicator
	{
		Price,
		Loading,
		NotConnected,
		Purchased
	}

	private class SaleEvent
	{
		public SaleEvent(string identifier, DateTime startTime)
		{
			this.identifier = identifier;
			this.startTime = startTime;
		}

		public string identifier;

		public DateTime startTime;
	}
}
