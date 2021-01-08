using System;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionUI : WPFMonoBehaviour
{
	public List<ConstructionUI.PartDesc> PartDescriptors
	{
		get
		{
			return this.m_partDescs;
		}
	}

	public bool DisableFunctionality
	{
		get
		{
			return this.m_disableFunctionality;
		}
		set
		{
			this.m_disableFunctionality = value;
		}
	}

	public List<ConstructionUI.PartDesc> UnlockedParts
	{
		get
		{
			return this.m_unlockedParts;
		}
	}

	public int RotationCount
	{
		get
		{
			return this.m_rotationCounter;
		}
	}

	public int MoveCount
	{
		get
		{
			return this.m_moveCounter;
		}
	}

	private void AddMove()
	{
		this.m_lastMoveTime = Time.time;
		this.m_moveCounter++;
	}

	private void OnDestroy()
	{
		EventManager.Disconnect<UIEvent>(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
		EventManager.Disconnect<CustomizePartUI.PartCustomizationEvent>(new EventManager.OnEvent<CustomizePartUI.PartCustomizationEvent>(this.OnPartCustomization));
	}

	public ConstructionUI.PartDesc FindPartDesc(BasePart.PartType partType)
	{
		foreach (ConstructionUI.PartDesc partDesc in this.m_partDescs)
		{
			if (partDesc.part.m_partType == partType)
			{
				return partDesc;
			}
		}
		return null;
	}

	public int PartSelectorRowCount()
	{
		return this.partSelector.UsedRows;
	}

	public void SetPartSelectorMaxRowCount(int rows)
	{
		this.partSelector.SetMaxRows(rows);
	}

	public GameObject FindPartButton(BasePart.PartType partType)
	{
		return this.partSelector.FindPartButton(this.FindPartDesc(partType));
	}

	public void AddUnlockedPart(BasePart.PartType partType, int count)
	{
		foreach (ConstructionUI.PartDesc partDesc in this.m_partDescs)
		{
			if (partDesc.part.m_partType == partType)
			{
				partDesc.maxCount += count;
				EventManager.Send<PartCountChanged>(new PartCountChanged(partType, partDesc.CurrentCount));
			}
		}
	}

	private void OnEnable()
	{
		this.SetButtonPositions();
		this.m_lastMoveTime = Time.time;
		EventManager.Connect<GameTimePaused>(new EventManager.OnEvent<GameTimePaused>(this.ReceiveGameTimePaused));
	}

	private void OnDisable()
	{
		EventManager.Disconnect<GameTimePaused>(new EventManager.OnEvent<GameTimePaused>(this.ReceiveGameTimePaused));
	}

	private void OnApplicationPause(bool paused)
	{
		if (paused && this.m_draggedElement != -1)
		{
			this.partSelector.ResetSelection();
			if (this.m_draggedElement != -1)
			{
				this.SetDraggedElement(-1);
			}
		}
	}

	private void ReceiveGameTimePaused(GameTimePaused data)
	{
		if (data.paused && this.m_draggedElement != -1)
		{
			this.partSelector.ResetSelection();
			if (this.m_draggedElement != -1)
			{
				this.SetDraggedElement(-1);
			}
		}
	}

	private void Awake()
	{
		EventManager.Connect<UIEvent>(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
		EventManager.Connect<CustomizePartUI.PartCustomizationEvent>(new EventManager.OnEvent<CustomizePartUI.PartCustomizationEvent>(this.OnPartCustomization));
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		this.m_useDragOffset = (DeviceInfo.UsesTouchInput && !Singleton<BuildCustomizationLoader>.Instance.IsHDVersion);
		this.m_allowDragPlacement = !DeviceInfo.UsesTouchInput;
		foreach (GameObject gameObject in WPFMonoBehaviour.gameData.m_parts)
		{
			Transform transform = gameObject.transform;
			this.m_parts.Add(transform);
			BasePart component = gameObject.GetComponent<BasePart>();
			int partTypeCount = WPFMonoBehaviour.levelManager.GetPartTypeCount(component.m_partType);
			if (partTypeCount != 0 || this.m_purchasableParts.Contains(transform))
			{
				Transform transform2 = UnityEngine.Object.Instantiate<Transform>(transform);
				component = transform2.GetComponent<BasePart>();
				transform2.gameObject.SetActive(false);
				transform2.parent = base.transform;
				MeshRenderer component2 = transform2.GetComponent<MeshRenderer>();
				if (component.m_constructionIconSprite)
				{
					component2 = component.m_constructionIconSprite.GetComponent<MeshRenderer>();
				}
				if (component2)
				{
					if (component2.sharedMaterial)
					{
						Texture mainTexture = component2.sharedMaterial.mainTexture;
						if (mainTexture)
						{
							ConstructionUI.PartDesc partDesc = new ConstructionUI.PartDesc();
							partDesc.part = component;
							partDesc.tex = mainTexture;
							partDesc.coordX = num;
							partDesc.coordY = num2;
							partDesc.useCount = 0;
							partDesc.maxCount = partTypeCount;
							partDesc.customPartIndex = 0;
							if (WPFMonoBehaviour.levelManager.m_sandbox && !(WPFMonoBehaviour.levelManager.CurrentGameMode is CakeRaceMode))
							{
								int unlockedSandboxPartCount = GameProgress.GetUnlockedSandboxPartCount(component.m_partType);
								if (unlockedSandboxPartCount > 0)
								{
									GameProgress.SetUnlockedSandboxPartCount(component.m_partType, 0);
									ConstructionUI.PartDesc partDesc2 = new ConstructionUI.PartDesc();
									partDesc2.part = partDesc.part;
									partDesc2.maxCount = unlockedSandboxPartCount;
									partDesc2.customPartIndex = 0;
									this.m_unlockedParts.Add(partDesc2);
									partDesc.maxCount -= unlockedSandboxPartCount;
								}
								unlockedSandboxPartCount = GameProgress.GetUnlockedSandboxPartCount(Singleton<GameManager>.Instance.CurrentSceneName, component.m_partType);
								if (unlockedSandboxPartCount > 0)
								{
									GameProgress.SetUnlockedSandboxPartCount(Singleton<GameManager>.Instance.CurrentSceneName, component.m_partType, 0);
									ConstructionUI.PartDesc partDesc3 = new ConstructionUI.PartDesc();
									partDesc3.part = partDesc.part;
									partDesc3.maxCount = unlockedSandboxPartCount;
									partDesc3.customPartIndex = 0;
									this.m_unlockedParts.Add(partDesc3);
									partDesc.maxCount -= unlockedSandboxPartCount;
								}
							}
							this.m_partDescs.Add(partDesc);
							WPFMonoBehaviour.levelManager.m_totalAvailableParts += partTypeCount;
							num++;
							if (num >= this.m_itemsPerRow)
							{
								num = 0;
								num2++;
							}
							num3++;
						}
					}
				}
			}
		}
		if (WPFMonoBehaviour.levelManager)
		{
			this.m_contraption = WPFMonoBehaviour.levelManager.ContraptionProto;
		}
		if (!this.m_contraption)
		{
			this.m_contraption = new GameObject("Contraption")
			{
				transform = 
				{
					parent = base.transform,
					localPosition = Vector3.zero
				}
			}.AddComponent<Contraption>();
		}
		this.m_cellPrefab = ((!WPFMonoBehaviour.levelManager.GridCellPrefab) ? this.m_cellPrefab : WPFMonoBehaviour.levelManager.GridCellPrefab.transform);
		if (this.m_cellPrefab)
		{
			GameObject gameObject2 = new GameObject();
			gameObject2.transform.parent = base.transform;
			gameObject2.transform.localPosition = Vector3.zero;
			for (int i = 0; i < WPFMonoBehaviour.levelManager.GridHeight; i++)
			{
				for (int j = WPFMonoBehaviour.levelManager.GridXMin; j <= WPFMonoBehaviour.levelManager.GridXMax; j++)
				{
					if (WPFMonoBehaviour.levelManager.CanPlacePartAtGridCell(j, i))
					{
						Transform transform3 = UnityEngine.Object.Instantiate<Transform>(this.m_cellPrefab);
						transform3.transform.parent = gameObject2.transform;
						transform3.localPosition = new Vector3((float)j, (float)i, 1f);
						int key = i * 1000 + j;
						this.m_cellMap[key] = transform3;
					}
				}
			}
			this.m_grid = gameObject2.transform;
		}
		GameObject gameObject3 = GameObject.Find("InGameGUI");
		if (gameObject3)
		{
			this.clearButton = gameObject3.transform.Find("InGameBuildMenu").Find("ClearButton").gameObject;
			this.playButton = gameObject3.transform.Find("InGameBuildMenu").Find("PlayButton").gameObject;
			this.moveButtons = gameObject3.transform.Find("InGameBuildMenu").Find("MoveButtons").gameObject;
			this.moveLeftButton = this.moveButtons.transform.Find("MoveLeftButton").gameObject;
			this.moveRightButton = this.moveButtons.transform.Find("MoveRightButton").gameObject;
			this.moveUpButton = this.moveButtons.transform.Find("MoveUpButton").gameObject;
			this.moveDownButton = this.moveButtons.transform.Find("MoveDownButton").gameObject;
			this.partSelector = gameObject3.transform.Find("InGameBuildMenu").Find("PartSelector").GetComponent<PartSelector>();
			this.partSelector.SetParts(this.m_partDescs);
		}
	}

	public void SetCurrentContraption()
	{
		this.m_contraption = WPFMonoBehaviour.levelManager.ContraptionProto;
	}

	private void Update()
	{
		if (this.m_disableFunctionality)
		{
			return;
		}
		if (this.m_draggedElement != -1)
		{
			this.m_lastMoveTime = Time.time;
			if (this.m_dragIcon)
			{
				Vector3 vector = WPFMonoBehaviour.hudCamera.GetComponent<Camera>().ScreenToWorldPoint(GuiManager.GetPointer().position);
				vector.z = WPFMonoBehaviour.hudCamera.transform.position.z + 2f;
				vector += this.m_dragOffset;
				vector += this.m_dragIconOffset;
				this.m_dragIcon.transform.position = vector;
			}
		}
		this.SetButtonPositions();
		if (Input.touchCount > 1)
		{
			this.CancelDrag();
		}
		this.HandleDragging();
	}

	private void SetButtonPositions()
	{
		this.SetHudPositionFromRelativeLevelPosition(this.clearButton, new Vector3((float)WPFMonoBehaviour.levelManager.GridXMin - 1f, 0.5f * (float)(WPFMonoBehaviour.levelManager.GridHeight - 1), 0f), new Vector3(-1.2f, 0f, 0f));
		this.SetHudPositionFromRelativeLevelPosition(this.playButton, new Vector3((float)WPFMonoBehaviour.levelManager.GridXMax + 1f, 0.5f * (float)(WPFMonoBehaviour.levelManager.GridHeight - 1), 0f), new Vector3(1.2f, 0f, 0f));
	}

	public void CheckUnlockedParts()
	{
		List<ConstructionUI.PartDesc> list = new List<ConstructionUI.PartDesc>();
		List<ConstructionUI.PartDesc> list2 = new List<ConstructionUI.PartDesc>();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		foreach (Transform transform in this.m_parts)
		{
			Transform transform2 = UnityEngine.Object.Instantiate<Transform>(transform);
			BasePart component = transform2.GetComponent<BasePart>();
			transform2.gameObject.SetActive(false);
			int partTypeCount = WPFMonoBehaviour.levelManager.GetPartTypeCount(component.m_partType);
			if (partTypeCount == 0 && !this.m_purchasableParts.Contains(transform))
			{
				UnityEngine.Object.Destroy(transform2.gameObject);
			}
			else
			{
				transform2.parent = base.transform;
				MeshRenderer component2 = transform2.GetComponent<MeshRenderer>();
				if (transform2.GetComponent<BasePart>().m_constructionIconSprite)
				{
					component2 = transform2.GetComponent<BasePart>().m_constructionIconSprite.GetComponent<MeshRenderer>();
				}
				if (component2)
				{
					if (component2.sharedMaterial)
					{
						Texture mainTexture = component2.sharedMaterial.mainTexture;
						if (mainTexture)
						{
							ConstructionUI.PartDesc partDesc = new ConstructionUI.PartDesc();
							partDesc.part = component;
							partDesc.tex = mainTexture;
							partDesc.coordX = num;
							partDesc.coordY = num2;
							partDesc.useCount = WPFMonoBehaviour.levelManager.ContraptionProto.GetPartCount(component.m_partType);
							partDesc.maxCount = partTypeCount;
							partDesc.customPartIndex = 0;
							if (WPFMonoBehaviour.levelManager.m_sandbox)
							{
								int unlockedSandboxPartCount = GameProgress.GetUnlockedSandboxPartCount(component.m_partType);
								if (unlockedSandboxPartCount > 0)
								{
									GameProgress.SetUnlockedSandboxPartCount(component.m_partType, 0);
									list.Add(new ConstructionUI.PartDesc
									{
										part = partDesc.part,
										maxCount = unlockedSandboxPartCount,
										customPartIndex = 0
									});
									partDesc.maxCount -= unlockedSandboxPartCount;
								}
								if (unlockedSandboxPartCount > 0)
								{
									num4 += unlockedSandboxPartCount;
									WPFMonoBehaviour.levelManager.m_totalAvailableParts += unlockedSandboxPartCount;
								}
								unlockedSandboxPartCount = GameProgress.GetUnlockedSandboxPartCount(Singleton<GameManager>.Instance.CurrentSceneName, component.m_partType);
								if (unlockedSandboxPartCount > 0)
								{
									GameProgress.SetUnlockedSandboxPartCount(Singleton<GameManager>.Instance.CurrentSceneName, component.m_partType, 0);
									list.Add(new ConstructionUI.PartDesc
									{
										part = partDesc.part,
										maxCount = unlockedSandboxPartCount,
										customPartIndex = 0
									});
									partDesc.maxCount -= unlockedSandboxPartCount;
								}
								if (unlockedSandboxPartCount > 0)
								{
									num4 += unlockedSandboxPartCount;
									WPFMonoBehaviour.levelManager.m_totalAvailableParts += unlockedSandboxPartCount;
								}
								num++;
								if (num >= this.m_itemsPerRow)
								{
									num = 0;
									num2++;
								}
								num3++;
							}
							list2.Add(partDesc);
						}
					}
				}
			}
		}
		this.m_unlockedParts = list;
		if (num4 > 0)
		{
			this.m_partDescs = list2;
			this.RefreshButtons();
		}
		if (this.OnPartsUnlocked != null)
		{
			this.OnPartsUnlocked();
		}
	}

	public void RefreshButtons()
	{
		this.partSelector.SetParts(this.m_partDescs);
	}

	private void HandlePreviewSwipe()
	{
		if (this.m_draggedElement == -1)
		{
			GuiManager.Pointer pointer = GuiManager.GetPointer();
			if (pointer.down)
			{
				this.m_previewSwipeStarted = true;
				this.m_previewSwipeStartPosition = pointer.position;
			}
			if (pointer.up)
			{
				if (this.m_previewSwipeStarted)
				{
					float num = Vector3.Distance(this.m_previewSwipeStartPosition, pointer.position);
					num /= (float)Screen.width;
					if (num > 0.4f)
					{
						EventManager.Send<UIEvent>(new UIEvent(UIEvent.Type.Preview));
					}
				}
				this.m_previewSwipeStarted = false;
			}
		}
		else
		{
			this.m_previewSwipeStarted = false;
		}
	}

	private void HandleTutorialButton()
	{
		if (!this.m_tutorialPulseDone)
		{
			int tutorialBookOpenCount = GameProgress.GetTutorialBookOpenCount();
			if (tutorialBookOpenCount < 3)
			{
				if (Time.time - this.m_lastMoveTime > 7.5f * (float)tutorialBookOpenCount)
				{
					EventManager.Send<PulseButtonEvent>(new PulseButtonEvent(UIEvent.Type.OpenTutorial, true));
					this.m_tutorialPulseDone = true;
				}
			}
			else
			{
				this.m_tutorialPulseDone = true;
			}
		}
	}

	public Vector3 RelativeLevelPositionToHudPosition(Vector3 levelOffset)
	{
		Vector3 position = base.transform.position + levelOffset;
		Vector3 position2 = Camera.main.WorldToScreenPoint(position);
		return WPFMonoBehaviour.hudCamera.GetComponent<Camera>().ScreenToWorldPoint(position2);
	}

	private void SetHudPositionFromRelativeLevelPosition(GameObject obj, Vector3 levelOffset, Vector3 hudOffset)
	{
		Vector3 position = obj.transform.position;
		float z = position.z;
		Vector3 position2 = base.transform.position + levelOffset;
		Vector3 position3 = Camera.main.WorldToScreenPoint(position2);
		Vector3 vector = WPFMonoBehaviour.hudCamera.GetComponent<Camera>().ScreenToWorldPoint(position3);
		vector += hudOffset;
		vector.z = z;
		if (Vector3.SqrMagnitude(position - vector) > 1E-06f)
		{
			obj.transform.position = vector;
		}
	}

	private void ReceiveUIEvent(UIEvent data)
	{
		switch (data.type)
		{
		case UIEvent.Type.MoveContraptionLeft:
			this.MoveContraption(-1, 0);
			break;
		case UIEvent.Type.MoveContraptionRight:
			this.MoveContraption(1, 0);
			break;
		case UIEvent.Type.MoveContraptionUp:
			this.MoveContraption(0, 1);
			break;
		case UIEvent.Type.MoveContraptionDown:
			this.MoveContraption(0, -1);
			break;
		}
	}

	private void ContraptionPartChanged(int x, int y)
	{
		if (this.m_contraption.Parts.Count < 2)
		{
			this.SetMoveButtonStates();
			return;
		}
		if (x == WPFMonoBehaviour.levelManager.GridXMin)
		{
			this.SetMoveButtonState(-1, 0);
		}
		if (x == WPFMonoBehaviour.levelManager.GridXMax)
		{
			this.SetMoveButtonState(1, 0);
		}
		if (y == 0)
		{
			this.SetMoveButtonState(0, -1);
		}
		if (y == WPFMonoBehaviour.levelManager.GridHeight - 1)
		{
			this.SetMoveButtonState(0, 1);
		}
	}

	public void SetMoveButtonStates()
	{
		this.SetMoveButtonState(1, 0);
		this.SetMoveButtonState(-1, 0);
		this.SetMoveButtonState(0, 1);
		this.SetMoveButtonState(0, -1);
	}

	private void SetMoveButtonState(int dx, int dy)
	{
		bool enabled = this.m_contraption.CanMoveOnGrid(dx, dy);
		if (dx == -1)
		{
			this.moveLeftButton.GetComponent<Renderer>().enabled = enabled;
			this.moveLeftButton.GetComponent<Collider>().enabled = enabled;
		}
		else if (dx == 1)
		{
			this.moveRightButton.GetComponent<Renderer>().enabled = enabled;
			this.moveRightButton.GetComponent<Collider>().enabled = enabled;
		}
		else if (dy == 1)
		{
			this.moveUpButton.GetComponent<Renderer>().enabled = enabled;
			this.moveUpButton.GetComponent<Collider>().enabled = enabled;
		}
		else if (dy == -1)
		{
			this.moveDownButton.GetComponent<Renderer>().enabled = enabled;
			this.moveDownButton.GetComponent<Collider>().enabled = enabled;
		}
	}

	private void MoveContraption(int dx, int dy)
	{
		this.AddMove();
		this.m_contraption.MoveOnGrid(dx, dy);
		if (dx != 0)
		{
			this.SetMoveButtonState(1, 0);
			this.SetMoveButtonState(-1, 0);
		}
		if (dy != 0)
		{
			this.SetMoveButtonState(0, 1);
			this.SetMoveButtonState(0, -1);
		}
	}

	public void SelectPart(ConstructionUI.PartDesc partDesc)
	{
		this.m_selectedElement = -1;
		for (int i = 0; i < this.m_partDescs.Count; i++)
		{
			if (this.m_partDescs[i].part == partDesc.part)
			{
				this.m_selectedElement = i;
				break;
			}
		}
	}

	public void StartDrag(ConstructionUI.PartDesc partDesc)
	{
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Building)
		{
			int draggedElement = -1;
			for (int i = 0; i < this.m_partDescs.Count; i++)
			{
				if (this.m_partDescs[i] == partDesc)
				{
					if (this.m_partDescs[i].useCount < this.m_partDescs[i].maxCount)
					{
						this.m_partDescs[i].useCount++;
						EventManager.Send<PartCountChanged>(new PartCountChanged(partDesc.part.m_partType, this.m_partDescs[i].CurrentCount));
						draggedElement = i;
					}
					break;
				}
			}
			this.SetDraggedElement(draggedElement);
		}
	}

	public bool IsDragging()
	{
		return this.m_draggedElement != -1;
	}

	public void CancelDrag(ConstructionUI.PartDesc partDesc)
	{
		this.SetDraggedElement(-1);
	}

	public void CancelDrag()
	{
		if (this.m_draggedElement != -1)
		{
			if (this.m_draggingFromContraption)
			{
				ConstructionUI.PartDesc partDesc = this.m_partDescs[this.m_draggedElement];
				partDesc.useCount++;
				EventManager.Send<PartCountChanged>(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
				BasePart basePart = this.SetPartAt(this.m_contraptionDragX, this.m_contraptionDragY, partDesc.part, true);
				this.ContraptionPartChanged(this.m_contraptionDragX, this.m_contraptionDragY);
				EventManager.Send<PartPlacedEvent>(new PartPlacedEvent(partDesc.part.m_partType, partDesc.part.m_partTier, basePart.transform.position));
			}
			this.SetDraggedElement(-1);
		}
	}

	private void SetDraggedElement(int element)
	{
		this.SetDraggedElement(element, false, 0, 0);
	}

	private void SetDraggedElement(int element, bool fromContraption, int contraptionX, int contraptionY)
	{
		this.m_draggingFromContraption = fromContraption;
		this.m_contraptionDragX = contraptionX;
		this.m_contraptionDragY = contraptionY;
		this.m_dragStarted = false;
		if (this.m_useDragOffset)
		{
			if (fromContraption)
			{
				this.m_dragOffset = new Vector3(0f, 0.75f, 0f);
			}
			else
			{
				this.m_dragOffset = new Vector3(0f, 3f, 0f);
			}
		}
		if (this.m_draggedElement != -1)
		{
			ConstructionUI.PartDesc partDesc = this.m_partDescs[this.m_draggedElement];
			partDesc.useCount--;
			EventManager.Send<PartCountChanged>(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
		}
		this.m_draggedElement = element;
		if (element == -1)
		{
			if (this.m_dragIcon)
			{
				UnityEngine.Object.Destroy(this.m_dragIcon);
				this.m_dragIcon = null;
			}
		}
		else
		{
			if (this.m_dragIcon)
			{
				UnityEngine.Object.Destroy(this.m_dragIcon);
			}
			GameObject gameObject = null;
			BasePart basePart = null;
			if (this.m_draggingFromContraption)
			{
				basePart = WPFMonoBehaviour.gameData.GetCustomPart(this.m_partDescs[element].part.m_partType, this.m_draggedElementCustomizationIndex);
			}
			if (basePart != null)
			{
				gameObject = basePart.m_constructionIconSprite.gameObject;
			}
			if (gameObject == null)
			{
				gameObject = this.m_partDescs[element].part.m_constructionIconSprite.gameObject;
			}
			this.m_dragIcon = UnityEngine.Object.Instantiate<GameObject>(gameObject);
			float num = Vector3.Distance(this.GridPositionToGuiPosition(0, 0), this.GridPositionToGuiPosition(1, 0));
			ConstructionUI.SetSortingOrder(this.m_dragIcon, 0, "Popup");
			this.m_dragIcon.transform.localScale = new Vector3(num, num, num);
			EventManager.Send<DragStartedEvent>(new DragStartedEvent(this.m_partDescs[element].part.m_partType));
		}
	}

	public static void SetSortingOrder(GameObject target, int sortingOrder, string sortingLayer = "")
	{
		if (target == null)
		{
			return;
		}
		Renderer[] componentsInChildren = target.GetComponentsInChildren<Renderer>();
		if (componentsInChildren == null || componentsInChildren.Length == 0)
		{
			return;
		}
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!string.IsNullOrEmpty(sortingLayer))
			{
				componentsInChildren[i].sortingLayerName = sortingLayer;
			}
			componentsInChildren[i].sortingOrder = sortingOrder;
		}
	}

	private int FindPartIndex(BasePart part)
	{
		for (int i = 0; i < this.m_partDescs.Count; i++)
		{
			if (this.m_partDescs[i].part.m_partType == part.m_partType)
			{
				return i;
			}
		}
		return -1;
	}

	private void OnPartCustomization(CustomizePartUI.PartCustomizationEvent data)
	{
		ConstructionUI.PartDesc partDesc = this.FindPartDesc(data.customizedPart);
		if (partDesc != null)
		{
			EventManager.Send<PartCountChanged>(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
		}
	}

	private void OnPartListingClosed()
	{
		this.OnCustomPartListClosed(BasePart.PartType.Unknown);
	}

	private void HandleDragging()
	{
		if (WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.Building)
		{
			return;
		}
		GuiManager.Pointer pointer = GuiManager.GetPointer();
		int constructionUiRows = this.m_partDescs.Count / this.m_itemsPerRow + ((this.m_partDescs.Count % this.m_itemsPerRow != 0) ? 1 : 0);
		WPFMonoBehaviour.levelManager.m_constructionUiRows = constructionUiRows;
		if (pointer.down && !pointer.onWidget && this.m_draggedElement == -1 && !this.m_dragStarted)
		{
			Vector3 a = WPFMonoBehaviour.ScreenToZ0(pointer.position);
			Vector3 vector = a - base.transform.position;
			int x = Mathf.RoundToInt(vector.x);
			int y = Mathf.RoundToInt(vector.y);
			this.ChangeCoordinatesToSelectBigPart(ref x, ref y);
			BasePart basePart = this.m_contraption.FindPartAt(x, y);
			if (basePart)
			{
				if (basePart.enclosedPart)
				{
					basePart = basePart.enclosedPart;
				}
				if (!basePart.m_static)
				{
					this.m_dragStartPosition = pointer.position;
					this.m_dragStarted = true;
				}
			}
		}
		if (pointer.up)
		{
			if (this.m_dragStarted && this.m_draggedElement == -1)
			{
				Vector3 a2 = WPFMonoBehaviour.ScreenToZ0(this.m_dragStartPosition);
				Vector3 vector2 = a2 - base.transform.position;
				int x2 = Mathf.RoundToInt(vector2.x);
				int y2 = Mathf.RoundToInt(vector2.y);
				BasePart basePart2 = this.m_contraption.FindPartAt(x2, y2);
				if (basePart2)
				{
					if (basePart2.enclosedPart)
					{
						basePart2 = basePart2.enclosedPart;
					}
					bool flag = this.m_contraption.Flip(basePart2);
					if (flag)
					{
						this.AddMove();
						this.m_rotationCounter++;
						Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.rotatePart);
					}
				}
			}
			this.m_dragStarted = false;
		}
		float num = 1f;
		if (DeviceInfo.UsesTouchInput)
		{
			num = ((!this.m_useDragOffset) ? 10f : 20f);
		}
		if (this.m_dragStarted && this.m_draggedElement == -1 && Vector3.Distance(pointer.position, this.m_dragStartPosition) >= num)
		{
			Vector3 a3 = WPFMonoBehaviour.ScreenToZ0(this.m_dragStartPosition);
			Vector3 vector3 = a3 - base.transform.position;
			int num2 = Mathf.RoundToInt(vector3.x);
			int num3 = Mathf.RoundToInt(vector3.y);
			BasePart basePart3 = this.m_contraption.FindPartAt(num2, num3);
			if (!basePart3 || (basePart3.m_partType != BasePart.PartType.Rope && basePart3.m_partType != BasePart.PartType.Spring))
			{
				this.ChangeCoordinatesToSelectBigPart(ref num2, ref num3);
			}
			BasePart basePart4 = this.m_contraption.RemovePartAt(num2, num3);
			if (basePart4)
			{
				this.m_draggedElementCustomizationIndex = basePart4.customPartIndex;
				EventManager.Send<PartRemovedEvent>(new PartRemovedEvent(basePart4.m_partType, basePart4.transform.position));
				this.draggedPartRotation = basePart4.m_gridRotation;
				this.draggedPartFlipped = basePart4.m_flipped;
				for (int i = 0; i < this.m_partDescs.Count; i++)
				{
					if (this.m_partDescs[i].part.m_partType == basePart4.m_partType)
					{
						this.m_dragStartedFromContraption = true;
						this.SetDraggedElement(i, true, num2, num3);
						this.m_selectedElement = i;
						this.partSelector.SetSelection(this.m_partDescs[this.m_selectedElement]);
						break;
					}
				}
				UnityEngine.Object.Destroy(basePart4.gameObject);
				this.ContraptionPartChanged(num2, num3);
				this.PlayDragSound();
			}
		}
		if (this.m_draggedElement != -1)
		{
			ConstructionUI.PartDesc partDesc = this.m_partDescs[this.m_draggedElement];
			Vector3 position = WPFMonoBehaviour.hudCamera.GetComponent<Camera>().ScreenToWorldPoint(pointer.position) + this.m_dragOffset;
			Vector3 position2 = WPFMonoBehaviour.hudCamera.GetComponent<Camera>().WorldToScreenPoint(position);
			Vector3 vector4 = Camera.main.ScreenToWorldPoint(position2);
			EventManager.Send<DraggingPartEvent>(new DraggingPartEvent(partDesc.part.m_partType, vector4));
			Vector3 vector5 = vector4 - base.transform.position;
			int num4 = Mathf.RoundToInt(vector5.x);
			int num5 = Mathf.RoundToInt(vector5.y);
			if (this.m_useDragOffset)
			{
				int key = num5 * 1000 + num4;
				Transform transform;
				if (this.m_cellMap.TryGetValue(key, out transform))
				{
					if (this.m_mouseOverCell)
					{
						this.m_mouseOverCell.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
					}
					this.m_mouseOverCell = transform;
					transform.transform.localScale = new Vector3(0.33f, 0.33f, 0.33f);
				}
				else if (this.m_mouseOverCell)
				{
					this.m_mouseOverCell.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
				}
			}
			if (pointer.up)
			{
				partDesc.customPartIndex = this.m_draggedElementCustomizationIndex;
				this.AddMove();
				if (WPFMonoBehaviour.levelManager.CanPlacePartAtGridCell(num4, num5) && this.m_contraption.CanPlaceSpecificPartAt(num4, num5, partDesc.part))
				{
					partDesc.useCount++;
					EventManager.Send<PartCountChanged>(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
					BasePart basePart5 = partDesc.part;
					if (this.m_draggingFromContraption)
					{
						basePart5 = WPFMonoBehaviour.gameData.GetCustomPart(basePart5.m_partType, this.m_draggedElementCustomizationIndex);
					}
					BasePart basePart6 = this.SetPartAt(num4, num5, basePart5, true);
					this.ContraptionPartChanged(num4, num5);
					this.PlayPartPlacedSound();
					EventManager.Send<PartPlacedEvent>(new PartPlacedEvent(partDesc.part.m_partType, partDesc.part.m_partTier, basePart6.transform.position));
				}
				else
				{
					this.PlayRemoveSound();
				}
				this.SetDraggedElement(-1);
			}
		}
		else if (this.m_selectedElement != -1 && this.m_draggedElement == -1)
		{
			ConstructionUI.PartDesc partDesc2 = this.m_partDescs[this.m_selectedElement];
			Vector3 a4 = WPFMonoBehaviour.ScreenToZ0(pointer.position);
			Vector3 vector6 = a4 - base.transform.position;
			int num6 = Mathf.RoundToInt(vector6.x);
			int num7 = Mathf.RoundToInt(vector6.y);
			BasePart basePart7 = this.m_contraption.FindPartAt(num6, num7);
			if (!basePart7 && (pointer.down || (this.m_allowDragPlacement && pointer.dragging)) && partDesc2.useCount < partDesc2.maxCount)
			{
				bool flag2 = this.TryPlacePartAtGridCell(num6, num7, partDesc2);
				if (flag2)
				{
					this.AddMove();
				}
			}
			else if (basePart7 && basePart7.CanEncloseParts() && partDesc2.part.CanBeEnclosed() && pointer.up && (!basePart7.enclosedPart || partDesc2.part.m_partType != basePart7.enclosedPart.m_partType) && partDesc2.useCount < partDesc2.maxCount)
			{
				bool flag3 = this.TryPlacePartAtGridCell(num6, num7, partDesc2);
				if (flag3)
				{
					this.AddMove();
				}
			}
		}
		if (pointer.secondaryDown)
		{
			this.m_rightDragStartPosition = pointer.position;
		}
		if (this.m_draggedElement == -1 && (pointer.secondaryDown || (pointer.secondaryDragging && pointer.position != this.m_rightDragStartPosition && !pointer.dragging)))
		{
			Vector3 a5 = WPFMonoBehaviour.ScreenToZ0(pointer.position);
			Vector3 vector7 = a5 - base.transform.position;
			int x3 = Mathf.RoundToInt(vector7.x);
			int y3 = Mathf.RoundToInt(vector7.y);
			BasePart basePart8 = this.m_contraption.FindPartAt(x3, y3);
			if (basePart8 && basePart8.enclosedPart)
			{
				basePart8 = basePart8.enclosedPart;
			}
			if (basePart8 && !basePart8.m_static)
			{
				BasePart basePart9 = this.m_contraption.RemovePartAt(x3, y3);
				if (basePart9)
				{
					EventManager.Send<PartRemovedEvent>(new PartRemovedEvent(basePart9.m_partType, basePart9.transform.position));
					for (int j = 0; j < this.m_partDescs.Count; j++)
					{
						if (this.m_partDescs[j].part.m_partType == basePart9.m_partType)
						{
							ConstructionUI.PartDesc partDesc3 = this.m_partDescs[j];
							partDesc3.useCount--;
							EventManager.Send<PartCountChanged>(new PartCountChanged(partDesc3.part.m_partType, partDesc3.CurrentCount));
							this.AddMove();
							break;
						}
					}
					UnityEngine.Object.Destroy(basePart9.gameObject);
					this.ContraptionPartChanged(x3, y3);
				}
			}
		}
		if (this.m_draggedElement == -1 && this.m_mouseOverCell)
		{
			this.m_mouseOverCell.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			this.m_mouseOverCell = null;
		}
	}

	private void OnCustomPartListClosed(BasePart.PartType partType = BasePart.PartType.Unknown)
	{
		if (this.m_dragStartedFromContraption && partType != BasePart.PartType.Unknown && this.m_currentCustomizablePartType == partType)
		{
			ConstructionUI.PartDesc partDesc = this.FindPartDesc(partType);
			partDesc.useCount++;
			EventManager.Send<PartCountChanged>(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
			BasePart basePart = this.SetPartAt(this.m_dragStartedX, this.m_dragStartedY, partDesc.part, true);
			this.ContraptionPartChanged(this.m_dragStartedX, this.m_dragStartedY);
			EventManager.Send<PartPlacedEvent>(new PartPlacedEvent(partDesc.part.m_partType, partDesc.part.m_partTier, basePart.transform.position));
		}
		this.m_dragStartedFromContraption = false;
	}

	private void ChangeCoordinatesToSelectBigPart(ref int coordX, ref int coordY)
	{
		for (int i = -1; i <= 0; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				if (j != 0 || i != 0)
				{
					int num = coordX + j;
					int num2 = coordY + i;
					BasePart basePart = this.m_contraption.FindPartAt(num, num2);
					if (basePart)
					{
						if (basePart.enclosedPart)
						{
							basePart = basePart.enclosedPart;
						}
						if (num + basePart.m_gridXmin <= coordX && num + basePart.m_gridXmax >= coordX && num2 + basePart.m_gridYmin <= coordY && num2 + basePart.m_gridYmax >= coordY)
						{
							coordX = num;
							coordY = num2;
							return;
						}
					}
				}
			}
		}
	}

	private bool TryPlacePartAtGridCell(int coordX, int coordY, ConstructionUI.PartDesc partDesc)
	{
		if (WPFMonoBehaviour.levelManager.CanPlacePartAtGridCell(coordX, coordY) && this.m_contraption.CanPlaceSpecificPartAt(coordX, coordY, partDesc.part))
		{
			partDesc.useCount++;
			EventManager.Send<PartCountChanged>(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
			BasePart basePart = this.SetPartAt(coordX, coordY, partDesc.part, true);
			this.ContraptionPartChanged(coordX, coordY);
			this.PlayPartPlacedSound();
			EventManager.Send<PartPlacedEvent>(new PartPlacedEvent(basePart.m_partType, basePart.m_partTier, basePart.transform.position));
			return true;
		}
		return false;
	}

	private void ClearNonChassisPart(int coordX, int coordY)
	{
		BasePart basePart = this.m_contraption.FindPartAt(coordX, coordY);
		if (basePart && (!basePart.IsPartOfChassis() || basePart.enclosedPart))
		{
			basePart = this.m_contraption.RemovePartAt(coordX, coordY);
			for (int i = 0; i < this.m_partDescs.Count; i++)
			{
				if (this.m_partDescs[i].part.m_partType == basePart.m_partType)
				{
					ConstructionUI.PartDesc partDesc = this.m_partDescs[i];
					partDesc.useCount--;
					EventManager.Send<PartCountChanged>(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
					break;
				}
			}
			UnityEngine.Object.Destroy(basePart.gameObject);
			this.ContraptionPartChanged(coordX, coordY);
		}
	}

	public Vector3 GridPositionToGuiPosition(int x, int y)
	{
		Vector3 position = this.m_contraption.transform.position;
		Vector3 position2 = position + Vector3.right * (float)x + Vector3.up * (float)y;
		Vector3 position3 = Camera.main.WorldToScreenPoint(position2);
		return WPFMonoBehaviour.hudCamera.GetComponent<Camera>().ScreenToWorldPoint(position3);
	}

	public Vector3 GridPositionToWorldPosition(int x, int y)
	{
		Vector3 position = this.m_contraption.transform.position;
		return position + Vector3.right * (float)x + Vector3.up * (float)y;
	}

	private void ClearCollidingParts(int coordX, int coordY, BasePart part)
	{
		for (int i = part.m_gridYmin; i <= part.m_gridYmax; i++)
		{
			for (int j = part.m_gridXmin; j <= part.m_gridXmax; j++)
			{
				if (j != 0 || i != 0)
				{
					if (part.m_partType == BasePart.PartType.GoldenPig)
					{
						BasePart basePart = this.m_contraption.FindPartAt(coordX + j, coordY + i);
						if (basePart && (basePart.m_partType == BasePart.PartType.Rope || basePart.m_partType == BasePart.PartType.Spring))
						{
							goto IL_79;
						}
					}
					this.ClearNonChassisPart(coordX + j, coordY + i);
				}
				IL_79:;
			}
		}
		if (!part.IsPartOfChassis())
		{
			for (int k = -1; k <= 0; k++)
			{
				for (int l = -1; l <= 1; l++)
				{
					BasePart basePart2 = this.m_contraption.FindPartAt(coordX + l, coordY + k);
					if (basePart2)
					{
						if (basePart2.enclosedPart)
						{
							basePart2 = basePart2.enclosedPart;
						}
						if (basePart2.m_partType == BasePart.PartType.KingPig || basePart2.m_partType == BasePart.PartType.GoldenPig)
						{
							if ((part.m_partType != BasePart.PartType.Rope && part.m_partType != BasePart.PartType.Spring) || basePart2.m_partType != BasePart.PartType.GoldenPig)
							{
								this.ClearNonChassisPart(coordX + l, coordY + k);
							}
						}
					}
				}
			}
		}
	}

	public BasePart SetPartAt(int coordX, int coordY, BasePart part, bool autoalign = true)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(part.gameObject);
		gameObject.SetActive(true);
		BasePart component = gameObject.GetComponent<BasePart>();
		BasePart basePart = this.m_contraption.FindPartAt(coordX, coordY);
		if (component.m_partType == BasePart.PartType.Pig && basePart && basePart.m_partType == BasePart.PartType.WoodenFrame && Singleton<SocialGameManager>.IsInstantiated())
		{
			Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.THINK_INSIDE_THE_BOX", 100.0);
		}
		this.ClearCollidingParts(coordX, coordY, component);
		component.PrePlaced();
		BasePart basePart2 = this.m_contraption.SetPartAt(coordX, coordY, component, autoalign);
		if (autoalign)
		{
			this.m_contraption.AutoAlign(component);
		}
		if (basePart2)
		{
			EventManager.Send<PartRemovedEvent>(new PartRemovedEvent(basePart2.m_partType, basePart2.transform.position));
			this.CollectPart(basePart2);
		}
		return component;
	}

	protected void CollectPart(BasePart part)
	{
		if (!part)
		{
			return;
		}
		foreach (ConstructionUI.PartDesc partDesc in this.m_partDescs)
		{
			if (partDesc != null && partDesc.part != null && partDesc.part.m_partType == part.m_partType)
			{
				partDesc.useCount--;
				EventManager.Send<PartCountChanged>(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
			}
		}
		if (part.enclosedPart)
		{
			this.CollectPart(part.enclosedPart);
		}
		UnityEngine.Object.Destroy(part.gameObject);
	}

	public void SetEnabled(bool enableUI, bool enableGrid)
	{
		if (this.m_grid)
		{
			this.m_grid.gameObject.SetActive(enableGrid);
		}
		this.partSelector.SetConstructionUI(this);
		if (enableUI)
		{
			this.m_contraption.RefreshConnections();
		}
		base.gameObject.SetActive(enableUI || enableGrid);
		base.enabled = enableUI;
	}

	public void ClearContraption()
	{
		this.m_contraption.RemoveAllDynamicParts();
		foreach (ConstructionUI.PartDesc partDesc in this.m_partDescs)
		{
			partDesc.useCount = 0;
			EventManager.Send<PartCountChanged>(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
		}
		this.SetMoveButtonStates();
		this.m_moveCounter = 0;
	}

	public void ApplySuperGlue(bool apply)
	{
		this.m_contraption.ApplySuperGlue(Glue.Type.Regular);
	}

	public void ApplySuperMagnet(bool apply)
	{
		this.m_contraption.HasSuperMagnet = apply;
	}

	public void ApplyTurboCharge(bool apply)
	{
		this.m_contraption.HasTurboCharge = apply;
	}

	public void ApplyNightVision(bool apply)
	{
		this.m_contraption.HasNightVision = apply;
	}

	public void PlayPartPlacedSound()
	{
		if (Singleton<AudioManager>.IsInstantiated())
		{
			Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.placePart);
		}
	}

	public void PlayDragSound()
	{
		if (WPFMonoBehaviour.gameData.commonAudioCollection.dragPart != null && Singleton<AudioManager>.IsInstantiated())
		{
			Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.dragPart);
		}
	}

	public void PlayRemoveSound()
	{
		if (Singleton<AudioManager>.IsInstantiated())
		{
			Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.removePart);
		}
	}

	public Action OnPartsUnlocked;

	public List<Transform> m_purchasableParts = new List<Transform>();

	public Transform m_gridPrefab;

	public Transform m_cellPrefab;

	public int m_itemsPerRow = 14;

	public float m_offsetX = 0.2f;

	public float m_offsetY = 0.2f;

	public float m_spacingX = 0.06f;

	public float m_scale = 0.1f;

	public Texture2D m_cellTextureValid;

	public Texture2D m_cellTextureInvalid;

	public Texture2D m_textureSelected;

	protected Transform m_grid;

	protected Dictionary<int, Transform> m_cellMap = new Dictionary<int, Transform>();

	protected List<Transform> m_partInstances = new List<Transform>();

	protected List<ConstructionUI.PartDesc> m_partDescs = new List<ConstructionUI.PartDesc>();

	protected List<ConstructionUI.PartDesc> m_purchasablePartDescs = new List<ConstructionUI.PartDesc>();

	protected List<ConstructionUI.PartDesc> m_unlockedParts = new List<ConstructionUI.PartDesc>();

	protected Contraption m_contraption;

	protected int m_draggedElement = -1;

	protected int m_draggedElementCustomizationIndex;

	protected bool m_draggingFromContraption;

	private bool m_dragStartedFromContraption;

	protected int m_contraptionDragX;

	protected int m_contraptionDragY;

	private int m_dragStartedX;

	private int m_dragStartedY;

	protected int m_flipCount;

	protected int m_selectedElement = -1;

	protected BasePart.GridRotation draggedPartRotation;

	protected bool draggedPartFlipped;

	protected GUIStyle m_textStyle;

	private GameObject clearButton;

	private GameObject playButton;

	private GameObject moveButtons;

	private GameObject moveLeftButton;

	private GameObject moveRightButton;

	private GameObject moveUpButton;

	private GameObject moveDownButton;

	private List<Transform> m_parts = new List<Transform>();

	private PartSelector partSelector;

	private GameObject m_dragIcon;

	private bool m_useDragOffset = true;

	private Vector3 m_dragOffset;

	private Vector3 m_dragIconOffset = Vector3.zero;

	private Transform m_mouseOverCell;

	private bool m_dragStarted;

	private Vector3 m_dragStartPosition;

	private Vector3 m_rightDragStartPosition;

	private int m_moveCounter;

	private int m_rotationCounter;

	private float m_lastMoveTime;

	private bool m_tutorialPulseDone;

	private bool m_previewSwipeStarted;

	private Vector3 m_previewSwipeStartPosition;

	private bool m_allowDragPlacement;

	private bool m_disableFunctionality;

	private BasePart.PartType m_currentCustomizablePartType;

	public class PartDesc
	{
		public int CurrentCount
		{
			get
			{
				return this.maxCount - this.useCount;
			}
		}

		public BasePart part;

		public Texture tex;

		public int coordX;

		public int coordY;

		public int useCount;

		public int maxCount;

		public int sortKey;

		public int customPartIndex;

		public Transform currentPartIcon;
	}
}
