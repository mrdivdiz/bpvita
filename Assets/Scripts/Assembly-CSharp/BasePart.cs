using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePart : WPFMonoBehaviour
{
	public bool VisibleOnPartListBeforeUnlocking
	{
		get
		{
			return CustomizationManager.IsPartUnlocked(this) || (this.craftable && this.lootCrateReward);
		}
	}

	public bool JointPreprocessing
	{
		get
		{
			return this.m_jointPreprocessing;
		}
	}

	public virtual Vector3 Position
	{
		get
		{
			return base.transform.position;
		}
	}

	public virtual BasePart.JointConnectionStrength GetJointConnectionStrength()
	{
		return this.m_jointConnectionStrength;
	}

	public static BasePart.PartType BaseType(BasePart.PartType type)
	{
		if (type == BasePart.PartType.Balloons2)
		{
			return BasePart.PartType.Balloon;
		}
		if (type == BasePart.PartType.Balloons3)
		{
			return BasePart.PartType.Balloon;
		}
		if (type == BasePart.PartType.Sandbag2)
		{
			return BasePart.PartType.Sandbag;
		}
		if (type != BasePart.PartType.Sandbag3)
		{
			return type;
		}
		return BasePart.PartType.Sandbag;
	}

	public AudioManager.AudioMaterial AudioMaterial
	{
		get
		{
			return this.audioMaterial;
		}
	}

	public Contraption contraption
	{
		get
		{
			return this.m_contraption;
		}
		set
		{
			this.m_contraption = value;
		}
	}

	public int ConnectedComponent
	{
		get
		{
			return this.m_connectedComponent;
		}
		set
		{
			this.m_connectedComponent = value;
		}
	}

	public int SearchConnectedComponent
	{
		get
		{
			return this.m_searchConnectedComponent;
		}
		set
		{
			this.m_searchConnectedComponent = value;
		}
	}

	public BasePart enclosedPart
	{
		get
		{
			return this.m_enclosedPart;
		}
		set
		{
			this.m_enclosedPart = value;
			if (value)
			{
				value.enclosedInto = this;
			}
		}
	}

	public BasePart enclosedInto
	{
		get
		{
			return this.m_enclosedInto;
		}
		set
		{
			this.m_enclosedInto = value;
		}
	}

	public Vector3 WindVelocity
	{
		get
		{
			return this.m_windVelocity;
		}
		set
		{
			this.m_windVelocity = value;
		}
	}

	public bool valid
	{
		get
		{
			return this.m_valid;
		}
		set
		{
			this.m_valid = value;
		}
	}

	public virtual void Awake()
	{
		this.m_valid = true;
		this.m_spriteManager = base.GetComponent<SpriteManager>();
		BasePart.m_groundLayer = LayerMask.NameToLayer("Ground");
		BasePart.m_iceGroundLayer = LayerMask.NameToLayer("IceGround");
	}

	public virtual void Initialize()
	{
	}

	public virtual void InitializeEngine()
	{
	}

	public virtual bool CanBeEnabled()
	{
		return false;
	}

	public virtual bool HasOnOffToggle()
	{
		return false;
	}

	public virtual bool IsEnabled()
	{
		return false;
	}

	public virtual void SetEnabled(bool enabled)
	{
	}

	public virtual bool IsPowered()
	{
		return this.m_powerConsumption > 0f;
	}

	public bool IsEngine()
	{
		return this.m_enginePower > 0f;
	}

	public virtual BasePart.Direction EffectDirection()
	{
		return BasePart.Direction.Right;
	}

	public virtual BasePart.GridRotation AutoAlignRotation(BasePart.JointConnectionDirection target)
	{
		if (this.m_jointConnectionDirection == BasePart.JointConnectionDirection.None)
		{
			return BasePart.RotationTo(this.m_customJointConnectionDirection, target);
		}
		return BasePart.RotationTo(this.m_jointConnectionDirection, target);
	}

	public bool HasTag(string tag)
	{
		return this.tags != null && this.tags.Contains(tag);
	}

	public bool IsFlipped()
	{
		return this.m_flipped;
	}

	public void SetFlipped(bool flipped)
	{
		this.m_flipped = flipped;
		if (this.m_flipped)
		{
			base.transform.localRotation = Quaternion.AngleAxis(180f, Vector3.up);
		}
		else
		{
			base.transform.localRotation = Quaternion.identity;
		}
		this.OnFlipped();
	}

	public static BasePart.Direction ConvertDirection(BasePart.JointConnectionDirection direction)
	{
		return (BasePart.Direction)(direction - 1);
	}

	public static bool IsDirection(BasePart.JointConnectionDirection direction)
	{
		return direction == BasePart.JointConnectionDirection.Left || direction == BasePart.JointConnectionDirection.Right || direction == BasePart.JointConnectionDirection.Up || direction == BasePart.JointConnectionDirection.Down;
	}

	public BasePart.JointConnectionDirection GetJointConnectionDirection()
	{
		return this.GlobalJointConnectionDirection(this.m_jointConnectionDirection);
	}

	public BasePart.JointConnectionDirection GetCustomJointConnectionDirection()
	{
		return this.GlobalJointConnectionDirection(this.m_customJointConnectionDirection);
	}

	public JointConnectionDirection GlobalJointConnectionDirection(JointConnectionDirection localDirection)
	{
		if (localDirection == BasePart.JointConnectionDirection.Any || localDirection == BasePart.JointConnectionDirection.None)
		{
			return localDirection;
		}
		JointConnectionDirection jointConnectionDirection = localDirection;
		if (localDirection == BasePart.JointConnectionDirection.LeftAndRight)
		{
			if (this.m_gridRotation == BasePart.GridRotation.Deg_90 || this.m_gridRotation == BasePart.GridRotation.Deg_270)
			{
				jointConnectionDirection = BasePart.JointConnectionDirection.UpAndDown;
			}
		}
		else if (localDirection == BasePart.JointConnectionDirection.UpAndDown)
		{
			if (this.m_gridRotation == BasePart.GridRotation.Deg_90 || this.m_gridRotation == BasePart.GridRotation.Deg_270)
			{
				jointConnectionDirection = BasePart.JointConnectionDirection.LeftAndRight;
			}
		}
		else
		{
			jointConnectionDirection = (JointConnectionDirection)(((int)(localDirection - 1) + (int)m_gridRotation) % 4 + 1);
		}
		if (this.m_flipped)
		{
			if (jointConnectionDirection == BasePart.JointConnectionDirection.Left)
			{
				return BasePart.JointConnectionDirection.Right;
			}
			if (jointConnectionDirection == BasePart.JointConnectionDirection.Right)
			{
				return BasePart.JointConnectionDirection.Left;
			}
		}
		return jointConnectionDirection;
	}

	public static BasePart.Direction InverseDirection(BasePart.Direction direction)
	{
		switch (direction)
		{
			case BasePart.Direction.Right:
				return BasePart.Direction.Left;
			case BasePart.Direction.Up:
				return BasePart.Direction.Down;
			case BasePart.Direction.Left:
				return BasePart.Direction.Right;
			case BasePart.Direction.Down:
				return BasePart.Direction.Up;
			default:
				return BasePart.Direction.Right;
		}
	}

	public bool CanConnectTo(BasePart.Direction direction)
	{
		switch (this.GetJointConnectionDirection())
		{
			case BasePart.JointConnectionDirection.Any:
				return true;
			case BasePart.JointConnectionDirection.Right:
				return direction == BasePart.Direction.Right;
			case BasePart.JointConnectionDirection.Up:
				return direction == BasePart.Direction.Up;
			case BasePart.JointConnectionDirection.Left:
				return direction == BasePart.Direction.Left;
			case BasePart.JointConnectionDirection.Down:
				return direction == BasePart.Direction.Down;
			case BasePart.JointConnectionDirection.LeftAndRight:
				return direction == BasePart.Direction.Left || direction == BasePart.Direction.Right;
			case BasePart.JointConnectionDirection.UpAndDown:
				return direction == BasePart.Direction.Up || direction == BasePart.Direction.Down;
			case BasePart.JointConnectionDirection.None:
				return false;
			default:
				return false;
		}
	}

	public bool CanCustomConnectTo(BasePart.Direction direction)
	{
		switch (this.GetCustomJointConnectionDirection())
		{
			case BasePart.JointConnectionDirection.Any:
				return true;
			case BasePart.JointConnectionDirection.Right:
				return direction == BasePart.Direction.Right;
			case BasePart.JointConnectionDirection.Up:
				return direction == BasePart.Direction.Up;
			case BasePart.JointConnectionDirection.Left:
				return direction == BasePart.Direction.Left;
			case BasePart.JointConnectionDirection.Down:
				return direction == BasePart.Direction.Down;
			case BasePart.JointConnectionDirection.LeftAndRight:
				return direction == BasePart.Direction.Left || direction == BasePart.Direction.Right;
			case BasePart.JointConnectionDirection.UpAndDown:
				return direction == BasePart.Direction.Up || direction == BasePart.Direction.Down;
			case BasePart.JointConnectionDirection.None:
				return false;
			default:
				return false;
		}
	}

	public static Direction Rotate(Direction direction, GridRotation rotation)
	{
		return (Direction)(((int)direction + (int)rotation) % 4);
	}

	public static Direction RotateWithEightDirections(Direction direction, GridRotation rotation)
	{
		return (Direction)(((int)direction + (int)rotation) % 8);
	}

	public static GridRotation RotationTo(JointConnectionDirection source, JointConnectionDirection target)
	{
		if (source == BasePart.JointConnectionDirection.Any || target == BasePart.JointConnectionDirection.Any || source == BasePart.JointConnectionDirection.None || target == BasePart.JointConnectionDirection.None)
		{
			return BasePart.GridRotation.Deg_0;
		}
		if (source == BasePart.JointConnectionDirection.LeftAndRight)
		{
			if (target == BasePart.JointConnectionDirection.UpAndDown || target == BasePart.JointConnectionDirection.Up || target == BasePart.JointConnectionDirection.Down)
			{
				return BasePart.GridRotation.Deg_90;
			}
			return BasePart.GridRotation.Deg_0;
		}
		else
		{
			if (source != BasePart.JointConnectionDirection.UpAndDown)
			{
				int num = target - source;
				return (GridRotation)((num + 4) % 4);
			}
			if (target == BasePart.JointConnectionDirection.LeftAndRight || target == BasePart.JointConnectionDirection.Left || target == BasePart.JointConnectionDirection.Right)
			{
				return BasePart.GridRotation.Deg_90;
			}
			return BasePart.GridRotation.Deg_0;
		}
	}

	public float GetRotationAngle(BasePart.GridRotation rotation)
	{
		switch (rotation)
		{
			case BasePart.GridRotation.Deg_0:
				return 0f;
			case BasePart.GridRotation.Deg_90:
				return 90f;
			case BasePart.GridRotation.Deg_180:
				return 180f;
			case BasePart.GridRotation.Deg_270:
				return 270f;
			case BasePart.GridRotation.Deg_45:
				return 45f;
			case BasePart.GridRotation.Deg_135:
				return 135f;
			case BasePart.GridRotation.Deg_225:
				return 225f;
			case BasePart.GridRotation.Deg_315:
				return 315f;
			default:
				return 0f;
		}
	}

	public virtual void SetRotation(BasePart.GridRotation rotation)
	{
		this.m_gridRotation = rotation;
		base.transform.localRotation = Quaternion.AngleAxis(this.GetRotationAngle(rotation), Vector3.forward);
	}

	public void RotateClockwise()
	{
		switch (this.m_gridRotation)
		{
			case BasePart.GridRotation.Deg_0:
				if (!this.m_eightWay)
				{
					this.SetRotation(BasePart.GridRotation.Deg_270);
				}
				else
				{
					this.SetRotation(BasePart.GridRotation.Deg_315);
				}
				break;
			case BasePart.GridRotation.Deg_90:
				if (!this.m_eightWay)
				{
					this.SetRotation(BasePart.GridRotation.Deg_0);
				}
				else
				{
					this.SetRotation(BasePart.GridRotation.Deg_45);
				}
				break;
			case BasePart.GridRotation.Deg_180:
				if (!this.m_eightWay)
				{
					this.SetRotation(BasePart.GridRotation.Deg_90);
				}
				else
				{
					this.SetRotation(BasePart.GridRotation.Deg_135);
				}
				break;
			case BasePart.GridRotation.Deg_270:
				if (!this.m_eightWay)
				{
					this.SetRotation(BasePart.GridRotation.Deg_180);
				}
				else
				{
					this.SetRotation(BasePart.GridRotation.Deg_225);
				}
				break;
			case BasePart.GridRotation.Deg_45:
				this.SetRotation(BasePart.GridRotation.Deg_0);
				break;
			case BasePart.GridRotation.Deg_135:
				this.SetRotation(BasePart.GridRotation.Deg_90);
				break;
			case BasePart.GridRotation.Deg_225:
				this.SetRotation(BasePart.GridRotation.Deg_180);
				break;
			case BasePart.GridRotation.Deg_315:
				this.SetRotation(BasePart.GridRotation.Deg_270);
				break;
		}
	}

	public virtual bool IsInInteractiveRadius(Vector3 position)
	{
		Vector3 position2 = base.transform.position - base.rigidbody.velocity * Time.deltaTime;
		position2.z = 0f;
		return Vector3.Distance(position2, position) <= this.m_interactiveRadius;
	}

	public void ProcessTouch()
	{
		if (!WPFMonoBehaviour.levelManager || WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Running)
		{
			this.OnTouch();
			this.OnTouch(false, Vector3.zero);
		}
	}

	public void ProcessTouch(Vector3 touchPosition)
	{
		if (!WPFMonoBehaviour.levelManager || WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Running)
		{
			this.OnTouch();
			this.OnTouch(true, touchPosition);
		}
	}

	protected virtual void OnTouch()
	{
	}

	protected virtual void OnTouch(bool hasPosition, Vector3 touchPosition)
	{
	}

	public virtual void OnCollisionEnter(Collision c)
	{
		BasePart component = c.collider.GetComponent<BasePart>();
		if ((c.gameObject.layer == BasePart.m_groundLayer || c.gameObject.CompareTag("Ground")) && this.contraption.IsConnectedToPig(this, base.collider))
		{
			this.m_lastTimeTouchedGround = Time.time;
			this.contraption.SetTouchingGround(true);
		}
		if (c.gameObject.layer == BasePart.m_groundLayer || c.gameObject.CompareTag("Ground"))
		{
			this.m_isOnGround = true;
		}
		if (component && component.ConnectedComponent == this.ConnectedComponent)
		{
			return;
		}
		this.m_isOnIce = c.gameObject.CompareTag("IceSurface");
		this.PlayCollisionAudio(this, c);
		if (Time.time - BasePart.m_lastTimeUsedCollisionParticles > 0.25f)
		{
			int num = c.contacts.Length;
			for (int i = 0; i < num; i++)
			{
				ContactPoint contactPoint = c.contacts[i];
				if (contactPoint.otherCollider.CompareTag("Untagged") && base.rigidbody)
				{
					BasePart.m_lastTimeUsedCollisionParticles = Time.time;
					WPFMonoBehaviour.effectManager.CreateParticles(WPFMonoBehaviour.gameData.m_dustParticles, base.transform.position - Vector3.forward, false);
					float num2 = Vector3.Dot(base.rigidbody.GetPointVelocity(contactPoint.point), contactPoint.normal);
					if (this.m_breakVelocity > 0f && num2 > this.m_breakVelocity && !this.m_broken)
					{
						this.OnBreak();
						this.m_broken = true;
					}
					break;
				}
			}
		}
	}

	public virtual void OnCollisionStay(Collision c)
	{
		if (c.gameObject.layer == BasePart.m_groundLayer || c.gameObject.layer == BasePart.m_iceGroundLayer)
		{
			this.m_lastTimeTouchedGround = Time.time;
			this.m_contraption.SetGroundTouchTime(this);
		}
	}

	public virtual void OnCollisionExit(Collision c)
	{
		if (c.gameObject.layer == BasePart.m_iceGroundLayer)
		{
			this.m_isOnIce = false;
		}
		if (c.gameObject.layer == BasePart.m_groundLayer || c.gameObject.CompareTag("Ground"))
		{
			this.m_isOnGround = false;
		}
	}

	protected void LateUpdate()
	{
		this.UpdateSoundEffect();
	}

	public void PlayCollisionAudio(BasePart collisionPart, Collision collisionData)
	{
		if (collisionData.relativeVelocity.magnitude < 2.5f)
		{
			return;
		}
		AudioSource[] array = null;
		AudioSource[] array2 = null;
		AudioManager.AudioMaterial audioMaterial = collisionPart.AudioMaterial;
		if (audioMaterial != AudioManager.AudioMaterial.Metal)
		{
			if (audioMaterial != AudioManager.AudioMaterial.Wood)
			{
				array = null;
				array2 = null;
			}
			else
			{
				array = WPFMonoBehaviour.gameData.commonAudioCollection.collisionWoodHit;
				array2 = WPFMonoBehaviour.gameData.commonAudioCollection.collisionWoodDamage;
			}
		}
		else
		{
			array = WPFMonoBehaviour.gameData.commonAudioCollection.collisionMetalHit;
			array2 = WPFMonoBehaviour.gameData.commonAudioCollection.collisionMetalDamage;
		}
		float num = 1f;
		if (this is GoldenPig)
		{
			array = WPFMonoBehaviour.gameData.commonAudioCollection.goldenPigHit;
			array2 = array;
			num = 1.5f;
		}
		if (array != null && array2 != null)
		{
			float num2 = 0f;
			Vector3 soundPosition = Vector3.zero;
			IEnumerator enumerator = collisionData.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					ContactPoint contactPoint = (ContactPoint)obj;
					float num3 = Vector3.Dot(collisionData.relativeVelocity, contactPoint.normal);
					if (num3 > num2)
					{
						num2 = num3 * num;
						soundPosition = contactPoint.point;
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			if (num2 > 8f)
			{
				//Singleton<AudioManager>.Instance.SpawnOneShotEffect(array2, soundPosition);
			}
			else if (num2 > 2.5f)
			{
				//AudioSource audioSource = Singleton<AudioManager>.Instance.SpawnOneShotEffect(array, soundPosition);
				//if (audioSource)
				//{
					//audioSource.volume = (num2 - 2f) / 8f;
				//}
			}
		}
	}

	public void PlayBreakAudio(BasePart breakingPart)
	{
		AudioManager.AudioMaterial audioMaterial = breakingPart.AudioMaterial;
		AudioSource[] array;
		if (audioMaterial != AudioManager.AudioMaterial.Metal)
		{
			if (audioMaterial != AudioManager.AudioMaterial.Wood)
			{
				array = null;
			}
			else
			{
				array = null;//WPFMonoBehaviour.gameData.commonAudioCollection.collisionWoodDestroy;
			}
		}
		else
		{
			array = null;//WPFMonoBehaviour.gameData.commonAudioCollection.collisionMetalBreak;
		}
		if (array != null)
		{
			//Singleton<AudioManager>.Instance.SpawnOneShotEffect(array, breakingPart.transform.position);
		}
	}

	public virtual void PostInitialize()
	{
		this.AddShineEffect();
	}

	public virtual void PrePlaced()
	{
		for (int i = 0; i < this.tags.Count; i++)
		{
			if (this.tags[i] == "Alien_part")
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_alienPartParticles);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localPosition = Vector3.back * 0.1f;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.GetComponent<ParticleSystem>().startDelay = UnityEngine.Random.Range(0f, 2f);
			}
		}
		if (WPFMonoBehaviour.levelManager != null && WPFMonoBehaviour.levelManager.CurrentGameMode is CakeRaceMode && Singleton<CakeRaceKingsFavorite>.Instance.CurrentFavorite.m_partType == this.m_partType && Singleton<CakeRaceKingsFavorite>.Instance.CurrentFavorite.m_partTier == this.m_partTier)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_heartParticles);
			gameObject2.transform.parent = base.transform;
			gameObject2.transform.localPosition = Vector3.back;
			gameObject2.transform.localRotation = Quaternion.identity;
		}
	}

	private void AddShineEffect()
	{
		if (WPFMonoBehaviour.levelManager != null && this.HasTag("Gold"))
		{
			SpriteShineEffect.AddOneTimeShine(base.gameObject);
		}
	}

	public static Vector3 GetDirectionVector(BasePart.Direction direction)
	{
		switch (direction)
		{
			case BasePart.Direction.Right:
				return Vector3.right;
			case BasePart.Direction.Up:
				return Vector3.up;
			case BasePart.Direction.Left:
				return -Vector3.right;
			case BasePart.Direction.Down:
				return -Vector3.up;
			default:
				return Vector3.up;
		}
	}

	public virtual bool IsIntegralPart()
	{
		return true;
	}

	public virtual bool CanEncloseParts()
	{
		return false;
	}

	public virtual bool CanBeEnclosed()
	{
		return false;
	}

	public virtual bool IsPartOfChassis()
	{
		return false;
	}

	public virtual BasePart.JointConnectionType GetJointConnectionType()
	{
		return this.m_jointConnectionType;
	}

	public virtual bool ValidatePart()
	{
		return true;
	}

	public virtual void EnsureRigidbody()
	{
		if (base.rigidbody == null)
		{
			base.rigidbody = base.gameObject.AddComponent<Rigidbody>();
		}
		base.rigidbody.constraints = (RigidbodyConstraints)56;
		base.rigidbody.mass = this.m_mass;
		base.rigidbody.drag = 0.2f;
		base.rigidbody.angularDrag = 0.05f;
		base.rigidbody.useGravity = true;
		base.rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
		if (base.gameObject.layer == LayerMask.NameToLayer("Default") || base.gameObject.layer == LayerMask.NameToLayer("Contraption"))
		{
			base.gameObject.layer = LayerMask.NameToLayer("Contraption");
			for (int i = 0; i < base.transform.childCount; i++)
			{
				base.transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer("Contraption");
			}
		}
	}

	public virtual Joint CustomConnectToPart(BasePart part)
	{
		return null;
	}

	public virtual void OnChangeConnections()
	{
		if (this.m_jointConnectionDirection != BasePart.JointConnectionDirection.Any && this.m_jointConnectionDirection != BasePart.JointConnectionDirection.None && !this.contraption.CanConnectTo(this, this.GetJointConnectionDirection()))
		{
			this.contraption.AutoAlign(this);
		}
		this.ChangeVisualConnections();
	}

	public virtual void ChangeVisualConnections()
	{
	}

	public void OnEnclosedPartDetached()
	{
	}

	public virtual void OnDetach()
	{
	}

	protected virtual void OnJointBreak(float breakForce)
	{
		this.HandleJointBreak(breakForce, true);
	}

	protected virtual void OnFlipped()
	{
	}

	public void HandleJointBreak(float breakForce, bool playEffects = true)
	{
		this.CheckForBrokenPartsAchievement();
		this.contraption.m_jointDetached |= 2;
		if (playEffects)
		{
			this.PlayBreakAudio(this);
			Vector3 position = base.transform.position;
			Vector3 normalized = base.rigidbody.velocity.normalized;
			GameObject sprite = (this.m_partType != BasePart.PartType.WoodenFrame && this.m_partType != BasePart.PartType.Pig) ? WPFMonoBehaviour.gameData.m_snapSprite : WPFMonoBehaviour.gameData.m_krakSprite;
			WPFMonoBehaviour.effectManager.ShowBreakEffect(sprite, position - 2f * normalized + new Vector3(0f, 0f, -10f), Quaternion.AngleAxis(UnityEngine.Random.Range(-30f, 30f), Vector3.forward));
		}
	}

	public virtual void OnBreak()
	{
	}

	protected virtual void UpdateSoundEffect()
	{
		if (!base.rigidbody)
		{
			return;
		}
		float num = Mathf.Abs(base.rigidbody.velocity.magnitude);
		float num2 = 1f;
		float num3 = 10f;
		if (this.m_isOnIce && num > num2)
		{
			if (!this.m_slidingSound)
			{
				this.SpawnSlidingSound();
			}
			if (this.m_slidingSound)
			{
				this.m_slidingSound.volume = 0.25f * (Mathf.Clamp(num, num2, num3) / num3);
			}
		}
		else if (this.m_slidingSound)
		{
			if (Time.time - this.m_lastTimeTouchedGround < 0.4f)
			{
				this.m_slidingSound.volume = 0.25f * Mathf.Clamp01(1f - (Time.time - this.m_lastTimeTouchedGround) / 0.3f);
			}
			else
			{
				this.m_slidingSound.volume = 0f;
			}
		}
	}

	private void SpawnSlidingSound()
	{
		if (this.m_slidingSound)
		{
			this.m_slidingSound.Stop();
		}
		this.m_slidingSound = Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.partSlideOnIceLoop, base.transform);
		if (this.m_slidingSound)
		{
			this.m_slidingSound.volume = 0f;
		}
	}

	public void CheckForBrokenPartsAchievement()
	{
		if (Singleton<SocialGameManager>.IsInstantiated() && Singleton<GameManager>.Instance.IsInGame())
		{
			int brokenParts = GameProgress.GetInt("Broken_Parts", 0, GameProgress.Location.Local, null) + 1;
			GameProgress.SetInt("Broken_Parts", brokenParts, GameProgress.Location.Local);
			Action<List<string>> action = delegate (List<string> achievements)
			{
				foreach (string achievementId in achievements)
				{
					if (Singleton<SocialGameManager>.Instance.TryReportAchievementProgress(achievementId, 100.0, (int limit) => brokenParts >= limit))
					{
						break;
					}
				}
			};
			action(new List<string>
			{
				"grp.VETERAN_WRECKER",
				"grp.QUALIFIED_WRECKER",
				"grp.JUNIOR_WRECKER"
			});
		}
	}

	public string GetAnalyticsName()
	{
		return base.name;
	}

	private static float m_lastTimeUsedCollisionParticles;

	protected static int m_groundLayer = -1;

	protected static int m_iceGroundLayer = -1;

	protected bool m_isOnGround;

	[SerializeField]
	private bool m_jointPreprocessing;

	public bool m_eightWay;

	public int m_coordX;

	public int m_coordY;

	public float m_mass = 1f;

	public float m_interactiveRadius = 0.5f;

	public float m_breakVelocity;

	public float m_powerConsumption;

	public float m_enginePower;

	public float m_ZOffset;

	public int customPartIndex;

	public bool craftable = true;

	public bool lootCrateReward = true;

	public List<string> tags;

	private float m_lastTimeTouchedGround;

	private bool m_isOnIce;

	private AudioSource m_slidingSound;

	[SerializeField]
	private AudioManager.AudioMaterial audioMaterial;

	public BasePart.JointType m_jointType;

	public BasePart.PartTier m_partTier;

	public BasePart.PartType m_partType;

	public BasePart.AutoAlignType m_autoAlign;

	public bool m_flipped;

	public BasePart.GridRotation m_gridRotation;

	public int m_gridXmin;

	public int m_gridXmax;

	public int m_gridYmin;

	public int m_gridYmax;

	public bool m_static;

	public BasePart.JointConnectionStrength m_jointConnectionStrength;

	public BasePart.JointConnectionType m_jointConnectionType = BasePart.JointConnectionType.Target;

	public BasePart.JointConnectionDirection m_jointConnectionDirection;

	public BasePart.JointConnectionDirection m_customJointConnectionDirection = BasePart.JointConnectionDirection.None;

	private Contraption m_contraption;

	private bool m_broken;

	private int m_connectedComponent = -1;

	private int m_searchConnectedComponent = -1;

	public BasePart m_enclosedPart;

	public BasePart m_enclosedInto;

	public global::Sprite m_constructionIconSprite;

	protected bool m_valid;

	protected SpriteManager m_spriteManager;

	private Vector3 m_windVelocity;

	public enum JointType
	{
		FixedJoint,
		HingeJoint
	}

	public enum PartTier
	{
		Regular,
		Common,
		Rare,
		Epic,
		Legendary
	}

	public enum PartType
	{
		Unknown,
		Balloon,
		Balloons2,
		Balloons3,
		Fan,
		WoodenFrame,
		Bellows,
		CartWheel,
		Basket,
		Sandbag,
		Pig,
		Sandbag2,
		Sandbag3,
		Propeller,
		Wings,
		Tailplane,
		Engine,
		Rocket,
		MetalFrame,
		SmallWheel,
		MetalWing,
		MetalTail,
		Rotor,
		MotorWheel,
		TNT,
		EngineSmall,
		EngineBig,
		NormalWheel,
		Spring,
		Umbrella,
		Rope,
		CokeBottle,
		KingPig,
		RedRocket,
		SodaBottle,
		PoweredUmbrella,
		Egg,
		JetEngine,
		ObsoleteWheel,
		SpringBoxingGlove,
		StickyWheel,
		GrapplingHook,
		Pumpkin,
		Kicker,
		Gearbox,
		GoldenPig,
		PointLight,
		SpotLight,
		TimeBomb,
		MAX
	}

	public enum AutoAlignType
	{
		None,
		Rotate,
		FlipVertically
	}

	public enum Direction
	{
		Right,
		Up,
		Left,
		Down,
		UpRight,
		UpLeft,
		DownLeft,
		DownRight
	}

	public enum GridRotation
	{
		Deg_0,
		Deg_90,
		Deg_180,
		Deg_270,
		Deg_45,
		Deg_135,
		Deg_225,
		Deg_315,
		Deg_Max
	}

	public enum JointConnectionType
	{
		None,
		Source,
		Target
	}

	public enum JointConnectionDirection
	{
		Any,
		Right,
		Up,
		Left,
		Down,
		LeftAndRight,
		UpAndDown,
		None
	}

	public enum JointConnectionStrength
	{
		Weak,
		Normal,
		High,
		Extreme,
		HighlyExtreme
	}
}
