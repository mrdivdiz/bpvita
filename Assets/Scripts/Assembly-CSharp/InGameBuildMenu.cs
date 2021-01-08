using System;
using UnityEngine;

public class InGameBuildMenu : WPFMonoBehaviour
{
	public GameObject SuperBuildSelection
	{
		get
		{
			return this.superBuildSelection;
		}
	}

	public GameObject AutoBuildButton
	{
		get
		{
			return this.autoBuildButton;
		}
	}

	public GameObject TutorialButton
	{
		get
		{
			return this.tutorialButton;
		}
	}

	public GameObject PlayButton
	{
		get
		{
			return this.playButton;
		}
	}

	public PowerupButton NightVisionButton
	{
		get
		{
			return this.nightVisionButton;
		}
	}

	public PowerupButton SuperBluePrintButton
	{
		get
		{
			return this.superBluePrintButton;
		}
	}

	public PowerupButton TurboChargeButton
	{
		get
		{
			return this.turboChargeButton;
		}
	}

	public PowerupButton SuperMagnetButton
	{
		get
		{
			return this.superMagnetButton;
		}
	}

	public PowerupButton SuperGlueButton
	{
		get
		{
			return this.superGlueButton;
		}
	}

	public ToolboxButton ToolboxButton
	{
		get
		{
			return this.toolboxButton;
		}
	}

	public PartSelector PartSelector
	{
		get
		{
			return this.partSelector;
		}
	}

	public PigMechanic PigMechanic
	{
		get
		{
			return this.pigMechanic;
		}
	}

	private void Awake()
	{
		EventManager.Connect<UIEvent>(new EventManager.OnEvent<UIEvent>(this.OnUpsellDialogChanged));
		EventManager.Connect<PartPlacedEvent>(new EventManager.OnEvent<PartPlacedEvent>(this.OnPartPlaced));
		EventManager.Connect<PartRemovedEvent>(new EventManager.OnEvent<PartRemovedEvent>(this.OnPartRemoved));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect<UIEvent>(new EventManager.OnEvent<UIEvent>(this.OnUpsellDialogChanged));
		EventManager.Disconnect<PartPlacedEvent>(new EventManager.OnEvent<PartPlacedEvent>(this.OnPartPlaced));
		EventManager.Disconnect<PartRemovedEvent>(new EventManager.OnEvent<PartRemovedEvent>(this.OnPartRemoved));
	}

	private void OnPartRemoved(PartRemovedEvent data)
	{
		if (data.partType == BasePart.PartType.Egg && !WPFMonoBehaviour.levelManager.CurrentGameMode.ContraptionProto.HasPart(BasePart.PartType.Egg, BasePart.PartTier.Legendary) && WPFMonoBehaviour.levelManager.CurrentGameMode.ContraptionProto.HasAlienGlue)
		{
			WPFMonoBehaviour.levelManager.CurrentGameMode.ContraptionProto.RemoveSuperGlue();
		}
	}

	private void OnPartPlaced(PartPlacedEvent data)
	{
		if (data.partType == BasePart.PartType.Egg && data.partTier == BasePart.PartTier.Legendary && !WPFMonoBehaviour.levelManager.CurrentGameMode.ContraptionProto.HasSuperGlue)
		{
			WPFMonoBehaviour.levelManager.CurrentGameMode.ContraptionProto.ApplySuperGlue(Glue.Type.Alien);
		}
	}

	private void OnUpsellDialogChanged(UIEvent data)
	{
		if (data.type == UIEvent.Type.OpenUnlockFullVersionIapMenu)
		{
			base.gameObject.SetActive(false);
		}
		else if (data.type == UIEvent.Type.CloseUnlockFullVersionIapMenu && WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.Completed)
		{
			base.gameObject.SetActive(true);
		}
	}

