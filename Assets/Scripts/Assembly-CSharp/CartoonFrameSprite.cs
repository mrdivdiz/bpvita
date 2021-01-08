using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class CartoonFrameSprite : MonoBehaviour
{
	public Vector2 Size
	{
		get
		{
			return new Vector2(base.transform.localScale.x * (float)this.m_spriteWidth / 768f * 20f, base.transform.localScale.y * (float)this.m_spriteHeight / 768f * 20f);
		}
	}

	public Mesh SpriteMesh
	{
		get
		{
			return this.m_spriteMesh;
		}
	}

	private void Awake()
	{
		MeshFilter meshFilter = base.GetComponent(typeof(MeshFilter)) as MeshFilter;
		if (!meshFilter.sharedMesh)
		{
			this.CreatePlane(meshFilter, this.m_UVx, this.m_UVy, this.m_spriteWidth, this.m_spriteHeight);
			this.MapUVToTexture(this.m_UVx, this.m_UVy, this.m_width, this.m_height);
		}
	}

	public void RebuildMesh()
	{
		MeshFilter mf = base.GetComponent(typeof(MeshFilter)) as MeshFilter;
		this.CreatePlane(mf, this.m_UVx, this.m_UVy, this.m_spriteWidth, this.m_spriteHeight);
		this.MapUVToTexture(this.m_UVx, this.m_UVy, this.m_width, this.m_height);
	}

	public void ResetSize()
	{
		this.m_textureWidth = this.m_width * base.GetComponent<Renderer>().sharedMaterial.mainTexture.width / this.m_subdivisionsX;
		this.m_textureHeight = this.m_height * base.GetComponent<Renderer>().sharedMaterial.mainTexture.height / this.m_subdivisionsY;
		this.m_spriteWidth = this.m_textureWidth;
		this.m_spriteHeight = this.m_textureHeight;
		this.RebuildMesh();
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
		Vector3[] array = new Vector3[]
		{
			new Vector3(-1f, -1f, 0f),
			new Vector3(-1f, 1f, 0f),
			new Vector3(1f, 1f, 0f),
			new Vector3(1f, -1f, 0f)
		};
		Vector2[] array2 = new Vector2[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			float num = 0.5f * (1f / (float)this.m_subdivisionsX / (float)(1024 / this.m_subdivisionsX)) * array[i].x;
			float num2 = 0.5f * (1f / (float)this.m_subdivisionsY / (float)(1024 / this.m_subdivisionsY)) * array[i].y;
			float x = Mathf.Clamp(array[i].x, 0f, 1f) * (1f / (float)this.m_subdivisionsX) * (float)this.m_width + (float)this.m_UVx * (1f / (float)this.m_subdivisionsX) - num;
			float y = Mathf.Clamp(array[i].y, 0f, 1f) * (1f / (float)this.m_subdivisionsY) * (float)this.m_height + (float)this.m_UVy * (1f / (float)this.m_subdivisionsY) - num2;
			array2[i] = new Vector2(x, y);
		}
		this.m_uvRect = new Rect(array2[0].x, array2[0].y, array2[2].x - array2[0].x, array2[2].y - array2[0].y);
		if (this.m_spriteMesh)
		{
			this.m_spriteMesh.uv = array2;
		}
	}

	public void SetUVs(Vector2[] newUVs)
	{
		this.m_spriteMesh.uv = newUVs;
	}

	public void CreatePlane(MeshFilter mf, int x, int y, int width, int height)
	{
		float num = 2f * (float)width * 10f / 768f;
		float num2 = 2f * (float)height * 10f / 768f;
		float num3 = (float)(2 * x - this.m_subdivisionsX) * 10f / 768f;
		float num4 = (float)(2 * y - this.m_subdivisionsY) * 10f / 768f;
		Mesh mesh = new Mesh();
		mesh.name = string.Concat(new object[]
		{
			"GeneratedMesh_",
			width,
			"x",
			height
		});
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
		array[0] = new Vector3(num3, num4, 0f);
		array[1] = new Vector3(num3, num4 + num2, 0f);
		array[2] = new Vector3(num3 + num, num4 + num2, 0f);
		array[3] = new Vector3(num3 + num, num4, 0f);
		mesh.vertices = array;
		mesh.triangles = triangles;
		mf.sharedMesh = mesh;
		this.m_spriteMesh = mf.sharedMesh;
		mf.sharedMesh.RecalculateNormals();
		mf.sharedMesh.RecalculateBounds();
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
			if (base.GetComponent<Renderer>().sharedMaterial && base.GetComponent<Renderer>().sharedMaterial.mainTexture)
			{
				this.m_textureWidth = this.m_width * base.GetComponent<Renderer>().sharedMaterial.mainTexture.width / this.m_subdivisionsX;
				this.m_textureHeight = this.m_height * base.GetComponent<Renderer>().sharedMaterial.mainTexture.height / this.m_subdivisionsY;
				if (this.m_spriteWidth == 0)
				{
					this.m_spriteWidth = this.m_textureWidth;
				}
				if (this.m_spriteHeight == 0)
				{
					this.m_spriteHeight = this.m_textureHeight;
				}
				if (!component.sharedMesh)
				{
					this.CreatePlane(component, this.m_UVx, this.m_UVy, this.m_spriteWidth, this.m_spriteHeight);
					this.MapUVToTexture(this.m_UVx, this.m_UVy, this.m_width, this.m_height);
				}
			}
		}
	}

	[HideInInspector]
	public int m_textureWidth;

	[HideInInspector]
	public int m_textureHeight;

	public int m_spriteWidth;

	public int m_spriteHeight;

	public int m_UVx;

	public int m_UVy;

	public int m_width = 16;

	public int m_height = 16;

	public int m_subdivisionsX;

	public int m_subdivisionsY;

	[HideInInspector]
	public Rect m_uvRect;

	public const float DefaultCameraSize = 10f;

	public const float DefaultCameraHeight = 20f;

	public const float DefaultScreenHeight = 768f;

	protected Mesh m_spriteMesh;
}
