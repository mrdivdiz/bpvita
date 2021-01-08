using UnityEngine;

[ExecuteInEditMode]
public class TerrainMaterialOverride : MonoBehaviour
{
	private void Awake()
	{
		Transform transform = base.transform.Find("_fill");
		Transform transform2 = base.transform.Find("_curve");
		if (transform != null)
		{
			this.fillRenderer = transform.GetComponent<MeshRenderer>();
		}
		if (transform2 != null)
		{
			this.curveRenderer = transform2.GetComponent<MeshRenderer>();
		}
		if (this.fillRenderer != null)
		{
			this.fillRenderer.enabled = false;
		}
		if (this.curveRenderer != null)
		{
			this.curveRenderer.enabled = false;
		}
	}

	private void Start()
	{
		if (this.fillRenderer != null && this.fillMaterial != null)
		{
			this.fillRenderer.sharedMaterial = this.fillMaterial;
			this.fillRenderer.enabled = true;
		}
		if (this.curveRenderer != null && this.curveMaterial != null)
		{
			this.curveRenderer.sharedMaterial = this.curveMaterial;
			this.curveRenderer.enabled = true;
		}
	}

	[SerializeField]
	private Material fillMaterial;

	[SerializeField]
	private Material curveMaterial;

	private MeshRenderer fillRenderer;

	private MeshRenderer curveRenderer;
}
