using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity
{
    [RequireComponent(typeof(Animator))]
	public class SkeletonAnimator : SkeletonRenderer, ISkeletonAnimation
	{
		public event UpdateBonesDelegate UpdateLocal
		{
			add
			{
				this._UpdateLocal += value;
			}
			remove
			{
				this._UpdateLocal -= value;
			}
		}

		public event UpdateBonesDelegate UpdateWorld
		{
			add
			{
				this._UpdateWorld += value;
			}
			remove
			{
				this._UpdateWorld -= value;
			}
		}

		public event UpdateBonesDelegate UpdateComplete
		{
			add
			{
				this._UpdateComplete += value;
			}
			remove
			{
				this._UpdateComplete -= value;
			}
		}

		protected event UpdateBonesDelegate _UpdateLocal;

		protected event UpdateBonesDelegate _UpdateWorld;

		protected event UpdateBonesDelegate _UpdateComplete;

		public override void Initialize(bool overwrite)
		{
			if (this.valid && !overwrite)
			{
				return;
			}
			base.Initialize(overwrite);
			if (!this.valid)
			{
				return;
			}
			this.animationTable.Clear();
			this.clipNameHashCodeTable.Clear();
			SkeletonData skeletonData = this.skeletonDataAsset.GetSkeletonData(true);
			foreach (Animation animation in skeletonData.Animations)
			{
				this.animationTable.Add(animation.Name.GetHashCode(), animation);
			}
			this.animator = base.GetComponent<Animator>();
			this.lastTime = Time.time;
		}

		private void Update()
		{
			if (!this.valid)
			{
				return;
			}
			if (this.layerMixModes.Length != this.animator.layerCount)
			{
				Array.Resize(ref this.layerMixModes, this.animator.layerCount);
			}
			float num = Time.time - this.lastTime;
			this.skeleton.Update(Time.deltaTime);
			int layerCount = this.animator.layerCount;
			for (int i = 0; i < layerCount; i++)
			{
				float num2 = this.animator.GetLayerWeight(i);
				if (i == 0)
				{
					num2 = 1f;
				}
				AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(i);
				AnimatorStateInfo nextAnimatorStateInfo = this.animator.GetNextAnimatorStateInfo(i);
				AnimatorClipInfo[] currentAnimatorClipInfo = this.animator.GetCurrentAnimatorClipInfo(i);
				AnimatorClipInfo[] nextAnimatorClipInfo = this.animator.GetNextAnimatorClipInfo(i);
                MixMode mixMode = this.layerMixModes[i];
				if (mixMode == SkeletonAnimator.MixMode.AlwaysMix)
				{
					foreach (AnimatorClipInfo animatorClipInfo in currentAnimatorClipInfo)
					{
						float num3 = animatorClipInfo.weight * num2;
						if (num3 != 0f)
						{
							float num4 = currentAnimatorStateInfo.normalizedTime * animatorClipInfo.clip.length;
							this.animationTable[this.GetAnimationClipNameHashCode(animatorClipInfo.clip)].Mix(this.skeleton, Mathf.Max(0f, num4 - num), num4, currentAnimatorStateInfo.loop, this.events, num3);
						}
					}
					if (nextAnimatorStateInfo.nameHash != 0)
					{
						foreach (AnimatorClipInfo animatorClipInfo2 in nextAnimatorClipInfo)
						{
							float num5 = animatorClipInfo2.weight * num2;
							if (num5 != 0f)
							{
								float num6 = nextAnimatorStateInfo.normalizedTime * animatorClipInfo2.clip.length;
								this.animationTable[this.GetAnimationClipNameHashCode(animatorClipInfo2.clip)].Mix(this.skeleton, Mathf.Max(0f, num6 - num), num6, nextAnimatorStateInfo.loop, this.events, num5);
							}
						}
					}
				}
				else if (mixMode >= SkeletonAnimator.MixMode.MixNext)
				{
					int l;
					for (l = 0; l < currentAnimatorClipInfo.Length; l++)
					{
						AnimatorClipInfo animatorClipInfo3 = currentAnimatorClipInfo[l];
						float num7 = animatorClipInfo3.weight * num2;
						if (num7 != 0f)
						{
							float num8 = currentAnimatorStateInfo.normalizedTime * animatorClipInfo3.clip.length;
							this.animationTable[this.GetAnimationClipNameHashCode(animatorClipInfo3.clip)].Apply(this.skeleton, Mathf.Max(0f, num8 - num), num8, currentAnimatorStateInfo.loop, this.events);
							break;
						}
					}
					while (l < currentAnimatorClipInfo.Length)
					{
						AnimatorClipInfo animatorClipInfo4 = currentAnimatorClipInfo[l];
						float num9 = animatorClipInfo4.weight * num2;
						if (num9 != 0f)
						{
							float num10 = currentAnimatorStateInfo.normalizedTime * animatorClipInfo4.clip.length;
							this.animationTable[this.GetAnimationClipNameHashCode(animatorClipInfo4.clip)].Mix(this.skeleton, Mathf.Max(0f, num10 - num), num10, currentAnimatorStateInfo.loop, this.events, num9);
						}
						l++;
					}
					l = 0;
					if (nextAnimatorStateInfo.nameHash != 0)
					{
						if (mixMode == SkeletonAnimator.MixMode.SpineStyle)
						{
							while (l < nextAnimatorClipInfo.Length)
							{
								AnimatorClipInfo animatorClipInfo5 = nextAnimatorClipInfo[l];
								float num11 = animatorClipInfo5.weight * num2;
								if (num11 != 0f)
								{
									float num12 = nextAnimatorStateInfo.normalizedTime * animatorClipInfo5.clip.length;
									this.animationTable[this.GetAnimationClipNameHashCode(animatorClipInfo5.clip)].Apply(this.skeleton, Mathf.Max(0f, num12 - num), num12, nextAnimatorStateInfo.loop, this.events);
									break;
								}
								l++;
							}
						}
						while (l < nextAnimatorClipInfo.Length)
						{
							AnimatorClipInfo animatorClipInfo6 = nextAnimatorClipInfo[l];
							float num13 = animatorClipInfo6.weight * num2;
							if (num13 != 0f)
							{
								float num14 = nextAnimatorStateInfo.normalizedTime * animatorClipInfo6.clip.length;
								this.animationTable[this.GetAnimationClipNameHashCode(animatorClipInfo6.clip)].Mix(this.skeleton, Mathf.Max(0f, num14 - num), num14, nextAnimatorStateInfo.loop, this.events, num13);
							}
							l++;
						}
					}
				}
			}
			if (this._UpdateLocal != null)
			{
				this._UpdateLocal(this);
			}
			this.skeleton.UpdateWorldTransform();
			if (this._UpdateWorld != null)
			{
				this._UpdateWorld(this);
				this.skeleton.UpdateWorldTransform();
			}
			if (this._UpdateComplete != null)
			{
				this._UpdateComplete(this);
			}
			this.lastTime = Time.time;
		}

		private int GetAnimationClipNameHashCode(AnimationClip clip)
		{
			int hashCode;
			if (!this.clipNameHashCodeTable.TryGetValue(clip, out hashCode))
			{
				hashCode = clip.name.GetHashCode();
				this.clipNameHashCodeTable.Add(clip, hashCode);
			}
			return hashCode;
		}

		public MixMode[] layerMixModes = new MixMode[0];

		private readonly Dictionary<int, Animation> animationTable = new Dictionary<int, Animation>();

		private readonly Dictionary<AnimationClip, int> clipNameHashCodeTable = new Dictionary<AnimationClip, int>();

		private Animator animator;

		private float lastTime;

		public readonly ExposedList<Event> events;

		public enum MixMode
		{
			AlwaysMix,
			MixNext,
			SpineStyle
		}
	}
}
