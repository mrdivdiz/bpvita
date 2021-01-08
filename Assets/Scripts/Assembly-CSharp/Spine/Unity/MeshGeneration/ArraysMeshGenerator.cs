using UnityEngine;

namespace Spine.Unity.MeshGeneration
{
    public class ArraysMeshGenerator
	{
		public bool PremultiplyVertexColors { get; set; }

		public bool AddNormals
		{
			get
			{
				return this.addNormals;
			}
			set
			{
				this.addNormals = value;
			}
		}

		public bool AddTangents
		{
			get
			{
				return this.addTangents;
			}
			set
			{
				this.addTangents = value;
			}
		}

		public void TryAddNormalsTo(Mesh mesh, int targetVertexCount)
		{
			if (this.addNormals)
			{
				bool flag = this.meshNormals == null || this.meshNormals.Length < targetVertexCount;
				if (flag)
				{
					this.meshNormals = new Vector3[targetVertexCount];
					Vector3 vector = new Vector3(0f, 0f, -1f);
					Vector3[] array = this.meshNormals;
					for (int i = 0; i < targetVertexCount; i++)
					{
						array[i] = vector;
					}
				}
				mesh.normals = this.meshNormals;
			}
		}

		public static bool EnsureSize(int targetVertexCount, ref Vector3[] vertices, ref Vector2[] uvs, ref Color32[] colors)
		{
			Vector3[] array = vertices;
			bool flag = array == null || targetVertexCount > array.Length;
			if (flag)
			{
				vertices = new Vector3[targetVertexCount];
				colors = new Color32[targetVertexCount];
				uvs = new Vector2[targetVertexCount];
			}
			else
			{
				Vector3 zero = Vector3.zero;
				int i = targetVertexCount;
				int num = array.Length;
				while (i < num)
				{
					array[i] = zero;
					i++;
				}
			}
			return flag;
		}

		public static bool EnsureTriangleBuffersSize(ExposedList<SubmeshTriangleBuffer> submeshBuffers, int targetSubmeshCount, SubmeshInstruction[] instructionItems)
		{
			bool flag = submeshBuffers.Count < targetSubmeshCount;
			if (flag)
			{
				submeshBuffers.GrowIfNeeded(targetSubmeshCount - submeshBuffers.Count);
				int num = submeshBuffers.Count;
				while (submeshBuffers.Count < targetSubmeshCount)
				{
					submeshBuffers.Add(new SubmeshTriangleBuffer(instructionItems[num].triangleCount));
					num++;
				}
			}
			return flag;
		}

