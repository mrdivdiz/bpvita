using System;

namespace Spine
{
	public static class MathUtils
	{
		static MathUtils()
		{
			for (int i = 0; i < 16384; i++)
			{
				MathUtils.sin[i] = (float)Math.Sin((double)(((float)i + 0.5f) / 16384f * 6.28318548f));
			}
			for (int j = 0; j < 360; j += 90)
			{
				MathUtils.sin[(int)((float)j * 45.5111122f) & 16383] = (float)Math.Sin((double)((float)j * 0.0174532924f));
			}
		}

		public static float Sin(float radians)
		{
			return MathUtils.sin[(int)(radians * 2607.59448f) & 16383];
		}

		public static float Cos(float radians)
		{
			return MathUtils.sin[(int)((radians + 1.57079637f) * 2607.59448f) & 16383];
		}

		public static float SinDeg(float degrees)
		{
			return MathUtils.sin[(int)(degrees * 45.5111122f) & 16383];
		}

		public static float CosDeg(float degrees)
		{
			return MathUtils.sin[(int)((degrees + 90f) * 45.5111122f) & 16383];
		}

		public static float Atan2(float y, float x)
		{
			if (x == 0f)
			{
				if (y > 0f)
				{
					return 1.57079637f;
				}
				if (y == 0f)
				{
					return 0f;
				}
				return -1.57079637f;
			}
			else
			{
				float num = y / x;
				float num2;
				if (Math.Abs(num) >= 1f)
				{
					num2 = 1.57079637f - num / (num * num + 0.28f);
					return (y >= 0f) ? num2 : (num2 - 3.14159274f);
				}
				num2 = num / (1f + 0.28f * num * num);
				if (x < 0f)
				{
					return num2 + ((y >= 0f) ? 3.14159274f : -3.14159274f);
				}
				return num2;
			}
		}

		public static float Clamp(float value, float min, float max)
		{
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}

		public const float PI = 3.14159274f;

		public const float PI2 = 6.28318548f;

		public const float radDeg = 57.2957764f;

		public const float degRad = 0.0174532924f;

		private const int SIN_BITS = 14;

		private const int SIN_MASK = 16383;

		private const int SIN_COUNT = 16384;

		private const float radFull = 6.28318548f;

		private const float degFull = 360f;

		private const float radToIndex = 2607.59448f;

		private const float degToIndex = 45.5111122f;

		private static float[] sin = new float[16384];
	}
}
