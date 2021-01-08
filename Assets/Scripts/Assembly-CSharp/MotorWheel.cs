using UnityEngine;

public class MotorWheel : BasePart
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
	}

	private void SpawnLoopingWheelSound()
	{
		//this.loopingWheelSound = Singleton<AudioManager>.Instance.SpawnCombinedLoopingEffect(WPFMonoBehaviour.gameData.commonAudioCollection.motorWheelLoop, base.transform).GetComponent<AudioSource>();
		//this.loopingWheelSound.volume = 0f;
	}

	private void SpawnLoopingWheelOnIceSound()
	{
		//this.loopingWheelBrushSound = Singleton<AudioManager>.Instance.SpawnCombinedLoopingEffect(WPFMonoBehaviour.gameData.commonAudioCollection.motorWheelOnIceLoop, base.transform).GetComponent<AudioSource>();
		//this.loopingWheelBrushSound.volume = 0f;
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
		if (this.m_enabled && this.m_onIceSurface)
		{
			this.m_spinSpeed = 15f;
		}
		this.m_angle += -360f * this.m_spinSpeed / this.m_circumference * Time.deltaTime;
		if (this.m_wheelPivot)
		{
			this.m_wheelPivot.transform.localRotation = Quaternion.AngleAxis(-z + this.m_angle, Vector3.forward);
		}
		if (this.m_fakeWheelPivot)
		{
			float num = -z + Mathf.Sin(2f * this.m_angle * 0.0174532924f) * 8f;
			if (this.m_onIceSurface)
			{
				num *= 2f;
			}
			this.m_fakeWheelPivot.transform.localRotation = Quaternion.AngleAxis(num, Vector3.forward);
		}
		this.UpdateSoundEffect();
	}

	protected override void UpdateSoundEffect()
	{/*
		float num = 1f;
		if (Mathf.Abs(this.m_spinSpeed) > num && this.m_grounded)
		{
			if (this.m_onIceSurface && this.m_enabled)
			{
				this.loopingIceSurfaceSoundTime += Time.deltaTime;
				if (!this.m_playedIceSurfaceStart)
				{
					this.m_playedIceSurfaceStart = true;
					this.loopingIceSurfaceSoundTime = 0f;
					if (this.loopingWheelBrushSound)
					{
						this.loopingWheelBrushSound.volume = 0f;
					}
					if (this.wheelBrushSoundStart)
					{
						this.wheelBrushSoundStart.Stop();
						UnityEngine.Object.Destroy(this.wheelBrushSoundStart);
					}
					this.wheelBrushSoundStart = Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.motorWheelOnIceStart, base.transform);
					if (this.wheelBrushSoundStart != null)
					{
						if (!this.lastGearboxState)
						{
							this.wheelBrushSoundStart.volume = 0.4f * (1f - Mathf.Clamp01(base.rigidbody.velocity.x * 0.1f));
						}
						else
						{
							this.wheelBrushSoundStart.volume = 0.4f * (1f - Mathf.Clamp01(-base.rigidbody.velocity.x * 0.1f));
						}
						this.wheelBrushSoundStart.Play();
					}
				}
				if (this.loopingIceSurfaceSoundTime > 1.4f)
				{
					if (!this.loopingWheelBrushSound)
					{
						this.SpawnLoopingWheelOnIceSound();
					}
					if (!this.lastGearboxState)
					{
						this.loopingWheelBrushSound.volume = 0.4f * (1f - Mathf.Clamp01(base.rigidbody.velocity.x * 0.1f));
					}
					else
					{
						this.loopingWheelBrushSound.volume = 0.4f * (1f - Mathf.Clamp01(-base.rigidbody.velocity.x * 0.1f));
					}
				}
			}
			else
			{
				if (this.wheelBrushSoundStart)
				{
					this.wheelBrushSoundStart.Stop();
					UnityEngine.Object.Destroy(this.wheelBrushSoundStart);
				}
				if (this.loopingWheelBrushSound)
				{
					this.loopingWheelBrushSound.volume = 0f;
				}
			}
			if (!this.loopingWheelSound)
			{
				this.SpawnLoopingWheelSound();
			}
			this.loopingWheelSound.volume = 0.15f * (Mathf.Abs(this.m_spinSpeed) / num - 1f);
		}
		else
		{
			if (this.loopingWheelSound)
			{
				this.loopingWheelSound.volume = 0f;
			}
			if (this.loopingWheelBrushSound)
			{
				this.loopingWheelBrushSound.volume = 0f;
			}
			if (this.wheelBrushSoundStart)
			{
				this.wheelBrushSoundStart.Stop();
				UnityEngine.Object.Destroy(this.wheelBrushSoundStart);
			}
		}*/
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
			if (base.contraption.ConnectedToGearbox(this))
			{
				bool flag = base.contraption.GetGearbox(this).IsEnabled();
				if (flag != this.lastGearboxState)
				{
					this.OnGearboxStateChanged();
				}
				if (flag)
				{
					this.m_thrust = -this.m_thrust;
				}
				this.lastGearboxState = flag;
			}
		}
		else
		{
			this.m_thrustTimer = 0f;
			this.m_thrust = 0f;
		}
		this.m_lastPosition = this.m_wheelPivot.transform.position;
		RaycastHit raycastHit;
		bool flag2 = Physics.Raycast(this.m_wheelPivot.transform.position, this.m_lastContactDirection, out raycastHit, this.m_radius + 0.1f);
		this.m_onIceSurface = false;
		if (flag2 && raycastHit.collider != this.m_supportCollider)
		{
			float num = this.SpeedInDirection(base.transform.right);
			Vector3 vector = Vector3.Cross(raycastHit.normal, Vector3.forward);
			this.m_lastForceDirection = vector;
			this.m_spinSpeed = 0f;
			this.m_hasContact = true;
			this.colliderRigidbody = raycastHit.collider.gameObject.GetComponent<Rigidbody>();
			if (this.m_enabled && this.m_maximumSpeed > 0f && num < this.m_maximumSpeed && num > -this.m_maximumSpeed)
			{
				float num2 = 1f - Mathf.Abs(num) / this.m_maximumSpeed;
				num2 = Mathf.Pow(num2, 0.5f);
				float num3 = this.m_thrust * this.m_maximumForce * num2;
				if (this.m_onIceSurface = raycastHit.transform.CompareTag("IceSurface"))
				{
					num3 *= 0.25f + Mathf.Clamp(num, 0f, this.m_maximumSpeed) / this.m_maximumSpeed * 0.5f;
				}
				base.rigidbody.AddForceAtPosition(num3 * vector, raycastHit.point, ForceMode.Force);
				if (!this.colliderRigidbody && raycastHit.collider.transform.parent != null)
				{
					this.colliderRigidbody = raycastHit.collider.transform.parent.GetComponent<Rigidbody>();
				}
				if (this.colliderRigidbody != null && !this.colliderRigidbody.isKinematic)
				{
					this.colliderRigidbody.AddForceAtPosition(-num3 * vector, raycastHit.point, ForceMode.Force);
				}
			}
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
	}

	private float SpeedInDirection(Vector3 direction)
	{
		Vector3 vector = base.GetComponent<Rigidbody>().velocity;
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
		if (!this.m_enabled)
		{
			this.m_playedIceSurfaceStart = false;
		}
		base.contraption.UpdateEngineStates(base.ConnectedComponent);
	}

	private void OnGearboxStateChanged()
	{
		this.m_playedIceSurfaceStart = false;
	}

	public float m_force;

	public bool m_enabled;

	public float m_maximumSpeed;

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

	private AudioSource loopingWheelBrushSound;

	private AudioSource wheelBrushSoundStart;

	private bool m_grounded;

	private bool m_onIceSurface;

	private bool m_playedIceSurfaceStart;

	private bool lastGearboxState;

	private float loopingIceSurfaceSoundTime;
}
