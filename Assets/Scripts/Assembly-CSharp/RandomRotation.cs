using UnityEngine;

public class RandomRotation : MonoBehaviour
{
	private void Awake()
	{
		this.rotationVelocity = UnityEngine.Random.Range(this.minRotation, this.maxRotation);
		this.currentRotation = base.transform.rotation.eulerAngles;
	}

	private void Update()
	{
		this.currentRotation.z = this.currentRotation.z + this.rotationVelocity * Time.unscaledDeltaTime;
		base.transform.rotation = Quaternion.Euler(this.currentRotation);
	}

	[SerializeField]
	private float maxRotation;

	[SerializeField]
	private float minRotation;

	private float rotationVelocity;

	private Vector3 currentRotation;
}
