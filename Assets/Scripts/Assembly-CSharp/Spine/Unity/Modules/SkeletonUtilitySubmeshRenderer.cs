using System;
using UnityEngine;

namespace Spine.Unity.Modules
{
	[ExecuteInEditMode]
	public class SkeletonUtilitySubmeshRenderer : MonoBehaviour
	{
		private void Awake()
		{
			this.cachedRenderer = base.GetComponent<Renderer>();
			this.filter = base.GetComponent<MeshFilter>();
			this.sharedMaterials = new Material[0];
		}

		public void SetMesh(Renderer parentRenderer, Mesh mesh, Material mat)
		{
			if (this.cachedRenderer == null)
			{
				return;
			}
			this.cachedRenderer.enabled = true;
			this.filter.sharedMesh = mesh;
			if (this.cachedRenderer.sharedMaterials.Length != parentRenderer.sharedMaterials.Length)
			{
				this.sharedMaterials = parentRenderer.sharedMaterials;
			}
			for (int i = 0; i < this.sharedMaterials.Length; i++)
			{
				if (i == this.submeshIndex)
				{
					this.sharedMaterials[i] = mat;
				}
				else
				{
					this.sharedMaterials[i] = this.hiddenPassMaterial;
				}
			}
			this.cachedRenderer.sharedMaterials = this.sharedMaterials;
		}

		[NonSerialized]
		public Mesh mesh;

		public int submeshIndex;

		public Material hiddenPassMaterial;

		private Renderer cachedRenderer;

		private MeshFilter filter;

		private Material[] sharedMaterials;
	}
}
