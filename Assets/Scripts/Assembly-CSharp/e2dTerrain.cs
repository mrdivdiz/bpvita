using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class e2dTerrain : MonoBehaviour
{
	public bool IsEditable
	{
		get
		{
			return this.TerrainCurve != null && this.TerrainCurve.Count >= 2;
		}
	}

	public e2dTerrainBoundary Boundary
	{
		get
		{
			return this.mBoundary;
		}
	}

	public e2dTerrainCurveMesh CurveMesh
	{
		get
		{
			return this.mCurveMesh;
		}
	}

	public e2dTerrainFillMesh FillMesh
	{
		get
		{
			return this.mFillMesh;
		}
	}

	public e2dTerrainColliderMesh ColliderMesh
	{
		get
		{
			return this.mColliderMesh;
		}
	}

	public bool CurveIntercrossing
	{
		get
		{
			return this.mCurveIntercrossing;
		}
	}

	private void OnEnable()
	{
		this.EditorReference = null;
		this.mBoundary = new e2dTerrainBoundary(this);
		this.mFillMesh = new e2dTerrainFillMesh(this);
		this.mCurveMesh = new e2dTerrainCurveMesh(this);
		this.mColliderMesh = new e2dTerrainColliderMesh(this);
		if (!this.mFillMesh.IsMeshValid())
		{
			this.FixCurve();
			this.FixBoundary();
			this.RebuildAllMaterials();
			this.RebuildAllMeshes();
		}
		else
		{
			this.CurveMesh.UpdateControlTextures(true);
		}
	}

	private void OnDisable()
	{
		this.mCurveMesh.DestroyTemporaryAssets();
	}

	public void Reset()
	{
		this.TerrainCurve.Clear();
		this.TerrainBoundary = new Rect(0f, 0f, 0f, 0f);
		this.mFillMesh.DestroyMesh();
		this.mCurveMesh.DestroyMesh();
		this.mColliderMesh.DestroyMesh();
	}

	public int GetMaxNodesCount()
	{
		return 8192;
	}

	public void AddPointOnCurve(int beforeWhichIndex, Vector2 toAdd)
	{
		e2dCurveNode e2dCurveNode = new e2dCurveNode(toAdd);
		if (beforeWhichIndex > 0)
		{
			e2dCurveNode.texture = this.TerrainCurve[beforeWhichIndex - 1].texture;
		}
		else if (beforeWhichIndex < this.TerrainCurve.Count)
		{
			e2dCurveNode.texture = this.TerrainCurve[beforeWhichIndex].texture;
		}
		this.TerrainCurve.Insert(beforeWhichIndex, e2dCurveNode);
		this.mCurveMesh.UpdateControlTextures();
	}

	public void RemovePointOnCurve(int index, bool moveTheRest)
	{
		Vector2 b = Vector2.zero;
		if (index < this.TerrainCurve.Count - 1)
		{
			b = this.TerrainCurve[index + 1].position - this.TerrainCurve[index].position;
		}
		this.TerrainCurve.RemoveAt(index);
		if (moveTheRest)
		{
			for (int i = index; i < this.TerrainCurve.Count; i++)
			{
				this.TerrainCurve[i].position = this.TerrainCurve[i].position - b;
			}
		}
		this.mCurveMesh.UpdateControlTextures();
	}

	public void AddCurvePoints(Vector2[] points, int firstToReplace, int lastToReplace)
	{
		int num = this.TerrainCurve.Count + points.Length - (lastToReplace - firstToReplace + 1);
		if (num > this.GetMaxNodesCount())
		{
			return;
		}
		this.TerrainCurve.RemoveRange(firstToReplace, lastToReplace - firstToReplace + 1);
		this.TerrainCurve.Capacity = this.TerrainCurve.Count + points.Length;
		int num2 = firstToReplace;
		foreach (Vector2 position in points)
		{
			this.TerrainCurve.Insert(num2++, new e2dCurveNode(position));
		}
		this.mCurveMesh.UpdateControlTextures();
	}

	public void AlignPointsOnCurve(int index, int referenceIndex, bool horizontally)
	{
		if (index >= 0 && index <= this.TerrainCurve.Count - 1 && referenceIndex >= 0 && referenceIndex <= this.TerrainCurve.Count - 1)
		{
			if (horizontally)
			{
				this.TerrainCurve[index].position.y = this.TerrainCurve[referenceIndex].position.y;
			}
			else
			{
				this.TerrainCurve[index].position.x = this.TerrainCurve[referenceIndex].position.x;
			}
		}
	}

	public void FixCurve()
	{
		for (int i = 0; i < this.TerrainCurve.Count; i++)
		{
			if (float.IsNaN(this.TerrainCurve[i].position.x))
			{
				this.TerrainCurve[i].position.x = 0f;
			}
			if (float.IsNaN(this.TerrainCurve[i].position.y))
			{
				this.TerrainCurve[i].position.y = 0f;
			}
		}
		if (this.TerrainCurve.Count >= 3 && !this.CurveClosed && this.TerrainCurve[this.TerrainCurve.Count - 1] == this.TerrainCurve[0])
		{
			Vector2 a = this.TerrainCurve[this.TerrainCurve.Count - 1].position - this.TerrainCurve[this.TerrainCurve.Count - 2].position;
			this.TerrainCurve[this.TerrainCurve.Count - 1].position -= 0.5f * a;
		}
		if (this.TerrainCurve.Count >= 3 && this.CurveClosed)
		{
			this.TerrainCurve[this.TerrainCurve.Count - 1].Copy(this.TerrainCurve[0]);
		}
		if (e2dConstants.CHECK_CURVE_INTERCROSSING)
		{
			this.mCurveIntercrossing = false;
			int num = this.TerrainCurve.Count;
			if (this.CurveClosed)
			{
				num--;
			}
			for (int j = 3; j < num; j++)
			{
				if (this.IntersectsCurve(0, j - 2, this.TerrainCurve[j - 1].position, this.TerrainCurve[j].position))
				{
					this.mCurveIntercrossing = true;
				}
			}
		}
	}

	public void FixBoundary()
	{
		this.Boundary.FixBoundary();
	}

	public bool IntersectsCurve(int startIndex, int endIndex, Vector2 a, Vector2 b)
	{
		for (int i = startIndex; i < endIndex; i++)
		{
			if (e2dUtils.SegmentsIntersect(a, b, this.TerrainCurve[i].position, this.TerrainCurve[i + 1].position))
			{
				return true;
			}
		}
		return false;
	}

	public void RebuildAllMeshes()
	{
		this.mFillMesh.RebuildMesh();
		this.mCurveMesh.RebuildMesh();
		if (this.NoCollider)
		{
			this.mColliderMesh.ResetMesh();
		}
		else
		{
			this.mColliderMesh.RebuildMesh();
		}
	}

	public void RebuildAllMaterials()
	{
		this.mFillMesh.RebuildMaterial();
		this.mCurveMesh.UpdateControlTextures(true);
		this.mCurveMesh.RebuildMaterial();
	}

	public List<e2dCurveNode> TerrainCurve = new List<e2dCurveNode>();

	public Rect TerrainBoundary = new Rect(0f, 0f, 0f, 0f);

	public Texture FillTexture;

	public float FillTextureTileWidth = e2dConstants.INIT_FILL_TEXTURE_WIDTH;

	public float FillTextureTileHeight = e2dConstants.INIT_FILL_TEXTURE_HEIGHT;

	public float FillTextureTileOffsetX = e2dConstants.INIT_FILL_TEXTURE_OFFSET_X;

	public float FillTextureTileOffsetY = e2dConstants.INIT_FILL_TEXTURE_OFFSET_Y;

	public bool CurveClosed = e2dConstants.INIT_CURVE_CLOSED;

	public bool NoCollider = e2dConstants.INIT_NO_COLLIDER;

	public List<e2dCurveTexture> CurveTextures = new List<e2dCurveTexture>();

	public bool PlasticEdges = true;

	public bool AllowRebuildMaterial = true;

	private e2dTerrainFillMesh mFillMesh;

	private e2dTerrainCurveMesh mCurveMesh;

	private e2dTerrainColliderMesh mColliderMesh;

	private e2dTerrainBoundary mBoundary;

	private bool mCurveIntercrossing;

	[NonSerialized]
	public UnityEngine.Object EditorReference;
}
