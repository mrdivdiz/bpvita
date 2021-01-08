using UnityEngine;

public class TextMeshFormattedLocale : MonoBehaviour
{
	private void Awake()
	{
		this.textMesh = base.gameObject.GetComponent<TextMesh>();
	}

	public void SetText(string format, string localeKey, params object[] items)
	{
		if (this.textMesh == null)
		{
			return;
		}
		this.localeKey = localeKey;
		this.format = format;
		this.items = items;
		this.TextUpdated(this.textMesh.gameObject);
	}

	private void TextUpdated(GameObject go)
	{
		if (this.textMesh == null || this.items == null || this.items.Length < 1)
		{
			return;
		}
		this.locale = base.gameObject.GetComponent<TextMeshLocale>();
		if (this.locale == null)
		{
			this.locale = base.gameObject.AddComponent<TextMeshLocale>();
		}
		this.locale.enabled = false;
		Localizer.LocaleParameters localeParameters = Singleton<Localizer>.Instance.Resolve(this.localeKey, null);
		this.textMesh.text = string.Format(this.format, this.items[0], localeParameters.translation);
	}

	private TextMesh textMesh;

	private TextMeshLocale locale;

	private string localeKey = string.Empty;

	private string format = string.Empty;

	private object[] items;
}
