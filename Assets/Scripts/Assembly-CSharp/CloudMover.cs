using UnityEngine;

public class CloudMover : MonoBehaviour
{
	private void Update()
	{
		Vector3 position = base.transform.position + Vector3.right * this.m_velocity * Time.deltaTime;
		if (Mathf.Sign(this.m_velocity) * position.x > base.transform.parent.position.x + this.m_limits)
		{
			position.x = -this.m_limits * Mathf.Sign(this.m_velocity);
		}
		if (Mathf.Sign(this.m_velocity) * position.x < base.transform.parent.position.x - this.m_limits)
		{
			position.x = this.m_limits * Mathf.Sign(this.m_velocity);
		}
		base.transform.position = position;
	}

	[HideInInspector]
	public float m_velocity = 10f;

	[HideInInspector]
	public float m_limits = 100f;
}
