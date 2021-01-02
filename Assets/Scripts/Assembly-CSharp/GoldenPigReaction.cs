using UnityEngine;

[RequireComponent(typeof(LevelRigidbody))]
public class GoldenPigReaction : WPFMonoBehaviour
{
	private void Start()
	{
		this.levelRigidbody = base.GetComponent<LevelRigidbody>();
		this.m_rigidbody = base.rigidbody;
	}

	private void OnCollisionEnter(Collision c)
	{
		BasePart component = c.collider.GetComponent<BasePart>();
		if (component && component.m_partType == BasePart.PartType.GoldenPig)
		{
			if (this.levelRigidbody.breakEffect != null)
			{
				this.levelRigidbody.breakEffect.transform.parent = null;
				this.levelRigidbody.breakEffect.Play();
			}
			this.m_rigidbody.isKinematic = true;
			base.transform.position = -Vector3.up * 1000f;
		}
	}

	private Rigidbody m_rigidbody;

	private LevelRigidbody levelRigidbody;
}
