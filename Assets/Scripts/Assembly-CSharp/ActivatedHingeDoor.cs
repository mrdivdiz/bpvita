using UnityEngine;

public class ActivatedHingeDoor : MonoBehaviour
{
	private void OnDataLoaded()
	{
		this.m_door = base.transform.Find("Door");
		this.m_doorRigidbody = this.m_door.GetComponent<Rigidbody>();
		this.m_startingRotation = this.m_door.localRotation;
		this.m_joint = this.m_door.GetComponent<HingeJoint>();
		JointLimits limits = default(JointLimits);
		if (this.m_activatedAngle > 0f)
		{
			limits.max = this.m_activatedAngle;
			limits.min = 0f;
		}
		if (this.m_activatedAngle < 0f)
		{
			limits.max = 0f;
			limits.min = this.m_activatedAngle;
		}
		if (this.m_joint)
		{
			this.m_joint.limits = limits;
		}
		this.m_activatedRotation = Quaternion.AngleAxis(this.m_activatedAngle, Vector3.forward);
		EventManager.Connect(new EventManager.OnEvent<PressureButtonPressed>(this.OnPressurePlatePress));
		EventManager.Connect(new EventManager.OnEvent<PressureButtonReleased>(this.OnPressurePlateReleased));
		if (this.m_inverted)
		{
			this.m_rotationState = ActivatedHingeDoor.RotationState.Opening;
		}
        this.m_rotationState = ActivatedHingeDoor.RotationState.Kinematic;

    }

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<PressureButtonPressed>(this.OnPressurePlatePress));
		EventManager.Disconnect(new EventManager.OnEvent<PressureButtonReleased>(this.OnPressurePlateReleased));
	}

	private void OnPressurePlatePress(PressureButtonPressed pressed)
	{
		if (this.m_pressureID != pressed.id)
		{
			return;
		}
		if (this.m_inverted)
		{
			this.m_rotationState = ActivatedHingeDoor.RotationState.Closing;
		}
		else
		{
			this.m_rotationState = ActivatedHingeDoor.RotationState.Opening;
		}
	}

	private void OnPressurePlateReleased(PressureButtonReleased released)
	{
		if (this.m_pressureID != released.id)
		{
			return;
		}
		if (this.m_inverted)
		{
			this.m_rotationState = ActivatedHingeDoor.RotationState.Opening;
		}
		else
		{
			this.m_rotationState = ActivatedHingeDoor.RotationState.Closing;
		}
	}

	private void FixedUpdate()
	{
		float num = Mathf.Abs(this.m_activatedAngle) - Mathf.Abs(this.m_joint.angle);
		switch (this.m_rotationState)
		{
		case ActivatedHingeDoor.RotationState.Kinematic:
			if (!this.m_doorRigidbody.isKinematic)
			{
				this.m_doorRigidbody.isKinematic = true;
			}
			break;
		case ActivatedHingeDoor.RotationState.Opening:
			this.m_doorRigidbody.isKinematic = false;
			if (num >= 1f)
			{
				this.m_doorRigidbody.AddTorque(this.m_activatedAngle * Vector3.forward * this.m_torque);
			}
			else
			{
				this.m_rotationState = ActivatedHingeDoor.RotationState.Kinematic;
				this.m_door.localRotation = this.m_activatedRotation;
			}
			break;
		case ActivatedHingeDoor.RotationState.Closing:
			this.m_doorRigidbody.isKinematic = false;
			if (Mathf.Abs(this.m_activatedAngle) - num > 1f)
			{
				this.m_doorRigidbody.AddTorque(-this.m_activatedAngle * Vector3.forward * this.m_torque);
			}
			else
			{
				this.m_rotationState = ActivatedHingeDoor.RotationState.Kinematic;
				this.m_door.localRotation = this.m_startingRotation;
			}
			break;
		}
	}

	[SerializeField]
	private int m_pressureID;

	[SerializeField]
	private float m_activatedAngle;

	[SerializeField]
	private bool m_inverted;

	[SerializeField]
	private float m_torque = 100f;

	private Transform m_door;

	private Rigidbody m_doorRigidbody;

	private Quaternion m_startingRotation;

	private Quaternion m_activatedRotation;

	private HingeJoint m_joint;

	private RotationState m_rotationState = ActivatedHingeDoor.RotationState.Closing;

	private enum RotationState
	{
		Kinematic,
		Opening,
		Closing
	}
}
