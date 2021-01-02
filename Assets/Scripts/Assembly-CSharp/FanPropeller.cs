using System;
using UnityEngine;

public class FanPropeller : BasePropulsion
{
	public override BasePart.JointConnectionStrength GetJointConnectionStrength()
	{
		if (this.m_partType == BasePart.PartType.Fan && this.m_gridRotation == BasePart.GridRotation.Deg_270)
		{
			return BasePart.JointConnectionStrength.High;
		}
		return this.m_jointConnectionStrength;
	}

	public override bool CanBeEnabled()
	{
		return this.m_maximumRotationSpeed > 0f;
	}

	public override bool HasOnOffToggle()
	{
		return true;
	}

	public override bool IsEnabled()
	{
		return this.m_enabled;
	}

	public override BasePart.Direction EffectDirection()
	{
		return BasePart.Rotate(this.m_forceDirection, this.m_gridRotation);
	}

	public override void Awake()
	{
		base.Awake();
		this.m_enabled = false;
	}

	public override void Initialize()
	{
		this.m_origRot = this.m_fanVisualization.transform.localRotation;
		this.m_enabled = false;
		Vector3 directionVector = BasePart.GetDirectionVector(this.m_forceDirection);
		this.m_originalDirection = base.transform.TransformDirection(directionVector);
		this.m_rotorTargetDirection = this.m_originalDirection;
		if (this.m_rotorTargetDirection.y < 0f)
		{
			this.m_rotorTargetDirection.y = 1f;
		}
	}

	public override void InitializeEngine()
	{
		this.powerFactor = base.contraption.GetEnginePowerFactor(this);
		if (this.powerFactor > 1f)
		{
			this.powerFactor = Mathf.Pow(this.powerFactor, 0.75f);
		}
		this.m_maximumSpeed = this.powerFactor * this.m_defaultSpeed;
		this.m_maximumForce = this.m_force * this.powerFactor;
		this.m_maximumRotationSpeed = 1000f * this.powerFactor;
		if (this.m_maximumRotationSpeed > 0f)
		{
			this.m_maximumRotationSpeed += 700f;
		}
		else
		{
			this.m_angle = 0f;
			if (this.m_enabled)
			{
				this.SetEnabled(false);
			}
		}
	}

	public void FixedUpdate()
	{
		if (!base.contraption || !base.contraption.IsRunning)
		{
			return;
		}
		if (this.m_enabled)
		{
			this.m_rotationSpeed = this.m_maximumRotationSpeed;
		}
		else if (this.m_rotationSpeed < 450f)
		{
			this.m_rotationSpeed *= 0.9f;
		}
		else
		{
			this.m_rotationSpeed *= 0.98f;
		}
		this.m_angle += this.m_rotationSpeed * Time.deltaTime;
		if (this.m_angle > 180f)
		{
			this.m_angle -= 360f;
		}
		if (!this.m_enabled)
		{
			if (this.m_isRotor)
			{
				base.rigidbody.angularDrag = 1f;
			}
			return;
		}
		if (this.m_isRotor)
		{
			base.rigidbody.angularDrag = 1000f;
		}
		Vector3 directionVector = BasePart.GetDirectionVector(this.m_forceDirection);
		Vector3 vector = base.transform.TransformDirection(directionVector);
		Vector3 position = base.transform.position + vector * 0.5f;
		Vector3 vector2 = vector;
		if (this.m_isRotor)
		{
			float num = Vector3.Dot(vector2, this.m_rotorTargetDirection);
			if (num > 0f)
			{
				vector2 = 0.5f * (vector2 + this.m_rotorTargetDirection);
			}
		}
		float num2 = this.LimitForceForSpeed(this.m_maximumForce, vector2);
		float num3 = 1f;
		if (this.m_forceDirection == BasePart.Direction.Left)
		{
			float value = Vector3.Dot(base.rigidbody.velocity, -vector2);
			float num4 = Mathf.Clamp(value, -2f, 2f);
			Vector3 position2 = base.transform.position;
			position2.z = 0f;
			RaycastHit raycastHit;
			if (Physics.Raycast(position2, -vector2, out raycastHit, 1f) && this.m_enabled)
			{
				num3 = 1f + (2f + num4) * Mathf.Pow(1f - raycastHit.distance, 1.5f);
			}
		}
		if (this.m_partType == BasePart.PartType.Rotor && this.m_enabled)
		{
			Vector3 velocity = base.rigidbody.velocity;
			if (velocity.magnitude > this.m_maximumSpeed && Vector3.Dot(vector2, velocity) > 0f)
			{
				float num5 = velocity.magnitude - this.m_maximumSpeed;
				base.rigidbody.AddForceAtPosition(-4f * num5 * num5 * velocity.normalized, position, ForceMode.Force);
			}
		}
		base.rigidbody.AddForceAtPosition(num2 * num3 * vector2, position, ForceMode.Force);
	}

