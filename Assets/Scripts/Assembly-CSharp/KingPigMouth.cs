using UnityEngine;

public class KingPigMouth : WPFMonoBehaviour
{
	private void Awake()
	{
		this.m_collider = base.GetComponent<Collider>();
		if (Singleton<GameManager>.Instance.IsInGame() && this.m_collider != null)
		{
			this.m_collider.enabled = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		DessertFood component = other.gameObject.GetComponent<DessertFood>();
		if (component != null)
		{
			component.OnMouthTriggerEnter(this.m_collider);
		}
	}

	private Collider m_collider;
}
