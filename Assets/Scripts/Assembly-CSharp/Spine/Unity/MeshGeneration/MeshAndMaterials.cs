using UnityEngine;

namespace Spine.Unity.MeshGeneration
{
    public struct MeshAndMaterials
	{
		public MeshAndMaterials(Mesh mesh, Material[] materials)
		{
			this.mesh = mesh;
			this.materials = materials;
		}

		public readonly Mesh mesh;

		public readonly Material[] materials;
	}
}
