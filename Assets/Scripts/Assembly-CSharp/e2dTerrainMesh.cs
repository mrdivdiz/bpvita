using System.Collections.Generic;
using UnityEngine;

public abstract class e2dTerrainMesh
{
	public e2dTerrainMesh(e2dTerrain terrain)
	{
		this.mTerrain = terrain;
	}

	protected e2dTerrain Terrain
	{
		get
		{
			return this.mTerrain;
		}
	}

	protected Transform transform
	{
		get
		{
			return this.mTerrain.transform;
		}
	}

	protected List<e2dCurveNode> TerrainCurve
	{
		get
		{
			return this.mTerrain.TerrainCurve;
		}
	}

	protected List<e2dCurveTexture> CurveTextures
	{
		get
		{
			return this.mTerrain.CurveTextures;
		}
	}

	protected List<Texture2D> CurveControlTextures
	{
		get
		{
			return this.mTerrain.CurveMesh.CurveControlTextures;
		}
	}

	protected e2dTerrainBoundary Boundary
	{
		get
		{
			return this.mTerrain.Boundary;
		}
	}

	protected void ResetMeshObjectsTransforms()
	{
		this.transform.Find(e2dConstants.FILL_MESH_NAME).transform.localPosition = Vector3.zero;
		this.transform.Find(e2dConstants.FILL_MESH_NAME).transform.localRotation = Quaternion.identity;
		this.transform.Find(e2dConstants.FILL_MESH_NAME).transform.localScale = Vector3.one;
		this.transform.Find(e2dConstants.CURVE_MESH_NAME).transform.localPosition = Vector3.zero;
		this.transform.Find(e2dConstants.CURVE_MESH_NAME).transform.localRotation = Quaternion.identity;
		this.transform.Find(e2dConstants.CURVE_MESH_NAME).transform.localScale = Vector3.one;
		this.transform.Find(e2dConstants.COLLIDER_MESH_NAME).transform.localPosition = Vector3.zero;
		this.transform.Find(e2dConstants.COLLIDER_MESH_NAME).transform.localRotation = Quaternion.identity;
		this.transform.Find(e2dConstants.COLLIDER_MESH_NAME).transform.localScale = Vector3.one;
	}

	protected void EnsureMeshObjectsExist()
	{
		if (this.transform.Find(e2dConstants.FILL_MESH_NAME) == null)
		{
			GameObject gameObject = new GameObject(e2dConstants.FILL_MESH_NAME);
			gameObject.transform.parent = this.transform;
		}
		if (this.transform.Find(e2dConstants.CURVE_MESH_NAME) == null)
		{
			GameObject gameObject2 = new GameObject(e2dConstants.CURVE_MESH_NAME);
			gameObject2.transform.parent = this.transform;
		}
		if (this.transform.Find(e2dConstants.COLLIDER_MESH_NAME) == null)
		{
			GameObject gameObject3 = new GameObject(e2dConstants.COLLIDER_MESH_NAME);
			gameObject3.transform.parent = this.transform;
		}
	}

	protected void EnsureMeshComponentsExist()
	{
		this.EnsureMeshObjectsExist();
		GameObject gameObject = this.transform.Find(e2dConstants.FILL_MESH_NAME).gameObject;
		this.EnsureMeshFilterExists(gameObject);
		this.EnsureMeshRendererExists(gameObject);
		this.EnsureScriptsAttached(gameObject);
		gameObject = this.transform.Find(e2dConstants.CURVE_MESH_NAME).gameObject;
		this.EnsureMeshFilterExists(gameObject);
		this.EnsureMeshRendererExists(gameObject);
		this.EnsureScriptsAttached(gameObject);
		gameObject = this.transform.Find(e2dConstants.COLLIDER_MESH_NAME).gameObject;
		this.EnsureMeshColliderExists(gameObject);
		this.EnsureScriptsAttached(gameObject);
	}

	protected void EnsureScriptsAttached(GameObject meshObject)
	{
		if (meshObject.GetComponent<e2dMeshObject>() == null)
		{
			meshObject.AddComponent<e2dMeshObject>();
		}
	}

	protected void EnsureMeshFilterExists(GameObject meshObject)
	{
		if (meshObject.GetComponent<MeshFilter>() == null)
		{
			Mesh mesh = new Mesh();
			mesh.name = meshObject.name;
			meshObject.AddComponent<MeshFilter>().mesh = mesh;
		}
		else if (meshObject.GetComponent<MeshFilter>().sharedMesh == null)
		{
			Mesh mesh2 = new Mesh();
			mesh2.name = meshObject.name;
			meshObject.GetComponent<MeshFilter>().mesh = mesh2;
		}
	}

	protected void EnsureMeshRendererExists(GameObject meshObject)
	{
		if (meshObject.GetComponent<MeshRenderer>() == null)
		{
			meshObject.AddComponent<MeshRenderer>();
		}
	}

	protected void EnsureMeshColliderExists(GameObject meshObject)
	{
		if (meshObject.GetComponent<MeshCollider>() == null)
		{
			Mesh mesh = new Mesh();
			mesh.name = meshObject.name;
			meshObject.AddComponent<MeshCollider>().sharedMesh = mesh;
		}
		else if (meshObject.GetComponent<MeshCollider>().sharedMesh == null)
		{
			Mesh mesh2 = new Mesh();
			mesh2.name = meshObject.name;
			meshObject.GetComponent<MeshCollider>().sharedMesh = mesh2;
		}
	}

	public void DeleteAllSubobjects()
	{
		this.EnsureMeshObjectsExist();
		UnityEngine.Object.DestroyImmediate(this.transform.Find(e2dConstants.FILL_MESH_NAME).gameObject);
		UnityEngine.Object.DestroyImmediate(this.transform.Find(e2dConstants.CURVE_MESH_NAME).gameObject);
		UnityEngine.Object.DestroyImmediate(this.transform.Find(e2dConstants.COLLIDER_MESH_NAME).gameObject);
	}

	private e2dTerrain mTerrain;
}
