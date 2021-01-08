using System;
using UnityEngine;

public class Hook : MonoBehaviour
{
	public bool activeInHierarchy
	{
		get
		{
			return this.activeInHierarchy;
		}
	}

	public void Awake()
	{
		this.m_rigidbody = base.GetComponent<Rigidbody>();
		this.attachType = Hook.AttachType.None;
	}

	private void FixedUpdate()
	{
		float num = this.m_rigidbody.velocity.magnitude * Time.fixedDeltaTime;
		if (num > 0.1f)
		{
			Ray ray = new Ray(base.transform.position, base.transform.right);
			LayerMask layerMask = 1 << LayerMask.NameToLayer("Light");
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit, num, ~layerMask.value) && (raycastHit.collider.tag == "Dynamic" || raycastHit.collider.tag == "Contraption"))
			{
				base.transform.parent = null;
				this.attachType = Hook.AttachType.Dynamic;
				this.m_rigidbody.velocity = Vector3.zero;
				this.m_rigidbody.angularVelocity = Vector3.zero;
				base.transform.position = raycastHit.point;
				if (raycastHit.rigidbody != null)
				{
					this.AttachToRigidbody(raycastHit.rigidbody);
				}
			}
		}
	}

	private void AttachToRigidbody(Rigidbody rb)
	{
		if (this.m_dynamicJoint != null)
		{
			UnityEngine.Object.Destroy(this.m_dynamicJoint);
		}
		this.m_dynamicJoint = rb.gameObject.AddComponent<FixedJoint>();
		this.m_dynamicJoint.connectedBody = this.m_rigidbody;
		this.m_dynamicJoint.breakForce = this.GetJointConnectionStrength(this.m_dynamicAttachJointStrength);
		this.m_dynamicJoint.enablePreprocessing = false;
	}

	public float GetJointConnectionStrength(BasePart.JointConnectionStrength strength)
	{
		switch (strength)
		{
		case BasePart.JointConnectionStrength.Weak:
			return WPFMonoBehaviour.gameData.m_jointConnectionStrengthWeak;
		case BasePart.JointConnectionStrength.Normal:
			return WPFMonoBehaviour.gameData.m_jointConnectionStrengthNormal;
		case BasePart.JointConnectionStrength.High:
			return WPFMonoBehaviour.gameData.m_jointConnectionStrengthHigh;
		case BasePart.JointConnectionStrength.Extreme:
			return WPFMonoBehaviour.gameData.m_jointConnectionStrengthExtreme;
		case BasePart.JointConnectionStrength.HighlyExtreme:
			return WPFMonoBehaviour.gameData.m_jointConnectionStrengthHighlyExtreme;
		default:
			return 0f;
		}
	}

	public void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.tag == "Collectable" || coll.collider.tag == "DynamicCollectable")
		{
			return;
		}
		if (coll != null && this.attachType == Hook.AttachType.None && this.m_stickingAllowed)
		{
			base.transform.parent = null;
			if (coll.rigidbody != null)
			{
				this.AttachToRigidbody(coll.rigidbody);
				this.attachType = Hook.AttachType.Dynamic;
			}
			else
			{
				this.m_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
				this.attachType = Hook.AttachType.Static;
			}
			this.m_rigidbody.velocity = Vector3.zero;
			this.m_rigidbody.angularVelocity = Vector3.zero;
			if (coll.contacts.Length > 0)
			{
				base.transform.position = coll.contacts[0].point;
			}
		}
		if (coll.transform.tag == "Goal")
		{
			Physics.IgnoreCollision(coll.collider, base.GetComponent<Collider>());
		}
	}

	public void OnEnable()
	{
		this.attachType = Hook.AttachType.None;
		this.allowSticking(true);
		if (base.transform.parent != null)
		{
			base.transform.position = base.transform.parent.position;
		}
	}

	public Hook.AttachType GetAttachType()
	{
		return this.attachType;
	}

	public void SetActive(bool active)
	{
		base.gameObject.SetActive(active);
	}

	public void Reset()
	{
		this.m_rigidbody.constraints = (RigidbodyConstraints)56;
		if (this.m_dynamicJoint != null)
		{
			UnityEngine.Object.Destroy(this.m_dynamicJoint);
		}
		this.allowSticking(false);
		this.attachType = Hook.AttachType.None;
	}

	public void allowSticking(bool allow)
	{
		this.m_stickingAllowed = allow;
		base.GetComponent<Collider>().isTrigger = !allow;
	}

	private Vector3 m_lockedPosition;

	private Quaternion m_lockedRotation;

	private bool m_stickingAllowed = true;

	private Rigidbody m_rigidbody;

	private FixedJoint m_dynamicJoint;

	private Hook.AttachType attachType;

	[SerializeField]
	private BasePart.JointConnectionStrength m_dynamicAttachJointStrength;

	public enum AttachType
	{
		None,
		Static,
		Dynamic
	}
}
