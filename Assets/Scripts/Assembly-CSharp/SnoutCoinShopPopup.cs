using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;

public class SnoutCoinShopPopup : MonoBehaviour
{
	public GameObject BestValueRibbon
	{
		get
		{
			return this.m_bestValueRibbon;
		}
	}

	public GameObject MostPopularRibbon
	{
		get
		{
			return this.m_mostPopularRibbon;
		}
	}

	public static bool DialogOpen
	{
		get
		{
			return SnoutCoinShopPopup.s_dialogOpen;
		}
	}

	private void Start()
	{
		this.m_playingAnimation = false;
		this.m_hugePackAnimation.timeScale = float.MaxValue;
		this.m_hugePackAnimation.AnimationState.AddAnimation(0, "SafeIdle", false, 0f);
		this.m_hugePackAnimation.AnimationState.End += this.OnAnimationEnd;
		this.m_largePackAnimation.timeScale = float.MaxValue;
		this.m_largePackAnimation.AnimationState.AddAnimation(0, "BarrelIdle", false, 0f);
		this.m_largePackAnimation.AnimationState.End += this.OnAnimationEnd;
		this.m_mediumPackAnimation.timeScale = float.MaxValue;
		this.m_mediumPackAnimation.AnimationState.AddAnimation(0, "CoinPillar_Idle", false, 0f);
		this.m_mediumPackAnimation.AnimationState.End += this.OnAnimationEnd;
		this.m_smallPackAnimation.timeScale = float.MaxValue;
		this.m_smallPackAnimation.AnimationState.AddAnimation(0, "PiggieBankIdle", false, 0f);
		this.m_smallPackAnimation.AnimationState.End += this.OnAnimationEnd;
		this.m_ultimatePackAnimation.AnimationState.AddAnimation(0, "Shower_Idle", true, 0f);
		base.StartCoroutine(this.PlayRandomAnimation(2f));
	}

	private void OnEnable()
	{
		this.m_bestValueRibbon.SetActive(false);
		this.m_mostPopularRibbon.SetActive(false);
		this.ShowOfferBanner(false);
		this.UpdatePrices(null);
		SnoutCoinShopPopup.s_dialogOpen = true;
		EventManager.Send(new UIEvent(UIEvent.Type.OpenedSnoutCoinShop));
	}

	private void OnDisable()
	{
		SnoutCoinShopPopup.s_dialogOpen = false;
		EventManager.Send(new UIEvent(UIEvent.Type.ClosedSnoutCoinShop));
	}

	private void OnDestroy()
	{
		this.m_hugePackAnimation.AnimationState.End -= this.OnAnimationEnd;
		this.m_largePackAnimation.AnimationState.End -= this.OnAnimationEnd;
		this.m_mediumPackAnimation.AnimationState.End -= this.OnAnimationEnd;
		this.m_smallPackAnimation.AnimationState.End -= this.OnAnimationEnd;
	}

	public void ShowOfferBanner(bool show)
	{
		if (this.m_offerBanner != null)
		{
			this.m_offerBanner.SetActive(show);
		}
	}

