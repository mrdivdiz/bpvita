using System;
using UnityEngine;

public class RefreshLocalizer : IDisposable
{
	public RefreshLocalizer(TextMesh target)
	{
		this.target = target;
		this.originalText = target.text;
		this.originalCharacterSize = target.characterSize;
		this.originalLineSpacing = target.lineSpacing;
		this.ReloadLocalization(default(LocalizationReloaded));
		EventManager.Connect(new EventManager.OnEvent<LocalizationReloaded>(this.ReloadLocalization));
	}

	public Func<string> Update
	{
		get
		{
			return this.update;
		}
		set
		{
			this.update = value;
		}
	}

	public TextMesh Target
	{
		get
		{
			return this.target;
		}
	}

	~RefreshLocalizer()
	{
		this.Dispose();
	}

	public void Dispose()
	{
		if (this.disposed)
		{
			return;
		}
		EventManager.Disconnect(new EventManager.OnEvent<LocalizationReloaded>(this.ReloadLocalization));
		this.target = null;
		this.originalText = null;
		this.localizedText = null;
		this.update = null;
		GC.SuppressFinalize(this);
	}

	private void ReloadLocalization(LocalizationReloaded localizationReloaded)
	{
		this.ApplyLocale(null);
		this.Refresh();
	}

	private void ApplyLocale(string localeName = null)
	{
		Localizer.LocaleParameters localeParameters = Singleton<Localizer>.Instance.Resolve(this.originalText, localeName);
		Font font = Singleton<Localizer>.Instance.GetFont(localeName);
		if (font)
		{
			Color color = this.target.GetComponent<Renderer>().material.color;
			this.target.font = font;
			this.target.GetComponent<Renderer>().material = font.material;
			this.target.GetComponent<Renderer>().material.color = color;
		}
		this.localizedText = localeParameters.translation;
		this.target.characterSize = this.originalCharacterSize * localeParameters.characterSizeFactor;
		this.target.lineSpacing = this.originalLineSpacing * localeParameters.lineSpacingFactor;
	}

	public void Refresh()
	{
		if (this.update != null)
		{
			this.target.text = string.Format(this.localizedText, this.update());
		}
	}

	private TextMesh target;

	private string originalText = string.Empty;

	private string localizedText = string.Empty;

	private float originalCharacterSize;

	private float originalLineSpacing;

	private bool disposed;

	private Func<string> update;
}
