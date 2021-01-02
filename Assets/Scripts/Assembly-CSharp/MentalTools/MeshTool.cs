using System;
using System.Collections.Generic;
using UnityEngine;

namespace MentalTools
{
	public class MeshTool
	{
		private static MeshTool.MeshObject InitTransformForMesh(Transform transform)
		{
			GameObject gameObject = new GameObject("Polygon");
			gameObject.transform.parent = transform;
			gameObject.transform.localPosition = Vector3.zero;
			MeshFilter mf = MentalHelper.EnsureComponent<MeshFilter>(gameObject);
			MeshRenderer mr = MentalHelper.EnsureComponent<MeshRenderer>(gameObject);
			return new MeshTool.MeshObject(gameObject, mf, mr);
		}

		public static GameObject CreateMeshFromBezier(BezierCurve bezierCurve, Transform transform, MentalMath.AxisSpace space, bool debugMode = false)
		{
			if (bezierCurve == null || bezierCurve.Curve == null || bezierCurve.Curve.Count == 0)
			{
				return null;
			}
			List<Vector3> list = new List<Vector3>();
			int bezierPointCount = bezierCurve.bezierPointCount;
			for (int i = 1; i <= bezierPointCount; i++)
			{
				list.Add(bezierCurve.Curve.GetPoint((float)i / (float)bezierPointCount, true, Vector3.zero));
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return MeshTool.CreateMeshFromPolygon(list, transform, space, debugMode);
		}

		public static GameObject CreateMeshFromPolygon(List<Vector3> vertices, Transform transform, MentalMath.AxisSpace space, bool debugMode = false)
		{
			MeshTool.MeshObject meshObject = MeshTool.InitTransformForMesh(transform);
			if (debugMode)
			{
				for (int i = 0; i < vertices.Count; i++)
				{
				}
			}
			List<Vector2> list = new List<Vector2>();
			for (int j = 0; j < vertices.Count; j++)
			{
				list.Add(new Vector2(vertices[j].x, vertices[j].y));
			}
			List<int> list2 = new List<int>();
			bool[] array = new bool[vertices.Count];
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = true;
			}
			int num = 0;
			int num2 = 1;
			int num3 = 2;
			int l = vertices.Count;
			int num4 = l * 10;
			while (l > 0)
			{
				num4--;
				if (num4 < 0)
				{
					break;
				}
				bool flag = true;
				for (int m = 0; m < vertices.Count; m++)
				{
					if (num != m && num2 != m && num3 != m)
					{
						if (MentalMath.PointInTriangle(vertices[m], vertices[num], vertices[num2], vertices[num3], MentalMath.AxisSpace.XY))
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					Vector3 a = vertices[num2] - vertices[num];
					Vector3 tangent = a + (vertices[num3] - vertices[num2]);
					Vector3 counterClockwiseNormal = MentalMath.GetCounterClockwiseNormal(tangent, space);
					float num5 = Vector3.Angle(-a, counterClockwiseNormal);
					flag = (num5 > 90f);
				}
				if (!flag)
				{
					num = num2;
					num2 = num3;
				}
				else
				{
					if (debugMode)
					{
						Vector3 vector = transform.position + Vector3.up * 3f;
					}
					list2.Add(num);
					list2.Add(num2);
					list2.Add(num3);
					l--;
					if (l <= 2)
					{
						if (debugMode)
						{
						}
						break;
					}
					array[num2] = false;
					num2 = num3;
				}
				int num6 = num2;
				int num7 = vertices.Count;
				while (num2 == num3)
				{
					num7--;
					if (num7 < 0)
					{
						break;
					}
					num6++;
					if (num6 >= vertices.Count)
					{
						num6 = 0;
					}
					if (array[num6] && num != num6 && num2 != num6)
					{
						if (debugMode)
						{
						}
						num3 = num6;
						break;
					}
				}
			}
			if (!debugMode)
			{
				Mesh mesh = new Mesh();
				mesh.name = transform.name;
				mesh.vertices = vertices.ToArray();
				mesh.uv = list.ToArray();
				mesh.triangles = list2.ToArray();
				mesh.RecalculateNormals();
				meshObject.mf.sharedMesh = mesh;
			}
			return meshObject.parent;
		}

		public static GameObject CreateMeshStripFromBezier(BezierCurve bezierCurve, Transform transform, MentalMath.AxisSpace space, float stripWidth, bool debugMode = false)
		{
			List<Vector3> list = new List<Vector3>();
			int bezierPointCount = bezierCurve.bezierPointCount;
			Vector3 vector = bezierCurve.Curve.GetPoint(0f, false);
			Vector3 vector2 = bezierCurve.Curve.GetPoint(1f / (float)bezierPointCount, bezierCurve.loop);
			Vector3 vector3 = vector2;
			Vector3 a = vector2 - vector;
			Vector3 tangent = a + (vector3 - vector2);
			Vector3 counterClockwiseNormal = MentalMath.GetCounterClockwiseNormal(tangent, space);
			list.Add(vector + counterClockwiseNormal * stripWidth);
			list.Add(vector - counterClockwiseNormal * stripWidth);
			for (int i = 1; i <= bezierPointCount; i++)
			{
				if (i == bezierPointCount && bezierCurve.loop)
				{
					list.Add(list[0]);
					list.Add(list[1]);
				}
				else
				{
					float ct = (float)(i + 1) / (float)bezierPointCount;
					vector3 = bezierCurve.Curve.GetPoint(ct, bezierCurve.loop);
					a = vector2 - vector;
					tangent = a + (vector3 - vector2);
					counterClockwiseNormal = MentalMath.GetCounterClockwiseNormal(tangent, space);
					list.Add(vector2 + counterClockwiseNormal * stripWidth);
					list.Add(vector2 - counterClockwiseNormal * stripWidth);
					vector = vector2;
					vector2 = vector3;
				}
			}
			return MeshTool.CreateMeshStrip(list, transform, debugMode);
		}

		public static GameObject CreateMeshStrip(List<Vector3> vertices, Transform transform, bool debugMode = false)
		{
			MeshTool.MeshObject meshObject = MeshTool.InitTransformForMesh(transform);
			List<Vector2> list = new List<Vector2>();
			for (int i = 0; i < vertices.Count; i++)
			{
				list.Add(new Vector2(vertices[i].x, vertices[i].y));
			}
			List<int> list2 = new List<int>();
			for (int j = 0; j < vertices.Count - 2; j++)
			{
				list2.Add(j);
				if (j % 2 == 0)
				{
					list2.Add(j + 2);
					list2.Add(j + 1);
				}
				else
				{
					list2.Add(j + 1);
					list2.Add(j + 2);
				}
			}
			if (!debugMode)
			{
				Mesh mesh = new Mesh();
				mesh.name = transform.name;
				mesh.vertices = vertices.ToArray();
				mesh.uv = list.ToArray();
				mesh.triangles = list2.ToArray();
				mesh.RecalculateNormals();
				meshObject.mf.sharedMesh = mesh;
			}
			return meshObject.parent;
		}

		private struct MeshObject
		{
			public MeshObject(GameObject _parent, MeshFilter _mf, MeshRenderer _mr)
			{
				this.parent = _parent;
				this.mf = _mf;
				this.mr = _mr;
			}

			public GameObject parent;

			public MeshFilter mf;

			public MeshRenderer mr;
		}
	}
}
