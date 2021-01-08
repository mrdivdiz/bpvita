namespace Spine
{
    public class ShearTimeline : TranslateTimeline
	{
		public ShearTimeline(int frameCount) : base(frameCount)
		{
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha)
		{
			float[] frames = this.frames;
			if (time < frames[0])
			{
				return;
			}
			Bone bone = skeleton.bones.Items[this.boneIndex];
			if (time >= frames[frames.Length - 3])
			{
				bone.shearX += (bone.data.shearX + frames[frames.Length + -2] - bone.shearX) * alpha;
				bone.shearY += (bone.data.shearY + frames[frames.Length + -1] - bone.shearY) * alpha;
				return;
			}
			int num = Animation.binarySearch(frames, time, 3);
			float num2 = frames[num + -2];
			float num3 = frames[num + -1];
			float num4 = frames[num];
			float curvePercent = base.GetCurvePercent(num / 3 - 1, 1f - (time - num4) / (frames[num + -3] - num4));
			bone.shearX += (bone.data.shearX + (num2 + (frames[num + 1] - num2) * curvePercent) - bone.shearX) * alpha;
			bone.shearY += (bone.data.shearY + (num3 + (frames[num + 2] - num3) * curvePercent) - bone.shearY) * alpha;
		}
	}
}
