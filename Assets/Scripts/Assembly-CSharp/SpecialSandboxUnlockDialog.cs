using UnityEngine;

public class SpecialSandboxUnlockDialog : TextDialog
{
	public UnlockType Type
	{
		get
		{
			return this.unlockType;
		}
		set
		{
			this.unlockType = value;
		}
	}

	public int Collected
	{
		get
		{
			return this.collected;
		}
		set
		{
			this.collected = value;
		}
	}

	public int Required
	{
		get
		{
			return this.required;
		}
		set
		{
			this.required = value;
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
		base.Awake();
	}

	protected override void Start()
	{
		if (this.isOpened)
		{
			return;
		}
		this.RebuildIcons();
		this.RebuildTexts();
	}

	public new void Open()
	{
		this.RebuildIcons();
		this.RebuildTexts();
		base.Open();
	}

	public new void Close()
	{
		base.Close();
	}

	public new void Confirm()
	{
		base.Confirm();
	}

	public new void OpenShop()
	{
		base.OpenShop();
	}

	public void RebuildIcons()
	{
		if (Singleton<RuntimeSpriteDatabase>.Instance != null)
		{
			RuntimeSpriteDatabase instance = Singleton<RuntimeSpriteDatabase>.Instance;
            UnlockType unlockType = this.unlockType;
			if (unlockType != SpecialSandboxUnlockDialog.UnlockType.Skull)
			{
				if (unlockType == SpecialSandboxUnlockDialog.UnlockType.Statue)
				{
					this.sandboxLogo.SelectSprite(instance.Find(TextDialog.LocalizeSprite.GetLocalizedSprite(this.statueEpisodeIcon, Singleton<Localizer>.Instance.CurrentLocale)), true);
				}
			}
			else
			{
				this.sandboxLogo.SelectSprite(instance.Find(TextDialog.LocalizeSprite.GetLocalizedSprite(this.skullEpisodeIcon, Singleton<Localizer>.Instance.CurrentLocale)), true);
			}
		}
	}

	public void RebuildTexts()
	{
		string arg = string.Empty;
		string text = string.Format("[snout] {0}", this.cost);
        UnlockType unlockType = this.unlockType;
		if (unlockType != SpecialSandboxUnlockDialog.UnlockType.Skull)
		{
			if (unlockType == SpecialSandboxUnlockDialog.UnlockType.Statue)
			{
				arg = "[statue]";
			}
		}
		else
		{
			arg = "[skull]";
		}
		string text2 = string.Format("{0} {1}/{2}", arg, this.collected, this.required);
		for (int i = 0; i < this.collectedTexts.Length; i++)
		{
			this.collectedTexts[i].text = text2;
			TextMeshSpriteIcons.EnsureSpriteIcon(this.collectedTexts[i]);
		}
		this.costTextDisabled.text = text;
		TextMeshSpriteIcons.EnsureSpriteIcon(this.costTextDisabled);
		this.costTextEnabled.text = text;
		TextMeshSpriteIcons.EnsureSpriteIcon(this.costTextEnabled);
	}

	[SerializeField]
	private LocalizeSprite[] statueEpisodeIcon;

	[SerializeField]
	private LocalizeSprite[] skullEpisodeIcon;

	private UnlockType unlockType;

	private int collected;

	private int required;

	private int cost;

	[SerializeField]
	private Sprite sandboxLogo;

	[SerializeField]
	private TextMesh costTextEnabled;

	[SerializeField]
	private TextMesh costTextDisabled;

	[SerializeField]
	private TextMesh[] collectedTexts;

	public enum UnlockType
	{
		Statue,
		Skull
	}
}
