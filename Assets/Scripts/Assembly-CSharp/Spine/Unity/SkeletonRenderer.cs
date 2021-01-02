using System;
using System.Collections.Generic;
using Spine.Unity.MeshGeneration;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spine.Unity
{
    [ExecuteInEditMode]
	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	[DisallowMultipleComponent]
	[HelpURL("http://esotericsoftware.com/spine-unity-documentation#Rendering")]
	public class SkeletonRenderer : MonoBehaviour, ISkeletonComponent
	{
		public SkeletonDataAsset SkeletonDataAsset
		{
			get
			{
				return this.skeletonDataAsset;
			}
		}

		private event InstructionDelegate generateMeshOverride;

		public event InstructionDelegate GenerateMeshOverride
		{
			add
			{
				this.generateMeshOverride += value;
				if (this.disableRenderingOnOverride && this.generateMeshOverride != null)
				{
					this.Initialize(false);
					this.meshRenderer.enabled = false;
				}
			}
			remove
			{
				this.generateMeshOverride -= value;
				if (this.disableRenderingOnOverride && this.generateMeshOverride == null)
				{
					this.Initialize(false);
					this.meshRenderer.enabled = true;
				}
			}
		}

		public Dictionary<Material, Material> CustomMaterialOverride
		{
			get
			{
				return this.customMaterialOverride;
			}
		}

		public Dictionary<Slot, Material> CustomSlotMaterials
		{
			get
			{
				return this.customSlotMaterials;
			}
		}

		public Skeleton Skeleton
		{
			get
			{
				this.Initialize(false);
				return this.skeleton;
			}
		}

		public static T NewSpineGameObject<T>(SkeletonDataAsset skeletonDataAsset) where T : SkeletonRenderer
		{
			return SkeletonRenderer.AddSpineComponent<T>(new GameObject("New Spine GameObject"), skeletonDataAsset);
		}

		public static T AddSpineComponent<T>(GameObject gameObject, SkeletonDataAsset skeletonDataAsset) where T : SkeletonRenderer
		{
			T t = gameObject.AddComponent<T>();
			if (skeletonDataAsset != null)
			{
				t.skeletonDataAsset = skeletonDataAsset;
				t.Initialize(false);
			}
			return t;
		}

		public virtual void Awake()
		{
			this.Initialize(false);
		}

		public virtual void Initialize(bool overwrite)
		{
			if (this.valid && !overwrite)
			{
				return;
			}
			if (this.meshFilter != null)
			{
				this.meshFilter.sharedMesh = null;
			}
			this.meshRenderer = base.GetComponent<MeshRenderer>();
			if (this.meshRenderer != null)
			{
				this.meshRenderer.sharedMaterial = null;
			}
			this.currentInstructions.Clear();
			this.vertices = null;
			this.colors = null;
			this.uvs = null;
			this.sharedMaterials = new Material[0];
			this.submeshMaterials.Clear(true);
			this.submeshes.Clear(true);
			this.skeleton = null;
			this.valid = false;
			if (!this.skeletonDataAsset)
			{
				if (this.logErrors)
				{
				}
				return;
			}
			SkeletonData skeletonData = this.skeletonDataAsset.GetSkeletonData(false);
			if (skeletonData == null)
			{
				return;
			}
			this.valid = true;
			this.meshFilter = base.GetComponent<MeshFilter>();
			this.meshRenderer = base.GetComponent<MeshRenderer>();
			this.doubleBufferedMesh = new DoubleBuffered<SmartMesh>();
			this.vertices = new Vector3[0];
			this.skeleton = new Skeleton(skeletonData);
			if (!string.IsNullOrEmpty(this.initialSkinName) && this.initialSkinName != "default")
			{
				this.skeleton.SetSkin(this.initialSkinName);
			}
			this.separatorSlots.Clear();
			for (int i = 0; i < this.separatorSlotNames.Length; i++)
			{
				this.separatorSlots.Add(this.skeleton.FindSlot(this.separatorSlotNames[i]));
			}
			this.LateUpdate();
			if (this.OnRebuild != null)
			{
				this.OnRebuild(this);
			}
		}

		public virtual void LateUpdate()
		{
			if (!valid || (!meshRenderer.enabled && this.generateMeshOverride == null))
			{
				return;
			}
			ExposedList<Slot> drawOrder = skeleton.drawOrder;
			Slot[] items = drawOrder.Items;
			int count = drawOrder.Count;
			bool flag = renderMeshes;
			SmartMesh.Instruction instruction = currentInstructions;
			ExposedList<Attachment> attachments = instruction.attachments;
			attachments.Clear(clearArray: false);
			attachments.GrowIfNeeded(count);
			attachments.Count = count;
			Attachment[] items2 = instruction.attachments.Items;
			ExposedList<SubmeshInstruction> submeshInstructions = instruction.submeshInstructions;
			submeshInstructions.Clear(clearArray: false);
			bool flag2 = customSlotMaterials.Count > 0;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int firstVertexIndex = 0;
			int startSlot = 0;
			Material material = null;
			for (int i = 0; i < count; i++)
			{
				Slot slot = items[i];
				Attachment attachment = items2[i] = slot.attachment;
				RegionAttachment regionAttachment = attachment as RegionAttachment;
				object rendererObject;
				int num4;
				int num5;
				if (regionAttachment != null)
				{
					rendererObject = regionAttachment.RendererObject;
					num4 = 4;
					num5 = 6;
				}
				else
				{
					if (!flag)
					{
						continue;
					}
					MeshAttachment meshAttachment = attachment as MeshAttachment;
					if (meshAttachment == null)
					{
						continue;
					}
					rendererObject = meshAttachment.RendererObject;
					num4 = meshAttachment.worldVerticesLength >> 1;
					num5 = meshAttachment.triangles.Length;
				}
				Material value;
				if (flag2)
				{
					if (!customSlotMaterials.TryGetValue(slot, out value))
					{
						value = (Material)((AtlasRegion)rendererObject).page.rendererObject;
					}
				}
				else
				{
					value = (Material)((AtlasRegion)rendererObject).page.rendererObject;
				}
				bool flag3 = separatorSlots.Count > 0 && separatorSlots.Contains(slot);
				if (num > 0 && (material.GetInstanceID() != value.GetInstanceID() || flag3))
				{
					submeshInstructions.Add(new SubmeshInstruction
					{
						skeleton = skeleton,
						material = material,
						startSlot = startSlot,
						endSlot = i,
						triangleCount = num3,
						firstVertexIndex = firstVertexIndex,
						vertexCount = num2,
						forceSeparate = flag3
					});
					num3 = 0;
					num2 = 0;
					firstVertexIndex = num;
					startSlot = i;
				}
				material = value;
				num3 += num5;
				num += num4;
				num2 += num4;
			}
			if (num2 != 0)
			{
				submeshInstructions.Add(new SubmeshInstruction
				{
					skeleton = skeleton,
					material = material,
					startSlot = startSlot,
					endSlot = count,
					triangleCount = num3,
					firstVertexIndex = firstVertexIndex,
					vertexCount = num2,
					forceSeparate = false
				});
			}
			instruction.vertexCount = num;
			instruction.immutableTriangles = immutableTriangles;
			if (customMaterialOverride.Count > 0)
			{
				SubmeshInstruction[] items3 = submeshInstructions.Items;
				for (int j = 0; j < submeshInstructions.Count; j++)
				{
					Material material2 = items3[j].material;
					Material value2;
					if (customMaterialOverride.TryGetValue(material2, out value2))
					{
						items3[j].material = value2;
					}
				}
			}
			if (this.generateMeshOverride != null)
			{
				this.generateMeshOverride(instruction);
				if (disableRenderingOnOverride)
				{
					return;
				}
			}
			if (ArraysMeshGenerator.EnsureSize(num, ref vertices, ref uvs, ref colors) && calculateNormals)
			{
				Vector3[] array = normals = new Vector3[num];
				Vector3 vector = new Vector3(0f, 0f, -1f);
				for (int k = 0; k < num; k++)
				{
					array[k] = vector;
				}
			}
			Vector3 boundsMin = default(Vector3);
			Vector3 boundsMax = default(Vector3);
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
				if (zSpacing > 0f)
				{
					boundsMin.z = 0f;
					boundsMax.z = zSpacing * (float)(count - 1);
				}
				else
				{
					boundsMin.z = zSpacing * (float)(count - 1);
					boundsMax.z = 0f;
				}
			}
			int vertexIndex = 0;
			ArraysMeshGenerator.FillVerts(skeleton, 0, count, zSpacing, pmaVertexColors, vertices, uvs, colors, ref vertexIndex, ref tempVertices, ref boundsMin, ref boundsMax, flag);
			SmartMesh next = doubleBufferedMesh.GetNext();
			Mesh mesh = next.mesh;
			mesh.vertices = vertices;
			mesh.colors32 = colors;
			mesh.uv = uvs;
			mesh.bounds = ArraysMeshGenerator.ToBounds(boundsMin, boundsMax);
			SmartMesh.Instruction instructionUsed = next.instructionUsed;
			if (calculateNormals && instructionUsed.vertexCount < num)
			{
				mesh.normals = normals;
			}
			bool flag4 = CheckIfMustUpdateMeshStructure(instruction, instructionUsed);
			int count2 = submeshInstructions.Count;
			if (flag4)
			{
				ExposedList<Material> exposedList = submeshMaterials;
				exposedList.Clear(clearArray: false);
				int count3 = submeshes.Count;
				if (submeshes.Capacity < count2)
				{
					submeshes.Capacity = count2;
				}
				for (int l = count3; l < count2; l++)
				{
					submeshes.Items[l] = new ArraysMeshGenerator.SubmeshTriangleBuffer(submeshInstructions.Items[l].triangleCount);
				}
				submeshes.Count = count2;
				bool flag5 = !instruction.immutableTriangles;
				int m = 0;
				int num6 = count2 - 1;
				for (; m < count2; m++)
				{
					SubmeshInstruction submeshInstruction = submeshInstructions.Items[m];
					if (flag5 || m >= count3)
					{
						ArraysMeshGenerator.SubmeshTriangleBuffer submeshTriangleBuffer = submeshes.Items[m];
						int triangleCount = submeshInstruction.triangleCount;
						if (flag)
						{
							ArraysMeshGenerator.FillTriangles(ref submeshTriangleBuffer.triangles, skeleton, triangleCount, submeshInstruction.firstVertexIndex, submeshInstruction.startSlot, submeshInstruction.endSlot, m == num6);
							submeshTriangleBuffer.triangleCount = triangleCount;
						}
						else
						{
							ArraysMeshGenerator.FillTrianglesQuads(ref submeshTriangleBuffer.triangles, ref submeshTriangleBuffer.triangleCount, ref submeshTriangleBuffer.firstVertex, submeshInstruction.firstVertexIndex, triangleCount, m == num6);
						}
					}
					exposedList.Add(submeshInstruction.material);
				}
				mesh.subMeshCount = count2;
				for (int n = 0; n < count2; n++)
				{
					mesh.SetTriangles(submeshes.Items[n].triangles, n);
				}
			}
			if (calculateTangents)
			{
				ArraysMeshGenerator.SolveTangents2DEnsureSize(ref tangents, ref tempTanBuffer, vertices.Length);
				for (int num7 = 0; num7 < count2; num7++)
				{
					ArraysMeshGenerator.SubmeshTriangleBuffer submeshTriangleBuffer2 = submeshes.Items[num7];
					ArraysMeshGenerator.SolveTangents2DTriangles(tempTanBuffer, submeshTriangleBuffer2.triangles, submeshTriangleBuffer2.triangleCount, vertices, uvs, num);
				}
				ArraysMeshGenerator.SolveTangents2DBuffer(tangents, tempTanBuffer, num);
				mesh.tangents = tangents;
			}
			Material[] array2 = sharedMaterials;
			bool flag6 = flag4 || array2.Length != count2;
			if (!flag6)
			{
				SubmeshInstruction[] items4 = submeshInstructions.Items;
				int num8 = 0;
				for (int num9 = array2.Length; num8 < num9; num8++)
				{
					if (array2[num8].GetInstanceID() != items4[num8].material.GetInstanceID())
					{
						flag6 = true;
						break;
					}
				}
			}
			if (flag6)
			{
				if (submeshMaterials.Count == sharedMaterials.Length)
				{
					submeshMaterials.CopyTo(sharedMaterials);
				}
				else
				{
					sharedMaterials = submeshMaterials.ToArray();
				}
				meshRenderer.sharedMaterials = sharedMaterials;
			}
			meshFilter.sharedMesh = mesh;
			next.instructionUsed.Set(instruction);
		}

		private static bool CheckIfMustUpdateMeshStructure(SmartMesh.Instruction a, SmartMesh.Instruction b)
		{
			if (a.vertexCount != b.vertexCount)
			{
				return true;
			}
			if (a.immutableTriangles != b.immutableTriangles)
			{
				return true;
			}
			int count = b.attachments.Count;
			if (a.attachments.Count != count)
			{
				return true;
			}
			Attachment[] items = a.attachments.Items;
			Attachment[] items2 = b.attachments.Items;
			for (int i = 0; i < count; i++)
			{
				if (items[i] != items2[i])
				{
					return true;
				}
			}
			int count2 = a.submeshInstructions.Count;
			int count3 = b.submeshInstructions.Count;
			if (count2 != count3)
			{
				return true;
			}
			SubmeshInstruction[] items3 = a.submeshInstructions.Items;
			SubmeshInstruction[] items4 = b.submeshInstructions.Items;
			for (int j = 0; j < count3; j++)
			{
				SubmeshInstruction submeshInstruction = items3[j];
				SubmeshInstruction submeshInstruction2 = items4[j];
				if (submeshInstruction.vertexCount != submeshInstruction2.vertexCount || submeshInstruction.startSlot != submeshInstruction2.startSlot || submeshInstruction.endSlot != submeshInstruction2.endSlot || submeshInstruction.triangleCount != submeshInstruction2.triangleCount || submeshInstruction.firstVertexIndex != submeshInstruction2.firstVertexIndex)
				{
					return true;
				}
			}
			return false;
		}

		public SkeletonRendererDelegate OnRebuild;

		public SkeletonDataAsset skeletonDataAsset;

		public string initialSkinName;

		[FormerlySerializedAs("submeshSeparators")]
		[SpineSlot("", "", false)]
		public string[] separatorSlotNames = new string[0];

		[NonSerialized]
		public readonly List<Slot> separatorSlots = new List<Slot>();

		public float zSpacing;

		public bool renderMeshes = true;

		public bool immutableTriangles;

		public bool pmaVertexColors = true;

		public bool calculateNormals;

		public bool calculateTangents;

		public bool logErrors;

		public bool disableRenderingOnOverride = true;

		[NonSerialized]
		private readonly Dictionary<Material, Material> customMaterialOverride = new Dictionary<Material, Material>();

		[NonSerialized]
		private readonly Dictionary<Slot, Material> customSlotMaterials = new Dictionary<Slot, Material>();

		private MeshRenderer meshRenderer;

		private MeshFilter meshFilter;

		[NonSerialized]
		public bool valid;

		[NonSerialized]
		public Skeleton skeleton;

		private DoubleBuffered<SmartMesh> doubleBufferedMesh;

		private readonly SmartMesh.Instruction currentInstructions = new SmartMesh.Instruction();

		private readonly ExposedList<ArraysMeshGenerator.SubmeshTriangleBuffer> submeshes = new ExposedList<ArraysMeshGenerator.SubmeshTriangleBuffer>();

		private readonly ExposedList<Material> submeshMaterials = new ExposedList<Material>();

		private Material[] sharedMaterials = new Material[0];

		private float[] tempVertices = new float[8];

		private Vector3[] vertices;

		private Color32[] colors;

		private Vector2[] uvs;

		private Vector3[] normals;

		private Vector4[] tangents;

		private Vector2[] tempTanBuffer;

		public delegate void SkeletonRendererDelegate(SkeletonRenderer skeletonRenderer);

		public delegate void InstructionDelegate(SmartMesh.Instruction instruction);

		public class SmartMesh
		{
			public Mesh mesh = SpineMesh.NewMesh();

			public Instruction instructionUsed = new Instruction();

			public class Instruction
			{
				public void Clear()
				{
					this.attachments.Clear(false);
					this.submeshInstructions.Clear(false);
				}

				public void Set(Instruction other)
				{
					this.immutableTriangles = other.immutableTriangles;
					this.vertexCount = other.vertexCount;
					this.attachments.Clear(false);
					this.attachments.GrowIfNeeded(other.attachments.Capacity);
					this.attachments.Count = other.attachments.Count;
					other.attachments.CopyTo(this.attachments.Items);
					this.submeshInstructions.Clear(false);
					this.submeshInstructions.GrowIfNeeded(other.submeshInstructions.Capacity);
					this.submeshInstructions.Count = other.submeshInstructions.Count;
					other.submeshInstructions.CopyTo(this.submeshInstructions.Items);
				}

				public bool immutableTriangles;

				public int vertexCount = -1;

				public readonly ExposedList<Attachment> attachments = new ExposedList<Attachment>();

				public readonly ExposedList<SubmeshInstruction> submeshInstructions = new ExposedList<SubmeshInstruction>();
			}
		}
	}
}
