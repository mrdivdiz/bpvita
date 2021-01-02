using System;
using UnityEngine;

public class GrapplingHook : BasePart
{
	public override bool CanBeEnabled()
	{
		return this.m_CanBeEnabled;
	}

	public override bool CanBeEnclosed()
	{
		return false;
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
		return BasePart.RotateWithEightDirections(BasePart.Direction.Right, this.m_gridRotation);
	}

	public override void Awake()
	{
		base.Awake();
		this.m_leftAttachment = base.transform.Find("LeftAttachment").gameObject;
		this.m_rightAttachment = base.transform.Find("RightAttachment").gameObject;
		this.m_topAttachment = base.transform.Find("TopAttachment").gameObject;
		this.m_bottomAttachment = base.transform.Find("BottomAttachment").gameObject;
		this.m_bottomLeftAttachment = base.transform.Find("BottomLeftAttachment").gameObject;
		this.m_bottomRightAttachment = base.transform.Find("BottomRightAttachment").gameObject;
		this.m_topLeftAttachment = base.transform.Find("TopLeftAttachment").gameObject;
		this.m_topRightAttachment = base.transform.Find("TopRightAttachment").gameObject;
		this.m_leftAttachment.SetActive(false);
		this.m_rightAttachment.SetActive(false);
		this.m_topAttachment.SetActive(false);
		this.m_bottomAttachment.SetActive(false);
		this.m_bottomLeftAttachment.SetActive(false);
		this.m_bottomRightAttachment.SetActive(false);
		this.m_topLeftAttachment.SetActive(false);
		this.m_topRightAttachment.SetActive(false);
		this.m_SpringVisualization = base.transform.Find("SpringVisualization").gameObject;
		this.m_SpringVisualization.SetActive(false);
		this.m_SpringVisualizationInitZ = this.m_SpringVisualization.transform.localPosition.z;
		this.m_eightWay = true;
		GameObject gameObject = base.transform.Find("Visualization").gameObject;
		if (gameObject != null)
		{
			this.m_Visualization = gameObject;
		}
		this.m_enabled = false;
	}

	public override BasePart.GridRotation AutoAlignRotation(BasePart.JointConnectionDirection target)
	{
		switch (target)
		{
		case BasePart.JointConnectionDirection.Right:
			return BasePart.GridRotation.Deg_180;
		case BasePart.JointConnectionDirection.Up:
			return BasePart.GridRotation.Deg_0;
		case BasePart.JointConnectionDirection.Left:
			return BasePart.GridRotation.Deg_0;
		case BasePart.JointConnectionDirection.Down:
			return BasePart.GridRotation.Deg_90;
		default:
			return BasePart.GridRotation.Deg_0;
		}
	}

	public override void EnsureRigidbody()
	{
		this.m_Visualization.transform.localRotation = Quaternion.identity;
		base.transform.localRotation = Quaternion.AngleAxis(base.GetRotationAngle(this.m_gridRotation), Vector3.forward);
		base.EnsureRigidbody();
		base.rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
	}

	public override void PrePlaced()
	{
		base.PrePlaced();
		this.SetRotation(BasePart.GridRotation.Deg_0);
	}

