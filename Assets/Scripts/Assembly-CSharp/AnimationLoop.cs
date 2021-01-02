using Spine.Unity;
using UnityEngine;

public class AnimationLoop : MonoBehaviour
{
	private void Start()
	{
		this.skeletonAnimation.state.SetAnimation(0, this.animationName, false);
		this.skeletonAnimation.state.End += this.OnAnimationEnd;
		this.animationPlaying = true;
	}

	private void Update()
	{
		if (this.animationPlaying)
		{
			return;
		}
		this.counter -= Time.deltaTime;
		if (this.counter <= 0f)
		{
			this.skeletonAnimation.state.SetAnimation(0, this.animationName, false);
		}
	}

	private void OnAnimationEnd(Spine.AnimationState state, int trackIndex)
	{
		this.counter = this.interval;
		this.animationPlaying = false;
	}

	[SerializeField]
	private SkeletonAnimation skeletonAnimation;

	[SerializeField]
	private float interval;

	[SerializeField]
	private string animationName;

	private bool animationPlaying;

	private float counter;
}
