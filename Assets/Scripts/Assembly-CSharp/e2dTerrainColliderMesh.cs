using System.Collections.Generic;
using UnityEngine;

public class e2dTerrainColliderMesh : e2dTerrainMesh
{
	public e2dTerrainColliderMesh(e2dTerrain terrain) : base(terrain)
	{
	}

	public MeshCollider collider
	{
		get
		{
			base.EnsureMeshComponentsExist();
			return base.transform.Find(e2dConstants.COLLIDER_MESH_NAME).GetComponent<MeshCollider>();
		}
	}

	public GameObject gameObject
	{
		get
		{
			return base.transform.Find(e2dConstants.COLLIDER_MESH_NAME).gameObject;
		}
	}

	public void RebuildMesh()
	{
		if (base.TerrainCurve.Count < 2 || base.Terrain.CurveIntercrossing)
		{
			this.DestroyMesh();
			return;
		}
		base.EnsureMeshComponentsExist();
		List<Vector2> shapePolygon = base.Terrain.FillMesh.GetShapePolygon();
		Vector3[] array = new Vector3[2 * shapePolygon.Count];
		Vector3[] array2 = new Vector3[array.Length];
		int[] array3 = new int[6 * shapePolygon.Count];
		for (int i = 0; i < shapePolygon.Count; i++)
		{
			int num = 2 * i;
			array[num] = new Vector3(shapePolygon[i].x, shapePolygon[i].y, -0.5f * e2dConstants.COLLISION_MESH_Z_DEPTH);
			array[num + 1] = new Vector3(shapePolygon[i].x, shapePolygon[i].y, 0.5f * e2dConstants.COLLISION_MESH_Z_DEPTH);
			int num2 = i - 1;
			if (num2 < 0)
			{
				num2 += shapePolygon.Count;
			}
			int num3 = i + 1;
			if (num3 >= shapePolygon.Count)
			{
				num3 -= shapePolygon.Count;
			}
			Vector2 a = new Vector2(shapePolygon[i].y - shapePolygon[num2].y, shapePolygon[num2].x - shapePolygon[num2].x);
			Vector2 b = new Vector2(shapePolygon[num3].y - shapePolygon[i].y, shapePolygon[i].x - shapePolygon[num3].x);
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
		MeshCollider component = base.transform.Find(e2dConstants.COLLIDER_MESH_NAME).GetComponent<MeshCollider>();
		component.sharedMesh.Clear();
		component.sharedMesh.vertices = array;
		component.sharedMesh.triangles = array3;
		base.ResetMeshObjectsTransforms();
	}

	public void ResetMesh()
	{
		MeshCollider component = base.transform.Find(e2dConstants.COLLIDER_MESH_NAME).GetComponent<MeshCollider>();
		component.sharedMesh.Clear();
		base.ResetMeshObjectsTransforms();
	}

	public void DestroyMesh()
	{
		base.EnsureMeshObjectsExist();
		MeshCollider component = base.transform.Find(e2dConstants.COLLIDER_MESH_NAME).GetComponent<MeshCollider>();
		if (component && component.sharedMesh != null)
		{
			UnityEngine.Object.DestroyImmediate(component.sharedMesh);
		}
	}
}
