using System;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
	private void Update()
	{
	}

	private AnimationState FindAnimation(string name)
	{
		foreach (AnimationState animationState in this.m_states)
		{
			if (animationState.name == name)
			{
				return animationState;
			}
		}
		return null;
	}

	public void Play(string name)
	{
		if (this.m_spriteAnimation)
		{
			this.m_spriteAnimation.onPlay = new SpriteAnimation.OnPlay(this.OnPlay);
			this.m_spriteAnimation.Play(name);
		}
		else
		{
			this.OnPlay(name);
		}
	}

	private void OnPlay(string name)
	{
        AnimationState animationState = this.FindAnimation(name);
		if (this.m_spriteAnimation)
		{
			SpriteAnimation spriteAnimation = this.m_spriteAnimation;
			spriteAnimation.onPlay = (SpriteAnimation.OnPlay)Delegate.Remove(spriteAnimation.onPlay, new SpriteAnimation.OnPlay(this.OnPlay));
		}
		if (this.m_currentState != null)
		{
			foreach (ParticleSystem particleSystem in this.m_currentState.particleSystems)
			{
				particleSystem.Stop();
			}
			foreach (AnimationInfo animationInfo in this.m_currentState.animations)
			{
				bool flag = true;
				foreach (AnimationInfo animationInfo2 in animationState.animations)
				{
					if (animationInfo2.animation.gameObject == animationInfo.animation.gameObject)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					animationInfo.animation.Stop();
				}
			}
		}
		foreach (ParticleSystem particleSystem2 in animationState.particleSystems)
		{
			particleSystem2.Play();
		}
		foreach (AnimationInfo animationInfo3 in animationState.animations)
		{
			animationInfo3.animation.CrossFade(animationInfo3.name, animationInfo3.crossFadeTime);
		}
		this.m_currentState = animationState;
	}

	[SerializeField]
	private SpriteAnimation m_spriteAnimation;

	[SerializeField]
	private AnimationState[] m_states;

	[SerializeField]
	private TestKey[] m_testKeys;

	private AnimationState m_currentState;

	[Serializable]
	private class AnimationInfo
	{
		public string name = string.Empty;

		public Animation animation;

		public float crossFadeTime;
	}

	[Serializable]
	private class AnimationState
	{
		public string name = string.Empty;

		public ParticleSystem[] particleSystems;

		public AnimationInfo[] animations;
	}

	[Serializable]
	private class TestKey
	{
		public string animationName = string.Empty;

		public KeyCode key;
	}
}
