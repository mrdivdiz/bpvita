using System;
using System.Collections;
using UnityEngine;

public class Pig : BasePart
{
	public bool CheckCameraLimits
	{
		get
		{
			return this.m_checkCameraLimits;
		}
		set
		{
			this.m_checkCameraLimits = value;
		}
	}

	public float rolledDistance
	{
		get
		{
			return this.m_rolledDistance;
		}
	}

	public float traveledDistance
	{
		get
		{
			return this.m_traveledDistance;
		}
	}

	public override bool IsIntegralPart()
	{
		return base.enclosedInto;
	}

	public override bool CanBeEnclosed()
	{
		return true;
	}

	public override void OnDetach()
	{
		base.rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
		this.m_detached = true;
		base.OnDetach();
	}

	public override void PostInitialize()
	{
		base.rigidbody.collisionDetectionMode = ((!(base.enclosedInto == null)) ? CollisionDetectionMode.Discrete : CollisionDetectionMode.Continuous);
		base.PostInitialize();
	}

	public override void Awake()
	{
		base.Awake();
		this.m_visualizationPart = base.transform.Find("PigVisualization").transform;
		this.m_faceRotation = this.m_visualizationPart.Find("Face").GetComponent<FaceRotation>();
		this.m_faceAnimation = base.GetComponentInChildren<SpriteAnimation>();
		this.m_pupilMover = this.m_visualizationPart.transform.Find("Face").Find("PupilMover");
		this.m_lookDirectionChangeTime = Time.time + UnityEngine.Random.Range(2f, 4f);
		this.m_lookAtDraggedPartDistance = UnityEngine.Random.Range(0f, 10f);
		this.m_stopTestTimer = 0f;
		this.m_replayPulseDone = false;
		this.m_chorusFilter = base.GetComponent<AudioChorusFilter>();
		this.m_distortionFilter = base.GetComponent<AudioDistortionFilter>();
		this.m_echoFilter = base.GetComponent<AudioEchoFilter>();
		this.m_hpFilter = base.GetComponent<AudioHighPassFilter>();
		this.m_lpFilter = base.GetComponent<AudioLowPassFilter>();
		this.m_reverbFilter = base.GetComponent<AudioReverbFilter>();
	}

	private void OnEnable()
	{
		EventManager.Connect<DraggingPartEvent>(new EventManager.OnEvent<DraggingPartEvent>(this.ReceiveDraggingPartEvent));
		EventManager.Connect<DragStartedEvent>(new EventManager.OnEvent<DragStartedEvent>(this.ReceiveDragStartedEvent));
		EventManager.Connect<PartPlacedEvent>(new EventManager.OnEvent<PartPlacedEvent>(this.ReceivePartPlacedEvent));
		EventManager.Connect<PartRemovedEvent>(new EventManager.OnEvent<PartRemovedEvent>(this.ReceivePartRemovedEvent));
		EventManager.Connect<ObjectiveAchieved>(new EventManager.OnEvent<ObjectiveAchieved>(this.ReceiveObjectiveAchieved));
		EventManager.Connect<UserInputEvent>(new EventManager.OnEvent<UserInputEvent>(this.ReceiveUserInputEvent));
		this.m_randomBehaviorActive = false;
	}

	private void OnDisable()
	{
		EventManager.Disconnect<DraggingPartEvent>(new EventManager.OnEvent<DraggingPartEvent>(this.ReceiveDraggingPartEvent));
		EventManager.Disconnect<DragStartedEvent>(new EventManager.OnEvent<DragStartedEvent>(this.ReceiveDragStartedEvent));
		EventManager.Disconnect<PartPlacedEvent>(new EventManager.OnEvent<PartPlacedEvent>(this.ReceivePartPlacedEvent));
		EventManager.Disconnect<PartRemovedEvent>(new EventManager.OnEvent<PartRemovedEvent>(this.ReceivePartRemovedEvent));
		EventManager.Disconnect<ObjectiveAchieved>(new EventManager.OnEvent<ObjectiveAchieved>(this.ReceiveObjectiveAchieved));
		EventManager.Disconnect<UserInputEvent>(new EventManager.OnEvent<UserInputEvent>(this.ReceiveUserInputEvent));
	}

