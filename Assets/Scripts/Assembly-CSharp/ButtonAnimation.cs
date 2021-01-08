using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class ButtonAnimation : MonoBehaviour
{
	public bool PlayWholeAnimation
	{
		get
		{
			return this.playWholeAnimation;
		}
		set
		{
			this.playWholeAnimation = value;
		}
	}

	public string ActivateAnimationName
	{
		get
		{
			return this.activateAnimationName;
		}
		set
		{
			this.activateAnimationName = value;
		}
	}

	private void OnEnable()
	{
		this.mouseOver = false;
		base.transform.localScale = Vector3.one;
		this.ResetAnimation();
	}

	private void Awake()
	{
		this.cachedButton = base.GetComponent<Button>();
		this.cachedAnimation = base.GetComponent<Animation>();
		if (this.cachedButton != null)
		{
			this.cachedButton.SetInputDelegate(new Button.InputDelegate(this.InputHandler));
			this.hasDelegateSet = true;
		}
	}

	private void OnDestroy()
	{
		this.RemoveInputListener();
	}

	public void RemoveInputListener()
	{
		if (this.cachedButton != null && this.hasDelegateSet)
		{
			this.cachedButton.RemoveInputDelegate(new Button.InputDelegate(this.InputHandler));
			this.hasDelegateSet = false;
		}
	}

	public void ResetAnimation()
	{
		if (this.cachedAnimation == null)
		{
			return;
		}
		AnimationState animationState = this.cachedAnimation[this.activateAnimationName];
		if (animationState != null)
		{
			animationState.enabled = true;
			animationState.time = 0f;
			this.cachedAnimation.Sample();
			this.StopAnimation();
		}
	}

	public void PlayAnimation(string animationName)
	{
		if (this.cachedAnimation == null)
		{
			return;
		}
		this.cachedAnimation.Play(animationName);
	}

	public void StopAnimation()
	{
		if (this.cachedAnimation == null)
		{
			return;
		}
		this.cachedAnimation.Stop();
	}

	private float GetAnimationClipLength(string clipName)
	{
		if (this.cachedAnimation == null)
		{
			return 0f;
		}
		AnimationClip clip = this.cachedAnimation.GetClip(clipName);
		if (clip == null)
		{
			return 0f;
		}
		return clip.length;
	}

	private void InputHandler(InputEvent input)
	{
		if (input.type == InputEvent.EventType.Press)
		{
			if (!string.IsNullOrEmpty(this.activateAnimationName))
			{
				this.mouseOver = true;
				this.PlayAnimation(this.activateAnimationName);
				float animationClipLength = this.GetAnimationClipLength(this.activateAnimationName);
				base.StartCoroutine(this.DelayScaling(animationClipLength));
			}
		}
		else if (input.type == InputEvent.EventType.Release || input.type == InputEvent.EventType.MouseLeave)
		{
			this.mouseOver = false;
		}
	}

	private IEnumerator DelayScaling(float delay)
	{
		if (this.playWholeAnimation)
		{
			yield return new WaitForSeconds(delay * 1.05f);
		}
		while (this.mouseOver)
		{
			yield return null;
		}
		if (!this.playWholeAnimation)
		{
			this.StopAnimation();
		}
		base.transform.localScale = Vector3.one;
		yield break;
	}

	[SerializeField]
	private bool playWholeAnimation = true;

	[SerializeField]
	private string activateAnimationName = string.Empty;

	private Button cachedButton;

	private Animation cachedAnimation;

	private bool mouseOver;

	private bool hasDelegateSet;
}
