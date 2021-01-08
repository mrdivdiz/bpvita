using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomizePartWidget : Widget
{
	private void Start()
	{
		this.constructionUI = UnityEngine.Object.FindObjectOfType<ConstructionUI>();
		EventManager.Connect(new EventManager.OnEvent<PartSelectedEvent>(this.OnPartSelected));
		EventManager.Connect(new EventManager.OnEvent<LootCrateOpenDialog.LootCrateDelivered>(this.OnLootCrateDelivered));
		this.CreatePartListing();
		this.UpdateNewTagState();
		if (this.constructionUI != null)
		{
			ConstructionUI constructionUI = this.constructionUI;
			constructionUI.OnPartsUnlocked = (Action)Delegate.Combine(constructionUI.OnPartsUnlocked, new Action(this.OnPartsUnlocked));
		}
	}

	private void OnDestroy()
	{
		if (this.constructionUI != null)
		{
			ConstructionUI constructionUI = this.constructionUI;
			constructionUI.OnPartsUnlocked = (Action)Delegate.Remove(constructionUI.OnPartsUnlocked, new Action(this.OnPartsUnlocked));
		}
		EventManager.Disconnect(new EventManager.OnEvent<PartSelectedEvent>(this.OnPartSelected));
		EventManager.Disconnect(new EventManager.OnEvent<LootCrateOpenDialog.LootCrateDelivered>(this.OnLootCrateDelivered));
	}

	private void OnPartsUnlocked()
	{
		this.CreatePartScope(UnityEngine.Object.FindObjectOfType<LevelManager>());
		this.partListing.SetPartScope(this.scope);
	}

	private void OnPartSelected(PartSelectedEvent evnt)
	{
		this.centerPart = evnt.type;
	}

	private void OnLootCrateDelivered(LootCrateOpenDialog.LootCrateDelivered data)
	{
		this.UpdateNewTagState();
	}

	public void OpenCustomizationForPart(BasePart part, Action<BasePart.PartType> onClose = null)
	{
		this.onPartListClose = onClose;
		if (part)
		{
			this.centerPart = part.m_partType;
		}
		this.OpenPartList();
	}

	public void ClosePastList()
	{
		this.onPartListClose = null;
		if (this.closeButton != null)
		{
			this.closeButton.Activate();
		}
	}

	public void OpenPartList()
	{
		if (this.constructionUI != null)
		{
			this.constructionUI.SetEnabled(false, false);
		}
		if (this.partListing == null)
		{
			this.CreatePartListing();
		}
		LevelManager levelManager = UnityEngine.Object.FindObjectOfType<LevelManager>();
		LevelManager.GameState previousState = LevelManager.GameState.Building;
		if (levelManager != null)
		{
			previousState = levelManager.gameState;
			levelManager.SetGameState(LevelManager.GameState.CustomizingPart);
		}
		this.partListing.CenterOnPart(this.centerPart);
		this.partListing.Open(delegate
		{
			if (this.constructionUI != null)
			{
				this.constructionUI.SetEnabled(true, true);
				levelManager.SetGameState(previousState);
			}
			this.UpdateNewTagState();
		});
		if (this.customizeMenu == null)
		{
			this.customizeMenu = base.gameObject.AddComponent<CustomizePartUI>();
		}
		this.customizeMenu.customPartWidget = this;
		this.customizeMenu.InitButtons(this.partListing, this.onPartListClose);
		this.centerPart = BasePart.PartType.Unknown;
	}

	private void CreatePartListing()
	{
		if (this.partListing != null)
		{
			return;
		}
		this.partListing = PartListing.Create();
		this.partListing.transform.parent = base.transform.parent.parent;
		this.partListing.Close();
		if (this.scope == null)
		{
			this.CreatePartScope(UnityEngine.Object.FindObjectOfType<LevelManager>());
		}
		this.partListing.SetPartScope(this.scope);
	}

	private void CreatePartScope(LevelManager levelManager)
	{
		if (levelManager == null)
		{
			return;
		}
		this.scope = new List<BasePart.PartType>();
		for (int i = 0; i < levelManager.ConstructionUI.PartDescriptors.Count; i++)
		{
			this.scope.Add(levelManager.ConstructionUI.PartDescriptors[i].part.m_partType);
		}
		for (int j = 0; j < levelManager.ConstructionUI.UnlockedParts.Count; j++)
		{
			if (!this.scope.Contains(levelManager.ConstructionUI.UnlockedParts[j].part.m_partType))
			{
				this.scope.Add(levelManager.ConstructionUI.UnlockedParts[j].part.m_partType);
			}
		}
	}

	private bool IsRaceLevelUnlocked(BasePart.PartType type)
	{
		int num = GameProgress.GetAllStars() + GameProgress.GetRaceLevelUnlockedStars();
		string currentLevelIdentifier = Singleton<GameManager>.Instance.CurrentLevelIdentifier;
		RaceLevels.LevelUnlockablePartsData levelUnlockableData = WPFMonoBehaviour.gameData.m_raceLevels.GetLevelUnlockableData(currentLevelIdentifier);
		foreach (RaceLevels.UnlockableTier unlockableTier in levelUnlockableData.m_tiers)
		{
			if (unlockableTier.m_part == type)
			{
				return num >= unlockableTier.m_starLimit;
			}
		}
		return true;
	}

	public void UpdateNewTagState()
	{
		this.newTag.SetActive(this.NewPartsInScope());
	}

	private bool NewPartsInScope()
	{
		if (this.scope == null)
		{
			return CustomizationManager.HasNewParts();
		}
		for (int i = 0; i < this.scope.Count; i++)
		{
			List<BasePart> customParts = CustomizationManager.GetCustomParts(this.scope[i], false);
			for (int j = 0; j < customParts.Count; j++)
			{
				if (CustomizationManager.IsPartNew(customParts[j]))
				{
					return true;
				}
			}
		}
		return false;
	}

	[HideInInspector]
	public Button closeButton;

	[SerializeField]
	private GameObject newTag;

	private PartListing partListing;

	private ConstructionUI constructionUI;

	private CustomizePartUI customizeMenu;

	private BasePart.PartType centerPart;

	private List<BasePart.PartType> scope;

	private Action<BasePart.PartType> onPartListClose;
}