	public override void EnsureRigidbody()
	{
		if (base.rigidbody == null)
		{
			base.rigidbody = base.gameObject.AddComponent<Rigidbody>();
		}
		base.rigidbody.constraints = (RigidbodyConstraints)56;
		base.rigidbody.mass = this.m_mass;
		base.rigidbody.drag = 0.2f;
		base.rigidbody.angularDrag = 0.05f;
		base.rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
		base.rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
	}

	private void OnDestroy()
	{
	}

	private void FixedUpdate()
	{
		if (!base.contraption || !base.contraption.IsRunning)
		{
			return;
		}
		float magnitude = base.rigidbody.velocity.magnitude;
		if (magnitude < 1f)
		{
			base.rigidbody.drag = 0.2f + 2.5f * (1f - magnitude);
			base.rigidbody.angularDrag = 0.2f + 2.5f * (1f - magnitude);
		}
		else
		{
			base.rigidbody.drag = 0.2f;
			base.rigidbody.angularDrag = 0.05f;
		}
	}

	public void PrepareForTNT(Vector3 tntPosition, float force)
	{
		if (Vector3.Distance(tntPosition, base.transform.position) > 1.5f)
		{
			return;
		}
		Joint component = base.GetComponent<Joint>();
		if (component && !base.contraption.HasSuperGlue)
		{
			UnityEngine.Object.Destroy(component);
			base.HandleJointBreak(force, true);
		}
		base.rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
	}

	private void Start()
	{
		this.m_traveledDistance = GameProgress.GetFloat("traveledDistance", 0f, GameProgress.Location.Local, null);
		this.m_rolledDistance = GameProgress.GetFloat("rolledDistance", 0f, GameProgress.Location.Local, null);
	}

	private void Update()
	{
		this.UpdateBuildModeAnimations();
		float x = 0.2f * Mathf.PerlinNoise(0.75f * Time.time, 0f) - 0.1f;
		float y = 0.2f * Mathf.PerlinNoise(0f, 0.75f * Time.time) - 0.1f;
		this.m_faceRotation.SetTargetDirection(this.m_lookDirection + new Vector2(x, y));
		this.m_blinkTimer -= Time.deltaTime;
		bool flag = false;
		if (this.m_blinkTimer <= 0f && this.m_currentExpression == Pig.Expressions.Normal)
		{
			this.m_faceAnimation.Play("Blink");
			if (this.m_playerIsDraggingPart)
			{
				this.m_pupilMover.transform.localPosition = 0.035f * this.m_lookTargetDirection;
			}
			else
			{
				this.m_pupilMover.transform.localPosition = 0.04f * UnityEngine.Random.insideUnitCircle;
			}
			this.m_blinkTimer = UnityEngine.Random.Range(1.5f, 4f);
			flag = true;
		}
		this.m_playerIsDraggingPart = false;
		if (!base.contraption || !base.contraption.IsRunning)
		{
			return;
		}
		if (base.enclosedInto == null)
		{
			this.m_rolledDistance += base.rigidbody.velocity.magnitude * Time.deltaTime;
		}
		else
		{
			this.m_traveledDistance += base.rigidbody.velocity.magnitude * Time.deltaTime;
		}
		this.m_currentMagnitude = base.rigidbody.velocity.magnitude;
		if (Mathf.Abs(this.m_currentMagnitude - this.m_previousMagnitude) > 5f && !this.m_isPlayingAnimation)
		{
			this.PlayAnimation(Pig.Expressions.Hit, 1f);
			this.starsLoop.Play();
			this.m_starsTimer = 4f;
			this.m_previousMagnitude = this.m_currentMagnitude;
			return;
		}
		this.m_previousMagnitude = this.m_currentMagnitude;
		if (!this.m_isPlayingAnimation)
		{
			Pig.Expressions expression = this.SelectExpression();
			if (!flag)
			{
				this.SetExpression(expression);
			}
		}
		if (!base.contraption.HasComponentEngine(base.ConnectedComponent) && base.contraption.HasPoweredPartsRunning(base.ConnectedComponent))
		{
			this.PlayWorkingAnimation();
			if (!this.sweatLoop.isPlaying)
			{
				this.sweatLoop.Play();
			}
		}
		else
		{
			if (this.sweatLoop.isPlaying)
			{
				this.sweatLoop.Stop();
			}
			if (this.m_visualizationPart.localScale.x > 1.001f || this.m_visualizationPart.localScale.y > 1.001f || this.m_visualizationPart.localPosition.y > 0.001f)
			{
				this.m_visualizationPart.localScale = 0.9f * this.m_visualizationPart.localScale + 0.1f * Vector3.one;
				this.m_visualizationPart.localPosition = 0.9f * this.m_visualizationPart.localPosition + 0.1f * Vector3.zero;
				this.m_workingTime = 0.5f;
			}
		}
		if (this.starsLoop.isPlaying)
		{
			if (this.m_starsTimer > 0f)
			{
				float num = this.m_starsTimer;
				if (this.m_starsTimer > 2f)
				{
					num *= 2f;
				}
				this.m_starsTimer -= Time.deltaTime;
			}
			else
			{
				this.starsLoop.Stop();
			}
		}
		if (!this.m_replayPulseDone && Singleton<GameManager>.Instance.IsInGame())
		{
			this.CheckStopped();
		}
		if (!this.m_faceZFlattened && !base.GetComponent<Joint>())
		{
			this.m_faceRotation.ScaleFaceZ(0.01f);
			this.m_faceZFlattened = true;
		}
	}

