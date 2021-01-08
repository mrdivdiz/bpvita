using Spine.Unity.MeshGeneration;
using UnityEngine;
using UnityEngine.UI;

namespace Spine.Unity
{
    [ExecuteInEditMode]
	[RequireComponent(typeof(CanvasRenderer), typeof(RectTransform))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Spine/SkeletonGraphic (Unity UI Canvas)")]
	public class SkeletonGraphic : MaskableGraphic, ISkeletonComponent, IAnimationStateComponent, ISkeletonAnimation
	{
		public SkeletonDataAsset SkeletonDataAsset
		{
			get
			{
				return this.skeletonDataAsset;
			}
		}

		public override Texture mainTexture
		{
			get
			{
				return (!(this.skeletonDataAsset == null)) ? this.skeletonDataAsset.atlasAssets[0].materials[0].mainTexture : null;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			if (!this.IsValid)
			{
				this.Initialize(false);
				this.Rebuild(CanvasUpdate.PreRender);
			}
		}

		public override void Rebuild(CanvasUpdate update)
		{
			base.Rebuild(update);
			if (base.canvasRenderer.cull)
			{
				return;
			}
			if (update == CanvasUpdate.PreRender)
			{
				this.UpdateMesh();
			}
		}

		public virtual void Update()
		{
			if (this.freeze)
			{
				return;
			}
			this.Update(Time.deltaTime);
		}

		public virtual void Update(float deltaTime)
		{
			if (!this.IsValid)
			{
				return;
			}
			deltaTime *= this.timeScale;
			this.skeleton.Update(deltaTime);
			this.state.Update(deltaTime);
			this.state.Apply(this.skeleton);
			if (this.UpdateLocal != null)
			{
				this.UpdateLocal(this);
			}
			this.skeleton.UpdateWorldTransform();
			if (this.UpdateWorld != null)
			{
				this.UpdateWorld(this);
				this.skeleton.UpdateWorldTransform();
			}
			if (this.UpdateComplete != null)
			{
				this.UpdateComplete(this);
			}
		}

		public void LateUpdate()
		{
			if (this.freeze)
			{
				return;
			}
			this.UpdateMesh();
		}

		public Skeleton Skeleton
		{
			get
			{
				return this.skeleton;
			}
		}

		public SkeletonData SkeletonData
		{
			get
			{
				return (this.skeleton != null) ? this.skeleton.data : null;
			}
		}

		public bool IsValid
		{
			get
			{
				return this.skeleton != null;
			}
		}

		public AnimationState AnimationState
		{
			get
			{
				return this.state;
			}
		}

		public ISimpleMeshGenerator SpineMeshGenerator
		{
			get
			{
				return this.spineMeshGenerator;
			}
		}

		public event UpdateBonesDelegate UpdateLocal;

		public event UpdateBonesDelegate UpdateWorld;

		public event UpdateBonesDelegate UpdateComplete;

		public void Clear()
		{
			this.skeleton = null;
			base.canvasRenderer.Clear();
		}

		public void Initialize(bool overwrite)
		{
			if (this.IsValid && !overwrite)
			{
				return;
			}
			if (this.skeletonDataAsset == null)
			{
				return;
			}
			SkeletonData skeletonData = this.skeletonDataAsset.GetSkeletonData(false);
			if (skeletonData == null)
			{
				return;
			}
			if (this.skeletonDataAsset.atlasAssets.Length <= 0 || this.skeletonDataAsset.atlasAssets[0].materials.Length <= 0)
			{
				return;
			}
			this.state = new AnimationState(this.skeletonDataAsset.GetAnimationStateData());
			if (this.state == null)
			{
				this.Clear();
				return;
			}
			this.skeleton = new Skeleton(skeletonData);
			this.spineMeshGenerator = new ArraysSimpleMeshGenerator();
			this.spineMeshGenerator.PremultiplyVertexColors = true;
			if (!string.IsNullOrEmpty(this.initialSkinName))
			{
				this.skeleton.SetSkin(this.initialSkinName);
			}
			if (!string.IsNullOrEmpty(this.startingAnimation))
			{
				this.state.SetAnimation(0, this.startingAnimation, this.startingLoop);
			}
		}

		public void UpdateMesh()
		{
			if (this.IsValid)
			{
				this.skeleton.SetColor(this.color);
				if (base.canvas != null)
				{
					this.spineMeshGenerator.Scale = base.canvas.referencePixelsPerUnit;
				}
				base.canvasRenderer.SetMesh(this.spineMeshGenerator.GenerateMesh(this.skeleton));
			}
		}

		public SkeletonDataAsset skeletonDataAsset;

		[SpineSkin("", "skeletonDataAsset")]
		public string initialSkinName = "default";

		[SpineAnimation("", "skeletonDataAsset")]
		public string startingAnimation;

		public bool startingLoop;

		public float timeScale = 1f;

		public bool freeze;

		protected Skeleton skeleton;

		protected AnimationState state;

		protected ISimpleMeshGenerator spineMeshGenerator;
	}
}
