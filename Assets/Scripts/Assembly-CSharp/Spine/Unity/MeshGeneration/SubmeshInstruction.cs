using UnityEngine;

namespace Spine.Unity.MeshGeneration
{
    public struct SubmeshInstruction
	{
		public int SlotCount
		{
			get
			{
				return this.endSlot - this.startSlot;
			}
		}

		public Skeleton skeleton;

		public int startSlot;

		public int endSlot;

		public Material material;

		public int triangleCount;

		public int vertexCount;

		public int firstVertexIndex;

		public bool forceSeparate;
	}
}