		public static void FillVerts(Skeleton skeleton, int startSlot, int endSlot, float zSpacing, bool pmaColors, Vector3[] verts, Vector2[] uvs, Color32[] colors, ref int vertexIndex, ref float[] tempVertBuffer, ref Vector3 boundsMin, ref Vector3 boundsMax, bool renderMeshes = true)
		{
			Color32 color = new Color32(0, 0, 0, 0);
			Slot[] items = skeleton.DrawOrder.Items;
			float num = skeleton.a * 255f;
			float r = skeleton.r;
			float g = skeleton.g;
			float b = skeleton.b;
			int num2 = vertexIndex;
			float[] array = tempVertBuffer;
			Vector3 vector = boundsMin;
			Vector3 vector2 = boundsMax;
			for (int i = startSlot; i < endSlot; i++)
			{
				Slot slot = items[i];
				Attachment attachment = slot.attachment;
				float z = (float)i * zSpacing;
				RegionAttachment regionAttachment = attachment as RegionAttachment;
				if (regionAttachment != null)
				{
					regionAttachment.ComputeWorldVertices(slot.bone, array);
					float num3 = array[0];
					float num4 = array[1];
					float num5 = array[2];
					float num6 = array[3];
					float num7 = array[4];
					float num8 = array[5];
					float num9 = array[6];
					float num10 = array[7];
					verts[num2].x = num3;
					verts[num2].y = num4;
					verts[num2].z = z;
					verts[num2 + 1].x = num9;
					verts[num2 + 1].y = num10;
					verts[num2 + 1].z = z;
					verts[num2 + 2].x = num5;
					verts[num2 + 2].y = num6;
					verts[num2 + 2].z = z;
					verts[num2 + 3].x = num7;
					verts[num2 + 3].y = num8;
					verts[num2 + 3].z = z;
					if (pmaColors)
					{
						color.a = (byte)(num * slot.a * regionAttachment.a);
						color.r = (byte)(r * slot.r * regionAttachment.r * (float)color.a);
						color.g = (byte)(g * slot.g * regionAttachment.g * (float)color.a);
						color.b = (byte)(b * slot.b * regionAttachment.b * (float)color.a);
						if (slot.data.blendMode == BlendMode.additive)
						{
							color.a = 0;
						}
					}
					else
					{
						color.a = (byte)(num * slot.a * regionAttachment.a);
						color.r = (byte)(r * slot.r * regionAttachment.r * 255f);
						color.g = (byte)(g * slot.g * regionAttachment.g * 255f);
						color.b = (byte)(b * slot.b * regionAttachment.b * 255f);
					}
					colors[num2] = color;
					colors[num2 + 1] = color;
					colors[num2 + 2] = color;
					colors[num2 + 3] = color;
					float[] uvs2 = regionAttachment.uvs;
					uvs[num2].x = uvs2[0];
					uvs[num2].y = uvs2[1];
					uvs[num2 + 1].x = uvs2[6];
					uvs[num2 + 1].y = uvs2[7];
					uvs[num2 + 2].x = uvs2[2];
					uvs[num2 + 2].y = uvs2[3];
					uvs[num2 + 3].x = uvs2[4];
					uvs[num2 + 3].y = uvs2[5];
					if (num3 < vector.x)
					{
						vector.x = num3;
					}
					else if (num3 > vector2.x)
					{
						vector2.x = num3;
					}
					if (num5 < vector.x)
					{
						vector.x = num5;
					}
					else if (num5 > vector2.x)
					{
						vector2.x = num5;
					}
					if (num7 < vector.x)
					{
						vector.x = num7;
					}
					else if (num7 > vector2.x)
					{
						vector2.x = num7;
					}
					if (num9 < vector.x)
					{
						vector.x = num9;
					}
					else if (num9 > vector2.x)
					{
						vector2.x = num9;
					}
					if (num4 < vector.y)
					{
						vector.y = num4;
					}
					else if (num4 > vector2.y)
					{
						vector2.y = num4;
					}
					if (num6 < vector.y)
					{
						vector.y = num6;
					}
					else if (num6 > vector2.y)
					{
						vector2.y = num6;
					}
					if (num8 < vector.y)
					{
						vector.y = num8;
					}
					else if (num8 > vector2.y)
					{
						vector2.y = num8;
					}
					if (num10 < vector.y)
					{
						vector.y = num10;
					}
					else if (num10 > vector2.y)
					{
						vector2.y = num10;
					}
					num2 += 4;
				}
				else if (renderMeshes)
				{
					MeshAttachment meshAttachment = attachment as MeshAttachment;
					if (meshAttachment != null)
					{
						int worldVerticesLength = meshAttachment.worldVerticesLength;
						if (array.Length < worldVerticesLength)
						{
							array = new float[worldVerticesLength];
						}
						meshAttachment.ComputeWorldVertices(slot, array);
						if (pmaColors)
						{
							color.a = (byte)(num * slot.a * meshAttachment.a);
							color.r = (byte)(r * slot.r * meshAttachment.r * (float)color.a);
							color.g = (byte)(g * slot.g * meshAttachment.g * (float)color.a);
							color.b = (byte)(b * slot.b * meshAttachment.b * (float)color.a);
							if (slot.data.blendMode == BlendMode.additive)
							{
								color.a = 0;
							}
						}
						else
						{
							color.a = (byte)(num * slot.a * meshAttachment.a);
							color.r = (byte)(r * slot.r * meshAttachment.r * 255f);
							color.g = (byte)(g * slot.g * meshAttachment.g * 255f);
							color.b = (byte)(b * slot.b * meshAttachment.b * 255f);
						}
						float[] uvs3 = meshAttachment.uvs;
						for (int j = 0; j < worldVerticesLength; j += 2)
						{
							float num11 = array[j];
							float num12 = array[j + 1];
							verts[num2].x = num11;
							verts[num2].y = num12;
							verts[num2].z = z;
							colors[num2] = color;
							uvs[num2].x = uvs3[j];
							uvs[num2].y = uvs3[j + 1];
							if (num11 < vector.x)
							{
								vector.x = num11;
							}
							else if (num11 > vector2.x)
							{
								vector2.x = num11;
							}
							if (num12 < vector.y)
							{
								vector.y = num12;
							}
							else if (num12 > vector2.y)
							{
								vector2.y = num12;
							}
							num2++;
						}
					}
				}
			}
			vertexIndex = num2;
			tempVertBuffer = array;
			boundsMin = vector;
			boundsMax = vector2;
		}

