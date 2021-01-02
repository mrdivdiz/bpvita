using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class SpriteText : MonoBehaviour
{
	public string Text
	{
		get
		{
			return this.text;
		}
		set
		{
			if (value != this.text)
			{
				this.text = value;
				this.BuildMesh();
			}
		}
	}

	private void Awake()
	{
		this.m_font.Initialize(Singleton<RuntimeSpriteDatabase>.Instance);
		base.GetComponent<Renderer>().sharedMaterial = this.m_font.GetComponent<Renderer>().sharedMaterial;
		this.BuildMesh();
	}

	private Vector2 GetSize()
	{
		int length = this.text.Length;
		float num = 0f;
		float num2 = 0f;
		float num3 = this.letterInterval * 0.026041666f;
		for (int i = 0; i < length; i++)
		{
			char c = this.text[i];
			SpriteFont.SpriteSymbol symbol = this.m_font.GetSymbol(c);
			SpriteData spriteData = symbol.spriteData;
			float num4 = symbol.spriteScaleX * (float)spriteData.width * 0.026041666f;
			float num5 = symbol.spriteScaleY * (float)spriteData.height * 0.026041666f;
			num2 += num4 + num3;
			if (num5 > num)
			{
				num = num5;
			}
		}
		return new Vector2(num2, num);
	}

	public void BuildMesh()
	{
		int length = this.text.Length;
		Vector2 size = this.GetSize();
		Vector3[] array = new Vector3[4 * length];
		Vector2[] array2 = new Vector2[4 * length];
		int[] array3 = new int[6 * length];
		float num = 0f;
		float num2 = 0f;
		int num3 = 0;
		int num4 = 0;
		float num5 = (this.hAlign != SpriteText.HorizontalAlignment.Center) ? ((this.hAlign != SpriteText.HorizontalAlignment.Right) ? 0f : (-size.x)) : (-size.x / 2f);
		float num6 = (this.vAlign != SpriteText.VerticalAlignment.Center) ? ((this.vAlign != SpriteText.VerticalAlignment.Top) ? 0f : (-size.y)) : (-size.y / 2f);
		float num7 = this.letterInterval * 0.026041666f;
		for (int i = 0; i < length; i++)
		{
			char c = this.text[i];
			SpriteFont.SpriteSymbol symbol = this.m_font.GetSymbol(c);
			SpriteData spriteData = symbol.spriteData;
			float num8 = symbol.spriteScaleX * (float)spriteData.width * 0.026041666f;
			float num9 = symbol.spriteScaleY * (float)spriteData.height * 0.026041666f;
			float num10 = num6 + ((this.letterVAlign != SpriteText.VerticalAlignment.Center) ? ((this.letterVAlign != SpriteText.VerticalAlignment.Top) ? 0f : (size.y - num9)) : ((size.y - num9) / 2f));
			array[num3] = new Vector3(num + num5, num2 + num10, 0f);
			array[num3 + 1] = new Vector3(num + num5, num2 + num10 + num9, 0f);
			array[num3 + 2] = new Vector3(num + num5 + num8, num2 + num10 + num9, 0f);
			array[num3 + 3] = new Vector3(num + num5 + num8, num2 + num10, 0f);
			array3[num4] = num3;
			array3[num4 + 1] = num3 + 1;
			array3[num4 + 2] = num3 + 2;
			array3[num4 + 3] = num3 + 2;
			array3[num4 + 4] = num3 + 3;
			array3[num4 + 5] = num3;
			float num11 = 0f;
			float num12 = 0f;
			if (spriteData.opaqueBorderPixels > 0)
			{
				num11 = (float)spriteData.opaqueBorderPixels * spriteData.uv.width / (float)spriteData.width;
				num12 = (float)spriteData.opaqueBorderPixels * spriteData.uv.height / (float)spriteData.height;
			}
			array2[num3] = new Vector2(spriteData.uv.x + num11, spriteData.uv.y + num12);
			array2[num3 + 1] = new Vector2(spriteData.uv.x + num11, spriteData.uv.y + spriteData.uv.height - 1f * num12);
			array2[num3 + 2] = new Vector2(spriteData.uv.x + spriteData.uv.width - 1f * num11, spriteData.uv.y + spriteData.uv.height - 1f * num12);
			array2[num3 + 3] = new Vector2(spriteData.uv.x + spriteData.uv.width - 1f * num11, spriteData.uv.y + num12);
			num3 += 4;
			num4 += 6;
			num += num8 + num7;
		}
		MeshFilter meshFilter = base.GetComponent(typeof(MeshFilter)) as MeshFilter;
		if (meshFilter.sharedMesh != null && meshFilter.sharedMesh.vertices.SequenceEqual(array) && meshFilter.sharedMesh.triangles.SequenceEqual(array3) && meshFilter.sharedMesh.uv.SequenceEqual(array2))
		{
			return;
		}
		meshFilter.sharedMesh = new Mesh
		{
			vertices = array,
			triangles = array3,
			uv = array2
		};
		meshFilter.sharedMesh.RecalculateNormals();
		meshFilter.sharedMesh.RecalculateBounds();
	}

	private void OnDrawGizmos()
	{
		this.RefreshEditorView();
	}

	public void RefreshEditorView()
	{
		if (!Application.isPlaying)
		{
			if (this.m_spriteDatabase == null)
			{
				this.m_spriteDatabase = ((GameObject)Resources.Load("GUISystem/SpriteDatabase", typeof(GameObject))).GetComponent<RuntimeSpriteDatabase>();
			}
			this.m_font.Initialize(this.m_spriteDatabase);
			base.GetComponent<Renderer>().sharedMaterial = this.m_font.GetComponent<Renderer>().sharedMaterial;
			this.BuildMesh();
		}
	}

	private const float CameraScale = 0.026041666f;

	public SpriteFont m_font;

	[SerializeField]
	private string text;

	public VerticalAlignment vAlign;

	public HorizontalAlignment hAlign;

	public VerticalAlignment letterVAlign;

	public float letterInterval;

	private RuntimeSpriteDatabase m_spriteDatabase;

	public enum VerticalAlignment
	{
		Bottom,
		Center,
		Top
	}

	public enum HorizontalAlignment
	{
		Left,
		Center,
		Right
	}
}
