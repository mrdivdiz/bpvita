using UnityEngine;

public class ListenerPosition : MonoBehaviour
{
	private void Start()
	{
		this.cachedTransform = base.transform;
	}

	private void Update()
	{
		this.cachedTransform.localPosition = new Vector3(0f, 0f, this.cachedTransform.parent.transform.InverseTransformPoint(Vector3.zero).z + -1f);
	}

	private const float FixedPositionZ = -1f;

	private Transform cachedTransform;
}
