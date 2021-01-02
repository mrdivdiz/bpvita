using System.Collections.Generic;
using UnityEngine;

public class e2dVoronoi
{
	public e2dVoronoi(List<Vector2> peaks, e2dVoronoiPeakType peakType, float peakWidth)
	{
		this.mPeaks = peaks;
		this.mPeakType = peakType;
		this.mPeakWidth = peakWidth;
		this.mPeaks.Sort(new Vector2XComparer());
		this.mValleys = new List<Vector2>(this.mPeaks.Count + 1);
		this.mValleys.Add(new Vector2(0f, -this.mPeaks[0].x));
		for (int i = 1; i < this.mPeaks.Count; i++)
		{
			float num = Mathf.Abs(this.mPeaks[i].x - this.mPeaks[i - 1].x);
			float x = 0.5f * (this.mPeaks[i - 1].x + this.mPeaks[i].x);
			this.mValleys.Add(new Vector2(x, -0.5f * num));
		}
		this.mValleys.Add(new Vector2(1f, -(1f - this.mPeaks[this.mPeaks.Count - 1].x)));
		float num2 = float.MaxValue;
		foreach (Vector2 vector in this.mValleys)
		{
			if (vector.y < num2)
			{
				num2 = vector.y;
			}
		}
		for (int j = 0; j < this.mValleys.Count; j++)
		{
			Vector2 value = this.mValleys[j];
			value.y = (value.y - num2) / -num2;
			if (j == 0)
			{
				value.y *= this.mPeaks[j].y;
			}
			else if (j == this.mValleys.Count - 1)
			{
				value.y *= this.mPeaks[j - 1].y;
			}
			else
			{
				value.y *= Mathf.Min(this.mPeaks[j - 1].y, this.mPeaks[j].y);
			}
			if (this.mPeakType == e2dVoronoiPeakType.LINEAR)
			{
				if (this.mPeakWidth <= 0.5f)
				{
					value.y *= 2f * this.mPeakWidth;
				}
				else if (j > 0 && j < this.mValleys.Count - 1)
				{
					float t = 2f * (this.mPeakWidth - 0.5f);
					value.y = Mathf.Lerp(value.y, Mathf.Min(this.mPeaks[j - 1].y, this.mPeaks[j].y), t);
				}
			}
			this.mValleys[j] = value;
		}
	}

	public float GetValue(float x)
	{
		int index = this.mPeaks.Count - 1;
		int index2 = this.mPeaks.Count;
		int i = 0;
		while (i < this.mPeaks.Count)
		{
			if (x < this.mPeaks[i].x)
			{
				if (x < this.mValleys[i].x)
				{
					index = i - 1;
					index2 = i;
					break;
				}
				index = i;
				index2 = i;
				break;
			}
			else
			{
				i++;
			}
		}
		float num = (x - this.mValleys[index2].x) / (this.mPeaks[index].x - this.mValleys[index2].x);
		if (float.IsNaN(num))
		{
			num = 0f;
		}
		float result = 0f;
		e2dVoronoiPeakType e2dVoronoiPeakType = this.mPeakType;
		if (e2dVoronoiPeakType != e2dVoronoiPeakType.LINEAR)
		{
			if (e2dVoronoiPeakType != e2dVoronoiPeakType.SINE)
			{
				if (e2dVoronoiPeakType == e2dVoronoiPeakType.QUADRATIC)
				{
					num *= Mathf.Lerp(1f, e2dConstants.VORONOI_QUADRATIC_PEAK_WIDTH_RATIO, this.mPeakWidth);
					if (num > 1f)
					{
						result = this.mPeaks[index].y;
					}
					else
					{
						float num2 = this.mPeaks[index].y - this.mValleys[index2].y;
						result = this.mValleys[index2].y + num * num * num2;
					}
				}
			}
			else
			{
				num = 1f - Mathf.Pow(1f - num, Mathf.Lerp(e2dConstants.VORONOI_SIN_POWER_MIN, e2dConstants.VORONOI_SIN_POWER_MAX, this.mPeakWidth));
				float f = -1.57079637f + num * 3.14159274f;
				float num2 = 0.5f * (this.mPeaks[index].y - this.mValleys[index2].y);
				float num3 = 1f;
				result = this.mValleys[index2].y + (Mathf.Sin(f) + num3) * num2;
			}
		}
		else
		{
			result = Mathf.Lerp(this.mValleys[index2].y, this.mPeaks[index].y, num);
		}
		return result;
	}

	private List<Vector2> mPeaks;

	private List<Vector2> mValleys;

	private e2dVoronoiPeakType mPeakType;

	private float mPeakWidth;

	private class Vector2XComparer : IComparer<Vector2>
	{
		public int Compare(Vector2 x, Vector2 y)
		{
			return (x.x >= y.x) ? ((x.x <= y.x) ? 0 : 1) : -1;
		}
	}
}
