using UnityEngine;

namespace Spine.Unity.MeshGeneration
{
    public class ArraysSimpleMeshGenerator : ArraysMeshGenerator, ISimpleMeshGenerator
	{
		public float Scale
		{
			get
			{
				return this.scale;
			}
			set
			{
				this.scale = value;
			}
		}

		public float ZSpacing { get; set; }

		public Mesh LastGeneratedMesh
		{
			get
			{
				return this.lastGeneratedMesh;
			}
		}

		public Mesh GenerateMesh(Skeleton skeleton)
		{
			int num = 0;
			int num2 = 0;
			Slot[] items = skeleton.drawOrder.Items;
			int count = skeleton.drawOrder.Count;
			int i = 0;
			while (i < count)
			{
				Slot slot = items[i];
				Attachment attachment = slot.attachment;
				RegionAttachment regionAttachment = attachment as RegionAttachment;
				int num3;
				int num4;
				if (regionAttachment != null)
				{
					num3 = 4;
					num4 = 6;
					goto IL_7E;
				}
				MeshAttachment meshAttachment = attachment as MeshAttachment;
				if (meshAttachment != null)
				{
					num3 = meshAttachment.worldVerticesLength >> 1;
					num4 = meshAttachment.triangles.Length;
					goto IL_7E;
				}
				IL_88:
				i++;
				continue;
				IL_7E:
				num2 += num4;
				num += num3;
				goto IL_88;
			}
			ArraysMeshGenerator.EnsureSize(num, ref this.meshVertices, ref this.meshUVs, ref this.meshColors32);
			this.triangles = (this.triangles ?? new int[num2]);
			Vector3 boundsMin;
			Vector3 boundsMax;
			if (num == 0)
			{
				boundsMin = new Vector3(0f, 0f, 0f);
				boundsMax = new Vector3(0f, 0f, 0f);
			}
			else
			{
				boundsMin.x = 2.14748365E+09f;
				boundsMin.y = 2.14748365E+09f;
				boundsMax.x = -2.14748365E+09f;
				boundsMax.y = -2.14748365E+09f;
				boundsMin.z = -0.01f * this.scale;
				boundsMax.z = 0.01f * this.scale;
				int num5 = 0;
				ArraysMeshGenerator.FillVerts(skeleton, 0, count, this.ZSpacing, base.PremultiplyVertexColors, this.meshVertices, this.meshUVs, this.meshColors32, ref num5, ref this.attachmentVertexBuffer, ref boundsMin, ref boundsMax, true);
				boundsMax.x *= this.scale;
				boundsMax.y *= this.scale;
				boundsMin.x *= this.scale;
				boundsMax.y *= this.scale;
				Vector3[] meshVertices = this.meshVertices;
				for (int j = 0; j < num; j++)
				{
					Vector3 vector = meshVertices[j];
					vector.x *= this.scale;
					vector.y *= this.scale;
					meshVertices[j] = vector;
				}
			}
			ArraysMeshGenerator.FillTriangles(ref this.triangles, skeleton, num2, 0, 0, count, true);
			Mesh nextMesh = this.doubleBufferedMesh.GetNextMesh();
			nextMesh.vertices = this.meshVertices;
			nextMesh.colors32 = this.meshColors32;
			nextMesh.uv = this.meshUVs;
			nextMesh.bounds = ArraysMeshGenerator.ToBounds(boundsMin, boundsMax);
			nextMesh.triangles = this.triangles;
			base.TryAddNormalsTo(nextMesh, num);
			if (this.addTangents)
			{
				ArraysMeshGenerator.SolveTangents2DEnsureSize(ref this.meshTangents, ref this.tempTanBuffer, num);
				ArraysMeshGenerator.SolveTangents2DTriangles(this.tempTanBuffer, this.triangles, num2, this.meshVertices, this.meshUVs, num);
				ArraysMeshGenerator.SolveTangents2DBuffer(this.meshTangents, this.tempTanBuffer, num);
			}
			this.lastGeneratedMesh = nextMesh;
			return nextMesh;
		}

		protected float scale = 1f;

		protected Mesh lastGeneratedMesh;

		private readonly DoubleBufferedMesh doubleBufferedMesh = new DoubleBufferedMesh();

		private int[] triangles;
	}
}
