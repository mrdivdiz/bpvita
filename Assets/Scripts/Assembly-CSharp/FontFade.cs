using UnityEngine;

public class FontFade : MonoBehaviour
{
	private void Update()
	{
		if (this.m_fadingInProgress)
		{
			this.m_currentAlpha -= Time.deltaTime;
			Color color = this.m_textMesh.color;
			color.a = this.m_currentAlpha;
			this.m_textMesh.color = color;
			if (this.m_currentAlpha <= 0f)
			{
				base.gameObject.SetActive(false);
				this.m_fadingInProgress = false;
				base.transform.position = this.m_originalPosition;
			}
			if (this.doTransform)
			{
				base.transform.position = base.transform.position + new Vector3(0f, Time.deltaTime * 0.5f, 0f);
			}
		}
	}

	private void OnEnable()
	{
		this.m_textMesh = base.GetComponent<TextMesh>();
		this.m_fadingInProgress = false;
		this.m_originalPosition = base.transform.position;
		if (this.m_textMesh)
		{
			this.m_currentAlpha = 1.2f;
			Color color = this.m_textMesh.color;
			color.a = 1f;
			this.m_textMesh.color = color;
			this.m_fadingInProgress = true;
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}

	private bool m_fadingInProgress;

	private TextMesh m_textMesh;

	private float m_currentAlpha = 1f;

	private Vector3 m_originalPosition;

	public bool doTransform = true;
}