	private void CheckStopped()
	{
		if (WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.Running)
		{
			return;
		}
		Vector3 position = base.transform.position;
		if (Vector3.Distance(position, this.m_stopTestPosition) > 0.1f)
		{
			this.m_stopTestPosition = position;
			this.m_stopTestTimer = 0f;
		}
		else
		{
			this.m_stopTestTimer += Time.deltaTime;
			if (this.m_stopTestTimer > 5f)
			{
				EventManager.Send<PulseButtonEvent>(new PulseButtonEvent(UIEvent.Type.Building, true));
				this.m_replayPulseDone = true;
			}
		}
		if (this.m_checkCameraLimits)
		{
			LevelManager.CameraLimits currentCameraLimits = WPFMonoBehaviour.levelManager.CurrentCameraLimits;
			if (position.y < currentCameraLimits.topLeft.y - currentCameraLimits.size.y || position.x > currentCameraLimits.topLeft.x + currentCameraLimits.size.x * 1.1f || position.x < currentCameraLimits.topLeft.x - currentCameraLimits.size.x * 0.1f)
			{
				EventManager.Send<Pig.PigOutOfBounds>(new Pig.PigOutOfBounds());
			}
		}
	}

	private Pig.Expressions SelectExpression()
	{
		Vector3 velocity = base.rigidbody.velocity;
		Pig.Expressions result = Pig.Expressions.Normal;
		if (Time.time > this.m_expressionSetTime + 1f)
		{
			float num = velocity.magnitude + 0.3f * Mathf.Abs(velocity.y);
			if (num > this.speedFunThreshold)
			{
				result = Pig.Expressions.Grin;
			}
			if (num > 0.5f * (this.speedFunThreshold + this.speedFearThreshold))
			{
				result = Pig.Expressions.FearfulGrin;
			}
			if (num > this.speedFearThreshold)
			{
				result = Pig.Expressions.Fear;
			}
			if (Time.time - base.contraption.GetGroundTouchTime(base.ConnectedComponent) > 0.25f)
			{
				float num2 = -velocity.y;
				if (num2 > this.fallFearThreshold)
				{
					result = Pig.Expressions.Fear2;
				}
			}
		}
		else
		{
			result = this.m_currentExpression;
		}
		return result;
	}

