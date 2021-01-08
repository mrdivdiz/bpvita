using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(SpriteReference))]
[ExecuteInEditMode]
public class Panel : MonoBehaviour, SpriteMeshGenerator
{
	public int width
	{
		get
		{
			return this.m_width;
		}
		set
		{
			if (value > 0 && value != this.m_width)
			{
				this.m_width = value;
				this.Rebuild(this.m_spriteData);
			}
		}
	}

	private void Awake()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		RuntimeSpriteDatabase component = Resources.Load<GameObject>("GUISystem/SpriteDatabase").GetComponent<RuntimeSpriteDatabase>();
		this.m_spriteData = component.Find(base.GetComponent<SpriteReference>().Id);
		this.Rebuild(this.m_spriteData);
	}

	private void OnDestroy()
	{
		MeshFilter component = base.GetComponent<MeshFilter>();
		if (!Application.isPlaying)
		{
			if (component.sharedMesh)
			{
				UnityEngine.Object.DestroyImmediate(component.sharedMesh);
			}
		}
		else
		{
			UnityEngine.Object.Destroy(component.sharedMesh);
		}
	}

	private void Rebuild(SpriteData spriteData)
	{
		float scaleX = base.GetComponent<SpriteReference>().m_scaleX;
		float scaleY = base.GetComponent<SpriteReference>().m_scaleY;
		int num = (int)(scaleX * (float)spriteData.width / 3f);
		int num2 = (int)(scaleY * (float)spriteData.height / 3f);
		int num3 = num * this.m_width;
		int num4 = num2 * this.m_height;
		if (num3 != this.m_spriteWidth || num4 != this.m_spriteHeight || this.m_spriteUVRect != spriteData.uv)
		{
			this.m_spriteWidth = num3;
			this.m_spriteHeight = num4;
			this.m_spriteUVRect = spriteData.uv;
			this.CreateMesh(base.GetComponent<MeshFilter>(), num, num2, spriteData, 0, 0);
		}
	}

	public void CreateMesh(MeshFilter mf, int tileWidth, int tileHeight, SpriteData data, int pivotX, int pivotY)
	{
		Vector3[] array = new Vector3[4 * this.m_width * this.m_height];
		int[] array2 = new int[6 * this.m_width * this.m_height];
		Vector2[] array3 = new Vector2[4 * this.m_width * this.m_height];
		Mesh mesh = new Mesh();
		mesh.name = string.Concat(new object[]
		{
			"GeneratedPanelMesh_",
			this.m_width * tileWidth,
			"x",
			this.m_height * tileHeight
		});
		if (!Application.isPlaying)
		{
			mesh.hideFlags = HideFlags.DontSave;
		}
		int num = 0;
		for (int i = 0; i < this.m_height; i++)
		{
			for (int j = 0; j < this.m_width; j++)
			{
				float num2 = 2f * (float)tileWidth * 10f / 768f;
				float num3 = 2f * (float)tileHeight * 10f / 768f;
				float num4 = -2f * (float)pivotX * 10f / 768f;
				float num5 = -2f * (float)pivotY * 10f / 768f;
				float num6 = num2 * (-0.5f * (float)this.m_width + (float)j);
				float num7 = num3 * (-0.5f * (float)this.m_height + (float)i);
				array[num * 4] = new Vector3(num6 + num4, num7 + num5, 0f);
				array[num * 4 + 1] = new Vector3(num6 + num4, num7 + num5 + num3, 0f);
				array[num * 4 + 2] = new Vector3(num6 + num4 + num2, num7 + num5 + num3, 0f);
				array[num * 4 + 3] = new Vector3(num6 + num4 + num2, num7 + num5, 0f);
				array2[num * 6] = num * 4;
				array2[num * 6 + 1] = num * 4 + 1;
				array2[num * 6 + 2] = num * 4 + 2;
				array2[num * 6 + 3] = num * 4 + 2;
				array2[num * 6 + 4] = num * 4 + 3;
				array2[num * 6 + 5] = num * 4;
				Rect uvs = this.GetUvs(j, i, data);
				array3[num * 4].x = uvs.x;
				array3[num * 4].y = uvs.y;
				array3[num * 4 + 1].x = uvs.x;
				array3[num * 4 + 1].y = uvs.y + uvs.height;
				array3[num * 4 + 2].x = uvs.x + uvs.width;
				array3[num * 4 + 2].y = uvs.y + uvs.height;
				array3[num * 4 + 3].x = uvs.x + uvs.width;
				array3[num * 4 + 3].y = uvs.y;
				num++;
			}
		}
		mesh.vertices = array;
		mesh.triangles = array2;
		mesh.uv = array3;
		mf.sharedMesh = mesh;
		mf.sharedMesh.RecalculateNormals();
		mf.sharedMesh.RecalculateBounds();
	}

	private Rect GetUvs(int x, int y, SpriteData data)
	{
		Rect result = new Rect(data.uv.x, data.uv.y, data.uv.width / 3f, data.uv.height / 3f);
		if (x == this.m_width - 1)
		{
			result.x += 2f * result.width;
		}
		else if (x > 0)
		{
			result.x += result.width;
		}
		if (y == this.m_height - 1)
		{
			result.y += 2f * result.height;
		}
		else if (y > 0)
		{
			result.y += result.height;
		}
		return result;
	}

	private void OnDrawGizmos()
	{
		this.RefreshEditorView();
	}

	public void RefreshEditorView()
	{
		if (!Application.isPlaying && base.GetComponent<Renderer>().sharedMaterial && base.GetComponent<Renderer>().sharedMaterial.mainTexture)
		{
			if (this.m_spriteDatabase == null)
			{
				this.m_spriteDatabase = ((GameObject)Resources.Load("GUISystem/SpriteDatabase", typeof(GameObject))).GetComponent<RuntimeSpriteDatabase>();
			}
			SpriteData spriteData = this.m_spriteDatabase.Find(base.GetComponent<SpriteReference>().Id);
			if (spriteData != null)
			{
				this.Rebuild(spriteData);
			}
		}
	}

	public int m_width = 5;

	public int m_height = 3;

	public const float DefaultCameraSize = 10f;

	public const float DefaultCameraHeight = 20f;

	public const float DefaultScreenHeight = 768f;

	private int m_spriteWidth;

	private int m_spriteHeight;

	private Rect m_spriteUVRect = default(Rect);

	private RuntimeSpriteDatabase m_spriteDatabase;

	private SpriteData m_spriteData;
}