	private void Start()
	{
		if (WPFMonoBehaviour.levelManager)
		{
			this.superGlueButton.SetAvailable(WPFMonoBehaviour.levelManager.SuperGlueAllowed);
			this.superMagnetButton.SetAvailable(WPFMonoBehaviour.levelManager.SuperMagnetAllowed);
			this.turboChargeButton.SetAvailable(WPFMonoBehaviour.levelManager.TurboChargeAllowed);
			this.superBluePrintButton.SetAvailable(WPFMonoBehaviour.levelManager.SuperBluePrintsAllowed);
			this.nightVisionButton.SetAvailable(WPFMonoBehaviour.levelManager.m_darkLevel);
		}
	}

	private void SetButtonAmountText(PowerupButton powerupButton, int amount)
	{
		string text = (amount != 0 || !Singleton<IapManager>.IsInstantiated()) ? amount.ToString() : string.Empty;
		powerupButton.SetText(text);
	}

	private Transform FindRecursively(Transform root, string name)
	{
		Transform transform = root.Find(name);
		if (transform)
		{
			return transform;
		}
		int childCount = root.childCount;
		for (int i = 0; i < childCount; i++)
		{
			transform = this.FindRecursively(root.GetChild(i), name);
			if (transform)
			{
				return transform;
			}
		}
		return null;
	}

	private void OnEnable()
	{
		this.cakeRaceMode = (WPFMonoBehaviour.levelManager.CurrentGameMode as CakeRaceMode);
		if (WPFMonoBehaviour.levelManager.CurrentGameMode.ContraptionProto.HasPart(BasePart.PartType.Egg, BasePart.PartTier.Legendary))
		{
			WPFMonoBehaviour.levelManager.CurrentGameMode.ContraptionProto.ApplySuperGlue(Glue.Type.Alien);
		}
		if (DeviceInfo.ActiveDeviceFamily == DeviceInfo.DeviceFamily.Ios)
		{
			IapManager.onPurchaseSucceeded += this.HandleIapManageronPurchaseSucceeded;
		}
		this.SetButtonAmountText(this.superBluePrintButton, GameProgress.BluePrintCount());
		this.SetButtonAmountText(this.superGlueButton, GameProgress.SuperGlueCount());
		this.SetButtonAmountText(this.superMagnetButton, GameProgress.SuperMagnetCount());
		this.SetButtonAmountText(this.turboChargeButton, GameProgress.TurboChargeCount());
		this.SetButtonAmountText(this.nightVisionButton, GameProgress.NightVisionCount());
		if (WPFMonoBehaviour.levelManager && WPFMonoBehaviour.levelManager.ContraptionProto)
		{
			this.superGlueButton.SetUsedState(WPFMonoBehaviour.levelManager.ContraptionProto.HasRegularGlue);
			this.superMagnetButton.SetUsedState(WPFMonoBehaviour.levelManager.ContraptionProto.HasSuperMagnet);
			this.turboChargeButton.SetUsedState(WPFMonoBehaviour.levelManager.ContraptionProto.HasTurboCharge);
			this.nightVisionButton.SetUsedState(WPFMonoBehaviour.levelManager.ContraptionProto.HasNightVision);
		}
		else
		{
			this.superGlueButton.SetUsedState(false);
			this.superMagnetButton.SetUsedState(false);
			this.turboChargeButton.SetUsedState(false);
			this.nightVisionButton.SetUsedState(false);
		}
		bool @bool = GameProgress.GetBool(Singleton<GameManager>.Instance.CurrentSceneName + "_autobuild_available", false, GameProgress.Location.Local, null);
		this.superBluePrintButton.SetUsedState(@bool);
		this.SetSuperAutoBuildAvailable(@bool);
		EventManager.Connect<InGameBuildMenu.AutoBuildEvent>(new EventManager.OnEvent<InGameBuildMenu.AutoBuildEvent>(this.SetSuperAutoBuildButtonAmount));
		EventManager.Connect<InGameBuildMenu.ApplySuperGlueEvent>(new EventManager.OnEvent<InGameBuildMenu.ApplySuperGlueEvent>(this.SetSuperGlueButtonAmount));
		EventManager.Connect<InGameBuildMenu.ApplySuperMagnetEvent>(new EventManager.OnEvent<InGameBuildMenu.ApplySuperMagnetEvent>(this.SetSuperMagnetButtonAmount));
		EventManager.Connect<InGameBuildMenu.ApplyTurboChargeEvent>(new EventManager.OnEvent<InGameBuildMenu.ApplyTurboChargeEvent>(this.SetTurboChargeButtonAmount));
		EventManager.Connect<InGameBuildMenu.ApplyNightVisionEvent>(new EventManager.OnEvent<InGameBuildMenu.ApplyNightVisionEvent>(this.SetNightVisionButtonAmount));
		OnPurchaseSucceeded component = this.superGlueButton.GetComponent<OnPurchaseSucceeded>();
		if (component != null)
		{
			component.buildMenu = this;
		}
		component = this.superMagnetButton.GetComponent<OnPurchaseSucceeded>();
		if (component != null)
		{
			component.buildMenu = this;
		}
		component = this.turboChargeButton.GetComponent<OnPurchaseSucceeded>();
		if (component != null)
		{
			component.buildMenu = this;
		}
		component = this.nightVisionButton.GetComponent<OnPurchaseSucceeded>();
		if (component != null)
		{
			component.buildMenu = this;
		}
		component = this.superBluePrintButton.GetComponent<OnPurchaseSucceeded>();
		if (component != null)
		{
			component.buildMenu = this;
		}
		if (this.editorButtons)
		{
			this.editorButtons.SetActive(false);
		}
	}

