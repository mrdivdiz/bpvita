using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoxingGlove : BasePart
{
	public override bool CanBeEnabled()
	{
		return this.m_CanBeEnabled;
	}

	public override bool CanBeEnclosed()
	{
		return true;
	}

	public override bool IsEnabled()
	{
		return this.m_enabled;
	}

	public override bool HasOnOffToggle()
	{
		return false;
	}

	public override BasePart.Direction EffectDirection()
	{
		return BasePart.Rotate(BasePart.Direction.Down, this.m_gridRotation);
	}

	public override void Awake()
	{
		base.Awake();
		this.m_SpringVisualization = base.transform.Find("SpringVisualization").gameObject;
		this.m_SpringVisualization.SetActive(false);
		this.m_SpringVisualizationInitZ = this.m_SpringVisualization.transform.localPosition.z;
		this.m_Visualization = base.transform.Find("Visualization").gameObject;
		this.m_enabled = false;
	}

	public override void EnsureRigidbody()
	{
		this.m_Visualization.transform.localRotation = Quaternion.identity;
		base.transform.localRotation = Quaternion.AngleAxis(base.GetRotationAngle(this.m_gridRotation), Vector3.forward);
		base.EnsureRigidbody();
		base.rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
	}

	public override void PrePlaced()
	{
		base.PrePlaced();
		this.SetRotation(BasePart.GridRotation.Deg_0);
	}

	public override void SetRotation(BasePart.GridRotation rotation)
	{
		this.m_gridRotation = rotation;
		this.m_Visualization.transform.localRotation = Quaternion.AngleAxis(base.GetRotationAngle(rotation), Vector3.forward);
		this.CheckRotations();
	}

	private void FlipRotation(Transform target, bool flipX, bool flipY)
	{
		Vector3 localScale = target.localScale;
		if (flipX)
		{
			localScale.x = -Mathf.Abs(localScale.x);
		}
		else
		{
			localScale.x = Mathf.Abs(localScale.x);
		}
		if (flipY)
		{
			localScale.y = -Mathf.Abs(localScale.y);
		}
		else
		{
			localScale.y = Mathf.Abs(localScale.y);
		}
		target.localScale = localScale;
	}

	private void FlipPosition(Transform target, bool flipX, bool flipY)
	{
		Vector3 localPosition = target.localPosition;
		if (flipX)
		{
			localPosition.x = -Mathf.Abs(localPosition.x);
		}
		if (flipY)
		{
			localPosition.y = -Mathf.Abs(localPosition.y);
		}
		target.localPosition = localPosition;
	}

	public override void ChangeVisualConnections()
	{
		this.m_SpringVisualization.SetActive(false);
	}

	public override void Initialize()
	{
		this.m_BoxingGlove = UnityEngine.Object.Instantiate<GameObject>(this.m_BoxingGlovePrefab, base.transform.position, base.transform.rotation);
		this.m_BoxingGloveRigidbody = this.m_BoxingGlove.GetComponent<Rigidbody>();
		this.m_BoxingGlove.transform.parent = base.transform;
		this.m_BoxingGloveVisualization = this.m_BoxingGlove.transform.Find("Visualization").gameObject;
		this.CheckRotations();
		this.m_BoxingGlove.SetActive(true);
		this.InitilizeBoxingGlove();
		if (WPFMonoBehaviour.levelManager.ContraptionRunning == null)
		{
			return;
		}
		BasePart.Direction direction = this.EffectDirection();
		int num = (direction != BasePart.Direction.Left) ? ((direction != BasePart.Direction.Right) ? 0 : 1) : -1;
		int num2 = (direction != BasePart.Direction.Down) ? ((direction != BasePart.Direction.Up) ? 0 : 1) : -1;
		this.m_EffectDirPart = WPFMonoBehaviour.levelManager.ContraptionRunning.FindPartAt(this.m_coordX + num, this.m_coordY + num2);
		if (this.m_EffectDirPart)
		{
			this.m_FixedJointToBreak = WPFMonoBehaviour.levelManager.ContraptionRunning.FindPartFixedJoints(this.m_EffectDirPart);
		}
		this.m_CanBeEnabled = (!WPFMonoBehaviour.levelManager.ContraptionRunning.HasSuperGlue || this.m_FixedJointToBreak == null || this.m_FixedJointToBreak.Count <= 0 || !this.m_FixedJointToBreak[0] || this.m_EffectDirPart.m_partType == BasePart.PartType.TNT);
	}

	private void CheckRotations()
	{
		if (this.m_checkRotation && this.m_gridRotation == BasePart.GridRotation.Deg_90)
		{
			this.FlipRotation(this.m_Visualization.transform, true, false);
			if (this.m_BoxingGloveVisualization)
			{
				this.FlipRotation(this.m_BoxingGloveVisualization.transform, false, false);
			}
		}
		else if (this.m_checkRotation)
		{
			this.FlipRotation(this.m_Visualization.transform, false, false);
			if (this.m_BoxingGloveVisualization)
			{
				this.FlipRotation(this.m_BoxingGloveVisualization.transform, false, true);
				this.FlipPosition(this.m_BoxingGloveVisualization.transform, true, false);
			}
		}
	}

	private void InitilizeBoxingGlove()
	{
		this.m_BoxingGlove.SetActive(true);
		ConfigurableJoint configurableJoint = this.m_BoxingGlove.GetComponent<ConfigurableJoint>();
		if (configurableJoint == null)
		{
			configurableJoint = this.m_BoxingGlove.AddComponent<ConfigurableJoint>();
		}
		configurableJoint.connectedBody = base.rigidbody;
		configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
		configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
		configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
		configurableJoint.xMotion = ConfigurableJointMotion.Locked;
		configurableJoint.yMotion = ConfigurableJointMotion.Limited;
		configurableJoint.zMotion = ConfigurableJointMotion.Locked;
		SoftJointLimitSpring linearLimitSpring = default(SoftJointLimitSpring);
		SoftJointLimit linearLimit = default(SoftJointLimit);
		linearLimitSpring.spring = 0f;
		linearLimitSpring.damper = 0f;
		linearLimit.bounciness = 0f;
		linearLimit.limit = 1f;
		configurableJoint.linearLimit = linearLimit;
		configurableJoint.linearLimitSpring = linearLimitSpring;
		configurableJoint.yDrive = new JointDrive
		{
			positionSpring = this.m_SpringYDrive,
			positionDamper = this.m_SpringYDriveDamper,
			maximumForce = float.MaxValue
		};
		configurableJoint.xDrive = new JointDrive
		{
			positionSpring = 1000f,
			positionDamper = 5f,
			maximumForce = float.MaxValue
		};
		configurableJoint.targetPosition = Vector3.zero;
		configurableJoint.projectionMode = JointProjectionMode.PositionAndRotation;
		configurableJoint.projectionDistance = 0.1f;
		configurableJoint.projectionAngle = 0f;
		configurableJoint.enablePreprocessing = false;
		this.m_SpringVisualization.SetActive(false);
		this.m_BoxingGloveVisualization.SetActive(false);
		this.IgnoreCollisions();
		this.m_BoxingGlove.transform.localPosition = Vector3.zero;
		this.m_BoxingGlove.transform.localRotation = Quaternion.identity;
		if (this.m_BoxingGloveSolverIterCount < 0)
		{
			this.m_BoxingGloveSolverIterCount = (int)((float)this.m_BoxingGloveRigidbody.solverIterations * 1.6f);
		}
		this.m_BoxingGloveRigidbody.solverIterations = this.m_BoxingGloveSolverIterCount;
		Collider component = this.m_BoxingGlove.GetComponent<Collider>();
		if (component)
		{
			component.enabled = true;
		}
		Rigidbody component2 = this.m_BoxingGlove.GetComponent<Rigidbody>();
		if (component2)
		{
			component2.mass = 0.5f;
		}
		this.m_State = SpringBoxingGlove.State.WindedUp;
		this.m_BoxingGlove.SetActive(false);
	}

	private void IgnoreCollisions()
	{
		if (base.GetComponent<Collider>() != null && this.m_BoxingGlove != null && this.m_BoxingGlove.activeInHierarchy && this.m_BoxingGlove.GetComponent<Collider>() != null)
		{
			Physics.IgnoreCollision(base.GetComponent<Collider>(), this.m_BoxingGlove.GetComponent<Collider>());
			if (this.m_enclosedInto != null && this.m_enclosedInto.GetComponent<Collider>() != null)
			{
				Physics.IgnoreCollision(this.m_enclosedInto.GetComponent<Collider>(), this.m_BoxingGlove.GetComponent<Collider>());
			}
		}
	}

	private IEnumerator Shoot(float timeout)
	{
		if (timeout > 0f)
		{
			yield return new WaitForSeconds(timeout);
		}
		if (this.m_EffectDirPart && base.ConnectedComponent >= 0 && this.m_EffectDirPart.ConnectedComponent == base.ConnectedComponent)
		{
			for (int i = 0; i < this.m_FixedJointToBreak.Count; i++)
			{
				UnityEngine.Object.Destroy(this.m_FixedJointToBreak[i]);
				if (this.m_FixedJointToBreak[i])
				{
					BasePart component = this.m_FixedJointToBreak[i].gameObject.GetComponent<BasePart>();
					if (component)
					{
						component.HandleJointBreak(1000f, true);
					}
				}
				this.m_FixedJointToBreak[i] = null;
			}
			this.m_FixedJointToBreak.Clear();
		}
		this.m_State = SpringBoxingGlove.State.Shoot;
		this.m_enabled = true;
		this.m_BoxingGlove.SetActive(true);
		this.m_SpringVisualization.SetActive(true);
		this.m_BoxingGloveVisualization.SetActive(true);
		this.m_ShootStartTime = Time.time;
		if (base.HasTag("Alien_part"))
		{
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.alienPunch, base.transform.position);
		}
		else
		{
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.springBoxingGloveShoot, base.transform.position);
		}
		ConfigurableJoint joint = this.m_BoxingGlove.GetComponent<ConfigurableJoint>();
		joint.targetPosition = new Vector3(this.m_targetDeviationX * ((UnityEngine.Random.value >= 0.5f) ? 1f : -1f), this.m_targetDistanceY, 0f);
		SoftJointLimitSpring limitSpring = joint.linearLimitSpring;
		limitSpring.spring = 0.1f;
		joint.linearLimitSpring = limitSpring;
		JointDrive yDrive = joint.yDrive;
		joint.yDrive = yDrive;
		if (this.m_targetDeviationX != 0f)
		{
			joint.xMotion = ConfigurableJointMotion.Limited;
			JointDrive xDrive = joint.xDrive;
			joint.xDrive = xDrive;
		}
		yield break;
	}

	protected override void OnTouch()
	{
		if (!this.m_enabled && this.CanBeEnabled())
		{
			base.StartCoroutine(this.Shoot(0f));
		}
	}

	private void Update()
	{
		this.IgnoreCollisions();
		SpringBoxingGlove.State state = this.m_State;
		if (state != SpringBoxingGlove.State.Shoot)
		{
			if (state == SpringBoxingGlove.State.Winding)
			{
				if (Time.time - this.m_WindingStartTime > this.m_WindingTime || this.m_BoxingGlove.transform.localPosition.magnitude < 0.1f || this.m_BoxingGlove.transform.localPosition.y > 0f)
				{
					this.m_State = SpringBoxingGlove.State.WindedUp;
					this.m_enabled = false;
					this.InitilizeBoxingGlove();
				}
			}
		}
		else if (Time.time - this.m_ShootStartTime > this.m_ShootTime)
		{
			this.m_State = SpringBoxingGlove.State.Winding;
			this.m_WindingStartTime = Time.time;
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.springBoxingGloveWinding, base.transform.position);
			ConfigurableJoint component = this.m_BoxingGlove.GetComponent<ConfigurableJoint>();
			component.targetPosition = Vector3.zero;
			JointDrive yDrive = component.yDrive;
			float num = 10f;
			yDrive.positionDamper = num * 0.25f;
			yDrive.positionSpring = num * this.m_targetDistanceY;
			component.yDrive = yDrive;
			Collider component2 = this.m_BoxingGlove.GetComponent<Collider>();
			if (component2)
			{
				component2.enabled = false;
			}
			Rigidbody component3 = this.m_BoxingGlove.GetComponent<Rigidbody>();
			if (component3)
			{
				component3.mass = 0.01f;
			}
		}
		if (this.m_State != SpringBoxingGlove.State.WindedUp && base.rigidbody && this.m_BoxingGloveRigidbody)
		{
			Vector3 position = base.transform.position;
			Vector3 position2 = this.m_BoxingGlove.transform.position;
			this.m_SpringVisualization.transform.rotation = Quaternion.LookRotation(Vector3.back, position2 - position);
			Vector3 localScale = this.m_SpringVisualization.transform.localScale;
			localScale.y = Vector3.Distance(position, position2);
			this.m_SpringVisualization.transform.localScale = localScale;
			this.m_SpringVisualization.transform.position = 0.5f * (position + position2);
			Vector3 localPosition = this.m_SpringVisualization.transform.localPosition;
			localPosition.z = this.m_SpringVisualizationInitZ;
			this.m_SpringVisualization.transform.localPosition = localPosition;
		}
	}

	private float m_SpringVisualizationInitZ;

	private int m_BoxingGloveSolverIterCount = -1;

	private GameObject m_Visualization;

	private GameObject m_SpringVisualization;

	private GameObject m_BoxingGlove;

	private Rigidbody m_BoxingGloveRigidbody;

	private GameObject m_BoxingGloveVisualization;

	public GameObject m_BoxingGlovePrefab;

	private bool m_enabled;

	private bool m_CanBeEnabled = true;

	private SpringBoxingGlove.State m_State;

	public float m_targetDistanceY = 2.5f;

	public float m_targetDeviationX = 0.01f;

	public float m_WindingTime = 1f;

	public float m_ShootTime = 1f;

	public float m_SpringYDrive = 60f;

	public float m_SpringYDriveDamper = 3f;

	public bool m_checkRotation;

	private float m_ShootStartTime;

	private float m_WindingStartTime;

	private List<Joint> m_FixedJointToBreak;

	private BasePart m_EffectDirPart;

	private enum State
	{
		WindedUp,
		Shoot,
		Winding
	}
}