	private void UpdateBuildModeAnimations()
	{
		if ((!Singleton<GameManager>.Instance.IsInGame() || WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.Building) && Singleton<GameManager>.Instance.GetGameState() != GameManager.GameState.KingPigFeeding)
		{
			this.m_randomBehaviorActive = false;
			return;
		}
		this.FollowPartDragging();
		this.m_funLevel *= Mathf.Pow(0.997f, Time.deltaTime / 0.0166666675f);
		this.m_fearLevel *= Mathf.Pow(0.999f, Time.deltaTime / 0.0166666675f);
		if (this.m_partRemoved)
		{
			this.m_partRemoved = false;
			GameData.PartReaction partReaction = WPFMonoBehaviour.gameData.GetPartReaction(this.m_removedPartType);
			if (partReaction != null)
			{
				this.m_funLevel -= partReaction.fun;
				this.m_fearLevel -= partReaction.fear;
				this.m_funLevel = Mathf.Clamp(this.m_funLevel, 0f, 100f);
				this.m_fearLevel = Mathf.Clamp(this.m_fearLevel, 0f, 100f);
			}
		}
		if (this.m_lookAtDraggedPart)
		{
			this.m_randomBehaviorActive = false;
			if (this.m_partPlaced)
			{
				this.m_partPlaced = false;
				GameData.PartReaction partReaction2 = WPFMonoBehaviour.gameData.GetPartReaction(this.m_placedPartType);
				if (partReaction2 != null)
				{
					this.m_funLevel += partReaction2.fun;
					this.m_fearLevel += partReaction2.fear;
					this.m_funLevel = Mathf.Clamp(this.m_funLevel, 0f, 100f);
					this.m_fearLevel = Mathf.Clamp(this.m_fearLevel, 0f, 100f);
				}
				if (this.m_fearLevel < 50f || partReaction2.fear == 0f)
				{
					if (UnityEngine.Random.Range(0f, 100f) < this.m_funLevel && this.m_expressionSetTime < Time.time - 3f)
					{
						this.PlayAnimation(Pig.Expressions.Laugh, 1.5f);
					}
				}
				else if (UnityEngine.Random.Range(0f, 100f) < this.m_fearLevel && this.m_expressionSetTime < Time.time - 3f)
				{
					this.PlayAnimation(Pig.Expressions.Fear, 1.5f);
				}
			}
		}
		else
		{
			if (!this.m_randomBehaviorActive)
			{
				this.m_randomBehaviorActive = true;
				this.m_randomLaughTime = Time.time + UnityEngine.Random.Range(5f, 9f);
			}
			if (Time.time >= this.m_randomLaughTime)
			{
				this.m_randomLaughTime = Time.time + UnityEngine.Random.Range(5f, 9f);
				if (this.m_expressionSetTime < Time.time - 3f)
				{
					this.PlayAnimation(Pig.Expressions.Laugh, 1.5f);
				}
			}
		}
	}

	private void FollowPartDragging()
	{
		if (!this.m_playerIsDraggingPart && this.m_partPlacementTime > Time.time - 1.5f)
		{
			this.m_playerIsDraggingPart = true;
			this.m_draggingPartPosition = this.m_partPlacementPosition;
		}
		if (this.m_playerIsDraggingPart)
		{
			if (!this.m_lookAtDraggedPart && this.m_lookAtDraggedPartTimer < 1f && Vector2.Distance(base.transform.position, this.m_draggingPartPosition) < this.m_lookAtDraggedPartDistance)
			{
				this.m_lookAtDraggedPart = true;
			}
		}
		else
		{
			this.m_lookAtDraggedPart = false;
		}
		if (this.m_lookAtDraggedPart)
		{
			this.m_lookAtDraggedPartTimer += Time.deltaTime;
			if (this.m_lookAtDraggedPartTimer > 8f)
			{
				this.m_faceAnimation.Play("Hit");
				this.m_blinkTimer = 0.2f;
				this.m_lookAtDraggedPart = false;
			}
			this.m_lookTargetDirection = this.m_draggingPartPosition - base.transform.position;
			if (this.m_lookTargetDirection.sqrMagnitude > 1f)
			{
				this.m_lookTargetDirection.Normalize();
			}
			Vector2 a = this.m_lookTargetDirection - this.m_lookDirection;
			this.m_lookDirection += 8f * Time.deltaTime * a;
		}
		else
		{
			if (this.m_lookAtDraggedPartTimer > 0f)
			{
				this.m_lookAtDraggedPartTimer -= Time.deltaTime;
			}
			if (Time.time > this.m_lookDirectionChangeTime)
			{
				this.m_lookDirectionChangeTime = Time.time + UnityEngine.Random.Range(2f, 4f);
				Vector2 insideUnitCircle = UnityEngine.Random.insideUnitCircle;
				if (Vector2.Distance(this.m_lookTargetDirection, insideUnitCircle) < 0.3f)
				{
					insideUnitCircle = UnityEngine.Random.insideUnitCircle;
				}
				this.m_lookTargetDirection = Mathf.Pow(insideUnitCircle.magnitude, 0.2f) * insideUnitCircle.normalized;
			}
			Vector2 a2 = this.m_lookTargetDirection - this.m_lookDirection;
			this.m_lookDirection += 2f * Time.deltaTime * a2;
		}
		if (this.m_playerIsDraggingPart)
		{
			Vector3 vector = 0.035f * this.m_lookTargetDirection;
			if (Vector3.Distance(this.m_pupilMover.transform.localPosition, vector) > 0.0105000008f)
			{
				Vector3 a3 = vector - this.m_pupilMover.transform.localPosition;
				this.m_pupilMover.transform.localPosition += 4f * Time.deltaTime * a3;
			}
		}
	}

