using System;
using System.Collections.Generic;
using UnityEngine;

public class Tail : BasePart
{
	public override bool ValidatePart()
	{
		if (!WPFMonoBehaviour.levelManager.RequireConnectedContraption)
		{
			return true;
		}
		List<BasePart> list = base.contraption.FindNeighbours(this.m_coordX, this.m_coordY);
		int num = 0;
		foreach (BasePart basePart in list)
		{
			if (basePart.IsPartOfChassis())
			{
				num++;
			}
		}
		return num >= 1;
	}

	private void Start()
	{
		this.liftCoefficients.AddPoint(-180f, 0f);
		this.liftCoefficients.AddPoint(-135f, -1.5f);
		this.liftCoefficients.AddPoint(-90f, 0f);
		this.liftCoefficients.AddPoint(-45f, -1.5f);
		this.liftCoefficients.AddPoint(-10f, 0f);
		this.liftCoefficients.AddPoint(10f, 1f);
		this.liftCoefficients.AddPoint(45f, 1.5f);
		this.liftCoefficients.AddPoint(90f, 0f);
		this.liftCoefficients.AddPoint(135f, -1.5f);
		this.liftCoefficients.AddPoint(180f, 0f);
	}

	public override void EnsureRigidbody()
	{
		if (base.rigidbody == null)
		{
			base.rigidbody = base.gameObject.AddComponent<Rigidbody>();
		}
		base.rigidbody.constraints = (RigidbodyConstraints)56;
		base.rigidbody.mass = this.m_mass;
		base.rigidbody.drag = 1f;
		base.rigidbody.angularDrag = 0.2f;
		base.rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
	}

	public void FixedUpdate()
	{
		if (!base.contraption || !base.contraption.IsRunning)
		{
			return;
		}
		Vector3 vector = base.rigidbody.velocity - base.WindVelocity;
		base.WindVelocity = Vector3.zero;
		Vector3 vector2 = base.transform.right;
		float num = (!base.IsFlipped()) ? 1f : -1f;
		float num2 = Vector3.Angle(new Vector3(num, 0f, 0f), vector2);
		float num3 = Mathf.Sign(Vector3.Cross(new Vector3(1f, 0f, 0f), vector2).z);
		num2 = num3 * num2;
		float angle = 0.4f * (num2 - 30f);
		vector2 = Quaternion.AngleAxis(angle, base.transform.forward) * vector2;
		float num4 = num * Mathf.Sign(Vector3.Cross(vector, vector2).z);
		float x = num4 * Vector3.Angle(vector, vector2);
		float num5 = this.liftCoefficients.Get(x);
		Vector3 a = Vector3.Cross(base.transform.forward, vector.normalized);
		Vector3 vector3 = this.liftConstant * vector.sqrMagnitude * num5 * a;
		vector3 = Vector3.ClampMagnitude(vector3, 100f);
		base.rigidbody.AddForce(vector3, ForceMode.Force);
	}

	public float liftConstant;

	private ResponseCurve liftCoefficients = new ResponseCurve();
}
