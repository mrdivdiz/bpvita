using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using UnityEngine;

public class Localizer : Singleton<Localizer>
{
	public Font LanguageFont
	{
		get
		{
			return this.languageSpecificFont;
		}
	}

	public Font EnglishFont
	{
		get
		{
			return this.englishFont;
		}
	}

	public string CurrentLocale
	{
		get
		{
			return this.currentLocale;
		}
	}

	public static XDocument LoadLocalizationFile()
	{
		TextAsset textAsset = Resources.Load<TextAsset>("Localization/localization_data");
		return XDocument.Parse(textAsset.text);
	}

	private void Awake()
	{
		base.SetAsPersistant();
		this.currentLocale = this.DetectLocale();
		this.PopulateTranslations(this.currentLocale);
		this.localizationDataInitalized = true;
	}

	private string DetectLocale()
	{
		string localeId = "en-EN";
		if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			localeId = "ja-JP";
		}
		SystemLanguage systemLanguage = Application.systemLanguage;
		switch (systemLanguage)
		{
		case SystemLanguage.Polish:
			localeId = "pl-PL";
			break;
		case SystemLanguage.Portuguese:
			localeId = "pt-PT";
			break;
		default:
			if (systemLanguage != SystemLanguage.French)
			{
				if (systemLanguage != SystemLanguage.German)
				{
					if (systemLanguage != SystemLanguage.Italian)
					{
						if (systemLanguage != SystemLanguage.Japanese)
						{
							if (systemLanguage != SystemLanguage.ChineseSimplified && systemLanguage != SystemLanguage.ChineseTraditional)
							{
								if (systemLanguage == SystemLanguage.Arabic)
								{
									localeId = "ar-AR";
									break;
								}
								if (systemLanguage != SystemLanguage.Chinese)
								{
									if (systemLanguage != SystemLanguage.English)
									{
										localeId = "en-EN";
										break;
									}
									localeId = "en-EN";
									break;
								}
							}
							localeId = "zh-CN";
						}
						else
						{
							localeId = "ja-JP";
						}
					}
					else
					{
						localeId = "it-IT";
					}
				}
				else
				{
					localeId = "de-DE";
				}
			}
			else
			{
				localeId = "fr-FR";
			}
			break;
		case SystemLanguage.Russian:
			localeId = "ru-RU";
			break;
		case SystemLanguage.Spanish:
			localeId = "es-ES";
			break;
		}
		if (this.allowedLocales != null && this.allowedLocales.Length > 0)
		{
            foreach (string x in this.allowedLocales)
            {
                if (x == localeId)
                {
                    return localeId;
                }
            }
			return "en-EN";
		}
		return localeId;
	}

	public Font GetFont(string localeName)
	{
		return (!(localeName == "en-EN")) ? Singleton<Localizer>.Instance.LanguageFont : Singleton<Localizer>.Instance.EnglishFont;
	}

	public LocaleParameters Resolve(string textId, string localeName = null)
	{
		Dictionary<string, LocaleParameters> dictionary = (!(localeName == "en-EN")) ? this.activeTranslations : this.englishTranslations;
		if (!dictionary.ContainsKey(textId) || dictionary[textId].translation == string.Empty)
		{
            LocaleParameters localeParameters = new LocaleParameters();
			localeParameters.translation = textId;
			return localeParameters;
		}
		return dictionary[textId];
	}

	private bool LoadFont(string fontName)
	{
		if (fontName != "default")
		{
			this.languageSpecificFont = (Font)Resources.Load("Localization/Fonts/" + fontName, typeof(Font));
			return this.languageSpecificFont;
		}
		return true;
	}

	private void PopulateTranslations(string localeId)
	{
		bool flag = this.englishTranslations == null;
		if (flag)
		{
			this.englishTranslations = new Dictionary<string, LocaleParameters>();
		}
		XDocument xdocument = Localizer.LoadLocalizationFile();
        XElement xelement = null;
        foreach (XElement lang in xdocument.Element("texts").Elements("languages").Descendants())
        {
            if (lang.Name == localeId)
            {
                xelement = lang;
                break;
            }
        }
		if (xelement != null)
		{
			XElement xelement2 = xelement.Element("font");
			if (xelement2 != null)
			{
                this.LoadFont(xelement2.Value);
            }
		}
		if (this.englishFont == null)
		{
            XElement xelement3 = null;
            foreach (XElement lang in xdocument.Element("texts").Elements("languages").Descendants())
            {
                if (lang.Name == "en-EN")
                {
                    xelement3 = lang;
                    break;
                }
            }
            if (xelement3 != null)
			{
				XElement xelement4 = xelement3.Element("font");
				if (xelement4 != null)
				{
					this.englishFont = (Font)Resources.Load("Localization/Fonts/" + xelement4.Value, typeof(Font));
				}
			}
		}
		foreach (XElement xelement5 in xdocument.Element("texts").Elements("text"))
		{
			string value = xelement5.Element("text_id").Value;
			XElement xelement6 = xelement5.Element(localeId);
			if (xelement6 == null)
			{
				xelement6 = xelement5.Element("en-EN");
			}
			if (!this.activeTranslations.ContainsKey(value))
			{
				this.activeTranslations.Add(value, this.FormulateTranslation(xelement6));
				if (flag)
				{
					xelement6 = xelement5.Element("en-EN");
					this.englishTranslations.Add(value, this.FormulateTranslation(xelement6));
				}
			}
		}
	}

	private LocaleParameters FormulateTranslation(XElement xn)
	{
        LocaleParameters localeParameters = new LocaleParameters();
		localeParameters.translation = xn.Value;
		XAttribute xattribute = xn.Attribute("character_size");
		XAttribute xattribute2 = xn.Attribute("line_spacing");
		if (xattribute != null)
		{
			localeParameters.characterSizeFactor = float.Parse(xattribute.Value, CultureInfo.InvariantCulture);
		}
		if (xattribute2 != null)
		{
			localeParameters.lineSpacingFactor = float.Parse(xattribute2.Value, CultureInfo.InvariantCulture);
		}
		return localeParameters;
	}

	private void OnApplicationPause(bool paused)
	{
		if (!paused)
		{
			string a = this.DetectLocale();
			if (a != this.currentLocale)
			{
				this.RefreshLocalization();
			}
		}
	}

	private void RefreshLocalization()
	{
		this.activeTranslations.Clear();
		this.languageSpecificFont = null;
		this.currentLocale = this.DetectLocale();
		this.PopulateTranslations(this.currentLocale);
		EventManager.Send(new LocalizationReloaded(this.currentLocale));
	}

	public string[] allowedLocales;

	private Dictionary<string, LocaleParameters> activeTranslations = new Dictionary<string, LocaleParameters>();

	private Dictionary<string, LocaleParameters> englishTranslations;

	private Font languageSpecificFont;

	private Font englishFont;

	private new static Localizer instance;

	private const string defaultFontName = "default";

	private bool localizationDataInitalized;

	private string currentLocale = string.Empty;

	public class LocaleParameters
	{
		public string translation = string.Empty;

		public float characterSizeFactor = 1f;

		public float lineSpacingFactor = 1f;
	}
}