		public static void FillTriangles(ref int[] triangleBuffer, Skeleton skeleton, int triangleCount, int firstVertex, int startSlot, int endSlot, bool isLastSubmesh)
		{
			int num = triangleBuffer.Length;
			int[] array = triangleBuffer;
			if (isLastSubmesh)
			{
				if (num > triangleCount)
				{
					for (int i = triangleCount; i < num; i++)
					{
						array[i] = 0;
					}
				}
				else if (num < triangleCount)
				{
					triangleBuffer = (array = new int[triangleCount]);
				}
			}
			else if (num != triangleCount)
			{
				triangleBuffer = (array = new int[triangleCount]);
			}
			Slot[] items = skeleton.drawOrder.Items;
			int j = startSlot;
			int num2 = 0;
			int num3 = firstVertex;
			while (j < endSlot)
			{
				Attachment attachment = items[j].attachment;
				if (attachment is RegionAttachment)
				{
					array[num2] = num3;
					array[num2 + 1] = num3 + 2;
					array[num2 + 2] = num3 + 1;
					array[num2 + 3] = num3 + 2;
					array[num2 + 4] = num3 + 3;
					array[num2 + 5] = num3 + 1;
					num2 += 6;
					num3 += 4;
				}
				else
				{
					MeshAttachment meshAttachment = attachment as MeshAttachment;
					if (meshAttachment != null)
					{
						int[] triangles = meshAttachment.triangles;
						int k = 0;
						int num4 = triangles.Length;
						while (k < num4)
						{
							array[num2] = num3 + triangles[k];
							k++;
							num2++;
						}
						num3 += meshAttachment.worldVerticesLength >> 1;
					}
				}
				j++;
			}
		}

		public static void FillTrianglesQuads(ref int[] triangleBuffer, ref int storedTriangleCount, ref int storedFirstVertex, int instructionsFirstVertex, int instructionTriangleCount, bool isLastSubmesh)
		{
			int num = triangleBuffer.Length;
			if (isLastSubmesh && num > instructionTriangleCount)
			{
				for (int i = instructionTriangleCount; i < num; i++)
				{
					triangleBuffer[i] = 0;
				}
				storedTriangleCount = instructionTriangleCount;
			}
			else if (num != instructionTriangleCount)
			{
				triangleBuffer = new int[instructionTriangleCount];
				storedTriangleCount = 0;
			}
			int[] array = triangleBuffer;
			if (storedFirstVertex != instructionsFirstVertex || storedTriangleCount < instructionTriangleCount)
			{
				storedTriangleCount = instructionTriangleCount;
				storedFirstVertex = instructionsFirstVertex;
				int num2 = instructionsFirstVertex;
				int j = 0;
				while (j < instructionTriangleCount)
				{
					array[j] = num2;
					array[j + 1] = num2 + 2;
					array[j + 2] = num2 + 1;
					array[j + 3] = num2 + 2;
					array[j + 4] = num2 + 3;
					array[j + 5] = num2 + 1;
					j += 6;
					num2 += 4;
				}
			}
		}

