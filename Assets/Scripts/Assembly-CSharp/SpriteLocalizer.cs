using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLocalizer : MonoBehaviour, IEnumerable<LocalizationEntry>, IEnumerable
{
	private void Awake()
	{
		this.m_defaultSprite = base.gameObject.GetComponent<Sprite>().Id;
	}

	private void OnEnable()
	{
		EventManager.Connect(new EventManager.OnEvent<LocalizationReloaded>(this.RefreshSpriteLocale));
		this.RefreshSpriteLocale(new LocalizationReloaded(Singleton<Localizer>.Instance.CurrentLocale));
	}

	private void OnDisable()
	{
		EventManager.Disconnect(new EventManager.OnEvent<LocalizationReloaded>(this.RefreshSpriteLocale));
	}

	private void RefreshSpriteLocale(LocalizationReloaded localeChange)
	{
		string currentLanguage = localeChange.currentLanguage;
		string localizedSprite = this.GetLocalizedSprite(currentLanguage);
		RuntimeSpriteDatabase instance = Singleton<RuntimeSpriteDatabase>.Instance;
		SpriteData data = instance.Find(localizedSprite);
		base.gameObject.GetComponent<Sprite>().SelectSprite(data, false);
	}

	public IEnumerator<LocalizationEntry> GetEnumerator()
	{
		return this.m_mapping.GetEnumerator();
	}

	public void AddLocalization(string locale, string sprite = "")
	{
		this.m_mapping.Add(new LocalizationEntry(locale, sprite));
		this.m_mapping.Sort();
	}

	public void RemoveLocalization(string locale)
	{
		int? num = this.LocaleToIndex(locale);
		this.m_mapping.RemoveAt(num.Value);
	}

	public bool ContainsLocalization(string locale)
	{
		return this.LocaleToIndex(locale) != null;
	}

	public string GetDefaultSprite()
	{
		if (this.m_defaultSprite == null)
		{
			return base.gameObject.GetComponent<Sprite>().Id;
		}
		return this.m_defaultSprite;
	}

	public string GetSprite(string locale)
	{
		if (locale == "en-EN")
		{
			return this.GetDefaultSprite();
		}
		int? num = this.LocaleToIndex(locale);
		if (num != null)
		{
			return this.m_mapping[num.Value].sprite;
		}
		return null;
	}

	public string GetLocalizedSprite(string locale)
	{
		string sprite = this.GetSprite(locale);
		if (sprite != null && sprite.Length > 0)
		{
			return sprite;
		}
		return this.m_defaultSprite;
	}

	public void SetSprite(string locale, string sprite)
	{
		int? num = this.LocaleToIndex(locale);
		this.m_mapping[num.Value].sprite = sprite;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	private int? LocaleToIndex(string locale)
	{
		int num = this.m_mapping.BinarySearch(new LocalizationEntry(locale, null));
		if (num >= 0)
		{
			return new int?(num);
		}
		return null;
	}

	public const string DefaultLocale = "en-EN";

	[SerializeField]
	private List<LocalizationEntry> m_mapping = new List<LocalizationEntry>();

	private string m_defaultSprite;
}
