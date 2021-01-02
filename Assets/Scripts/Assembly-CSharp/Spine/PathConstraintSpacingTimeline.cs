namespace Spine
{
    public class PathConstraintSpacingTimeline : PathConstraintPositionTimeline
	{
		public PathConstraintSpacingTimeline(int frameCount) : base(frameCount)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> events, float alpha)
		{
			float[] frames = this.frames;
			if (time < frames[0])
			{
				return;
			}
			PathConstraint pathConstraint = skeleton.pathConstraints.Items[this.pathConstraintIndex];
			if (time >= frames[frames.Length - 2])
			{
				int num = frames.Length;
				pathConstraint.spacing += (frames[num + -1] - pathConstraint.spacing) * alpha;
				return;
			}
			int num2 = Animation.binarySearch(frames, time, 2);
			float num3 = frames[num2 + -1];
			float num4 = frames[num2];
			float curvePercent = base.GetCurvePercent(num2 / 2 - 1, 1f - (time - num4) / (frames[num2 + -2] - num4));
			pathConstraint.spacing += (num3 + (frames[num2 + 1] - num3) * curvePercent - pathConstraint.spacing) * alpha;
		}
	}
}
