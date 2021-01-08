using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
	private void Update()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		float num = Time.realtimeSinceStartup - this.lastRealtimeSinceStartup;
		this.lastRealtimeSinceStartup = realtimeSinceStartup;
		base.transform.Rotate(Vector3.back, num * this.speed);
	}

	public float speed = 90f;

	private float lastRealtimeSinceStartup;
}
