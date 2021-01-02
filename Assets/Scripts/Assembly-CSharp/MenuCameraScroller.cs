using UnityEngine;

public class MenuCameraScroller : MonoBehaviour
{
	private void Update()
	{
		base.transform.position = new Vector3(Mathf.PingPong(Time.time, 14f), base.transform.position.y, base.transform.position.z);
	}
}
