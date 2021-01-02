using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.MeshGeneration
{
	public class ArraysSubmeshedMeshGenerator : ArraysMeshGenerator, ISubmeshedMeshGenerator
	{
		public List<Slot> Separators
		{
			get
			{
				return this.separators;
			}
		}

		public float ZSpacing { get; set; }

		public SubmeshedMeshInstruction GenerateInstruction(Skeleton skeleton)
		{
			if (skeleton == null)
			{
				throw new ArgumentNullException("skeleton");
			}
			int num = 0;
			int num2 = 0;
			int firstVertexIndex = 0;
			int num3 = 0;
			int startSlot = 0;
			Material material = null;
			ExposedList<Slot> drawOrder = skeleton.drawOrder;
			Slot[] items = drawOrder.Items;
			int count = drawOrder.Count;
			int count2 = this.separators.Count;
			ExposedList<SubmeshInstruction> submeshInstructions = this.currentInstructions.submeshInstructions;
			submeshInstructions.Clear(false);
			this.currentInstructions.attachmentList.Clear(false);
			int i = 0;
			while (i < count)
			{
				Slot slot = items[i];
				Attachment attachment = slot.attachment;
				RegionAttachment regionAttachment = attachment as RegionAttachment;
				object rendererObject;
				int num4;
				int num5;
				if (regionAttachment != null)
				{
					rendererObject = regionAttachment.RendererObject;
					num4 = 4;
					num5 = 6;
					goto IL_E1;
				}
				MeshAttachment meshAttachment = attachment as MeshAttachment;
				if (meshAttachment != null)
				{
					rendererObject = meshAttachment.RendererObject;
					num4 = meshAttachment.worldVerticesLength >> 1;
					num5 = meshAttachment.triangles.Length;
					goto IL_E1;
				}
				IL_1B8:
				i++;
				continue;
				IL_E1:
				Material material2 = (Material)((AtlasRegion)rendererObject).page.rendererObject;
				bool flag = count2 > 0 && this.separators.Contains(slot);
				if ((num > 0 && material.GetInstanceID() != material2.GetInstanceID()) || flag)
				{
					submeshInstructions.Add(new SubmeshInstruction
					{
						skeleton = skeleton,
						material = material,
						triangleCount = num2,
						vertexCount = num3,
						startSlot = startSlot,
						endSlot = i,
						firstVertexIndex = firstVertexIndex,
						forceSeparate = flag
					});
					num2 = 0;
					num3 = 0;
					firstVertexIndex = num;
					startSlot = i;
				}
				material = material2;
				num2 += num5;
				num3 += num4;
				num += num4;
				this.currentInstructions.attachmentList.Add(attachment);
				goto IL_1B8;
			}
			submeshInstructions.Add(new SubmeshInstruction
			{
				skeleton = skeleton,
				material = material,
				triangleCount = num2,
				vertexCount = num3,
				startSlot = startSlot,
				endSlot = count,
				firstVertexIndex = firstVertexIndex,
				forceSeparate = false
			});
			this.currentInstructions.vertexCount = num;
			return this.currentInstructions;
		}

		public MeshAndMaterials GenerateMesh(SubmeshedMeshInstruction meshInstructions)
		{
            SmartMesh next = this.doubleBufferedSmartMesh.GetNext();
			Mesh mesh = next.mesh;
			int count = meshInstructions.submeshInstructions.Count;
			ExposedList<SubmeshInstruction> submeshInstructions = meshInstructions.submeshInstructions;
			int vertexCount = meshInstructions.vertexCount;
			bool flag = ArraysMeshGenerator.EnsureTriangleBuffersSize(this.submeshBuffers, count, submeshInstructions.Items);
			bool flag2 = ArraysMeshGenerator.EnsureSize(vertexCount, ref this.meshVertices, ref this.meshUVs, ref this.meshColors32);
			Vector3[] meshVertices = this.meshVertices;
			float zspacing = this.ZSpacing;
			int count2 = meshInstructions.attachmentList.Count;
			Vector3 boundsMin;
			Vector3 boundsMax;
			if (count2 <= 0)
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
				if (zspacing > 0f)
				{
					boundsMin.z = 0f;
					boundsMax.z = zspacing * (float)(count2 - 1);
				}
				else
				{
					boundsMin.z = zspacing * (float)(count2 - 1);
					boundsMax.z = 0f;
				}
			}
			bool flag3 = flag2 || flag || next.StructureDoesntMatch(meshInstructions);
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				SubmeshInstruction submeshInstruction = submeshInstructions.Items[i];
				int startSlot = submeshInstruction.startSlot;
				int endSlot = submeshInstruction.endSlot;
				Skeleton skeleton = submeshInstruction.skeleton;
				ArraysMeshGenerator.FillVerts(skeleton, startSlot, endSlot, zspacing, base.PremultiplyVertexColors, meshVertices, this.meshUVs, this.meshColors32, ref num, ref this.attachmentVertexBuffer, ref boundsMin, ref boundsMax, true);
				if (flag3)
				{
                    SubmeshTriangleBuffer submeshTriangleBuffer = this.submeshBuffers.Items[i];
					bool isLastSubmesh = i == count - 1;
					ArraysMeshGenerator.FillTriangles(ref submeshTriangleBuffer.triangles, skeleton, submeshInstruction.triangleCount, submeshInstruction.firstVertexIndex, startSlot, endSlot, isLastSubmesh);
					submeshTriangleBuffer.triangleCount = submeshInstruction.triangleCount;
					submeshTriangleBuffer.firstVertex = submeshInstruction.firstVertexIndex;
				}
			}
			if (flag3)
			{
				mesh.Clear();
				this.sharedMaterials = meshInstructions.GetUpdatedMaterialArray(this.sharedMaterials);
			}
			next.Set(this.meshVertices, this.meshUVs, this.meshColors32, meshInstructions);
			mesh.bounds = ArraysMeshGenerator.ToBounds(boundsMin, boundsMax);
			if (flag3)
			{
				mesh.subMeshCount = count;
				for (int j = 0; j < count; j++)
				{
					mesh.SetTriangles(this.submeshBuffers.Items[j].triangles, j);
				}
				base.TryAddNormalsTo(mesh, vertexCount);
			}
			if (this.addTangents)
			{
				ArraysMeshGenerator.SolveTangents2DEnsureSize(ref this.meshTangents, ref this.tempTanBuffer, vertexCount);
				int k = 0;
				int num2 = count;
				while (k < num2)
				{
                    SubmeshTriangleBuffer submeshTriangleBuffer2 = this.submeshBuffers.Items[k];
					ArraysMeshGenerator.SolveTangents2DTriangles(this.tempTanBuffer, submeshTriangleBuffer2.triangles, submeshTriangleBuffer2.triangleCount, this.meshVertices, this.meshUVs, vertexCount);
					k++;
				}
				ArraysMeshGenerator.SolveTangents2DBuffer(this.meshTangents, this.tempTanBuffer, vertexCount);
			}
			return new MeshAndMaterials(next.mesh, this.sharedMaterials);
		}

		private readonly List<Slot> separators = new List<Slot>();

		private readonly DoubleBuffered<SmartMesh> doubleBufferedSmartMesh = new DoubleBuffered<SmartMesh>();

		private readonly SubmeshedMeshInstruction currentInstructions = new SubmeshedMeshInstruction();

		private readonly ExposedList<SubmeshTriangleBuffer> submeshBuffers = new ExposedList<SubmeshTriangleBuffer>();

		private Material[] sharedMaterials = new Material[0];

		private class SmartMesh
		{
			public void Set(Vector3[] verts, Vector2[] uvs, Color32[] colors, SubmeshedMeshInstruction instruction)
			{
				this.mesh.vertices = verts;
				this.mesh.uv = uvs;
				this.mesh.colors32 = colors;
				this.attachmentsUsed.Clear(false);
				this.attachmentsUsed.GrowIfNeeded(instruction.attachmentList.Capacity);
				this.attachmentsUsed.Count = instruction.attachmentList.Count;
				instruction.attachmentList.CopyTo(this.attachmentsUsed.Items);
				this.instructionsUsed.Clear(false);
				this.instructionsUsed.GrowIfNeeded(instruction.submeshInstructions.Capacity);
				this.instructionsUsed.Count = instruction.submeshInstructions.Count;
				instruction.submeshInstructions.CopyTo(this.instructionsUsed.Items);
			}

			public bool StructureDoesntMatch(SubmeshedMeshInstruction instructions)
			{
				if (instructions.attachmentList.Count != this.attachmentsUsed.Count)
				{
					return true;
				}
				if (instructions.submeshInstructions.Count != this.instructionsUsed.Count)
				{
					return true;
				}
				Attachment[] items = instructions.attachmentList.Items;
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
				SubmeshInstruction[] items3 = instructions.submeshInstructions.Items;
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
