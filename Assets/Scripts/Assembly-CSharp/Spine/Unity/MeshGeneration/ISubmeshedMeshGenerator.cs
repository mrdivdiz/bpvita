using System.Collections.Generic;

namespace Spine.Unity.MeshGeneration
{
    public interface ISubmeshedMeshGenerator
	{
		SubmeshedMeshInstruction GenerateInstruction(Skeleton skeleton);

		MeshAndMaterials GenerateMesh(SubmeshedMeshInstruction wholeMeshInstruction);

		List<Slot> Separators { get; }

		float ZSpacing { get; set; }

		bool AddNormals { get; set; }

		bool AddTangents { get; set; }
	}
}
