using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonUtilityKinematicShadow : MonoBehaviour
	{
		private void Start()
		{
			this.shadowRoot = UnityEngine.Object.Instantiate<GameObject>(base.gameObject);
			UnityEngine.Object.Destroy(this.shadowRoot.GetComponent<SkeletonUtilityKinematicShadow>());
			Transform transform = this.shadowRoot.transform;
			transform.position = base.transform.position;
			transform.rotation = base.transform.rotation;
			Vector3 b = base.transform.TransformPoint(Vector3.right);
			float d = Vector3.Distance(base.transform.position, b);
			transform.localScale = Vector3.one;
			if (!this.detachedShadow)
			{
				if (this.parent == null)
				{
					transform.parent = base.transform.root;
				}
				else
				{
					transform.parent = this.parent;
				}
			}
			if (this.hideShadow)
			{
				this.shadowRoot.hideFlags = HideFlags.HideInHierarchy;
			}
			Joint[] componentsInChildren = this.shadowRoot.GetComponentsInChildren<Joint>();
			foreach (Joint joint in componentsInChildren)
			{
				joint.connectedAnchor *= d;
			}
			SkeletonUtilityBone[] componentsInChildren2 = base.GetComponentsInChildren<SkeletonUtilityBone>();
			SkeletonUtilityBone[] componentsInChildren3 = this.shadowRoot.GetComponentsInChildren<SkeletonUtilityBone>();
			foreach (SkeletonUtilityBone skeletonUtilityBone in componentsInChildren2)
			{
				if (!(skeletonUtilityBone.gameObject == base.gameObject))
				{
					foreach (SkeletonUtilityBone skeletonUtilityBone2 in componentsInChildren3)
					{
						if (skeletonUtilityBone2.GetComponent<Rigidbody>() != null && skeletonUtilityBone2.boneName == skeletonUtilityBone.boneName)
						{
							this.shadowTable.Add(new TransformPair
                            {
								dest = skeletonUtilityBone.transform,
								src = skeletonUtilityBone2.transform
							});
							break;
						}
					}
				}
			}
			SkeletonUtilityKinematicShadow.DestroyComponents(componentsInChildren3);
			SkeletonUtilityKinematicShadow.DestroyComponents(base.GetComponentsInChildren<Joint>());
			SkeletonUtilityKinematicShadow.DestroyComponents(base.GetComponentsInChildren<Rigidbody>());
			SkeletonUtilityKinematicShadow.DestroyComponents(base.GetComponentsInChildren<Collider>());
		}

		private static void DestroyComponents(Component[] components)
		{
			int i = 0;
			int num = components.Length;
			while (i < num)
			{
				UnityEngine.Object.Destroy(components[i]);
				i++;
			}
		}

		private void FixedUpdate()
		{
			Rigidbody component = this.shadowRoot.GetComponent<Rigidbody>();
			component.MovePosition(base.transform.position);
			component.MoveRotation(base.transform.rotation);
			int i = 0;
			int count = this.shadowTable.Count;
			while (i < count)
			{
                TransformPair transformPair = this.shadowTable[i];
				transformPair.dest.localPosition = transformPair.src.localPosition;
				transformPair.dest.localRotation = transformPair.src.localRotation;
				i++;
			}
		}

		[Tooltip("If checked, the hinge chain can inherit your root transform's velocity or position/rotation changes.")]
		public bool detachedShadow;

		public Transform parent;

		public bool hideShadow = true;

		private GameObject shadowRoot;

		private readonly List<TransformPair> shadowTable = new List<TransformPair>();

		private struct TransformPair
		{
			public Transform dest;

			public Transform src;
		}
	}
}
