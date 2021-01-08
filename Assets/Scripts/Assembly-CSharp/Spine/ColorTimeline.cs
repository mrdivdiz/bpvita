namespace Spine
{
    public class ColorTimeline : CurveTimeline
	{
		public ColorTimeline(int frameCount) : base(frameCount)
		{
			this.frames = new float[frameCount * 5];
		}

		public int SlotIndex
		{
			get
			{
				return this.slotIndex;
			}
			set
			{
				this.slotIndex = value;
			}
		}

		public float[] Frames
		{
			get
			{
				return this.frames;
			}
			set
			{
				this.frames = value;
			}
		}

		public void SetFrame(int frameIndex, float time, float r, float g, float b, float a)
		{
			frameIndex *= 5;
			this.frames[frameIndex] = time;
			this.frames[frameIndex + 1] = r;
			this.frames[frameIndex + 2] = g;
			this.frames[frameIndex + 3] = b;
			this.frames[frameIndex + 4] = a;
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha)
		{
			float[] array = this.frames;
			if (time < array[0])
			{
				return;
			}
			float num2;
			float num3;
			float num4;
			float num5;
			if (time >= array[array.Length - 5])
			{
				int num = array.Length;
				num2 = array[num + -4];
				num3 = array[num + -3];
				num4 = array[num + -2];
				num5 = array[num + -1];
			}
			else
			{
				int num6 = Animation.binarySearch(array, time, 5);
				num2 = array[num6 + -4];
				num3 = array[num6 + -3];
				num4 = array[num6 + -2];
				num5 = array[num6 + -1];
				float num7 = array[num6];
				float curvePercent = base.GetCurvePercent(num6 / 5 - 1, 1f - (time - num7) / (array[num6 + -5] - num7));
				num2 += (array[num6 + 1] - num2) * curvePercent;
				num3 += (array[num6 + 2] - num3) * curvePercent;
				num4 += (array[num6 + 3] - num4) * curvePercent;
				num5 += (array[num6 + 4] - num5) * curvePercent;
			}
			Slot slot = skeleton.slots.Items[this.slotIndex];
			if (alpha < 1f)
			{
				slot.r += (num2 - slot.r) * alpha;
				slot.g += (num3 - slot.g) * alpha;
				slot.b += (num4 - slot.b) * alpha;
				slot.a += (num5 - slot.a) * alpha;
			}
			else
			{
				slot.r = num2;
				slot.g = num3;
				slot.b = num4;
				slot.a = num5;
			}
		}

		public const int ENTRIES = 5;

		protected const int PREV_TIME = -5;

		protected const int PREV_R = -4;

		protected const int PREV_G = -3;

		protected const int PREV_B = -2;

		protected const int PREV_A = -1;

		protected const int R = 1;

		protected const int G = 2;

		protected const int B = 3;

		protected const int A = 4;

		internal int slotIndex;

		internal float[] frames;
	}
}
