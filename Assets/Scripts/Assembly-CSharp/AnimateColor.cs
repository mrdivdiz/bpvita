using System;
using UnityEngine;

[ExecuteInEditMode]
public class AnimateColor : MonoBehaviour
{
	private void Awake()
	{
		this.Reset();
	}

	private void Reset()
	{
		this.m_renderer = base.GetComponent<MeshRenderer>();
		if (this.m_renderer != null && this.originalMaterial != null)
		{
			this.materialInstance = new Material(this.originalMaterial);
			AtlasMaterials.Instance.AddMaterialInstance(this.materialInstance);
			this.m_renderer.material = this.materialInstance;
		}
	}

	private void OnDestroy()
	{
		if (AtlasMaterials.IsInstantiated)
		{
			AtlasMaterials.Instance.RemoveMaterialInstance(this.materialInstance);
		}
	}

	private void Update()
	{
		if (this.materialInstance == null)
		{
			return;
		}
		this.materialInstance.SetColor(this.colorName, this.color);
	}

	[SerializeField]
	private Material originalMaterial;

	public string colorName = "_Color";

	public Color color = Color.white;

	private MeshRenderer m_renderer;

	[NonSerialized]
	private Material materialInstance;
}
