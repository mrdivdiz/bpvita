using UnityEngine;

public class AspectRatioController : MonoBehaviour
{
	private void Update()
	{
		float num = (float)Screen.width / (float)Screen.height;
		if (num != this.m_aspectRatio)
		{
			this.m_aspectRatio = num;
			if (num < 1.33333337f)
			{
				Rect rect = base.GetComponent<Camera>().rect;
				rect.height = num / 1.33333337f;
				rect.y = (1f - rect.height) / 2f;
				base.GetComponent<Camera>().rect = rect;
			}
			else
			{
				base.GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 1f);
			}
		}
	}

	private float m_aspectRatio;

	private const float MinAspectRatio = 1.33333337f;
}
