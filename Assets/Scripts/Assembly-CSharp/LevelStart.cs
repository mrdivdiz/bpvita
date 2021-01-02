using UnityEngine;

public class LevelStart : MonoBehaviour
{
	private void OnDrawGizmos()
	{
		Gizmos.DrawIcon(base.transform.position, "Marker.tga");
	}
}