	private void ReceiveUserInputEvent(UserInputEvent data)
	{
		EventManager.Send<PulseButtonEvent>(new PulseButtonEvent(UIEvent.Type.Building, false));
		this.m_stopTestTimer = 0f;
	}

	private void ReceiveDraggingPartEvent(DraggingPartEvent data)
	{
		this.m_playerIsDraggingPart = true;
		this.m_draggingPartPosition = data.position;
	}

	private void ReceiveDragStartedEvent(DragStartedEvent data)
	{
		this.m_lookAtDraggedPartDistance = UnityEngine.Random.Range(0f, 10f);
	}

	private void ReceivePartPlacedEvent(PartPlacedEvent data)
	{
		this.m_partPlacementTime = Time.time;
		this.m_partPlacementPosition = data.position;
		this.m_partPlaced = true;
		this.m_placedPartType = data.partType;
	}

	private void ReceivePartRemovedEvent(PartRemovedEvent data)
	{
		this.m_partRemoved = true;
		this.m_removedPartType = data.partType;
	}

	private void ReceiveObjectiveAchieved(ObjectiveAchieved data)
	{
		this.PlayAnimation(Pig.Expressions.Laugh, 3f);
	}

	public override void OnCollisionEnter(Collision collision)
	{
		base.OnCollisionEnter(collision);
		if (collision.relativeVelocity.magnitude > 2f)
		{
			this.collisionStars.Play();
		}
	}

