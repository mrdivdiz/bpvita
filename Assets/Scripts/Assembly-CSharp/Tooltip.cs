using System.Collections;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
	private void Awake()
	{
		this.arrow = base.transform.Find("Arrow");
		if (this.arrow != null)
		{
			this.arrowOriginalPosition = this.arrow.localPosition;
		}
		this.background = base.transform.Find("Popup");
		if (this.background != null)
		{
			this.backgroundOriginalPosition = this.background.localPosition;
			Transform transform = this.background.Find("InfoText");
			if (transform != null)
			{
				this.locale = transform.GetComponent<TextMeshLocale>();
				this.textMesh = transform.GetComponent<TextMesh>();
			}
		}
		base.transform.localScale = Vector3.one * 0.001f;
		this.hudCamera = Singleton<GuiManager>.Instance.FindCamera();
	}

	private IEnumerator Start()
	{
		yield return null;
		if (string.IsNullOrEmpty(this.thisLocaleKey))
		{
			yield break;
		}
		this.SetText(this.thisLocaleKey);
		base.GetComponent<Animation>().Play("TooltipOpen");
		yield break;
	}

	private void Update()
	{
		if (!this.closing && GuiManager.GetPointer().dragging)
		{
			this.Close();
		}
		if (this.followTarget)
		{
			if (this.hudCamera && this.background && !base.GetComponent<Animation>().isPlaying)
			{
				Vector3 vector = Vector3.right * ((float)Screen.width / (float)Screen.height) * this.hudCamera.orthographicSize;
				Vector3 vector2 = Vector3.right * (base.transform.position.x + this.background.GetComponent<Renderer>().bounds.size.x) + Vector3.up * (base.transform.position.y + this.background.GetComponent<Renderer>().bounds.size.y);
				if (vector.x < vector2.x)
				{
					Vector3 vector3 = Vector3.right * (vector.x - vector2.x);
					this.background.localPosition = this.backgroundOriginalPosition + vector3;
					if (this.arrow && vector3.x < -7f)
					{
						this.arrow.localPosition = this.arrowOriginalPosition + (vector3 + Vector3.right * 7f);
					}
				}
			}
			base.transform.position = this.followTarget.position;
		}
	}

	private void Close()
	{
		this.closing = true;
		base.GetComponent<Animation>().Play("TooltipClose");
		base.StartCoroutine(this.DelayClose());
	}

	private IEnumerator DelayClose()
	{
		while (base.GetComponent<Animation>().isPlaying)
		{
			yield return null;
		}
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	private void SetText(string localeKey)
	{
		this.thisLocaleKey = localeKey;
		this.textMesh.text = this.thisLocaleKey;
		this.locale.RefreshTranslation(null);
		if (TextMeshHelper.UsesKanjiCharacters())
		{
			TextMeshHelper.Wrap(this.textMesh, 13, false);
		}
		else
		{
			TextMeshHelper.Wrap(this.textMesh, 24, false);
		}
	}

	public void SetLocaleKey(string tooltipLocaleKey)
	{
		this.thisLocaleKey = tooltipLocaleKey;
	}

	public void SetTarget(Transform newTarget)
	{
		this.followTarget = newTarget;
	}

	private TextMeshLocale locale;

	private TextMesh textMesh;

	private bool closing;

	private string thisLocaleKey = string.Empty;

	private Transform followTarget;

	private Camera hudCamera;

	private Transform background;

	private Transform arrow;

	private Vector3 backgroundOriginalPosition;

	private Vector3 arrowOriginalPosition;
}
