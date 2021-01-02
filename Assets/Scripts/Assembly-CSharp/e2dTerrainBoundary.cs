using UnityEngine;

public class e2dTerrainBoundary : e2dTerrainMesh
{
	public e2dTerrainBoundary(e2dTerrain terrain) : base(terrain)
	{
	}

	public void FixBoundary()
	{
		foreach (e2dCurveNode e2dCurveNode in base.TerrainCurve)
		{
			Vector2 position = e2dCurveNode.position;
			if (position.x < base.Terrain.TerrainBoundary.xMin)
			{
				base.Terrain.TerrainBoundary.xMin = position.x;
			}
			if (position.x > base.Terrain.TerrainBoundary.xMax)
			{
				base.Terrain.TerrainBoundary.xMax = position.x;
			}
			if (position.y < base.Terrain.TerrainBoundary.yMin)
			{
				base.Terrain.TerrainBoundary.yMin = position.y;
			}
			if (position.y > base.Terrain.TerrainBoundary.yMax)
			{
				base.Terrain.TerrainBoundary.yMax = position.y;
			}
		}
	}

	public void EnsurePointIsInBoundary(ref Vector3 point)
	{
		if (point.x < base.Terrain.TerrainBoundary.xMin)
		{
			point.x = base.Terrain.TerrainBoundary.xMin;
		}
		if (point.x > base.Terrain.TerrainBoundary.xMax)
		{
			point.x = base.Terrain.TerrainBoundary.xMax;
		}
		if (point.y < base.Terrain.TerrainBoundary.yMin)
		{
			point.y = base.Terrain.TerrainBoundary.yMin;
		}
		if (point.y > base.Terrain.TerrainBoundary.yMax)
		{
			point.y = base.Terrain.TerrainBoundary.yMax;
		}
	}

	public Vector2[] GetBoundaryRect()
	{
		Vector2[] array = new Vector2[5];
		array[0] = new Vector2(base.Terrain.TerrainBoundary.xMax, base.Terrain.TerrainBoundary.yMin);
		array[1] = new Vector2(base.Terrain.TerrainBoundary.xMin, base.Terrain.TerrainBoundary.yMin);
		array[2] = new Vector2(base.Terrain.TerrainBoundary.xMin, base.Terrain.TerrainBoundary.yMax);
		array[3] = new Vector2(base.Terrain.TerrainBoundary.xMax, base.Terrain.TerrainBoundary.yMax);
		array[4] = array[0];
		return array;
	}

	public int ProjectStartPointToBoundary(ref Vector2 point)
	{
		return this.ProjectPointToBoundary(ref point, 1, base.TerrainCurve.Count - 1);
	}

	public int ProjectEndPointToBoundary(ref Vector2 point)
	{
		return this.ProjectPointToBoundary(ref point, 0, base.TerrainCurve.Count - 2);
	}

	public int ProjectPointToBoundary(ref Vector2 point, int startCurveIndex, int endCurveIndex)
	{
		int num = -1;
		float num2 = float.MaxValue;
		float num3 = Mathf.Abs(base.Terrain.TerrainBoundary.yMin - point.y);
		if (num3 < num2 && !base.Terrain.IntersectsCurve(startCurveIndex, endCurveIndex, point, this.ProjectPointToBoundaryEdge(point, 0)))
		{
			num2 = num3;
			num = 0;
		}
		num3 = Mathf.Abs(base.Terrain.TerrainBoundary.xMin - point.x);
		if (num3 < num2 && !base.Terrain.IntersectsCurve(startCurveIndex, endCurveIndex, point, this.ProjectPointToBoundaryEdge(point, 1)))
		{
			num2 = num3;
			num = 1;
		}
		num3 = Mathf.Abs(base.Terrain.TerrainBoundary.yMax - point.y);
		if (num3 < num2 && !base.Terrain.IntersectsCurve(startCurveIndex, endCurveIndex, point, this.ProjectPointToBoundaryEdge(point, 2)))
		{
			num2 = num3;
			num = 2;
		}
		num3 = Mathf.Abs(base.Terrain.TerrainBoundary.xMax - point.x);
		if (num3 < num2 && !base.Terrain.IntersectsCurve(startCurveIndex, endCurveIndex, point, this.ProjectPointToBoundaryEdge(point, 3)))
		{
			num2 = num3;
			num = 3;
		}
		if (num == -1)
		{
			num3 = Mathf.Abs(base.Terrain.TerrainBoundary.yMin - point.y);
			if (num3 < num2)
			{
				num2 = num3;
				num = 0;
			}
			num3 = Mathf.Abs(base.Terrain.TerrainBoundary.xMin - point.x);
			if (num3 < num2)
			{
				num2 = num3;
				num = 1;
			}
			num3 = Mathf.Abs(base.Terrain.TerrainBoundary.yMax - point.y);
			if (num3 < num2)
			{
				num2 = num3;
				num = 2;
			}
			num3 = Mathf.Abs(base.Terrain.TerrainBoundary.xMax - point.x);
			if (num3 < num2)
			{
				num = 3;
			}
		}
		point = this.ProjectPointToBoundaryEdge(point, num);
		return num;
	}

	private Vector2 ProjectPointToBoundaryEdge(Vector2 point, int edgeIndex)
	{
		switch (edgeIndex)
		{
		case 0:
			return new Vector2(point.x, base.Terrain.TerrainBoundary.yMin);
		case 1:
			return new Vector2(base.Terrain.TerrainBoundary.xMin, point.y);
		case 2:
			return new Vector2(point.x, base.Terrain.TerrainBoundary.yMax);
		case 3:
			return new Vector2(base.Terrain.TerrainBoundary.xMax, point.y);
		default:
			return Vector2.zero;
		}
	}
}
