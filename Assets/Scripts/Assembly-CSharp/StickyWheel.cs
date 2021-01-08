using System.Collections.Generic;
using UnityEngine;

public class StickyWheel : BasePart
{
	public bool HasContact
	{
		get
		{
			return this.m_hasContact;
		}
	}

	public override bool CanBeEnabled()
	{
		return this.m_maximumSpeed > 0f;
	}

	public override bool HasOnOffToggle()
	{
		return true;
	}

	public override bool IsEnabled()
	{
		return this.m_enabled;
	}

	private void Start()
	{
		this.m_wheelPivot = base.transform.Find("WheelPivot");
		this.m_fakeWheelPivot = base.transform.Find("FakeWheelPivot");
		this.m_radius = base.GetComponent<SphereCollider>().radius;
		this.m_circumference = 6.28318548f * this.m_radius;
		if (base.transform.Find("SupportCollider"))
		{
			this.m_supportCollider = base.transform.Find("SupportCollider").GetComponent<Collider>();
		}
		this.m_nonCollideLayerMask = 1 << LayerMask.NameToLayer("NonCollidingPart");
		this.m_nonCollideLayerMask |= 1 << LayerMask.NameToLayer("Light");
		this.m_nonCollideLayerMask |= 1 << LayerMask.NameToLayer("IcePart");
		BasePart.m_groundLayer = LayerMask.NameToLayer("Ground");
		this.m_contraptionLayer = LayerMask.NameToLayer("Contraption");
		this.CheckIsConnected();
	}

	private void CheckIsConnected()
	{
		List<BasePart> parts = base.contraption.Parts;
		this.m_connected = false;
		for (int i = 0; i < parts.Count; i++)
		{
			BasePart basePart = parts[i];
			if (!this.Equals(basePart) && base.contraption.IsConnectedTo(this, basePart))
			{
				this.m_connected = true;
				return;
			}
		}
	}

	private void SpawnSound()
	{
		this.loopingWheelSound = Singleton<AudioManager>.Instance.SpawnCombinedLoopingEffect(WPFMonoBehaviour.gameData.commonAudioCollection.stickyWheelLoop, base.transform).GetComponent<AudioSource>();
		this.loopingWheelSound.volume = 0f;
	}

	public override void InitializeEngine()
	{
		float enginePowerFactor = base.contraption.GetEnginePowerFactor(this);
		this.m_maximumForce = this.m_force * enginePowerFactor;
		this.m_maximumSpeed = 15f * enginePowerFactor;
	}

	private void ReinitializeEngine()
	{
		float enginePowerFactor = base.contraption.GetEnginePowerFactor(this);
		this.m_maximumForce = this.m_force * enginePowerFactor;
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
			this.m_wheelPivot.transform.localRotation = Quaternion.AngleAxis(-z + this.m_angle, Vector3.forward);
		}
		if (this.m_fakeWheelPivot)
		{
			float angle = -z + Mathf.Sin(2f * this.m_angle * 0.0174532924f) * 8f;
			this.m_fakeWheelPivot.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
		if (!this.m_spiderReported && Singleton<SocialGameManager>.IsInstantiated() && base.transform.rotation.eulerAngles.z > 100f && base.transform.rotation.eulerAngles.z < 260f && this.m_hasContact)
		{
			this.m_spiderTimer += Time.deltaTime;
			if (this.m_spiderTimer > 3f)
			{
				Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.SPIDER_PIG", 100.0);
				this.m_spiderReported = true;
			}
		}
		else
		{
			this.m_spiderTimer = 0f;
		}
		if (this.m_connected)
		{
			this.CheckIsConnected();
		}
		this.UpdateSoundEffect();
	}

	protected override void UpdateSoundEffect()
	{
		float num = 1f;
		if (Mathf.Abs(this.m_spinSpeed) > num && this.m_grounded)
		{
			if (!this.loopingWheelSound)
			{
				this.SpawnSound();
			}
			float num2 = 1f;
			float num3 = 0.1f;
			float num4 = this.SpeedInDirection(this.m_lastForceDirection);
			float num5 = (num2 - num3) / this.m_maximumSpeed * num4;
			num5 = Mathf.Clamp(num5, num3, num2);
			this.loopingWheelSound.pitch = num5;
			if (this.m_hasContact)
			{
				this.loopingWheelSound.volume = 0.15f * (Mathf.Abs(this.m_spinSpeed) / num - 1f);
			}
			else
			{
				this.loopingWheelSound.volume = 0f;
			}
		}
		else if (this.loopingWheelSound)
		{
			this.loopingWheelSound.volume = 0f;
		}
	}

	private bool CanCollide(int otherLayer)
	{
		return (this.m_nonCollideLayerMask & 1 << otherLayer) == 0;
	}

