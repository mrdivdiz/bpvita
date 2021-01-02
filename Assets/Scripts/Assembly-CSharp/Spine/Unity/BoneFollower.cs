using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spine.Unity
{
	[ExecuteInEditMode]
	[AddComponentMenu("Spine/BoneFollower")]
	public class BoneFollower : MonoBehaviour
	{
		public SkeletonRenderer SkeletonRenderer
		{
			get
			{
				return this.skeletonRenderer;
			}
			set
			{
				this.skeletonRenderer = value;
				this.Initialize();
			}
		}

		public void Awake()
		{
			if (this.initializeOnAwake)
			{
				this.Initialize();
			}
		}

		public void HandleRebuildRenderer(SkeletonRenderer skeletonRenderer)
		{
			this.Initialize();
		}

		public void Initialize()
		{
			this.bone = null;
			this.valid = (this.skeletonRenderer != null && this.skeletonRenderer.valid);
			if (!this.valid)
			{
				return;
			}
			this.skeletonTransform = this.skeletonRenderer.transform;
			SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
			skeletonRenderer.OnRebuild = (SkeletonRenderer.SkeletonRendererDelegate)Delegate.Remove(skeletonRenderer.OnRebuild, new SkeletonRenderer.SkeletonRendererDelegate(this.HandleRebuildRenderer));
			SkeletonRenderer skeletonRenderer2 = this.skeletonRenderer;
			skeletonRenderer2.OnRebuild = (SkeletonRenderer.SkeletonRendererDelegate)Delegate.Combine(skeletonRenderer2.OnRebuild, new SkeletonRenderer.SkeletonRendererDelegate(this.HandleRebuildRenderer));
		}

		private void OnDestroy()
		{
			if (this.skeletonRenderer != null)
			{
				SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
				skeletonRenderer.OnRebuild = (SkeletonRenderer.SkeletonRendererDelegate)Delegate.Remove(skeletonRenderer.OnRebuild, new SkeletonRenderer.SkeletonRendererDelegate(this.HandleRebuildRenderer));
			}
		}

		public void LateUpdate()
		{
			if (!this.valid)
			{
				this.Initialize();
				return;
			}
			if (this.bone == null)
			{
				if (string.IsNullOrEmpty(this.boneName))
				{
					return;
				}
				this.bone = this.skeletonRenderer.skeleton.FindBone(this.boneName);
				if (this.bone == null)
				{
					return;
				}
			}
			Transform transform = base.transform;
			if (transform.parent == this.skeletonTransform)
			{
				transform.localPosition = new Vector3(this.bone.worldX, this.bone.worldY, (!this.followZPosition) ? transform.localPosition.z : 0f);
				if (this.followBoneRotation)
				{
					transform.localRotation = Quaternion.Euler(0f, 0f, this.bone.WorldRotationX);
				}
			}
			else
			{
				Vector3 position = this.skeletonTransform.TransformPoint(new Vector3(this.bone.worldX, this.bone.worldY, 0f));
				if (!this.followZPosition)
				{
					position.z = transform.position.z;
				}
				transform.position = position;
				if (this.followBoneRotation)
				{
					Vector3 eulerAngles = this.skeletonTransform.rotation.eulerAngles;
					transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, this.skeletonTransform.rotation.eulerAngles.z + this.bone.WorldRotationX);
				}
			}
			if (this.followSkeletonFlip)
			{
				float y = (!(this.bone.skeleton.flipX ^ this.bone.skeleton.flipY)) ? 1f : -1f;
				transform.localScale = new Vector3(1f, y, 1f);
			}
		}

		public SkeletonRenderer skeletonRenderer;

		[SpineBone("", "skeletonRenderer")]
		public string boneName;

		public bool followZPosition = true;

		public bool followBoneRotation = true;

		[Tooltip("Follows the skeleton's flip state by controlling this Transform's local scale.")]
		public bool followSkeletonFlip;

		[FormerlySerializedAs("resetOnAwake")]
		public bool initializeOnAwake = true;

		[NonSerialized]
		public bool valid;

		[NonSerialized]
		public Bone bone;

		private Transform skeletonTransform;
	}
}
