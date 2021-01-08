using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyRotationConstraints : MonoBehaviour
{
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>();
		this.startRotation = base.transform.localRotation;
	}

	private void LateUpdate()
	{
		byte b = (byte)this.rb.constraints;
		Quaternion localRotation = new Quaternion(((b & 16) == 0) ? base.transform.localRotation.x : this.startRotation.x, ((b & 32) == 0) ? base.transform.localRotation.y : this.startRotation.y, ((b & 64) == 0) ? base.transform.localRotation.z : this.startRotation.z, base.transform.localRotation.w);
		base.transform.localRotation = localRotation;
	}

	private Rigidbody rb;

	private Quaternion startRotation;
}
