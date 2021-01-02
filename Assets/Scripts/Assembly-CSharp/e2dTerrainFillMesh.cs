using System.Collections.Generic;
using UnityEngine;

public class e2dTerrainFillMesh : e2dTerrainMesh
{
	public e2dTerrainFillMesh(e2dTerrain terrain) : base(terrain)
	{
	}

	public MeshRenderer renderer
	{
		get
		{
			base.EnsureMeshComponentsExist();
			return base.transform.Find(e2dConstants.FILL_MESH_NAME).GetComponent<MeshRenderer>();
		}
	}

	public GameObject gameObject
	{
		get
		{
			return base.transform.Find(e2dConstants.FILL_MESH_NAME).gameObject;
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
		base.ResetMeshObjectsTransforms();
		List<Vector2> shapePolygon = this.GetShapePolygon();
		e2dTriangulator e2dTriangulator = new e2dTriangulator(shapePolygon.ToArray());
		List<int> list = e2dTriangulator.Triangulate();
		list.Reverse();
		int[] triangles = list.ToArray();
		Vector3[] array = new Vector3[shapePolygon.Count];
		Vector3[] array2 = new Vector3[array.Length];
		Vector2[] array3 = new Vector2[array.Length];
		for (int i = 0; i < shapePolygon.Count; i++)
		{
			array[i] = shapePolygon[i];
			array2[i] = Vector3.back;
			array3[i] = this.GetPointFillUV(shapePolygon[i]);
		}
		MeshFilter component = base.transform.Find(e2dConstants.FILL_MESH_NAME).GetComponent<MeshFilter>();
		component.sharedMesh.Clear();
		component.sharedMesh.vertices = array;
		component.sharedMesh.normals = array2;
		component.sharedMesh.uv = array3;
		component.sharedMesh.triangles = triangles;
		if (this.SomeMaterialsMissing())
		{
			this.RebuildMaterial();
		}
	}

	public bool IsMeshValid()
	{
		Transform transform = base.transform.Find(e2dConstants.FILL_MESH_NAME);
		if (transform == null)
		{
			return false;
		}
		MeshFilter component = transform.GetComponent<MeshFilter>();
		return !(component == null) && !(component.sharedMesh == null) && component.sharedMesh.vertexCount != 0;
	}

	public List<Vector2> GetShapePolygon()
	{
		List<Vector2> list = new List<Vector2>(base.TerrainCurve.Count + 3);
		Vector2[] boundaryRect = base.Boundary.GetBoundaryRect();
		Vector2 position = base.TerrainCurve[0].position;
		Vector2 position2 = base.TerrainCurve[base.TerrainCurve.Count - 1].position;
		int num = base.Boundary.ProjectStartPointToBoundary(ref position);
		int num2 = base.Boundary.ProjectEndPointToBoundary(ref position2);
		if (!base.Terrain.CurveClosed && position2 != base.TerrainCurve[base.TerrainCurve.Count - 1].position)
		{
			list.Add(position2);
		}
		if (!base.Terrain.CurveClosed)
		{
			bool flag = (position2 - boundaryRect[num2 + 1]).sqrMagnitude <= (position - boundaryRect[num2 + 1]).sqrMagnitude;
			int num3 = num2;
			while (flag || num3 != num)
			{
				flag = false;
				list.Add(boundaryRect[num3 + 1]);
				num3 = (num3 + 1) % 4;
			}
		}
		if (!base.Terrain.CurveClosed && position != base.TerrainCurve[0].position)
		{
			list.Add(position);
		}
		foreach (e2dCurveNode e2dCurveNode in base.TerrainCurve)
		{
			list.Add(e2dCurveNode.position);
		}
		if (list[list.Count - 1] == list[0])
		{
			list.RemoveAt(list.Count - 1);
		}
		return list;
	}

	private Vector2 GetPointFillUV(Vector2 curvePoint)
	{
		float x = (curvePoint.x - base.Terrain.FillTextureTileOffsetX) / base.Terrain.FillTextureTileWidth;
		float y = (curvePoint.y - base.Terrain.FillTextureTileOffsetY) / base.Terrain.FillTextureTileHeight;
		return new Vector2(x, y);
	}

	public void DestroyMesh()
	{
		base.EnsureMeshObjectsExist();
		MeshFilter component = base.transform.Find(e2dConstants.FILL_MESH_NAME).GetComponent<MeshFilter>();
		if (component && component.sharedMesh != null)
		{
			UnityEngine.Object.DestroyImmediate(component.sharedMesh);
		}
		MeshRenderer component2 = base.transform.Find(e2dConstants.FILL_MESH_NAME).GetComponent<MeshRenderer>();
		if (component2 && component2.sharedMaterials != null)
		{
			foreach (Material obj in component2.sharedMaterials)
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
		}
	}

	public void RebuildMaterial()
	{
		base.EnsureMeshComponentsExist();
		MeshRenderer component = base.transform.Find(e2dConstants.FILL_MESH_NAME).GetComponent<MeshRenderer>();
		Material[] array = component.sharedMaterials;
		if (array != null)
		{
			foreach (Material obj in array)
			{
				UnityEngine.Object.DestroyImmediate(obj, true);
			}
		}
		array = new Material[]
		{
			new Material(Shader.Find("_Custom/Unlit_Color_Geometry"))
		};
		if (!base.Terrain.FillTexture)
		{
			base.Terrain.FillTexture = (Texture)Resources.Load("defaultFillTexture", typeof(Texture));
		}
		array[0].mainTexture = base.Terrain.FillTexture;
		component.materials = array;
	}

	public bool SomeMaterialsMissing()
	{
		return base.transform.Find(e2dConstants.FILL_MESH_NAME).GetComponent<MeshRenderer>().sharedMaterial == null;
	}
}