	private void FixedUpdate()
	{
		if (!base.contraption || !base.contraption.IsRunning)
		{
			return;
		}
		this.ReinitializeEngine();
		if (this.m_enabled)
		{
			this.m_thrustTimer += Time.deltaTime * 1f;
			this.m_thrustTimer = Mathf.Min(this.m_thrustTimer, 1f);
			this.m_thrust = Mathf.Pow(this.m_thrustTimer, 0.4f);
			if (base.contraption.ConnectedToGearbox(this) && base.contraption.GetGearbox(this).IsEnabled())
			{
				this.m_thrust = -this.m_thrust;
			}
		}
		else
		{
			this.m_thrustTimer = 0f;
			this.m_thrust = 0f;
		}
		this.m_lastPosition = this.m_wheelPivot.transform.position;
		RaycastHit raycastHit;
		this.hasHit = Physics.Raycast(this.m_lastPosition, this.m_lastContactDirection, out raycastHit, this.m_radius + 0.1f, ~this.m_nonCollideLayerMask);
		if (this.hasHit && raycastHit.collider != this.m_supportCollider && this.CanCollide(raycastHit.collider.gameObject.layer))
		{
			int layer = raycastHit.collider.gameObject.layer;
			Vector3 vector = Vector3.Cross(raycastHit.normal, Vector3.forward);
			float num = this.SpeedInDirection(vector);
			this.m_lastForceDirection = vector;
			this.m_spinSpeed = 0f;
			this.m_hasContact = true;
			this.colliderRigidbody = ((layer != BasePart.m_groundLayer) ? raycastHit.collider.gameObject.GetComponent<Rigidbody>() : null);
			if (this.m_enabled && this.m_maximumSpeed > 0f && num < this.m_maximumSpeed && num > -this.m_maximumSpeed)
			{
				float num2 = 1f - Mathf.Abs(num) / this.m_maximumSpeed;
				num2 = Mathf.Pow(num2, 0.5f);
				float d = this.m_thrust * this.m_maximumForce * num2;
				base.rigidbody.AddForceAtPosition(vector * d, raycastHit.point, ForceMode.Force);
				if (!this.colliderRigidbody && layer != BasePart.m_groundLayer && raycastHit.collider.transform.parent != null)
				{
					this.colliderRigidbody = raycastHit.collider.transform.parent.GetComponent<Rigidbody>();
				}
				if (this.colliderRigidbody != null && !this.colliderRigidbody.isKinematic)
				{
					this.colliderRigidbody.AddForceAtPosition(-vector * d, raycastHit.point, ForceMode.Force);
				}
			}
			vector = Vector3.Cross(raycastHit.normal, Vector3.forward * -1f);
			base.rigidbody.AddForceAtPosition(vector * this.m_drag * num, (this.m_lastPosition + raycastHit.point) * 0.5f, ForceMode.Force);
			this.m_grounded = true;
		}
		else
		{
			this.m_hasContact = false;
			this.colliderRigidbody = null;
			if (this.m_enabled)
			{
				this.m_spinSpeed = this.m_maximumSpeed;
				if (base.contraption.ConnectedToGearbox(this) && base.contraption.GetGearbox(this).IsEnabled())
				{
					this.m_spinSpeed = -this.m_maximumSpeed;
				}
			}
			else
			{
				this.m_spinSpeed *= 0.98f;
			}
		}
		if (this.hasHit && raycastHit.collider != this.m_supportCollider && raycastHit.collider.gameObject.layer != this.m_contraptionLayer && this.CanCollide(raycastHit.collider.gameObject.layer) && this.m_connected)
		{
			this.m_fallOffForce = this.m_lastContactDirection * this.m_stickiness;
			if (this.colliderRigidbody == null)
			{
				base.rigidbody.AddForceAtPosition(this.m_fallOffForce, (this.m_lastPosition + raycastHit.point) * 0.5f, ForceMode.Force);
			}
		}
		else
		{
			this.m_fallOffForce = Vector3.zero;
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

	protected override void OnTouch()
	{
		this.SetEnabled(!this.m_enabled);
	}

	public override void SetEnabled(bool enabled)
	{
		this.m_enabled = enabled;
		base.contraption.UpdateEngineStates(base.ConnectedComponent);
	}

	public float m_force;

	public bool m_enabled;

	public float m_maximumSpeed;

	public float m_stickiness = 200f;

	private float m_maximumForce;

	private Vector3 m_lastPosition = Vector3.zero;

	private Vector3 m_lastContactDirection = Vector3.zero;

	private float m_radius;

	private float m_circumference;

	private Transform m_wheelPivot;

	private Transform m_fakeWheelPivot;

	private float m_spinSpeed;

	private Vector3 m_lastForceDirection;

	private float m_angle;

	private Collider m_supportCollider;

	private bool m_hasContact = true;

	private float m_thrust;

	private float m_thrustTimer;

	private Rigidbody colliderRigidbody;

	private AudioSource loopingWheelSound;

	private bool m_grounded;

	private Vector3 m_fallOffForce = Vector3.zero;

	private int m_nonCollideLayerMask;

	private int m_contraptionLayer;

	public float m_drag = 0.1f;

	private float m_spiderTimer;

	private bool m_spiderReported;

	public bool hasHit;

	private bool m_connected;
}
