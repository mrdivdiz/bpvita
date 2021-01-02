using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonUtilityEyeConstraint : SkeletonUtilityConstraint
	{
		protected override void OnEnable()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			base.OnEnable();
			Bounds bounds = new Bounds(this.eyes[0].localPosition, Vector3.zero);
			this.origins = new Vector3[this.eyes.Length];
			for (int i = 0; i < this.eyes.Length; i++)
			{
				this.origins[i] = this.eyes[i].localPosition;
				bounds.Encapsulate(this.origins[i]);
			}
			this.centerPoint = bounds.center;
		}

		protected override void OnDisable()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			base.OnDisable();
		}

		public override void DoUpdate()
		{
			if (this.target != null)
			{
				this.targetPosition = this.target.position;
			}
			Vector3 a = this.targetPosition;
			Vector3 vector = base.transform.TransformPoint(this.centerPoint);
			Vector3 a2 = a - vector;
			if (a2.magnitude > 1f)
			{
				a2.Normalize();
			}
			for (int i = 0; i < this.eyes.Length; i++)
			{
				vector = base.transform.TransformPoint(this.origins[i]);
				this.eyes[i].position = Vector3.MoveTowards(this.eyes[i].position, vector + a2 * this.radius, this.speed * Time.deltaTime);
			}
		}

		public Transform[] eyes;

		public float radius = 0.5f;

		public Transform target;

		public Vector3 targetPosition;

		public float speed = 10f;

		private Vector3[] origins;

		private Vector3 centerPoint;
	}
}
