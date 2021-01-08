using UnityEngine;

namespace Spine.Unity.MeshGeneration
{
    public class ArraysSubmeshSetMeshGenerator : ArraysMeshGenerator, ISubmeshSetMeshGenerator
	{
		public float ZSpacing { get; set; }

		public MeshAndMaterials GenerateMesh(ExposedList<SubmeshInstruction> instructions, int startSubmesh, int endSubmesh)
		{
			SubmeshInstruction[] items = instructions.Items;
			this.currentInstructions.Clear(false);
			for (int i = startSubmesh; i < endSubmesh; i++)
			{
				this.currentInstructions.Add(items[i]);
			}
            SmartMesh next = this.doubleBufferedSmartMesh.GetNext();
			Mesh mesh = next.mesh;
			int count = this.currentInstructions.Count;
			SubmeshInstruction[] items2 = this.currentInstructions.Items;
			int num = 0;
			for (int j = 0; j < count; j++)
			{
				items2[j].firstVertexIndex = num;
				num += items2[j].vertexCount;
			}
			bool flag = ArraysMeshGenerator.EnsureSize(num, ref this.meshVertices, ref this.meshUVs, ref this.meshColors32);
			bool flag2 = ArraysMeshGenerator.EnsureTriangleBuffersSize(this.submeshBuffers, count, items2);
			float zspacing = this.ZSpacing;
			Vector3 boundsMin;
			Vector3 boundsMax;
			if (num <= 0)
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
				int endSlot = items2[count - 1].endSlot;
				if (zspacing > 0f)
				{
					boundsMin.z = 0f;
					boundsMax.z = zspacing * (float)endSlot;
				}
				else
				{
					boundsMin.z = zspacing * (float)endSlot;
					boundsMax.z = 0f;
				}
			}
			ExposedList<Attachment> exposedList = this.attachmentBuffer;
			exposedList.Clear(false);
			int num2 = 0;
			for (int k = 0; k < count; k++)
			{
				SubmeshInstruction submeshInstruction = items2[k];
				int startSlot = submeshInstruction.startSlot;
				int endSlot2 = submeshInstruction.endSlot;
				Skeleton skeleton = submeshInstruction.skeleton;
				Slot[] items3 = skeleton.DrawOrder.Items;
				for (int l = startSlot; l < endSlot2; l++)
				{
					Attachment attachment = items3[l].attachment;
					if (attachment != null)
					{
						exposedList.Add(attachment);
					}
				}
				ArraysMeshGenerator.FillVerts(skeleton, startSlot, endSlot2, zspacing, base.PremultiplyVertexColors, this.meshVertices, this.meshUVs, this.meshColors32, ref num2, ref this.attachmentVertexBuffer, ref boundsMin, ref boundsMax, true);
			}
			bool flag3 = flag || flag2 || next.StructureDoesntMatch(exposedList, this.currentInstructions);
			for (int m = 0; m < count; m++)
			{
				SubmeshInstruction submeshInstruction2 = items2[m];
				if (flag3)
				{
                    SubmeshTriangleBuffer submeshTriangleBuffer = this.submeshBuffers.Items[m];
					bool isLastSubmesh = m == count - 1;
					ArraysMeshGenerator.FillTriangles(ref submeshTriangleBuffer.triangles, submeshInstruction2.skeleton, submeshInstruction2.triangleCount, submeshInstruction2.firstVertexIndex, submeshInstruction2.startSlot, submeshInstruction2.endSlot, isLastSubmesh);
					submeshTriangleBuffer.triangleCount = submeshInstruction2.triangleCount;
					submeshTriangleBuffer.firstVertex = submeshInstruction2.firstVertexIndex;
				}
			}
			if (flag3)
			{
				mesh.Clear();
				this.sharedMaterials = this.currentInstructions.GetUpdatedMaterialArray(this.sharedMaterials);
			}
			next.Set(this.meshVertices, this.meshUVs, this.meshColors32, exposedList, this.currentInstructions);
			mesh.bounds = ArraysMeshGenerator.ToBounds(boundsMin, boundsMax);
			if (flag3)
			{
				mesh.subMeshCount = count;
				for (int n = 0; n < count; n++)
				{
					mesh.SetTriangles(this.submeshBuffers.Items[n].triangles, n);
				}
				base.TryAddNormalsTo(mesh, num);
			}
			if (this.addTangents)
			{
				ArraysMeshGenerator.SolveTangents2DEnsureSize(ref this.meshTangents, ref this.tempTanBuffer, num);
				int num3 = 0;
				int num4 = count;
				while (num3 < num4)
				{
                    SubmeshTriangleBuffer submeshTriangleBuffer2 = this.submeshBuffers.Items[num3];
					ArraysMeshGenerator.SolveTangents2DTriangles(this.tempTanBuffer, submeshTriangleBuffer2.triangles, submeshTriangleBuffer2.triangleCount, this.meshVertices, this.meshUVs, num);
					num3++;
				}
				ArraysMeshGenerator.SolveTangents2DBuffer(this.meshTangents, this.tempTanBuffer, num);
			}
			return new MeshAndMaterials(next.mesh, this.sharedMaterials);
		}

