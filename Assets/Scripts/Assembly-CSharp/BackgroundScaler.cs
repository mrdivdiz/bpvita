using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
	private void Awake()
	{
		this.originalScale = base.transform.localScale;
	}

	private void Update()
	{
		base.transform.localScale = new Vector3(this.originalScale.x * (float)Screen.width / (float)Screen.height / 1.33333337f, this.originalScale.y, this.originalScale.z);
	}

	private Vector3 originalScale;
}