	public override void ChangeVisualConnections()
	{
		bool flag = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Up, this.m_gridRotation));
		bool flag2 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Down, this.m_gridRotation));
		bool flag3 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Left, this.m_gridRotation));
		bool flag4 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Right, this.m_gridRotation));
		bool flag5 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.UpLeft, this.m_gridRotation));
		bool flag6 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.DownLeft, this.m_gridRotation));
		bool flag7 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.UpRight, this.m_gridRotation));
		bool flag8 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.DownRight, this.m_gridRotation));
		bool flag9 = this.m_gridRotation == BasePart.GridRotation.Deg_135 || this.m_gridRotation == BasePart.GridRotation.Deg_45 || this.m_gridRotation == BasePart.GridRotation.Deg_225 || this.m_gridRotation == BasePart.GridRotation.Deg_315;
		this.m_leftAttachment.SetActive(flag3 && !flag9);
		this.m_rightAttachment.SetActive(flag4 && !flag9);
		this.m_topAttachment.SetActive(flag && !flag9);
		this.m_bottomAttachment.SetActive((flag2 && !flag9) || (!flag && !flag3 && !flag4 && !flag9));
		this.m_bottomLeftAttachment.SetActive(flag6 && flag9);
		this.m_bottomRightAttachment.SetActive(flag8 && flag9);
		this.m_topLeftAttachment.SetActive(flag5 && flag9);
		this.m_topRightAttachment.SetActive(flag7 && flag9);
		if (!flag && !flag6 && !flag3 && !flag4 && !flag5 && !flag6 && !flag7 && !flag8)
		{
			this.m_bottomAttachment.SetActive(true);
		}
		this.m_SpringVisualization.SetActive(false);
	}

	public override void Initialize()
	{
		this.m_GrapplingHook = UnityEngine.Object.Instantiate<GameObject>(this.m_GrapplingHookPrefab, base.transform.position, base.transform.rotation);
		this.m_GrapplingHookRigidbody = this.m_GrapplingHook.GetComponent<Rigidbody>();
		this.m_GrapplingHook.transform.parent = base.transform;
		this.m_GrapplingHookScript = this.m_GrapplingHook.GetComponent<Hook>();
		this.m_GrapplingHook.SetActive(true);
		this.InitializeGrapplingHook();
		if (WPFMonoBehaviour.levelManager.ContraptionRunning == null)
		{
			return;
		}
		BasePart.Direction direction = this.EffectDirection();
		int num = (direction != BasePart.Direction.Left) ? ((direction != BasePart.Direction.Right) ? 0 : 1) : -1;
		int num2 = (direction != BasePart.Direction.Down) ? ((direction != BasePart.Direction.Up) ? 0 : 1) : -1;
		BasePart basePart = WPFMonoBehaviour.levelManager.ContraptionRunning.FindPartAt(this.m_coordX + num, this.m_coordY + num2);
		this.m_CanBeEnabled = (!WPFMonoBehaviour.levelManager.ContraptionRunning.HasSuperGlue || !this.m_FixedJointToBreak[0] || basePart.m_partType == BasePart.PartType.TNT);
	}

	private void InitializeGrapplingHook()
	{
		this.m_GrapplingHook.SetActive(true);
		this.m_joint = this.m_GrapplingHook.GetComponent<ConfigurableJoint>();
		if (this.m_joint == null)
		{
			this.m_joint = this.m_GrapplingHook.AddComponent<ConfigurableJoint>();
		}
		this.m_joint.projectionMode = JointProjectionMode.PositionAndRotation;
		this.m_joint.xMotion = ConfigurableJointMotion.Free;
		this.m_joint.yMotion = ConfigurableJointMotion.Free;
		this.m_joint.zMotion = ConfigurableJointMotion.Locked;
		SoftJointLimitSpring linearLimitSpring = default(SoftJointLimitSpring);
		SoftJointLimit linearLimit = default(SoftJointLimit);
		linearLimit.bounciness = 1f;
		linearLimitSpring.spring = this.m_springStrength;
		linearLimitSpring.damper = 1.5f;
		linearLimit.limit = this.m_maxHookDistance;
		this.m_joint.linearLimit = linearLimit;
		this.m_joint.linearLimitSpring = linearLimitSpring;
		this.m_joint.connectedBody = base.rigidbody;
		this.m_joint.enablePreprocessing = false;
		this.m_SpringVisualization.SetActive(false);
		this.IgnoreCollisions();
		this.m_GrapplingHook.transform.position = base.transform.position;
		this.m_GrapplingHook.transform.rotation = base.transform.rotation;
		if (this.m_GrapplingHookSolverIterCount < 0)
		{
			this.m_GrapplingHookSolverIterCount = (int)((float)this.m_GrapplingHookRigidbody.solverIterations * 1.6f);
		}
		this.m_GrapplingHookRigidbody.solverIterations = this.m_GrapplingHookSolverIterCount;
		this.m_State = GrapplingHook.State.WindedUp;
		this.m_GrapplingHook.SetActive(false);
	}

	private void IgnoreCollisions()
	{
		if (base.collider != null && this.m_GrapplingHook != null && this.m_GrapplingHook.activeInHierarchy && this.m_GrapplingHook.GetComponent<Collider>() != null)
		{
			Physics.IgnoreCollision(base.collider, this.m_GrapplingHook.GetComponent<Collider>());
			if (this.m_enclosedInto != null && this.m_enclosedInto.collider != null)
			{
				Physics.IgnoreCollision(this.m_enclosedInto.collider, this.m_GrapplingHook.GetComponent<Collider>());
			}
		}
	}

	private void Shoot()
	{
		this.m_State = GrapplingHook.State.Shoot;
		this.m_enabled = true;
		this.m_SpringVisualization.SetActive(true);
		Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.grapplingHookLaunch, base.transform.position);
		this.m_shotStartTime = Time.time;
		Vector3 vector = base.transform.TransformDirection(this.m_direction);
		this.m_GrapplingHook.transform.parent = base.transform;
		this.m_GrapplingHook.transform.position = base.transform.position;
		this.m_GrapplingHook.transform.rotation = base.transform.rotation;
		this.m_GrapplingHook.SetActive(true);
		this.m_Visualization.SetActive(false);
		this.m_GrapplingHookRigidbody.AddForce(vector.normalized * 20f, ForceMode.Impulse);
	}

	protected override void OnTouch()
	{
		if (!this.m_enabled && this.CanBeEnabled() && Time.time - this.m_plungerTimer > this.m_plungerResetTimer)
		{
			this.Shoot();
		}
		else if (this.m_State == GrapplingHook.State.Shoot || this.m_State == GrapplingHook.State.Winding || this.m_State == GrapplingHook.State.Idle)
		{
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.grapplingHookMiss, base.transform.position);
			this.m_State = GrapplingHook.State.Rewind;
			base.contraption.SetHangingFromHook(false, base.GetInstanceID());
			this.m_ReWindingStartTime = Time.time;
			if (Singleton<SocialGameManager>.IsInstantiated() && base.contraption.IsConnectedToPig(this, base.GetComponent<Collider>()) && !base.contraption.GetHangingFromHook() && Mathf.Abs(base.rigidbody.velocity.x) > 3f)
			{
				base.contraption.SetSwings(base.contraption.GetSwings() + 1);
				Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.SWINGIN_PIGGIES", 100.0);
				BasePart basePart = base.contraption.FindPartOfType(BasePart.PartType.KingPig);
				if (base.contraption.GetSwings() > 1 && basePart && base.contraption.IsConnectedToPig(basePart, basePart.GetComponent<Collider>()))
				{
					Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.KING_PIG_OF_THE_JUNGLE", 100.0);
				}
			}
		}
	}

	private void Update()
	{
		if (this.m_State != GrapplingHook.State.WindedUp && base.rigidbody && this.m_GrapplingHookRigidbody)
		{
			Vector3 position = base.transform.position;
			Vector3 position2 = this.m_GrapplingHook.transform.position;
			this.m_SpringVisualization.transform.rotation = Quaternion.LookRotation(Vector3.back, position2 - position);
			Vector3 localScale = this.m_SpringVisualization.transform.localScale;
			localScale.y = Vector3.Distance(position, position2) * 1.25f;
			this.m_SpringVisualization.transform.localScale = localScale;
			this.m_SpringVisualization.transform.position = 0.5f * (position + position2);
			Vector3 localPosition = this.m_SpringVisualization.transform.localPosition;
			localPosition.z = this.m_SpringVisualizationInitZ;
			this.m_SpringVisualization.transform.localPosition = localPosition;
		}
	}

	private void FixedUpdate()
	{
		this.IgnoreCollisions();
		switch (this.m_State)
		{
		case GrapplingHook.State.WindedUp:
			if (!this.m_Visualization.activeSelf && Time.time - this.m_plungerTimer > this.m_plungerResetTimer)
			{
				this.PlaySound(WPFMonoBehaviour.gameData.commonAudioCollection.grapplingHookReset);
				this.m_Visualization.SetActive(true);
			}
			break;
		case GrapplingHook.State.Shoot:
			if (this.m_GrapplingHookScript.GetAttachType() != Hook.AttachType.None)
			{
				this.m_State = GrapplingHook.State.Winding;
				this.m_hookDistance = this.HookDistance();
				Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.grapplingHookAttach, this.m_GrapplingHook.transform.position);
				this.m_loopingReelSound = Singleton<AudioManager>.Instance.SpawnLoopingEffect(WPFMonoBehaviour.gameData.commonAudioCollection.grapplingHookReeling, base.transform);
				SoftJointLimit linearLimit = this.m_joint.linearLimit;
				linearLimit.limit = this.m_hookDistance;
				this.m_joint.linearLimit = linearLimit;
			}
			else if ((this.m_GrapplingHookScript.GetAttachType() == Hook.AttachType.None && this.HookDistance() > this.m_maxHookDistance) || Time.time - this.m_shotStartTime > this.m_ShootTime)
			{
				Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.grapplingHookMiss, base.transform.position);
				this.m_ReWindingStartTime = Time.time;
				this.m_State = GrapplingHook.State.Rewind;
			}
			break;
		case GrapplingHook.State.Winding:
		{
			float num = this.HookDistance();
			if (base.contraption.IsConnectedToPig(this, base.GetComponent<Collider>()))
			{
				base.contraption.SetHangingFromHook(true, base.GetInstanceID());
			}
			else
			{
				base.contraption.SetHangingFromHook(false, base.GetInstanceID());
			}
			if (num < this.m_minimumDistance)
			{
				if (this.m_loopingReelSound != null)
				{
					Singleton<AudioManager>.Instance.StopLoopingEffect(this.m_loopingReelSound.GetComponent<AudioSource>());
				}
				if (this.m_joint != null)
				{
					SoftJointLimit linearLimit2 = this.m_joint.linearLimit;
					linearLimit2.limit = this.m_minimumDistance;
					this.m_joint.linearLimit = linearLimit2;
					this.m_joint.zMotion = ConfigurableJointMotion.Locked;
					this.m_joint.xMotion = ConfigurableJointMotion.Limited;
					this.m_joint.yMotion = ConfigurableJointMotion.Limited;
				}
			}
			else if (this.m_GrapplingHookScript != null && this.m_GrapplingHookScript.GetAttachType() != Hook.AttachType.None)
			{
				if ((double)num > 1.1 * (double)this.m_maxHookDistance)
				{
					this.PlaySound(WPFMonoBehaviour.gameData.commonAudioCollection.grapplingHookDetach);
					this.m_State = GrapplingHook.State.Rewind;
					base.contraption.SetHangingFromHook(false, base.GetInstanceID());
				}
				else
				{
					this.m_joint.zMotion = ConfigurableJointMotion.Locked;
					this.m_joint.xMotion = ConfigurableJointMotion.Limited;
					this.m_joint.yMotion = ConfigurableJointMotion.Limited;
					if (this.m_minimumDistance < num)
					{
						SoftJointLimit linearLimit3 = this.m_joint.linearLimit;
						linearLimit3.limit -= this.m_maxWindingSpeed * Time.fixedDeltaTime;
						if (linearLimit3.limit < this.m_minimumDistance)
						{
							linearLimit3.limit = this.m_minimumDistance;
							if (this.m_loopingReelSound != null)
							{
								Singleton<AudioManager>.Instance.StopLoopingEffect(this.m_loopingReelSound.GetComponent<AudioSource>());
							}
						}
						this.m_joint.linearLimit = linearLimit3;
					}
				}
			}
			break;
		}
		case GrapplingHook.State.Rewind:
			if (this.m_joint != null)
			{
				if (this.m_loopingReelSound != null)
				{
					Singleton<AudioManager>.Instance.StopLoopingEffect(this.m_loopingReelSound.GetComponent<AudioSource>());
				}
				if (Time.time - this.m_ReWindingStartTime < this.m_rewindingTime && this.HookDistance() > 1f)
				{
					this.m_GrapplingHookScript.Reset();
					this.m_GrapplingHookRigidbody.AddForceAtPosition((base.transform.position - this.m_GrapplingHook.transform.position).normalized * 40f, this.m_GrapplingHook.transform.position, ForceMode.Force);
					float magnitude = this.m_GrapplingHookRigidbody.velocity.magnitude;
					this.m_GrapplingHookRigidbody.velocity = (base.transform.position - this.m_GrapplingHook.transform.position).normalized * magnitude;
				}
				else
				{
					this.m_State = GrapplingHook.State.Detach;
				}
			}
			break;
		case GrapplingHook.State.Detach:
			if (this.m_loopingReelSound != null)
			{
				Singleton<AudioManager>.Instance.StopLoopingEffect(this.m_loopingReelSound.GetComponent<AudioSource>());
			}
			this.m_State = GrapplingHook.State.WindedUp;
			this.m_enabled = false;
			this.InitializeGrapplingHook();
			this.m_GrapplingHookRigidbody.velocity = Vector3.zero;
			this.m_GrapplingHookScript.Reset();
			this.m_plungerTimer = Time.time;
			break;
		}
		if (base.contraption != null && base.contraption.GetTouchingGround())
		{
			base.contraption.SetTouchingGround(false);
			base.contraption.SetSwings(0);
		}
	}

	private void PlaySound(AudioSource soundEffect)
	{
		Singleton<AudioManager>.Instance.SpawnOneShotEffect(soundEffect, this.m_GrapplingHook.transform.position);
	}

	private float HookDistance()
	{
		return (this.m_GrapplingHook.transform.position - base.transform.position).magnitude;
	}

	private void OnDestroy()
	{
		if (this.m_GrapplingHook != null)
		{
			UnityEngine.Object.Destroy(this.m_GrapplingHook);
		}
	}

	private float m_SpringVisualizationInitZ;

	private int m_GrapplingHookSolverIterCount = -1;

	private GameObject m_Visualization;

	private GameObject m_SpringVisualization;

	private GameObject m_GrapplingHook;

	private Rigidbody m_GrapplingHookRigidbody;

	private Hook m_GrapplingHookScript;

	public GameObject m_GrapplingHookPrefab;

	private bool m_enabled;

	private bool m_CanBeEnabled = true;

	private GrapplingHook.State m_State;

	public float m_rewindingTime = 4f;

	public float m_ShootTime = 2.5f;

	private Vector3 m_direction = Vector3.right;

	private FixedJoint[] m_FixedJointToBreak = new FixedJoint[32];

	private GameObject m_leftAttachment;

	private GameObject m_rightAttachment;

	private GameObject m_topAttachment;

	private GameObject m_bottomAttachment;

	private GameObject m_bottomLeftAttachment;

	private GameObject m_bottomRightAttachment;

	private GameObject m_topLeftAttachment;

	private GameObject m_topRightAttachment;

	private GameObject m_loopingReelSound;

	private ConfigurableJoint m_joint;

	private float m_shotStartTime;

	private float m_ReWindingStartTime;

	private float m_hookDistance;

	public float m_springStrength;

	public float m_minimumDistance;

	public float m_maxHookDistance;

	public float m_maxWindingSpeed;

	private float m_plungerResetTimer = 0.1f;

	private float m_plungerTimer;

	private enum State
	{
		WindedUp,
		Shoot,
		Winding,
		Rewind,
		Detach,
		Idle
	}
}
