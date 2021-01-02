using System;
using UnityEngine;

namespace MentalTools
{
	public abstract class MentalMath
	{
		public static bool PointInTriangle(Vector3 p, Vector3 p0, Vector3 p1, Vector3 p2, MentalMath.AxisSpace space)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			switch (space)
			{
			case MentalMath.AxisSpace.XY:
				num = (double)(p0.y * p2.x - p0.x * p2.y + (p2.y - p0.y) * p.x + (p0.x - p2.x) * p.y);
				num2 = (double)(p0.x * p1.y - p0.y * p1.x + (p0.y - p1.y) * p.x + (p1.x - p0.x) * p.y);
				if (num < 0.0 != num2 < 0.0)
				{
					return false;
				}
				num3 = (double)(-(double)p1.y * p2.x + p0.y * (p2.x - p1.x) + p0.x * (p1.y - p2.y) + p1.x * p2.y);
				if (num3 < 0.0)
				{
					num = -num;
					num2 = -num2;
					num3 = -num3;
				}
				break;
			case MentalMath.AxisSpace.XZ:
				num = (double)(p0.z * p2.x - p0.x * p2.z + (p2.z - p0.z) * p.x + (p0.x - p2.x) * p.z);
				num2 = (double)(p0.x * p1.z - p0.z * p1.x + (p0.z - p1.z) * p.x + (p1.x - p0.x) * p.z);
				if (num < 0.0 != num2 < 0.0)
				{
					return false;
				}
				num3 = (double)(-(double)p1.z * p2.x + p0.z * (p2.x - p1.x) + p0.x * (p1.z - p2.z) + p1.x * p2.z);
				if (num3 < 0.0)
				{
					num = -num;
					num2 = -num2;
					num3 = -num3;
				}
				break;
			case MentalMath.AxisSpace.YZ:
				num = (double)(p0.z * p2.y - p0.y * p2.z + (p2.z - p0.z) * p.y + (p0.y - p2.y) * p.z);
				num2 = (double)(p0.y * p1.z - p0.z * p1.y + (p0.z - p1.z) * p.y + (p1.y - p0.y) * p.z);
				if (num < 0.0 != num2 < 0.0)
				{
					return false;
				}
				num3 = (double)(-(double)p1.z * p2.y + p0.z * (p2.y - p1.y) + p0.y * (p1.z - p2.z) + p1.y * p2.z);
				if (num3 < 0.0)
				{
					num = -num;
					num2 = -num2;
					num3 = -num3;
				}
				break;
			}
			return num > 0.0 && num2 > 0.0 && num + num2 < num3;
		}

		public static Vector3 LeftSideNormal(Vector3 tangent)
		{
			Vector3 vector = new Vector3(-tangent.z, 0f, tangent.x);
			return vector.normalized;
		}

		public static Vector3 GetCounterClockwiseNormal(Vector3 tangent, MentalMath.AxisSpace space)
		{
			Vector3 vector = Vector3.zero;
			Vector3 rhs = Vector3.zero;
			switch (space)
			{
			case MentalMath.AxisSpace.XY:
			{
				rhs = Vector3.back;
				Vector3 vector2 = new Vector3(-tangent.y, tangent.x, 0f);
				vector = vector2.normalized;
				break;
			}
			case MentalMath.AxisSpace.XZ:
				rhs = Vector3.up;
				vector = Vector3.Cross(tangent, rhs);
				break;
			case MentalMath.AxisSpace.YZ:
				rhs = Vector3.right;
				vector = Vector3.Cross(tangent, rhs);
				break;
			}
			return vector.normalized;
		}

		public static Vector3 GetClockwiseNormal(Vector3 tangent, MentalMath.AxisSpace space)
		{
			Vector3 vector = Vector3.zero;
			Vector3 rhs = Vector3.zero;
			switch (space)
			{
			case MentalMath.AxisSpace.XY:
				rhs = Vector3.forward;
				vector = Vector3.Cross(tangent, rhs);
				break;
			case MentalMath.AxisSpace.XZ:
				rhs = Vector3.down;
				vector = Vector3.Cross(tangent, rhs);
				break;
			case MentalMath.AxisSpace.YZ:
				rhs = Vector3.left;
				vector = Vector3.Cross(tangent, rhs);
				break;
			}
			return vector.normalized;
		}

		public static float s { get; set; }

		public enum AxisSpace
		{
			XY,
			XZ,
			YZ
		}
	}
}
