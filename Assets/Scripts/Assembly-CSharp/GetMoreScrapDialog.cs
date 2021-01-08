public class GetMoreScrapDialog : TextDialog
{
	protected override void Awake()
	{
		base.Awake();
		base.onOpen += this.RefreshLocalization;
	}

	protected override void Start()
	{
	}

	private void OnDestroy()
	{
		base.onOpen -= this.RefreshLocalization;
	}

	public void SetScrapAmount(int scrapAmount, BasePart.PartTier tier)
	{
		this.buyScrapAmount = scrapAmount;
		this.partTier = tier;
	}

	private void RefreshLocalization()
	{
		for (int i = 0; i < this.texts.Length; i++)
		{
			this.texts[i].textMesh.text = this.texts[i].localizationKey;
			TextMeshLocale component = this.texts[i].textMesh.gameObject.GetComponent<TextMeshLocale>();
			if (component != null)
			{
				component.RefreshTranslation(null);
				string text = this.texts[i].textMesh.text;
				if (this.texts[i].textMesh.name.Equals("ScrapLabel") && text.Contains("{0}") && text.Contains("{1}"))
				{
					string arg = string.Empty;
					switch (this.partTier)
					{
					case BasePart.PartTier.Common:
						arg = "[common_star]";
						break;
					case BasePart.PartTier.Rare:
						arg = "[rare_star][rare_star]";
						break;
					case BasePart.PartTier.Epic:
						arg = "[epic_star][epic_star][epic_star]";
						break;
					case BasePart.PartTier.Legendary:
						arg = "[legendary_icon]";
						break;
					}
					this.texts[i].textMesh.text = string.Format(text, this.buyScrapAmount, arg);
				}
				component.enabled = false;
				TextMeshSpriteIcons.EnsureSpriteIcon(this.texts[i].textMesh);
				TextMeshHelper.Wrap(this.texts[i].textMesh, (!TextMeshHelper.UsesKanjiCharacters()) ? this.maxCharactersInLine : this.maxKanjiCharacterInLine, false);
			}
		}
	}

	private int buyScrapAmount;

	private BasePart.PartTier partTier;
}
