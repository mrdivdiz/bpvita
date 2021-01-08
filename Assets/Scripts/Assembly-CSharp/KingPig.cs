using System.Collections;
using UnityEngine;

public class KingPig : BasePart
{
	public override void Awake()
	{
		base.Awake();
		this.m_currentExpression = Pig.Expressions.Normal;
		this.m_faceRotation = base.transform.Find("KingPig").Find("Face").GetComponent<FaceRotation>();
		this.m_pupilMover = this.m_faceRotation.transform.Find("PupilMover");
		this.m_faceAnimation = this.m_faceRotation.transform.Find("Face").GetComponent<SpriteAnimation>();
	}

	private void OnEnable()
	{
		EventManager.Connect<ObjectiveAchieved>(new EventManager.OnEvent<ObjectiveAchieved>(this.ReceiveObjectiveAchieved));
	}

	private void OnDisable()
	{
		EventManager.Disconnect<ObjectiveAchieved>(new EventManager.OnEvent<ObjectiveAchieved>(this.ReceiveObjectiveAchieved));
	}

	private void ReceiveObjectiveAchieved(ObjectiveAchieved data)
	{
		base.StartCoroutine(this.PlayAnimation(Pig.Expressions.Laugh, 2.5f));
	}

	public override bool CanBeEnclosed()
	{
		return true;
	}

	public override void Initialize()
	{
		base.rigidbody.drag = 0.5f;
		base.rigidbody.angularDrag = 1f;
	}

	public override void OnCollisionEnter(Collision collision)
	{
		base.OnCollisionEnter(collision);
		if (collision.relativeVelocity.magnitude >= 6f)
		{
			base.StartCoroutine(this.PlayAnimation(Pig.Expressions.Hit, 1f));
			//this.starsLoop.Play();
			this.m_starsTimer = 4f;
		}
		if (collision.relativeVelocity.magnitude > 4f)
		{
			//this.collisionStars.Play();
		}
		if (this.m_currentExpression == Pig.Expressions.Fear)
		{
			//this.collisionSweat.Play();
		}
	}

	public IEnumerator PlayAnimation(Pig.Expressions exp, float time)
	{
		this.m_isPlayingAnimation = true;
		this.SetExpression(exp);
		yield return new WaitForSeconds(time);
		this.m_isPlayingAnimation = false;
		yield break;
	}

	public IEnumerator PlayAnimation(Pig.Expressions exp)
	{
		string animName = this.ExpressionToAnimationName(exp);
		if (!string.IsNullOrEmpty(animName))
		{
			SpriteAnimation.Animation anim = this.m_faceAnimation.GetAnimation(animName);
			float time = anim.frames[anim.frames.Count - 1].endTime;
			this.m_isPlayingAnimation = true;
			this.SetExpression(exp);
			yield return new WaitForSeconds(time);
			this.m_isPlayingAnimation = false;
		}
		yield break;
	}

