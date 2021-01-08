using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BridgeStep : LevelRigidbody
{
	private void Awake()
	{
		if (this.breakForce < 0.0001f)
		{
		}
		this.m_transform = base.transform;
		this.m_hingeJoint = base.GetComponent<HingeJoint>();
	}

	private void OnDataLoaded()
	{
	}

	public void Init(bool isKinematic)
	{
		this.m_isKinematic = isKinematic;
		this.freezeOnEnd = false;
		this.SaveState();
		this.LoadState();
	}

	private void SaveState()
	{
		this.m_originalPosition = base.transform.localPosition;
		this.m_originalRotation = base.transform.localRotation;
		if (this.m_hingeJoint)
		{
			if (this.m_originalHingeJointValues == null)
			{
				this.m_originalHingeJointValues = new HingeJointValues();
			}
			this.m_originalHingeJointValues.connectedBody = this.m_hingeJoint.connectedBody;
			this.m_originalHingeJointValues.anchor = this.m_hingeJoint.anchor;
			this.m_originalHingeJointValues.axis = this.m_hingeJoint.axis;
			this.m_originalHingeJointValues.connectedAnchor = this.m_hingeJoint.connectedAnchor;
			this.m_originalHingeJointValues.autoConfigureConnectedAnchor = this.m_hingeJoint.autoConfigureConnectedAnchor;
			this.m_originalHingeJointValues.useMotor = this.m_hingeJoint.useMotor;
			this.m_originalHingeJointValues.motor = this.m_hingeJoint.motor;
			this.m_originalHingeJointValues.useSpring = this.m_hingeJoint.useSpring;
			this.m_originalHingeJointValues.spring = this.m_hingeJoint.spring;
			this.m_originalHingeJointValues.useLimits = this.m_hingeJoint.useLimits;
			this.m_originalHingeJointValues.limits = this.m_hingeJoint.limits;
			this.m_originalHingeJointValues.breakForce = this.m_hingeJoint.breakForce;
			this.m_originalHingeJointValues.breakTorque = this.m_hingeJoint.breakTorque;
		}
	}

	public void LoadState()
	{
		base.StartCoroutine(this.LoadStateRoutine());
	}

	private IEnumerator LoadStateRoutine()
	{
		base.rigidbody.isKinematic = true;
		yield return new WaitForFixedUpdate();
		this.ResetTransform();
		this.ResetJoints();
		yield return new WaitForFixedUpdate();
		this.ResetRigidbody();
		yield break;
	}

	private void ResetTransform()
	{
		this.m_transform = (this.m_transform ?? base.transform);
		this.m_transform.localPosition = this.m_originalPosition;
		this.m_transform.localRotation = this.m_originalRotation;
	}

	private void ResetJoints()
	{
		if (this.m_hingeJoint == null && this.m_originalHingeJointValues != null)
		{
			this.m_hingeJoint = base.gameObject.AddComponent<HingeJoint>();
		}
		if (this.m_originalHingeJointValues == null || this.m_hingeJoint == null)
		{
			return;
		}
		this.m_hingeJoint.autoConfigureConnectedAnchor = this.m_originalHingeJointValues.autoConfigureConnectedAnchor;
		this.m_hingeJoint.connectedBody = this.m_originalHingeJointValues.connectedBody;
		this.m_hingeJoint.anchor = this.m_originalHingeJointValues.anchor;
		this.m_hingeJoint.axis = this.m_originalHingeJointValues.axis;
		this.m_hingeJoint.connectedAnchor = this.m_originalHingeJointValues.connectedAnchor;
		this.m_hingeJoint.motor = this.m_originalHingeJointValues.motor;
		this.m_hingeJoint.useMotor = this.m_originalHingeJointValues.useMotor;
		this.m_hingeJoint.spring = this.m_originalHingeJointValues.spring;
		this.m_hingeJoint.useSpring = this.m_originalHingeJointValues.useSpring;
		this.m_hingeJoint.limits = this.m_originalHingeJointValues.limits;
		this.m_hingeJoint.useLimits = this.m_originalHingeJointValues.useLimits;
		this.m_hingeJoint.breakForce = this.m_originalHingeJointValues.breakForce;
		this.m_hingeJoint.breakTorque = this.m_originalHingeJointValues.breakTorque;
		this.m_hingeJoint.enableCollision = this.m_originalHingeJointValues.enableCollision;
		this.m_hingeJoint.enablePreprocessing = this.m_originalHingeJointValues.enablePreprocessing;
	}

	private void ResetRigidbody()
	{
		base.rigidbody.Sleep();
		base.rigidbody.isKinematic = this.m_isKinematic;
		if (!this.m_isKinematic)
		{
			base.rigidbody.WakeUp();
		}
	}

	[HideInInspector]
	[SerializeField]
	private bool m_isKinematic;
}