		private readonly DoubleBuffered<SmartMesh> doubleBufferedSmartMesh = new DoubleBuffered<SmartMesh>();

		private readonly ExposedList<SubmeshInstruction> currentInstructions = new ExposedList<SubmeshInstruction>();

		private readonly ExposedList<Attachment> attachmentBuffer = new ExposedList<Attachment>();

		private readonly ExposedList<SubmeshTriangleBuffer> submeshBuffers = new ExposedList<SubmeshTriangleBuffer>();

		private Material[] sharedMaterials = new Material[0];

		private class SmartMesh
		{
			public void Set(Vector3[] verts, Vector2[] uvs, Color32[] colors, ExposedList<Attachment> attachments, ExposedList<SubmeshInstruction> instructions)
			{
				this.mesh.vertices = verts;
				this.mesh.uv = uvs;
				this.mesh.colors32 = colors;
				this.attachmentsUsed.Clear(false);
				this.attachmentsUsed.GrowIfNeeded(attachments.Capacity);
				this.attachmentsUsed.Count = attachments.Count;
				attachments.CopyTo(this.attachmentsUsed.Items);
				this.instructionsUsed.Clear(false);
				this.instructionsUsed.GrowIfNeeded(instructions.Capacity);
				this.instructionsUsed.Count = instructions.Count;
				instructions.CopyTo(this.instructionsUsed.Items);
			}

			public bool StructureDoesntMatch(ExposedList<Attachment> attachments, ExposedList<SubmeshInstruction> instructions)
			{
				if (attachments.Count != this.attachmentsUsed.Count)
				{
					return true;
				}
				if (instructions.Count != this.instructionsUsed.Count)
				{
					return true;
				}
				Attachment[] items = attachments.Items;
				Attachment[] items2 = this.attachmentsUsed.Items;
				int i = 0;
				int count = this.attachmentsUsed.Count;
				while (i < count)
				{
					if (items[i] != items2[i])
					{
						return true;
					}
					i++;
				}
				SubmeshInstruction[] items3 = instructions.Items;
				SubmeshInstruction[] items4 = this.instructionsUsed.Items;
				int j = 0;
				int count2 = this.instructionsUsed.Count;
				while (j < count2)
				{
					SubmeshInstruction submeshInstruction = items3[j];
					SubmeshInstruction submeshInstruction2 = items4[j];
					if (submeshInstruction.material.GetInstanceID() != submeshInstruction2.material.GetInstanceID() || submeshInstruction.startSlot != submeshInstruction2.startSlot || submeshInstruction.endSlot != submeshInstruction2.endSlot || submeshInstruction.triangleCount != submeshInstruction2.triangleCount || submeshInstruction.vertexCount != submeshInstruction2.vertexCount || submeshInstruction.firstVertexIndex != submeshInstruction2.firstVertexIndex)
					{
						return true;
					}
					j++;
				}
				return false;
			}

			public readonly Mesh mesh = SpineMesh.NewMesh();

			private readonly ExposedList<Attachment> attachmentsUsed = new ExposedList<Attachment>();

			private readonly ExposedList<SubmeshInstruction> instructionsUsed = new ExposedList<SubmeshInstruction>();
		}
	}
}
