using System;
using UnityEngine;

namespace MentalTools
{
	[ExecuteInEditMode]
	public class BezierCurve : MonoBehaviour
	{
		public Bezier Curve
		{
			get
			{
				return this.bezierCurve;
			}
			set
			{
				this.bezierCurve = value;
			}
		}

		public Transform CachedTf
		{
			get
			{
				return this.tf;
			}
		}

		private void Awake()
		{
			this.tf = base.transform;
		}

		private void OnDataLoaded()
		{
			BezierMesh component = base.GetComponent<BezierMesh>();
			if (component != null)
			{
				component.CreateMesh();
			}
		}

		public int bezierPointCount = 10;

		public bool loop;

		[SerializeField]
		private Bezier bezierCurve;

		[NonSerialized]
		private Transform tf;
	}
}
