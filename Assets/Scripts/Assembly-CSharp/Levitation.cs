using UnityEngine;

public class Levitation : WPFMonoBehaviour
{
	private void Awake()
	{
		this.tf = base.transform;
		this.original = this.tf.localPosition;
		this.max = 6.28318548f;
	}

	private void Update()
	{
		this.t += Time.unscaledDeltaTime * this.speed;
		this.t %= this.max;
		this.tf.localPosition = this.original + new Vector3(0f, Mathf.Sin(this.t) * this.magnitude);
	}

	[SerializeField]
	private float magnitude;

	[SerializeField]
	private float speed = 1f;

	private Vector3 original;

	private Transform tf;

	private float t;

	private float max;
}
