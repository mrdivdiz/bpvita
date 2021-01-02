using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(e2dTerrain))]
public class e2dTerrainGenerator : MonoBehaviour
{
	public e2dTerrain Terrain
	{
		get
		{
			if (this.mTerrain == null)
			{
				this.mTerrain = base.GetComponent<e2dTerrain>();
			}
			return this.mTerrain;
		}
	}

	public int NodeCount
	{
		get
		{
			return 1 + Mathf.RoundToInt(this.TargetSize.x / this.NodeStepSize);
		}
	}

	private void OnEnable()
	{
		this.EditorReference = null;
	}

	private void SetPointsToCurve(Vector2[] points, bool fullRebuild)
	{
		if (fullRebuild || this.Terrain.TerrainCurve.Count == 0)
		{
			this.Terrain.AddCurvePoints(points, 0, this.Terrain.TerrainCurve.Count - 1);
			return;
		}
		int[] curveIndicesInTargetArea = this.GetCurveIndicesInTargetArea();
		if (curveIndicesInTargetArea[0] == -2)
		{
			float sqrMagnitude = (this.Terrain.TerrainCurve[0].position - points[points.Length - 1]).sqrMagnitude;
			float sqrMagnitude2 = (this.Terrain.TerrainCurve[this.Terrain.TerrainCurve.Count - 1].position - points[0]).sqrMagnitude;
			if (sqrMagnitude < sqrMagnitude2)
			{
				curveIndicesInTargetArea[0] = 0;
				curveIndicesInTargetArea[1] = -1;
			}
			else
			{
				curveIndicesInTargetArea[0] = this.Terrain.TerrainCurve.Count;
				curveIndicesInTargetArea[1] = this.Terrain.TerrainCurve.Count - 1;
			}
		}
		this.Terrain.AddCurvePoints(points, curveIndicesInTargetArea[0], curveIndicesInTargetArea[1]);
	}

	private int[] GetCurveIndicesInTargetArea()
	{
		Vector2[] targetAreaBoundary = this.GetTargetAreaBoundary();
		int num = -2;
		for (int i = 1; i < this.Terrain.TerrainCurve.Count; i++)
		{
			if (e2dUtils.SegmentIntersectsPolygon(this.Terrain.TerrainCurve[i - 1].position, this.Terrain.TerrainCurve[i].position, targetAreaBoundary))
			{
				num = i;
				break;
			}
		}
		if (e2dUtils.PointInConvexPolygon(this.Terrain.TerrainCurve[0].position, targetAreaBoundary))
		{
			num = 0;
		}
		int num2 = -2;
		for (int j = this.Terrain.TerrainCurve.Count - 1; j >= 1; j--)
		{
			if (e2dUtils.SegmentIntersectsPolygon(this.Terrain.TerrainCurve[j - 1].position, this.Terrain.TerrainCurve[j].position, targetAreaBoundary))
			{
				num2 = j - 1;
				break;
			}
		}
		if (e2dUtils.PointInConvexPolygon(this.Terrain.TerrainCurve[this.Terrain.TerrainCurve.Count - 1].position, targetAreaBoundary))
		{
			num2 = this.Terrain.TerrainCurve.Count - 1;
		}
		return new int[]
		{
			num,
			num2
		};
	}

	public Rect GetTargetAreaBoundingBox()
	{
		Rect result = default(Rect);
		result.xMin = float.MaxValue;
		result.yMin = float.MaxValue;
		result.xMax = float.MinValue;
		result.yMax = float.MinValue;
		foreach (Vector2 vector in this.GetTargetAreaBoundary())
		{
			if (vector.x < result.xMin)
			{
				result.xMin = vector.x;
			}
			if (vector.y < result.yMin)
			{
				result.yMin = vector.y;
			}
			if (vector.x > result.xMax)
			{
				result.xMax = vector.x;
			}
			if (vector.y > result.yMax)
			{
				result.yMax = vector.y;
			}
		}
		return result;
	}

	public Vector2[] GetTargetAreaBoundary()
	{
		return new Vector2[]
		{
			this.TransformPointFromTargetArea(new Vector3(-0.5f * this.TargetSize.x, -0.5f * this.TargetSize.y)),
			this.TransformPointFromTargetArea(new Vector3(-0.5f * this.TargetSize.x, 0.5f * this.TargetSize.y)),
			this.TransformPointFromTargetArea(new Vector3(0.5f * this.TargetSize.x, 0.5f * this.TargetSize.y)),
			this.TransformPointFromTargetArea(new Vector3(0.5f * this.TargetSize.x, -0.5f * this.TargetSize.y))
		};
	}

