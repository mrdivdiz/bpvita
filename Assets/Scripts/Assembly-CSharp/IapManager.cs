using Pathfinding.Serialization.JsonFx;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IapManager : Singleton<IapManager>
{
	public static event PurchaseSucceeded onPurchaseSucceeded;

	public static event PurchaseFailed onPurchaseFailed;

	public static event ProductListReceived onProductListReceived;

	public static event RestorePurchaseComplete onRestorePurchaseComplete;

	public static event Action<object, CodeRedeemError> onCodeRedeemFailed;

	public static event Action<object, bool> onCodeVerificationCompleted;

	public static event Action onProductListParsed;

	public InAppPurchaseStatus Status
	{
		get
		{
			return this.m_state;
		}
	}

	public bool ReadyForTransaction
	{
		get
		{
			return this.m_iap != null && this.m_iap.readyForTransactions() && this.m_state == IapManager.InAppPurchaseStatus.Idle;
		}
	}

	public bool UserInitiatedRestore
	{
		get
		{
			return this.m_iap != null && this.m_iap.UserInitiatedRestore;
		}
	}

	public bool PurchaseListInited
	{
		get
		{
			return this.m_countDictionary.Count > 0;
		}
	}

	public IEnumerable<IAPProductInfo> ProductList
	{
		get
		{
			return this.productList;
		}
	}

	public string LocalCatalogJson
	{
		get
		{
			return (!(this.m_catalog != null)) ? string.Empty : this.m_catalog.text;
		}
	}

	public IAPInterface createIAP()
	{
		return new NullIAP();
	}

	private void Awake()
	{
		if (!Singleton<BuildCustomizationLoader>.Instance.IAPEnabled)
		{
			return;
		}
		if (this.m_iap != null)
		{
		}
		base.SetAsPersistant();
		this.InitDictionaries();
		this.m_iap = this.createIAP();
		this.m_iap.readyForTransactionsEvent += this.HandleReadyForTransactionsEvent;
		this.m_iap.purchaseSucceededEvent += this.HandlePurchaseSucceededEvent;
		this.m_iap.purchaseFailedEvent += this.HandlePurchaseFailedEvent;
		this.m_iap.purchaseCancelledEvent += this.HandlePurchaseCancelledEvent;
		this.m_iap.transactionsRestoredEvent += this.HandleTransactionsRestoredEvent;
		this.m_iap.transactionRestoreFailedEvent += this.HandleTransactionsRestoreFailedEvent;
		this.m_iap.productListReceivedEvent += this.HandleProductListReceivedEvent;
		this.m_iap.productListRequestFailedEvent += this.HandleProductListRequestFailedEvent;
		this.m_iap.codeRedeemFailedEvent += this.HandleCodeRedeemFailedEvent;
		this.m_iap.codeVerificationEvent += this.HandleCodeVerificationEvent;
		this.m_iap.deliverItem += this.HandleDeliverItem;
		this.m_state = IapManager.InAppPurchaseStatus.Init;
		this.m_iap.init();
		EventManager.Connect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
		EventManager.Connect(new EventManager.OnEvent<LevelLoadedEvent>(this.OnLevelLoadedEvent));
	}

	private void OnPlayerChanged(PlayerChangedEvent data)
	{
		this.CreatePages();
	}

	private void Start()
	{
		this.CreatePages();
	}

	private void CreatePages()
	{
		if (this.m_iapUnlockFullVersionPageInstance != null)
		{
			UnityEngine.Object.Destroy(this.m_iapUnlockFullVersionPageInstance);
		}
		this.m_iapUnlockFullVersionPageInstance = UnityEngine.Object.Instantiate<GameObject>(this.m_iapUnlockFullVersionPage);
		this.m_iapUnlockFullVersionPageInstance.transform.parent = base.transform;
		this.m_iapUnlockFullVersionPageInstance.SetActive(false);
		if (this.m_errorPopupInstance != null)
		{
			UnityEngine.Object.Destroy(this.m_errorPopupInstance);
		}
		this.m_errorPopupInstance = UnityEngine.Object.Instantiate<GameObject>(this.m_errorPopup);
		this.m_errorPopupInstance.transform.parent = base.transform;
		this.m_errorPopupInstance.SetActive(false);
		if (this.m_ShopPageInstance != null)
		{
			this.m_Shop = null;
			UnityEngine.Object.Destroy(this.m_ShopPageInstance);
		}
		this.m_ShopPageInstance = UnityEngine.Object.Instantiate<GameObject>(this.m_ShopPage);
		this.m_ShopPageInstance.transform.parent = base.transform;
		this.m_ShopPageInstance.transform.localPosition = Vector3.zero;
		this.m_ShopPageInstance.SetActive(false);
		this.m_Shop = this.GetShop();
		MainMenu mainMenu = UnityEngine.Object.FindObjectOfType<MainMenu>();
		if (mainMenu == null)
		{
			return;
		}
		mainMenu.ConnectShopToRestoreConfirmButton(this.m_Shop);
	}

	private void OnLevelLoadedEvent(LevelLoadedEvent data)
	{
		if (this.m_iap != null)
		{
			this.m_iap.OnLevelWasLoaded();
		}
		if (data.currentGameState != GameManager.GameState.MainMenu)
		{
			return;
		}
		MainMenu mainMenu = UnityEngine.Object.FindObjectOfType<MainMenu>();
		if (mainMenu == null)
		{
			return;
		}
		mainMenu.ConnectShopToRestoreConfirmButton(this.m_Shop);
		string[] names = Enum.GetNames(typeof(LootCrateType));
		for (int i = 0; i < names.Length - 1; i++)
		{
			int lootcrateAmount = GameProgress.GetLootcrateAmount((LootCrateType)i);
			if (lootcrateAmount > 0)
			{
				WorkshopMenu.AnyLootCrateCollected = true;
				Camera hudCamera = Singleton<GuiManager>.Instance.FindCamera();
				LootCrate.SpawnLootCrateOpeningDialog((LootCrateType)i, lootcrateAmount, hudCamera, null, new LootCrate.AnalyticData("restored", "0", LootCrate.AdWatched.NotApplicaple));
			}
		}
	}

	private void OnDestroy()
	{
		if (this.m_iap != null)
		{
			this.m_iap.deInit();
		}
		EventManager.Disconnect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
		EventManager.Disconnect(new EventManager.OnEvent<LevelLoadedEvent>(this.OnLevelLoadedEvent));
	}

	public void UpdatePosition()
	{
		base.transform.position = Singleton<GuiManager>.Instance.FindCamera().transform.position + Vector3.forward * 10f;
	}

	public string GetProductIdByItem(InAppPurchaseItemType itemId)
	{
		string result = null;
		if (this.m_itemDictionary.TryGetValue(itemId, out result))
		{
			return result;
		}
		return string.Empty;
	}

	public InAppPurchaseItemType GetItemByProductId(string productId)
	{
		if (!string.IsNullOrEmpty(productId) && this.m_idDictionary.ContainsKey(productId))
		{
			return this.m_idDictionary[productId];
		}
		return IapManager.InAppPurchaseItemType.Undefined;
	}

	public bool IsBundleProduct(InAppPurchaseItemType itemId)
	{
		return this.m_bundlesInfo.ContainsKey(itemId);
	}

	private bool IsLootCrateIAP(InAppPurchaseItemType itemId)
	{
		switch (itemId)
		{
			case IapManager.InAppPurchaseItemType.MetalLootCrate:
			case IapManager.InAppPurchaseItemType.GoldenLootCrate:
			case IapManager.InAppPurchaseItemType.MetalLootCrateSale:
			case IapManager.InAppPurchaseItemType.GoldenLootCrateSale:
			case IapManager.InAppPurchaseItemType.GoldenLootCratePack:
				return true;
		}
		return false;
	}

	public bool SnoutCoinPurchasable(InAppPurchaseItemType itemId)
	{
		switch (itemId)
		{
			case IapManager.InAppPurchaseItemType.SnoutCoinPackSmall:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackMedium:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackLarge:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackHuge:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackUltimate:
			case IapManager.InAppPurchaseItemType.StarterPack:
			case IapManager.InAppPurchaseItemType.MetalLootCrate:
			case IapManager.InAppPurchaseItemType.GoldenLootCrate:
			case IapManager.InAppPurchaseItemType.MetalLootCrateSale:
			case IapManager.InAppPurchaseItemType.GoldenLootCrateSale:
			case IapManager.InAppPurchaseItemType.GoldenLootCratePack:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackSmallSale:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackMediumSale:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackLargeSale:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackHugeSale:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackUltimateSale:
				break;
			default:
				if (itemId != IapManager.InAppPurchaseItemType.UnlockSpecialSandbox && itemId != IapManager.InAppPurchaseItemType.PermanentBlueprint)
				{
					return true;
				}
				break;
		}
		return false;
	}

	public int SnoutCoinPrice(InAppPurchaseItemType type)
	{
		if (this.m_priceDictionary.ContainsKey(type))
		{
			return this.m_priceDictionary[type];
		}
		return int.MaxValue;
	}

	public bool HasBundleInfo(InAppPurchaseItemType itemId)
	{
		return this.m_bundlesInfo[itemId] != null;
	}

	public IEnumerable<BundleItem> GetBundleInfo(InAppPurchaseItemType itemId)
	{
		return this.m_bundlesInfo[itemId];
	}

	private void HandleReadyForTransactionsEvent(bool isReady)
	{
		this.m_state = IapManager.InAppPurchaseStatus.Idle;
		if (isReady)
		{
			this.FetchPurchasableItemList();
		}
		if (!this.m_iap.UserInitiatedRestore && !GameProgress.GetBool("IAPRestored", false, GameProgress.Location.Local, null))
		{
			this.RestorePurchasedItems();
		}
	}

	private void HandlePurchaseFailedEvent(string error)
	{
		if (this.m_state == IapManager.InAppPurchaseStatus.PurchasingItem)
		{
			this.m_state = IapManager.InAppPurchaseStatus.Idle;
			this.ShowErrorPopup("IN_APP_PURCHASE_NOT_READY");
		}
		IapManager.onPurchaseFailed(this.m_activePurchase);
	}

	private void HandlePurchaseCancelledEvent(string obj)
	{
		this.m_state = IapManager.InAppPurchaseStatus.Idle;
		IapManager.onPurchaseFailed(this.m_activePurchase);
	}

	private bool HandleDeliverItem(string productId)
	{
		return this.DeliverItem(this.GetItemByProductId(productId));
	}

	private void HandlePurchaseSucceededEvent(string productId)
	{
		this.m_state = IapManager.InAppPurchaseStatus.Idle;
		InAppPurchaseItemType itemByProductId = this.GetItemByProductId(productId);
		if (itemByProductId != IapManager.InAppPurchaseItemType.Undefined)
		{
			if (IapManager.onPurchaseSucceeded != null)
			{
				IapManager.onPurchaseSucceeded(itemByProductId);
			}
		}
		else if (IapManager.onPurchaseFailed != null)
		{
			IapManager.onPurchaseFailed(itemByProductId);
		}
		if (this.m_Shop != null)
		{
			this.m_Shop.UnlockScreen(IapManager.InAppPurchaseItemType.Undefined);
		}
	}

	private void HandleTransactionsRestoredEvent()
	{
		GameProgress.SetBool("IAPRestored", true, GameProgress.Location.Local);
		IapManager.onRestorePurchaseComplete(true);
	}

	private void HandleTransactionsRestoreFailedEvent(string error)
	{
		IapManager.onRestorePurchaseComplete(false);
	}

	private void HandleProductListReceivedEvent(List<IAPProductInfo> products)
	{
		this.m_state = IapManager.InAppPurchaseStatus.Idle;
		if (products != null && products.Count > 0)
		{
			if (this.productList == null)
			{
				this.productList = new List<IAPProductInfo>();
			}
			this.productList.Clear();
			this.productList.AddRange(products);
			foreach (IAPProductInfo product in products)
			{
				this.ParseProductInfo(product);
			}
			if (IapManager.onProductListParsed != null)
			{
				IapManager.onProductListParsed();
			}
		}
		IapManager.onProductListReceived(this.productList, null);
	}

	private void ParseProductInfo(IAPProductInfo product)
	{
		if (!this.m_idDictionary.ContainsKey(product.productId))
		{
			return;
		}
		InAppPurchaseItemType inAppPurchaseItemType = this.m_idDictionary[product.productId];
		if (this.m_bundlesInfo.ContainsKey(inAppPurchaseItemType))
		{
			return;
		}
		if (this.SnoutCoinPurchasable(inAppPurchaseItemType))
		{
			return;
		}
		string key = (!Singleton<BuildCustomizationLoader>.Instance.IsChina) ? "normalCount" : "chinaCount";
		if (!this.m_countDictionary.ContainsKey(inAppPurchaseItemType))
		{
			if (product.clientData.ContainsKey(key))
			{
				int value;
				if (int.TryParse(product.clientData[key], out value))
				{
					this.m_countDictionary.Add(inAppPurchaseItemType, value);
				}
			}
		}
	}

	private BundleItem[] ParseBundleData(string json)
	{
		object[] array = JsonReader.Deserialize(json) as object[];
		List<BundleItem> list = new List<BundleItem>();
		foreach (object obj in array)
		{
			Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
			if (dictionary != null)
			{
				string key = "snoutCoinCount";
				if (dictionary.ContainsKey("itemType") && dictionary.ContainsKey(key))
				{
					int count = 0;
					BundleItem.BundleItemType bundleItemType;
					if (Enum.IsDefined(typeof(BundleItem.BundleItemType), dictionary["itemType"] as string))
					{
						bundleItemType = (BundleItem.BundleItemType)Enum.Parse(typeof(BundleItem.BundleItemType), dictionary["itemType"] as string);
					}
					else
					{
						bundleItemType = IapManager.BundleItem.BundleItemType.Undefined;
					}
					if (int.TryParse(dictionary[key] as string, out count) && bundleItemType != IapManager.BundleItem.BundleItemType.Undefined)
					{
						list.Add(new BundleItem(bundleItemType, count));
					}
				}
			}
		}
		return list.ToArray();
	}

	private void HandleProductListRequestFailedEvent(string error)
	{
		this.m_state = IapManager.InAppPurchaseStatus.Idle;
		IapManager.onProductListReceived(null, error);
	}

	private void HandleCodeRedeemFailedEvent(CodeRedeemError error)
	{
		this.ShowErrorPopup("REDEEM_CODE_FAILURE_MESSAGE");
		if (IapManager.onCodeRedeemFailed != null)
		{
			IapManager.onCodeRedeemFailed(this, error);
		}
	}

	private void HandleCodeVerificationEvent(bool succeeded)
	{
		if (IapManager.onCodeVerificationCompleted != null)
		{
			IapManager.onCodeVerificationCompleted(this, succeeded);
		}
	}

	public void PurchaseItem(InAppPurchaseItemType type)
	{
		if (this.SnoutCoinPurchasable(type))
		{
			this.PurchaseSnoutCoinItem(type);
		}
		else
		{
			if (!this.ReadyForTransaction)
			{
				IapManager.onPurchaseFailed(this.m_activePurchase);
				this.ShowErrorPopup("IN_APP_PURCHASE_NOT_READY");
				return;
			}
			this.m_state = IapManager.InAppPurchaseStatus.PurchasingItem;
			this.m_activePurchase = type;
			this.m_iap.purchaseProduct(this.m_itemDictionary[type]);
			this.SendStartPurchaseFlurryEvent(type);
		}
	}

	private void PurchaseSnoutCoinItem(InAppPurchaseItemType type)
	{
		int productPrice = Singleton<VirtualCatalogManager>.Instance.GetProductPrice(type);
		if (productPrice > 0)
		{
			if (GameProgress.UseSnoutCoins(productPrice))
			{
				if (this.DeliverItem(type))
				{
					this.HandlePurchaseSucceededEvent(this.m_itemDictionary[type]);
				}
				else
				{
					this.HandlePurchaseFailedEvent("DELIVER_ERROR");
				}
				Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinUse);
			}
			else
			{
				this.HandlePurchaseFailedEvent("NOT_ENOUGH_SNOUT_COINS");
			}
		}
	}

	private IEnumerator PurchaseTimeout()
	{
		float pollTime = 0.5f;
		float waitTime = 10f;
		while (waitTime > 0f && this.m_state == IapManager.InAppPurchaseStatus.PurchasingItem)
		{
			yield return new WaitForSeconds(pollTime);
			waitTime -= pollTime;
		}
		if (this.m_state == IapManager.InAppPurchaseStatus.PurchasingItem)
		{
			this.m_state = IapManager.InAppPurchaseStatus.Idle;
			IapManager.onPurchaseFailed(this.m_activePurchase);
			this.ShowErrorPopup("IN_APP_PURCHASE_TIMEOUT");
		}
		yield break;
	}

	public void FetchPurchasableItemList()
	{
		if (this.m_state == IapManager.InAppPurchaseStatus.FetchingItems)
		{
			return;
		}
		if (!this.ReadyForTransaction)
		{
			IapManager.onProductListReceived(null, "IN_APP_PURCHASE_NOT_READY");
			return;
		}
		this.productList = null;
		this.m_state = IapManager.InAppPurchaseStatus.FetchingItems;
		this.m_iap.fetchAvailableProducts(this.GetPurchasableItemIdentifiers());
	}

	public void RestorePurchasedItems()
	{
		if (!this.m_iap.readyForTransactions())
		{
			IapManager.onRestorePurchaseComplete(false);
			return;
		}
		this.m_iap.restoreTransactions();
	}

	public static string GetProductName()
	{
		string text = "badpiggies";
		if (Singleton<BuildCustomizationLoader>.Instance.IsHDVersion)
		{
			text += "hd";
		}
		return text;
	}

	private void InitDictionaries()
	{
		string productName = IapManager.GetProductName();
		this.m_idDictionary.Add("com.rovio." + productName + ".supermechanic_single", IapManager.InAppPurchaseItemType.BlueprintSingle);
		this.m_idDictionary.Add("com.rovio." + productName + ".supermechanic_small", IapManager.InAppPurchaseItemType.BlueprintSmall);
		this.m_idDictionary.Add("com.rovio." + productName + ".supermechanic_medium", IapManager.InAppPurchaseItemType.BlueprintMedium);
		this.m_idDictionary.Add("com.rovio." + productName + ".supermechanic_large", IapManager.InAppPurchaseItemType.BlueprintLarge);
		this.m_idDictionary.Add("com.rovio." + productName + ".supermechanic_huge", IapManager.InAppPurchaseItemType.BlueprintHuge);
		this.m_idDictionary.Add("com.rovio." + productName + ".superglue_single", IapManager.InAppPurchaseItemType.SuperGlueSingle);
		this.m_idDictionary.Add("com.rovio." + productName + ".superglue_small", IapManager.InAppPurchaseItemType.SuperGlueSmall);
		this.m_idDictionary.Add("com.rovio." + productName + ".superglue_medium", IapManager.InAppPurchaseItemType.SuperGlueMedium);
		this.m_idDictionary.Add("com.rovio." + productName + ".superglue_large", IapManager.InAppPurchaseItemType.SuperGlueLarge);
		this.m_idDictionary.Add("com.rovio." + productName + ".superglue_huge", IapManager.InAppPurchaseItemType.SuperGlueHuge);
		this.m_idDictionary.Add("com.rovio." + productName + ".supermagnet_single", IapManager.InAppPurchaseItemType.SuperMagnetSingle);
		this.m_idDictionary.Add("com.rovio." + productName + ".supermagnet_small", IapManager.InAppPurchaseItemType.SuperMagnetSmall);
		this.m_idDictionary.Add("com.rovio." + productName + ".supermagnet_medium", IapManager.InAppPurchaseItemType.SuperMagnetMedium);
		this.m_idDictionary.Add("com.rovio." + productName + ".supermagnet_large", IapManager.InAppPurchaseItemType.SuperMagnetLarge);
		this.m_idDictionary.Add("com.rovio." + productName + ".supermagnet_huge", IapManager.InAppPurchaseItemType.SuperMagnetHuge);
		this.m_idDictionary.Add("com.rovio." + productName + ".turbocharge_single", IapManager.InAppPurchaseItemType.TurboChargeSingle);
		this.m_idDictionary.Add("com.rovio." + productName + ".turbocharge_small", IapManager.InAppPurchaseItemType.TurboChargeSmall);
		this.m_idDictionary.Add("com.rovio." + productName + ".turbocharge_medium", IapManager.InAppPurchaseItemType.TurboChargeMedium);
		this.m_idDictionary.Add("com.rovio." + productName + ".turbocharge_large", IapManager.InAppPurchaseItemType.TurboChargeLarge);
		this.m_idDictionary.Add("com.rovio." + productName + ".turbocharge_huge", IapManager.InAppPurchaseItemType.TurboChargeHuge);
		this.m_idDictionary.Add("com.rovio." + productName + ".nightvision_single", IapManager.InAppPurchaseItemType.NightVisionSingle);
		this.m_idDictionary.Add("com.rovio." + productName + ".nightvision_small", IapManager.InAppPurchaseItemType.NightVisionSmall);
		this.m_idDictionary.Add("com.rovio." + productName + ".nightvision_medium", IapManager.InAppPurchaseItemType.NightVisionMedium);
		this.m_idDictionary.Add("com.rovio." + productName + ".nightvision_large", IapManager.InAppPurchaseItemType.NightVisionLarge);
		this.m_idDictionary.Add("com.rovio." + productName + ".nightvision_huge", IapManager.InAppPurchaseItemType.NightVisionHuge);
		this.m_idDictionary.Add("com.rovio." + productName + ".snout_pack_small", IapManager.InAppPurchaseItemType.SnoutCoinPackSmall);
		this.m_idDictionary.Add("com.rovio." + productName + ".snout_pack_medium", IapManager.InAppPurchaseItemType.SnoutCoinPackMedium);
		this.m_idDictionary.Add("com.rovio." + productName + ".snout_pack_large", IapManager.InAppPurchaseItemType.SnoutCoinPackLarge);
		this.m_idDictionary.Add("com.rovio." + productName + ".snout_pack_huge", IapManager.InAppPurchaseItemType.SnoutCoinPackHuge);
		this.m_idDictionary.Add("com.rovio." + productName + ".snout_pack_ultimate", IapManager.InAppPurchaseItemType.SnoutCoinPackUltimate);
		this.m_idDictionary.Add("com.rovio." + productName + ".snout_pack_small_sale", IapManager.InAppPurchaseItemType.SnoutCoinPackSmallSale);
		this.m_idDictionary.Add("com.rovio." + productName + ".snout_pack_medium_sale", IapManager.InAppPurchaseItemType.SnoutCoinPackMediumSale);
		this.m_idDictionary.Add("com.rovio." + productName + ".snout_pack_large_sale", IapManager.InAppPurchaseItemType.SnoutCoinPackLargeSale);
		this.m_idDictionary.Add("com.rovio." + productName + ".snout_pack_huge_sale", IapManager.InAppPurchaseItemType.SnoutCoinPackHugeSale);
		this.m_idDictionary.Add("com.rovio." + productName + ".snout_pack_ultimate_sale", IapManager.InAppPurchaseItemType.SnoutCoinPackUltimateSale);
		this.m_idDictionary.Add("com.rovio." + productName + ".bundle_small", IapManager.InAppPurchaseItemType.BundleStarterPack);
		this.m_idDictionary.Add("com.rovio." + productName + ".bundle_medium", IapManager.InAppPurchaseItemType.BundleMediumPack);
		this.m_idDictionary.Add("com.rovio." + productName + ".bundle_big", IapManager.InAppPurchaseItemType.BundleBigPack);
		this.m_idDictionary.Add("com.rovio." + productName + ".bundle_huge", IapManager.InAppPurchaseItemType.BundleHugePack);
		this.m_idDictionary.Add("com.rovio." + productName + ".lootcrate_wooden", IapManager.InAppPurchaseItemType.WoodenLootCrate);
		this.m_idDictionary.Add("com.rovio." + productName + ".lootcrate_metal", IapManager.InAppPurchaseItemType.MetalLootCrate);
		this.m_idDictionary.Add("com.rovio." + productName + ".lootcrate_golden", IapManager.InAppPurchaseItemType.GoldenLootCrate);
		this.m_idDictionary.Add("com.rovio." + productName + ".lootcrate_wooden_sale", IapManager.InAppPurchaseItemType.WoodenLootCrateSale);
		this.m_idDictionary.Add("com.rovio." + productName + ".lootcrate_metal_sale", IapManager.InAppPurchaseItemType.MetalLootCrateSale);
		this.m_idDictionary.Add("com.rovio." + productName + ".lootcrate_golden_sale", IapManager.InAppPurchaseItemType.GoldenLootCrateSale);
		this.m_idDictionary.Add("com.rovio." + productName + ".lootcrate_golden_pack", IapManager.InAppPurchaseItemType.GoldenLootCratePack);
		if (Singleton<BuildCustomizationLoader>.Instance.IsChina)
		{
			this.m_idDictionary.Add("com.rovio." + productName + ".unlocktenlevels", IapManager.InAppPurchaseItemType.UnlockTenLevels);
			this.m_idDictionary.Add("com.rovio." + productName + ".unlockninelevels", IapManager.InAppPurchaseItemType.UnlockNineLevels);
			this.m_idDictionary.Add("com.rovio." + productName + ".unlockepisode", IapManager.InAppPurchaseItemType.UnlockEpisode);
			this.m_idDictionary.Add("com.rovio." + productName + ".tendesserts", IapManager.InAppPurchaseItemType.AddTenDesserts);
		}
		this.m_idDictionary.Add("com.rovio." + productName + ".special_sandbox", IapManager.InAppPurchaseItemType.UnlockSpecialSandbox);
		this.m_idDictionary.Add("com.rovio." + productName + ".mechanic", IapManager.InAppPurchaseItemType.PermanentBlueprint);
		this.m_idDictionary.Add("com.rovio." + productName + ".piggy_pack", IapManager.InAppPurchaseItemType.StarterPack);
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.BlueprintSingle, "com.rovio." + productName + ".supermechanic_single");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.BlueprintSmall, "com.rovio." + productName + ".supermechanic_small");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.BlueprintMedium, "com.rovio." + productName + ".supermechanic_medium");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.BlueprintLarge, "com.rovio." + productName + ".supermechanic_large");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.BlueprintHuge, "com.rovio." + productName + ".supermechanic_huge");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SuperGlueSingle, "com.rovio." + productName + ".superglue_single");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SuperGlueSmall, "com.rovio." + productName + ".superglue_small");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SuperGlueMedium, "com.rovio." + productName + ".superglue_medium");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SuperGlueLarge, "com.rovio." + productName + ".superglue_large");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SuperGlueHuge, "com.rovio." + productName + ".superglue_huge");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SuperMagnetSingle, "com.rovio." + productName + ".supermagnet_single");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SuperMagnetSmall, "com.rovio." + productName + ".supermagnet_small");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SuperMagnetMedium, "com.rovio." + productName + ".supermagnet_medium");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SuperMagnetLarge, "com.rovio." + productName + ".supermagnet_large");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SuperMagnetHuge, "com.rovio." + productName + ".supermagnet_huge");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.TurboChargeSingle, "com.rovio." + productName + ".turbocharge_single");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.TurboChargeSmall, "com.rovio." + productName + ".turbocharge_small");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.TurboChargeMedium, "com.rovio." + productName + ".turbocharge_medium");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.TurboChargeLarge, "com.rovio." + productName + ".turbocharge_large");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.TurboChargeHuge, "com.rovio." + productName + ".turbocharge_huge");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.NightVisionSingle, "com.rovio." + productName + ".nightvision_single");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.NightVisionSmall, "com.rovio." + productName + ".nightvision_small");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.NightVisionMedium, "com.rovio." + productName + ".nightvision_medium");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.NightVisionLarge, "com.rovio." + productName + ".nightvision_large");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.NightVisionHuge, "com.rovio." + productName + ".nightvision_huge");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SnoutCoinPackSmall, "com.rovio." + productName + ".snout_pack_small");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SnoutCoinPackMedium, "com.rovio." + productName + ".snout_pack_medium");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SnoutCoinPackLarge, "com.rovio." + productName + ".snout_pack_large");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SnoutCoinPackHuge, "com.rovio." + productName + ".snout_pack_huge");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SnoutCoinPackUltimate, "com.rovio." + productName + ".snout_pack_ultimate");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SnoutCoinPackSmallSale, "com.rovio." + productName + ".snout_pack_small_sale");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SnoutCoinPackMediumSale, "com.rovio." + productName + ".snout_pack_medium_sale");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SnoutCoinPackLargeSale, "com.rovio." + productName + ".snout_pack_large_sale");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SnoutCoinPackHugeSale, "com.rovio." + productName + ".snout_pack_huge_sale");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.SnoutCoinPackUltimateSale, "com.rovio." + productName + ".snout_pack_ultimate_sale");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.BundleStarterPack, "com.rovio." + productName + ".bundle_small");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.BundleMediumPack, "com.rovio." + productName + ".bundle_medium");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.BundleBigPack, "com.rovio." + productName + ".bundle_big");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.BundleHugePack, "com.rovio." + productName + ".bundle_huge");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.WoodenLootCrate, "com.rovio." + productName + ".lootcrate_wooden");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.MetalLootCrate, "com.rovio." + productName + ".lootcrate_metal");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.GoldenLootCrate, "com.rovio." + productName + ".lootcrate_golden");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.WoodenLootCrateSale, "com.rovio." + productName + ".lootcrate_wooden_sale");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.MetalLootCrateSale, "com.rovio." + productName + ".lootcrate_metal_sale");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.GoldenLootCrateSale, "com.rovio." + productName + ".lootcrate_golden_sale");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.GoldenLootCratePack, "com.rovio." + productName + ".lootcrate_golden_pack");
		if (Singleton<BuildCustomizationLoader>.Instance.IsChina)
		{
			this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.UnlockTenLevels, "com.rovio." + productName + ".unlocktenlevels");
			this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.UnlockNineLevels, "com.rovio." + productName + ".unlockninelevels");
			this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.UnlockEpisode, "com.rovio." + productName + ".unlockepisode");
			this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.AddTenDesserts, "com.rovio." + productName + ".tendesserts");
		}
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.UnlockSpecialSandbox, "com.rovio." + productName + ".special_sandbox");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.PermanentBlueprint, "com.rovio." + productName + ".mechanic");
		this.m_itemDictionary.Add(IapManager.InAppPurchaseItemType.StarterPack, "com.rovio." + productName + ".piggy_pack");
		this.m_bundlesInfo.Add(IapManager.InAppPurchaseItemType.BundleStarterPack, null);
		this.m_bundlesInfo.Add(IapManager.InAppPurchaseItemType.BundleMediumPack, null);
		this.m_bundlesInfo.Add(IapManager.InAppPurchaseItemType.BundleBigPack, null);
		this.m_bundlesInfo.Add(IapManager.InAppPurchaseItemType.BundleHugePack, null);
	}

	private string[] GetPurchasableItemIdentifiers()
	{
		string productName = IapManager.GetProductName();
		List<string> list = new List<string>();
		foreach (KeyValuePair<InAppPurchaseItemType, string> keyValuePair in this.m_itemDictionary)
		{
			if ((keyValuePair.Key == IapManager.InAppPurchaseItemType.SnoutCoinPackMediumSale && Singleton<BuildCustomizationLoader>.Instance.CustomerID.ToLower().Equals("amazon") && productName.ToLower().Equals("badpiggieshdfree")) || (keyValuePair.Key == IapManager.InAppPurchaseItemType.SnoutCoinPackHugeSale && Singleton<BuildCustomizationLoader>.Instance.CustomerID.ToLower().Equals("apple")))
			{
				list.Add(keyValuePair.Value + "1");
			}
			else
			{
				list.Add(keyValuePair.Value);
			}
		}
		return list.ToArray();
	}

	public void EnableUnlockFullVersionPurchasePage()
	{
		this.m_iapUnlockFullVersionPageInstance.transform.position = GameObject.FindGameObjectWithTag("HUDCamera").transform.position + Vector3.forward * 5f;
		this.m_iapUnlockFullVersionPageInstance.SetActive(base.enabled);
		this.m_iapUnlockFullVersionPageInstance.GetComponent<InGameInAppPurchaseMenu>().OpenDialog();
	}

	public void EnableUnlockFullVersionPurchasePage(InGameInAppPurchaseMenu.OnClose onClose)
	{
		this.m_iapUnlockFullVersionPageInstance.transform.position = GameObject.FindGameObjectWithTag("HUDCamera").transform.position + Vector3.forward * 5f;
		this.m_iapUnlockFullVersionPageInstance.SetActive(base.enabled);
		this.m_iapUnlockFullVersionPageInstance.GetComponent<InGameInAppPurchaseMenu>().onClose += onClose;
	}

	public bool IsShopPageOpened()
	{
		return this.m_ShopPageInstance.activeInHierarchy;
	}

	public void OpenShopPage(Action onClose, string pageName = null)
	{
		this.m_ShopPageInstance.GetComponent<Shop>().Open(onClose, pageName);
	}

	public Shop GetShop()
	{
		if (this.m_Shop == null)
		{
			this.m_Shop = this.m_ShopPageInstance.GetComponent<Shop>();
		}
		return this.m_Shop;
	}

	public void ShowErrorPopup(string message)
	{
		this.m_errorPopupInstance.transform.position = GameObject.FindGameObjectWithTag("HUDCamera").transform.position + Vector3.forward * 1.5f;
		this.m_errorPopupInstance.SetActive(true);
		NotificationPopup componentInChildren = this.m_errorPopupInstance.GetComponentInChildren<NotificationPopup>();
		componentInChildren.SetText(message);
		componentInChildren.onClose += delegate ()
		{
			this.m_ShopPageInstance.GetComponent<Shop>().UnlockScreen(IapManager.InAppPurchaseItemType.Undefined);
		};
		componentInChildren.Open();
	}

	private void AddBundleItem(BundleItem item)
	{
		switch (item.type)
		{
			case IapManager.BundleItem.BundleItemType.Blueprint:
				GameProgress.AddBluePrints(item.count);
				break;
			case IapManager.BundleItem.BundleItemType.SuperGlue:
				GameProgress.AddSuperGlue(item.count);
				break;
			case IapManager.BundleItem.BundleItemType.SuperMagnet:
				GameProgress.AddSuperMagnet(item.count);
				break;
			case IapManager.BundleItem.BundleItemType.TurboCharge:
				GameProgress.AddTurboCharge(item.count);
				break;
			case IapManager.BundleItem.BundleItemType.NightVision:
				GameProgress.AddNightVision(item.count);
				break;
		}
	}

	private bool DeliverItem(InAppPurchaseItemType product)
	{
		int purchaseItemTypeCount = this.GetPurchaseItemTypeCount(product);
		switch (product)
		{
			case IapManager.InAppPurchaseItemType.Undefined:
				return false;
			case IapManager.InAppPurchaseItemType.UnlockFullVersion:
				if (GameProgress.GetFullVersionUnlocked())
				{
					return false;
				}
				GameProgress.SetFullVersionUnlocked(true);
				break;
			case IapManager.InAppPurchaseItemType.UnlockSpecialSandbox:
				this.TryGiveFreeCrate("S-F_GoldenCrate", "fod");
				if (GameProgress.GetSandboxUnlocked("S-F"))
				{
					return false;
				}
				GameProgress.SetSandboxUnlocked("S-F", true);
				GameProgress.UnlockButton("EpisodeButtonSandbox");
				break;
			case IapManager.InAppPurchaseItemType.BlueprintSmall:
			case IapManager.InAppPurchaseItemType.BlueprintMedium:
			case IapManager.InAppPurchaseItemType.BlueprintLarge:
			case IapManager.InAppPurchaseItemType.BlueprintHuge:
			case IapManager.InAppPurchaseItemType.BlueprintSingle:
				GameProgress.AddBluePrints(purchaseItemTypeCount);
				this.SendFlurryInventoryGainEvent(product, purchaseItemTypeCount, string.Empty);
				break;
			case IapManager.InAppPurchaseItemType.SuperGlueSmall:
			case IapManager.InAppPurchaseItemType.SuperGlueMedium:
			case IapManager.InAppPurchaseItemType.SuperGlueLarge:
			case IapManager.InAppPurchaseItemType.SuperGlueHuge:
			case IapManager.InAppPurchaseItemType.SuperGlueSingle:
				GameProgress.AddSuperGlue(purchaseItemTypeCount);
				this.SendFlurryInventoryGainEvent(product, purchaseItemTypeCount, string.Empty);
				break;
			case IapManager.InAppPurchaseItemType.SuperMagnetSmall:
			case IapManager.InAppPurchaseItemType.SuperMagnetMedium:
			case IapManager.InAppPurchaseItemType.SuperMagnetLarge:
			case IapManager.InAppPurchaseItemType.SuperMagnetHuge:
			case IapManager.InAppPurchaseItemType.SuperMagnetSingle:
				GameProgress.AddSuperMagnet(purchaseItemTypeCount);
				this.SendFlurryInventoryGainEvent(product, purchaseItemTypeCount, string.Empty);
				break;
			case IapManager.InAppPurchaseItemType.TurboChargeSmall:
			case IapManager.InAppPurchaseItemType.TurboChargeMedium:
			case IapManager.InAppPurchaseItemType.TurboChargeLarge:
			case IapManager.InAppPurchaseItemType.TurboChargeHuge:
			case IapManager.InAppPurchaseItemType.TurboChargeSingle:
				GameProgress.AddTurboCharge(purchaseItemTypeCount);
				this.SendFlurryInventoryGainEvent(product, purchaseItemTypeCount, string.Empty);
				break;
			case IapManager.InAppPurchaseItemType.PermanentBlueprint:
				if (GameProgress.GetPermanentBlueprint())
				{
					return false;
				}
				GameProgress.SetPermanentBlueprint(true);
				break;
			case IapManager.InAppPurchaseItemType.BundleStarterPack:
			case IapManager.InAppPurchaseItemType.BundleMediumPack:
			case IapManager.InAppPurchaseItemType.BundleBigPack:
			case IapManager.InAppPurchaseItemType.BundleHugePack:
				{
					BundleItem[] productRewardsAsBundleItems = Singleton<VirtualCatalogManager>.Instance.GetProductRewardsAsBundleItems(product);
					foreach (BundleItem item in productRewardsAsBundleItems)
					{
						this.AddBundleItem(item);
						this.SendFlurryInventoryGainEvent(item.type, item.count);
					}
					break;
				}
			case IapManager.InAppPurchaseItemType.UnlockTenLevels:
				GameProgress.SetMinimumLockedLevel(Singleton<GameManager>.Instance.CurrentEpisodeIndex, GameProgress.GetMinimumLockedLevel(Singleton<GameManager>.Instance.CurrentEpisodeIndex) + 10);
				break;
			case IapManager.InAppPurchaseItemType.UnlockEpisode:
				GameProgress.SetMinimumLockedLevel(Singleton<GameManager>.Instance.CurrentEpisodeIndex, GameProgress.GetMinimumLockedLevel(Singleton<GameManager>.Instance.CurrentEpisodeIndex) + 100);
				break;
			case IapManager.InAppPurchaseItemType.AddTenDesserts:
				{
					GameProgress.AddDesserts("GoldenCake", 2);
					int max = Singleton<GameManager>.Instance.gameData.m_desserts.Count - 1;
					int num = 8;
					for (int j = 0; j < num; j++)
					{
						string name = Singleton<GameManager>.Instance.gameData.m_desserts[UnityEngine.Random.Range(0, max)].name;
						GameProgress.AddDesserts(name, 1);
					}
					Singleton<GameManager>.Instance.LoadKingPigFeed(false);
					break;
				}
			case IapManager.InAppPurchaseItemType.UnlockNineLevels:
				GameProgress.SetMinimumLockedLevel(Singleton<GameManager>.Instance.CurrentEpisodeIndex, GameProgress.GetMinimumLockedLevel(Singleton<GameManager>.Instance.CurrentEpisodeIndex) + 10);
				break;
			case IapManager.InAppPurchaseItemType.NightVisionSmall:
			case IapManager.InAppPurchaseItemType.NightVisionMedium:
			case IapManager.InAppPurchaseItemType.NightVisionLarge:
			case IapManager.InAppPurchaseItemType.NightVisionHuge:
			case IapManager.InAppPurchaseItemType.NightVisionSingle:
				GameProgress.AddNightVision(purchaseItemTypeCount);
				this.SendFlurryInventoryGainEvent(product, purchaseItemTypeCount, string.Empty);
				break;
			case IapManager.InAppPurchaseItemType.SnoutCoinPackSmall:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackMedium:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackLarge:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackHuge:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackUltimate:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackSmallSale:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackMediumSale:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackLargeSale:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackHugeSale:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackUltimateSale:
				GameProgress.AddSnoutCoins(purchaseItemTypeCount);
				break;
			case IapManager.InAppPurchaseItemType.StarterPack:
				this.TryGiveFreeCrate("Starter_GoldenCrate", "starter");
				if (GameProgress.HasStarterPack())
				{
					return false;
				}
				GameProgress.SetStarterPack(true);
				GameProgress.AddSnoutCoins(purchaseItemTypeCount);
				break;
			case IapManager.InAppPurchaseItemType.WoodenLootCrate:
			case IapManager.InAppPurchaseItemType.MetalLootCrate:
			case IapManager.InAppPurchaseItemType.GoldenLootCrate:
			case IapManager.InAppPurchaseItemType.WoodenLootCrateSale:
			case IapManager.InAppPurchaseItemType.MetalLootCrateSale:
			case IapManager.InAppPurchaseItemType.GoldenLootCrateSale:
			case IapManager.InAppPurchaseItemType.GoldenLootCratePack:
				{
					LootCrateType crateType = LootCrateType.Wood;
					if (product == IapManager.InAppPurchaseItemType.MetalLootCrate || product == IapManager.InAppPurchaseItemType.MetalLootCrateSale)
					{
						crateType = LootCrateType.Metal;
					}
					else if (product == IapManager.InAppPurchaseItemType.GoldenLootCrate || product == IapManager.InAppPurchaseItemType.GoldenLootCrateSale || product == IapManager.InAppPurchaseItemType.GoldenLootCratePack)
					{
						crateType = LootCrateType.Gold;
					}
					string gainType = "shop";
					string price = "0";
					switch (product)
					{
						case IapManager.InAppPurchaseItemType.WoodenLootCrate:
							price = Singleton<VirtualCatalogManager>.Instance.GetProductPrice("lootcrate_wooden").ToString();
							break;
						case IapManager.InAppPurchaseItemType.MetalLootCrate:
							price = this.CentsToDecimal(Singleton<VirtualCatalogManager>.Instance.GetProductPrice("lootcrate_metal"));
							break;
						case IapManager.InAppPurchaseItemType.GoldenLootCrate:
							price = this.CentsToDecimal(Singleton<VirtualCatalogManager>.Instance.GetProductPrice("lootcrate_gold"));
							break;
						case IapManager.InAppPurchaseItemType.WoodenLootCrateSale:
							price = Singleton<VirtualCatalogManager>.Instance.GetProductPrice("lootcrate_wooden_sale").ToString();
							break;
						case IapManager.InAppPurchaseItemType.MetalLootCrateSale:
							price = this.CentsToDecimal(Singleton<VirtualCatalogManager>.Instance.GetProductPrice("lootcrate_metal_sale"));
							break;
						case IapManager.InAppPurchaseItemType.GoldenLootCrateSale:
							price = this.CentsToDecimal(Singleton<VirtualCatalogManager>.Instance.GetProductPrice("lootcrate_gold_sale"));
							break;
						case IapManager.InAppPurchaseItemType.GoldenLootCratePack:
							price = this.CentsToDecimal(Singleton<VirtualCatalogManager>.Instance.GetProductPrice("lootcrate_gold_pack"));
							break;
					}
					int amount = 1;
					if (product == IapManager.InAppPurchaseItemType.GoldenLootCratePack)
					{
						amount = 3;
					}
					this.GiveLootCrate(crateType, amount, price, gainType);
					break;
				}
		}
		this.SendCompletedPurchaseFlurryEvent(product);
		return true;
	}

	private void TryGiveFreeCrate(string key, string analyticName)
	{
		if (!GameProgress.GetBool(key, false, GameProgress.Location.Local, null))
		{
			this.GiveLootCrate(LootCrateType.Gold, 1, "free", analyticName);
			GameProgress.SetBool(key, true, GameProgress.Location.Local);
		}
	}

	private void GiveLootCrate(LootCrateType crateType, int amount, string price, string gainType)
	{
		GameProgress.AddLootcrate(crateType, amount);
		WorkshopMenu.AnyLootCrateCollected = true;
		Camera hudCamera = Singleton<GuiManager>.Instance.FindCamera();
		LootCrate.SpawnLootCrateOpeningDialog(crateType, amount, hudCamera, null, new LootCrate.AnalyticData(gainType, price, LootCrate.AdWatched.NotApplicaple));
	}

	private string CentsToDecimal(int cents)
	{
		return string.Format("{0}.{1}", Mathf.FloorToInt((float)cents / 100f), cents % 100);
	}

	private void SendFlurryInventoryGainEvent(BundleItem.BundleItemType type, int amount)
	{
		switch (type)
		{
			case IapManager.BundleItem.BundleItemType.Blueprint:
				this.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.BlueprintSingle, amount, string.Empty);
				break;
			case IapManager.BundleItem.BundleItemType.SuperGlue:
				this.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.SuperGlueSingle, amount, string.Empty);
				break;
			case IapManager.BundleItem.BundleItemType.SuperMagnet:
				this.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.SuperMagnetSingle, amount, string.Empty);
				break;
			case IapManager.BundleItem.BundleItemType.TurboCharge:
				this.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.TurboChargeSingle, amount, string.Empty);
				break;
			case IapManager.BundleItem.BundleItemType.NightVision:
				this.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.NightVisionSingle, amount, string.Empty);
				break;
		}
	}

	public void SendFlurryInventoryGainEvent(InAppPurchaseItemType type, int amount, string customTypeOfGain = "")
	{
	}

	private void SendStartPurchaseFlurryEvent(InAppPurchaseItemType type)
	{
	}

	public bool IsItemPurchased(InAppPurchaseItemType type)
	{
		if (type == IapManager.InAppPurchaseItemType.UnlockFullVersion)
		{
			return GameProgress.GetFullVersionUnlocked();
		}
		if (type == IapManager.InAppPurchaseItemType.UnlockSpecialSandbox)
		{
			return GameProgress.GetSandboxUnlocked("S-F");
		}
		if (type != IapManager.InAppPurchaseItemType.PermanentBlueprint)
		{
			return type == IapManager.InAppPurchaseItemType.StarterPack && GameProgress.HasStarterPack();
		}
		return GameProgress.GetPermanentBlueprint();
	}

	public bool IsCurrencyPack(InAppPurchaseItemType type)
	{
		switch (type)
		{
			case IapManager.InAppPurchaseItemType.SnoutCoinPackSmall:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackMedium:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackLarge:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackHuge:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackUltimate:
			case IapManager.InAppPurchaseItemType.StarterPack:
				break;
			default:
				switch (type)
				{
					case IapManager.InAppPurchaseItemType.SnoutCoinPackSmallSale:
					case IapManager.InAppPurchaseItemType.SnoutCoinPackMediumSale:
					case IapManager.InAppPurchaseItemType.SnoutCoinPackLargeSale:
					case IapManager.InAppPurchaseItemType.SnoutCoinPackHugeSale:
					case IapManager.InAppPurchaseItemType.SnoutCoinPackUltimateSale:
						break;
					default:
						return false;
				}
				break;
		}
		return true;
	}

	public bool IsPowerUp(InAppPurchaseItemType type)
	{
		switch (type)
		{
			case IapManager.InAppPurchaseItemType.BlueprintSmall:
			case IapManager.InAppPurchaseItemType.BlueprintMedium:
			case IapManager.InAppPurchaseItemType.BlueprintLarge:
			case IapManager.InAppPurchaseItemType.BlueprintHuge:
			case IapManager.InAppPurchaseItemType.SuperGlueSmall:
			case IapManager.InAppPurchaseItemType.SuperGlueMedium:
			case IapManager.InAppPurchaseItemType.SuperGlueLarge:
			case IapManager.InAppPurchaseItemType.SuperGlueHuge:
			case IapManager.InAppPurchaseItemType.SuperMagnetSmall:
			case IapManager.InAppPurchaseItemType.SuperMagnetMedium:
			case IapManager.InAppPurchaseItemType.SuperMagnetLarge:
			case IapManager.InAppPurchaseItemType.SuperMagnetHuge:
			case IapManager.InAppPurchaseItemType.TurboChargeSmall:
			case IapManager.InAppPurchaseItemType.TurboChargeMedium:
			case IapManager.InAppPurchaseItemType.TurboChargeLarge:
			case IapManager.InAppPurchaseItemType.TurboChargeHuge:
			case IapManager.InAppPurchaseItemType.NightVisionSmall:
			case IapManager.InAppPurchaseItemType.NightVisionMedium:
			case IapManager.InAppPurchaseItemType.NightVisionLarge:
			case IapManager.InAppPurchaseItemType.NightVisionHuge:
			case IapManager.InAppPurchaseItemType.BlueprintSingle:
			case IapManager.InAppPurchaseItemType.SuperGlueSingle:
			case IapManager.InAppPurchaseItemType.SuperMagnetSingle:
			case IapManager.InAppPurchaseItemType.TurboChargeSingle:
			case IapManager.InAppPurchaseItemType.NightVisionSingle:
				return true;
		}
		return false;
	}

	public int GetPurchaseItemTypeCount(InAppPurchaseItemType type)
	{
		if (this.SnoutCoinPurchasable(type))
		{
			Hashtable productRewards = Singleton<VirtualCatalogManager>.Instance.GetProductRewards(type);
			if (productRewards != null)
			{
				IDictionaryEnumerator enumerator = productRewards.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
						if (Enum.IsDefined(typeof(BundleItem.BundleItemType), (string)dictionaryEntry.Key))
						{
							return int.Parse((string)dictionaryEntry.Value);
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
				return 0;
			}
			return 0;
		}
		if (this.m_countDictionary.ContainsKey(type))
		{
			return this.m_countDictionary[type];
		}
		if (this.IsBundleProduct(type))
		{
			return 1;
		}
		if (this.IsLootCrateIAP(type))
		{
			return 1;
		}
		return 0;
	}

	public string PreparePrice(string formattedPrice)
	{
		return formattedPrice;
	}

	public bool HasProduct(InAppPurchaseItemType productType)
	{
		if (Singleton<IapManager>.Instance.ProductList != null)
		{
			string prodId = Singleton<IapManager>.Instance.GetProductIdByItem(productType);
			if (!string.IsNullOrEmpty(prodId))
			{
				foreach (IAPProductInfo x in Singleton<IapManager>.Instance.ProductList)
				{
					if (x.productId == prodId)
					{
						return true;
					}
				}
				return false;
			}
		}
		return false;
	}

	public string GetFlurryItemName(InAppPurchaseItemType type)
	{
		switch (type)
		{
			case IapManager.InAppPurchaseItemType.BlueprintSmall:
			case IapManager.InAppPurchaseItemType.BlueprintMedium:
			case IapManager.InAppPurchaseItemType.BlueprintLarge:
			case IapManager.InAppPurchaseItemType.BlueprintHuge:
			case IapManager.InAppPurchaseItemType.BlueprintSingle:
				return "Blueprint";
			case IapManager.InAppPurchaseItemType.SuperGlueSmall:
			case IapManager.InAppPurchaseItemType.SuperGlueMedium:
			case IapManager.InAppPurchaseItemType.SuperGlueLarge:
			case IapManager.InAppPurchaseItemType.SuperGlueHuge:
			case IapManager.InAppPurchaseItemType.SuperGlueSingle:
				return "Super Glue";
			case IapManager.InAppPurchaseItemType.SuperMagnetSmall:
			case IapManager.InAppPurchaseItemType.SuperMagnetMedium:
			case IapManager.InAppPurchaseItemType.SuperMagnetLarge:
			case IapManager.InAppPurchaseItemType.SuperMagnetHuge:
			case IapManager.InAppPurchaseItemType.SuperMagnetSingle:
				return "Super Magnet";
			case IapManager.InAppPurchaseItemType.TurboChargeSmall:
			case IapManager.InAppPurchaseItemType.TurboChargeMedium:
			case IapManager.InAppPurchaseItemType.TurboChargeLarge:
			case IapManager.InAppPurchaseItemType.TurboChargeHuge:
			case IapManager.InAppPurchaseItemType.TurboChargeSingle:
				return "Turbo Charge";
			case IapManager.InAppPurchaseItemType.BundleStarterPack:
			case IapManager.InAppPurchaseItemType.BundleMediumPack:
			case IapManager.InAppPurchaseItemType.BundleBigPack:
			case IapManager.InAppPurchaseItemType.BundleHugePack:
				return "Powerup Bundle";
			case IapManager.InAppPurchaseItemType.NightVisionSmall:
			case IapManager.InAppPurchaseItemType.NightVisionMedium:
			case IapManager.InAppPurchaseItemType.NightVisionLarge:
			case IapManager.InAppPurchaseItemType.NightVisionHuge:
			case IapManager.InAppPurchaseItemType.NightVisionSingle:
				return "Nightvision";
			case IapManager.InAppPurchaseItemType.SnoutCoinPackSmall:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackMedium:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackLarge:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackHuge:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackUltimate:
				return "Snout Coin";
			case IapManager.InAppPurchaseItemType.SnoutCoinPackSmallSale:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackMediumSale:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackLargeSale:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackHugeSale:
			case IapManager.InAppPurchaseItemType.SnoutCoinPackUltimateSale:
				return "Snout Coin Sale";
		}
		return type.ToString();
	}

	private void SendCompletedPurchaseFlurryEvent(InAppPurchaseItemType type)
	{
	}

	// Note: this type is marked as 'beforefieldinit'.
	static IapManager()
	{
		IapManager.onPurchaseSucceeded = delegate (InAppPurchaseItemType A_0)
		{
		};
		IapManager.onPurchaseFailed = delegate (InAppPurchaseItemType A_0)
		{
		};
		IapManager.onProductListReceived = delegate (List<IAPProductInfo> A_0, string A_1)
		{
		};
		IapManager.onRestorePurchaseComplete = delegate (bool A_0)
		{
		};
	}

	[SerializeField]
	private GameObject m_iapUnlockFullVersionPage;

	private GameObject m_iapUnlockFullVersionPageInstance;

	[SerializeField]
	private GameObject m_errorPopup;

	private GameObject m_errorPopupInstance;

	[SerializeField]
	private GameObject m_ShopPage;

	private GameObject m_ShopPageInstance;

	private Shop m_Shop;

	public string m_priceAllowedChars;

	public GameObject m_reward;

	[SerializeField]
	private TextAsset m_catalog;

	private const float purchaseTimeout = 10f;

	private Dictionary<string, InAppPurchaseItemType> m_idDictionary = new Dictionary<string, InAppPurchaseItemType>();

	private Dictionary<InAppPurchaseItemType, string> m_itemDictionary = new Dictionary<InAppPurchaseItemType, string>();

	private Dictionary<InAppPurchaseItemType, BundleItem[]> m_bundlesInfo = new Dictionary<InAppPurchaseItemType, BundleItem[]>();

	private Dictionary<InAppPurchaseItemType, int> m_countDictionary = new Dictionary<InAppPurchaseItemType, int>();

	private Dictionary<InAppPurchaseItemType, int> m_priceDictionary = new Dictionary<InAppPurchaseItemType, int>();

	private InAppPurchaseStatus m_state;

	private InAppPurchaseItemType m_activePurchase;

	private const string NORMAL_COUNT = "normalCount";

	private const string CHINA_COUNT = "chinaCount";

	private const string BUNDLE_ITEMS = "bundleItems";

	private const string ITEM_TYPE = "itemType";

	private const string SNOUT_COIN_PRICE = "snoutCoinPrice";

	private const string SNOUT_COIN_COUNT = "snoutCoinCount";

	private List<IAPProductInfo> productList;

	private IAPInterface m_iap;

	public delegate void PurchaseSucceeded(InAppPurchaseItemType type);

	public delegate void PurchaseFailed(InAppPurchaseItemType type);

	public delegate void RestorePurchaseComplete(bool isSucceeded);

	public delegate void ProductListReceived(List<IAPProductInfo> products, string error);

	public struct PurchaseEvent : EventManager.Event
	{
		public PurchaseEvent(InAppPurchaseItemType itemType)
		{
			this.itemType = itemType;
		}

		public InAppPurchaseItemType itemType;
	}

	public struct BundleItem
	{
		public BundleItem(BundleItemType type, int count)
		{
			this.type = type;
			this.count = count;
		}

		public readonly BundleItemType type;

		public readonly int count;

		public enum BundleItemType
		{
			Undefined,
			Blueprint,
			SuperGlue,
			SuperMagnet,
			TurboCharge,
			NightVision
		}
	}

	public enum InAppPurchaseStatus
	{
		Init,
		Idle,
		FetchingItems,
		PurchasingItem
	}

	public enum CurrencyType
	{
		RealMoney,
		SnoutCoin,
		Scrap
	}

	public enum InAppPurchaseItemType
	{
		Undefined,
		UnlockFullVersion,
		UnlockSpecialSandbox,
		BlueprintSmall,
		BlueprintMedium,
		BlueprintLarge,
		BlueprintHuge,
		BlueprintUltimate,
		SuperGlueSmall,
		SuperGlueMedium,
		SuperGlueLarge,
		SuperGlueHuge,
		SuperGlueUltimate,
		SuperMagnetSmall,
		SuperMagnetMedium,
		SuperMagnetLarge,
		SuperMagnetHuge,
		SuperMagnetUltimate,
		TurboChargeSmall,
		TurboChargeMedium,
		TurboChargeLarge,
		TurboChargeHuge,
		TurboChargeUltimate,
		PermanentBlueprint,
		BundleStarterPack,
		BundleMediumPack,
		BundleBigPack,
		UnlockTenLevels,
		UnlockEpisode,
		AddTenDesserts,
		UnlockNineLevels,
		NightVisionSmall,
		NightVisionMedium,
		NightVisionLarge,
		NightVisionHuge,
		NightVisionUltimate,
		SnoutCoinPackSmall,
		SnoutCoinPackMedium,
		SnoutCoinPackLarge,
		SnoutCoinPackHuge,
		SnoutCoinPackUltimate,
		BundleHugePack,
		StarterPack,
		BlueprintSingle,
		SuperGlueSingle,
		SuperMagnetSingle,
		TurboChargeSingle,
		NightVisionSingle,
		WoodenLootCrate,
		MetalLootCrate,
		GoldenLootCrate,
		WoodenLootCrateSale,
		MetalLootCrateSale,
		GoldenLootCrateSale,
		GoldenLootCratePack,
		SnoutCoinPackSmallSale,
		SnoutCoinPackMediumSale,
		SnoutCoinPackLargeSale,
		SnoutCoinPackHugeSale,
		SnoutCoinPackUltimateSale
	}

	public enum CodeRedeemError
	{
		AlreadyUsed,
		AlreadyOwned,
		Invalid
	}
}
