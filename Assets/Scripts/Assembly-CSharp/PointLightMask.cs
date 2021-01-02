using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class PointLightMask : MonoBehaviour
{
	protected void Awake()
	{
		this.meshFilter = base.GetComponent<MeshFilter>();
		this.mesh = this.meshFilter.mesh;
	}

	public virtual void UpdateMesh()
	{
		this.radius = 1f;
		if (this.border != null)
		{
			this.borderMesh = this.border.GetComponent<MeshFilter>().mesh;
		}
		if (this.mesh.vertices.Length != this.vertexCount + 1 || this.radius != this.lastRadius)
		{
			this.mesh.Clear();
			this.newVertices = new Vector3[this.vertexCount + 1];
			this.newVertices[0] = Vector3.zero;
			this.newTriangles = new int[(this.vertexCount - 1) * 3 + 3];
			int num = 1;
			for (int i = 0; i < this.newTriangles.Length; i += 3)
			{
				this.newTriangles[i] = 0;
				this.newTriangles[i + 1] = num + 1;
				this.newTriangles[i + 2] = num;
				if (i >= (this.vertexCount - 1) * 3)
				{
					this.newTriangles[i] = 0;
					this.newTriangles[i + 1] = 1;
					this.newTriangles[i + 2] = num;
				}
				else
				{
					num++;
				}
			}
			for (int j = 0; j < this.vertexCount; j++)
			{
				float f = 6.28318548f / (float)this.vertexCount * (float)j;
				float x = this.newVertices[0].x + this.radius * Mathf.Cos(f);
				float y = this.newVertices[0].y + this.radius * Mathf.Sin(f);
				this.newVertices[j + 1] = new Vector3(x, y);
			}
			this.newUV = new Vector2[this.newVertices.Length];
			for (int k = 0; k < this.newUV.Length; k++)
			{
				this.newUV[k] = new Vector2(this.newVertices[k].x, this.newVertices[k].y);
			}
			if (this.border != null)
			{
				this.borderVertices = new Vector3[this.vertexCount + 1];
				this.borderTriangles = new int[(this.vertexCount - 1) * 3 + 3];
				num = 1;
				for (int l = 0; l < this.borderTriangles.Length; l += 3)
				{
					this.borderTriangles[l] = 0;
					this.borderTriangles[l + 1] = num + 1;
					this.borderTriangles[l + 2] = num;
					if (l >= (this.vertexCount - 1) * 3)
					{
						this.borderTriangles[l] = 0;
						this.borderTriangles[l + 1] = 1;
						this.borderTriangles[l + 2] = num;
					}
					else
					{
						num++;
					}
				}
				for (int m = 0; m < this.borderVertices.Length; m++)
				{
					this.borderVertices[m] = this.newVertices[m];
				}
				this.borderUV = new Vector2[this.borderVertices.Length];
				for (int n = 0; n < this.borderUV.Length; n++)
				{
					this.borderUV[n] = new Vector2(this.borderVertices[n].x, this.borderVertices[n].y);
				}
				this.borderMesh.vertices = this.borderVertices;
				this.borderMesh.uv = this.borderUV;
				this.borderMesh.triangles = this.borderTriangles;
				this.borderMesh.RecalculateNormals();
				this.borderMesh.RecalculateBounds();
			}
			this.mesh.vertices = this.newVertices;
			this.mesh.uv = this.newUV;
			this.mesh.triangles = this.newTriangles;
			this.mesh.RecalculateNormals();
			this.mesh.RecalculateBounds();
			this.lastRadius = this.radius;
		}
	}

	public LightType lightType;

	public Transform lightSource;

	public GameObject border;

	public float radius = 1f;

	public int vertexCount = 100;

	public float borderWidth = 0.3f;

	[HideInInspector]
	public MeshFilter meshFilter;

	[HideInInspector]
	public float colliderSize;

	protected float lastRadius;

	protected Mesh mesh;

	protected Mesh borderMesh;

	protected Vector3[] newVertices;

	protected Vector2[] newUV;

	protected int[] newTriangles;

	protected Vector3[] borderVertices;

	protected Vector2[] borderUV;

	protected int[] borderTriangles;

	public enum LightType
	{
		PointLight,
		BeamLight
	}
}
