using System;
using System.Diagnostics;
using UnityEngine;

public static class e2dUtils
{
	public static bool DEBUG_GENERATOR_CURVE
	{
		get
		{
			return false;
		}
	}

	public static float Cross(Vector2 a, Vector2 b)
	{
		return a.x * b.y - a.y * b.x;
	}

	public static bool PointInTriangle(Vector2 P, Vector2 A, Vector2 B, Vector2 C)
	{
		Vector2 vector = C - A;
		Vector2 vector2 = B - A;
		Vector2 rhs = P - A;
		float num = Vector2.Dot(vector, vector);
		float num2 = Vector2.Dot(vector, vector2);
		float num3 = Vector2.Dot(vector, rhs);
		float num4 = Vector2.Dot(vector2, vector2);
		float num5 = Vector2.Dot(vector2, rhs);
		float num6 = 1f / (num * num4 - num2 * num2);
		float num7 = (num4 * num3 - num2 * num5) * num6;
		float num8 = (num * num5 - num2 * num3) * num6;
		return num7 > 0f && num8 > 0f && num7 + num8 < 1f;
	}

	public static bool SegmentsIntersect(Vector2 a, Vector2 b, Vector2 c, Vector2 d)
	{
		Vector2 vector;
		return e2dUtils.SegmentsIntersect(a, b, c, d, out vector);
	}

	public static bool SegmentsIntersect(Vector2 a, Vector2 b, Vector2 c, Vector2 d, out Vector2 intersection)
	{
		intersection = Vector2.zero;
		float num = (a.x - b.x) * (c.y - d.y) - (a.y - b.y) * (c.x - d.x);
		if (Mathf.Abs(num) <= 1.401298E-45f)
		{
			return false;
		}
		intersection.x = ((c.x - d.x) * (a.x * b.y - a.y * b.x) - (a.x - b.x) * (c.x * d.y - c.y * d.x)) / num;
		intersection.y = ((c.y - d.y) * (a.x * b.y - a.y * b.x) - (a.y - b.y) * (c.x * d.y - c.y * d.x)) / num;
		float num2 = 0f;
		if (Mathf.Abs(a.x - b.x) <= 1.401298E-45f || Mathf.Abs(a.y - b.y) <= 1.401298E-45f)
		{
			num2 = 0.01f;
		}
		if (intersection.x < Mathf.Min(a.x, b.x) - num2 || intersection.x > Mathf.Max(a.x, b.x) + num2)
		{
			return false;
		}
		if (intersection.y < Mathf.Min(a.y, b.y) - num2 || intersection.y > Mathf.Max(a.y, b.y) + num2)
		{
			return false;
		}
		float num3 = 0f;
		if (Mathf.Abs(c.x - d.x) <= 1.401298E-45f || Mathf.Abs(c.y - d.y) <= 1.401298E-45f)
		{
			num3 = 0.01f;
		}
		return intersection.x >= Mathf.Min(c.x, d.x) - num3 && intersection.x <= Mathf.Max(c.x, d.x) + num3 && intersection.y >= Mathf.Min(c.y, d.y) - num3 && intersection.y <= Mathf.Max(c.y, d.y) + num3;
	}

	public static bool LinesIntersect(Vector2 a, Vector2 b, Vector2 c, Vector2 d, out Vector2 result)
	{
		result = Vector2.zero;
		float num = (a.x - b.x) * (c.y - d.y) - (a.y - b.y) * (c.x - d.x);
		if (Mathf.Abs(num) < -3.40282347E+38f)
		{
			return false;
		}
		float x = ((c.x - d.x) * (a.x * b.y - a.y * b.x) - (a.x - b.x) * (c.x * d.y - c.y * d.x)) / num;
		float y = ((c.y - d.y) * (a.x * b.y - a.y * b.x) - (a.y - b.y) * (c.x * d.y - c.y * d.x)) / num;
		result.x = x;
		result.y = y;
		return true;
	}

	public static bool HalfLineAndLineIntersect(Vector2 a, Vector2 b, Vector2 c, Vector2 d, out Vector2 result)
	{
		result = Vector2.zero;
		float num = (a.x - b.x) * (c.y - d.y) - (a.y - b.y) * (c.x - d.x);
		if (Mathf.Abs(num) < -3.40282347E+38f)
		{
			return false;
		}
		result.x = ((c.x - d.x) * (a.x * b.y - a.y * b.x) - (a.x - b.x) * (c.x * d.y - c.y * d.x)) / num;
		result.y = ((c.y - d.y) * (a.x * b.y - a.y * b.x) - (a.y - b.y) * (c.x * d.y - c.y * d.x)) / num;
		return Vector2.Dot(result, b - a) >= 0f;
	}

	public static bool SegmentIntersectsPolygon(Vector2 a, Vector2 b, Vector2[] poly)
	{
		bool flag = false;
		Vector2 c = poly[poly.Length - 1];
		foreach (Vector2 vector in poly)
		{
			flag = (flag || e2dUtils.SegmentsIntersect(a, b, c, vector));
			c = vector;
		}
		return flag;
	}

	public static bool PointInConvexPolygon(Vector2 p, Vector2[] poly)
	{
		bool flag = true;
		Vector2 b = poly[poly.Length - 1];
		foreach (Vector2 vector in poly)
		{
			float num = e2dUtils.Cross(vector - b, p - b);
			flag = (flag && num <= 0f);
			b = vector;
		}
		return flag;
	}
}
