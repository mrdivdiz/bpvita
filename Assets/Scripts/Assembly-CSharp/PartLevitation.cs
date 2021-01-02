using System;
using UnityEngine;

public class PartLevitation : WPFMonoBehaviour
{
	private void Awake()
	{
		this.part = base.GetComponent<BasePart>();
	}

	private void FixedUpdate()
	{
		if (base.rigidbody != null)
		{
			float d = (!(this.part.enclosedInto == null)) ? this.enclosedForce : this.force;
			base.rigidbody.AddForce(Vector3.up * d, ForceMode.Force);
		}
	}

	[SerializeField]
	private float force;

	[SerializeField]
	private float enclosedForce;

	private BasePart part;
}
