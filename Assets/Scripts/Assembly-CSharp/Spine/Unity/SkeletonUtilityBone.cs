using System;
using UnityEngine;

namespace Spine.Unity
{
	[ExecuteInEditMode]
	[AddComponentMenu("Spine/SkeletonUtilityBone")]
	public class SkeletonUtilityBone : MonoBehaviour
	{
		public bool DisableInheritScaleWarning
		{
			get
			{
				return this.disableInheritScaleWarning;
			}
		}

		public void Reset()
		{
			this.bone = null;
			this.cachedTransform = base.transform;
			this.valid = (this.skeletonUtility != null && this.skeletonUtility.skeletonRenderer != null && this.skeletonUtility.skeletonRenderer.valid);
			if (!this.valid)
			{
				return;
			}
			this.skeletonTransform = this.skeletonUtility.transform;
			this.skeletonUtility.OnReset -= this.HandleOnReset;
			this.skeletonUtility.OnReset += this.HandleOnReset;
			this.DoUpdate();
		}

		private void OnEnable()
		{
			this.skeletonUtility = SkeletonUtility.GetInParent<SkeletonUtility>(base.transform);
			if (this.skeletonUtility == null)
			{
				return;
			}
			this.skeletonUtility.RegisterBone(this);
			this.skeletonUtility.OnReset += this.HandleOnReset;
		}

		private void HandleOnReset()
		{
			this.Reset();
		}

		private void OnDisable()
		{
			if (this.skeletonUtility != null)
			{
				this.skeletonUtility.OnReset -= this.HandleOnReset;
				this.skeletonUtility.UnregisterBone(this);
			}
		}

		public void DoUpdate()
		{
			if (!this.valid)
			{
				this.Reset();
				return;
			}
			Skeleton skeleton = this.skeletonUtility.skeletonRenderer.skeleton;
			if (this.bone == null)
			{
				if (this.boneName == null || this.boneName.Length == 0)
				{
					return;
				}
				this.bone = skeleton.FindBone(this.boneName);
				if (this.bone == null)
				{
					return;
				}
			}
			float num = (!(skeleton.flipX ^ skeleton.flipY)) ? 1f : -1f;
			if (this.mode == SkeletonUtilityBone.Mode.Follow)
			{
				if (this.position)
				{
					this.cachedTransform.localPosition = new Vector3(this.bone.x, this.bone.y, 0f);
				}
				if (this.rotation)
				{
					if (this.bone.Data.InheritRotation)
					{
						this.cachedTransform.localRotation = Quaternion.Euler(0f, 0f, this.bone.AppliedRotation);
					}
					else
					{
						Vector3 eulerAngles = this.skeletonTransform.rotation.eulerAngles;
						this.cachedTransform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z + this.bone.WorldRotationX * num);
					}
				}
				if (this.scale)
				{
					this.cachedTransform.localScale = new Vector3(this.bone.scaleX, this.bone.scaleY, this.bone.WorldSignX);
					this.disableInheritScaleWarning = !this.bone.data.inheritScale;
				}
			}
			else if (this.mode == SkeletonUtilityBone.Mode.Override)
			{
				if (this.transformLerpComplete)
				{
					return;
				}
				if (this.parentReference == null)
				{
					if (this.position)
					{
						this.bone.x = Mathf.Lerp(this.bone.x, this.cachedTransform.localPosition.x, this.overrideAlpha);
						this.bone.y = Mathf.Lerp(this.bone.y, this.cachedTransform.localPosition.y, this.overrideAlpha);
					}
					if (this.rotation)
					{
						float appliedRotation = Mathf.LerpAngle(this.bone.Rotation, this.cachedTransform.localRotation.eulerAngles.z, this.overrideAlpha);
						this.bone.Rotation = appliedRotation;
						this.bone.AppliedRotation = appliedRotation;
					}
					if (this.scale)
					{
						this.bone.scaleX = Mathf.Lerp(this.bone.scaleX, this.cachedTransform.localScale.x, this.overrideAlpha);
						this.bone.scaleY = Mathf.Lerp(this.bone.scaleY, this.cachedTransform.localScale.y, this.overrideAlpha);
					}
				}
				else
				{
					if (this.transformLerpComplete)
					{
						return;
					}
					if (this.position)
					{
						Vector3 vector = this.parentReference.InverseTransformPoint(this.cachedTransform.position);
						this.bone.x = Mathf.Lerp(this.bone.x, vector.x, this.overrideAlpha);
						this.bone.y = Mathf.Lerp(this.bone.y, vector.y, this.overrideAlpha);
					}
					if (this.rotation)
					{
						float appliedRotation2 = Mathf.LerpAngle(this.bone.Rotation, Quaternion.LookRotation((!this.flipX) ? Vector3.forward : (Vector3.forward * -1f), this.parentReference.InverseTransformDirection(this.cachedTransform.up)).eulerAngles.z, this.overrideAlpha);
						this.bone.Rotation = appliedRotation2;
						this.bone.AppliedRotation = appliedRotation2;
					}
					if (this.scale)
					{
						this.bone.scaleX = Mathf.Lerp(this.bone.scaleX, this.cachedTransform.localScale.x, this.overrideAlpha);
						this.bone.scaleY = Mathf.Lerp(this.bone.scaleY, this.cachedTransform.localScale.y, this.overrideAlpha);
					}
					this.disableInheritScaleWarning = !this.bone.data.inheritScale;
				}
				this.transformLerpComplete = true;
			}
		}

		public void AddBoundingBox(string skinName, string slotName, string attachmentName)
		{
			SkeletonUtility.AddBoundingBox(this.bone.skeleton, skinName, slotName, attachmentName, base.transform, true);
		}

		[NonSerialized]
		public bool valid;

		[NonSerialized]
		public SkeletonUtility skeletonUtility;

		[NonSerialized]
		public Bone bone;

		public Mode mode;

		public bool zPosition = true;

		public bool position;

		public bool rotation;

		public bool scale;

		public bool flip;

		public bool flipX;

		[Range(0f, 1f)]
		public float overrideAlpha = 1f;

		public string boneName;

		public Transform parentReference;

		[NonSerialized]
		public bool transformLerpComplete;

		protected Transform cachedTransform;

		protected Transform skeletonTransform;

		private bool disableInheritScaleWarning;

		public enum Mode
		{
			Follow,
			Override
		}
	}
}
