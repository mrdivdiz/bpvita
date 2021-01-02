using UnityEngine;

public class JointBreakEvent : MonoBehaviour
{
	private void OnJointBreak(float breakForce)
	{
		if (this.onJointBreak != null)
		{
			this.onJointBreak(this);
		}
	}

	public JointBreak onJointBreak;

	public delegate void JointBreak(JointBreakEvent sender);
}
