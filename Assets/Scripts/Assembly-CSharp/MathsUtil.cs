using UnityEngine;

public static class MathsUtil
{
	public static float CatmullRomInterpolate(float a, float b, float c, float d, float i)
	{
		return a * ((-i + 2f) * i - 1f) * i * 0.5f + b * ((3f * i - 5f) * i * i + 2f) * 0.5f + c * ((-3f * i + 4f) * i + 1f) * i * 0.5f + d * ((i - 1f) * i * i) * 0.5f;
	}

	public static Vector3 CatmullRomInterpolate(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float i)
	{
		return new Vector3(MathsUtil.CatmullRomInterpolate(a.x, b.x, c.x, d.x, i), MathsUtil.CatmullRomInterpolate(a.y, b.y, c.y, d.y, i), MathsUtil.CatmullRomInterpolate(a.z, b.z, c.z, d.z, i));
	}

	public static float EasingInQuad(float t, float b, float c, float d)
	{
		t /= d;
		return c * t * t + b;
	}

	public static float EasingOutQuad(float t, float b, float c, float d)
	{
		t /= d;
		return -c * t * (t - 2f) + b;
	}

	public static float EaseInOutQuad(float t, float b, float c, float d)
	{
		t /= d / 2f;
		if (t < 1f)
		{
			return c / 2f * t * t + b;
		}
		t -= 1f;
		return -c / 2f * (t * (t - 2f) - 1f) + b;
	}
}