	private void Update()
	{
		if (this.m_faceRotation)
		{
			Vector3 targetDirection = Vector3.zero;
			if (this.followMouse)
			{
				Vector3 a;
				if (GameObject.FindGameObjectWithTag("MainCamera"))
				{
					a = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
				}
				else
				{
					a = GameObject.FindGameObjectWithTag("HUDCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
				}
				targetDirection = a - base.transform.position;
				targetDirection.z = 0f;
			}
			else
			{
				float num = Mathf.Pow(Mathf.Clamp(Mathf.PerlinNoise(0.6f * Time.time, -1.5234f), 0f, 1f), 1.5f);
				this.m_phase += num * Time.deltaTime;
				float num2 = Mathf.PerlinNoise(this.m_phase, 0.123f);
				float num3 = Mathf.PerlinNoise(this.m_phase, 5.9123f);
				targetDirection = new Vector3(2f * num2 - 1f, 2f * num3 - 1f, 0f);
				targetDirection = Mathf.Pow(targetDirection.magnitude, 1.2f) * targetDirection.normalized;
			}
			this.m_faceRotation.SetTargetDirection(targetDirection);
		}
		if (!this.m_isPlayingAnimation)
		{
			this.m_blinkTimer -= Time.deltaTime;
			bool flag = false;
			if (this.m_blinkTimer <= 0f && this.m_currentExpression == Pig.Expressions.Normal)
			{
				this.m_faceAnimation.Play("Blink");
				this.m_pupilMover.transform.localPosition = 0.05f * UnityEngine.Random.insideUnitCircle;
				this.m_blinkTimer = UnityEngine.Random.Range(2.5f, 5f);
				flag = true;
			}
			if (!base.contraption || !base.contraption.IsRunning)
			{
				return;
			}
			Pig.Expressions expression = this.SelectExpression();
			if (!flag)
			{
				this.SetExpression(expression);
			}
		}
		if (this.starsLoop.isPlaying)
		{
			if (this.m_starsTimer > 0f)
			{
				float num4 = this.m_starsTimer;
				if (this.m_starsTimer > 2f)
				{
					num4 *= 2f;
				}
				this.m_starsTimer -= Time.deltaTime;
			}
			else
			{
				this.starsLoop.Stop();
			}
		}
		if (!this.m_faceZFlattened && !base.GetComponent<Joint>())
		{
			this.m_faceRotation.ScaleFaceZ(0.01f);
			this.m_faceZFlattened = true;
		}
	}

	private Pig.Expressions SelectExpression()
	{
		Vector3 velocity = base.rigidbody.velocity;
		Pig.Expressions result = Pig.Expressions.Normal;
		if (Time.time > this.m_expressionSetTime + 1f)
		{
			float num = velocity.magnitude + 0.3f * Mathf.Abs(velocity.y);
			if (num > this.speedFearThreshold)
			{
				result = Pig.Expressions.Fear;
			}
			float num2 = -velocity.y;
			if (num2 > this.fallFearThreshold)
			{
				result = Pig.Expressions.Fear;
			}
		}
		else
		{
			result = this.m_currentExpression;
		}
		return result;
	}

	private string ExpressionToAnimationName(Pig.Expressions exp)
	{
		switch (exp)
		{
			case Pig.Expressions.Normal:
				return "Normal";
			case Pig.Expressions.Laugh:
				return "Laugh";
			case Pig.Expressions.Fear:
				return "Fear_1";
			case Pig.Expressions.Hit:
				return "Hit";
			case Pig.Expressions.Blink:
				return "Blink";
			case Pig.Expressions.Chew:
				return "Chew";
			case Pig.Expressions.WaitForFood:
				return "WaitForFood";
			case Pig.Expressions.Burp:
				return "Burp";
			case Pig.Expressions.Snooze:
				return "Snooze";
			case Pig.Expressions.Panting:
				return "Panting";
		}
		return null;
	}

	public void SetExpression(Pig.Expressions exp)
	{
		if (this.m_currentExpression != exp)
		{
			AudioSource[] array = null;
			switch (exp)
			{
				case Pig.Expressions.Fear:
					array = this.FearAudio;
					break;
				case Pig.Expressions.Hit:
					array = this.HitAudio;
					break;
			}
			string text = this.ExpressionToAnimationName(exp);
			if (!string.IsNullOrEmpty(text))
			{
				this.m_faceAnimation.Play(text);
			}
			if (array != null && array.Length > 0)
			{
				if (this.m_currentSound)
				{
					this.m_currentSound.Stop();
				}
				this.m_currentSound = Singleton<AudioManager>.Instance.SpawnOneShotEffect(array, base.transform);
			}
			this.m_expressionSetTime = Time.time;
			this.m_currentExpression = exp;
		}
	}

	private IEnumerator PlayEatingAnimationCoroutine(Pig.Expressions exp, float time, Pig.Expressions normalExpression)
	{
		this.m_isPlayingAnimation = true;
		this.SetExpression(exp);
		yield return new WaitForSeconds(time);
		this.m_isPlayingAnimation = false;
		this.SetExpression(normalExpression);
		yield break;
	}

	public void PlayEatingAnimation(Pig.Expressions expr, float time, Pig.Expressions normalExpression)
	{
		base.StartCoroutine(this.PlayEatingAnimationCoroutine(expr, 1f, normalExpression));
	}

	public ParticleSystem collisionStars;

	public ParticleSystem collisionSweat;

	public ParticleSystem sweatLoop;

	public ParticleSystem starsLoop;

	public float speedFearThreshold;

	public float fallFearThreshold;

	public bool followMouse;

	private float m_starsTimer;

	private float m_sweatTimer;

	private FaceRotation m_faceRotation;

	private Transform m_pupilMover;

	private float m_phase;

	public AudioSource[] FearAudio;

	public AudioSource[] HitAudio;

	[HideInInspector]
	public Pig.Expressions m_currentExpression;

	public float m_expressionSetTime;

	private SpriteAnimation m_faceAnimation;

	private float m_blinkTimer;

	private bool m_isPlayingAnimation;

	private AudioSource m_currentSound;

	private bool m_faceZFlattened;
}
