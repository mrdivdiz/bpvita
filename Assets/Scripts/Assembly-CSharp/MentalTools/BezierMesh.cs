using System;
using UnityEngine;

namespace MentalTools
{
	public class BezierMesh : MonoBehaviour
	{
		public void CreateMesh()
		{
			this.bezierCurve = base.GetComponent<BezierCurve>();
			if (this.bezierCurve == null)
			{
				return;
			}
			if (this.polygon != null)
			{
				this.DeleteMesh();
			}
			this.polygon = MeshTool.CreateMeshFromBezier(this.bezierCurve, base.transform, MentalMath.AxisSpace.XY, false);
			if (this.mainMaterial != null)
			{
				this.polygon.GetComponent<MeshRenderer>().sharedMaterial = this.mainMaterial;
			}
			if (this.secondMaterial != null)
			{
				GameObject gameObject = new GameObject("Border");
				gameObject.transform.SetParent(this.polygon.transform);
				gameObject.transform.localPosition = Vector3.forward * 0.25f;
				gameObject.transform.localScale = Vector3.one;
				BezierCurve bezierCurve = gameObject.AddComponent<BezierCurve>();
				bezierCurve.bezierPointCount = this.bezierCurve.bezierPointCount;
				bezierCurve.loop = this.bezierCurve.loop;
				bezierCurve.Curve = new Bezier();
				for (int i = 0; i < this.bezierCurve.Curve.Count; i++)
				{
					BezierNode bezierNode = bezierCurve.Curve.AddNode(this.bezierCurve.Curve[i].Position, this.bezierCurve.Curve[i].ForwardTangent, this.bezierCurve.Curve[i].BackwardTangent);
					bezierNode.ForwardTangentType = this.bezierCurve.Curve[i].ForwardTangentType;
					bezierNode.BackwardTangentType = this.bezierCurve.Curve[i].BackwardTangentType;
				}
				this.borderPolygon = MeshTool.CreateMeshStripFromBezier(bezierCurve, gameObject.transform, MentalMath.AxisSpace.XY, this.borderWidth, false);
				this.borderPolygon.GetComponent<MeshRenderer>().sharedMaterial = this.secondMaterial;
			}
		}

		public void DeleteMesh()
		{
			if (this.polygon != null)
			{
				UnityEngine.Object.DestroyImmediate(this.polygon);
			}
		}

		public Material mainMaterial;

		public Material secondMaterial;

		public float borderWidth;

		private BezierCurve bezierCurve;

		[SerializeField]
		private GameObject polygon;

		[SerializeField]
		private GameObject borderPolygon;
	}
}
