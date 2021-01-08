using System.Collections.Generic;
using UnityEngine;

public class e2dTerrainCurveMesh : e2dTerrainMesh
{
	public e2dTerrainCurveMesh(e2dTerrain terrain) : base(terrain)
	{
		this.ControlTextures = new List<Texture2D>();
		this.StripeVertices = new List<Vector3>();
	}

	public MeshRenderer renderer
	{
		get
		{
			base.EnsureMeshComponentsExist();
			return base.transform.Find(e2dConstants.CURVE_MESH_NAME).GetComponent<MeshRenderer>();
		}
	}

	public GameObject gameObject
	{
		get
		{
			return base.transform.Find(e2dConstants.CURVE_MESH_NAME).gameObject;
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
		Vector3[] array = new Vector3[base.TerrainCurve.Count * 2];
		Vector2[] array2 = new Vector2[array.Length];
		Color[] array3 = new Color[array.Length];
		int[] array4 = new int[(base.TerrainCurve.Count - 1) * 2 * 3];
		this.StripeVertices = this.ComputeStripeVertices();
		array[0] = base.TerrainCurve[0].position;
		array[1] = this.StripeVertices[0];
		array2[0] = new Vector2(0f, 0f);
		array2[1] = new Vector2(0f, 0f);
		array3[0] = new Color(1f, 0f, 0f, 0f);
		array3[1] = new Color(0f, 0f, 0f, 0f);
		float num = 0f;
		for (int i = 1; i < base.TerrainCurve.Count; i++)
		{
			int num2 = i;
			int num3 = 2 * num2;
			int num4 = 6 * (i - 1);
			float magnitude = (base.TerrainCurve[i].position - base.TerrainCurve[i - 1].position).magnitude;
			num += magnitude;
			array[num3] = base.TerrainCurve[num2].position;
			array[num3] -= Vector3.forward * 0.01f;
			array2[num3] = new Vector2(num, (float)num2);
			array3[num3] = new Color(1f, 0f, 0f, 0f);
			array[num3 + 1] = this.StripeVertices[i];
			array2[num3 + 1] = new Vector2(num, (float)num2);
			array3[num3 + 1] = new Color(0f, 0f, 0f, 0f);
			if (e2dUtils.PointInTriangle(array[num3 + 1], array[num3 - 2], array[num3], array[num3 - 1]))
			{
				array4[num4] = num3 - 2;
				array4[num4 + 1] = num3 + 1;
				array4[num4 + 2] = num3 - 1;
				array4[num4 + 3] = num3 - 2;
				array4[num4 + 4] = num3;
				array4[num4 + 5] = num3 + 1;
			}
			else
			{
				array4[num4] = num3 - 2;
				array4[num4 + 1] = num3;
				array4[num4 + 2] = num3 - 1;
				array4[num4 + 3] = num3 - 1;
				array4[num4 + 4] = num3;
				array4[num4 + 5] = num3 + 1;
			}
		}
		MeshFilter component = base.transform.Find(e2dConstants.CURVE_MESH_NAME).GetComponent<MeshFilter>();
		component.sharedMesh.Clear();
		component.sharedMesh.vertices = array;
		component.sharedMesh.uv = array2;
		component.sharedMesh.colors = array3;
		component.sharedMesh.triangles = array4;
		if (this.SomeMaterialsMissing())
		{
			this.RebuildMaterial();
		}
	}

	private List<Vector3> ComputeStripeVertices()
	{
		List<Vector3> list = new List<Vector3>(base.TerrainCurve.Count);
		list.Add(this.ComputeFirstStripeVertex());
		for (int i = 1; i < base.TerrainCurve.Count - 1; i++)
		{
			list.Add(this.ComputeStripeVertex(i));
		}
		list.Add(this.ComputeLastStripeVertex());
		for (int j = 0; j < list.Count - 1; j++)
		{
			for (int k = j + 2; k < list.Count - 1; k++)
			{
				Vector2 v;
				if (e2dUtils.SegmentsIntersect(list[j], list[j + 1], list[k], list[k + 1], out v))
				{
					for (int l = j + 1; l <= k; l++)
					{
						list[l] = v;
					}
					break;
				}
			}
		}
		return list;
	}

	private Vector3 ComputeFirstStripeVertex()
	{
		Vector2 position = base.TerrainCurve[0].position;
		base.Boundary.ProjectStartPointToBoundary(ref position);
		Vector3 result = position;
		if (position != base.TerrainCurve[0].position)
		{
			Vector2 b = base.TerrainCurve[1].position - base.TerrainCurve[0].position;
			float nodeStripeSize = this.GetNodeStripeSize(0);
			Vector2 vector = new Vector2(b.y, -b.x);
			Vector2 vector2 = nodeStripeSize * vector.normalized;
			Vector2 b2 = position - base.TerrainCurve[0].position;
			Vector2 zero;
			if (!e2dUtils.HalfLineAndLineIntersect(Vector2.zero, b2, vector2, vector2 + b, out zero))
			{
				zero = Vector2.zero;
			}
			result = base.TerrainCurve[0].position + zero;
			base.Boundary.EnsurePointIsInBoundary(ref result);
		}
		return result;
	}

	private Vector3 ComputeLastStripeVertex()
	{
		Vector2 position = base.TerrainCurve[base.TerrainCurve.Count - 1].position;
		base.Boundary.ProjectEndPointToBoundary(ref position);
		Vector3 result = position;
		if (position != base.TerrainCurve[base.TerrainCurve.Count - 1].position)
		{
			Vector2 b = base.TerrainCurve[base.TerrainCurve.Count - 1].position - base.TerrainCurve[base.TerrainCurve.Count - 2].position;
			float nodeStripeSize = this.GetNodeStripeSize(base.TerrainCurve.Count - 1);
			Vector2 vector = new Vector2(b.y, -b.x);
			Vector2 vector2 = nodeStripeSize * vector.normalized;
			Vector2 b2 = position - base.TerrainCurve[base.TerrainCurve.Count - 1].position;
			Vector2 zero;
			if (!e2dUtils.HalfLineAndLineIntersect(Vector2.zero, b2, vector2, vector2 + b, out zero))
			{
				zero = Vector2.zero;
			}
			result = base.TerrainCurve[base.TerrainCurve.Count - 1].position + zero;
			base.Boundary.EnsurePointIsInBoundary(ref result);
		}
		return result;
	}

	private Vector3 ComputeStripeVertex(int nodeIndex)
	{
		Vector2 vector = base.TerrainCurve[nodeIndex].position - base.TerrainCurve[nodeIndex - 1].position;
		Vector2 vector2 = base.TerrainCurve[nodeIndex + 1].position - base.TerrainCurve[nodeIndex].position;
		Vector2 vector3 = new Vector2(vector.y, -vector.x);
		Vector2 normalized = vector3.normalized;
		Vector2 vector4 = new Vector2(vector2.y, -vector2.x);
		Vector2 normalized2 = vector4.normalized;
		Vector2 b = this.GetNodeStripeSize(nodeIndex) * (normalized + normalized2).normalized;
		Vector3 result = base.TerrainCurve[nodeIndex].position + b;
		base.Boundary.EnsurePointIsInBoundary(ref result);
		return result;
	}

	private float GetNodeStripeSize(int nodeIndex)
	{
		e2dCurveTexture e2dCurveTexture = base.CurveTextures[base.TerrainCurve[nodeIndex].texture];
		return e2dCurveTexture.size.y;
	}

	public void DestroyMesh()
	{
		base.EnsureMeshObjectsExist();
		this.DestroyTemporaryAssets();
		MeshFilter component = base.transform.Find(e2dConstants.CURVE_MESH_NAME).GetComponent<MeshFilter>();
		if (component && component.sharedMesh != null)
		{
			UnityEngine.Object.DestroyImmediate(component.sharedMesh);
		}
		MeshRenderer component2 = base.transform.Find(e2dConstants.CURVE_MESH_NAME).GetComponent<MeshRenderer>();
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
		MeshRenderer component = base.transform.Find(e2dConstants.CURVE_MESH_NAME).GetComponent<MeshRenderer>();
		Material[] array = component.sharedMaterials;
		if (array != null)
		{
			foreach (Material obj in array)
			{
				UnityEngine.Object.DestroyImmediate(obj, true);
			}
		}
		this.EnsureTexturesInited();
		int materialsNeededCount = this.GetMaterialsNeededCount();
		array = new Material[materialsNeededCount];
		if (this.ControlTextures.Count != materialsNeededCount)
		{
			this.UpdateControlTextures();
		}
		int num = 0;
		for (int j = 0; j < materialsNeededCount; j++)
		{
			array[j] = new Material(Shader.Find("e2d/Curve"));
			array[j].SetFloat("_ControlSize", (float)this.ControlTextures[j].width);
			array[j].SetFloat("_InvControlSize", 1f / (float)this.ControlTextures[j].width);
			array[j].SetFloat("_InvControlSizeHalf", 0.5f / (float)this.ControlTextures[j].width);
			array[j].SetTexture("_Control", this.ControlTextures[j]);
			array[j].SetTexture("_MainTex", base.CurveTextures[num].texture);
			int k = 0;
			/*while (k < e2dConstants.NUM_TEXTURES_PER_STRIPE_SHADER)
			{
				if (num >= base.CurveTextures.Count)
				{
					break;
				}
				array[j].SetTexture("_Splat" + k, base.CurveTextures[num].texture);
				Vector4 value = new Vector4(1f / base.CurveTextures[num].size.x, base.CurveTextures[num].size.y, (float)((!base.CurveTextures[num].fixedAngle) ? 0 : 1), base.CurveTextures[num].fadeThreshold);
				array[j].SetVector("_SplatParams" + k, value);
				k++;
				num++;
			}*/
		}
		component.materials = array;
	}

	private void EnsureTexturesInited()
	{
		if (base.CurveTextures.Count == 0)
		{
			base.CurveTextures.Clear();
			base.CurveTextures.Add(this.GetDefaultCurveTexture());
			foreach (Texture obj in this.ControlTextures)
			{
				UnityEngine.Object.DestroyImmediate(obj, true);
			}
			this.ControlTextures.Clear();
			this.ControlTextures.Add(this.CreateControlTexture(new Color(1f, 0f, 0f, 0f)));
		}
	}

	public void UpdateControlTextures()
	{
		this.UpdateControlTextures(false);
	}

	public void UpdateControlTextures(bool forceRecreate)
	{
		while (this.ControlTextures.Count > this.GetMaterialsNeededCount())
		{
			UnityEngine.Object.DestroyImmediate(this.ControlTextures[this.ControlTextures.Count - 1], true);
			this.ControlTextures.RemoveAt(this.ControlTextures.Count - 1);
		}
		while (this.ControlTextures.Count < this.GetMaterialsNeededCount())
		{
			this.ControlTextures.Add(this.CreateControlTexture(new Color(0f, 0f, 0f, 0f)));
		}
		for (int i = 0; i < this.ControlTextures.Count; i++)
		{
			if (forceRecreate || this.ControlTextures[i] == null || this.ControlTextures[i].width != this.GetControlTextureSize())
			{
				UnityEngine.Object.DestroyImmediate(this.ControlTextures[i], true);
				this.ControlTextures[i] = this.CreateControlTexture(new Color(0f, 0f, 0f, 0f));
				base.EnsureMeshComponentsExist();
				MeshRenderer component = base.transform.Find(e2dConstants.CURVE_MESH_NAME).GetComponent<MeshRenderer>();
				if (component.sharedMaterials != null && i == component.sharedMaterials.Length - 1 && component.sharedMaterials[i])
				{
					component.sharedMaterials[i].SetFloat("_ControlSize", (float)this.ControlTextures[i].width);
					component.sharedMaterials[i].SetFloat("_InvControlSize", 1f / (float)this.ControlTextures[i].width);
					component.sharedMaterials[i].SetFloat("_InvControlSizeHalf", 0.5f / (float)this.ControlTextures[i].width);
					component.sharedMaterials[i].SetTexture("_Control", this.ControlTextures[i]);
				}
			}
			if (base.TerrainCurve.Count == 0)
			{
				break;
			}
			Color[] array = new Color[base.TerrainCurve.Count];
			for (int j = 0; j < base.TerrainCurve.Count; j++)
			{
				array[j] = new Color(0f, 0f, 0f, 0f);
				if (base.TerrainCurve[j].texture / e2dConstants.NUM_TEXTURES_PER_STRIPE_SHADER == i)
				{
					switch (base.TerrainCurve[j].texture % e2dConstants.NUM_TEXTURES_PER_STRIPE_SHADER)
					{
					case 0:
						array[j].r = 1f;
						break;
					case 1:
						array[j].g = 1f;
						break;
					case 2:
						array[j].b = 1f;
						break;
					case 3:
						array[j].a = 1f;
						break;
					}
				}
			}
			this.ControlTextures[i].SetPixels(0, 0, array.Length, 1, array);
			this.ControlTextures[i].Apply();
		}
	}

	private int GetMaterialsNeededCount()
	{
		int num = base.CurveTextures.Count / e2dConstants.NUM_TEXTURES_PER_STRIPE_SHADER;
		if (base.CurveTextures.Count % e2dConstants.NUM_TEXTURES_PER_STRIPE_SHADER != 0)
		{
			num++;
		}
		return num;
	}

	private int GetControlTextureSize()
	{
		int num = Mathf.NextPowerOfTwo(base.TerrainCurve.Count);
		if (num == 0)
		{
			num = 1;
		}
		return num;
	}

	private Texture2D CreateControlTexture(Color color)
	{
		int controlTextureSize = this.GetControlTextureSize();
		Texture2D texture2D = new Texture2D(controlTextureSize, 1, TextureFormat.ARGB32, false);
		texture2D.filterMode = FilterMode.Bilinear;
		texture2D.wrapMode = TextureWrapMode.Clamp;
		texture2D.anisoLevel = 1;
		Color[] array = new Color[controlTextureSize];
		for (int i = 0; i < controlTextureSize; i++)
		{
			array[i] = color;
		}
		texture2D.SetPixels(array);
		texture2D.Apply();
		return texture2D;
	}

	public e2dCurveTexture GetDefaultCurveTexture()
	{
		return new e2dCurveTexture((Texture)Resources.Load("defaultCurveTexture", typeof(Texture)));
	}

	public bool SomeMaterialsMissing()
	{
		return base.transform.Find(e2dConstants.CURVE_MESH_NAME).GetComponent<MeshRenderer>().sharedMaterial == null;
	}

	public void AppendCurveTexture()
	{
		base.Terrain.CurveTextures.Add(base.Terrain.CurveMesh.GetDefaultCurveTexture());
		this.UpdateControlTextures();
	}

	public void RemoveCurveTexture(int index)
	{
		base.Terrain.CurveTextures.RemoveAt(index);
		foreach (e2dCurveNode e2dCurveNode in base.TerrainCurve)
		{
			if (e2dCurveNode.texture == index)
			{
				e2dCurveNode.texture = 0;
			}
			else if (e2dCurveNode.texture > index)
			{
				e2dCurveNode.texture--;
			}
		}
		this.UpdateControlTextures();
	}

	public void DestroyTemporaryAssets()
	{
		foreach (Texture2D texture2D in this.ControlTextures)
		{
			if (texture2D)
			{
				UnityEngine.Object.DestroyImmediate(texture2D, true);
			}
		}
		this.ControlTextures.Clear();
	}

	public List<Texture2D> ControlTextures;

	public List<Vector3> StripeVertices;
}