	public Rect GetTargetAreaLocalBox()
	{
		return new Rect(-0.5f * this.TargetSize.x, -0.5f * this.TargetSize.y, this.TargetSize.x, this.TargetSize.y);
	}

	public Vector3 TransformPointFromTargetArea(Vector3 point)
	{
		point = Quaternion.Euler(0f, 0f, this.TargetAngle) * point;
		point.x += this.TargetPosition.x;
		point.y += this.TargetPosition.y;
		return point;
	}

	public Vector3 TransformPointIntoTargetArea(Vector3 point)
	{
		point.x -= this.TargetPosition.x;
		point.y -= this.TargetPosition.y;
		point = Quaternion.Euler(0f, 0f, -this.TargetAngle) * point;
		return point;
	}

	public void FixTargetArea()
	{
		this.TargetSize.x = Mathf.Max(this.TargetSize.x, float.Epsilon);
		this.TargetSize.y = Mathf.Max(this.TargetSize.y, float.Epsilon);
		Rect targetAreaLocalBox = this.GetTargetAreaLocalBox();
		for (int i = 0; i < this.Peaks.Count; i++)
		{
			Vector3 v = this.Peaks[i].position;
			if (v.x < targetAreaLocalBox.xMin)
			{
				v.x = targetAreaLocalBox.xMin;
			}
			if (v.y < targetAreaLocalBox.yMin)
			{
				v.y = targetAreaLocalBox.yMin;
			}
			if (v.x > targetAreaLocalBox.xMax)
			{
				v.x = targetAreaLocalBox.xMax;
			}
			if (v.y > targetAreaLocalBox.yMax)
			{
				v.y = targetAreaLocalBox.yMax;
			}
			this.Peaks[i].position = v;
		}
	}

	public void GenerateCurve()
	{
		float[] array = null;
		this.GenerateCurve(ref array);
	}

	public void GenerateCurve(ref float[] debugHeightmap)
	{
		if (this.NodeCount < 2)
		{
			return;
		}
		float num = 0f;
		foreach (float num2 in this.CurveBlendingWeights)
		{
			num += num2;
		}
		float[] array = new float[this.NodeCount];
		float[] array2 = new float[this.NodeCount];
		for (int j = 0; j < this.NodeCount; j++)
		{
			array[j] = 0.5f;
		}
		bool flag = true;
		for (int k = 0; k < 4; k++)
		{
			if (num != 0f)
			{
				if (this.CurveBlendingWeights[k] != 0f)
				{
					switch (k)
					{
					case 0:
					{
						bool flag2 = this.GenerateCurvePerlin(array2, this.GetTargetAreaLocalBox(), ref debugHeightmap);
						if (flag2)
						{
							this.NormalizeHeightmap(array2);
						}
						if (!flag2)
						{
							flag = false;
						}
						break;
					}
					case 1:
					{
						bool flag2 = this.GenerateCurveMidpoint(array2, this.GetTargetAreaLocalBox(), ref debugHeightmap);
						if (flag2)
						{
							this.NormalizeHeightmap(array2);
						}
						if (!flag2)
						{
							flag = false;
						}
						break;
					}
					case 2:
						if (!this.GenerateCurveVoronoi(array2, this.GetTargetAreaLocalBox(), ref debugHeightmap))
						{
							flag = false;
						}
						break;
					case 3:
					{
						bool flag2 = this.GenerateCurveWalk(array2, this.GetTargetAreaLocalBox(), ref debugHeightmap);
						if (flag2)
						{
							this.NormalizeHeightmap(array2);
						}
						if (!flag2)
						{
							flag = false;
						}
						break;
					}
					}
					for (int l = 0; l < array.Length; l++)
					{
						array[l] += (array2[l] - 0.5f) * this.CurveBlendingWeights[k] / num;
					}
				}
			}
		}
		if (flag)
		{
			this.NormalizeHeightmap(array);
		}
		Vector2[] targetAreaBoundary = this.GetTargetAreaBoundary();
		Vector2[] array3 = new Vector2[this.NodeCount];
		for (int m = 0; m < this.NodeCount; m++)
		{
			float num3 = (float)m / (float)(this.NodeCount - 1);
			array3[m] = (1f - num3) * targetAreaBoundary[0] + num3 * targetAreaBoundary[3];
			array3[m] += array[m] * (targetAreaBoundary[1] - targetAreaBoundary[0]);
		}
		this.SetPointsToCurve(array3, this.FullRebuild);
		this.Terrain.CurveClosed = false;
		this.Terrain.FixCurve();
		this.Terrain.FixBoundary();
		this.Terrain.RebuildAllMaterials();
		this.Terrain.RebuildAllMeshes();
	}

