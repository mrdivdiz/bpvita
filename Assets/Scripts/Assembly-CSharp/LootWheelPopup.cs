using System.Collections.Generic;
using UnityEngine;

public class LootWheelPopup : TextDialog
{
	public bool SpinButtonEnabled
	{
		get
		{
			return this.enabledSpinButton.activeSelf;
		}
		set
		{
			this.enabledSpinButton.SetActive(value);
			this.disabledSpinButton.SetActive(!value);
		}
	}

	public string SpinButtonText
	{
		set
		{
			TextMesh[] componentsInChildren = this.enabledSpinButton.transform.parent.GetComponentsInChildren<TextMesh>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].text = value;
				TextMeshSpriteIcons.EnsureSpriteIcon(componentsInChildren[i]);
			}
		}
	}

	public bool DoneButtonEnabled
	{
		get
		{
			return this.enabledDoneButton.activeSelf;
		}
		set
		{
			this.enabledDoneButton.SetActive(value);
			this.disabledDoneButton.SetActive(!value);
		}
	}

	public bool DoneButtonHidden
	{
		get
		{
			return this.enabledDoneButton.activeSelf && this.disabledDoneButton.activeSelf;
		}
		set
		{
			this.enabledDoneButton.SetActive(!value);
			this.disabledDoneButton.SetActive(!value);
		}
	}

	public new static bool DialogOpen
	{
		get
		{
			return !(LootWheelPopup.s_instance == null) && LootWheelPopup.s_instance.IsOpen;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (LootWheelPopup.s_instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		this.rendererMaterialPair = new Dictionary<MeshRenderer, Material[]>();
		MeshRenderer[] componentsInChildren = this.enabledSpinButton.transform.parent.GetComponentsInChildren<MeshRenderer>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			this.rendererMaterialPair.Add(componentsInChildren[i], componentsInChildren[i].sharedMaterials);
		}
		EventManager.Connect(new EventManager.OnEvent<LevelUpEvent>(this.OnLevelUpEvent));
		UnityEngine.Object.DontDestroyOnLoad(this);
		LootWheelPopup.s_instance = this;
	}

	protected override void Start()
	{
		base.Start();
		this.Close();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		this.scrapWasVsibile = ResourceBar.Instance.IsItemActive(ResourceBar.Item.Scrap);
		if (this.scrapWasVsibile)
		{
			ResourceBar.Instance.ShowItem(ResourceBar.Item.Scrap, false, true);
		}
		EventManager.Send(new UIEvent(UIEvent.Type.OpenedLootWheel));
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		if (this.scrapWasVsibile)
		{
			ResourceBar.Instance.ShowItem(ResourceBar.Item.Scrap, true, true);
		}
		EventManager.Send(new UIEvent(UIEvent.Type.ClosedLootWheel));
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<LevelUpEvent>(this.OnLevelUpEvent));
	}

	private void OnLevelUpEvent(LevelUpEvent data)
	{
		this.Open();
	}

	public override void Open()
	{
		base.Open();
		base.transform.position = WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 6f;
		this.lootWheel.ForceReInit();
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.jokerLevelUnlocked);
	}

	public void RefreshSpinButtonTranslation()
	{
		TextMeshLocale[] componentsInChildren = this.enabledSpinButton.transform.parent.GetComponentsInChildren<TextMeshLocale>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].RefreshTranslation(null);
		}
	}

	public void ResetSpinButtonTextMaterials()
	{
		if (this.rendererMaterialPair == null)
		{
			return;
		}
		foreach (KeyValuePair<MeshRenderer, Material[]> keyValuePair in this.rendererMaterialPair)
		{
			keyValuePair.Key.sharedMaterials = keyValuePair.Value;
		}
	}

	private static LootWheelPopup s_instance;

	private Dictionary<MeshRenderer, Material[]> rendererMaterialPair;

	[SerializeField]
	private LootWheel lootWheel;

	[SerializeField]
	private GameObject enabledDoneButton;

	[SerializeField]
	private GameObject disabledDoneButton;

	[SerializeField]
	private GameObject enabledSpinButton;

	[SerializeField]
	private GameObject disabledSpinButton;

	private bool coinsWasVisible;

	private bool scrapWasVsibile;
}
