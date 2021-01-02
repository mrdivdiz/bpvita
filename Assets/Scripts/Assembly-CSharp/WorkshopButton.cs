using System;
using UnityEngine;

public class WorkshopButton : Button
{
	protected override void ButtonAwake()
	{
		bool flag = WorkshopMenu.FirstLootCrateCollected || WorkshopMenu.AnyLootCrateCollected;
		bool @bool = GameProgress.GetBool("Workshop_Visited", false, GameProgress.Location.Local, null);
		base.gameObject.SetActive(flag);
		if (flag && !@bool)
		{
			this.Wiggle();
		}
		else if (!flag && !@bool)
		{
			FreeLootCrate.OnFreeLootCrateCollected = (Action)Delegate.Combine(FreeLootCrate.OnFreeLootCrateCollected, new Action(this.ButtonAwake));
			IapManager.onPurchaseSucceeded += this.OnItemPurchase;
		}
	}

	private void OnDestroy()
	{
		FreeLootCrate.OnFreeLootCrateCollected = (Action)Delegate.Remove(FreeLootCrate.OnFreeLootCrateCollected, new Action(this.ButtonAwake));
		IapManager.onPurchaseSucceeded -= this.OnItemPurchase;
	}

	private void Wiggle()
	{
		if (this.tagAdded)
		{
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.newTag);
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = new Vector3(1.1f, 1.1f, -1f);
		this.tagAdded = true;
	}

	private void Start()
	{
	}

	private void OnItemPurchase(IapManager.InAppPurchaseItemType type)
	{
		switch (type)
		{
		case IapManager.InAppPurchaseItemType.WoodenLootCrate:
		case IapManager.InAppPurchaseItemType.MetalLootCrate:
		case IapManager.InAppPurchaseItemType.GoldenLootCrate:
		case IapManager.InAppPurchaseItemType.WoodenLootCrateSale:
		case IapManager.InAppPurchaseItemType.MetalLootCrateSale:
		case IapManager.InAppPurchaseItemType.GoldenLootCrateSale:
			this.ButtonAwake();
			break;
		}
	}

	protected override void OnActivate()
	{
		Singleton<GameManager>.Instance.LoadWorkshop(false);
	}

	[SerializeField]
	private GameObject newTag;

	private bool tagAdded;
}
