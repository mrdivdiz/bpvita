using UnityEngine;

public class Billboard : MonoBehaviour
{
	public void LateUpdate()
	{
		Vector3 normalized = (base.transform.position - Camera.main.transform.position).normalized;
		Vector3 rhs = base.transform.right;
		if (this.m_upFrom)
		{
			rhs = Vector3.Cross(this.m_upFrom.up, normalized);
		}
		Vector3 normalized2 = Vector3.Cross(normalized, rhs).normalized;
		base.transform.rotation = Quaternion.LookRotation(normalized, normalized2);
	}

	public Transform m_upFrom;
}
