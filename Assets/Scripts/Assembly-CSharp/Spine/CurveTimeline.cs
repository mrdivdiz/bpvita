using System;

namespace Spine
{
	public abstract class CurveTimeline : Timeline
	{
		public CurveTimeline(int frameCount)
		{
			if (frameCount <= 0)
			{
				throw new ArgumentException("frameCount must be > 0: " + frameCount, "frameCount");
			}
			this.curves = new float[(frameCount - 1) * 19];
		}

		public int FrameCount
		{
			get
			{
				return this.curves.Length / 19 + 1;
			}
		}

		public abstract void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha);

		public void SetLinear(int frameIndex)
		{
			this.curves[frameIndex * 19] = 0f;
		}

		public void SetStepped(int frameIndex)
		{
			this.curves[frameIndex * 19] = 1f;
		}

		public void SetCurve(int frameIndex, float cx1, float cy1, float cx2, float cy2)
		{
			float num = (-cx1 * 2f + cx2) * 0.03f;
			float num2 = (-cy1 * 2f + cy2) * 0.03f;
			float num3 = ((cx1 - cx2) * 3f + 1f) * 0.006f;
			float num4 = ((cy1 - cy2) * 3f + 1f) * 0.006f;
			float num5 = num * 2f + num3;
			float num6 = num2 * 2f + num4;
			float num7 = cx1 * 0.3f + num + num3 * 0.166666672f;
			float num8 = cy1 * 0.3f + num2 + num4 * 0.166666672f;
			int i = frameIndex * 19;
			float[] array = this.curves;
			array[i++] = 2f;
			float num9 = num7;
			float num10 = num8;
			int num11 = i + 19 - 1;
			while (i < num11)
			{
				array[i] = num9;
				array[i + 1] = num10;
				num7 += num5;
				num8 += num6;
				num5 += num3;
				num6 += num4;
				num9 += num7;
				num10 += num8;
				i += 2;
			}
		}

		public float GetCurvePercent(int frameIndex, float percent)
		{
			percent = MathUtils.Clamp(percent, 0f, 1f);
			float[] array = this.curves;
			int i = frameIndex * 19;
			float num = array[i];
			if (num == 0f)
			{
				return percent;
			}
			if (num == 1f)
			{
				return 0f;
			}
			i++;
			float num2 = 0f;
			int num3 = i;
			int num4 = i + 19 - 1;
			while (i < num4)
			{
				num2 = array[i];
				if (num2 >= percent)
				{
					float num5;
					float num6;
					if (i == num3)
					{
						num5 = 0f;
						num6 = 0f;
					}
					else
					{
						num5 = array[i - 2];
						num6 = array[i - 1];
					}
					return num6 + (array[i + 1] - num6) * (percent - num5) / (num2 - num5);
				}
				i += 2;
			}
			float num7 = array[i - 1];
			return num7 + (1f - num7) * (percent - num2) / (1f - num2);
		}

		public float GetCurveType(int frameIndex)
		{
			return this.curves[frameIndex * 19];
		}

		protected const float LINEAR = 0f;

		protected const float STEPPED = 1f;

		protected const float BEZIER = 2f;

		protected const int BEZIER_SIZE = 19;

		private float[] curves;
	}
}
