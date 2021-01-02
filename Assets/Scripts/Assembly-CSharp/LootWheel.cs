using System;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class LootWheel : WPFMonoBehaviour
{
	private int TotalRewards
	{
		get
		{
			int num = 0;
			for (int i = 0; i < this.wheelSlots.Length; i++)
			{
				num += this.wheelSlots[i].TotalRewards;
			}
			return num;
		}
	}

	private int RewardsLeft
	{
		get
		{
			int num = 0;
			for (int i = 0; i < this.wheelSlots.Length; i++)
			{
				num += this.wheelSlots[i].RewardsLeft;
			}
			return num;
		}
	}

	public bool Initialized
	{
		get
		{
			return this.initialized;
		}
	}

	public bool Dirty
	{
		get
		{
			return this.currentSpin > 0;
		}
	}

	private void Awake()
	{
		this.initialized = false;
		this.subscribed = false;
		this.spinner = new LootWheelSpinner(this.wheelRigidbody, this.needleTransform, this.wheelSlots);
		this.rewards = new LootWheelRewards();
		this.epicStarAnim = this.epicPartStarsRoot.gameObject.GetComponentInChildren<SkeletonAnimation>(true);
		this.rareStarAnim = this.rarePartStarsRoot.gameObject.GetComponentInChildren<SkeletonAnimation>(true);
		this.commonStarAnim = this.commonPartStarsRoot.gameObject.GetComponentInChildren<SkeletonAnimation>(true);
	}

	private void OnDestroy()
	{
		if (this.epicStarAnim != null && this.epicStarAnim.state != null)
		{
			this.epicStarAnim.state.Complete -= this.OnStarAnimationComplete;
		}
		if (this.rareStarAnim != null && this.rareStarAnim.state != null)
		{
			this.rareStarAnim.state.Complete -= this.OnStarAnimationComplete;
		}
		if (this.commonStarAnim != null && this.commonStarAnim.state != null)
		{
			this.commonStarAnim.state.Complete -= this.OnStarAnimationComplete;
		}
		if (this.rewards != null)
		{
			LootWheelRewards lootWheelRewards = this.rewards;
			lootWheelRewards.OnInitialized = (Action)Delegate.Remove(lootWheelRewards.OnInitialized, new Action(this.Initialize));
		}
	}

	public void ForceReInit()
	{
		this.initialized = false;
		if (this.rewards.Initialized)
		{
			this.Initialize();
		}
		else
		{
			LootWheelRewards lootWheelRewards = this.rewards;
			lootWheelRewards.OnInitialized = (Action)Delegate.Combine(lootWheelRewards.OnInitialized, new Action(this.Initialize));
		}
	}

	private void Initialize()
	{
		for (int i = 0; i < this.wheelSlots.Length; i++)
		{
			LootWheelRewards.LootWheelReward[] array = this.wheelSlots[i].InitReward(this.rewards);
			if (this.wheelSlots[i].SlotType == LootWheel.WheelSlotType.Part)
			{
				if (this.commonPart != null)
				{
					UnityEngine.Object.Destroy(this.commonPart);
				}
				this.commonPart = this.InstantiateRewardImage(this.commonPartRoot, array[0]);
				if (this.rarePart != null)
				{
					UnityEngine.Object.Destroy(this.rarePart);
				}
				this.rarePart = this.InstantiateRewardImage(this.rarePartRoot, array[1]);
				if (this.epicPart != null)
				{
					UnityEngine.Object.Destroy(this.epicPart);
				}
				this.epicPart = this.InstantiateRewardImage(this.epicPartRoot, array[2]);
			}
		}
		if (!this.subscribed)
		{
			if (this.epicStarAnim != null && this.epicStarAnim.state != null)
			{
				this.epicStarAnim.state.Complete += this.OnStarAnimationComplete;
			}
			if (this.rareStarAnim != null && this.rareStarAnim.state != null)
			{
				this.rareStarAnim.state.Complete += this.OnStarAnimationComplete;
			}
			if (this.commonStarAnim != null && this.commonStarAnim.state != null)
			{
				this.commonStarAnim.state.Complete += this.OnStarAnimationComplete;
			}
			this.subscribed = true;
		}
		this.SetStarsEnabled(BasePart.PartTier.Epic, false, null);
		this.SetStarsEnabled(BasePart.PartTier.Rare, false, null);
		this.SetStarsEnabled(BasePart.PartTier.Common, false, null);
		this.SetCheckMark(BasePart.PartTier.Epic, false);
		this.SetCheckMark(BasePart.PartTier.Rare, false);
		this.SetCheckMark(BasePart.PartTier.Common, false);
		this.currentSpin = 0;
		this.currentPrice = this.CalculateSpinPrice(this.currentSpin);
		this.SetPriceToButton(this.currentPrice);
		this.SetSpinText(this.currentSpin);
		this.popup.DoneButtonHidden = true;
		this.popup.SpinButtonEnabled = true;
		this.initialized = true;
	}

	private GameObject InstantiateRewardImage(Transform root, LootWheelRewards.LootWheelReward reward)
	{
		GameObject gameObject = root.parent.Find("Label").gameObject;
		LootWheelRewards.RewardType type = reward.Type;
		GameObject gameObject2;
		if (type != LootWheelRewards.RewardType.Part)
		{
			if (type != LootWheelRewards.RewardType.Scrap)
			{
				return null;
			}
			gameObject.SetActive(true);
			gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.scrapIconPrefab);
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.genericTextPrefab);
			gameObject3.transform.parent = gameObject.transform;
			gameObject3.transform.localPosition = Vector3.zero;
			gameObject3.transform.position += new Vector3(0f, -0.05f, -0.1f);
			gameObject3.transform.localScale = new Vector3(0.08f, 0.08f, 1f);
			TextMesh[] componentsInChildren = gameObject3.GetComponentsInChildren<TextMesh>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].alignment = TextAlignment.Center;
				componentsInChildren[i].anchor = TextAnchor.MiddleCenter;
				componentsInChildren[i].text = reward.Amount.ToString();
			}
			this.SetLayer(gameObject3, base.gameObject.layer);
			this.SetSortingLayer(gameObject3, "Popup");
			this.SetOrderInLayer(gameObject3, 0);
		}
		else
		{
			gameObject2 = UnityEngine.Object.Instantiate<GameObject>(reward.PartReward.m_constructionIconSprite.gameObject);
			gameObject.SetActive(false);
		}
		gameObject2.transform.parent = root;
		gameObject2.transform.localPosition = Vector3.zero;
		this.SetSortingLayer(gameObject2, "Popup");
		this.SetLayer(gameObject2, base.gameObject.layer);
		this.SetOrderInLayer(gameObject2, 0);
		return gameObject2;
	}

	public void Spin()
	{
		if (!this.initialized || this.spinner.IsSpinning)
		{
			return;
		}
        WheelSlot target = this.GetRewardSlot(0);
		if (target != null && GameProgress.UseSnoutCoins(this.currentPrice))
		{
			if (this.currentPrice > 0)
			{
				Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinUse);
			}
			SnoutButton.Instance.UpdateAmount(false);
			this.popup.SpinButtonEnabled = false;
			this.popup.DoneButtonEnabled = false;
			this.spinner.Spin(target, this.initialSpinTime, this.spinVelocity, this.decelerationRate, this.tickSoundRate, delegate
			{
				this.OnSpinEnd(target);
			});
			this.SendFlurryLootWheelSpinEvent(target, this.currentPrice);
		}
		else
		{
			Singleton<IapManager>.Instance.OpenShopPage(delegate
			{
				this.popup.gameObject.SetActive(true);
			}, "SnoutCoinShop");
			this.popup.gameObject.SetActive(false);
		}
	}

	private void OnSpinEnd(WheelSlot reward)
	{
		this.currentSpin++;
		this.GiveReward(reward);
	}

	private WheelSlot GetRewardSlot(int counter = 0)
	{
		if (counter > 10)
		{
			return null;
		}
		float num = 0f;
		for (int i = 0; i < this.wheelSlots.Length; i++)
		{
			num += this.wheelSlots[i].Probability;
		}
		if (num <= 0f)
		{
			return null;
		}
		float num2 = UnityEngine.Random.Range(0f, 1f) * num;
		float num3 = 0f;
		for (int j = 0; j < this.wheelSlots.Length; j++)
		{
			num3 += this.wheelSlots[j].Probability;
			if (num2 <= num3)
			{
				return this.wheelSlots[j];
			}
		}
		return this.GetRewardSlot(++counter);
	}

	private void GiveReward(WheelSlot slot)
	{
		LootWheelRewards.LootWheelReward reward;
		if (!slot.GetReward(out reward))
		{
			return;
		}
		switch (reward.Type)
		{
		case LootWheelRewards.RewardType.Dessert:
			this.RewardDesserts(reward.Amount);
			break;
		case LootWheelRewards.RewardType.Scrap:
			this.RewardScrap(reward.Amount);
			ScrapButton.Instance.UpdateAmount(false);
			break;
		case LootWheelRewards.RewardType.Powerup:
			this.RewardPowerup(reward.PowerupReward);
			break;
		case LootWheelRewards.RewardType.Part:
			this.RewardPart(reward.PartReward);
			break;
		}
		if (slot.SlotType == LootWheel.WheelSlotType.Part)
		{
			this.SetStarsEnabled((BasePart.PartTier)slot.RewardIndex, true, delegate
			{
				this.shakeAnimation.state.AddAnimation(0, this.shakeAnimationName, false, 0f);
				CoroutineRunner.Instance.DelayAction(delegate
				{
					this.ShowRewardRoutine(slot, reward.Amount, reward.Type, delegate
					{
						this.SetCheckMark((BasePart.PartTier)slot.RewardIndex, true);
					});
				}, 0.3f, false);
			});
		}
		else
		{
			this.ShowRewardRoutine(slot, reward.Amount, reward.Type, delegate
			{
				slot.SetCollectIndicator(true);
			});
		}
	}

	private void RewardDesserts(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			int index = UnityEngine.Random.Range(0, WPFMonoBehaviour.gameData.m_desserts.Count - 1);
			GameProgress.AddDesserts(WPFMonoBehaviour.gameData.m_desserts[index].name, 1);
		}
	}

	private void RewardPart(BasePart part)
	{
		CustomizationManager.UnlockPart(part, "_LootWheel");
	}

	private void RewardScrap(int amount)
	{
		GameProgress.AddScrap(amount);
	}

	private void RewardPowerup(LootCrateRewards.Powerup powerup)
	{
		switch (powerup)
		{
		case LootCrateRewards.Powerup.Magnet:
			GameProgress.AddSuperMagnet(1);
			break;
		case LootCrateRewards.Powerup.Superglue:
			GameProgress.AddSuperGlue(1);
			break;
		case LootCrateRewards.Powerup.Turbo:
			GameProgress.AddTurboCharge(1);
			break;
		case LootCrateRewards.Powerup.Supermechanic:
			GameProgress.AddBluePrints(1);
			break;
		case LootCrateRewards.Powerup.NightVision:
			GameProgress.AddNightVision(1);
			break;
		}
	}

	private void ShowRewardRoutine(WheelSlot slot, int rewardAmount, LootWheelRewards.RewardType reward, Action OnEnd)
	{
		bool showHorns;
		GameObject copy;
		LootWheelRewardingRoutine.BackgroundType bgType;
		if (slot.SlotType == LootWheel.WheelSlotType.Part)
		{
			if (slot.RewardIndex == 1)
			{
				copy = this.commonPart.transform.parent.gameObject;
				bgType = LootWheelRewardingRoutine.BackgroundType.Common;
			}
			else if (slot.RewardIndex == 2)
			{
				copy = this.rarePart.transform.parent.gameObject;
				bgType = LootWheelRewardingRoutine.BackgroundType.Rare;
			}
			else
			{
				copy = this.epicPart.transform.parent.gameObject;
				bgType = LootWheelRewardingRoutine.BackgroundType.Epic;
			}
			showHorns = true;
			bgType = ((reward != LootWheelRewards.RewardType.Part) ? LootWheelRewardingRoutine.BackgroundType.Regular : bgType);
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.lootWheelJackPot);
		}
		else
		{
			copy = slot.CollectableIcon;
			bgType = LootWheelRewardingRoutine.BackgroundType.Regular;
			showHorns = false;
		}
		CoroutineRunner.Instance.DelayAction(delegate
		{
			this.rewardRoutine.ShowRewarding(showHorns, rewardAmount, UnityEngine.Object.Instantiate<GameObject>(copy), bgType, OnEnd);
			this.popup.DoneButtonEnabled = true;
			if ((!Singleton<BuildCustomizationLoader>.Instance.IsOdyssey && this.currentSpin < this.TotalRewards) || (Singleton<BuildCustomizationLoader>.Instance.IsOdyssey && this.currentSpin < this.odysseySpinCount))
			{
				this.popup.SpinButtonEnabled = true;
				this.currentPrice = this.CalculateSpinPrice(this.currentSpin);
				this.SetPriceToButton(this.currentPrice);
				this.SetSpinText(this.currentSpin);
			}
		}, 0.5f, false);
	}

	private void SetSpinText(int currentSpins)
	{
		bool flag = currentSpins <= 0;
		this.spinText.SetActive(flag);
		this.spinAgainText.SetActive(!flag);
	}

	private int CalculateSpinPrice(int currentSpin)
	{
		if (Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			return 0;
		}
		if (currentSpin <= 0)
		{
			return 0;
		}
		float num = this.rewards.RewardValueAvg * 2f * this.rewards.SpinPriceVariation / (float)this.TotalRewards;
		float num2 = this.rewards.RewardValueAvg * (1f - this.rewards.SpinPriceVariation);
		float num3 = (num2 + (float)currentSpin * num) * this.rewards.SpinPriceMultiplier;
		return Mathf.RoundToInt(num3 / 10f) * 10;
	}

	private void SetPriceToButton(int price)
	{
		if (price <= 0)
		{
			this.popup.ResetSpinButtonTextMaterials();
			this.popup.SpinButtonText = "TEXT_FREE";
			this.popup.RefreshSpinButtonTranslation();
		}
		else
		{
			this.popup.SpinButtonText = string.Format("[snout] {0}", price);
		}
	}

	private void SetStarsEnabled(BasePart.PartTier tier, bool enabled, Action OnAnimationEnd)
	{
		if (tier != BasePart.PartTier.Epic)
		{
			if (tier != BasePart.PartTier.Rare)
			{
				if (tier == BasePart.PartTier.Common)
				{
					this.SetStarEnabled(this.commonPartStarsRoot, enabled, OnAnimationEnd);
				}
			}
			else
			{
				this.SetStarEnabled(this.rarePartStarsRoot, enabled, OnAnimationEnd);
			}
		}
		else
		{
			this.SetStarEnabled(this.epicPartStarsRoot, enabled, OnAnimationEnd);
		}
	}

	private void SetCheckMark(BasePart.PartTier tier, bool enabled)
	{
		if (tier != BasePart.PartTier.Epic)
		{
			if (tier != BasePart.PartTier.Rare)
			{
				if (tier == BasePart.PartTier.Common)
				{
					this.SetCheckMark(this.commonPartStarsRoot.parent, enabled);
				}
			}
			else
			{
				this.SetCheckMark(this.rarePartStarsRoot.parent, enabled);
			}
		}
		else
		{
			this.SetCheckMark(this.epicPartStarsRoot.parent, enabled);
		}
	}

	private void SetStarEnabled(Transform starRoot, bool enabled, Action OnAnimationEnd)
	{
		starRoot.Find("Star").gameObject.SetActive(enabled);
		if (enabled)
		{
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.lootWheelStarExplosion);
			this.OnStarAnimationEnd = (Action)Delegate.Combine(this.OnStarAnimationEnd, OnAnimationEnd);
			SkeletonAnimation componentInChildren = starRoot.gameObject.GetComponentInChildren<SkeletonAnimation>();
			componentInChildren.state.AddAnimation(0, this.starAnimationName, false, 0f);
		}
	}

	private void OnStarAnimationComplete(Spine.AnimationState state, int trackIndex, int loopCount)
	{
		if (this.OnStarAnimationEnd != null)
		{
			this.OnStarAnimationEnd();
			this.OnStarAnimationEnd = null;
		}
	}

	private void SetCheckMark(Transform root, bool enabled)
	{
		root.Find("Checked").gameObject.SetActive(enabled);
	}

	private void SetSortingLayer(GameObject go, string layer)
	{
		Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].sortingLayerName = layer;
		}
	}

	private void SetOrderInLayer(GameObject go, int order)
	{
		Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].sortingOrder = order;
		}
	}

	private void SetLayer(GameObject go, int layer)
	{
		go.layer = layer;
		for (int i = 0; i < go.transform.childCount; i++)
		{
			this.SetLayer(go.transform.GetChild(i).gameObject, layer);
		}
	}

	private void SendFlurryLootWheelSpinEvent(WheelSlot slot, int snoutCost)
	{
	}

	[SerializeField]
	private Transform needleTransform;

	[SerializeField]
	private Rigidbody wheelRigidbody;

	[SerializeField]
	private WheelSlot[] wheelSlots;

	[SerializeField]
	private LootWheelRewardingRoutine rewardRoutine;

	[SerializeField]
	private SkeletonAnimation shakeAnimation;

	[SerializeField]
	private string starAnimationName;

	[SerializeField]
	private string shakeAnimationName;

	[SerializeField]
	private Transform epicPartRoot;

	[SerializeField]
	private Transform rarePartRoot;

	[SerializeField]
	private Transform commonPartRoot;

	[SerializeField]
	private Transform epicPartStarsRoot;

	[SerializeField]
	private Transform rarePartStarsRoot;

	[SerializeField]
	private Transform commonPartStarsRoot;

	[SerializeField]
	private LootWheelPopup popup;

	[SerializeField]
	private GameObject spinText;

	[SerializeField]
	private GameObject spinAgainText;

	[SerializeField]
	private GameObject scrapIconPrefab;

	[SerializeField]
	private GameObject genericTextPrefab;

	[SerializeField]
	private float initialSpinTime = 0.75f;

	[SerializeField]
	private float decelerationRate = 0.15f;

	[SerializeField]
	private float spinVelocity = 30f;

	[SerializeField]
	private float tickSoundRate = 5f;

	[SerializeField]
	private int odysseySpinCount;

	private LootWheelSpinner spinner;

	private LootWheelRewards rewards;

	private bool initialized;

	private bool subscribed;

	private GameObject epicPart;

	private GameObject rarePart;

	private GameObject commonPart;

	private int currentSpin;

	private int currentPrice;

	private Action OnStarAnimationEnd;

	private SkeletonAnimation epicStarAnim;

	private SkeletonAnimation rareStarAnim;

	private SkeletonAnimation commonStarAnim;

	public enum WheelSlotType
	{
		Part,
		Scrap1,
		Scrap2,
		Dessert1,
		Dessert2,
		Dessert3,
		Powerup
	}

	[Serializable]
	public class WheelSlot
	{
		public float RotationBegin
		{
			get
			{
				return this.m_rotationBegin;
			}
		}

		public float RotationEnd
		{
			get
			{
				return this.m_rotationEnd;
			}
		}

		public WheelSlotType SlotType
		{
			get
			{
				return this.m_slotType;
			}
		}

		public int RewardIndex
		{
			get
			{
				return this.m_rewardIndex;
			}
		}

		public bool RewardsCollected
		{
			get
			{
				return this.m_rewardIndex >= this.m_rewards.Length;
			}
		}

		public int RewardsLeft
		{
			get
			{
				return this.m_rewards.Length - this.m_rewardIndex;
			}
		}

		public int TotalRewards
		{
			get
			{
				return this.m_rewards.Length;
			}
		}

		public GameObject CollectableIcon
		{
			get
			{
				return this.m_collectableIcon;
			}
		}

		public float Probability
		{
			get
			{
				if (this.m_rewardIndex >= this.m_rewards.Length)
				{
					return 0f;
				}
				float num = 0f;
				for (int i = 0; i < this.m_probabilities.Length; i++)
				{
					num += this.m_probabilities[i];
				}
				return num;
			}
		}

		public LootWheelRewards.LootWheelReward[] InitReward(LootWheelRewards rewards)
		{
			this.m_rewardIndex = 0;
			switch (this.m_slotType)
			{
			case LootWheel.WheelSlotType.Part:
				this.m_rewards = new LootWheelRewards.LootWheelReward[]
				{
					rewards.GetReward(LootWheelRewards.WheelReward.CommonPart),
					rewards.GetReward(LootWheelRewards.WheelReward.RarePart),
					rewards.GetReward(LootWheelRewards.WheelReward.EpicPart)
				};
				break;
			case LootWheel.WheelSlotType.Scrap1:
				this.m_rewards = new LootWheelRewards.LootWheelReward[]
				{
					rewards.GetReward(LootWheelRewards.WheelReward.Scrap1)
				};
				break;
			case LootWheel.WheelSlotType.Scrap2:
				this.m_rewards = new LootWheelRewards.LootWheelReward[]
				{
					rewards.GetReward(LootWheelRewards.WheelReward.Scrap2)
				};
				break;
			case LootWheel.WheelSlotType.Dessert1:
				this.m_rewards = new LootWheelRewards.LootWheelReward[]
				{
					rewards.GetReward(LootWheelRewards.WheelReward.Dessert1)
				};
				break;
			case LootWheel.WheelSlotType.Dessert2:
				this.m_rewards = new LootWheelRewards.LootWheelReward[]
				{
					rewards.GetReward(LootWheelRewards.WheelReward.Dessert2)
				};
				break;
			case LootWheel.WheelSlotType.Dessert3:
				this.m_rewards = new LootWheelRewards.LootWheelReward[]
				{
					rewards.GetReward(LootWheelRewards.WheelReward.Dessert3)
				};
				break;
			case LootWheel.WheelSlotType.Powerup:
				this.m_rewards = new LootWheelRewards.LootWheelReward[]
				{
					rewards.GetReward(LootWheelRewards.WheelReward.Powerup)
				};
				break;
			}
			this.m_probabilities = new float[this.m_rewards.Length];
			for (int i = 0; i < this.m_probabilities.Length; i++)
			{
				float num = (float)rewards.TotalRewardValues / (float)this.m_rewards[i].TotalValue;
				this.m_probabilities[i] = num / rewards.TotalRewardInverseValues;
			}
			if (this.m_countIndicator != null && this.m_rewards.Length > 0)
			{
				TextMesh[] componentsInChildren = this.m_countIndicator.gameObject.GetComponentsInChildren<TextMesh>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					componentsInChildren[j].text = this.m_rewards[0].Amount.ToString();
				}
			}
			if (this.m_slotType == LootWheel.WheelSlotType.Part)
			{
				this.CheckDuplicateParts();
			}
			if (this.m_slotType == LootWheel.WheelSlotType.Powerup && this.m_rewards.Length > 0)
			{
				this.CreatePowerupIcon(this.m_rewards[0].PowerupReward);
			}
			this.m_collectedIndicator.SetActive(false);
			return this.m_rewards;
		}

		public void SetCollectIndicator(bool set)
		{
			this.m_collectedIndicator.SetActive(set);
		}

		public bool PeekReward(out LootWheelRewards.LootWheelReward reward)
		{
			if (this.m_rewardIndex < this.m_rewards.Length && this.m_rewardIndex >= 0)
			{
				reward = this.m_rewards[this.m_rewardIndex];
				return true;
			}
			reward = LootWheelRewards.LootWheelReward.Empty;
			return false;
		}

		public bool GetReward(out LootWheelRewards.LootWheelReward reward)
		{
			if (this.m_rewardIndex < this.m_rewards.Length && this.m_rewardIndex >= 0)
			{
				reward = this.m_rewards[this.m_rewardIndex++];
				return true;
			}
			reward = LootWheelRewards.LootWheelReward.Empty;
			return false;
		}

		private void CheckDuplicateParts()
		{
			ConfigData config = Singleton<GameConfigurationManager>.Instance.GetConfig("part_salvage_rewards");
			for (int i = 0; i < this.m_rewards.Length; i++)
			{
				if (CustomizationManager.IsPartUnlocked(this.m_rewards[i].PartReward))
				{
					int amount = int.Parse(config[this.m_rewards[i].PartReward.m_partTier.ToString()]);
					this.m_rewards[i] = new LootWheelRewards.LootWheelReward(amount, this.m_rewards[i].SingleValue, LootWheelRewards.RewardType.Scrap);
				}
			}
		}

		private void CreatePowerupIcon(LootCrateRewards.Powerup powerup)
		{
			if (this.m_collectableIcon == null)
			{
				return;
			}
            Sprite component = this.m_collectableIcon.GetComponent<Sprite>();
			if (component == null)
			{
				return;
			}
			string text = string.Empty;
			switch (this.m_rewards[0].PowerupReward)
			{
			case LootCrateRewards.Powerup.Magnet:
				text = WPFMonoBehaviour.gameData.m_superMagnetIcon.GetComponent<Sprite>().Id;
				break;
			case LootCrateRewards.Powerup.Superglue:
				text = WPFMonoBehaviour.gameData.m_superGlueIcon.GetComponent<Sprite>().Id;
				break;
			case LootCrateRewards.Powerup.Turbo:
				text = WPFMonoBehaviour.gameData.m_turboChargeIcon.GetComponent<Sprite>().Id;
				break;
			case LootCrateRewards.Powerup.Supermechanic:
				text = WPFMonoBehaviour.gameData.m_superMechanicIcon.GetComponent<Sprite>().Id;
				break;
			case LootCrateRewards.Powerup.NightVision:
				text = WPFMonoBehaviour.gameData.m_nightVisionIcon.GetComponent<Sprite>().Id;
				break;
			}
			if (!string.IsNullOrEmpty(text))
			{
				RuntimeSpriteDatabase instance = Singleton<RuntimeSpriteDatabase>.Instance;
				component.SelectSprite(instance.Find(text), true);
			}
		}

		[SerializeField]
		private float m_rotationBegin;

		[HideInInspector]
		[SerializeField]
		private float m_rotationEnd;

		[SerializeField]
		private WheelSlotType m_slotType;

		[SerializeField]
		private TextMesh m_countIndicator;

		[SerializeField]
		private GameObject m_collectedIndicator;

		[SerializeField]
		private GameObject m_collectableIcon;

		private LootWheelRewards.LootWheelReward[] m_rewards;

		private float[] m_probabilities;

		private int m_rewardIndex;
	}
}
