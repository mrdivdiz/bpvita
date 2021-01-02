using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class UnmanagedSprite : MonoBehaviour
{
	public Renderer renderer
	{
		get
		{
			if (this.cachedRenderer == null)
			{
				this.cachedRenderer = base.GetComponent<Renderer>();
			}
			return this.cachedRenderer;
		}
	}

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
			this.CreatePlane(meshFilter, this.m_spriteWidth, this.m_spriteHeight);
			this.MapUVToTexture(this.m_UVx, this.m_UVy, this.m_width, this.m_height);
		}
		this.m_meshFilter = meshFilter;
	}

	public void RebuildMesh()
	{
		MeshFilter mf = base.GetComponent(typeof(MeshFilter)) as MeshFilter;
		this.CreatePlane(mf, this.m_spriteWidth, this.m_spriteHeight);
		this.MapUVToTexture(this.m_UVx, this.m_UVy, this.m_width, this.m_height);
		if (this.m_updateCollider)
		{
			this.UpdateCollider();
		}
	}

	public void ResetSize()
	{
		this.m_textureWidth = this.m_width * base.GetComponent<Renderer>().sharedMaterial.mainTexture.width / this.m_atlasGridSubdivisions;
		this.m_textureHeight = this.m_height * base.GetComponent<Renderer>().sharedMaterial.mainTexture.height / this.m_atlasGridSubdivisions;
		this.m_spriteWidth = (int)(this.m_scale * (float)(this.m_textureWidth - 2 * this.m_border));
		this.m_spriteHeight = (int)(this.m_scale * (float)(this.m_textureHeight - 2 * this.m_border));
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
		Vector2[] array = this.CalculateUVs(this.m_UVx, this.m_UVy, this.m_width, this.m_height);
		this.m_uvRect = new Rect(array[0].x, array[0].y, array[2].x - array[0].x, array[2].y - array[0].y);
		this.m_spriteMesh.uv = array;
	}

	public Vector2[] CalculateUVs(int UVx, int UVy, int width, int height)
	{
		float num = 1f / (float)this.m_atlasGridSubdivisions;
		float num2 = 0.00048828125f;
		float num3 = (float)this.m_border / 1024f;
		float num4 = (float)UVx * num + num2 + num3;
		float num5 = (float)UVy * num + num2 + num3;
		float x = num4 + num * (float)width - 2f * num2 - 2f * num3;
		float y = num5 + num * (float)height - 2f * num2 - 2f * num3;
		return new Vector2[]
		{
			new Vector2(num4, num5),
			new Vector2(num4, y),
			new Vector2(x, y),
			new Vector2(x, num5)
		};
	}

	public void ChangeUVs(Vector2[] uv)
	{
		this.m_meshFilter.mesh.uv = uv;
	}

	public void Instantiate()
	{
	}

	public void CreatePlane(MeshFilter mf, int width, int height)
	{
		float num = (float)width * 10f / 768f;
		float num2 = (float)height * 10f / 768f;
		mf.sharedMesh = new Mesh
		{
			name = string.Concat(new object[]
			{
				"GeneratedMesh_",
				width,
				"x",
				height
			}),
			vertices = new Vector3[]
			{
				new Vector3(-num, -num2, 0f),
				new Vector3(-num, num2, 0f),
				new Vector3(num, num2, 0f),
				new Vector3(num, -num2, 0f)
			},
			triangles = new int[]
			{
				0,
				1,
				2,
				2,
				3,
				0
			}
		};
		this.m_spriteMesh = mf.sharedMesh;
		mf.sharedMesh.RecalculateNormals();
		mf.sharedMesh.RecalculateBounds();
	}

	private void UpdateCollider()
	{
		BoxCollider component = base.GetComponent<BoxCollider>();
		if (component)
		{
			float z = component.size.z;
			component.center = this.SpriteMesh.bounds.center;
			Vector3 size = 2f * this.SpriteMesh.bounds.extents;
			size.z = z;
			component.size = size;
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
			if (base.GetComponent<Renderer>().sharedMaterial && base.GetComponent<Renderer>().sharedMaterial.mainTexture)
			{
				this.m_textureWidth = this.m_width * base.GetComponent<Renderer>().sharedMaterial.mainTexture.width / this.m_atlasGridSubdivisions;
				this.m_textureHeight = this.m_height * base.GetComponent<Renderer>().sharedMaterial.mainTexture.height / this.m_atlasGridSubdivisions;
				if (this.m_spriteWidth == 0)
				{
					this.m_spriteWidth = (int)(this.m_scale * (float)this.m_textureWidth);
				}
				if (this.m_spriteHeight == 0)
				{
					this.m_spriteHeight = (int)(this.m_scale * (float)this.m_textureHeight);
				}
				if (!component.sharedMesh)
				{
					this.CreatePlane(component, this.m_spriteWidth, this.m_spriteHeight);
					this.MapUVToTexture(this.m_UVx, this.m_UVy, this.m_width, this.m_height);
				}
			}
		}
	}

	private Renderer cachedRenderer;

	[HideInInspector]
	public int m_textureWidth;

	[HideInInspector]
	public int m_textureHeight;

	public float m_scale = 1f;

	public int m_spriteWidth;

	public int m_spriteHeight;

	public int m_UVx;

	public int m_UVy;

	public int m_width = 16;

	public int m_height = 16;

	public int m_atlasGridSubdivisions = 16;

	public int m_border;

	public bool m_updateCollider;

	[HideInInspector]
	public Rect m_uvRect;

	public const float DefaultCameraSize = 10f;

	public const float DefaultCameraHeight = 20f;

	public const float DefaultScreenHeight = 768f;

	public const float DefaultAtlasSize = 1024f;

	protected Mesh m_spriteMesh;

	protected MeshFilter m_meshFilter;
}
