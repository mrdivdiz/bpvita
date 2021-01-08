using System;
using UnityEngine;

public class CartWheel : BasePart
{
	private void Start()
	{
		this.m_wheelPivot = base.transform.Find("WheelPivot");
		this.m_fakeWheelPivot = base.transform.Find("FakeWheelPivot");
		if (this.m_wheelPivot)
		{
			this.m_axle = this.m_wheelPivot;
			this.m_radius = this.m_wheelPivot.GetComponent<SphereCollider>().radius;
			this.m_circumference = 6.28318548f * this.m_radius;
		}
		else
		{
			this.m_axle = this.m_fakeWheelPivot;
			this.m_radius = this.m_fakeWheelPivot.GetComponent<SphereCollider>().radius;
			this.m_circumference = 6.28318548f * this.m_radius;
		}
		if (base.transform.Find("SupportCollider"))
		{
			this.m_supportCollider = base.transform.Find("SupportCollider").GetComponent<Collider>();
		}
	}

	private void SpawnSound()
	{
		BasePart.PartType partType = this.m_partType;
		if (partType != BasePart.PartType.CartWheel)
		{
			if (partType != BasePart.PartType.SmallWheel)
			{
				if (partType != BasePart.PartType.NormalWheel)
				{
					if (partType == BasePart.PartType.ObsoleteWheel)
					{
						//this.loopingWheelSound = Singleton<AudioManager>.Instance.SpawnCombinedLoopingEffect(WPFMonoBehaviour.gameData.commonAudioCollection.woodenWheelLoop, base.transform).GetComponent<AudioSource>();
					}
				}
				else
				{
					//this.loopingWheelSound = Singleton<AudioManager>.Instance.SpawnCombinedLoopingEffect(WPFMonoBehaviour.gameData.commonAudioCollection.normalWheelLoop, base.transform).GetComponent<AudioSource>();
				}
			}
			else
			{
				//this.loopingWheelSound = Singleton<AudioManager>.Instance.SpawnCombinedLoopingEffect(WPFMonoBehaviour.gameData.commonAudioCollection.smallWheelLoop, base.transform).GetComponent<AudioSource>();
			}
		}
		else
		{
			//this.loopingWheelSound = Singleton<AudioManager>.Instance.SpawnCombinedLoopingEffect(WPFMonoBehaviour.gameData.commonAudioCollection.woodenWheelLoop, base.transform).GetComponent<AudioSource>();
		}
		//this.loopingWheelSound.volume = 0f;
	}

	public override void OnCollisionStay(Collision collisionInfo)
	{
		base.OnCollisionStay(collisionInfo);
		for (int i = 0; i < collisionInfo.contacts.Length; i++)
		{
			if (collisionInfo.contacts[i].otherCollider != this.m_supportCollider)
			{
				this.m_lastContactDirection = (collisionInfo.contacts[i].point - this.m_lastPosition).normalized;
				break;
			}
		}
	}

	private void Update()
	{
		if (!base.contraption || !base.contraption.IsRunning)
		{
			return;
		}
		if (this.m_spinSpeed == 0f)
		{
			this.m_spinSpeed = this.SpeedInDirection(this.m_lastForceDirection);
		}
		float z = base.transform.rotation.eulerAngles.z;
		this.m_angle += -360f * this.m_spinSpeed / this.m_circumference * Time.deltaTime;
		if (this.m_wheelPivot)
		{
			this.m_wheelPivot.localRotation = Quaternion.AngleAxis(-z + this.m_angle, Vector3.forward);
		}
		if (this.m_fakeWheelPivot)
		{
			float angle = -z + Mathf.Sin(2f * this.m_angle * 0.0174532924f) * 8f;
			this.m_fakeWheelPivot.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
		//this.UpdateSoundEffect();
	}

	protected override void UpdateSoundEffect()
	{/*
		float num = 1f;
		if (Mathf.Abs(this.m_spinSpeed) > num && this.m_grounded)
		{
			if (!this.loopingWheelSound)
			{
				this.SpawnSound();
			}
			this.loopingWheelSound.volume = 0.2f * (Mathf.Abs(this.m_spinSpeed) / num - 1f);
		}
		else if (this.loopingWheelSound)
		{
			this.loopingWheelSound.volume = 0f;
		}*/
	}

	private void FixedUpdate()
	{
		if (!base.contraption || !base.contraption.IsRunning)
		{
			return;
		}
		this.m_lastPosition = this.m_axle.position;
		RaycastHit raycastHit;
		if (Physics.Raycast(this.m_axle.position, this.m_lastContactDirection, out raycastHit, this.m_radius + 0.1f) && raycastHit.collider != this.m_supportCollider)
		{
			this.colliderRigidbody = ((raycastHit.collider.gameObject.layer != BasePart.m_groundLayer) ? raycastHit.rigidbody : null);
			Vector3 lastForceDirection = Vector3.Cross(raycastHit.normal, Vector3.forward);
			this.m_lastForceDirection = lastForceDirection;
			this.m_spinSpeed = 0f;
			this.m_grounded = true;
		}
		else
		{
			this.m_spinSpeed *= 0.98f;
			this.colliderRigidbody = null;
			this.m_grounded = false;
		}
	}

	private float SpeedInDirection(Vector3 direction)
	{
		Vector3 vector = base.rigidbody.velocity;
		if (this.colliderRigidbody)
		{
			vector -= this.colliderRigidbody.velocity;
		}
		return Vector3.Dot(vector, direction);
	}

	private Vector3 m_lastPosition = Vector3.zero;

	private Vector3 m_lastContactDirection = Vector3.zero;

	private float m_radius;

	private float m_circumference;

	private Transform m_wheelPivot;

	private Transform m_fakeWheelPivot;

	private Transform m_axle;

	private float m_spinSpeed;

	private Vector3 m_lastForceDirection;

	private float m_angle;

	private AudioSource loopingWheelSound;

	private Collider m_supportCollider;

	private Rigidbody colliderRigidbody;

	private bool m_grounded;
}
