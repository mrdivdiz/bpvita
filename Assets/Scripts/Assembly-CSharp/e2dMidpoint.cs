using System.Collections.Generic;
using UnityEngine;

public class e2dMidpoint
{
	public e2dMidpoint(int cellCount, int initialStep, float roughness, List<Vector2> peaks)
	{
		this.mRoughness = roughness;
		this.mInitialCellCount = cellCount;
		cellCount = Mathf.NextPowerOfTwo(cellCount - 1) + 1;
		this.mCells = new float[cellCount];
		this.mInitialStep = Mathf.ClosestPowerOfTwo(initialStep);
		this.mInitialStep = Mathf.Clamp(this.mInitialStep, 1, cellCount - 1);
		this.mPeaks = peaks;
	}

	public void Regenerate()
	{
		int i = this.mInitialStep;
		float num = 0.9f;
		float num2 = Mathf.Pow(2f, Mathf.Lerp(e2dConstants.MIDPOINT_ROUGHNESS_POWER_MIN, e2dConstants.MIDPOINT_ROUGHNESS_POWER_MAX, this.mRoughness));
		for (int j = 0; j < this.mCells.Length; j++)
		{
			this.mCells[j] = -1f;
		}
		for (int k = 0; k < this.mCells.Length; k += this.mInitialStep)
		{
			this.mCells[k] = 0.5f - 0.5f * num + UnityEngine.Random.value * num;
		}
		num *= num2;
		if (this.mPeaks != null)
		{
			foreach (Vector2 vector in this.mPeaks)
			{
				int num3 = Mathf.RoundToInt(vector.x * (float)(this.mInitialCellCount - 1) / (float)this.mInitialStep);
				num3 *= this.mInitialStep;
				this.mCells[num3] = vector.y;
			}
		}
		while (i > 1)
		{
			int num4 = 0;
			while (num4 + i < this.mCells.Length)
			{
				int num5 = num4 + (i >> 1);
				int num6 = num4 + i;
				float num7 = 0.5f * (this.mCells[num4] + this.mCells[num6]);
				num7 += -0.5f * num + UnityEngine.Random.value * num;
				this.mCells[num5] = num7;
				num4 += i;
			}
			i >>= 1;
			num *= num2;
		}
	}

	public float GetValueAt(int i)
	{
		return this.mCells[i];
	}

	private float[] mCells;

	private int mInitialCellCount;

	private int mInitialStep;

	private float mRoughness;

	private List<Vector2> mPeaks;
}
