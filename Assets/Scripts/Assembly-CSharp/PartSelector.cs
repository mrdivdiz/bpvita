using System;
using System.Collections.Generic;
using UnityEngine;

public class PartSelector : WPFMonoBehaviour, WidgetListener
{
	public int UsedRows
	{
		get
		{
			return this.m_scrollList.UsedRows;
		}
	}

	public void SetMaxRows(int rows)
	{
		this.m_scrollList.SetMaxRows(rows);
	}

	public void SetConstructionUI(ConstructionUI constructionUI)
	{
		this.m_constructionUI = constructionUI;
	}

	public GameObject FindPartButton(ConstructionUI.PartDesc partDesc)
	{
		return this.m_scrollList.FindButton(partDesc);
	}

	public void SetSelection(ConstructionUI.PartDesc targetObject)
	{
		if (WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.AutoBuilding)
		{
			this.m_scrollList.SetSelection(targetObject);
		}
	}

	public void Select(Widget widget, object targetObject)
	{
		if (this.m_constructionUI && WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.AutoBuilding && WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.SuperAutoBuilding)
		{
			this.m_constructionUI.SelectPart((ConstructionUI.PartDesc)targetObject);
		}
	}

	public void StartDrag(Widget widget, object targetObject)
	{
		if (this.m_constructionUI && WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.AutoBuilding && WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.SuperAutoBuilding)
		{
			this.m_constructionUI.StartDrag((ConstructionUI.PartDesc)targetObject);
		}
	}

	public void CancelDrag(Widget widget, object targetObject)
	{
		if (this.m_constructionUI)
		{
			this.m_constructionUI.CancelDrag((ConstructionUI.PartDesc)targetObject);
		}
	}

	public void Drop(Widget widget, Vector3 dropPosition, object targetObject)
	{
	}

	public void SetParts(List<ConstructionUI.PartDesc> partDescs)
	{
		this.m_partDescs = new List<ConstructionUI.PartDesc>(partDescs);
		foreach (ConstructionUI.PartDesc partDesc in this.m_partDescs)
		{
			partDesc.sortKey = this.m_partOrder[partDesc.part.m_partType];
		}
		this.m_partDescs.Sort(new PartSelector.PartDescOrder(WPFMonoBehaviour.gameData));
		this.CreatePartList(false);
	}

	public void ResetSelection()
	{
		this.m_scrollList.ResetSelection();
	}

	private void Awake()
	{
		this.m_scrollList = base.transform.Find("ScrollList").GetComponent<ExtendedScrollList>();
		this.m_scrollList.SetListener(this);
		if (Singleton<BuildCustomizationLoader>.Instance.IsHDVersion)
		{
			this.m_scrollList.SetMaxRows(2);
		}
		else
		{
			this.m_scrollList.SetButtonScale(1.5f);
			base.transform.Translate(new Vector3(0f, 0.5f, 0f));
		}
		this.ReadPartOrder();
		if (!WPFMonoBehaviour.levelManager)
		{
			this.CreateTestPartList();
		}
		EventManager.Connect<CustomizePartUI.PartCustomizationEvent>(new EventManager.OnEvent<CustomizePartUI.PartCustomizationEvent>(this.OnPartCustomized));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect<CustomizePartUI.PartCustomizationEvent>(new EventManager.OnEvent<CustomizePartUI.PartCustomizationEvent>(this.OnPartCustomized));
	}

