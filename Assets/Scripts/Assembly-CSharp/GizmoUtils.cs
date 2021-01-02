using UnityEngine;

public class GizmoUtils : MonoBehaviour
{
	public static void DrawArrow(Vector3 pos, Vector3 direction)
	{
		if (direction.magnitude != 0f)
		{
			float d = 0.35f;
			float num = 30f;
			Vector3 a = Quaternion.AngleAxis(num + 180f, Vector3.forward) * direction;
			Vector3 a2 = Quaternion.AngleAxis(-num - 180f, Vector3.forward) * direction;
			Gizmos.DrawRay(pos, direction);
			Gizmos.DrawRay(pos + direction, a * d);
			Gizmos.DrawRay(pos + direction, a2 * d);
		}
	}
}
