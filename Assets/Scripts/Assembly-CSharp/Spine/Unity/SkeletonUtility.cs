using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity
{
    [RequireComponent(typeof(ISkeletonAnimation))]
	[ExecuteInEditMode]
	public class SkeletonUtility : MonoBehaviour
	{
		public static T GetInParent<T>(Transform origin) where T : Component
		{
			return origin.GetComponentInParent<T>();
		}

		public static PolygonCollider2D AddBoundingBox(Skeleton skeleton, string skinName, string slotName, string attachmentName, Transform parent, bool isTrigger = true)
		{
			if (skinName == string.Empty)
			{
				skinName = skeleton.Data.DefaultSkin.Name;
			}
			Skin skin = skeleton.Data.FindSkin(skinName);
			if (skin == null)
			{
				return null;
			}
			Attachment attachment = skin.GetAttachment(skeleton.FindSlotIndex(slotName), attachmentName);
			if (attachment is BoundingBoxAttachment)
			{
				PolygonCollider2D polygonCollider2D = new GameObject("[BoundingBox]" + attachmentName)
				{
					transform = 
					{
						parent = parent,
						localPosition = Vector3.zero,
						localRotation = Quaternion.identity,
						localScale = Vector3.one
					}
				}.AddComponent<PolygonCollider2D>();
				polygonCollider2D.isTrigger = isTrigger;
				BoundingBoxAttachment boundingBoxAttachment = (BoundingBoxAttachment)attachment;
				float[] vertices = boundingBoxAttachment.Vertices;
				int num = vertices.Length;
				int num2 = num / 2;
				Vector2[] array = new Vector2[num2];
				int num3 = 0;
				int i = 0;
				while (i < num)
				{
					array[num3].x = vertices[i];
					array[num3].y = vertices[i + 1];
					i += 2;
					num3++;
				}
				polygonCollider2D.SetPath(0, array);
				return polygonCollider2D;
			}
			return null;
		}

		public static PolygonCollider2D AddBoundingBoxAsComponent(BoundingBoxAttachment boundingBox, GameObject gameObject, bool isTrigger = true)
		{
			if (boundingBox == null)
			{
				return null;
			}
			PolygonCollider2D polygonCollider2D = gameObject.AddComponent<PolygonCollider2D>();
			polygonCollider2D.isTrigger = isTrigger;
			float[] vertices = boundingBox.Vertices;
			int num = vertices.Length;
			int num2 = num / 2;
			Vector2[] array = new Vector2[num2];
			int num3 = 0;
			int i = 0;
			while (i < num)
			{
				array[num3].x = vertices[i];
				array[num3].y = vertices[i + 1];
				i += 2;
				num3++;
			}
			polygonCollider2D.SetPath(0, array);
			return polygonCollider2D;
		}

		public static Bounds GetBoundingBoxBounds(BoundingBoxAttachment boundingBox, float depth = 0f)
		{
			float[] vertices = boundingBox.Vertices;
			int num = vertices.Length;
			Bounds result = default(Bounds);
			result.center = new Vector3(vertices[0], vertices[1], 0f);
			for (int i = 2; i < num; i += 2)
			{
				result.Encapsulate(new Vector3(vertices[i], vertices[i + 1], 0f));
			}
			Vector3 size = result.size;
			size.z = depth;
			result.size = size;
			return result;
		}

		public event SkeletonUtilityDelegate OnReset;

		private void Update()
		{
			if (this.boneRoot != null && this.skeletonRenderer.skeleton != null)
			{
				Vector3 one = Vector3.one;
				if (this.skeletonRenderer.skeleton.FlipX)
				{
					one.x = -1f;
				}
				if (this.skeletonRenderer.skeleton.FlipY)
				{
					one.y = -1f;
				}
				this.boneRoot.localScale = one;
			}
		}

		private void OnEnable()
		{
			if (this.skeletonRenderer == null)
			{
				this.skeletonRenderer = base.GetComponent<SkeletonRenderer>();
			}
			if (this.skeletonAnimation == null)
			{
				this.skeletonAnimation = base.GetComponent<SkeletonAnimation>();
				if (this.skeletonAnimation == null)
				{
					this.skeletonAnimation = base.GetComponent<SkeletonAnimator>();
				}
			}
			SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
			skeletonRenderer.OnRebuild = (SkeletonRenderer.SkeletonRendererDelegate)Delegate.Remove(skeletonRenderer.OnRebuild, new SkeletonRenderer.SkeletonRendererDelegate(this.HandleRendererReset));
			SkeletonRenderer skeletonRenderer2 = this.skeletonRenderer;
			skeletonRenderer2.OnRebuild = (SkeletonRenderer.SkeletonRendererDelegate)Delegate.Combine(skeletonRenderer2.OnRebuild, new SkeletonRenderer.SkeletonRendererDelegate(this.HandleRendererReset));
			if (this.skeletonAnimation != null)
			{
				this.skeletonAnimation.UpdateLocal -= this.UpdateLocal;
				this.skeletonAnimation.UpdateLocal += this.UpdateLocal;
			}
			this.CollectBones();
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
			SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
			skeletonRenderer.OnRebuild = (SkeletonRenderer.SkeletonRendererDelegate)Delegate.Remove(skeletonRenderer.OnRebuild, new SkeletonRenderer.SkeletonRendererDelegate(this.HandleRendererReset));
			if (this.skeletonAnimation != null)
			{
				this.skeletonAnimation.UpdateLocal -= this.UpdateLocal;
				this.skeletonAnimation.UpdateWorld -= this.UpdateWorld;
				this.skeletonAnimation.UpdateComplete -= this.UpdateComplete;
			}
		}

		private void HandleRendererReset(SkeletonRenderer r)
		{
			if (this.OnReset != null)
			{
				this.OnReset();
			}
			this.CollectBones();
		}

		public void RegisterBone(SkeletonUtilityBone bone)
		{
			if (this.utilityBones.Contains(bone))
			{
				return;
			}
			this.utilityBones.Add(bone);
			this.needToReprocessBones = true;
		}

		public void UnregisterBone(SkeletonUtilityBone bone)
		{
			this.utilityBones.Remove(bone);
		}

		public void RegisterConstraint(SkeletonUtilityConstraint constraint)
		{
			if (this.utilityConstraints.Contains(constraint))
			{
				return;
			}
			this.utilityConstraints.Add(constraint);
			this.needToReprocessBones = true;
		}

		public void UnregisterConstraint(SkeletonUtilityConstraint constraint)
		{
			this.utilityConstraints.Remove(constraint);
		}

		public void CollectBones()
		{
			if (this.skeletonRenderer.skeleton == null)
			{
				return;
			}
			if (this.boneRoot != null)
			{
				List<string> list = new List<string>();
				ExposedList<IkConstraint> ikConstraints = this.skeletonRenderer.skeleton.IkConstraints;
				int i = 0;
				int count = ikConstraints.Count;
				while (i < count)
				{
					list.Add(ikConstraints.Items[i].Target.Data.Name);
					i++;
				}
				List<SkeletonUtilityBone> list2 = this.utilityBones;
				int j = 0;
				int count2 = list2.Count;
				while (j < count2)
				{
					SkeletonUtilityBone skeletonUtilityBone = list2[j];
					if (skeletonUtilityBone.bone == null)
					{
						return;
					}
					if (skeletonUtilityBone.mode == SkeletonUtilityBone.Mode.Override)
					{
						this.hasTransformBones = true;
					}
					if (list.Contains(skeletonUtilityBone.bone.Data.Name))
					{
						this.hasUtilityConstraints = true;
					}
					j++;
				}
				if (this.utilityConstraints.Count > 0)
				{
					this.hasUtilityConstraints = true;
				}
				if (this.skeletonAnimation != null)
				{
					this.skeletonAnimation.UpdateWorld -= this.UpdateWorld;
					this.skeletonAnimation.UpdateComplete -= this.UpdateComplete;
					if (this.hasTransformBones || this.hasUtilityConstraints)
					{
						this.skeletonAnimation.UpdateWorld += this.UpdateWorld;
					}
					if (this.hasUtilityConstraints)
					{
						this.skeletonAnimation.UpdateComplete += this.UpdateComplete;
					}
				}
				this.needToReprocessBones = false;
			}
			else
			{
				this.utilityBones.Clear();
				this.utilityConstraints.Clear();
			}
		}

		private void UpdateLocal(ISkeletonAnimation anim)
		{
			if (this.needToReprocessBones)
			{
				this.CollectBones();
			}
			List<SkeletonUtilityBone> list = this.utilityBones;
			if (list == null)
			{
				return;
			}
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				list[i].transformLerpComplete = false;
				i++;
			}
			this.UpdateAllBones();
		}

		private void UpdateWorld(ISkeletonAnimation anim)
		{
			this.UpdateAllBones();
			int i = 0;
			int count = this.utilityConstraints.Count;
			while (i < count)
			{
				this.utilityConstraints[i].DoUpdate();
				i++;
			}
		}

		private void UpdateComplete(ISkeletonAnimation anim)
		{
			this.UpdateAllBones();
		}

		private void UpdateAllBones()
		{
			if (this.boneRoot == null)
			{
				this.CollectBones();
			}
			List<SkeletonUtilityBone> list = this.utilityBones;
			if (list == null)
			{
				return;
			}
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				list[i].DoUpdate();
				i++;
			}
		}

		public Transform GetBoneRoot()
		{
			if (this.boneRoot != null)
			{
				return this.boneRoot;
			}
			this.boneRoot = new GameObject("SkeletonUtility-Root").transform;
			this.boneRoot.parent = base.transform;
			this.boneRoot.localPosition = Vector3.zero;
			this.boneRoot.localRotation = Quaternion.identity;
			this.boneRoot.localScale = Vector3.one;
			return this.boneRoot;
		}

		public GameObject SpawnRoot(SkeletonUtilityBone.Mode mode, bool pos, bool rot, bool sca)
		{
			this.GetBoneRoot();
			Skeleton skeleton = this.skeletonRenderer.skeleton;
			GameObject result = this.SpawnBone(skeleton.RootBone, this.boneRoot, mode, pos, rot, sca);
			this.CollectBones();
			return result;
		}

		public GameObject SpawnHierarchy(SkeletonUtilityBone.Mode mode, bool pos, bool rot, bool sca)
		{
			this.GetBoneRoot();
			Skeleton skeleton = this.skeletonRenderer.skeleton;
			GameObject result = this.SpawnBoneRecursively(skeleton.RootBone, this.boneRoot, mode, pos, rot, sca);
			this.CollectBones();
			return result;
		}

		public GameObject SpawnBoneRecursively(Bone bone, Transform parent, SkeletonUtilityBone.Mode mode, bool pos, bool rot, bool sca)
		{
			GameObject gameObject = this.SpawnBone(bone, parent, mode, pos, rot, sca);
			ExposedList<Bone> children = bone.Children;
			int i = 0;
			int count = children.Count;
			while (i < count)
			{
				Bone bone2 = children.Items[i];
				this.SpawnBoneRecursively(bone2, gameObject.transform, mode, pos, rot, sca);
				i++;
			}
			return gameObject;
		}

		public GameObject SpawnBone(Bone bone, Transform parent, SkeletonUtilityBone.Mode mode, bool pos, bool rot, bool sca)
		{
			GameObject gameObject = new GameObject(bone.Data.Name);
			gameObject.transform.parent = parent;
			SkeletonUtilityBone skeletonUtilityBone = gameObject.AddComponent<SkeletonUtilityBone>();
			skeletonUtilityBone.skeletonUtility = this;
			skeletonUtilityBone.position = pos;
			skeletonUtilityBone.rotation = rot;
			skeletonUtilityBone.scale = sca;
			skeletonUtilityBone.mode = mode;
			skeletonUtilityBone.zPosition = true;
			skeletonUtilityBone.Reset();
			skeletonUtilityBone.bone = bone;
			skeletonUtilityBone.boneName = bone.Data.Name;
			skeletonUtilityBone.valid = true;
			if (mode == SkeletonUtilityBone.Mode.Override)
			{
				if (rot)
				{
					gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, skeletonUtilityBone.bone.AppliedRotation);
				}
				if (pos)
				{
					gameObject.transform.localPosition = new Vector3(skeletonUtilityBone.bone.X, skeletonUtilityBone.bone.Y, 0f);
				}
				gameObject.transform.localScale = new Vector3(skeletonUtilityBone.bone.scaleX, skeletonUtilityBone.bone.scaleY, 0f);
			}
			return gameObject;
		}

		public Transform boneRoot;

		[HideInInspector]
		public SkeletonRenderer skeletonRenderer;

		[HideInInspector]
		public ISkeletonAnimation skeletonAnimation;

		[NonSerialized]
		public List<SkeletonUtilityBone> utilityBones = new List<SkeletonUtilityBone>();

		[NonSerialized]
		public List<SkeletonUtilityConstraint> utilityConstraints = new List<SkeletonUtilityConstraint>();

		protected bool hasTransformBones;

		protected bool hasUtilityConstraints;

		protected bool needToReprocessBones;

		public delegate void SkeletonUtilityDelegate();
	}
}