	private void OnPartCustomized(CustomizePartUI.PartCustomizationEvent data)
	{
		if (this.m_partDescs == null)
		{
			return;
		}
		foreach (ConstructionUI.PartDesc partDesc in this.m_partDescs)
		{
			if (partDesc.part.m_partType == data.customizedPart)
			{
				partDesc.part = WPFMonoBehaviour.gameData.GetCustomPart(partDesc.part.m_partType, data.customPartIndex);
				GameObject gameObject = partDesc.part.m_constructionIconSprite.gameObject;
				partDesc.part.customPartIndex = data.customPartIndex;
				if (partDesc.currentPartIcon != null && gameObject != null)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject);
					gameObject2.transform.parent = partDesc.currentPartIcon.parent;
					gameObject2.transform.localScale = new Vector3(1.75f, 1.75f, 1f);
					gameObject2.transform.localPosition = new Vector3(0f, 0f, -0.5f);
					ConstructionUI.SetSortingOrder(gameObject2, 1, string.Empty);
					UnityEngine.Object.Destroy(partDesc.currentPartIcon.gameObject);
					partDesc.currentPartIcon = gameObject2.transform;
					if (partDesc.currentPartIcon.parent != null && partDesc.currentPartIcon.parent.GetComponent<DraggableButton>() != null)
					{
						partDesc.currentPartIcon.parent.GetComponent<DraggableButton>().Icon = gameObject2;
					}
				}
			}
		}
	}

	private void Start()
	{
	}

	private void LateUpdate()
	{
		Vector3 position = this.m_toolBox.position;
		if (this.m_scrollList.leftButton.transform.position.y > position.y)
		{
			position.y = this.m_scrollList.leftButton.transform.position.y;
			this.m_toolBox.position = position;
		}
		position = this.m_partList.position;
		if (this.m_scrollList.rightButton.transform.position.y > position.y)
		{
			position.y = this.m_scrollList.rightButton.transform.position.y;
			this.m_partList.position = position;
		}
	}

	private void ReadPartOrder()
	{
		this.m_partOrder.Clear();
		string text = this.m_gameData.m_partOrderList.text;
		char[] separator = new char[]
		{
			'\n'
		};
		string[] array = text.Split(separator);
		int num = 0;
		foreach (string text2 in array)
		{
			string text3 = text2.Trim();
			if (text3 != string.Empty)
			{
				BasePart.PartType key = BasePart.PartType.Unknown;
				foreach (GameObject gameObject in this.m_gameData.m_parts)
				{
					BasePart.PartType partType = gameObject.GetComponent<BasePart>().m_partType;
					if (partType.ToString() == text3)
					{
						key = partType;
						break;
					}
				}
				this.m_partOrder[key] = num;
				num++;
			}
		}
	}

	private void CreatePartList(bool handleDragIcons)
	{
		this.m_scrollList.Clear();
		foreach (ConstructionUI.PartDesc partDesc in this.m_partDescs)
		{
			BasePart part = partDesc.part;
			GameObject gameObject = part.m_constructionIconSprite.gameObject;
			bool flag = true;
			int num = 0;
			int num2 = 0;
			int num3 = GameProgress.GetAllStars() + GameProgress.GetRaceLevelUnlockedStars();
			bool flag2 = false;
			if (WPFMonoBehaviour.levelManager && WPFMonoBehaviour.levelManager.m_raceLevel && WPFMonoBehaviour.levelManager.CurrentGameMode is BaseGameMode)
			{
				string currentLevelIdentifier = Singleton<GameManager>.Instance.CurrentLevelIdentifier;
				RaceLevels.LevelUnlockablePartsData levelUnlockableData = WPFMonoBehaviour.gameData.m_raceLevels.GetLevelUnlockableData(currentLevelIdentifier);
				if (levelUnlockableData != null)
				{
					foreach (RaceLevels.UnlockableTier unlockableTier in levelUnlockableData.m_tiers)
					{
						if (unlockableTier.m_part == part.m_partType)
						{
							if (num3 < unlockableTier.m_starLimit)
							{
								flag = false;
								num = Mathf.Max(unlockableTier.m_starLimit - num3, 0);
								num2 = unlockableTier.m_starLimit;
								if (this.m_unlockPartTierDialog == null)
								{
									this.m_unlockPartTierDialog = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_unlockPartTierDialog).GetComponent<UnlockRoadHogsParts>();
									this.m_unlockPartTierDialog.transform.position = WPFMonoBehaviour.hudCamera.transform.position + new Vector3(0f, 0f, 10f);
									this.m_unlockPartTierDialog.Close();
									this.m_unlockPartTierDialog.onOpen += delegate()
									{
										this.m_constructionUI.DisableFunctionality = true;
									};
									this.m_unlockPartTierDialog.onClose += delegate()
									{
										this.m_constructionUI.DisableFunctionality = false;
									};
								}
							}
							else if (!GameProgress.GetRaceLevelPartUnlocked(currentLevelIdentifier, part.m_partType.ToString()))
							{
								GameProgress.SetRaceLevelPartUnlocked(currentLevelIdentifier, part.m_partType.ToString(), true);
								flag2 = true;
							}
							break;
						}
					}
				}
			}
			GameObject original = (!flag) ? this.m_partUnavailableButtonPrefab : this.m_partButtonPrefab;
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(original);
			gameObject2.transform.parent = this.m_scrollList.transform;
			ConstructionUI.SetSortingOrder(gameObject2, 1, string.Empty);
			if (flag)
			{
				gameObject2.GetComponent<DraggableButton>().DragObject = partDesc;
				if (handleDragIcons)
				{
					gameObject2.GetComponent<DraggableButton>().DragIconPrefab = gameObject;
				}
				gameObject2.GetComponent<DraggableButton>().DragIconScale = 1.75f;
				Transform transform = gameObject2.transform.Find("PartCount");
				transform.GetComponent<TextMesh>().text = (partDesc.maxCount - partDesc.useCount).ToString();
				transform.GetComponent<PartCounter>().m_partType = partDesc.part.m_partType;
				transform.GetComponent<Renderer>().sortingOrder = 1;
			}
			else
			{
				Transform transform2 = gameObject2.transform.Find("Starlimit");
				transform2.GetComponent<TextMesh>().text = num.ToString();
				transform2.GetComponent<Renderer>().sortingOrder = 1;
				int productPrice = Singleton<VirtualCatalogManager>.Instance.GetProductPrice("road_hogs_star_unlock");
				if (productPrice > 0 && !Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
				{
					int totalCost = (num2 - num3) * productPrice;
					this.AddUnlockStarTierPopup(gameObject2.GetComponent<UnavailablePartButton>(), this.m_unlockPartTierDialog, num2, num3, totalCost, () => GameProgress.SnoutCoinCount() >= totalCost);
				}
			}
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(gameObject);
			gameObject3.transform.parent = gameObject2.transform;
			gameObject3.transform.localScale = new Vector3(1.75f, 1.75f, 1f);
			gameObject3.transform.localPosition = new Vector3(0f, 0f, -0.5f);
			ConstructionUI.SetSortingOrder(gameObject3, 1, string.Empty);
			partDesc.currentPartIcon = gameObject3.transform;
			if (flag)
			{
				gameObject2.GetComponent<DraggableButton>().Icon = gameObject3;
				if (flag2)
				{
					GameObject gameObject4 = UnityEngine.Object.Instantiate<GameObject>(this.m_partUnlockAnimatedLock);
					gameObject4.transform.parent = gameObject2.transform;
					gameObject4.transform.localPosition = new Vector3(0f, 0.6f, -1f);
				}
			}
			this.m_scrollList.AddButton(gameObject2.GetComponent<Widget>());
		}
		foreach (ConstructionUI.PartDesc partDesc2 in this.m_partDescs)
		{
			if (partDesc2 != null && !(partDesc2.part == null))
			{
				int lastUsedPartIndex = CustomizationManager.GetLastUsedPartIndex(partDesc2.part.m_partType);
				if (lastUsedPartIndex > 0)
				{
					this.OnPartCustomized(new CustomizePartUI.PartCustomizationEvent(partDesc2.part.m_partType, lastUsedPartIndex));
				}
			}
		}
	}

	private void CreateTestPartList()
	{
		this.m_partDescs = new List<ConstructionUI.PartDesc>();
		foreach (GameObject gameObject in this.m_gameData.m_parts)
		{
			ConstructionUI.PartDesc partDesc = new ConstructionUI.PartDesc();
			partDesc.part = gameObject.GetComponent<BasePart>();
			partDesc.sortKey = this.m_partOrder[gameObject.GetComponent<BasePart>().m_partType];
			partDesc.maxCount = UnityEngine.Random.Range(0, 20);
			this.m_partDescs.Add(partDesc);
		}
		this.m_partDescs.Sort(new PartSelector.PartDescOrder(WPFMonoBehaviour.gameData));
		this.CreatePartList(true);
	}

	public void AddUnlockStarTierPopup(UnavailablePartButton button, UnlockRoadHogsParts dialog, int tier, int currentStars, int cost, Func<bool> requirements)
	{
		if (button == null || dialog == null)
		{
			return;
		}
		button.OnPress = (Action)Delegate.Combine(button.OnPress, new Action(delegate()
		{
			dialog.Cost = string.Format("[snout] {0}", cost);
			dialog.ShowConfirmEnabled = (() => true);
			dialog.SetOnConfirm(delegate
			{
				if (requirements() && GameProgress.UseSnoutCoins(cost))
				{
					int num = tier - currentStars;
					GameProgress.AddRaceLevelUnlockedStars(num);
					Dictionary<string, string> data = new Dictionary<string, string>
					{
						{
							"Item_name",
							"Snout Coin"
						},
						{
							"Type_of_item",
							"currency"
						},
						{
							"Amount",
							string.Format("{0}", cost)
						},
						{
							"Type_of_use",
							"Unlock Race Level Stars"
						},
						{
							"Screen",
							"Race Level"
						},
						{
							"Level",
							Singleton<GameManager>.Instance.CurrentLevelIdentifier
						},
						{
							"Unlocked_star_count",
							string.Format("{0}", num)
						}
					};
					Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.snoutCoinUse);
					this.CreatePartList(false);
					dialog.Close();
				}
				else if (!requirements() && Singleton<IapManager>.IsInstantiated())
				{
					dialog.Close();
					Singleton<IapManager>.Instance.OpenShopPage(new Action(dialog.Open), "SnoutCoinShop");
				}
				else
				{
					dialog.Close();
				}
			});
			dialog.Open();
		}));
	}

	public GameObject m_partButtonPrefab;

	public GameObject m_partUnavailableButtonPrefab;

	public GameObject m_partUnlockAnimatedLock;

	public GameData m_gameData;

	public Transform m_toolBox;

	public Transform m_partList;

	private ExtendedScrollList m_scrollList;

	private List<ConstructionUI.PartDesc> m_partDescs;

	private ConstructionUI m_constructionUI;

	private Dictionary<BasePart.PartType, int> m_partOrder = new Dictionary<BasePart.PartType, int>();

	private UnlockRoadHogsParts m_unlockPartTierDialog;

	public class PartDescOrder : IComparer<ConstructionUI.PartDesc>
	{
		public PartDescOrder(GameData data)
		{
			this.gameData = data;
		}

		public int Compare(ConstructionUI.PartDesc obj1, ConstructionUI.PartDesc obj2)
		{
			int partStarLimit = this.GetPartStarLimit(obj1.part.m_partType);
			int partStarLimit2 = this.GetPartStarLimit(obj2.part.m_partType);
			if (partStarLimit < partStarLimit2)
			{
				return -1;
			}
			if (partStarLimit > partStarLimit2)
			{
				return 1;
			}
			if (obj1.sortKey < obj2.sortKey)
			{
				return -1;
			}
			if (obj1.sortKey > obj2.sortKey)
			{
				return 1;
			}
			return 0;
		}

		private int GetPartStarLimit(BasePart.PartType part)
		{
			string currentLevelIdentifier = Singleton<GameManager>.Instance.CurrentLevelIdentifier;
			RaceLevels.LevelUnlockablePartsData levelUnlockableData = this.gameData.m_raceLevels.GetLevelUnlockableData(currentLevelIdentifier);
			if (levelUnlockableData != null)
			{
				foreach (RaceLevels.UnlockableTier unlockableTier in levelUnlockableData.m_tiers)
				{
					if (unlockableTier.m_part == part)
					{
						return unlockableTier.m_starLimit;
					}
				}
				return -1;
			}
			return -1;
		}

		private GameData gameData;
	}
}
