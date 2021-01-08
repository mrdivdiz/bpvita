using System;
using UnityEngine;

public class TextMeshLocale : MonoBehaviour
{
	public string Postfix
	{
		set
		{
			this.postfix = value;
			this.targetTextMesh.text = this.localeParameters.translation + this.postfix;
		}
	}

	private void Start()
	{
		this.ApplyLocale(null);
	}

	private void ApplyLocale(string localeName = null)
	{
		this.localeParameters = Singleton<Localizer>.Instance.Resolve(this.originalTextContents, localeName);
		Font font = Singleton<Localizer>.Instance.GetFont(localeName);
		if (font)
		{
			Color color = this.targetTextMesh.GetComponent<Renderer>().material.color;
			this.targetTextMesh.font = font;
			this.targetTextMesh.GetComponent<Renderer>().material = font.material;
			this.targetTextMesh.GetComponent<Renderer>().material.color = color;
		}
		this.targetTextMesh.text = this.localeParameters.translation + this.postfix;
		base.gameObject.SendMessageUpwards("TextUpdated", base.gameObject, SendMessageOptions.DontRequireReceiver);
		this.targetTextMesh.characterSize = this.originalCharacterSize * this.localeParameters.characterSizeFactor;
		this.targetTextMesh.lineSpacing = this.originalLineSpacing * this.localeParameters.lineSpacingFactor;
	}

	public void RefreshTranslation(string localeName = null)
	{
		this.Init();
		this.originalTextContents = this.targetTextMesh.text;
		this.ApplyLocale(localeName);
	}

	private void Awake()
	{
		this.Init();
	}

	private void Init()
	{
		if (this.isInitialized)
		{
			return;
		}
		this.targetTextMesh = base.GetComponent<TextMesh>();
		this.originalCharacterSize = this.targetTextMesh.characterSize;
		this.originalLineSpacing = this.targetTextMesh.lineSpacing;
		this.originalTextContents = this.targetTextMesh.text;
		EventManager.Connect(new EventManager.OnEvent<LocalizationReloaded>(this.ReceiveLocalizationReloaded));
		this.isInitialized = true;
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<LocalizationReloaded>(this.ReceiveLocalizationReloaded));
	}

	private void ReceiveLocalizationReloaded(LocalizationReloaded localizationReloaded)
	{
		this.ApplyLocale(null);
	}

	private TextMesh targetTextMesh;

	private string originalTextContents = string.Empty;

	private float originalCharacterSize;

	private float originalLineSpacing;

	private string postfix = string.Empty;

	private Localizer.LocaleParameters localeParameters;

	private bool isInitialized;
}
