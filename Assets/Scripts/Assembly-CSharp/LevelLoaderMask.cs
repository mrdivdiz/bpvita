using UnityEngine;

public class LevelLoaderMask : MonoBehaviour
{
	private void Update()
	{
		this.fade += Time.deltaTime * 10f;
		base.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, this.targetColor, this.fade);
		if (this.fade >= 1f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private float fade;

	private Color targetColor = new Color(0f, 0f, 0f, 0f);
}
