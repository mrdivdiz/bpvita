using System;
using Spine.Unity;
using UnityEngine;

public class AnimatedButton : Widget
{
	public MethodCaller MethodToCall
	{
		get
		{
			return this.methodToCall;
		}
	}

	public EventSender EventSender
	{
		get
		{
			return this.eventToSend;
		}
	}

	private void Awake()
	{
		this.methodToCall.PrepareCall();
		this.eventToSend.PrepareSend();
		if (this.skeletonAnimation.state == null)
		{
			this.skeletonAnimation.Initialize(true);
		}
		this.skeletonAnimation.state.Event += this.OnAnimationEvent;
		if (this.requirements != null)
		{
			PlayerLevelRequirement playerLevelRequirement = this.requirements;
			playerLevelRequirement.OnUnlock = (Action<bool>)Delegate.Combine(playerLevelRequirement.OnUnlock, new Action<bool>(this.OnUnlockActions));
		}
	}

	private void OnAnimationEvent(Spine.AnimationState state, int trackIndex, Spine.Event e)
	{
		if (this.OnOpenAnimationEvent != null)
		{
			this.OnOpenAnimationEvent(e);
		}
	}

	private void OnDestroy()
	{
		if (this.requirements != null)
		{
			PlayerLevelRequirement playerLevelRequirement = this.requirements;
			playerLevelRequirement.OnUnlock = (Action<bool>)Delegate.Remove(playerLevelRequirement.OnUnlock, new Action<bool>(this.OnUnlockActions));
		}
	}

	private void Start()
	{
		this.SetIdle(false);
	}

	private void OnUnlockActions(bool unlocked)
	{
		if (unlocked)
		{
			this.UnlockSequence(false);
		}
		else
		{
			this.SetIdle(true);
		}
	}

	private void SetIdle(bool force = false)
	{
		if (this.idleSet && !force)
		{
			return;
		}
		this.locked = (this.requirements != null && this.requirements.IsLocked);
		string text = (!this.locked) ? this.unlockedIdle : this.lockedIdle;
		if (!string.IsNullOrEmpty(text))
		{
			this.skeletonAnimation.state.ClearTracks();
			this.skeletonAnimation.state.AddAnimation(0, text, true, 0f);
			this.idleSet = true;
		}
	}

	public void UnlockSequence(bool forcePlayUnlock = false)
	{
		string key = string.Format("UnlockShown_{0}", base.gameObject.name);
		if (!string.IsNullOrEmpty(this.unlock) && (forcePlayUnlock || !GameProgress.GetBool(key, false, GameProgress.Location.Local, null)))
		{
			this.skeletonAnimation.state.ClearTracks();
			this.skeletonAnimation.state.AddAnimation(0, this.unlock, false, 0f);
			GameProgress.SetBool(key, true, GameProgress.Location.Local);
			if (!string.IsNullOrEmpty(this.unlockedIdle))
			{
				this.skeletonAnimation.state.AddAnimation(0, this.unlockedIdle, true, 0f);
			}
			this.idleSet = true;
			this.locked = false;
		}
	}

	protected override void OnActivate()
	{
		if (this.locked)
		{
			if (!string.IsNullOrEmpty(this.touchLocked) || !string.IsNullOrEmpty(this.lockedIdle))
			{
				this.skeletonAnimation.state.ClearTracks();
			}
			if (!string.IsNullOrEmpty(this.touchLocked))
			{
				this.skeletonAnimation.state.AddAnimation(0, this.touchLocked, false, 0f);
			}
			if (!string.IsNullOrEmpty(this.lockedIdle))
			{
				this.skeletonAnimation.state.AddAnimation(0, this.lockedIdle, true, 0f);
			}
		}
		if (this.eventToSend.HasEvent())
		{
			this.eventToSend.Send();
		}
		if (this.methodToCall.TargetComponent != null)
		{
			this.methodToCall.Call();
		}
	}

	protected override void OnInput(InputEvent input)
	{
		if (input.type == InputEvent.EventType.Press)
		{
			base.Activate();
		}
		else if (input.type == InputEvent.EventType.Release)
		{
			base.Release();
		}
	}

	public Action<Spine.Event> OnOpenAnimationEvent;

	[SerializeField]
	private SkeletonAnimation skeletonAnimation;

	[SerializeField]
	private string lockedIdle;

	[SerializeField]
	private string unlockedIdle;

	[SerializeField]
	private string touchLocked;

	[SerializeField]
	private string unlock;

	[SerializeField]
	private MethodCaller methodToCall;

	[SerializeField]
	private EventSender eventToSend;

	[SerializeField]
	private PlayerLevelRequirement requirements;

	private bool locked;

	private bool idleSet;
}