	private void OnDisable()
	{
		if (DeviceInfo.ActiveDeviceFamily == DeviceInfo.DeviceFamily.Ios)
		{
			IapManager.onPurchaseSucceeded -= this.HandleIapManageronPurchaseSucceeded;
		}
		EventManager.Disconnect<InGameBuildMenu.AutoBuildEvent>(new EventManager.OnEvent<InGameBuildMenu.AutoBuildEvent>(this.SetSuperAutoBuildButtonAmount));
		EventManager.Disconnect<InGameBuildMenu.ApplySuperGlueEvent>(new EventManager.OnEvent<InGameBuildMenu.ApplySuperGlueEvent>(this.SetSuperGlueButtonAmount));
		EventManager.Disconnect<InGameBuildMenu.ApplySuperMagnetEvent>(new EventManager.OnEvent<InGameBuildMenu.ApplySuperMagnetEvent>(this.SetSuperMagnetButtonAmount));
		EventManager.Disconnect<InGameBuildMenu.ApplyTurboChargeEvent>(new EventManager.OnEvent<InGameBuildMenu.ApplyTurboChargeEvent>(this.SetTurboChargeButtonAmount));
		EventManager.Disconnect<InGameBuildMenu.ApplyNightVisionEvent>(new EventManager.OnEvent<InGameBuildMenu.ApplyNightVisionEvent>(this.SetNightVisionButtonAmount));
	}

	public void SetSuperAutoBuildAvailable(bool available)
	{
		if (available)
		{
			this.autoBuildButton.gameObject.SetActive(false);
			this.superBuildSelection.gameObject.SetActive(true);
		}
	}

	public void RefreshPowerUpCounts()
	{
		this.SetSuperAutoBuildButtonAmount(new InGameBuildMenu.AutoBuildEvent(GameProgress.BluePrintCount(), false));
		this.SetSuperGlueButtonAmount(new InGameBuildMenu.ApplySuperGlueEvent(GameProgress.SuperGlueCount(), false));
		this.SetSuperMagnetButtonAmount(new InGameBuildMenu.ApplySuperMagnetEvent(GameProgress.SuperMagnetCount(), false));
		this.SetTurboChargeButtonAmount(new InGameBuildMenu.ApplyTurboChargeEvent(GameProgress.TurboChargeCount(), false));
		this.SetNightVisionButtonAmount(new InGameBuildMenu.ApplyNightVisionEvent(GameProgress.NightVisionCount(), false));
	}

	private void SetSuperAutoBuildButtonAmount(InGameBuildMenu.AutoBuildEvent eventData)
	{
		this.SetButtonAmountText(this.superBluePrintButton, eventData.availableBlueprints);
		this.superBluePrintButton.SetUsedState(eventData.usedState);
	}