		public static Bounds ToBounds(Vector3 boundsMin, Vector3 boundsMax)
		{
			Vector3 vector = boundsMax - boundsMin;
			Vector3 center = boundsMin + vector * 0.5f;
			return new Bounds(center, vector);
		}

		public static void SolveTangents2DEnsureSize(ref Vector4[] tangentBuffer, ref Vector2[] tempTanBuffer, int vertexCount)
		{
			if (tangentBuffer == null || tangentBuffer.Length < vertexCount)
			{
				tangentBuffer = new Vector4[vertexCount];
			}
			if (tempTanBuffer == null || tempTanBuffer.Length < vertexCount * 2)
			{
				tempTanBuffer = new Vector2[vertexCount * 2];
			}
		}

		public static void SolveTangents2DTriangles(Vector2[] tempTanBuffer, int[] triangles, int triangleCount, Vector3[] vertices, Vector2[] uvs, int vertexCount)
		{
			for (int i = 0; i < triangleCount; i += 3)
			{
				int num = triangles[i];
				int num2 = triangles[i + 1];
				int num3 = triangles[i + 2];
				Vector3 vector = vertices[num];
				Vector3 vector2 = vertices[num2];
				Vector3 vector3 = vertices[num3];
				Vector2 vector4 = uvs[num];
				Vector2 vector5 = uvs[num2];
				Vector2 vector6 = uvs[num3];
				float num4 = vector2.x - vector.x;
				float num5 = vector3.x - vector.x;
				float num6 = vector2.y - vector.y;
				float num7 = vector3.y - vector.y;
				float num8 = vector5.x - vector4.x;
				float num9 = vector6.x - vector4.x;
				float num10 = vector5.y - vector4.y;
				float num11 = vector6.y - vector4.y;
				float num12 = num8 * num11 - num9 * num10;
				float num13 = (num12 != 0f) ? (1f / num12) : 0f;
				Vector2 vector7;
				vector7.x = (num11 * num4 - num10 * num5) * num13;
				vector7.y = (num11 * num6 - num10 * num7) * num13;
				tempTanBuffer[num] = (tempTanBuffer[num2] = (tempTanBuffer[num3] = vector7));
				Vector2 vector8;
				vector8.x = (num8 * num5 - num9 * num4) * num13;
				vector8.y = (num8 * num7 - num9 * num6) * num13;
				tempTanBuffer[vertexCount + num] = (tempTanBuffer[vertexCount + num2] = (tempTanBuffer[vertexCount + num3] = vector8));
			}
		}

		public static void SolveTangents2DBuffer(Vector4[] tangents, Vector2[] tempTanBuffer, int vertexCount)
		{
			Vector4 vector;
			vector.z = 0f;
			for (int i = 0; i < vertexCount; i++)
			{
				Vector2 vector2 = tempTanBuffer[i];
				float num = Mathf.Sqrt(vector2.x * vector2.x + vector2.y * vector2.y);
				if ((double)num > 1E-05)
				{
					float num2 = 1f / num;
					vector2.x *= num2;
					vector2.y *= num2;
				}
				Vector2 vector3 = tempTanBuffer[vertexCount + i];
				vector.x = vector2.x;
				vector.y = vector2.y;
				vector.w = (float)((vector2.y * vector3.x <= vector2.x * vector3.y) ? -1 : 1);
				tangents[i] = vector;
			}
		}

		protected bool addNormals;

		protected bool addTangents;

		protected float[] attachmentVertexBuffer = new float[8];

		protected Vector3[] meshVertices;

		protected Color32[] meshColors32;

		protected Vector2[] meshUVs;

		protected Vector3[] meshNormals;

		protected Vector4[] meshTangents;

		protected Vector2[] tempTanBuffer;

		public class SubmeshTriangleBuffer
		{
			public SubmeshTriangleBuffer()
			{
			}

			public SubmeshTriangleBuffer(int triangleCount)
			{
				this.triangles = new int[triangleCount];
			}

			public int[] triangles;

			public int triangleCount;

			public int firstVertex = -1;
		}
	}
}
