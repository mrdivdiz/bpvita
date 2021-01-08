using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class Sprite : MonoBehaviour, SpriteMeshGenerator
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

	public string Id
	{
		get
		{
			return this.m_id;
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
			return base.GetComponent<MeshFilter>().sharedMesh;
		}
	}

	public void GetPreviewImage(out float aspectRatio, out Rect uvRect)
	{
		if (base.GetComponent<MeshFilter>().sharedMesh != null)
		{
			aspectRatio = (float)this.m_spriteWidth / (float)this.m_spriteHeight;
			uvRect = this.m_uvRect;
		}
		else
		{
			RuntimeSpriteDatabase component = Resources.Load<GameObject>("GUISystem/SpriteDatabase").GetComponent<RuntimeSpriteDatabase>();
			SpriteData spriteData = component.Find(this.m_id);
			if (spriteData != null)
			{
				if ((float)spriteData.height > 0f)
				{
					aspectRatio = (float)spriteData.width / (float)spriteData.height;
				}
				else
				{
					aspectRatio = 1f;
				}
				uvRect = spriteData.uv;
			}
			else
			{
				aspectRatio = 1f;
				uvRect = new Rect(0f, 0f, 1f, 1f);
			}
		}
	}

	protected virtual bool RenderingEnabled()
	{
		return true;
	}

	private void Awake()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		RuntimeSpriteDatabase instance = Singleton<RuntimeSpriteDatabase>.Instance;
		SpriteData data = instance.Find(this.m_id);
		this.SelectSprite(data, false);
	}

	private void OnDestroy()
	{
	}

	public void RebuildMesh()
	{
		MeshFilter component = base.GetComponent<MeshFilter>();
		if (component.sharedMesh != null)
		{
			UnityEngine.Object.DestroyImmediate(component.sharedMesh);
		}
		component.sharedMesh = null;
		RuntimeSpriteDatabase component2 = Resources.Load<GameObject>("GUISystem/SpriteDatabase").GetComponent<RuntimeSpriteDatabase>();
		SpriteData data = component2.Find(this.m_id);
		this.SelectSprite(data, false);
	}

	public void SelectSprite(SpriteData data, bool forceResetMesh = false)
	{
		this.m_id = data.id;
		MeshFilter meshFilter = base.GetComponent(typeof(MeshFilter)) as MeshFilter;
		int num = (int)(this.m_scaleX * (float)data.width);
		int num2 = (int)(this.m_scaleY * (float)data.height);
		int num3 = data.selectionX + data.selectionWidth / 2;
		int num4 = data.selectionY + data.selectionHeight / 2;
		int num5 = data.UVx + data.width / 2;
		int num6 = data.UVy + data.height / 2;
		int num7 = num3 - num5;
		int num8 = num4 - num6;
		int num9 = (int)(this.m_scaleX * (float)(num7 + data.pivotX + this.m_pivotX));
		int num10 = (int)(this.m_scaleY * (float)(num8 + data.pivotY + this.m_pivotY));
		if (meshFilter.sharedMesh == null || forceResetMesh || num != this.m_spriteWidth || num2 != this.m_spriteHeight || num9 != this.m_spritePivotX || num10 != this.m_spritePivotY)
		{
			this.m_spritePivotX = num9;
			this.m_spritePivotY = num10;
			this.m_spriteWidth = num;
			this.m_spriteHeight = num2;
			this.CreateMesh(meshFilter, this.m_spriteWidth, this.m_spriteHeight, this.m_spritePivotX, this.m_spritePivotY);
			this.ResetUVs(data, meshFilter.sharedMesh);
			if (this.m_updateCollider)
			{
				this.UpdateCollider();
			}
		}
		else if (this.m_uvRect != data.uv)
		{
			this.ResetUVs(data, meshFilter.sharedMesh);
		}
	}

	private void ResetUVs(SpriteData data, Mesh mesh)
	{
		this.m_uvRect = data.uv;
		float num = 0f;
		float num2 = 0f;
		if (data.opaqueBorderPixels > 0)
		{
			num = (float)data.opaqueBorderPixels * data.uv.width / (float)data.width;
			num2 = (float)data.opaqueBorderPixels * data.uv.height / (float)data.height;
		}
		Vector2[] array = new Vector2[4];
		array[0].x = data.uv.x + num;
		array[0].y = data.uv.y + num2;
		array[1].x = data.uv.x + num;
		array[1].y = data.uv.y + data.uv.height - 1f * num2;
		array[2].x = data.uv.x + data.uv.width - 1f * num;
		array[2].y = data.uv.y + data.uv.height - 1f * num2;
		array[3].x = data.uv.x + data.uv.width - 1f * num;
		array[3].y = data.uv.y + num2;
		this.m_uvRect = data.uv;
		if (this.RenderingEnabled())
		{
			mesh.uv = array;
		}
	}

	public void CreateMesh(MeshFilter mf, int width, int height, int pivotX, int pivotY)
	{
		if (!this.RenderingEnabled())
		{
			return;
		}
		float num = (float)width * 10f / 768f;
		float num2 = (float)height * 10f / 768f;
		float num3 = -2f * (float)pivotX * 10f / 768f;
		float num4 = -2f * (float)pivotY * 10f / 768f;
		Mesh mesh = new Mesh();
		mesh.name = string.Concat(new object[]
		{
			"GeneratedMesh_",
			width,
			"x",
			height
		});
		if (!Application.isPlaying)
		{
			mesh.hideFlags = HideFlags.DontSave;
		}
		mesh.vertices = new Vector3[]
		{
			new Vector3(num3 - num, num4 - num2, 0f),
			new Vector3(num3 - num, num4 + num2, 0f),
			new Vector3(num3 + num, num4 + num2, 0f),
			new Vector3(num3 + num, num4 - num2, 0f)
		};
		mesh.triangles = new int[]
		{
			0,
			1,
			2,
			2,
			3,
			0
		};
		mf.sharedMesh = mesh;
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
		this.RefreshEditorView();
	}

	public void RefreshEditorView()
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
				if (this.m_spriteDatabase == null)
				{
					this.m_spriteDatabase = Resources.Load<GameObject>("GUISystem/SpriteDatabase").GetComponent<RuntimeSpriteDatabase>();
				}
				SpriteData spriteData = this.m_spriteDatabase.Find(this.m_id);
				if (spriteData != null)
				{
					this.SelectSprite(spriteData, false);
				}
			}
		}
	}

	private Renderer cachedRenderer;

	public string m_id = string.Empty;

	public float m_scaleX = 1f;

	public float m_scaleY = 1f;

	public int m_pivotX;

	public int m_pivotY;

	public bool m_updateCollider = true;

	public const float DefaultCameraSize = 10f;

	public const float DefaultCameraHeight = 20f;

	public const float DefaultScreenHeight = 768f;

	public const float DefaultAtlasSize = 1024f;

	private int m_spriteWidth;

	private int m_spriteHeight;

	private int m_spritePivotX;

	private int m_spritePivotY;

	private Rect m_uvRect;

	private RuntimeSpriteDatabase m_spriteDatabase;
}
