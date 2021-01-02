using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class LootCrateOpenDialog : WPFMonoBehaviour
{
	public static bool DialogOpen
	{
		get
		{
			return LootCrateOpenDialog.s_dialogOpen;
		}
	}

	public event Dialog.OnClose onClose;

	public static LootCrateOpenDialog CreateLootCrateOpenDialog()
	{
		if (LootCrateOpenDialog.instance == null && WPFMonoBehaviour.gameData.m_lootcrateOpenDialog != null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_lootcrateOpenDialog, Vector3.zero, Quaternion.identity);
			LootCrateOpenDialog.instance = gameObject.GetComponent<LootCrateOpenDialog>();
		}
		return LootCrateOpenDialog.instance;
	}

	private void Awake()
	{
		this.lootCrateAnimationInstance = UnityEngine.Object.Instantiate<GameObject>(this.lootCrateAnimation, Vector3.up * 1000f, Quaternion.identity);
		this.lootCrateAnimationInstance.SetActive(false);
	}

	public void PrepareOpening()
	{
		if (WPFMonoBehaviour.levelManager)
		{
			this.levelLootcrateOpened = true;
			WPFMonoBehaviour.levelManager.SetGameState(LevelManager.GameState.LootCrateOpening);
		}
	}

	public void AddLootCrate(LootCrateType lootCrateType, int amount, LootCrate.AnalyticData data, bool fromQueue = false, int xp = 0)
	{
		if (this.lootcrateRewardQueue == null)
		{
			this.lootcrateRewardQueue = new Queue<LootCrateRewardQueueElement>();
		}
		if (this.lootCrateAnimation != null)
		{
			if (this.lootCrateAnimationInstance == null)
			{
				this.lootCrateAnimationInstance = UnityEngine.Object.Instantiate<GameObject>(this.lootCrateAnimation, Vector3.up * 1000f, Quaternion.identity);
			}
			else
			{
				this.lootCrateAnimationInstance.SetActive(true);
			}
			this.lootCrateAnimationInstance.transform.parent = base.transform;
            LootCrateRewardQueueElement lootCrateRewardQueueElement = null;
			if (!fromQueue)
			{
				bool flag = this.lootcrateRewardQueue.Count == 0;
				for (int i = 0; i < amount; i++)
				{
					lootCrateRewardQueueElement = new LootCrateRewardQueueElement(lootCrateType, data, xp);
					this.lootcrateRewardQueue.Enqueue(lootCrateRewardQueueElement);
				}
				if (!flag)
				{
					return;
				}
			}
			else
			{
				lootCrateRewardQueueElement = this.lootcrateRewardQueue.Peek();
			}
			this.closeButton.SetActive(false);
			this.closeButtonGfx.SetActive(false);
			this.crateOpened = false;
			LootCrateRewards.SlotRewards[] randomRewards = LootCrateRewards.GetRandomRewards(lootCrateType);
			if (randomRewards == null)
			{
				return;
			}
			int num = 0;
			LootCrateButton componentInChildren = this.lootCrateAnimationInstance.GetComponentInChildren<LootCrateButton>();
			componentInChildren.GainedXP = lootCrateRewardQueueElement.xp;
			componentInChildren.Init(lootCrateType);
			LootCrateButton lootCrateButton = componentInChildren;
			lootCrateButton.onOpeningDone = (Action)Delegate.Combine(lootCrateButton.onOpeningDone, new Action(delegate()
			{
				base.StartCoroutine(this.CrateOpened());
			}));
			base.StartCoroutine(this.DelayIntro(componentInChildren, Vector3.forward * -1f));
			List<BasePart> list = new List<BasePart>();
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			List<int> list2 = new List<int>();
			for (int j = 0; j < randomRewards.Length; j++)
			{
				int num8 = UnityEngine.Random.Range(0, randomRewards.Length);
				int num9 = randomRewards.Length;
				while (list2.Contains(num8) && num9 >= 0)
				{
					if (++num8 >= randomRewards.Length)
					{
						num8 = 0;
					}
					num9--;
				}
				if (num9 >= 0)
				{
					list2.Add(num8);
					LootCrateRewards.SlotRewards reward = randomRewards[num8];
					LootCrateRewards.Reward type = reward.Type;
					switch (type)
					{
					case LootCrateRewards.Reward.Part:
					{
						bool isDuplicatePart = false;
						int num10 = 0;
						int num11 = 10;
						BasePart randomLootCrateRewardPartFromTier;
						do
						{
							randomLootCrateRewardPartFromTier = CustomizationManager.GetRandomLootCrateRewardPartFromTier(reward.PartTier, false);
							num11--;
						}
						while (list.Contains(randomLootCrateRewardPartFromTier) && num11 > 0);
						list.Add(randomLootCrateRewardPartFromTier);
						if (CustomizationManager.IsPartUnlocked(randomLootCrateRewardPartFromTier))
						{
							num10 = Singleton<GameConfigurationManager>.Instance.GetValue<int>("part_salvage_rewards", randomLootCrateRewardPartFromTier.m_partTier.ToString());
							GameProgress.AddScrap(num10);
							num2 += num10;
							num7++;
							isDuplicatePart = true;
						}
						else
						{
							CustomizationManager.UnlockPart(randomLootCrateRewardPartFromTier, lootCrateType.ToString() + "_crate");
						}
						componentInChildren.SetIcon(num, randomLootCrateRewardPartFromTier.m_constructionIconSprite.gameObject, string.Empty, (int)reward.PartTier, isDuplicatePart, true);
						componentInChildren.SetScrapIcon(num, this.scrapIcons[0], num10.ToString());
						BasePart.PartTier partTier = reward.PartTier;
						if (partTier != BasePart.PartTier.Common)
						{
							if (partTier != BasePart.PartTier.Rare)
							{
								if (partTier == BasePart.PartTier.Epic)
								{
									num6++;
								}
							}
							else
							{
								num5++;
							}
						}
						else
						{
							num4++;
						}
						break;
					}
					case LootCrateRewards.Reward.Powerup:
					{
						GameObject iconPrefab = this.powerUpIcons[reward.Powerup - LootCrateRewards.Powerup.Magnet];
						string customTypeOfGain = lootCrateType.ToString() + " crate";
						switch (reward.Powerup)
						{
						case LootCrateRewards.Powerup.Magnet:
							GameProgress.AddSuperMagnet(1);
							if (Singleton<IapManager>.Instance != null)
							{
								Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.SuperMagnetSingle, 1, customTypeOfGain);
							}
							break;
						case LootCrateRewards.Powerup.Superglue:
							GameProgress.AddSuperGlue(1);
							if (Singleton<IapManager>.Instance != null)
							{
								Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.SuperGlueSingle, 1, customTypeOfGain);
							}
							break;
						case LootCrateRewards.Powerup.Turbo:
							GameProgress.AddTurboCharge(1);
							if (Singleton<IapManager>.Instance != null)
							{
								Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.TurboChargeSingle, 1, customTypeOfGain);
							}
							break;
						case LootCrateRewards.Powerup.Supermechanic:
							GameProgress.AddBluePrints(1);
							if (Singleton<IapManager>.Instance != null)
							{
								Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.BlueprintSingle, 1, customTypeOfGain);
							}
							break;
						case LootCrateRewards.Powerup.NightVision:
							GameProgress.AddNightVision(1);
							if (Singleton<IapManager>.Instance != null)
							{
								Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.NightVisionSingle, 1, customTypeOfGain);
							}
							break;
						}
						componentInChildren.SetIcon(num, iconPrefab, string.Empty, 0, false, true);
						break;
					}
					case LootCrateRewards.Reward.Dessert:
						if (reward.GoldenCupcake)
						{
							GameObject gameObject = WPFMonoBehaviour.gameData.m_desserts[WPFMonoBehaviour.gameData.m_desserts.Count - 1];
							Dessert component = gameObject.GetComponent<Dessert>();
							GameProgress.AddDesserts(component.saveId, 1);
							componentInChildren.SetIcon(num, this.dessertIcons[1], string.Empty, 0, false, true);
						}
						else
						{
							GameObject gameObject2 = WPFMonoBehaviour.gameData.m_desserts[UnityEngine.Random.Range(0, WPFMonoBehaviour.gameData.m_desserts.Count - 1)];
							Dessert component2 = gameObject2.GetComponent<Dessert>();
							GameProgress.AddDesserts(component2.saveId, reward.Desserts);
							componentInChildren.SetIcon(num, this.dessertIcons[0], reward.Desserts.ToString(), 0, false, true);
						}
						num3 += reward.Desserts;
						break;
					case LootCrateRewards.Reward.Scrap:
					{
						GameProgress.AddScrap(reward.Scrap);
						num2 += reward.Scrap;
						GameObject scrapRewardContainer = componentInChildren.SetIcon(num, this.scrapIcons[0], reward.Scrap.ToString(), 0, false, true);
						LootRewardElement component3 = scrapRewardContainer.GetComponent<LootRewardElement>();
						if (component3 != null)
						{
							LootRewardElement lootRewardElement = component3;
							lootRewardElement.onRewardOpened = (Action)Delegate.Combine(lootRewardElement.onRewardOpened, new Action(delegate()
							{
								ScrapButton.Instance.AddParticles(scrapRewardContainer, reward.Scrap, 0f, (float)reward.Scrap);
							}));
						}
						break;
					}
					case LootCrateRewards.Reward.Coin:
					{
						GameProgress.AddSnoutCoins(reward.Coins);
						GameObject coinRewardContainer = componentInChildren.SetIcon(num, this.coinIcons[0], reward.Coins.ToString(), 0, false, true);
						LootRewardElement component4 = coinRewardContainer.GetComponent<LootRewardElement>();
						if (component4 != null)
						{
							LootRewardElement lootRewardElement2 = component4;
							lootRewardElement2.onRewardOpened = (Action)Delegate.Combine(lootRewardElement2.onRewardOpened, new Action(delegate()
							{
								SnoutButton.Instance.AddParticles(coinRewardContainer, reward.Scrap, 0f, (float)reward.Scrap);
							}));
						}
						break;
					}
					}
					num++;
				}
			}
			if (lootCrateRewardQueueElement != null && num > 0)
			{
				lootCrateRewardQueueElement.SetRewarded();
				int @int = GameProgress.GetInt(lootCrateType.ToString() + "_crates_collected", 0, GameProgress.Location.Local, null);
				GameProgress.SetInt(lootCrateType.ToString() + "_crates_collected", @int + 1, GameProgress.Location.Local);
			}
			EventManager.Send(new LootCrateDelivered(lootCrateType));
			int value = GameProgress.GetInt("Total_parts_scrapped", 0, GameProgress.Location.Local, null) + num7;
			GameProgress.SetInt("Total_parts_scrapped", value, GameProgress.Location.Local);
			int value2 = GameProgress.GetInt("Total_parts_received", 0, GameProgress.Location.Local, null) + num4 + num5 + num6;
			GameProgress.SetInt("Total_parts_received", value2, GameProgress.Location.Local);
		}
	}

	private void ReportCustomPartsGainedEvent(string itemName, string typeOfGain, int amount)
	{
		GameManager.GameState gameState = Singleton<GameManager>.Instance.GetGameState();
		string value = "None";
		if (gameState == GameManager.GameState.Level)
		{
			value = Singleton<GameManager>.Instance.CurrentLevelIdentifier;
		}
	}

	private IEnumerator DelayIntro(LootCrateButton button, Vector3 position)
	{
		yield return null;
		button.PlayIntro();
		yield return null;
		button.transform.localPosition = position;
		yield break;
	}

	private IEnumerator CrateOpened()
	{
		this.closeButton.SetActive(true);
		this.closeBtnAnimation.state.AddAnimation(0, "Intro1", false, 0f);
		this.crateOpened = true;
		yield return null;
		this.closeButtonGfx.SetActive(true);
		yield break;
	}

	public void Close()
	{
		if (this.lootCrateAnimationInstance != null)
		{
			UnityEngine.Object.Destroy(this.lootCrateAnimationInstance);
			this.lootCrateAnimationInstance = null;
		}
		while (this.lootcrateRewardQueue.Count > 0)
		{
            LootCrateRewardQueueElement lootCrateRewardQueueElement = this.lootcrateRewardQueue.Peek();
			if (!lootCrateRewardQueueElement.isRewarded)
			{
				this.AddLootCrate(lootCrateRewardQueueElement.lootCrateType, 1, lootCrateRewardQueueElement.data, true, 0);
				return;
			}
			this.lootcrateRewardQueue.Dequeue();
		}
		if (this.levelLootcrateOpened && WPFMonoBehaviour.levelManager != null)
		{
			WPFMonoBehaviour.levelManager.SetGameState(LevelManager.GameState.Continue);
		}
		this.levelLootcrateOpened = false;
		base.gameObject.SetActive(false);
		if (this.onClose != null)
		{
			this.onClose();
		}
	}

	private void OnEnable()
	{
		this.closeButton.SetActive(false);
		this.closeButtonGfx.SetActive(false);
		if (Singleton<GuiManager>.IsInstantiated())
		{
			Singleton<GuiManager>.Instance.GrabPointer(this);
		}
		if (Singleton<KeyListener>.IsInstantiated())
		{
			Singleton<KeyListener>.Instance.GrabFocus(this);
		}
		KeyListener.keyReleased += this.HandleKeyReleased;
		EventManager.Send(new UIEvent(UIEvent.Type.OpenedLootCrateDialog));
		if (!Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			ResourceBar.Instance.LockItem(ResourceBar.Item.SnoutCoin, true, false, true);
		}
		ResourceBar.Instance.LockItem(ResourceBar.Item.Scrap, true, false, true);
		LootCrateOpenDialog.s_dialogOpen = true;
	}

	private void OnDisable()
	{
		if (Singleton<GuiManager>.IsInstantiated())
		{
			Singleton<GuiManager>.Instance.ReleasePointer(this);
		}
		if (Singleton<KeyListener>.IsInstantiated())
		{
			Singleton<KeyListener>.Instance.ReleaseFocus(this);
		}
		KeyListener.keyReleased -= this.HandleKeyReleased;
		EventManager.Send(new UIEvent(UIEvent.Type.ClosedLootCrateDialog));
		if (!Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			ResourceBar.Instance.ReleaseItem(ResourceBar.Item.SnoutCoin);
		}
		ResourceBar.Instance.ReleaseItem(ResourceBar.Item.Scrap);
		LootCrateOpenDialog.s_dialogOpen = false;
	}

	private void HandleKeyReleased(KeyCode obj)
	{
		if (!this.crateOpened)
		{
			return;
		}
		if (obj == KeyCode.Escape)
		{
			this.Close();
		}
	}

	private static bool s_dialogOpen;

	private static LootCrateOpenDialog instance;

	private Queue<LootCrateRewardQueueElement> lootcrateRewardQueue;

	[SerializeField]
	private GameObject lootCrateAnimation;

	[SerializeField]
	private SkeletonAnimation closeBtnAnimation;

	[SerializeField]
	private GameObject closeButton;

	[SerializeField]
	private GameObject closeButtonGfx;

	[SerializeField]
	private GameObject[] powerUpIcons;

	[SerializeField]
	private GameObject[] scrapIcons;

	[SerializeField]
	private GameObject[] dessertIcons;

	[SerializeField]
	private GameObject[] coinIcons;

	private GameObject lootCrateAnimationInstance;

	private bool crateOpened;

	private bool levelLootcrateOpened;

	private class LootCrateRewardQueueElement
	{
		public LootCrateRewardQueueElement(LootCrateType _lootCrateType, LootCrate.AnalyticData _data, int _xp)
		{
			this.lootCrateType = _lootCrateType;
			this.data = _data;
			this.isRewarded = false;
			this.xp = _xp;
		}

		public void SetRewarded()
		{
			this.isRewarded = true;
			GameProgress.RemoveLootcrate(this.lootCrateType);
		}

		public LootCrateType lootCrateType;

		public LootCrate.AnalyticData data;

		public bool isRewarded;

		public int xp;
	}

	public class LootCrateDelivered : EventManager.Event
	{
		public LootCrateDelivered(LootCrateType type)
		{
			this.type = type;
		}

		public LootCrateType Type
		{
			get
			{
				return this.type;
			}
		}

		private LootCrateType type;
	}
}
