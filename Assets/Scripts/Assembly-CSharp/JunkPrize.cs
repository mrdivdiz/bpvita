using UnityEngine;

public class JunkPrize : MonoBehaviour
{
	private void Start()
	{
		Vector3 vector = Vector3.up;
		float num = (UnityEngine.Random.value >= 0.5f) ? -1f : 1f;
		vector = Quaternion.AngleAxis(num * UnityEngine.Random.Range(30f, 60f), Vector3.forward) * vector;
		Vector3 force = vector * 15f;
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(force, ForceMode.Impulse);
		component.AddTorque(new Vector3(0f, 0f, 5f), ForceMode.Impulse);
		UnityEngine.Object.Destroy(base.gameObject, 3f);
	}
}
