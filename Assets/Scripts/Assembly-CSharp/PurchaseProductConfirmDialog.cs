using UnityEngine;

public class PurchaseProductConfirmDialog : TextDialog
{
	public string ItemSpriteID
	{
		get
		{
			return this.itemSpriteID;
		}
		set
		{
			this.itemSpriteID = value;
		}
	}

	public string EffectSpriteID
	{
		get
		{
			return this.effectSpriteID;
		}
		set
		{
			this.effectSpriteID = value;
		}
	}

	public string ItemLocalizationKey
	{
		get
		{
			return this.itemLocalizationKey;
		}
		set
		{
			this.itemLocalizationKey = value;
		}
	}

	public string ItemDescriptionKey
	{
		get
		{
			return this.itemDescriptionKey;
		}
		set
		{
			this.itemDescriptionKey = value;
		}
	}

	public int ItemCount
	{
		get
		{
			return this.itemCount;
		}
		set
		{
			this.itemCount = value;
		}
	}

	public int Cost
	{
		get
		{
			return this.cost;
		}
		set
		{
			this.cost = value;
		}
	}

	protected override void Awake()
	{
		this.defaultScale = new Vector2(this.itemIcon.m_scaleX, this.itemIcon.m_scaleY);
		if (WPFMonoBehaviour.levelManager != null)
		{
			WPFMonoBehaviour.levelManager.ConstructionUI.DisableFunctionality = true;
		}
		base.Awake();
	}

	protected virtual void OnDestroy()
	{
		if (WPFMonoBehaviour.levelManager != null)
		{
			WPFMonoBehaviour.levelManager.ConstructionUI.DisableFunctionality = false;
		}
	}

	protected override void Start()
	{
		this.RebuildIcons();
		this.RebuildTexts();
	}

	public new void Open()
	{
		base.Open();
		this.RebuildIcons();
		this.RebuildTexts();
		EventManager.Send(new UIEvent(UIEvent.Type.OpenedPurchaseConfirmation));
	}

	public new void Close()
	{
		base.Close();
		EventManager.Send(new UIEvent(UIEvent.Type.ClosedPurchaseConfirmation));
	}

	private new void HandleKeyReleased(KeyCode obj)
	{
		if (obj == KeyCode.Escape)
		{
			this.Close();
		}
	}

	public new void Confirm()
	{
		base.Confirm();
		this.Close();
	}

	public void OpenSnoutCoinPopup()
	{
		if (Singleton<IapManager>.Instance != null)
		{
			Singleton<IapManager>.Instance.OpenShopPage(null, "SnoutCoinShop");
		}
	}

	public void RebuildIcons()
	{
		if (Singleton<RuntimeSpriteDatabase>.Instance != null)
		{
			Vector2 vector;
			if (TextDialog.SpriteScale.GetCustomScale(this.customScales, this.itemSpriteID, out vector))
			{
				this.itemIcon.m_scaleX = vector.x;
				this.itemIcon.m_scaleY = vector.y;
			}
			else
			{
				this.itemIcon.m_scaleX = this.defaultScale.x;
				this.itemIcon.m_scaleY = this.defaultScale.y;
			}
			SpriteData spriteData = Singleton<RuntimeSpriteDatabase>.Instance.Find(this.itemSpriteID);
			if (spriteData != null)
			{
				this.itemIcon.SelectSprite(spriteData, true);
			}
		}
	}

	public void RebuildTexts()
	{
		if (this.itemCountTf != null && this.countText != null)
		{
			string text = (this.itemCount <= 0) ? string.Empty : string.Format("x{0}", this.itemCount);
			this.countText.Text = text;
		}
		this.RefreshTexts(this.costText, string.Format("[snout] {0}", this.cost), false, true);
		this.RefreshTexts(this.productName, this.itemLocalizationKey, true, false);
		this.RefreshTexts(this.description, this.itemDescriptionKey, true, false);
		base.EnableConfirmButton(this.cost > 0);
	}

	private void RefreshTexts(GameObject target, string text, bool updateLocale, bool updateSprites)
	{
		TextMesh[] componentsInChildren = target.GetComponentsInChildren<TextMesh>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].text = text;
			if (updateLocale)
			{
				TextMeshLocale textMeshLocale = componentsInChildren[i].GetComponent<TextMeshLocale>();
				if (textMeshLocale == null)
				{
					textMeshLocale = componentsInChildren[i].gameObject.AddComponent<TextMeshLocale>();
				}
				textMeshLocale.RefreshTranslation(null);
				textMeshLocale.enabled = false;
			}
			if (updateSprites)
			{
				TextMeshSpriteIcons.EnsureSpriteIcon(componentsInChildren[i]);
			}
		}
	}

	[SerializeField]
	private SpriteScale[] customScales;

	[SerializeField]
	private GameObject description;

	[SerializeField]
	private SpriteText countText;

	[SerializeField]
	private Sprite itemIcon;

	[SerializeField]
	private Transform itemCountTf;

	[SerializeField]
	private GameObject costText;

	[SerializeField]
	private GameObject productName;

	private string itemSpriteID;

	private string effectSpriteID;

	private string itemLocalizationKey;

	private string itemDescriptionKey;

	private int itemCount;

	private int cost;

	private Sprite buttonBackground;

	private Sprite disabledButtonBackground;

	private Vector2 defaultScale;
}
