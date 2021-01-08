using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : WPFMonoBehaviour
{
	public BirdType GetBirdType()
	{
		return this.m_birdType;
	}

	public bool IsSleeping()
	{
		return this.m_state == Bird.State.Sleeping;
	}

	public float ColliderRadius
	{
		get
		{
			return this.m_colliderRadius;
		}
	}

	public bool IsDisturbed()
	{
		return this.m_state != Bird.State.KnockedOut && (this.m_state != Bird.State.Sleeping || this.m_disturbance >= 1f);
	}

	public float WakeUpProgress()
	{
		return Mathf.Pow(this.m_disturbance / 2.5f, 0.75f);
	}

	public bool IsAwake()
	{
		return this.m_state != Bird.State.Sleeping && this.m_state != Bird.State.KnockedOut;
	}

	public bool IsCollided()
	{
		return this.m_isCollided;
	}

	public bool IsAttacking()
	{
		return this.m_state == Bird.State.JumpToSlingshot || this.m_state == Bird.State.Aim || this.m_state == Bird.State.Shoot || this.m_state == Bird.State.Fly;
	}

	public void IgnoreCollisions(Collider targetCollider)
	{
		Physics.IgnoreCollision(base.collider, targetCollider);
		this.m_ignoredCollisions.Add(targetCollider);
	}

	private void OnCollisionEnter(Collision col)
	{
		bool flag = false;
		foreach (ContactPoint contactPoint in col.contacts)
		{
			if (contactPoint.otherCollider.tag == "Contraption")
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			this.m_contraptionHit = true;
			if (Singleton<SocialGameManager>.IsInstantiated() && !GameProgress.GetBool("bird_hit", false, GameProgress.Location.Local, null))
			{
				GameProgress.SetBool("bird_hit", true, GameProgress.Location.Local);
				Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.CANNON_FODDER", 100.0);
			}
		}
	}

	private void Start()
	{
		if (this.m_state != Bird.State.Sleeping)
		{
			return;
		}
		this.m_animation = base.GetComponent<AnimationHandler>();
		this.m_animation.Play("Sleep");
		GameObject[] array = GameObject.FindGameObjectsWithTag("Slingshot");
		this.m_slingshot = null;
		float num = float.MaxValue;
		foreach (GameObject gameObject in array)
		{
			float num2 = Vector3.Distance(gameObject.transform.position, base.transform.position);
			if (num2 < num)
			{
				num = num2;
				this.m_slingshot = gameObject.GetComponent<Slingshot>();
			}
		}
		if (this.m_slingshot)
		{
			this.m_slingshotRestPosition = this.m_slingshot.transform.position;
			this.m_slingshotRestPosition.y = this.m_slingshotRestPosition.y + 2.25f;
			this.m_distanceToSlingShot = num;
		}
		this.springConstant = this.m_relativeSlingForce * this.springConstant * base.rigidbody.mass / 4f;
		base.rigidbody.isKinematic = true;
		Vector3 position = base.transform.position;
		position.z = -0.2f;
		base.transform.position = position;
		this.m_faceRotation = base.transform.Find("Visualization").Find("Face").GetComponent<FaceRotation>();
		SphereCollider sphereCollider = base.collider as SphereCollider;
		if (sphereCollider)
		{
			this.m_colliderRadius = sphereCollider.radius;
		}
		this.m_alarm = base.transform.Find("Visualization/Alarm").gameObject;
		this.SetAlarmOn(false);
	}

	public void StartAfterSplit(Bird from)
	{
		this.SetState(Bird.State.Fly);
		base.rigidbody.isKinematic = false;
		this.m_animation = base.GetComponent<AnimationHandler>();
		this.m_animation.Play("Normal");
		this.m_splitDone = true;
		this.m_colliderRadius = from.ColliderRadius;
	}

	public void SetAlarmOn(bool on)
	{
		if (this.m_alarm == null)
		{
			this.m_alarm = base.transform.Find("Visualization/Alarm").gameObject;
		}
		this.m_alarm.SetActive(on);
		if (on)
		{
			this.m_alarmTimer = 0.5f;
		}
		else
		{
			this.m_alarmTimer = 0f;
		}
	}

	private void SetState(State state)
	{
		this.m_state = state;
		this.m_timer = 0f;
		State state2 = this.m_state;
		if (state2 != Bird.State.JumpToSlingshot)
		{
			if (state2 != Bird.State.Aim)
			{
				if (state2 == Bird.State.Fly)
				{
					this.m_speed = base.rigidbody.velocity.magnitude;
				}
			}
			else
			{
				this.m_previousTargetVelocity = this.m_target.rigidbody.velocity;
			}
		}
		else
		{
			this.JumpToSlingshotStart();
		}
	}

	private void FixedUpdate()
	{
		if (!WPFMonoBehaviour.levelManager || !WPFMonoBehaviour.levelManager.ContraptionRunning)
		{
			return;
		}
		if (!this.m_target)
		{
			this.m_target = WPFMonoBehaviour.levelManager.ContraptionRunning.FindPig();
		}
		switch (this.m_state)
		{
			case Bird.State.Sleeping:
				this.Sleeping();
				break;
			case Bird.State.Ready:
				this.Ready();
				break;
			case Bird.State.JumpToSlingshot:
				this.JumpToSlingshot();
				break;
			case Bird.State.Aim:
				this.Aim();
				break;
			case Bird.State.Shoot:
				this.Shoot();
				break;
			case Bird.State.Fly:
				this.Fly();
				break;
		}
	}

	private void Sleeping()
	{
		float noiseAtPosition = this.GetNoiseAtPosition(base.transform.position);
		float num = (!WPFMonoBehaviour.levelManager) ? 124.56f : WPFMonoBehaviour.levelManager.TimeElapsed;
		if (num > 1f)
		{
			if (noiseAtPosition > 0.5f)
			{
				this.m_disturbance += 1.5f * noiseAtPosition * Time.deltaTime;
			}
			else if (noiseAtPosition > 0.3f)
			{
				this.m_disturbance += 0.5f * noiseAtPosition * Time.deltaTime;
			}
			else
			{
				this.m_disturbance -= 2f * Time.deltaTime;
				this.m_disturbance = Mathf.Max(this.m_disturbance, 0f);
			}
		}
		if (this.m_disturbance < 1f)
		{
			if (this.m_waking)
			{
				this.m_animation.Play("Sleep");
				this.m_disturbance *= 0.5f;
			}
			this.m_waking = false;
		}
		else if (this.m_disturbance < 2.5f)
		{
			if (!this.m_waking)
			{
				this.m_animation.Play("Waking");
				EventManager.Send(new BirdWakeUpEvent(this));
			}
			this.m_waking = true;
		}
		else
		{
			this.SetState(Bird.State.Ready);
			this.m_animation.Play("Blink");
			this.SetAlarmOn(true);
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.birdWakeUp);
		}
	}

	private void Ready()
	{
		Vector3 vector = this.m_target.transform.position - this.m_slingshotRestPosition;
		this.m_faceRotation.SetTargetDirection(vector.normalized);
		if (this.m_alarmTimer > 0f)
		{
			this.m_alarmTimer -= Time.deltaTime;
			if (this.m_alarmTimer <= 0f)
			{
				this.SetAlarmOn(false);
			}
		}
		if (this.m_slingshot && this.m_slingshot.IsFree())
		{
			int layerMask = 1 << LayerMask.NameToLayer("Ground");
			RaycastHit raycastHit;
			if (!Physics.Raycast(this.m_slingshotRestPosition, vector.normalized, out raycastHit, vector.magnitude, layerMask))
			{
				this.m_timer += Time.deltaTime;
			}
			if (this.m_timer > 0.4f + 0.03f * this.m_distanceToSlingShot)
			{
				this.m_slingshot.StartShot();
				this.m_faceRotation.SetTargetDirection(Vector3.zero);
				this.SetState(Bird.State.JumpToSlingshot);
				base.StartCoroutine(this.PlayAnimation("Angry", 0.6f));
				this.SetAlarmOn(false);
			}
		}
	}

	private void JumpToSlingshotStart()
	{
		this.m_startPosition = base.transform.position;
	}

	private void JumpToSlingshot()
	{
		this.m_timer += Time.deltaTime;
		Vector3 vector = new Vector3(-29.46859f, -0.6941621f, 0f);
		Vector3 vector2 = new Vector3(-30.86662f, 2.937689f, 0f);
		AnimationState animationState = base.GetComponent<Animation>()["JumpToSlingshot"];
		animationState.enabled = true;
		animationState.time = this.m_timer;
		animationState.weight = 1f;
		base.GetComponent<Animation>().Sample();
		animationState.enabled = false;
		float num = (base.transform.position.x - vector.x) / (vector2.x - vector.x);
		float num2 = (base.transform.position.y - vector.y) / (vector2.y - vector.y);
		float x = this.m_startPosition.x + num * this.m_slingshotRestPosition.x - num * this.m_startPosition.x;
		float y = this.m_startPosition.y + num2 * this.m_slingshotRestPosition.y - num2 * this.m_startPosition.y;
		base.transform.position = new Vector3(x, y, -0.2f);
		if (this.m_timer >= animationState.length)
		{
			this.SetState(Bird.State.Aim);
		}
	}

	private float SimulateShot(Vector3 birdStartPosition, Vector3 targetPosition, Vector3 targetVelocity, Vector3 targetAcceleration)
	{
		birdStartPosition = 3.2f * birdStartPosition.normalized;
		Vector3 a = birdStartPosition;
		Vector3 lhs = -birdStartPosition;
		Vector3 a2 = Vector3.zero;
		float mass = base.rigidbody.mass;
		for (int i = 0; i < 1000; i++)
		{
			Vector3 a3 = -a;
			Vector3 normalized = a3.normalized;
			float num = Vector3.Dot(lhs, normalized);
			Vector3 a4 = this.springConstant * a3;
			a4.y += -9.81f * mass;
			a2 += a4 / mass * 0.02f;
			a += a2 * 0.02f;
			targetVelocity += targetAcceleration * 0.02f;
			targetPosition += targetVelocity * 0.02f;
			if (num <= 0f)
			{
				break;
			}
		}
		float num2 = (a - targetPosition).sqrMagnitude;
		bool flag = false;
		for (; ; )
		{
			Vector3 a5 = new Vector3(0f, -9.81f * mass, 0f);
			Vector3 b = -a2 * base.rigidbody.drag;
			a5 += b;
			a2 += a5 / mass * 0.02f;
			a += a2 * 0.02f;
			targetVelocity += targetAcceleration * 0.02f;
			targetPosition += targetVelocity * 0.02f;
			float sqrMagnitude = (a - targetPosition).sqrMagnitude;
			if (this.m_speedBoost > 0f && !flag && sqrMagnitude < 0.5f * targetPosition.sqrMagnitude)
			{
				flag = true;
				a2 = this.m_speedBoost * a2;
			}
			if (sqrMagnitude > num2)
			{
				break;
			}
			num2 = sqrMagnitude;
		}
		return Mathf.Sqrt(num2);
	}

	private Vector3 FindShot(Vector3 relativeTargetPosition, Vector3 targetVelocity, Vector3 targetAcceleration)
	{
		Vector3 result = Vector3.zero;
		Vector3 vector = -relativeTargetPosition.normalized;
		float num = Mathf.Atan2(vector.y, vector.x);
		Vector3 vector2 = 3.2f * new Vector3(Mathf.Cos(num), Mathf.Sin(num), 0f);
		float f = num + 0.04363323f;
		float num2 = num - 0.04363323f;
		Vector3 vector3 = 3.2f * new Vector3(Mathf.Cos(f), Mathf.Sin(f), 0f);
		Vector3 vector4 = 3.2f * new Vector3(Mathf.Cos(num2), Mathf.Sin(num2), 0f);
		float num3 = this.SimulateShot(vector3, relativeTargetPosition, targetVelocity, targetAcceleration);
		float num4 = this.SimulateShot(vector4, relativeTargetPosition, targetVelocity, targetAcceleration);
		float num5;
		float num6;
		if (num3 < num4)
		{
			num5 = num4;
			result = vector3;
			num = num2;
			num6 = 1f;
		}
		else
		{
			num5 = num3;
			result = vector4;
			num6 = -1f;
		}
		float num7 = 0.17453292f;
		for (int i = 0; i < 6; i++)
		{
			float num8 = num;
			num += num6 * num7;
			vector2 = 3.2f * new Vector3(Mathf.Cos(num), Mathf.Sin(num), 0f);
			float num9 = this.SimulateShot(vector2, relativeTargetPosition, targetVelocity, targetAcceleration);
			if (num9 < num5)
			{
				num5 = num9;
				result = vector2;
			}
			else
			{
				num = num8;
				num7 *= 0.5f;
				if (i < 5)
				{
					vector4 = 3.2f * new Vector3(Mathf.Cos(num + 0.1f * num7 * num6 * 0.0174532924f), Mathf.Sin(num + num6 * num7 * 0.0174532924f), 0f);
					float num10 = this.SimulateShot(vector4, relativeTargetPosition, targetVelocity, targetAcceleration);
					if (num10 > num5)
					{
						num6 = -num6;
					}
				}
			}
		}
		return result;
	}

	private void Aim()
	{
		this.m_timer += Time.deltaTime;
		float num = Mathf.Min(Mathf.Pow(this.m_timer * 17f, 0.5f), 3.5f);
		float num2 = Vector3.Distance(this.m_target.transform.position, base.transform.position);
		Vector3 position = this.m_target.transform.position;
		position.z = 0f;
		Vector3 velocity = this.m_target.rigidbody.velocity;
		Vector3 a = (velocity - this.m_previousTargetVelocity) / Time.deltaTime;
		this.m_targetAcceleration = 0.95f * this.m_targetAcceleration + 0.05f * a;
		this.m_previousTargetVelocity = velocity;
		float d = num2 / 35f;
		Vector3 a2 = this.m_target.transform.position + d * velocity;
		Vector3 vector = (a2 - base.transform.position).normalized;
		if (a2.x > base.transform.position.x && !this.m_flyingRight)
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x * -1f, base.transform.localScale.y, base.transform.localScale.z);
			this.m_flyingRight = true;
		}
		vector = -this.FindShot(position - this.m_slingshotRestPosition, velocity, 0.5f * this.m_targetAcceleration);
		vector = 0.2f * vector + 0.8f * this.m_lastAim;
		this.m_lastAim = vector;
		vector.Normalize();
		Vector3 position2 = this.m_slingshotRestPosition - num * vector;
		position2.z = -0.2f;
		base.transform.position = position2;
		if (num >= 3.499f)
		{
			this.m_shootDirection = vector;
			base.rigidbody.isKinematic = false;
			this.SetState(Bird.State.Shoot);
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.birdShot);
		}
		this.m_slingshot.SetDrawPosition(base.transform.position - this.m_slingshotRestPosition - 0.45f * vector);
	}

	private void Shoot()
	{
		Vector3 b = new Vector3(base.transform.position.x, base.transform.position.y, 0f);
		Vector3 a = this.m_slingshotRestPosition - b;
		Vector3 normalized = a.normalized;
		float num = Vector3.Dot(this.m_shootDirection, normalized);
		base.rigidbody.AddForce(this.springConstant * a, ForceMode.Force);
		if (num <= 0f)
		{
			this.SetState(Bird.State.Fly);
			this.m_slingshot.EndShot();
		}
		this.m_slingshot.SetDrawPosition(base.transform.position - this.m_slingshotRestPosition - 0.45f * normalized);
	}

	private void Fly()
	{
		float magnitude = base.rigidbody.velocity.magnitude;
		if (this.m_previousSpeed - magnitude > 5f)
		{
			this.m_animation.Play("Hit");
			this.m_isCollided = true;
		}
		this.m_previousSpeed = magnitude;
		if (this.m_speedBoost > 0f && !this.m_boosted)
		{
			Vector3 position = this.m_target.transform.position;
			if (Vector3.SqrMagnitude(base.transform.position - position) < 0.5f * Vector3.SqrMagnitude(this.m_slingshotRestPosition - position))
			{
				this.m_boosted = true;
				base.rigidbody.velocity = this.m_speedBoost * base.rigidbody.velocity;
			}
		}
		if (this.m_split > 0 && !this.m_splitDone)
		{
			Vector3 position2 = this.m_target.transform.position;
			if (Vector3.SqrMagnitude(base.transform.position - position2) < 0.5f * Vector3.SqrMagnitude(this.m_slingshotRestPosition - position2))
			{
				this.Split();
			}
		}
		SphereCollider sphereCollider = base.collider as SphereCollider;
		float num = 0.02f * base.rigidbody.velocity.magnitude;
		this.m_speed = 0.8f * this.m_speed + 0.2f * base.rigidbody.velocity.magnitude;
		if (this.m_speed < 0.75f && !this.m_collisionsRemoved)
		{
			base.gameObject.layer = LayerMask.NameToLayer("Bird");
			this.m_collisionsRemoved = true;
			this.SetState(Bird.State.KnockedOut);
			num = 0f;
			if (sphereCollider)
			{
				sphereCollider.radius = this.ColliderRadius;
			}
			foreach (Collider collider in this.m_ignoredCollisions)
			{
				Physics.IgnoreCollision(base.collider, collider, false);
			}
			if (Singleton<SocialGameManager>.IsInstantiated() && !this.m_contraptionHit && !GameProgress.GetBool("bird_evaded", false, GameProgress.Location.Local, null))
			{
				GameProgress.SetBool("bird_evaded", true, GameProgress.Location.Local);
				Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.NER_NER", 100.0);
			}
		}
		if (sphereCollider && this.m_state == Bird.State.Fly)
		{
			float radius = Mathf.Max(0.75f * num, this.m_colliderRadius);
			sphereCollider.radius = radius;
		}
	}

	private void Split()
	{
		this.m_splitDone = true;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(base.gameObject);
		Vector3 vector = base.rigidbody.velocity;
		Quaternion rotation = Quaternion.AngleAxis(7.5f, Vector3.forward);
		vector = rotation * vector;
		gameObject.GetComponent<Rigidbody>().velocity = vector;
		this.IgnoreCollisions(gameObject.GetComponent<Collider>());
		gameObject.GetComponent<Bird>().StartAfterSplit(this);
		gameObject.GetComponent<Bird>().SetAlarmOn(false);
		WPFMonoBehaviour.levelManager.AddTemporaryDynamicObject(gameObject);
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(base.gameObject);
		vector = base.rigidbody.velocity;
		rotation = Quaternion.AngleAxis(-7.5f, Vector3.forward);
		vector = rotation * vector;
		gameObject2.GetComponent<Rigidbody>().velocity = vector;
		this.IgnoreCollisions(gameObject2.GetComponent<Collider>());
		gameObject2.GetComponent<Bird>().StartAfterSplit(this);
		gameObject2.GetComponent<Bird>().SetAlarmOn(false);
		WPFMonoBehaviour.levelManager.AddTemporaryDynamicObject(gameObject2);
		gameObject.GetComponent<Bird>().IgnoreCollisions(gameObject2.GetComponent<Collider>());
	}

	private IEnumerator PlayAnimation(string name, float delay)
	{
		yield return new WaitForSeconds(delay);
		this.m_animation.Play(name);
		yield break;
	}

	public float GetNoiseAtPosition(Vector3 position)
	{
		AudioManager instance = Singleton<AudioManager>.Instance;
		float num = 0f;
		foreach (AudioSource audioSource in instance.GetActiveLoopingSounds())
		{
			if (audioSource)
			{
				num += this.ComputeNoiseLevel(audioSource, position);
			}
		}
		foreach (AudioSource audioSource2 in instance.GetActive3dOneShotSounds())
		{
			if (audioSource2)
			{
				num += this.ComputeNoiseLevel(audioSource2, position);
			}
		}
		return num;
	}

	private float ComputeNoiseLevel(AudioSource source, Vector3 position)
	{
		NoiseLevel component = source.GetComponent<NoiseLevel>();
		if (component && component.Level > 0f)
		{
			float num = Vector3.Distance(position, source.transform.position);
			float result = component.Level / (num + 0.1f);
			Vector3 position2 = source.transform.position;
			return result;
		}
		return 0f;
	}

	[SerializeField]
	private BirdType m_birdType;

	[SerializeField]
	private float m_relativeSlingForce = 1f;

	[SerializeField]
	private float m_speedBoost = 1f;

	[SerializeField]
	private int m_split;

	private AnimationHandler m_animation;

	private BasePart m_target;

	private State m_state;

	private float m_timer;

	private Vector3 m_lastAim;

	private Vector3 m_startPosition;

	private Slingshot m_slingshot;

	private Vector3 m_slingshotRestPosition;

	private Vector3 m_shootDirection;

	private Vector3 m_previousTargetVelocity;

	private Vector3 m_targetAcceleration;

	private float springConstant = 300f;

	private bool m_waking;

	private float m_disturbance;

	private FaceRotation m_faceRotation;

	private float m_speed;

	private bool m_collisionsRemoved;

	private float m_previousSpeed;

	private bool m_boosted;

	private bool m_splitDone;

	private const float m_zPosition = -0.2f;

	private float m_colliderRadius = 1f;

	private float m_distanceToSlingShot;

	private List<Collider> m_ignoredCollisions = new List<Collider>();

	private bool m_contraptionHit;

	private const float m_wake_up_threshold = 2.5f;

	private bool m_flyingRight;

	private GameObject m_alarm;

	private float m_alarmTimer;

	private bool m_isCollided;

	public enum BirdType
	{
		Red,
		Yellow,
		Blue
	}

	private enum State
	{
		Sleeping,
		Ready,
		JumpToSlingshot,
		Aim,
		Shoot,
		Fly,
		KnockedOut
	}
}
