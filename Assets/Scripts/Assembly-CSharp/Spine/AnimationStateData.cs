using System;
using System.Collections.Generic;

namespace Spine
{
	public class AnimationStateData
	{
		public AnimationStateData(SkeletonData skeletonData)
		{
			if (skeletonData == null)
			{
				throw new ArgumentException("skeletonData cannot be null.");
			}
			this.skeletonData = skeletonData;
		}

		public SkeletonData SkeletonData
		{
			get
			{
				return this.skeletonData;
			}
		}

		public float DefaultMix
		{
			get
			{
				return this.defaultMix;
			}
			set
			{
				this.defaultMix = value;
			}
		}

		public void SetMix(string fromName, string toName, float duration)
		{
			Animation animation = this.skeletonData.FindAnimation(fromName);
			if (animation == null)
			{
				throw new ArgumentException("Animation not found: " + fromName);
			}
			Animation animation2 = this.skeletonData.FindAnimation(toName);
			if (animation2 == null)
			{
				throw new ArgumentException("Animation not found: " + toName);
			}
			this.SetMix(animation, animation2, duration);
		}

		public void SetMix(Animation from, Animation to, float duration)
		{
			if (from == null)
			{
				throw new ArgumentNullException("from", "from cannot be null.");
			}
			if (to == null)
			{
				throw new ArgumentNullException("to", "to cannot be null.");
			}
            AnimationPair key = new AnimationPair(from, to);
			this.animationToMixTime.Remove(key);
			this.animationToMixTime.Add(key, duration);
		}

		public float GetMix(Animation from, Animation to)
		{
            AnimationPair key = new AnimationPair(from, to);
			float result;
			if (this.animationToMixTime.TryGetValue(key, out result))
			{
				return result;
			}
			return this.defaultMix;
		}

		internal SkeletonData skeletonData;

		private Dictionary<AnimationPair, float> animationToMixTime = new Dictionary<AnimationPair, float>(AnimationStateData.AnimationPairComparer.Instance);

		internal float defaultMix;

		private struct AnimationPair
		{
			public AnimationPair(Animation a1, Animation a2)
			{
				this.a1 = a1;
				this.a2 = a2;
			}

			public readonly Animation a1;

			public readonly Animation a2;
		}

		private class AnimationPairComparer : IEqualityComparer<AnimationPair>
		{
			bool IEqualityComparer<AnimationPair>.Equals(AnimationPair x, AnimationPair y)
			{
				return object.ReferenceEquals(x.a1, y.a1) && object.ReferenceEquals(x.a2, y.a2);
			}

			int IEqualityComparer<AnimationPair>.GetHashCode(AnimationPair obj)
			{
				int hashCode = obj.a1.GetHashCode();
				return (hashCode << 5) + hashCode ^ obj.a2.GetHashCode();
			}

			internal static readonly AnimationPairComparer Instance = new AnimationPairComparer();
		}
	}
}
