using UnityEngine;

namespace Spine.Unity
{
    [ExecuteInEditMode]
	[AddComponentMenu("Spine/SkeletonAnimation")]
	[HelpURL("http://esotericsoftware.com/spine-unity-documentation#Controlling-Animation")]
	public class SkeletonAnimation : SkeletonRenderer, ISkeletonAnimation, IAnimationStateComponent
	{
		public AnimationState AnimationState
		{
			get
			{
				return this.state;
			}
		}

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

		public string AnimationName
		{
			get
			{
				if (!this.valid)
				{
					return null;
				}
				TrackEntry current = this.state.GetCurrent(0);
				return (current != null) ? current.Animation.Name : null;
			}
			set
			{
				if (this._animationName == value)
				{
					return;
				}
				this._animationName = value;
				if (!this.valid)
				{
					return;
				}
				if (string.IsNullOrEmpty(value))
				{
					this.state.ClearTrack(0);
				}
				else
				{
					this.state.SetAnimation(0, value, this.loop);
				}
			}
		}

		public static SkeletonAnimation AddToGameObject(GameObject gameObject, SkeletonDataAsset skeletonDataAsset)
		{
			return SkeletonRenderer.AddSpineComponent<SkeletonAnimation>(gameObject, skeletonDataAsset);
		}

		public static SkeletonAnimation NewSkeletonAnimationGameObject(SkeletonDataAsset skeletonDataAsset)
		{
			return SkeletonRenderer.NewSpineGameObject<SkeletonAnimation>(skeletonDataAsset);
		}

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
			this.state = new AnimationState(this.skeletonDataAsset.GetAnimationStateData());
			if (!string.IsNullOrEmpty(this._animationName))
			{
				this.state.SetAnimation(0, this._animationName, this.loop);
				this.Update(0f);
			}
		}

		public virtual void Update()
		{
			this.Update(Time.deltaTime);
		}

		public virtual void Update(float deltaTime)
		{
			if (!this.valid)
			{
				return;
			}
			deltaTime *= this.timeScale;
			this.skeleton.Update(deltaTime);
			this.state.Update(deltaTime);
			this.state.Apply(this.skeleton);
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
		}

		public AnimationState state;

		[SerializeField]
		[SpineAnimation("", "")]
		private string _animationName;

		[Tooltip("Whether or not an animation should loop. This only applies to the initial animation specified in the inspector, or any subsequent Animations played through .AnimationName. Animations set through state.SetAnimation are unaffected.")]
		public bool loop;

		[Tooltip("The rate at which animations progress over time. 1 means 100%. 0.5 means 50%.")]
		public float timeScale = 1f;
	}
}
