using UnityEngine;

public class BaseTransform : MonoBehaviour
{
	public void Awake()
	{
		this.position = base.transform.position;
		this.rotation = base.transform.rotation;
		this.localScale = base.transform.localScale;
	}

	public Vector3 position;

	public Quaternion rotation;

	public Vector3 localScale;
}