	private void NormalizeHeightmap(float[] heightMap)
	{
		float num = float.MaxValue;
		float num2 = float.MinValue;
		foreach (float num3 in heightMap)
		{
			if (num3 < num)
			{
				num = num3;
			}
			if (num3 > num2)
			{
				num2 = num3;
			}
		}
		if (num2 - num <= 1.401298E-45f)
		{
			return;
		}
		for (int j = 0; j < heightMap.Length; j++)
		{
			heightMap[j] = (heightMap[j] - num) / (num2 - num);
		}
	}

	private List<Vector2> PreparePeaks(int totalPeakCount, float peakRatio, bool includeCustomPeaks, Rect targetRect)
	{
		List<Vector2> list = new List<Vector2>();
		totalPeakCount = Mathf.Max(totalPeakCount, 2);
		bool flag = true;
		if (includeCustomPeaks)
		{
			foreach (e2dGeneratorPeak e2dGeneratorPeak in this.Peaks)
			{
				float x = (e2dGeneratorPeak.position.x - targetRect.xMin) / targetRect.width;
				float num = (e2dGeneratorPeak.position.y - targetRect.yMin) / targetRect.height;
				list.Add(new Vector2(x, num));
				if (Mathf.Approximately(num, 1f))
				{
					flag = false;
				}
			}
		}
		while (list.Count < totalPeakCount)
		{
			float y = 0f;
			if (UnityEngine.Random.value <= peakRatio)
			{
				y = UnityEngine.Random.value;
			}
			list.Add(new Vector2(UnityEngine.Random.value, y));
		}
		if (flag)
		{
			float num2 = float.MinValue;
			int num3 = (!includeCustomPeaks) ? 0 : this.Peaks.Count;
			for (int i = num3; i < list.Count; i++)
			{
				if (list[i].y > num2)
				{
					num2 = list[i].y;
				}
			}
			if (num2 > 1.401298E-45f)
			{
				for (int j = num3; j < list.Count; j++)
				{
					Vector2 value = list[j];
					value.y /= num2;
					list[j] = value;
				}
			}
		}
		return list;
	}

	private bool GenerateCurvePerlin(float[] heightMap, Rect targetRect, ref float[] debugHeightmap)
	{
		int num = 1 + Mathf.RoundToInt(this.Perlin.frequencyPerUnit * targetRect.width);
		num = Mathf.Max(num, 2);
		e2dPerlinNoise e2dPerlinNoise = new e2dPerlinNoise(this.Perlin.octaves, 1f, num, this.Perlin.persistence);
		e2dPerlinNoise.Regenerate();
		for (int i = 0; i < heightMap.Length; i++)
		{
			float x = (float)i / (float)(heightMap.Length - 1);
			heightMap[i] = e2dPerlinNoise.GetValue(x);
		}
		if (e2dUtils.DEBUG_GENERATOR_CURVE)
		{
			debugHeightmap = new float[10 * heightMap.Length];
			for (int j = 0; j < debugHeightmap.Length; j++)
			{
				float x2 = (float)j / (float)(debugHeightmap.Length - 1);
				debugHeightmap[j] = e2dPerlinNoise.GetValue(x2) * targetRect.height;
			}
		}
		return true;
	}

	private bool GenerateCurveVoronoi(float[] heightMap, Rect targetRect, ref float[] debugHeightmap)
	{
		int totalPeakCount = Mathf.RoundToInt(this.Voronoi.frequencyPerUnit * targetRect.width);
		List<Vector2> peaks = this.PreparePeaks(totalPeakCount, this.Voronoi.peakRatio, this.Voronoi.usePeaks, targetRect);
		e2dVoronoi e2dVoronoi = new e2dVoronoi(peaks, this.Voronoi.peakType, this.Voronoi.peakWidth);
		for (int i = 0; i < heightMap.Length; i++)
		{
			float x = (float)i / (float)(heightMap.Length - 1);
			heightMap[i] = e2dVoronoi.GetValue(x);
		}
		if (e2dUtils.DEBUG_GENERATOR_CURVE)
		{
			debugHeightmap = new float[10 * heightMap.Length];
			for (int j = 0; j < debugHeightmap.Length; j++)
			{
				float x2 = (float)j / (float)(debugHeightmap.Length - 1);
				debugHeightmap[j] = e2dVoronoi.GetValue(x2) * targetRect.height;
			}
		}
		return !this.Voronoi.usePeaks;
	}

