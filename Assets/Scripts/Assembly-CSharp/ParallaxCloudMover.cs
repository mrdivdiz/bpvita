using UnityEngine;

public class ParallaxCloudMover : CloudMover
{
	private void Update()
	{
		Vector3 localPosition = base.transform.localPosition + Vector3.right * this.m_velocity * Time.deltaTime;
		if (Mathf.Sign(this.m_velocity) * localPosition.x > base.transform.parent.position.x + this.m_limits)
		{
			localPosition.x = -this.m_limits * Mathf.Sign(this.m_velocity);
		}
		if (Mathf.Sign(this.m_velocity) * localPosition.x < base.transform.parent.position.x - this.m_limits)
		{
			localPosition.x = this.m_limits * Mathf.Sign(this.m_velocity);
		}
		base.transform.localPosition = localPosition;
	}
}
