using System.Collections.Generic;
using UnityEngine;

public class TerrainColliderGenerator : MonoBehaviour
{
	private void Start()
	{
		e2dTerrain component = base.GetComponent<e2dTerrain>();
		List<Vector2> shapePolygon = component.FillMesh.GetShapePolygon();
		TerrainColliderGenerator.CreateCollider(base.gameObject, shapePolygon);
	}

	public static void CreateCollider(GameObject obj, List<Vector2> polygon)
	{
		Vector3[] array = new Vector3[2 * polygon.Count];
		Vector3[] array2 = new Vector3[array.Length];
		int[] array3 = new int[6 * polygon.Count];
		for (int i = 0; i < polygon.Count; i++)
		{
			int num = 2 * i;
			array[num] = new Vector3(polygon[i].x, polygon[i].y, -0.5f * e2dConstants.COLLISION_MESH_Z_DEPTH);
			array[num + 1] = new Vector3(polygon[i].x, polygon[i].y, 0.5f * e2dConstants.COLLISION_MESH_Z_DEPTH);
			int num2 = i - 1;
			if (num2 < 0)
			{
				num2 += polygon.Count;
			}
			int num3 = i + 1;
			if (num3 >= polygon.Count)
			{
				num3 -= polygon.Count;
			}
			Vector2 a = new Vector2(polygon[i].y - polygon[num2].y, polygon[num2].x - polygon[num2].x);
			Vector2 b = new Vector2(polygon[num3].y - polygon[i].y, polygon[i].x - polygon[num3].x);
			Vector3 vector = 0.5f * (a + b);
			vector.Normalize();
			array2[num] = vector;
			array2[num + 1] = vector;
			int num4 = 6 * i;
			array3[num4] = num % array.Length;
			array3[num4 + 1] = (num + 1) % array.Length;
			array3[num4 + 2] = (num + 2) % array.Length;
			array3[num4 + 3] = (num + 2) % array.Length;
			array3[num4 + 4] = (num + 1) % array.Length;
			array3[num4 + 5] = (num + 3) % array.Length;
		}
		MeshCollider component = obj.transform.Find(e2dConstants.COLLIDER_MESH_NAME).GetComponent<MeshCollider>();
		component.sharedMesh = new Mesh
		{
			vertices = array,
			triangles = array3
		};
		obj.transform.Find(e2dConstants.COLLIDER_MESH_NAME).transform.localPosition = Vector3.zero;
		obj.transform.Find(e2dConstants.COLLIDER_MESH_NAME).transform.localRotation = Quaternion.identity;
		obj.transform.Find(e2dConstants.COLLIDER_MESH_NAME).transform.localScale = Vector3.one;
		component.gameObject.layer = LayerMask.NameToLayer("Ground");
	}
}
