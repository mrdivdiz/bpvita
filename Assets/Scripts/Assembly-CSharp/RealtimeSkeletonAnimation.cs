using Spine.Unity;

public class RealtimeSkeletonAnimation : SkeletonAnimation
{
	public override void Update()
	{
		this.Update(GameTime.RealTimeDelta);
	}
}
