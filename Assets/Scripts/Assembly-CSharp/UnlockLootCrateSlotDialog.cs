using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class UnlockLootCrateSlotDialog : TextDialog
{
	public int SnoutCoinPrice { get; private set; }

	private bool BeginOpeningTutorialShown
	{
		get
		{
			return GameProgress.GetBool("BeginOpeninTutorialShown", false, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetBool("BeginOpeninTutorialShown", value, GameProgress.Location.Local);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		GameObject gameObject = GameObject.Find("CakeRaceTutorial");
		if (gameObject != null)
		{
			this.cakeRaceTutorial = gameObject.GetComponent<CakeRaceTutorial>();
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		base.transform.position = WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 10f;
		if (!this.BeginOpeningTutorialShown && this.cakeRaceTutorial != null && this.unlockNowControls != null)
		{
			this.cakeRaceTutorial.OpenCrateTutorial(this.unlockNowControls.transform);
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		if (this.cakeRaceTutorial != null)
		{
			this.cakeRaceTutorial.SetActive(false);
		}
	}

	public void InitPopup(int price, int secondsLeft, GameObject cratePrefab, LootCrateType lootCrate)
	{
		this.currentCrateType = lootCrate;
		this.SnoutCoinPrice = price;
		if (this.priceLabel)
		{
			TextMesh[] componentsInChildren = this.priceLabel.gameObject.GetComponentsInChildren<TextMesh>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].text = string.Format("[snout] {0}", this.SnoutCoinPrice);
				TextMeshSpriteIcons.EnsureSpriteIcon(componentsInChildren[i]);
			}
		}
		string formattedTimeFromSeconds = LootCrateSlot.GetFormattedTimeFromSeconds(secondsLeft);
		if (this.timerLabel)
		{
			TextMesh[] componentsInChildren2 = this.timerLabel.gameObject.GetComponentsInChildren<TextMesh>();
			TextMeshHelper.UpdateTextMeshes(componentsInChildren2, formattedTimeFromSeconds, false);
		}
		if (this.unlockNowControls != null)
		{
			Transform transform = this.unlockNowControls.transform.Find("StartUnlockButton/TimeLabel");
			if (transform != null)
			{
				TextMesh[] componentsInChildren3 = transform.gameObject.GetComponentsInChildren<TextMesh>();
				TextMeshHelper.UpdateTextMeshes(componentsInChildren3, formattedTimeFromSeconds, false);
			}
		}
		if (this.skeletonAnimation)
		{
			this.skeletonAnimation.initialSkinName = lootCrate.ToString();
			this.skeletonAnimation.Initialize(true);
			this.skeletonAnimation.state.AddAnimation(0, "Idle", true, 0f);
		}
		this.InitRewardItems(lootCrate);
	}

	private void InitRewardItems(LootCrateType lootCrate)
	{
		if (!this.gridLayout)
		{
			return;
		}
		List<Tuple<LootCrateRewards.Reward, BasePart.PartTier>> list = LootCrateRewards.MinimumRewards(lootCrate);
		for (int i = 0; i < list.Count; i++)
		{
			LootCrateRewards.Reward item = list[i].Item1;
			GameObject original;
			if (item != LootCrateRewards.Reward.Part)
			{
				original = this.randomItemPrefab;
			}
			else if (list[i].Item2 == BasePart.PartTier.Common)
			{
				original = this.commonItemPrefab;
			}
			else if (list[i].Item2 == BasePart.PartTier.Rare)
			{
				original = this.rareItemPrefab;
			}
			else
			{
				original = this.epicItemPrefab;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original, Vector3.zero, Quaternion.identity);
			LayerHelper.SetLayer(gameObject, base.gameObject.layer, true);
			LayerHelper.SetSortingLayer(gameObject, "Popup", true);
			LayerHelper.SetOrderInLayer(gameObject, 0, true);
			gameObject.transform.parent = this.gridLayout.transform;
		}
		this.gridLayout.UpdateLayout();
	}

	public void SetInfoLabel(UnlockType infoType)
	{
		if (this.timerInfos == null)
		{
			return;
		}
		for (int i = 0; i < this.timerInfos.Length; i++)
		{
			if (this.timerInfos[i] != null)
			{
				this.timerInfos[i].SetActive(i == (int)infoType);
			}
		}
		if (this.openNowControls != null)
		{
			this.openNowControls.SetActive(infoType <= UnlockLootCrateSlotDialog.UnlockType.PurchaseInactiveCrate);
		}
		if (this.unlockNowControls != null)
		{
			this.unlockNowControls.SetActive(infoType == UnlockLootCrateSlotDialog.UnlockType.StartUnlocking);
		}
	}

	public void TryToUnlock()
	{
		if (GameProgress.SnoutCoinCount() >= this.SnoutCoinPrice)
		{
			base.Confirm();
			this.Close();
		}
		else
		{
			base.OpenShop();
		}
	}

	public void DiscardCrate()
	{
		this.Close();
	}

	public void StartUnlockingNow()
	{
		this.BeginOpeningTutorialShown = true;
		base.Confirm();
		this.Close();
	}

	public new void Close()
	{
		if (this.crateHolder && this.crateHolder.childCount > 0)
		{
			for (int i = 0; i < this.crateHolder.childCount; i++)
			{
				UnityEngine.Object.Destroy(this.crateHolder.GetChild(i).gameObject);
			}
		}
		base.Close();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	[SerializeField]
	private string[] skinNames;

	[SerializeField]
	private TextMesh priceLabel;

	[SerializeField]
	private TextMesh timerLabel;

	[SerializeField]
	private Transform crateHolder;

	[SerializeField]
	private GameObject[] timerInfos;

	[SerializeField]
	private GridLayout gridLayout;

	[SerializeField]
	private GameObject epicItemPrefab;

	[SerializeField]
	private GameObject rareItemPrefab;

	[SerializeField]
	private GameObject commonItemPrefab;

	[SerializeField]
	private GameObject randomItemPrefab;

	[SerializeField]
	private SkeletonAnimation skeletonAnimation;

	[SerializeField]
	private GameObject openNowControls;

	[SerializeField]
	private GameObject unlockNowControls;

	private CakeRaceTutorial cakeRaceTutorial;

	private LootCrateType currentCrateType = LootCrateType.None;

	public enum UnlockType
	{
		PurchaseLockedCrate,
		PurchaseInactiveCrate,
		StartUnlocking,
		DiscardPopup
	}
}
