using System;
using UnityEngine;

namespace MentalTools
{
	public class LineHelper
	{
		public static Vector3 GetPointOnBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			if (t < 0f)
			{
				t = 0f;
			}
			else if (t > 1f)
			{
				t = 1f;
			}
			return Mathf.Pow(1f - t, 3f) * p0 + 3f * Mathf.Pow(1f - t, 2f) * t * p1 + 3f * (1f - t) * Mathf.Pow(t, 2f) * p2 + Mathf.Pow(t, 3f) * p3;
		}

		public static int AreIntersecting(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float errorMargin = 0.001f)
		{
			Vector2 vector = p1 - p0;
			Vector2 vector2 = p3 - p2;
			p0 += vector.normalized * errorMargin;
			p1 -= vector.normalized * errorMargin;
			p2 += vector2.normalized * errorMargin;
			p3 -= vector2.normalized * errorMargin;
			return LineHelper.CheckSegmentIntersection(p0.x, p0.y, p1.x, p1.y, p2.x, p2.y, p3.x, p3.y);
		}

		public static int CheckSegmentIntersection(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
		{
			float num = x2 - x1;
			float num2 = y2 - y1;
			float num3 = x4 - x3;
			float num4 = y4 - y3;
			float num5 = num * num4 - num2 * num3;
			if (Mathf.Approximately(num5, 0f))
			{
				return 0;
			}
			float num6 = x3 - x1;
			float num7 = y3 - y1;
			float num8 = (num6 * num4 - num7 * num3) / num5;
			if (num8 < 0f || num8 > 1f)
			{
				return 0;
			}
			float num9 = (num6 * num2 - num7 * num) / num5;
			if (num9 < 0f || num9 > 1f)
			{
				return 0;
			}
			return 1;
		}

		public static int AreIntersecting(out Vector3 interSectPoint, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			return LineHelper.CheckSegmentIntersection(out interSectPoint, p0.x, p0.z, p1.x, p1.z, p2.x, p2.z, p3.x, p3.z);
		}

		public static int AreIntersecting(out Vector3 interSectPoint, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
		{
			return LineHelper.CheckSegmentIntersection(out interSectPoint, p0.x, p0.y, p1.x, p1.y, p2.x, p2.y, p3.x, p3.y);
		}

		public static int CheckSegmentIntersection(out Vector3 interSectPoint, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
		{
			interSectPoint = Vector2.zero;
			float num = x2 - x1;
			float num2 = y2 - y1;
			float num3 = x4 - x3;
			float num4 = y4 - y3;
			float num5 = num * num4 - num2 * num3;
			if (Mathf.Approximately(num5, 0f))
			{
				return 0;
			}
			float num6 = x3 - x1;
			float num7 = y3 - y1;
			float num8 = (num6 * num4 - num7 * num3) / num5;
			if (num8 < 0f || num8 > 1f)
			{
				return 0;
			}
			float num9 = (num6 * num2 - num7 * num) / num5;
			if (num9 < 0f || num9 > 1f)
			{
				return 0;
			}
			interSectPoint = new Vector2(x1 + num8 * num, y1 + num8 * num2);
			return 1;
		}
	}
}
