using UnityEngine;

namespace Spine.Unity.MeshGeneration
{
    public interface ISimpleMeshGenerator
	{
		Mesh GenerateMesh(Skeleton skeleton);

		Mesh LastGeneratedMesh { get; }

		float Scale { set; }

		float ZSpacing { get; set; }

		bool PremultiplyVertexColors { get; set; }

		bool AddNormals { get; set; }

		bool AddTangents { get; set; }
	}
}
