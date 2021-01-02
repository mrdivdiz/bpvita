using UnityEngine;

public class DisableAfterAnimation : MonoBehaviour
{
	private void OnEnable()
	{
		AnimationClip animationClip = (!base.GetComponent<Animation>() || string.IsNullOrEmpty(this.animName)) ? ((!base.GetComponent<Animation>()) ? null : base.GetComponent<Animation>().clip) : base.GetComponent<Animation>()[this.animName].clip;
		if (this.target && animationClip)
		{
			animationClip.AddEvent(new AnimationEvent
			{
				time = animationClip.length,
				functionName = "OnAnimFinished"
			});
		}
	}

	private void OnAnimFinished()
	{
		if (this.target)
		{
			this.target.SetActive(false);
		}
	}

	public GameObject target;

	public string animName;
}