	private float LimitForceForSpeed(float forceMagnitude, Vector3 forceDir)
	{
		Vector3 velocity = base.rigidbody.velocity;
		float num = Vector3.Dot(velocity.normalized, forceDir);
		if (num > 0f)
		{
			Vector3 vector = velocity * num;
			if (vector.magnitude > this.m_maximumSpeed)
			{
				return forceMagnitude / (1f + vector.magnitude - this.m_maximumSpeed);
			}
		}
		return forceMagnitude;
	}

	protected override void OnTouch()
	{
		this.SetEnabled(!this.m_enabled);
	}

	public override void SetEnabled(bool toggle)
	{
		if (toggle && this.m_maximumRotationSpeed == 0f)
		{
			return;
		}
		this.m_enabled = toggle;
		if (!this.m_enabled)
		{
			this.m_rotationSpeed = 800f;
			this.m_angle = 292.3f;
			if (this.smokeCloud)
			{
				this.smokeCloud.Stop();
			}
		}
		else if (this.smokeCloud)
		{
			this.smokeCloud.Play();
		}
		base.contraption.UpdateEngineStates(base.ConnectedComponent);
		if (this.m_enabled)
		{
			//this.PlayPropellerSound();
		}
		else if (this.loopingSound)
		{
			Singleton<AudioManager>.Instance.RemoveCombinedLoopingEffect(this.loopingSoundPrefab, this.loopingSound);
		}
		Billboard component = base.GetComponent<Billboard>();
		if (component)
		{
			component.enabled = !this.m_enabled;
		}
	}

	public void PlayPropellerSound()
	{
		AudioManager instance = Singleton<AudioManager>.Instance;
		BasePart.PartType partType = this.m_partType;
		if (partType != BasePart.PartType.Fan)
		{
			if (partType != BasePart.PartType.Rotor)
			{
				this.loopingSoundPrefab = ((this.m_partTier != BasePart.PartTier.Legendary) ? WPFMonoBehaviour.gameData.commonAudioCollection.propeller : WPFMonoBehaviour.gameData.commonAudioCollection.alienFan);
			}
			else
			{
				this.loopingSoundPrefab = ((this.m_partTier != BasePart.PartTier.Legendary) ? WPFMonoBehaviour.gameData.commonAudioCollection.rotorLoop : WPFMonoBehaviour.gameData.commonAudioCollection.alienRotor);
			}
		}
		else
		{
			this.loopingSoundPrefab = ((this.m_partTier != BasePart.PartTier.Legendary) ? WPFMonoBehaviour.gameData.commonAudioCollection.fan : WPFMonoBehaviour.gameData.commonAudioCollection.alienFan);
		}
		this.loopingSound = instance.SpawnCombinedLoopingEffect(this.loopingSoundPrefab, base.gameObject.transform);
	}

	protected new void LateUpdate()
	{
		base.LateUpdate();
		Vector3 axis = (!this.m_isRotor) ? Vector3.right : Vector3.up;
		this.m_fanVisualization.transform.localRotation = this.m_origRot * Quaternion.AngleAxis(this.m_angle, axis);
	}

	public float m_force;

	public BasePart.Direction m_forceDirection;

	public bool m_isRotor;

	public bool m_enabled;

	public float m_defaultSpeed;

	public Transform m_fanVisualization;

	protected Quaternion m_origRot;

	protected float m_angle;

	private Vector3 m_originalDirection;

	private Vector3 m_rotorTargetDirection;

	private float m_maximumRotationSpeed;

	private float m_rotationSpeed;

	private float m_maximumForce;

	private float m_maximumSpeed;

	private GameObject loopingSound;

	private AudioSource loopingSoundPrefab;

	private float powerFactor;

	private const float LowPowerSoundLimit = 1f;

	public ParticleSystem smokeCloud;
}