	private bool GenerateCurveMidpoint(float[] heightMap, Rect targetRect, ref float[] debugHeightmap)
	{
		List<Vector2> peaks = null;
		if (this.Midpoint.usePeaks)
		{
			peaks = this.PreparePeaks(this.Peaks.Count, 0f, true, targetRect);
		}
		int initialStep = Mathf.RoundToInt((float)heightMap.Length / (this.Midpoint.frequencyPerUnit * targetRect.width));
		e2dMidpoint e2dMidpoint = new e2dMidpoint(heightMap.Length, initialStep, this.Midpoint.roughness, peaks);
		e2dMidpoint.Regenerate();
		for (int i = 0; i < heightMap.Length; i++)
		{
			heightMap[i] = e2dMidpoint.GetValueAt(i);
			if (this.Midpoint.usePeaks)
			{
				heightMap[i] = Mathf.Clamp01(heightMap[i]);
			}
		}
		if (e2dUtils.DEBUG_GENERATOR_CURVE)
		{
			debugHeightmap = new float[heightMap.Length];
			for (int j = 0; j < heightMap.Length; j++)
			{
				debugHeightmap[j] = e2dMidpoint.GetValueAt(j) * targetRect.height;
			}
		}
		return !this.Midpoint.usePeaks;
	}

	private bool GenerateCurveWalk(float[] heightMap, Rect targetRect, ref float[] debugHeightmap)
	{
		float num = 1f / (float)(heightMap.Length - 1);
		float num2 = targetRect.width / (float)(heightMap.Length - 1);
		float num3 = 1f / (this.Walk.frequencyPerUnit * targetRect.width);
		num3 = Mathf.Clamp01(num3);
		float num4 = 0.5f;
		float num5 = 0f;
		float num6 = num4;
		float num7 = num4;
		heightMap[0] = num4;
		for (int i = 1; i < heightMap.Length; i++)
		{
			float num8 = (float)i / (float)(heightMap.Length - 1);
			float num9 = Mathf.Min(num8 % num3, num3 - num8 % num3);
			num9 = 1f - num9 * 2f / num3;
			num9 = Mathf.Pow(num9, 10f);
			float num10 = num9 * this.Walk.angleChangePerUnit * num2 * (2f * UnityEngine.Random.value - 1f);
			num5 = Mathf.Repeat(num5 + num10 + 180f, 360f) - 180f;
			num5 = Mathf.Clamp(num5, -80f, 80f);
			float num11 = Mathf.Tan(num5 * 0.0174532924f) * num;
			num4 += num11;
			float num12 = (e2dConstants.WALK_COHESION_MAX - this.Walk.cohesionPerUnit) * (float)i * num * 0.5f;
			float num13 = Mathf.Clamp(num4, num7 - num12, num6 + num12);
			if (num4 != num13)
			{
				num5 = 0f;
			}
			num4 = num13;
			num6 = Mathf.Min(num6, num4);
			num7 = Mathf.Max(num7, num4);
			heightMap[i] = num4;
		}
		if (e2dUtils.DEBUG_GENERATOR_CURVE)
		{
			debugHeightmap = new float[heightMap.Length];
			for (int j = 0; j < heightMap.Length; j++)
			{
				debugHeightmap[j] = heightMap[j] * targetRect.height;
			}
		}
		return true;
	}

	public void SmoothCurve()
	{
		int[] curveIndicesInTargetArea = this.GetCurveIndicesInTargetArea();
		int num = curveIndicesInTargetArea[1] - curveIndicesInTargetArea[0] + 1;
		if (curveIndicesInTargetArea[0] == -2 || num < 2)
		{
			return;
		}
		float[] array = new float[num];
		float[] array2 = new float[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = this.TransformPointIntoTargetArea(this.Terrain.TerrainCurve[curveIndicesInTargetArea[0] + i].position).y;
		}
		for (int j = 0; j < this.SmoothIterations; j++)
		{
			for (int k = 1; k < num - 1; k++)
			{
				float num2 = 0.5f * (array[k - 1] + array[k + 1]);
				num2 = 0.5f * (num2 + array[k]);
				array2[k] = num2;
			}
			for (int l = 1; l < num - 1; l++)
			{
				array[l] = array2[l];
			}
		}
		for (int m = 0; m < num; m++)
		{
			Vector2 v = this.TransformPointIntoTargetArea(this.Terrain.TerrainCurve[curveIndicesInTargetArea[0] + m].position);
			v.y = array[m];
			this.Terrain.TerrainCurve[curveIndicesInTargetArea[0] + m].position = this.TransformPointFromTargetArea(v);
		}
		this.Terrain.FixCurve();
		this.Terrain.FixBoundary();
		this.Terrain.RebuildAllMaterials();
		this.Terrain.RebuildAllMeshes();
	}

