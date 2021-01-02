using UnityEngine;

namespace Spine.Unity
{
    [RequireComponent(typeof(SkeletonUtilityBone))]
	[ExecuteInEditMode]
	public abstract class SkeletonUtilityConstraint : MonoBehaviour
	{
		protected virtual void OnEnable()
		{
			this.utilBone = base.GetComponent<SkeletonUtilityBone>();
			this.skeletonUtility = SkeletonUtility.GetInParent<SkeletonUtility>(base.transform);
			this.skeletonUtility.RegisterConstraint(this);
		}

		protected virtual void OnDisable()
		{
			this.skeletonUtility.UnregisterConstraint(this);
		}

		public abstract void DoUpdate();

		protected SkeletonUtilityBone utilBone;

		protected SkeletonUtility skeletonUtility;
	}
}
