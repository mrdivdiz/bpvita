using UnityEngine;

public class SandboxUnlockDialog : TextDialog
{
	public string SandboxIdentifier
	{
		get
		{
			return this.sandboxIdentifier;
		}
		set
		{
			this.sandboxIdentifier = value;
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
		this.ep1Sprite.SetActive(false);
		this.ep2Sprite.SetActive(false);
		this.ep3Sprite.SetActive(false);
		this.ep4Sprite.SetActive(false);
		this.ep6Sprite.SetActive(false);
		string text = this.sandboxIdentifier;
		switch (text)
		{
		case "S-1":
		case "S-2":
			this.ep1Sprite.SetActive(true);
			break;
		case "S-7":
		case "S-8":
			this.ep2Sprite.SetActive(true);
			break;
		case "S-3":
		case "S-4":
			this.ep3Sprite.SetActive(true);
			break;
		case "S-5":
		case "S-6":
			this.ep4Sprite.SetActive(true);
			break;
		case "S-9":
		case "S-10":
			this.ep6Sprite.SetActive(true);
			break;
		}
	}

	public void RebuildTexts()
	{
		string text = string.Format("[snout] {0}", this.cost);
		TextMesh[] componentsInChildren = this.costTextEnabled.gameObject.GetComponentsInChildren<TextMesh>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].text = text;
			TextMeshSpriteIcons.EnsureSpriteIcon(componentsInChildren[i]);
		}
	}

	[SerializeField]
	private LocalizeSprite[] ep1SandboxSpriteIdLocales;

	[SerializeField]
	private LocalizeSprite[] ep2SandboxSpriteIdLocales;

	[SerializeField]
	private LocalizeSprite[] ep3SandboxSpriteIdLocales;

	[SerializeField]
	private LocalizeSprite[] ep4SandboxSpriteIdLocales;

	[SerializeField]
	private LocalizeSprite[] ep6SandboxSpriteIdLocales;

	[SerializeField]
	private GameObject ep1Sprite;

	[SerializeField]
	private GameObject ep2Sprite;

	[SerializeField]
	private GameObject ep3Sprite;

	[SerializeField]
	private GameObject ep4Sprite;

	[SerializeField]
	private GameObject ep6Sprite;

	private string sandboxIdentifier;

	private int cost;

	[SerializeField]
	private GameObject costTextEnabled;
}
