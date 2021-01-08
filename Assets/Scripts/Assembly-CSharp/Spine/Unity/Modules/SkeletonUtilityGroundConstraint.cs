using UnityEngine;

namespace Spine.Unity.Modules
{
    [RequireComponent(typeof(SkeletonUtilityBone))]
	[ExecuteInEditMode]
	public class SkeletonUtilityGroundConstraint : SkeletonUtilityConstraint
	{
		protected override void OnEnable()
		{
			base.OnEnable();
			this.lastHitY = base.transform.position.y;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
		}

		public override void DoUpdate()
		{
			this.rayOrigin = base.transform.position + new Vector3(this.castOffset, this.castDistance, 0f);
			this.hitY = float.MinValue;
			if (this.use2D)
			{
				RaycastHit2D raycastHit2D;
				if (this.useRadius)
				{
					raycastHit2D = Physics2D.CircleCast(this.rayOrigin, this.castRadius, this.rayDir, this.castDistance + this.groundOffset, this.groundMask);
				}
				else
				{
					raycastHit2D = Physics2D.Raycast(this.rayOrigin, this.rayDir, this.castDistance + this.groundOffset, this.groundMask);
				}
				if (raycastHit2D.collider != null)
				{
					this.hitY = raycastHit2D.point.y + this.groundOffset;
					if (Application.isPlaying)
					{
						this.hitY = Mathf.MoveTowards(this.lastHitY, this.hitY, this.adjustSpeed * Time.deltaTime);
					}
				}
				else if (Application.isPlaying)
				{
					this.hitY = Mathf.MoveTowards(this.lastHitY, base.transform.position.y, this.adjustSpeed * Time.deltaTime);
				}
			}
			else
			{
				RaycastHit raycastHit;
				bool flag;
				if (this.useRadius)
				{
					flag = Physics.SphereCast(this.rayOrigin, this.castRadius, this.rayDir, out raycastHit, this.castDistance + this.groundOffset, this.groundMask);
				}
				else
				{
					flag = Physics.Raycast(this.rayOrigin, this.rayDir, out raycastHit, this.castDistance + this.groundOffset, this.groundMask);
				}
				if (flag)
				{
					this.hitY = raycastHit.point.y + this.groundOffset;
					if (Application.isPlaying)
					{
						this.hitY = Mathf.MoveTowards(this.lastHitY, this.hitY, this.adjustSpeed * Time.deltaTime);
					}
				}
				else if (Application.isPlaying)
				{
					this.hitY = Mathf.MoveTowards(this.lastHitY, base.transform.position.y, this.adjustSpeed * Time.deltaTime);
				}
			}
			Vector3 position = base.transform.position;
			position.y = Mathf.Clamp(position.y, Mathf.Min(this.lastHitY, this.hitY), float.MaxValue);
			base.transform.position = position;
			this.utilBone.bone.X = base.transform.localPosition.x;
			this.utilBone.bone.Y = base.transform.localPosition.y;
			this.lastHitY = this.hitY;
		}

		private void OnDrawGizmos()
		{
			Vector3 vector = this.rayOrigin + this.rayDir * Mathf.Min(this.castDistance, this.rayOrigin.y - this.hitY);
			Vector3 to = this.rayOrigin + this.rayDir * this.castDistance;
			Gizmos.DrawLine(this.rayOrigin, vector);
			if (this.useRadius)
			{
				Gizmos.DrawLine(new Vector3(vector.x - this.castRadius, vector.y - this.groundOffset, vector.z), new Vector3(vector.x + this.castRadius, vector.y - this.groundOffset, vector.z));
				Gizmos.DrawLine(new Vector3(to.x - this.castRadius, to.y, to.z), new Vector3(to.x + this.castRadius, to.y, to.z));
			}
			Gizmos.color = Color.red;
			Gizmos.DrawLine(vector, to);
		}

		[Tooltip("LayerMask for what objects to raycast against")]
		public LayerMask groundMask;

		[Tooltip("The 2D")]
		public bool use2D;

		[Tooltip("Uses SphereCast for 3D mode and CircleCast for 2D mode")]
		public bool useRadius;

		[Tooltip("The Radius")]
		public float castRadius = 0.1f;

		[Tooltip("How high above the target bone to begin casting from")]
		public float castDistance = 5f;

		[Tooltip("X-Axis adjustment")]
		public float castOffset;

		[Tooltip("Y-Axis adjustment")]
		public float groundOffset;

		[Tooltip("How fast the target IK position adjusts to the ground.  Use smaller values to prevent snapping")]
		public float adjustSpeed = 5f;

		private Vector3 rayOrigin;

		private Vector3 rayDir = new Vector3(0f, -1f, 0f);

		private float hitY;

		private float lastHitY;
	}
}
