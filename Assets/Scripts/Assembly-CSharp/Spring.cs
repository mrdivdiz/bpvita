using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : BasePart
{
	public override void Awake()
	{
		base.Awake();
		this.m_visualization = base.transform.Find("SpringVisualization").gameObject;
		this.m_jointBroken = false;
	}

	private void Update()
	{
		if (base.rigidbody && this.m_connectedBody)
		{
			Vector3 vector = base.transform.TransformPoint(this.m_localConnectionPoint);
			Vector3 vector2 = this.m_connectedBody.transform.TransformPoint(this.m_remoteConnectionPoint);
			Vector3 localScale = this.m_visualization.transform.localScale;
			localScale.y = Vector3.Distance(vector, vector2);
			this.m_visualization.transform.localScale = localScale;
			this.m_visualization.transform.position = 0.5f * (vector + vector2);
			Vector3 vector3 = vector2 - vector;
			float z = Mathf.Atan2(vector3.y, vector3.x) * 57.29578f + 90f;
			this.m_visualization.transform.rotation = Quaternion.Euler(0f, 0f, z);
		}
	}

	protected new IEnumerator OnJointBreak(float breakForce)
	{
		base.OnJointBreak(breakForce);
		yield return null;
		if (this.joint == null)
		{
			this.CreateSpringBody(BasePart.Direction.Down);
		}
		yield break;
	}

	public override void EnsureRigidbody()
	{
		base.EnsureRigidbody();
		base.rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
	}

	private void FixedUpdate()
	{
		if (this.m_jointBroken || base.transform == null || this.m_connectedBody == null)
		{
			return;
		}
		Vector3 a = base.transform.TransformPoint(this.m_localConnectionPoint);
		Vector3 b = this.m_connectedBody.transform.TransformPoint(this.m_remoteConnectionPoint);
		if (Vector3.Distance(a, b) > 3f && !base.contraption.HasSuperGlue)
		{
			List<Joint> list = base.contraption.FindPartFixedJoints(this);
			for (int i = 0; i < list.Count; i++)
			{
				UnityEngine.Object.Destroy(list[i]);
			}
			base.HandleJointBreak(float.MaxValue, true);
			this.m_jointBroken = true;
		}
	}

	public override Joint CustomConnectToPart(BasePart part)
	{
		ConfigurableJoint configurableJoint = base.gameObject.AddComponent<ConfigurableJoint>();
		configurableJoint.connectedBody = part.rigidbody;
		configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
		configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
		configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
		configurableJoint.xMotion = ConfigurableJointMotion.Locked;
		configurableJoint.yMotion = ConfigurableJointMotion.Limited;
		configurableJoint.zMotion = ConfigurableJointMotion.Locked;
		configurableJoint.enablePreprocessing = false;
		configurableJoint.configuredInWorldSpace = true;
		configurableJoint.breakForce = 250f;
		SoftJointLimitSpring linearLimitSpring = configurableJoint.linearLimitSpring;
		linearLimitSpring.spring = 250f;
		linearLimitSpring.damper = 20f;
		configurableJoint.linearLimitSpring = linearLimitSpring;
		SoftJointLimit linearLimit = configurableJoint.linearLimit;
		linearLimit.limit = 0.1f;
		linearLimit.bounciness = 1f;
		configurableJoint.linearLimit = linearLimit;
		this.m_connectedBody = part.rigidbody;
		this.m_localConnectionPoint = new Vector3(0f, 0.5f, 0f);
		this.m_remoteConnectionPoint = part.transform.InverseTransformPoint(base.transform.position - 0.5f * base.transform.up);
		this.joint = configurableJoint;
		return configurableJoint;
	}

	public void CreateSpringBody(BasePart.Direction direction)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_endPointPrefab, base.transform.position, base.transform.rotation);
		ConfigurableJoint configurableJoint = base.gameObject.AddComponent<ConfigurableJoint>();
		configurableJoint.connectedBody = gameObject.GetComponent<Rigidbody>();
		configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
		configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
		configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
		configurableJoint.xMotion = ConfigurableJointMotion.Locked;
		configurableJoint.yMotion = ConfigurableJointMotion.Limited;
		configurableJoint.zMotion = ConfigurableJointMotion.Locked;
		configurableJoint.enablePreprocessing = false;
		configurableJoint.configuredInWorldSpace = true;
		SoftJointLimitSpring linearLimitSpring = configurableJoint.linearLimitSpring;
		linearLimitSpring.spring = 250f;
		linearLimitSpring.damper = 20f;
		configurableJoint.linearLimitSpring = linearLimitSpring;
		SoftJointLimit linearLimit = configurableJoint.linearLimit;
		linearLimit.limit = 0.1f;
		linearLimit.bounciness = 1f;
		configurableJoint.linearLimit = linearLimit;
		gameObject.transform.parent = base.transform;
		if (this.m_connectedBody == null)
		{
			this.m_connectedBody = gameObject.GetComponent<Rigidbody>();
			this.m_localConnectionPoint = new Vector3(0f, 0.5f, 0f);
			this.m_remoteConnectionPoint = gameObject.transform.InverseTransformPoint(base.transform.position - 0.5f * base.transform.up);
		}
		else
		{
			Vector3 position = this.m_connectedBody.position + (base.transform.position - this.m_connectedBody.position).normalized * 0.5f;
			this.m_connectedBody = gameObject.GetComponent<Rigidbody>();
			this.m_connectedBody.position = position;
			this.m_localConnectionPoint = new Vector3(0f, 0.5f, 0f);
			this.m_remoteConnectionPoint = gameObject.transform.InverseTransformPoint(base.transform.position - 0.5f * base.transform.up);
		}
	}

	private const float SPRING_LIMIT_SPRING = 250f;

	private const float SPRING_DAMPING = 20f;

	private const float SPRING_LIMIT = 0.1f;

	private const float SPRING_BOUNCINESS = 1f;

	private const float SPRING_BREAK_FORCE = 250f;

	public GameObject m_endPointPrefab;

	private Rigidbody m_connectedBody;

	private GameObject m_visualization;

	private Vector3 m_localConnectionPoint;

	private Vector3 m_remoteConnectionPoint;

	private bool m_jointBroken;

	private Joint joint;
}