	public GameObject AddRibbon(ShopRibbon ribbon)
	{
		Transform transform = base.transform.Find("Items/" + ribbon.itemId);
		if (!transform)
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
				original = this.m_mostPopularRibbon;
			}
		}
		else
		{
			text = "BestValueRibbon";
			original = this.m_bestValueRibbon;
		}
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		Transform transform2 = transform.Find(text);
		GameObject gameObject = null;
		if (transform2 != null)
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
			gameObject.name = text;
			gameObject.transform.parent = transform2;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
			gameObject.SetActive(true);
		}
		return gameObject;
	}

	public void UpdatePrices(Shop _shop = null)
	{
		if (_shop != null)
		{
			this.shop = _shop;
		}
		if (this.shop == null)
		{
			return;
		}
		bool show = false;
		PurchaseInfo[] componentsInChildren = base.gameObject.GetComponentsInChildren<PurchaseInfo>();
		foreach (PurchaseInfo purchaseInfo in componentsInChildren)
		{
			Button component = purchaseInfo.GetComponent<Button>();
			if (component != null)
			{
				if (purchaseInfo.purchaseItem == IapManager.InAppPurchaseItemType.StarterPack)
				{
					component.MethodToCall.SetMethod(this.shop, "PurchaseItem");
				}
				else
				{
					component.MethodToCall.SetMethod(purchaseInfo, "Purchase");
				}
			}
			purchaseInfo.CheckOnSale();
			string text = (!purchaseInfo.isSaleItem) ? null : this.shop.GetFormattedPrice(purchaseInfo.saleItem);
			if (!string.IsNullOrEmpty(text))
			{
				show = true;
			}
			this.shop.SetPriceIndicator(purchaseInfo, this.shop.GetFormattedPrice(purchaseInfo.purchaseItem), text);
		}
		this.ShowOfferBanner(show);
	}

	public void Open(Action onClose)
	{
		Singleton<GuiManager>.Instance.GrabPointer(this);
		Singleton<KeyListener>.Instance.GrabFocus(this);
		KeyListener.keyReleased += this.HandleKeyReleased;
		this.OnClose = onClose;
		base.gameObject.SetActive(true);
		ResourceBar.Instance.ShowItem(ResourceBar.Item.SnoutCoin, true, false);
		DoubleRewardIcon.Instance.SetSortingLayer("Default");
	}

	public void Close()
	{
		Singleton<GuiManager>.Instance.ReleasePointer(this);
		Singleton<KeyListener>.Instance.ReleaseFocus(this);
		KeyListener.keyReleased -= this.HandleKeyReleased;
		if (this.OnClose != null)
		{
			this.OnClose();
		}
		base.gameObject.SetActive(false);
		if (SnoutButton.Instance != null)
		{
			SnoutButton.Instance.EnableButton(true);
		}
		if (DoubleRewardIcon.Instance != null)
		{
			DoubleRewardIcon.Instance.SetSortingLayer("Popup");
		}
	}

	private void HandleKeyReleased(KeyCode key)
	{
		if (key == KeyCode.Escape)
		{
			this.Close();
		}
	}

	private IEnumerator PlayRandomAnimation(float interval)
	{
		float counter = 0f;
		while (base.gameObject.activeInHierarchy)
		{
			if (counter > interval)
			{
				counter = 0f;
				this.m_playingAnimation = true;
				this.PlayRandomAnimation();
			}
			else if (!this.m_playingAnimation)
			{
				counter += Time.deltaTime;
			}
			yield return null;
		}
		yield break;
	}

	private void PlayRandomAnimation()
	{
		switch (UnityEngine.Random.Range(0, 4))
		{
		default:
			this.m_hugePackAnimation.timeScale = 1f;
			this.m_hugePackAnimation.AnimationState.AddAnimation(0, "SafeIdle", false, 0f);
			break;
		case 1:
			this.m_largePackAnimation.timeScale = 1f;
			this.m_largePackAnimation.AnimationState.AddAnimation(0, "BarrelIdle", false, 0f);
			break;
		case 2:
			this.m_mediumPackAnimation.timeScale = 1f;
			this.m_mediumPackAnimation.AnimationState.AddAnimation(0, "CoinPillar_Idle", false, 0f);
			break;
		case 3:
			this.m_smallPackAnimation.timeScale = 1f;
			this.m_smallPackAnimation.AnimationState.AddAnimation(0, "PiggieBankIdle", false, 0f);
			break;
		}
	}

	private void OnAnimationEnd(Spine.AnimationState state, int trackIndex)
	{
		this.m_playingAnimation = false;
	}

	[SerializeField]
	private GameObject m_bestValueRibbon;

	[SerializeField]
	private GameObject m_mostPopularRibbon;

	[SerializeField]
	private GameObject m_offerBanner;

	[SerializeField]
	private SkeletonAnimation m_ultimatePackAnimation;

	[SerializeField]
	private SkeletonAnimation m_hugePackAnimation;

	[SerializeField]
	private SkeletonAnimation m_largePackAnimation;

	[SerializeField]
	private SkeletonAnimation m_mediumPackAnimation;

	[SerializeField]
	private SkeletonAnimation m_smallPackAnimation;

	private bool m_playingAnimation;

	private static bool s_dialogOpen;

	private Shop shop;

	private Action OnClose;
}
