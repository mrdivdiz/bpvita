using UnityEngine;

public class SimpleFloatingAnimation : MonoBehaviour
{
	private void Awake()
	{
		this.m_transform = base.transform;
		this.m_startingPosition = Vector3.zero;
		this.m_timer = 0f;
	}

	private void Update()
	{
		if (this.m_startingPosition == Vector3.zero)
		{
			this.m_startingPosition = this.m_transform.position;
		}
		if (base.enabled)
		{
			this.m_transform.position = this.m_startingPosition + this.m_direction * Mathf.Sin((this.m_timer - 5f) * this.m_power);
		}
		this.m_timer += Time.deltaTime;
	}

	public Vector3 m_direction;

	public float m_power;

	private Vector3 m_startingPosition;

	private float m_timer;

	private Transform m_transform;
}
