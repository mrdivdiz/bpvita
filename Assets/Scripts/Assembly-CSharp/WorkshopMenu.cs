using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class WorkshopMenu : MonoBehaviour
{
	public static bool FirstLootCrateCollected
	{
		get
		{
			return GameProgress.GetBool("CollectedFirstLootCrate", false, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetBool("CollectedFirstLootCrate", value, GameProgress.Location.Local);
		}
	}

	public static bool AnyLootCrateCollected
	{
		get
		{
			return GameProgress.GetBool("AnyLootCrateCollected", false, GameProgress.Location.Local, null);
		}
		set
		{
			GameProgress.SetBool("AnyLootCrateCollected", value, GameProgress.Location.Local);
		}
	}

	private bool IsMachineLocked
	{
		get
		{
			return this.machineIsLocked || this.introPlaying;
		}
	}

	private SpriteText MachineLabel
	{
		get
		{
			return (!this.IsAlienMachine) ? this.normalMachineLabel : this.alienMachineLabel;
		}
	}

	private bool IsAlienMachine
	{
		get
		{
			return this.alienConverter.IsAlienMachine;
		}
	}

	private void Awake()
	{
		this.gameData = WPFMonoBehaviour.gameData;
		AlienCraftingMachineConverter alienCraftingMachineConverter = this.alienConverter;
		alienCraftingMachineConverter.OnBeginUpgrade = (Action)Delegate.Combine(alienCraftingMachineConverter.OnBeginUpgrade, new Action(this.OnUpgradeMachineBegin));
		AlienCraftingMachineConverter alienCraftingMachineConverter2 = this.alienConverter;
		alienCraftingMachineConverter2.OnMachineBehindCurtain = (Action)Delegate.Combine(alienCraftingMachineConverter2.OnMachineBehindCurtain, new Action(this.OnMachineBehindCurtain));
		AlienCraftingMachineConverter alienCraftingMachineConverter3 = this.alienConverter;
		alienCraftingMachineConverter3.OnEndUpgrade = (Action)Delegate.Combine(alienCraftingMachineConverter3.OnEndUpgrade, new Action(this.OnUpgradeMachineEnd));
		Transform transform = base.transform.Find("LowerRightButtons/PartList");
		if (transform != null)
		{
			this.partListingButton = transform.GetComponent<CustomizePartWidget>();
		}
		this.commonPrice = Singleton<GameConfigurationManager>.Instance.GetValue<int>(WorkshopMenu.CRAFT_PRICE_CONFIG_KEY, BasePart.PartTier.Common.ToString());
		this.rarePrice = Singleton<GameConfigurationManager>.Instance.GetValue<int>(WorkshopMenu.CRAFT_PRICE_CONFIG_KEY, BasePart.PartTier.Rare.ToString());
		this.epicPrice = Singleton<GameConfigurationManager>.Instance.GetValue<int>(WorkshopMenu.CRAFT_PRICE_CONFIG_KEY, BasePart.PartTier.Epic.ToString());
		IapManager.onPurchaseSucceeded += this.OnItemPurchase;
		KeyListener.keyReleased += this.HandleKeyReleased;
		WorkshopMenu.isDestroyed = false;
	}

	private void OnUpgradeMachineBegin()
	{
		this.machineIsLocked = true;
	}

	private void OnMachineBehindCurtain()
	{
		this.UpdateLiquidTank((float)this.currentMachineScrapAmount, (float)AlienCustomizationManager.GetPrice(), false);
		this.UpdateAlienPartSilhouette();
	}

	private void OnUpgradeMachineEnd()
	{
		this.machineIsLocked = false;
		this.machineAnimation.state.End += this.OnMachineAnimationEnd;
		this.machineAnimation.state.Start += this.OnMachineAnimationStart;
		this.machineAnimation.state.Event += this.OnAnimationEvent;
	}

	private void HandleKeyReleased(KeyCode obj)
	{
		if (obj == KeyCode.Escape && !this.machineIsLocked)
		{
			Singleton<GameManager>.Instance.LoadEpisodeSelection(true);
		}
	}

	private void OnItemPurchase(IapManager.InAppPurchaseItemType type)
	{
		if (type == IapManager.InAppPurchaseItemType.WoodenLootCrate || type == IapManager.InAppPurchaseItemType.MetalLootCrate || type == IapManager.InAppPurchaseItemType.GoldenLootCrate)
		{
			this.partListingButton.UpdateNewTagState();
		}
	}

	private void OnEnable()
	{
		EventManager.Connect(new EventManager.OnEvent<CraftingMachineEvent>(this.OnCraftingMachineEvent));
		if (this.machineIdleLoop != null)
		{
			AudioSource component = this.machineIdleLoop.GetComponent<AudioSource>();
			if (component != null)
			{
				component.Play();
			}
		}
	}

	private void Start()
	{
		CoroutineRunner.Instance.StartCoroutine(this.Init());
	}

	private IEnumerator Init()
	{
		if (this.alienConverter.IsAlienMachine && this.alienConverter.RoutineShown)
		{
			this.alienConverter.ConvertToAlien();
			this.UpdateAlienPartSilhouette();
			this.UpdateLiquidTank((float)this.currentMachineScrapAmount, (float)AlienCustomizationManager.GetPrice(), true);
		}
		this.SetMachineScrapAmount(GameProgress.GetInt("Machine_scrap_amount", 0, GameProgress.Location.Local, null));
		this.currentMachineScrapAmount = this.targetMachineScrapAmount;
		this.UpdateMachineScrapLabel();
		this.pullChainButton.LockDragging(true);
		this.pullChainButton.SetPositionOffset(Vector3.up * 10f);
		this.machineAnimation.state.End += this.OnMachineAnimationEnd;
		this.machineAnimation.state.Start += this.OnMachineAnimationStart;
		this.machineAnimation.state.Event += this.OnAnimationEvent;
		this.SetMachineAnimation(this.introAnimationName, false, false, true);
		this.machineAnimation.timeScale = 0f;
		yield return new WaitForSeconds(0.1f);
		if (WorkshopMenu.isDestroyed)
		{
			yield break;
		}
		this.machineAnimation.timeScale = 1f;
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.gameData.commonAudioCollection.machineIntro);
		int idleAnimationIndex = (int)this.GetPartTierFromAmount(GameProgress.GetInt("Machine_scrap_amount", 0, GameProgress.Location.Local, null));
		this.SetMachineAnimation(this.idleAnimationNames[idleAnimationIndex], true, true, true);
		if (this.collectRewardButton != null)
		{
			this.collectRewardButton.SetActive(false);
		}
		yield return new WaitForSeconds(1f);
		if (WorkshopMenu.isDestroyed)
		{
			yield break;
		}
		this.SetMachineIdleSound(idleAnimationIndex);
		float fade = 1f;
		while (fade > 0f)
		{
			fade -= Time.deltaTime;
			this.pullChainButton.SetPositionOffset(Vector3.up * fade * 10f);
			yield return null;
			if (WorkshopMenu.isDestroyed)
			{
				yield break;
			}
		}
		this.pullChainButton.LockDragging(false);
		this.introPlaying = false;
		yield break;
	}

	private void OnDestroy()
	{
		WorkshopMenu.isDestroyed = true;
		this.machineAnimation.state.End -= this.OnMachineAnimationEnd;
		this.machineAnimation.state.Start -= this.OnMachineAnimationStart;
		this.machineAnimation.state.Event -= this.OnAnimationEvent;
		AlienCraftingMachineConverter alienCraftingMachineConverter = this.alienConverter;
		alienCraftingMachineConverter.OnBeginUpgrade = (Action)Delegate.Remove(alienCraftingMachineConverter.OnBeginUpgrade, new Action(this.OnUpgradeMachineBegin));
		AlienCraftingMachineConverter alienCraftingMachineConverter2 = this.alienConverter;
		alienCraftingMachineConverter2.OnMachineBehindCurtain = (Action)Delegate.Remove(alienCraftingMachineConverter2.OnMachineBehindCurtain, new Action(this.OnMachineBehindCurtain));
		AlienCraftingMachineConverter alienCraftingMachineConverter3 = this.alienConverter;
		alienCraftingMachineConverter3.OnEndUpgrade = (Action)Delegate.Remove(alienCraftingMachineConverter3.OnEndUpgrade, new Action(this.OnUpgradeMachineEnd));
		IapManager.onPurchaseSucceeded -= this.OnItemPurchase;
		KeyListener.keyReleased -= this.HandleKeyReleased;
	}

	private void OnDisable()
	{
		EventManager.Disconnect(new EventManager.OnEvent<CraftingMachineEvent>(this.OnCraftingMachineEvent));
	}

	private void OnCraftingMachineEvent(CraftingMachineEvent data)
	{
		this.SetMachineScrapAmount(GameProgress.GetInt("Machine_scrap_amount", 0, GameProgress.Location.Local, null));
	}

	private void UpdateMachineScrapLabel()
	{
		if (this.MachineLabel != null)
		{
			this.MachineLabel.Text = string.Format("{0}", Mathf.Clamp(this.currentMachineScrapAmount, 0, int.MaxValue));
		}
	}

	private void SetMachineScrapAmount(int newAmount)
	{
		if (this.targetMachineScrapAmount == newAmount)
		{
			return;
		}
		this.targetMachineScrapAmount = newAmount;
		if (!this.IsAlienMachine && this.machineArrow != null)
		{
			float num = 1f;
			this.machineArrowStutterStrength = 1f;
			if (newAmount > 0)
			{
				if (newAmount < this.commonPrice)
				{
					num = (float)newAmount / (float)this.commonPrice * 38f;
					this.machineArrowStutterStrength = 1f;
				}
				else if (newAmount < this.rarePrice)
				{
					num = 63f + (float)(newAmount - this.commonPrice) / (float)(this.rarePrice - this.commonPrice) * 22f;
					this.machineArrowStutterStrength = 2f;
				}
				else if (newAmount < this.epicPrice)
				{
					num = 116f + (float)(newAmount - this.rarePrice) / (float)(this.epicPrice - this.rarePrice) * 22f;
					this.machineArrowStutterStrength = 3f;
				}
				else
				{
					num = 164f;
					this.machineArrowStutterStrength = 4f;
				}
				this.machineArrowStutterStrength *= 3f;
				num = Mathf.Clamp(num, 1f, 164f);
			}
			this.machineArrowTargetAngle = -num;
			float num2 = this.machineArrow.localEulerAngles.z;
			if (Mathf.Approximately(num2, 0f) || num2 < 0f)
			{
				num2 += 360f;
			}
			this.machineArrowFromAngle = num2;
			this.arrowAngleFade = 0f;
		}
		else if (this.IsAlienMachine && this.liquidFillOverride != null)
		{
			this.UpdateLiquidTank((float)this.targetMachineScrapAmount, (float)AlienCustomizationManager.GetPrice(), false);
		}
	}

	public void OpenShop()
	{
		if (this.IsMachineLocked)
		{
			return;
		}
		this.SetActive(false);
		Singleton<IapManager>.Instance.OpenShopPage(delegate
		{
			this.SetActive(true);
		}, "LootCrates");
	}

	private void SetActive(bool active)
	{
		foreach (GameObject gameObject in this.hideObjects)
		{
			if (gameObject)
			{
				gameObject.SetActive(active);
			}
		}
		base.gameObject.SetActive(active);
	}

	public void OpenPartList()
	{
		if (this.pullLeverButton.IsActivating() || (this.IsMachineLocked && !this.waitingAnimationToEnd.Equals(this.introAnimationName)))
		{
			return;
		}
		if (this.partListingButton)
		{
			this.partListingButton.OpenPartList();
		}
	}

	public void GoBack()
	{
		if (this.IsMachineLocked && !this.waitingAnimationToEnd.Equals(this.introAnimationName))
		{
			return;
		}
		if ((Singleton<GameManager>.Instance.GetPrevGameState() == GameManager.GameState.LevelSelection || Singleton<GameManager>.Instance.GetPrevGameState() == GameManager.GameState.Level) && Singleton<GameManager>.Instance.CurrentEpisode != string.Empty)
		{
			Singleton<GameManager>.Instance.LoadLevelSelection(Singleton<GameManager>.Instance.CurrentEpisode, true);
		}
		else
		{
			Singleton<GameManager>.Instance.LoadEpisodeSelection(true);
		}
	}

	private void Update()
	{
		if (this.machineArrow != null)
		{
			float value = this.machineArrowTargetAngle + 360f + (Mathf.Sin(Time.time * this.machineArrowStutterStrength) + Mathf.Sin(Time.time * 2f * this.machineArrowStutterStrength) * this.machineArrowStutterStrength * 0.4f);
			Vector3 b = Vector3.forward * Mathf.Clamp(value, 1f, 359f);
			this.arrowAngleFade += GameTime.DeltaTime;
			this.machineArrow.localEulerAngles = Vector3.Lerp(Vector3.forward * this.machineArrowFromAngle, b, this.arrowAngleFade);
		}
		if (this.targetMachineScrapAmount != this.currentMachineScrapAmount && Time.realtimeSinceStartup >= this.nextLabelUpdate)
		{
			this.nextLabelUpdate = Time.realtimeSinceStartup + SoftCurrencyButton.updateInterval;
			int deltaAmount = SoftCurrencyButton.GetDeltaAmount(this.currentMachineScrapAmount, this.targetMachineScrapAmount);
			if (this.currentMachineScrapAmount < this.targetMachineScrapAmount)
			{
				this.currentMachineScrapAmount += deltaAmount;
			}
			else if (this.currentMachineScrapAmount > this.targetMachineScrapAmount)
			{
				this.currentMachineScrapAmount -= deltaAmount;
			}
			this.UpdateMachineScrapLabel();
		}
		if (!this.IsMachineLocked && this.queuedAddScrapActions > 0)
		{
			this.queuedAddScrapActions--;
			this.AddScrap(0);
		}
	}

	public void ChainPulled()
	{
		if (this.pullChainButton.IsActivating())
		{
			return;
		}
		this.AddScrap(0);
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.gameData.commonAudioCollection.pullChain);
	}

	public void AddScrap(int addScrapAmount = 0)
	{
		this.queuedAddScrapActions++;
		if (this.IsMachineLocked)
		{
			return;
		}
		this.queuedAddScrapActions--;
		int num = GameProgress.ScrapCount();
		int num2 = GameProgress.GetInt("Machine_scrap_amount", 0, GameProgress.Location.Local, null);
		int num3 = num - num2;
		int value = Singleton<GameConfigurationManager>.Instance.GetValue<int>(WorkshopMenu.CRAFT_PRICE_CONFIG_KEY, BasePart.PartTier.Common.ToString());
		int value2 = Singleton<GameConfigurationManager>.Instance.GetValue<int>(WorkshopMenu.CRAFT_PRICE_CONFIG_KEY, BasePart.PartTier.Rare.ToString());
		int value3 = Singleton<GameConfigurationManager>.Instance.GetValue<int>(WorkshopMenu.CRAFT_PRICE_CONFIG_KEY, BasePart.PartTier.Epic.ToString());
		int price = AlienCustomizationManager.GetPrice();
		bool flag = CustomizationManager.CustomizationCount(BasePart.PartTier.Common, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable) <= 0;
		bool flag2 = CustomizationManager.CustomizationCount(BasePart.PartTier.Rare, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable) <= 0;
		bool flag3 = CustomizationManager.CustomizationCount(BasePart.PartTier.Epic, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable) <= 0;
		bool flag4 = CustomizationManager.CustomizationCount(BasePart.PartTier.Legendary, CustomizationManager.PartFlags.Locked | CustomizationManager.PartFlags.Craftable) <= 0;
		BasePart.PartTier nextTier = BasePart.PartTier.Regular;
		int num4 = 0;
		int num5;
		if (addScrapAmount > 0)
		{
			num4 = addScrapAmount;
			if (num4 + num2 < value)
			{
				num5 = 0;
			}
			else if (num4 + num2 < value2)
			{
				num5 = 1;
			}
			else if (num4 + num2 < value3)
			{
				num5 = 2;
			}
			else if (this.IsAlienMachine && num4 + num2 < price)
			{
				num5 = 2;
			}
			else
			{
				num5 = 3;
			}
			if (!this.IsAlienMachine && num4 + num2 > value3)
			{
				num4 = value3 - num2;
			}
			else if (this.IsAlienMachine && num4 + num2 > price)
			{
				num4 = price - num2;
			}
		}
		else if (!flag && num2 < value)
		{
			nextTier = BasePart.PartTier.Common;
			num4 = value - num2;
			num5 = 0;
		}
		else if (!flag2 && num2 < value2)
		{
			nextTier = BasePart.PartTier.Rare;
			num4 = value2 - num2;
			num5 = 1;
		}
		else if (!flag3 && num2 < value3)
		{
			nextTier = BasePart.PartTier.Epic;
			num4 = value3 - num2;
			num5 = 2;
		}
		else if (this.IsAlienMachine && !flag4 && num2 < price)
		{
			nextTier = BasePart.PartTier.Legendary;
			num4 = price - num2;
			num5 = 0;
		}
		else
		{
			num5 = 3;
		}
		if (num4 > 0 && num3 > 0)
		{
			if (num4 > num3)
			{
				this.ShowGetMoreScrapDialog(num4 - num3, nextTier);
				num4 = num3;
			}
			int partTierFromAmount = (int)this.GetPartTierFromAmount(num2);
			num2 += num4;
			GameProgress.SetInt("Machine_scrap_amount", num2, GameProgress.Location.Local);
			EventManager.Send(new CraftingMachineEvent(WorkshopMenu.CraftingMachineAction.AddScrap, GameProgress.GetInt("Machine_scrap_amount", 0, GameProgress.Location.Local, null)));
			num5 = (int)this.GetPartTierFromAmount(num2);
			if (num5 >= 0)
			{
				this.SetMachineAnimation(this.chainPullAnimationName, false, true, false);
				this.SetMachineAnimation(this.feedAnimationNames[num5], false, false, true);
				this.SetMachineAnimation(this.idleAnimationNames[num5], true, true, true);
				if (num5 != partTierFromAmount)
				{
					this.SetMachineIdleSound(num5);
				}
			}
			base.StartCoroutine(this.MoveNuts(this.nutRootUpper, this.nutRootLower, num4, 0.2f));
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.gameData.commonAudioCollection.insertScrap);
		}
		else
		{
			this.queuedAddScrapActions = 0;
			this.SetMachineAnimation(this.idleAnimationNames[num5], true, true, true);
			this.SetMachineIdleSound(num5);
			if (num4 > 0 && num3 <= 0)
			{
				this.ShowGetMoreScrapDialog(num4, nextTier);
			}
		}
	}

	private void ShowGetMoreScrapDialog(int missingScrapAmount, BasePart.PartTier nextTier)
	{
		GameData gameData = Singleton<GameManager>.Instance.gameData;
		int value = Singleton<GameConfigurationManager>.Instance.GetValue<int>("scrap_to_coin_value", "value");
		if (value > 0)
		{
			int price = missingScrapAmount * value;
			if (this.getMoreScrapDialog == null && gameData.m_getMoreScrapDialog != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(gameData.m_getMoreScrapDialog);
				gameObject.transform.position = new Vector3(0f, 0f, -15f);
				this.getMoreScrapDialog = gameObject.GetComponent<GetMoreScrapDialog>();
			}
			if (this.getMoreScrapDialog != null)
			{
				this.getMoreScrapDialog.SetScrapAmount(missingScrapAmount, nextTier);
				this.getMoreScrapDialog.ConfirmButtonText = string.Format("[snout] {0}", price);
				this.getMoreScrapDialog.ShowConfirmEnabled = (() => true);
				this.getMoreScrapDialog.Close();
				this.getMoreScrapDialog.SetOnConfirm(delegate
				{
					if (GameProgress.UseSnoutCoins(price))
					{
						Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinUse);
						GameProgress.AddScrap(missingScrapAmount);
						SnoutButton.Instance.UpdateAmount(false);
						this.AddScrap(0);
						this.getMoreScrapDialog.Close();
					}
					else if (Singleton<IapManager>.IsInstantiated())
					{
						this.getMoreScrapDialog.Close();
						Singleton<IapManager>.Instance.OpenShopPage(new Action(this.getMoreScrapDialog.Open), "SnoutCoinShop");
					}
					else
					{
						this.getMoreScrapDialog.Close();
					}
				});
				this.getMoreScrapDialog.Open();
			}
		}
	}

	private IEnumerator MoveNuts(Transform spawnTf, Transform targetTf, int amount, float waitTime)
	{
		if (amount <= 0)
		{
			yield break;
		}
		bool goingUp = targetTf.position.y > spawnTf.position.y;
		yield return new WaitForSeconds(waitTime);
		Transform[] nuts = new Transform[10];
		for (int i = 0; i < nuts.Length; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.nutPrefabs[0]);
			nuts[i] = gameObject.transform;
			nuts[i].position = spawnTf.position + Vector3.right * ((float)UnityEngine.Random.Range(0, i) / 10f) - Vector3.right;
			nuts[i].localEulerAngles = Vector3.forward * UnityEngine.Random.Range(0f, 180f);
		}
		int nutCount = nuts.Length;
		float fade = 0f;
		while (nutCount > 0)
		{
			fade += Time.deltaTime;
			for (int j = 0; j < nuts.Length; j++)
			{
				if (nuts[j] != null)
				{
					float d = targetTf.position.x - nuts[j].position.x;
					if (goingUp)
					{
						nuts[j].position += Vector3.up * Time.deltaTime * ((float)(j * 2) + 30f) + Vector3.right * d * Time.deltaTime * 10f;
					}
					else
					{
						nuts[j].position -= Vector3.up * Time.deltaTime * ((float)(j * 2) + 30f) - Vector3.right * d * Time.deltaTime * 10f;
					}
					if ((goingUp && nuts[j].position.y > targetTf.position.y) || (!goingUp && nuts[j].position.y < targetTf.position.y))
					{
						if (fade >= 0.8f)
						{
							UnityEngine.Object.Destroy(nuts[j].gameObject);
							nutCount--;
						}
						else
						{
							nuts[j].position = spawnTf.position + Vector3.right * 3f * ((float)UnityEngine.Random.Range(0, j) / 10f) - Vector3.right;
						}
					}
				}
			}
			yield return null;
		}
		yield break;
	}

	private void RemoveScrap(int removeAmount)
	{
		int @int = GameProgress.GetInt("Machine_scrap_amount", 0, GameProgress.Location.Local, null);
		if (@int >= removeAmount)
		{
			GameProgress.SetInt("Machine_scrap_amount", @int - removeAmount, GameProgress.Location.Local);
			EventManager.Send(new CraftingMachineEvent(WorkshopMenu.CraftingMachineAction.RemoveScrap, GameProgress.GetInt("Machine_scrap_amount", 0, GameProgress.Location.Local, null)));
		}
		else
		{
			this.ResetScrap(false);
		}
	}

	public void ResetScrap(bool playAnimation = true)
	{
		if (this.IsMachineLocked)
		{
			return;
		}
		this.queuedAddScrapActions = 0;
		if (playAnimation)
		{
			int @int = GameProgress.GetInt("Machine_scrap_amount", 0, GameProgress.Location.Local, null);
			if (@int > 0)
			{
				this.SetMachineAnimation(this.resetAnimationName, false, false, true);
				this.SetMachineAnimation(this.idleAnimationNames[0], true, true, true);
				base.StartCoroutine(this.MoveNuts(this.nutRootLower, this.nutRootUpper, @int, 0.5f));
				Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.gameData.commonAudioCollection.ejectScrap);
			}
		}
		GameProgress.SetInt("Machine_scrap_amount", 0, GameProgress.Location.Local);
		EventManager.Send(new CraftingMachineEvent(WorkshopMenu.CraftingMachineAction.ResetScrap, 0));
		this.SetMachineIdleSound(0);
	}

	private BasePart.PartTier GetPartTierFromAmount(int amount)
	{
		for (int i = 3; i > 0; i--)
		{
			if (amount == AlienCustomizationManager.GetPrice())
			{
				return BasePart.PartTier.Legendary;
			}
			GameConfigurationManager instance = Singleton<GameConfigurationManager>.Instance;
			string craft_PRICE_CONFIG_KEY = WorkshopMenu.CRAFT_PRICE_CONFIG_KEY;
			BasePart.PartTier partTier = (BasePart.PartTier)i;
			if (amount >= instance.GetValue<int>(craft_PRICE_CONFIG_KEY, partTier.ToString()))
			{
				return (BasePart.PartTier)i;
			}
		}
		return BasePart.PartTier.Regular;
	}

	public void CraftSelectedPart()
	{
		if (this.IsMachineLocked)
		{
			return;
		}
		this.queuedAddScrapActions = 0;
		BasePart.PartTier partTierFromAmount = this.GetPartTierFromAmount(GameProgress.GetInt("Machine_scrap_amount", 0, GameProgress.Location.Local, null));
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.gameData.commonAudioCollection.craftLeverCrank);
		if (partTierFromAmount == BasePart.PartTier.Regular)
		{
			this.SetMachineAnimation(this.insufficientScrapAnimationName, false, false, true);
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.gameData.commonAudioCollection.craftEmpty);
			MaterialAnimation component = this.MachineLabel.GetComponent<MaterialAnimation>();
			if (component != null)
			{
				component.PlayAnimation(true, 5);
			}
			return;
		}
		SnoutButton.Instance.EnableButton(false);
		int num = 0;
		BasePart basePart = null;
		if (partTierFromAmount == BasePart.PartTier.Legendary && AlienCustomizationManager.GetNextUnlockable(out basePart))
		{
			num = AlienCustomizationManager.GetPrice();
		}
		else if (partTierFromAmount != BasePart.PartTier.Legendary)
		{
			num = Singleton<GameConfigurationManager>.Instance.GetValue<int>(WorkshopMenu.CRAFT_PRICE_CONFIG_KEY, partTierFromAmount.ToString());
			basePart = CustomizationManager.GetRandomCraftablePartFromTier(partTierFromAmount, true);
		}
		if (basePart && num > 0 && GameProgress.UseScrap(num))
		{
			this.SetMachineAnimation((!this.IsAlienMachine) ? this.craftAnimationName : this.slimeCraftAnimationName, false, false, false);
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.gameData.commonAudioCollection.craftPart);
			CustomizationManager.UnlockPart(basePart, "crafted");
			this.RemoveScrap(num);
			this.SetMachineIdleSound(0);
			PlayerProgress.ExperienceType experienceType = PlayerProgress.ExperienceType.CommonPartCrafted;
			if (partTierFromAmount == BasePart.PartTier.Rare)
			{
				experienceType = PlayerProgress.ExperienceType.RarePartCrafted;
			}
			if (partTierFromAmount == BasePart.PartTier.Epic)
			{
				experienceType = PlayerProgress.ExperienceType.EpicPartCrafted;
			}
			if (partTierFromAmount == BasePart.PartTier.Legendary)
			{
				experienceType = PlayerProgress.ExperienceType.LegendaryPartCrafted;
			}
			PlayerProgressBar.Instance.DelayUpdate();
			int exp = Singleton<PlayerProgress>.Instance.AddExperience(experienceType);
			this.ShowReward(basePart, exp);
			string key = "CraftCount" + basePart.m_partTier.ToString();
			int @int = GameProgress.GetInt(key, 0, GameProgress.Location.Local, null);
			GameProgress.SetInt(key, @int + 1, GameProgress.Location.Local);
			if (Singleton<SocialGameManager>.IsInstantiated() && basePart.m_partTier == BasePart.PartTier.Epic)
			{
				Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.CRAFT_PARTS", 100.0);
			}
			this.partsCraftedWhileInScreen++;
			EventManager.Send(new CraftingMachineEvent(WorkshopMenu.CraftingMachineAction.CraftPart, 0));
		}
		else if (basePart)
		{
		}
	}

	private void ShowReward(BasePart part, int exp)
	{
		if (this.rewardGameObject != null)
		{
			UnityEngine.Object.Destroy(this.rewardGameObject);
		}
		this.rewardGameObject = UnityEngine.Object.Instantiate<GameObject>(this.lootRewardBackgrounds[(int)part.m_partTier]);
		this.rewardGameObject.transform.parent = this.rewardSpawnRoot.transform;
		this.rewardGameObject.transform.localPosition = Vector3.zero;
		this.rewardGameObject.transform.localScale = Vector3.one * 2f;
		this.rewardGameObject.transform.localRotation = Quaternion.identity;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(part.m_constructionIconSprite.gameObject);
		LootRewardElement component = this.rewardGameObject.GetComponent<LootRewardElement>();
		if (component)
		{
			gameObject.transform.parent = component.IconRoot;
		}
		gameObject.transform.localPosition = -Vector3.forward * 0.5f;
		gameObject.transform.localScale = Vector3.one * 1.5f;
		gameObject.transform.localEulerAngles = Vector3.forward * 270f;
		base.StartCoroutine(this.WaitForReward(this.rewardGameObject, exp));
	}

	private IEnumerator WaitForReward(GameObject reward, int exp)
	{
		Transform[] tfs = reward.GetComponentsInChildren<Transform>();
		foreach (Transform transform in tfs)
		{
			transform.gameObject.layer = LayerMask.NameToLayer("Default");
		}
		MeshRenderer[] mrs = reward.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer meshRenderer in mrs)
		{
			meshRenderer.sortingLayerName = "Default";
			meshRenderer.sortingOrder = 0;
		}
		reward.SetActive(false);
		float waitTime = 1f;
		while (waitTime > 0f)
		{
			waitTime -= Time.deltaTime;
			yield return null;
		}
		reward.SetActive(true);
		waitTime = 6.18f;
		while (waitTime > 0f)
		{
			waitTime -= Time.deltaTime;
			yield return null;
		}
		if (this.IsAlienMachine)
		{
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.gameData.commonAudioCollection.alienMachineReveal);
		}
		foreach (MeshRenderer meshRenderer2 in mrs)
		{
			meshRenderer2.sortingLayerName = "Popup";
			meshRenderer2.sortingOrder = 0;
		}
		reward.transform.ResetPosition(TransformCategory.Axis.Z);
		BackgroundMask.Show(true, this, "Popup", null, Vector3.forward, true);
		ResourceBar.Instance.ShowItem(ResourceBar.Item.PlayerProgress, true, false);
		foreach (Transform transform2 in tfs)
		{
			transform2.gameObject.layer = LayerMask.NameToLayer("HUD");
		}
		yield return new WaitForSeconds(2f);
		if (PlayerProgressBar.Instance)
		{
			PlayerProgressBar.Instance.AddParticles(reward, exp, 0f, 0f, delegate(bool active)
			{
				if (active)
				{
					ResourceBar.Instance.ShowItem(ResourceBar.Item.PlayerProgress, true, true);
				}
			});
		}
		if (this.collectRewardButton != null)
		{
			this.collectRewardButton.SetActive(true);
		}
		EventManager.Connect(new EventManager.OnEvent<LevelUpEvent>(this.OnPlayerLevelUp));
		yield break;
	}

	private void OnPlayerLevelUp(LevelUpEvent data)
	{
		this.CollectReward(false);
	}

	public void CollectReward(bool hideProgressBar = true)
	{
		EventManager.Disconnect(new EventManager.OnEvent<LevelUpEvent>(this.OnPlayerLevelUp));
		if (this.collectRewardButton != null)
		{
			this.collectRewardButton.SetActive(false);
		}
		if (this.rewardGameObject != null)
		{
			UnityEngine.Object.Destroy(this.rewardGameObject);
		}
		this.machineIsLocked = false;
		BackgroundMask.Show(false, this, "Popup", null, Vector3.back, true);
		if (hideProgressBar)
		{
			ResourceBar.Instance.ShowItem(ResourceBar.Item.PlayerProgress, false, true);
		}
		ResourceBar.Instance.ShowItem(ResourceBar.Item.SnoutCoin, true, true);
		this.SetMachineAnimation(this.hideRewardAnimationName, false, false, true);
		this.partListingButton.UpdateNewTagState();
		if (!this.IsAlienMachine)
		{
			this.customizationsFullCheck.Check();
		}
		else
		{
			this.UpdateAlienPartSilhouette();
		}
		this.alienConverter.Check();
	}

	private void SetMachineAnimation(string newAnimation, bool loop = false, bool queue = false, bool releaseAfterEnd = true)
	{
		if (this.machineAnimation != null)
		{
			if (queue)
			{
				this.machineAnimation.state.AddAnimation(0, newAnimation, loop, 0f);
			}
			else
			{
				this.machineIsLocked = true;
				this.waitingAnimationToEnd = ((!releaseAfterEnd) ? string.Empty : newAnimation);
				this.machineAnimation.state.SetAnimation(0, newAnimation, loop);
			}
		}
	}

	private void OnMachineAnimationStart(Spine.AnimationState state, int trackIndex)
	{
		if (this.idleAnimationNames != null && this.idleAnimationNames.Length > 3)
		{
			bool flag = this.idleAnimationNames[3].Equals(state.ToString());
			if (this.machineSmokePuffEffect != null)
			{
				if (flag)
				{
					this.machineSmokePuffEffect.Play();
				}
				else
				{
					this.machineSmokePuffEffect.Stop();
				}
			}
		}
	}

	private void OnMachineAnimationEnd(Spine.AnimationState state, int trackIndex)
	{
		if (this.waitingAnimationToEnd.Equals(state.ToString()))
		{
			this.machineIsLocked = false;
		}
		if (this.introAnimationName.Equals(state.ToString()))
		{
			EventManager.Send(new CraftingMachineEvent(WorkshopMenu.CraftingMachineAction.Idle, 0));
		}
	}

	private void SetMachineIdleSound(int index)
	{
		int num = Mathf.Clamp(index, 0, this.gameData.commonAudioCollection.machineIdles.Length - 1);
		if (this.machineIdleLoop == null)
		{
			this.machineIdleLoop = Singleton<AudioManager>.Instance.SpawnLoopingEffect(this.gameData.commonAudioCollection.machineIdles[num], base.transform);
		}
		else
		{
			AudioSource component = this.machineIdleLoop.GetComponent<AudioSource>();
			Singleton<AudioManager>.Instance.StopLoopingEffect(component);
			this.machineIdleLoop = Singleton<AudioManager>.Instance.SpawnLoopingEffect(this.gameData.commonAudioCollection.machineIdles[num], base.transform);
		}
	}

	private void OnAnimationEvent(Spine.AnimationState state, int trackIndex, Spine.Event e)
	{
		string name = e.Data.Name;
		if (name != null)
		{
			if (!(name == "Intro_MachineDrop"))
			{
				if (!(name == "InsufficientScrap"))
				{
					if (!(name == "Reset_Button_Push"))
					{
						if (!(name == "LightBulb"))
						{
							if (!(name == "Item_Extract"))
							{
								if (name == "Item_Drop")
								{
									Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.gameData.commonAudioCollection.partCraftedJingle);
								}
							}
							else if (this.IsAlienMachine)
							{
								Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.gameData.commonAudioCollection.craftingSlime);
							}
						}
						else
						{
							Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.gameData.commonAudioCollection.lightBulb);
						}
					}
					else
					{
						Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.gameData.commonAudioCollection.ejectScrapButton);
					}
				}
				else if (this.machineCraftEmptyEffect)
				{
					this.machineCraftEmptyEffect.Play();
				}
			}
			else if (this.machineDropEffect)
			{
				this.machineDropEffect.Play();
			}
		}
	}

	private void UpdateLiquidTank(float currentScrap, float requiredScrap, bool quick = false)
	{
		float num = currentScrap / requiredScrap;
		float y = this.maxFill * num;
		Vector3 localPosition = this.liquidFillOverride.localPosition;
		localPosition.y = y;
		if (quick)
		{
			this.liquidFillOverride.localPosition = localPosition;
		}
		else
		{
			base.StartCoroutine(CoroutineRunner.MoveObject(this.liquidFillOverride, localPosition, 1f, true));
		}
	}

	private void UpdateAlienPartSilhouette()
	{
		if (!AlienCustomizationManager.Initialized)
		{
			return;
		}
		if (!AlienCustomizationManager.HasCraftableItems)
		{
			this.nextAlienPartIcon.ClearSprite();
			this.checkMark.SetActive(true);
			return;
		}
		this.checkMark.SetActive(false);
		BasePart basePart;
		if (AlienCustomizationManager.GetNextUnlockable(out basePart))
		{
			string id = basePart.m_constructionIconSprite.Id;
			SpriteData spriteData = Singleton<RuntimeSpriteDatabase>.Instance.Find(id);
			this.nextAlienPartIcon.SetSprite(basePart.m_constructionIconSprite.gameObject);
		}
		else
		{
			this.nextAlienPartIcon.ClearSprite();
		}
	}

	public static string CRAFT_PRICE_CONFIG_KEY = "part_crafting_prices";

	public static string SALVAGE_PRICE_CONFIG_KEY = "part_salvage_rewards";

	public static bool isDestroyed = true;

	[SerializeField]
	private SpriteText normalMachineLabel;

	[SerializeField]
	private SpriteText alienMachineLabel;

	[SerializeField]
	private Transform machineArrow;

	[SerializeField]
	private GameObject collectRewardButton;

	[SerializeField]
	private GameObject[] lootRewardBackgrounds;

	[SerializeField]
	private GameObject checkMark;

	[SerializeField]
	private GameObject rewardSpawnRoot;

	[SerializeField]
	private GameObject[] hideObjects;

	[SerializeField]
	private SkeletonAnimation machineAnimation;

	[SerializeField]
	private string introAnimationName;

	[SerializeField]
	private string hideRewardAnimationName;

	[SerializeField]
	private string meterFillAnimationName;

	[SerializeField]
	private string resetAnimationName;

	[SerializeField]
	private string craftAnimationName;

	[SerializeField]
	private string slimeCraftAnimationName;

	[SerializeField]
	private string chainPullAnimationName;

	[SerializeField]
	private string insufficientScrapAnimationName;

	[SerializeField]
	private string[] feedAnimationNames;

	[SerializeField]
	private string[] idleAnimationNames;

	[SerializeField]
	private GameObject[] nutPrefabs;

	[SerializeField]
	private Transform nutRootUpper;

	[SerializeField]
	private Transform nutRootLower;

	[SerializeField]
	private PullButton pullChainButton;

	[SerializeField]
	private PullButton pullLeverButton;

	[SerializeField]
	private PartListing partListing;

	[SerializeField]
	private ParticleSystem machineDropEffect;

	[SerializeField]
	private ParticleSystem machineCraftEmptyEffect;

	[SerializeField]
	private ParticleSystem machineSmokePuffEffect;

	[SerializeField]
	private CustomizationsFullCheck customizationsFullCheck;

	private CustomizePartWidget partListingButton;

	[SerializeField]
	private AlienCraftingMachineConverter alienConverter;

	[SerializeField]
	private Transform liquidFillOverride;

	[SerializeField]
	private float maxFill;

	[SerializeField]
	private CustomShaderSprite nextAlienPartIcon;

	[SerializeField]
	private string alienSkinName;

	private GameData gameData;

	private bool machineIsLocked = true;

	private bool introPlaying = true;

	private string waitingAnimationToEnd = string.Empty;

	private float machineArrowFromAngle;

	private float machineArrowTargetAngle;

	private float machineArrowStutterStrength = 1f;

	private GameObject rewardGameObject;

	private int queuedAddScrapActions;

	private GetMoreScrapDialog getMoreScrapDialog;

	private int commonPrice;

	private int rarePrice;

	private int epicPrice;

	private int targetMachineScrapAmount;

	private int currentMachineScrapAmount;

	protected float nextLabelUpdate;

	private GameObject machineIdleLoop;

	private int partsCraftedWhileInScreen;

	private float arrowAngleFade;

	public enum CraftingMachineAction
	{
		None,
		Idle,
		ResetScrap,
		AddScrap,
		RemoveScrap,
		CraftPart
	}

	public struct CraftingMachineEvent : EventManager.Event
	{
		public CraftingMachineEvent(CraftingMachineAction action, int scrapAmountInMachine = 0)
		{
			this.action = action;
			this.scrapAmountInMachine = scrapAmountInMachine;
		}

		public CraftingMachineAction action;

		public int scrapAmountInMachine;
	}
}
