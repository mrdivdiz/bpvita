using UnityEngine;

public class SpriteManager : MonoBehaviour
{
	public Mesh SpriteMesh
	{
		get
		{
			return this.m_spriteMesh;
		}
	}

	private void Awake()
	{
		MeshFilter mf = base.GetComponent(typeof(MeshFilter)) as MeshFilter;
		this.CreatePlane(mf);
		this.MapUVToTexture(this.m_UVx, this.m_UVy, this.m_width, this.m_height);
	}

	public void MapUVToTexture(int UVx, int UVy, int width, int height)
	{
		if (this.m_spriteMesh == null)
		{
			return;
		}
		this.m_UVx = UVx;
		this.m_UVy = UVy;
		this.m_width = width;
		this.m_height = height;
		Vector3[] vertices = this.m_spriteMesh.vertices;
		Vector2[] array = new Vector2[vertices.Length];
		for (int i = 0; i < array.Length; i++)
		{
			float num = 0.5f * (1f / (float)this.m_atlasGridSubdivisions / (float)(1024 / this.m_atlasGridSubdivisions)) * vertices[i].x;
			float num2 = 0.5f * (1f / (float)this.m_atlasGridSubdivisions / (float)(1024 / this.m_atlasGridSubdivisions)) * vertices[i].y;
			float x = Mathf.Clamp(vertices[i].x, 0f, 1f) * (1f / (float)this.m_atlasGridSubdivisions) * (float)this.m_width + (float)this.m_UVx * (1f / (float)this.m_atlasGridSubdivisions) - num;
			float y = Mathf.Clamp(vertices[i].y, 0f, 1f) * (1f / (float)this.m_atlasGridSubdivisions) * (float)this.m_height + (float)this.m_UVy * (1f / (float)this.m_atlasGridSubdivisions) - num2;
			array[i] = new Vector2(x, y);
		}
		this.m_spriteMesh.uv = array;
	}

	public void SetUVs(Vector2[] newUVs)
	{
		this.m_spriteMesh.uv = newUVs;
	}

	public void CreatePlane(MeshFilter mf)
	{
		if (!this.m_meshCreated)
		{
			Mesh mesh = new Mesh();
			mesh.name = "PreviewMesh_1x1";
			Vector3[] array = new Vector3[4];
			int[] triangles = new int[]
			{
				0,
				1,
				2,
				2,
				3,
				0
			};
			array[0] = new Vector3(-1f, -1f, 0f);
			array[1] = new Vector3(-1f, 1f, 0f);
			array[2] = new Vector3(1f, 1f, 0f);
			array[3] = new Vector3(1f, -1f, 0f);
			mesh.vertices = array;
			mesh.triangles = triangles;
			mf.sharedMesh = mesh;
			this.m_spriteMesh = mf.sharedMesh;
			mf.sharedMesh.RecalculateNormals();
			mf.sharedMesh.RecalculateBounds();
			this.m_meshCreated = true;
		}
	}

	private void OnDrawGizmos()
	{
		if (!Application.isPlaying)
		{
			MeshFilter component = base.transform.GetComponent<MeshFilter>();
			if (!component)
			{
				return;
			}
			this.CreatePlane(component);
			this.MapUVToTexture(this.m_UVx, this.m_UVy, this.m_width, this.m_height);
		}
	}

	public int m_UVx;

	public int m_UVy;

	public int m_width = 1;

	public int m_height = 1;

	public int m_atlasGridSubdivisions = 8;

	public int m_zOrder;

	public bool m_meshCreated;

	protected Mesh m_spriteMesh;
}
