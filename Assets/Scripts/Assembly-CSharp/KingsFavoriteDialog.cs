using UnityEngine;

public class KingsFavoriteDialog : TextDialog
{
	protected override void Awake()
	{
		base.Awake();
		TextMesh[] componentsInChildren = this.descriptionText.GetComponentsInChildren<TextMesh>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			TextMeshLocale component = componentsInChildren[i].GetComponent<TextMeshLocale>();
			if (!(component == null))
			{
				component.RefreshTranslation(componentsInChildren[i].text);
				component.enabled = false;
				float value = Singleton<GameConfigurationManager>.Instance.GetValue<float>("cake_race", "kings_favorite_bonus");
				int num = 0;
				if (!Mathf.Approximately(value, 0f))
				{
					num = Mathf.RoundToInt((value - 1f) * 100f);
				}
				componentsInChildren[i].text = string.Format(componentsInChildren[i].text, num.ToString());
				if (TextMeshHelper.UsesKanjiCharacters())
				{
					TextMeshHelper.Wrap(componentsInChildren[i], this.maxKanjiCharacterInLine, false);
				}
				else
				{
					TextMeshHelper.Wrap(componentsInChildren[i], this.maxCharactersInLine, false);
				}
			}
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		this.UpdatePart();
	}

	public new void Open()
	{
		base.Open();
	}

	public new void Close()
	{
		base.Close();
	}

	private void UpdatePart()
	{
		if (this.favoritePart != null)
		{
			UnityEngine.Object.Destroy(this.favoritePart);
		}
		if (Singleton<CakeRaceKingsFavorite>.Instance.CurrentFavorite == null)
		{
			this.Close();
		}
		BasePart currentFavorite = Singleton<CakeRaceKingsFavorite>.Instance.CurrentFavorite;
		this.favoritePart = UnityEngine.Object.Instantiate<GameObject>(this.partTierBackgrounds[(int)currentFavorite.m_partTier]);
		this.favoritePart.transform.parent = this.partRoot;
		this.favoritePart.transform.localScale = Vector3.one * 0.7f;
		this.favoritePart.transform.localPosition = Vector3.zero;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(currentFavorite.m_constructionIconSprite.gameObject);
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.parent = this.favoritePart.transform;
		gameObject.transform.localPosition = Vector3.back * 0.1f;
		gameObject.transform.localRotation = Quaternion.identity;
		LayerHelper.SetLayer(this.favoritePart, base.gameObject.layer, true);
		LayerHelper.SetSortingLayer(this.favoritePart, "Popup", true);
	}

	[SerializeField]
	private Transform partRoot;

	[SerializeField]
	private GameObject[] partTierBackgrounds;

	[SerializeField]
	private GameObject descriptionText;

	private GameObject favoritePart;
}