	public void SetExpression(Pig.Expressions exp)
	{
		if (this.m_currentExpression != exp)
		{
			switch (exp)
			{
				case Pig.Expressions.Normal:
					this.m_faceAnimation.Play("Normal");
					break;
				case Pig.Expressions.Laugh:
					this.m_faceAnimation.Play("Laugh");
					break;
				case Pig.Expressions.Grin:
					this.m_faceAnimation.Play("Grin");
					break;
				case Pig.Expressions.Fear:
					this.m_faceAnimation.Play("Fear_1");
					break;
				case Pig.Expressions.Fear2:
					this.m_faceAnimation.Play("Fear_2");
					break;
				case Pig.Expressions.Hit:
					this.m_faceAnimation.Play("Hit");
					break;
				case Pig.Expressions.Blink:
					this.m_faceAnimation.Play("Blink");
					break;
				case Pig.Expressions.FearfulGrin:
					this.m_faceAnimation.Play("FearfulGrin");
					break;
			}
			if (Singleton<GameManager>.Instance.IsInGame() && WPFMonoBehaviour.levelManager != null && WPFMonoBehaviour.levelManager.gameState != LevelManager.GameState.Building)
			{
				AudioSource[] sound = this.m_expressions[(int)exp].sound;
				if (sound != null && sound.Length > 0)
				{
					for (int i = 0; i < sound.Length; i++)
					{
						sound[i].pitch = this.m_pitch;
					}
					if (this.m_currentSound)
					{
						this.m_currentSound.Stop();
					}
					this.m_currentSound = ((!this.m_isSilent) ? Singleton<AudioManager>.Instance.SpawnOneShotEffect(sound, base.transform) : null);
					if (this.m_chorusFilter)
					{
						AudioChorusFilter audioChorusFilter = this.m_currentSound.gameObject.AddComponent<AudioChorusFilter>();
						audioChorusFilter.dryMix = this.m_chorusFilter.dryMix;
						audioChorusFilter.wetMix1 = this.m_chorusFilter.wetMix1;
						audioChorusFilter.wetMix2 = this.m_chorusFilter.wetMix2;
						audioChorusFilter.wetMix3 = this.m_chorusFilter.wetMix3;
						audioChorusFilter.delay = this.m_chorusFilter.delay;
						audioChorusFilter.rate = this.m_chorusFilter.rate;
						audioChorusFilter.depth = this.m_chorusFilter.depth;
					}
					if (this.m_distortionFilter)
					{
						AudioDistortionFilter audioDistortionFilter = this.m_currentSound.gameObject.AddComponent<AudioDistortionFilter>();
						audioDistortionFilter.distortionLevel = this.m_distortionFilter.distortionLevel;
					}
					if (this.m_echoFilter)
					{
						AudioEchoFilter audioEchoFilter = this.m_currentSound.gameObject.AddComponent<AudioEchoFilter>();
						audioEchoFilter.delay = this.m_echoFilter.delay;
						audioEchoFilter.decayRatio = this.m_echoFilter.decayRatio;
						audioEchoFilter.wetMix = this.m_echoFilter.wetMix;
						audioEchoFilter.dryMix = this.m_echoFilter.dryMix;
					}
					if (this.m_hpFilter)
					{
						AudioHighPassFilter audioHighPassFilter = this.m_currentSound.gameObject.AddComponent<AudioHighPassFilter>();
						audioHighPassFilter.cutoffFrequency = this.m_hpFilter.cutoffFrequency;
						audioHighPassFilter.highpassResonanceQ = this.m_hpFilter.highpassResonanceQ;
					}
					if (this.m_lpFilter)
					{
						AudioLowPassFilter audioLowPassFilter = this.m_currentSound.gameObject.AddComponent<AudioLowPassFilter>();
						audioLowPassFilter.cutoffFrequency = this.m_lpFilter.cutoffFrequency;
						audioLowPassFilter.lowpassResonanceQ = this.m_lpFilter.lowpassResonanceQ;
					}
					if (this.m_reverbFilter)
					{
						AudioReverbFilter audioReverbFilter = this.m_currentSound.gameObject.AddComponent<AudioReverbFilter>();
						if (this.m_reverbFilter.reverbPreset == AudioReverbPreset.User)
						{
							audioReverbFilter.dryLevel = this.m_reverbFilter.dryLevel;
							audioReverbFilter.room = this.m_reverbFilter.room;
							audioReverbFilter.roomHF = this.m_reverbFilter.roomHF;
							audioReverbFilter.roomLF = this.m_reverbFilter.roomLF;
							audioReverbFilter.decayTime = this.m_reverbFilter.decayTime;
							audioReverbFilter.decayHFRatio = this.m_reverbFilter.decayHFRatio;
							audioReverbFilter.reflectionsLevel = this.m_reverbFilter.reflectionsLevel;
							audioReverbFilter.reflectionsDelay = this.m_reverbFilter.reflectionsDelay;
							audioReverbFilter.hfReference = this.m_reverbFilter.hfReference;
							audioReverbFilter.lfReference = this.m_reverbFilter.lfReference;
							audioReverbFilter.diffusion = this.m_reverbFilter.diffusion;
							audioReverbFilter.density = this.m_reverbFilter.density;
						}
						else
						{
							audioReverbFilter.reverbPreset = this.m_reverbFilter.reverbPreset;
						}
					}
				}
			}
			this.m_expressionSetTime = Time.time;
			this.m_currentExpression = exp;
		}
	}

