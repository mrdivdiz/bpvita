using System;
using UnityEngine;

namespace MentalTools
{
	public class BezierFollower : MonoBehaviour
	{
		private void Start()
		{
			this.tf = base.transform;
			if (this.bezier == null)
			{
				return;
			}
			this.targetPosition = this.bezier.Curve.GetPoint(0f, this.bezier.loop, this.bezier.CachedTf.position);
			this.tf.position = this.targetPosition;
		}

		private void Update()
		{
			if (this.bezier == null)
			{
				return;
			}
			while (Vector3.Distance(this.tf.position, this.targetPosition) <= this.step)
			{
				this.t += Time.deltaTime;
				if (this.t > 1f)
				{
					this.t = 0f;
				}
				this.targetPosition = this.bezier.Curve.GetPoint(this.t, this.bezier.loop, this.bezier.CachedTf.position);
			}
			this.tf.position = Vector3.MoveTowards(this.tf.position, this.targetPosition, this.step);
		}

		private void OnDrawGizmos()
		{
			if (Application.isPlaying)
			{
				Gizmos.color = Color.white;
				Gizmos.DrawLine(this.tf.position, this.targetPosition);
			}
		}

		public BezierCurve bezier;

		public float step = 0.01f;

		private float t;

		private Transform tf;

		private Vector3 targetPosition = Vector3.zero;
	}
}
