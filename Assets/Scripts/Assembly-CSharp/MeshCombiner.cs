using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshCombiner : MonoBehaviour
{
	public static void Combine(Transform obj)
	{
		MeshFilter[] componentsInChildren = obj.GetComponentsInChildren<MeshFilter>();
		CombineInstance[] array = new CombineInstance[componentsInChildren.Length];
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			array[i].mesh = componentsInChildren[i].sharedMesh;
			array[i].transform = componentsInChildren[i].transform.localToWorldMatrix;
			componentsInChildren[i].gameObject.isStatic = true;
		}
		obj.GetComponent<MeshFilter>().sharedMesh = new Mesh();
		obj.GetComponent<MeshFilter>().sharedMesh.name = "TerrainMesh";
		obj.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(array);
		obj.gameObject.SetActive(true);
		obj.gameObject.GetComponent<Renderer>().enabled = false;
		obj.gameObject.isStatic = true;
	}
}