	public void PlayAnimation(Pig.Expressions exp, float time)
	{
		base.StartCoroutine(this.AnimationCoroutine(exp, time));
	}

	private IEnumerator AnimationCoroutine(Pig.Expressions exp, float time)
	{
		this.m_isPlayingAnimation = true;
		this.SetExpression(exp);
		yield return new WaitForSeconds(time);
		this.SetExpression(Pig.Expressions.Normal);
		this.m_isPlayingAnimation = false;
		yield break;
	}

	private void PlayWorkingAnimation()
	{
		if (!this.m_detached)
		{
			this.m_workingTime += Time.deltaTime;
			this.m_visualizationPart.localScale = new Vector3(Mathf.PingPong(this.m_workingTime * 0.2f + 0.1f, 0.1f) + 1f, Mathf.PingPong(this.m_workingTime * 0.2f, 0.1f) + 0.9f, 1f);
			this.m_visualizationPart.localPosition = new Vector3(0f, -Mathf.PingPong(this.m_workingTime * 0.2f + 0.1f, 0.1f), 0f);
		}
	}

	protected override void OnTouch()
	{
		base.contraption.ActivateAllPoweredParts(base.ConnectedComponent);
	}

	public Pig.Expression[] m_expressions;

	public float fallFearThreshold;

	public float speedFunThreshold;

	public float speedFearThreshold;

	[HideInInspector]
	public Pig.Expressions m_currentExpression;

	public float m_expressionSetTime;

	private AudioSource m_currentSound;

	private float m_blinkTimer;

	private bool m_isPlayingAnimation;

	private Transform m_visualizationPart;

	private SpriteAnimation m_faceAnimation;

	private Transform m_pupilMover;

	public ParticleSystem collisionStars;

	public ParticleSystem sweatLoop;

	public ParticleSystem starsLoop;

	public bool m_isSilent;

	[Range(0f, 2f)]
	public float m_pitch = 1f;

	private float m_starsTimer;

	private float m_rolledDistance;

	private float m_traveledDistance;

	private FaceRotation m_faceRotation;

	private Vector2 m_lookDirection;

	private Vector2 m_lookTargetDirection;

	private float m_lookDirectionChangeTime;

	private bool m_playerIsDraggingPart;

	private Vector3 m_draggingPartPosition;

	private bool m_lookAtDraggedPart;

	private float m_lookAtDraggedPartDistance;

	private float m_lookAtDraggedPartTimer;

	private Vector3 m_partPlacementPosition;

	private float m_partPlacementTime;

	private bool m_partPlaced;

	private BasePart.PartType m_placedPartType;

	private bool m_partRemoved;

	private BasePart.PartType m_removedPartType;

	private float m_funLevel;

	private float m_fearLevel;

	private bool m_randomBehaviorActive;

	private float m_randomLaughTime;

	private Vector3 m_stopTestPosition;

	private float m_stopTestTimer;

	private bool m_replayPulseDone;

	private bool m_faceZFlattened;

	private float m_workingTime = 0.5f;

	private bool m_detached;

	private bool m_checkCameraLimits = true;

	private AudioChorusFilter m_chorusFilter;

	private AudioDistortionFilter m_distortionFilter;

	private AudioEchoFilter m_echoFilter;

	private AudioHighPassFilter m_hpFilter;

	private AudioLowPassFilter m_lpFilter;

	private AudioReverbFilter m_reverbFilter;

	private float m_currentMagnitude;

	private float m_previousMagnitude;

	public enum Expressions
	{
		Normal,
		Laugh,
		Grin,
		Fear,
		Fear2,
		Hit,
		Blink,
		FearfulGrin,
		Chew,
		WaitForFood,
		Burp,
		Snooze,
		Panting,
		MAX
	}

	[Serializable]
	public class Expression
	{
		public Pig.Expressions type;

		public Texture texture;

		public AudioSource[] sound;
	}

	public class PigOutOfBounds : EventManager.Event
	{
	}
}
