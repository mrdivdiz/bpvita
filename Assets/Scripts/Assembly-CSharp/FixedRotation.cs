using UnityEngine;

public class FixedRotation : MonoBehaviour
{
	private void LateUpdate()
	{
		base.transform.rotation = Quaternion.identity;
	}
}
