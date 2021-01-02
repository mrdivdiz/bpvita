using UnityEngine;

[ExecuteInEditMode]
public class BundleTexture : MonoBehaviour
{
	private void Awake()
	{
		if (this.targetRenderer == null || this.targetMaterialIndex < 0 || this.targetMaterialIndex >= this.targetRenderer.sharedMaterials.Length || this.targetRenderer.sharedMaterials[this.targetMaterialIndex] == null)
		{
			return;
		}
		if (!Application.isPlaying)
		{
			return;
		}
		Material material = this.targetRenderer.sharedMaterials[this.targetMaterialIndex];
		if (material == null)
		{
			return;
		}
		Texture2D texture2D = this.bundleObject.LoadValue<Texture2D>();
		if (texture2D != null)
		{
			material.mainTexture = texture2D;
		}
	}

	[SerializeField]
	private BundleDataObject bundleObject;

	[SerializeField]
	private Renderer targetRenderer;

	[SerializeField]
	private int targetMaterialIndex;
}
