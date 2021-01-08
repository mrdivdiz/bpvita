using UnityEngine;

namespace Spine.Unity
{
    public class DoubleBufferedMesh
	{
		public Mesh GetNextMesh()
		{
			this.usingMesh1 = !this.usingMesh1;
			return (!this.usingMesh1) ? this.mesh2 : this.mesh1;
		}

		private readonly Mesh mesh1 = SpineMesh.NewMesh();

		private readonly Mesh mesh2 = SpineMesh.NewMesh();

		private bool usingMesh1;
	}
}
