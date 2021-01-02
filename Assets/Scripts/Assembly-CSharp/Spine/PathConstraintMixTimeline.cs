namespace Spine
{
    public class PathConstraintMixTimeline : CurveTimeline
	{
		public PathConstraintMixTimeline(int frameCount) : base(frameCount)
		{
			this.frames = new float[frameCount * 3];
		}

		public int PathConstraintIndex
		{
			get
			{
				return this.pathConstraintIndex;
			}
			set
			{
				this.pathConstraintIndex = value;
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

		public void SetFrame(int frameIndex, float time, float rotateMix, float translateMix)
		{
			frameIndex *= 3;
			this.frames[frameIndex] = time;
			this.frames[frameIndex + 1] = rotateMix;
			this.frames[frameIndex + 2] = translateMix;
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> events, float alpha)
		{
			float[] array = this.frames;
			if (time < array[0])
			{
				return;
			}
			PathConstraint pathConstraint = skeleton.pathConstraints.Items[this.pathConstraintIndex];
			if (time >= array[array.Length - 3])
			{
				int num = array.Length;
				pathConstraint.rotateMix += (array[num + -2] - pathConstraint.rotateMix) * alpha;
				pathConstraint.translateMix += (array[num + -1] - pathConstraint.translateMix) * alpha;
				return;
			}
			int num2 = Animation.binarySearch(array, time, 3);
			float num3 = array[num2 + -2];
			float num4 = array[num2 + -1];
			float num5 = array[num2];
			float curvePercent = base.GetCurvePercent(num2 / 3 - 1, 1f - (time - num5) / (array[num2 + -3] - num5));
			pathConstraint.rotateMix += (num3 + (array[num2 + 1] - num3) * curvePercent - pathConstraint.rotateMix) * alpha;
			pathConstraint.translateMix += (num4 + (array[num2 + 2] - num4) * curvePercent - pathConstraint.translateMix) * alpha;
		}

		public const int ENTRIES = 3;

		private const int PREV_TIME = -3;

		private const int PREV_ROTATE = -2;

		private const int PREV_TRANSLATE = -1;

		private const int ROTATE = 1;

		private const int TRANSLATE = 2;

		internal int pathConstraintIndex;

		internal float[] frames;
	}
}
