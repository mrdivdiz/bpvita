using UnityEngine;

namespace Spine.Unity.MeshGeneration
{
    public static class SubmeshInstructionExtensions
	{
		public static Material[] GetUpdatedMaterialArray(this ExposedList<SubmeshInstruction> instructions, Material[] materials)
		{
			int count = instructions.Count;
			if (count != materials.Length)
			{
				materials = new Material[count];
			}
			int i = 0;
			int num = materials.Length;
			while (i < num)
			{
				materials[i] = instructions.Items[i].material;
				i++;
			}
			return materials;
		}
	}
}