	public void TextureTerrain()
	{
		if (this.TextureHeights.Count != this.Terrain.CurveTextures.Count)
		{
			return;
		}
		List<KeyValuePair<float, int>> list = new List<KeyValuePair<float, int>>();
		float num = float.MinValue;
		foreach (float num2 in this.TextureHeights)
		{
			float b = num2;
			num = Mathf.Max(num, b);
		}
		if (num <= 0f)
		{
			return;
		}
		for (int i = 0; i < this.TextureHeights.Count; i++)
		{
			if (this.TextureHeights[i] > 0f)
			{
				list.Add(new KeyValuePair<float, int>(this.TextureHeights[i] / num, i));
			}
		}
		list.Sort(new HeightComparer());
		int[] curveIndicesInTargetArea = this.GetCurveIndicesInTargetArea();
		int num3 = curveIndicesInTargetArea[1] - curveIndicesInTargetArea[0] + 1;
		if (curveIndicesInTargetArea[0] == -2 || num3 < 1)
		{
			return;
		}
		Rect targetAreaLocalBox = this.GetTargetAreaLocalBox();
		for (int j = 0; j < num3; j++)
		{
			Vector2 vector = this.TransformPointIntoTargetArea(this.Terrain.TerrainCurve[curveIndicesInTargetArea[0] + j].position);
			float num4 = (vector.y + 0.5f * targetAreaLocalBox.height) / targetAreaLocalBox.height;
			foreach (KeyValuePair<float, int> keyValuePair in list)
			{
				if (num4 <= keyValuePair.Key)
				{
					this.Terrain.TerrainCurve[curveIndicesInTargetArea[0] + j].texture = keyValuePair.Value;
					break;
				}
			}
			if (j > 0 && j < num3 - 1)
			{
				Vector2 vector2 = this.TransformPointIntoTargetArea(this.Terrain.TerrainCurve[curveIndicesInTargetArea[0] + j - 1].position);
				Vector2 vector3 = this.TransformPointIntoTargetArea(this.Terrain.TerrainCurve[curveIndicesInTargetArea[0] + j + 1].position);
				float num5 = Mathf.Atan2(vector.y - vector2.y, vector.x - vector2.x) * 57.29578f;
				float num6 = Mathf.Atan2(vector3.y - vector.y, vector3.x - vector.x) * 57.29578f;
				if ((num5 >= this.CliffStartAngle && num6 >= this.CliffStartAngle) || (num5 <= -this.CliffStartAngle && num6 <= -this.CliffStartAngle))
				{
					this.Terrain.TerrainCurve[curveIndicesInTargetArea[0] + j].texture = this.CliffTextureIndex;
				}
			}
		}
		this.Terrain.RebuildAllMaterials();
		this.Terrain.RebuildAllMeshes();
	}

	public bool FullRebuild = e2dConstants.INIT_FULL_REBUILD;

	public float NodeStepSize = e2dConstants.INIT_NODE_STEP_SIZE;

	public Vector2 TargetPosition = e2dConstants.INIT_TARGET_POSITION;

	public Vector2 TargetSize = e2dConstants.INIT_TARGET_SIZE;

	public float TargetAngle = e2dConstants.INIT_TARGET_ANGLE;

	public e2dCurvePerlinPreset Perlin = (e2dCurvePerlinPreset)e2dPresets.GetDefault(e2dGeneratorCurveMethod.PERLIN);

	public e2dCurveVoronoiPreset Voronoi = (e2dCurveVoronoiPreset)e2dPresets.GetDefault(e2dGeneratorCurveMethod.VORONOI);

	public e2dCurveMidpointPreset Midpoint = (e2dCurveMidpointPreset)e2dPresets.GetDefault(e2dGeneratorCurveMethod.MIDPOINT);

	public e2dCurveWalkPreset Walk = (e2dCurveWalkPreset)e2dPresets.GetDefault(e2dGeneratorCurveMethod.WALK);

	public List<e2dGeneratorPeak> Peaks = new List<e2dGeneratorPeak>();

	public float[] CurveBlendingWeights = new float[4];

	public int SmoothIterations;

	public int CliffTextureIndex;

	public float CliffStartAngle;

	public List<float> TextureHeights;

	private e2dTerrain mTerrain;

	[NonSerialized]
	public UnityEngine.Object EditorReference;

	private class HeightComparer : IComparer<KeyValuePair<float, int>>
	{
		public int Compare(KeyValuePair<float, int> x, KeyValuePair<float, int> y)
		{
			return (x.Key >= y.Key) ? ((x.Key <= y.Key) ? 0 : 1) : -1;
		}
	}
}
