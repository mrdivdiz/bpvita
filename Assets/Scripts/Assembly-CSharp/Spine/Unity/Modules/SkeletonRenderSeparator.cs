using System.Collections.Generic;
using Spine.Unity.MeshGeneration;
using UnityEngine;
using UnityEngine.Rendering;

namespace Spine.Unity.Modules
{
    [ExecuteInEditMode]
	[HelpURL("https://github.com/pharan/spine-unity-docs/blob/master/SkeletonRenderSeparator.md")]
	public class SkeletonRenderSeparator : MonoBehaviour
	{
		public SkeletonRenderer SkeletonRenderer
		{
			get
			{
				return this.skeletonRenderer;
			}
			set
			{
				if (this.skeletonRenderer != null)
				{
					this.skeletonRenderer.GenerateMeshOverride -= this.HandleRender;
				}
				this.skeletonRenderer = value;
				base.enabled = false;
			}
		}

		private void OnEnable()
		{
			if (this.skeletonRenderer == null)
			{
				return;
			}
			if (this.copiedBlock == null)
			{
				this.copiedBlock = new MaterialPropertyBlock();
			}
			this.mainMeshRenderer = this.skeletonRenderer.GetComponent<MeshRenderer>();
			this.skeletonRenderer.GenerateMeshOverride -= this.HandleRender;
			this.skeletonRenderer.GenerateMeshOverride += this.HandleRender;
			if (this.copyMeshRendererFlags)
			{
				LightProbeUsage lightProbeUsage = this.mainMeshRenderer.lightProbeUsage;
				bool receiveShadows = this.mainMeshRenderer.receiveShadows;
				for (int i = 0; i < this.partsRenderers.Count; i++)
				{
					SkeletonPartsRenderer skeletonPartsRenderer = this.partsRenderers[i];
					if (!(skeletonPartsRenderer == null))
					{
						MeshRenderer meshRenderer = skeletonPartsRenderer.MeshRenderer;
						meshRenderer.lightProbeUsage = lightProbeUsage;
						meshRenderer.receiveShadows = receiveShadows;
					}
				}
			}
		}

		private void OnDisable()
		{
			if (this.skeletonRenderer == null)
			{
				return;
			}
			this.skeletonRenderer.GenerateMeshOverride -= this.HandleRender;
			foreach (SkeletonPartsRenderer skeletonPartsRenderer in this.partsRenderers)
			{
				skeletonPartsRenderer.ClearMesh();
			}
		}

		private void HandleRender(SkeletonRenderer.SmartMesh.Instruction instruction)
		{
			int count = this.partsRenderers.Count;
			if (count <= 0)
			{
				return;
			}
			int i = 0;
			if (this.copyPropertyBlock)
			{
				this.mainMeshRenderer.GetPropertyBlock(this.copiedBlock);
			}
			ExposedList<SubmeshInstruction> submeshInstructions = instruction.submeshInstructions;
			SubmeshInstruction[] items = submeshInstructions.Items;
			int num = submeshInstructions.Count - 1;
			SkeletonPartsRenderer skeletonPartsRenderer = this.partsRenderers[i];
			bool calculateNormals = this.skeletonRenderer.calculateNormals;
			bool calculateTangents = this.skeletonRenderer.calculateTangents;
			bool pmaVertexColors = this.skeletonRenderer.pmaVertexColors;
			int j = 0;
			int startSubmesh = 0;
			while (j <= num)
			{
				if (items[j].forceSeparate || j == num)
				{
					ISubmeshSetMeshGenerator meshGenerator = skeletonPartsRenderer.MeshGenerator;
					meshGenerator.AddNormals = calculateNormals;
					meshGenerator.AddTangents = calculateTangents;
					meshGenerator.PremultiplyVertexColors = pmaVertexColors;
					if (this.copyPropertyBlock)
					{
						skeletonPartsRenderer.SetPropertyBlock(this.copiedBlock);
					}
					skeletonPartsRenderer.RenderParts(instruction.submeshInstructions, startSubmesh, j + 1);
					startSubmesh = j + 1;
					i++;
					if (i >= count)
					{
						break;
					}
					skeletonPartsRenderer = this.partsRenderers[i];
				}
				j++;
			}
			while (i < count)
			{
				this.partsRenderers[i].ClearMesh();
				i++;
			}
		}

		public const int DefaultSortingOrderIncrement = 5;

		[SerializeField]
		protected SkeletonRenderer skeletonRenderer;

		private MeshRenderer mainMeshRenderer;

		public bool copyPropertyBlock;

		[Tooltip("Copies MeshRenderer flags into ")]
		public bool copyMeshRendererFlags;

		public List<SkeletonPartsRenderer> partsRenderers = new List<SkeletonPartsRenderer>();

		private MaterialPropertyBlock copiedBlock;
	}
}
