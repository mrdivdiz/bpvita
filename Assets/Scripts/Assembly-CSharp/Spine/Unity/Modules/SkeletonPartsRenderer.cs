using System;
using Spine.Unity.MeshGeneration;
using UnityEngine;

namespace Spine.Unity.Modules
{
	[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
	public class SkeletonPartsRenderer : MonoBehaviour
	{
		public ISubmeshSetMeshGenerator MeshGenerator
		{
			get
			{
				this.LazyIntialize();
				return this.meshGenerator;
			}
		}

		public MeshRenderer MeshRenderer
		{
			get
			{
				this.LazyIntialize();
				return this.meshRenderer;
			}
		}

		public MeshFilter MeshFilter
		{
			get
			{
				this.LazyIntialize();
				return this.meshFilter;
			}
		}

		private void LazyIntialize()
		{
			if (this.meshGenerator != null)
			{
				return;
			}
			this.meshGenerator = new ArraysSubmeshSetMeshGenerator();
			this.meshFilter = base.GetComponent<MeshFilter>();
			this.meshRenderer = base.GetComponent<MeshRenderer>();
		}

		public void ClearMesh()
		{
			this.LazyIntialize();
			this.meshFilter.sharedMesh = null;
		}

		public void RenderParts(ExposedList<SubmeshInstruction> instructions, int startSubmesh, int endSubmesh)
		{
			this.LazyIntialize();
			MeshAndMaterials meshAndMaterials = this.meshGenerator.GenerateMesh(instructions, startSubmesh, endSubmesh);
			this.meshFilter.sharedMesh = meshAndMaterials.mesh;
			this.meshRenderer.sharedMaterials = meshAndMaterials.materials;
		}

		public void SetPropertyBlock(MaterialPropertyBlock block)
		{
			this.LazyIntialize();
			this.meshRenderer.SetPropertyBlock(block);
		}

		public static SkeletonPartsRenderer NewPartsRendererGameObject(Transform parent, string name)
		{
			GameObject gameObject = new GameObject(name, new Type[]
			{
				typeof(MeshFilter),
				typeof(MeshRenderer)
			});
			gameObject.transform.SetParent(parent, false);
			return gameObject.AddComponent<SkeletonPartsRenderer>();
		}

		private ISubmeshSetMeshGenerator meshGenerator;

		private MeshRenderer meshRenderer;

		private MeshFilter meshFilter;
	}
}
