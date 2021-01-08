using System;
using System.Collections.Generic;
using UnityEngine;

public class Wings : BasePart
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

	protected override void OnFlipped()
	{
		Transform transform = base.transform.Find("WingSprite");
		if (transform)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -transform.localPosition.z);
		}
	}

	public override void ChangeVisualConnections()
	{
		bool flag = base.contraption.CanConnectTo(this, BasePart.Direction.Up) || base.contraption.CanConnectTo(this, BasePart.Direction.Left) || base.contraption.CanConnectTo(this, BasePart.Direction.Right);
		bool flag2 = base.contraption.CanConnectTo(this, BasePart.Direction.Down) || base.contraption.CanConnectTo(this, BasePart.Direction.Left) || base.contraption.CanConnectTo(this, BasePart.Direction.Right);
		bool active = flag;
		bool flag3 = flag2 || !flag;
		base.transform.Find("TopFrameSprite").gameObject.SetActive(active);
		base.transform.Find("BottomFrameSprite").gameObject.SetActive(flag3);
		Vector3 center = base.GetComponent<BoxCollider>().center;
		Vector3 size = base.GetComponent<BoxCollider>().size;
		if (!flag3)
		{
			base.GetComponent<BoxCollider>().center = new Vector3(center.x, 0.05f, center.z);
			base.GetComponent<BoxCollider>().size = new Vector3(size.x, 0.3f, size.z);
		}
		else
		{
			base.GetComponent<BoxCollider>().center = new Vector3(center.x, -0.15f, center.z);
			base.GetComponent<BoxCollider>().size = new Vector3(size.x, 0.6f, size.z);
		}
	}

	private void Start()
	{
		this.liftCoefficients.AddPoint(-180f, 0f);
		this.liftCoefficients.AddPoint(-135f, -0.2f);
		this.liftCoefficients.AddPoint(-90f, 0f);
		this.liftCoefficients.AddPoint(-45f, -0.2f);
		this.liftCoefficients.AddPoint(-10f, 0f);
		this.liftCoefficients.AddPoint(10f, 1.5f);
		this.liftCoefficients.AddPoint(15f, 1.75f);
		this.liftCoefficients.AddPoint(19f, 0.8f);
		this.liftCoefficients.AddPoint(22f, 0.1f);
		this.liftCoefficients.AddPoint(45f, 0.2f);
		this.liftCoefficients.AddPoint(90f, 0f);
		this.liftCoefficients.AddPoint(135f, -0.2f);
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
		Vector3 right = base.transform.right;
		float num = (!base.IsFlipped()) ? 1f : -1f;
		float num2 = num * Mathf.Sign(Vector3.Cross(vector, right).z);
		float x = num2 * Vector3.Angle(vector, right);
		float num3 = this.liftCoefficients.Get(x);
		Vector3 a = Vector3.Cross(base.transform.forward, vector.normalized);
		Vector3 vector2 = this.liftConstant * vector.sqrMagnitude * num3 * a;
		vector2 = Vector3.ClampMagnitude(vector2, 100f);
		base.rigidbody.AddForce(vector2, ForceMode.Force);
	}

	public float liftConstant = 0.8f;

	public float dragConstant = 0.8f;

	private ResponseCurve liftCoefficients = new ResponseCurve();
}