	private void SetSuperGlueButtonAmount(InGameBuildMenu.ApplySuperGlueEvent eventData)
	{
		this.SetButtonAmountText(this.superGlueButton, eventData.availableSuperGlue);
		this.superGlueButton.SetUsedState(eventData.usedState);
	}

	private void SetSuperMagnetButtonAmount(InGameBuildMenu.ApplySuperMagnetEvent eventData)
	{
		this.SetButtonAmountText(this.superMagnetButton, eventData.availableSuperMagnet);
		this.superMagnetButton.SetUsedState(eventData.usedState);
	}

	private void SetTurboChargeButtonAmount(InGameBuildMenu.ApplyTurboChargeEvent eventData)
	{
		this.SetButtonAmountText(this.turboChargeButton, eventData.availableTurboCharge);
		this.turboChargeButton.SetUsedState(eventData.usedState);
	}

	private void SetNightVisionButtonAmount(InGameBuildMenu.ApplyNightVisionEvent eventData)
	{
		this.SetButtonAmountText(this.nightVisionButton, eventData.availableNightVision);
		this.nightVisionButton.SetUsedState(eventData.usedState);
	}

	private void HandleIapManageronPurchaseSucceeded(IapManager.InAppPurchaseItemType type)
	{
		this.autoBuildButton.transform.Find("AmountText").GetComponent<TextMesh>().text = GameProgress.BluePrintCount().ToString();
	}

	private void SetTrackIndex()
	{
	}

	public void NextTrack()
	{
	}

	public void PreviousTrack()
	{
	}

	[SerializeField]
	private PartSelector partSelector;

	[SerializeField]
	private PowerupButton superGlueButton;

	[SerializeField]
	private PowerupButton superMagnetButton;

	[SerializeField]
	private PowerupButton turboChargeButton;

	[SerializeField]
	private PowerupButton superBluePrintButton;

	[SerializeField]
	private PowerupButton nightVisionButton;

	[SerializeField]
	private ToolboxButton toolboxButton;

	[SerializeField]
	private PigMechanic pigMechanic;

	[SerializeField]
	private GameObject tutorialButton;

	[SerializeField]
	private GameObject autoBuildButton;

	[SerializeField]
	private GameObject superBuildSelection;

	[SerializeField]
	private GameObject playButton;

	[SerializeField]
	private GameObject editorButtons;

	[SerializeField]
	private TextMesh[] trackLabel;

	private CakeRaceMode cakeRaceMode;

	public struct AutoBuildEvent : EventManager.Event
	{
		public AutoBuildEvent(int availableBlueprints, bool usedState)
		{
			this.availableBlueprints = availableBlueprints;
			this.usedState = usedState;
		}

		public int availableBlueprints;

		public bool usedState;
	}

	public struct ApplySuperGlueEvent : EventManager.Event
	{
		public ApplySuperGlueEvent(int availableSuperGlue, bool usedState)
		{
			this.availableSuperGlue = availableSuperGlue;
			this.usedState = usedState;
		}

		public int availableSuperGlue;

		public bool usedState;
	}

	public struct ApplySuperMagnetEvent : EventManager.Event
	{
		public ApplySuperMagnetEvent(int availableSuperMagnet, bool usedState)
		{
			this.availableSuperMagnet = availableSuperMagnet;
			this.usedState = usedState;
		}

		public int availableSuperMagnet;

		public bool usedState;
	}

	public struct ApplyTurboChargeEvent : EventManager.Event
	{
		public ApplyTurboChargeEvent(int availableTurboCharge, bool usedState)
		{
			this.availableTurboCharge = availableTurboCharge;
			this.usedState = usedState;
		}

		public int availableTurboCharge;

		public bool usedState;
	}

	public struct ApplyNightVisionEvent : EventManager.Event
	{
		public ApplyNightVisionEvent(int availableNightVision, bool usedState)
		{
			this.availableNightVision = availableNightVision;
			this.usedState = usedState;
		}

		public int availableNightVision;

		public bool usedState;
	}
}
