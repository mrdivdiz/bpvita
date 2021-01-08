using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.Modules
{
    [RequireComponent(typeof(SkeletonRenderer))]
	public class SkeletonRagdoll : MonoBehaviour
	{
		public Rigidbody RootRigidbody { get; private set; }

		public Bone StartingBone { get; private set; }

		public Vector3 RootOffset
		{
			get
			{
				return this.rootOffset;
			}
		}

		public bool IsActive
		{
			get
			{
				return this.isActive;
			}
		}

		private IEnumerator Start()
		{
			if (SkeletonRagdoll.parentSpaceHelper == null)
			{
				SkeletonRagdoll.parentSpaceHelper = new GameObject("Parent Space Helper").transform;
				SkeletonRagdoll.parentSpaceHelper.hideFlags = HideFlags.HideInHierarchy;
			}
			this.targetSkeletonComponent = (base.GetComponent<SkeletonRenderer>() as ISkeletonAnimation);
			if (this.targetSkeletonComponent == null)
			{
			}
			this.skeleton = this.targetSkeletonComponent.Skeleton;
			if (this.applyOnStart)
			{
				yield return null;
				this.Apply();
			}
			yield break;
		}

		public Rigidbody[] RigidbodyArray
		{
			get
			{
				if (!this.isActive)
				{
					return new Rigidbody[0];
				}
				Rigidbody[] array = new Rigidbody[this.boneTable.Count];
				int num = 0;
				foreach (Transform transform in this.boneTable.Values)
				{
					array[num] = transform.GetComponent<Rigidbody>();
					num++;
				}
				return array;
			}
		}

		public Vector3 EstimatedSkeletonPosition
		{
			get
			{
				return this.RootRigidbody.position - this.rootOffset;
			}
		}

		public void Apply()
		{
			this.isActive = true;
			this.mix = 1f;
			this.StartingBone = this.skeleton.FindBone(this.startingBoneName);
			this.RecursivelyCreateBoneProxies(this.StartingBone);
			this.RootRigidbody = this.boneTable[this.StartingBone].GetComponent<Rigidbody>();
			this.RootRigidbody.isKinematic = this.pinStartBone;
			this.RootRigidbody.mass = this.rootMass;
			List<Collider> list = new List<Collider>();
			foreach (KeyValuePair<Bone, Transform> keyValuePair in this.boneTable)
			{
				Bone key = keyValuePair.Key;
				Transform value = keyValuePair.Value;
				list.Add(value.GetComponent<Collider>());
				Transform transform;
				if (key == this.StartingBone)
				{
					this.ragdollRoot = new GameObject("RagdollRoot").transform;
					this.ragdollRoot.SetParent(base.transform, false);
					if (key == this.skeleton.RootBone)
					{
						this.ragdollRoot.localPosition = new Vector3(key.WorldX, key.WorldY, 0f);
						this.ragdollRoot.localRotation = Quaternion.Euler(0f, 0f, SkeletonRagdoll.GetPropagatedRotation(key));
					}
					else
					{
						this.ragdollRoot.localPosition = new Vector3(key.Parent.WorldX, key.Parent.WorldY, 0f);
						this.ragdollRoot.localRotation = Quaternion.Euler(0f, 0f, SkeletonRagdoll.GetPropagatedRotation(key.Parent));
					}
					transform = this.ragdollRoot;
					this.rootOffset = value.position - base.transform.position;
				}
				else
				{
					transform = this.boneTable[key.Parent];
				}
				Rigidbody component = transform.GetComponent<Rigidbody>();
				if (component != null)
				{
					HingeJoint hingeJoint = value.gameObject.AddComponent<HingeJoint>();
					hingeJoint.connectedBody = component;
					Vector3 connectedAnchor = transform.InverseTransformPoint(value.position);
					connectedAnchor.x *= 1f;
					hingeJoint.connectedAnchor = connectedAnchor;
					hingeJoint.axis = Vector3.forward;
					hingeJoint.GetComponent<Rigidbody>().mass = hingeJoint.connectedBody.mass * this.massFalloffFactor;
					hingeJoint.limits = new JointLimits
					{
						min = -this.rotationLimit,
						max = this.rotationLimit
					};
					hingeJoint.useLimits = true;
					hingeJoint.enableCollision = this.enableJointCollision;
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (i != j)
					{
						Physics.IgnoreCollision(list[i], list[j]);
					}
				}
			}
			SkeletonUtilityBone[] componentsInChildren = base.GetComponentsInChildren<SkeletonUtilityBone>();
			if (componentsInChildren.Length > 0)
			{
				List<string> list2 = new List<string>();
				foreach (SkeletonUtilityBone skeletonUtilityBone in componentsInChildren)
				{
					if (skeletonUtilityBone.mode == SkeletonUtilityBone.Mode.Override)
					{
						list2.Add(skeletonUtilityBone.gameObject.name);
						UnityEngine.Object.Destroy(skeletonUtilityBone.gameObject);
					}
				}
				if (list2.Count > 0)
				{
					string str = "Destroyed Utility Bones: ";
					for (int l = 0; l < list2.Count; l++)
					{
						str += list2[l];
						if (l != list2.Count - 1)
						{
							str += ",";
						}
					}
				}
			}
			if (this.disableIK)
			{
				ExposedList<IkConstraint> ikConstraints = this.skeleton.IkConstraints;
				int m = 0;
				int count = ikConstraints.Count;
				while (m < count)
				{
					ikConstraints.Items[m].mix = 0f;
					m++;
				}
			}
			if (this.disableOtherConstraints)
			{
				ExposedList<TransformConstraint> transformConstraints = this.skeleton.transformConstraints;
				int n = 0;
				int count2 = transformConstraints.Count;
				while (n < count2)
				{
					transformConstraints.Items[n].rotateMix = 0f;
					transformConstraints.Items[n].scaleMix = 0f;
					transformConstraints.Items[n].shearMix = 0f;
					transformConstraints.Items[n].translateMix = 0f;
					n++;
				}
				ExposedList<PathConstraint> pathConstraints = this.skeleton.pathConstraints;
				int num = 0;
				int count3 = pathConstraints.Count;
				while (num < count3)
				{
					pathConstraints.Items[num].rotateMix = 0f;
					pathConstraints.Items[num].translateMix = 0f;
					num++;
				}
			}
			this.targetSkeletonComponent.UpdateWorld += this.UpdateSpineSkeleton;
		}

		public Coroutine SmoothMix(float target, float duration)
		{
			return base.StartCoroutine(this.SmoothMixCoroutine(target, duration));
		}

		private IEnumerator SmoothMixCoroutine(float target, float duration)
		{
			float startTime = Time.time;
			float startMix = this.mix;
			while (this.mix > 0f)
			{
				this.mix = Mathf.SmoothStep(startMix, target, (Time.time - startTime) / duration);
				yield return null;
			}
			yield break;
		}

		public void SetSkeletonPosition(Vector3 worldPosition)
		{
			if (!this.isActive)
			{
				return;
			}
			Vector3 b = worldPosition - base.transform.position;
			base.transform.position = worldPosition;
			foreach (Transform transform in this.boneTable.Values)
			{
				transform.position -= b;
			}
			this.UpdateSpineSkeleton(null);
			this.skeleton.UpdateWorldTransform();
		}

		public void Remove()
		{
			this.isActive = false;
			foreach (Transform transform in this.boneTable.Values)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
			UnityEngine.Object.Destroy(this.ragdollRoot.gameObject);
			this.boneTable.Clear();
			this.targetSkeletonComponent.UpdateWorld -= this.UpdateSpineSkeleton;
		}

		public Rigidbody GetRigidbody(string boneName)
		{
			Bone bone = this.skeleton.FindBone(boneName);
			return (bone == null || !this.boneTable.ContainsKey(bone)) ? null : this.boneTable[bone].GetComponent<Rigidbody>();
		}

		private void RecursivelyCreateBoneProxies(Bone b)
		{
			string name = b.data.name;
			if (this.stopBoneNames.Contains(name))
			{
				return;
			}
			GameObject gameObject = new GameObject(name);
			gameObject.layer = this.colliderLayer;
			Transform transform = gameObject.transform;
			this.boneTable.Add(b, transform);
			transform.parent = base.transform;
			transform.localPosition = new Vector3(b.WorldX, b.WorldY, 0f);
			transform.localRotation = Quaternion.Euler(0f, 0f, b.WorldRotationX - b.shearX);
			transform.localScale = new Vector3(b.WorldScaleX, b.WorldScaleY, 1f);
			List<Collider> list = this.AttachBoundingBoxRagdollColliders(b);
			if (list.Count == 0)
			{
				float length = b.Data.Length;
				if (length == 0f)
				{
					SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
					sphereCollider.radius = this.thickness * 0.5f;
				}
				else
				{
					BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
					boxCollider.size = new Vector3(length, this.thickness, this.thickness);
					boxCollider.center = new Vector3(length * 0.5f, 0f);
				}
			}
			Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
			rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
			foreach (Bone b2 in b.Children)
			{
				this.RecursivelyCreateBoneProxies(b2);
			}
		}

		private void UpdateSpineSkeleton(ISkeletonAnimation skeletonRenderer)
		{
			bool flipX = this.skeleton.flipX;
			bool flipY = this.skeleton.flipY;
			bool flag = flipX ^ flipY;
			bool flag2 = flipX || flipY;
			foreach (KeyValuePair<Bone, Transform> keyValuePair in this.boneTable)
			{
				Bone key = keyValuePair.Key;
				Transform value = keyValuePair.Value;
				bool flag3 = key == this.StartingBone;
				Transform transform = (!flag3) ? this.boneTable[key.Parent] : this.ragdollRoot;
				Vector3 position = transform.position;
				Quaternion rotation = transform.rotation;
				SkeletonRagdoll.parentSpaceHelper.position = position;
				SkeletonRagdoll.parentSpaceHelper.rotation = rotation;
				SkeletonRagdoll.parentSpaceHelper.localScale = transform.localScale;
				Vector3 position2 = value.position;
				Vector3 vector = SkeletonRagdoll.parentSpaceHelper.InverseTransformDirection(value.right);
				Vector3 vector2 = SkeletonRagdoll.parentSpaceHelper.InverseTransformPoint(position2);
				float num = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
				if (flag2)
				{
					if (flag3)
					{
						if (flipX)
						{
							vector2.x *= -1f;
						}
						if (flipY)
						{
							vector2.y *= -1f;
						}
						num *= ((!flag) ? 1f : -1f);
						if (flipX)
						{
							num += 180f;
						}
					}
					else if (flag)
					{
						num *= -1f;
						vector2.y *= -1f;
					}
				}
				key.x = Mathf.Lerp(key.x, vector2.x, this.mix);
				key.y = Mathf.Lerp(key.y, vector2.y, this.mix);
				key.rotation = Mathf.Lerp(key.rotation, num, this.mix);
				key.appliedRotation = Mathf.Lerp(key.appliedRotation, num, this.mix);
			}
		}

		private List<Collider> AttachBoundingBoxRagdollColliders(Bone b)
		{
			List<Collider> list = new List<Collider>();
			Transform transform = this.boneTable[b];
			GameObject gameObject = transform.gameObject;
			Skin skin = this.skeleton.Skin ?? this.skeleton.Data.DefaultSkin;
			List<Attachment> list2 = new List<Attachment>();
			foreach (Slot slot in this.skeleton.Slots)
			{
				if (slot.Bone == b)
				{
					skin.FindAttachmentsForSlot(this.skeleton.Slots.IndexOf(slot), list2);
					foreach (Attachment attachment in list2)
					{
						BoundingBoxAttachment boundingBoxAttachment = attachment as BoundingBoxAttachment;
						if (boundingBoxAttachment != null)
						{
							if (attachment.Name.ToLower().Contains("ragdoll"))
							{
								BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
								Bounds boundingBoxBounds = SkeletonUtility.GetBoundingBoxBounds(boundingBoxAttachment, this.thickness);
								boxCollider.center = boundingBoxBounds.center;
								boxCollider.size = boundingBoxBounds.size;
								list.Add(boxCollider);
							}
						}
					}
				}
			}
			return list;
		}

		private static float GetPropagatedRotation(Bone b)
		{
			Bone parent = b.Parent;
			float num = b.AppliedRotation;
			while (parent != null)
			{
				num += parent.AppliedRotation;
				parent = parent.parent;
			}
			return num;
		}

		private static Transform parentSpaceHelper;

		[Header("Hierarchy")]
		[SpineBone("", "")]
		public string startingBoneName = string.Empty;

		[SpineBone("", "")]
		public List<string> stopBoneNames = new List<string>();

		[Header("Parameters")]
		public bool applyOnStart;

		[Tooltip("Warning!  You will have to re-enable and tune mix values manually if attempting to remove the ragdoll system.")]
		public bool disableIK = true;

		public bool disableOtherConstraints;

		[Space(18f)]
		[Tooltip("Set RootRigidbody IsKinematic to true when Apply is called.")]
		public bool pinStartBone;

		[Tooltip("Enable Collision between adjacent ragdoll elements (IE: Neck and Head)")]
		public bool enableJointCollision;

		public bool useGravity = true;

		[Tooltip("If no BoundingBox Attachment is attached to a bone, this becomes the default Width or Radius of a Bone's ragdoll Rigidbody")]
		public float thickness = 0.125f;

		[Tooltip("Default rotational limit value.  Min is negative this value, Max is this value.")]
		public float rotationLimit = 20f;

		public float rootMass = 20f;

		[Tooltip("If your ragdoll seems unstable or uneffected by limits, try lowering this value.")]
		[Range(0.01f, 1f)]
		public float massFalloffFactor = 0.4f;

		[Tooltip("The layer assigned to all of the rigidbody parts.")]
		public int colliderLayer;

		[Range(0f, 1f)]
		public float mix = 1f;

		private ISkeletonAnimation targetSkeletonComponent;

		private Skeleton skeleton;

		private Dictionary<Bone, Transform> boneTable = new Dictionary<Bone, Transform>();

		private Transform ragdollRoot;

		private Vector3 rootOffset;

		private bool isActive;

		public class LayerFieldAttribute : PropertyAttribute
		{
		}
	}
}
