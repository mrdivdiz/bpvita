using UnityEngine;

public class TextMeshLocaleShader : MonoBehaviour
{
	private void TextUpdated(GameObject caller)
	{
		if (caller != base.gameObject)
		{
			return;
		}
		if (this.renderer == null)
		{
			this.renderer = base.GetComponent<Renderer>();
			TextMesh component = base.GetComponent<TextMesh>();
			if (component != null)
			{
				this.originalColor = component.color;
			}
		}
		if (this.renderer != null)
		{
			this.renderer.material.shader = this.shader;
			this.renderer.material.color = this.originalColor;
		}
	}

	[SerializeField]
	private Shader shader;

	private Renderer renderer;

	private Color originalColor = Color.white;
}
