using UnityEngine;

public class BalloonBalancer : MonoBehaviour
{
	private void Update()
	{
		if (this.m_joint)
		{
			this.m_joint.connectedAnchor = base.transform.position;
		}
	}

	public void AddBalloon()
	{
		this.m_balloonCount++;
		if (!this.m_joint)
		{
			ConfigurableJoint configurableJoint = base.gameObject.AddComponent<ConfigurableJoint>();
			configurableJoint.configuredInWorldSpace = false;
			configurableJoint.autoConfigureConnectedAnchor = false;
			configurableJoint.anchor = Vector3.zero;
			configurableJoint.axis = Vector3.forward;
			configurableJoint.angularXMotion = ConfigurableJointMotion.Limited;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
			SoftJointLimit lowAngularXLimit = configurableJoint.lowAngularXLimit;
			lowAngularXLimit.limit = -1f;
			configurableJoint.lowAngularXLimit = lowAngularXLimit;
			SoftJointLimitSpring angularXLimitSpring = configurableJoint.angularXLimitSpring;
			angularXLimitSpring.spring = 100f;
			configurableJoint.angularXLimitSpring = angularXLimitSpring;
			configurableJoint.enablePreprocessing = false;
			this.m_joint = configurableJoint;
		}
	}

	public void RemoveBalloon()
	{
		this.m_balloonCount--;
		if (this.m_joint && this.m_balloonCount == 0)
		{
			UnityEngine.Object.Destroy(this.m_joint);
			this.m_joint = null;
		}
	}

	public void Configure(float powerFactor)
	{
		if (this.m_joint)
		{
			SoftJointLimitSpring angularXLimitSpring = this.m_joint.angularXLimitSpring;
			angularXLimitSpring.spring = (float)this.m_balloonCount * 20f * powerFactor;
			this.m_joint.angularXLimitSpring = angularXLimitSpring;
		}
	}

	private int m_balloonCount;

	[SerializeField]
	private ConfigurableJoint m_joint;
}
