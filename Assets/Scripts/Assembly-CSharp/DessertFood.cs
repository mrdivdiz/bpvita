using UnityEngine;

public class DessertFood : MonoBehaviour
{
	private void Start()
	{
		UnityEngine.Object.Destroy(base.gameObject, 10f);
	}

	public void OnMouthTriggerEnter(Collider other)
	{
		if (this.m_DessertSelector && !this.m_DessertSelector.IsEating())
		{
			this.m_DessertSelector.EatDessert(this.m_DessertButton);
			base.gameObject.GetComponent<Collider>().enabled = false;
			UnityEngine.Object.Destroy(base.gameObject, 0.02f);
		}
	}

	public void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.tag == "Ground")
		{
			if (coll.relativeVelocity.magnitude > 3f && this.m_DessertSelector && !this.m_DessertSelector.IsEating())
			{
				this.m_DessertSelector.MissDessert(this.m_DessertButton);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	[HideInInspector]
	public Widget m_DessertButton;

	[HideInInspector]
	public DessertSelector m_DessertSelector;
}
