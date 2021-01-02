using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : BasePropulsion
{
	public override bool IsEnabled()
	{
		float num = Time.time - this.m_timeBoostStarted;
		return num < this.m_ignitionTime + this.m_boostDuration + this.m_boostEndDuration;
	}

	public override BasePart.Direction EffectDirection()
	{
		return BasePart.Rotate(BasePart.Direction.Right, this.m_gridRotation);
	}

	public override void Awake()
	{
		base.Awake();
		this.m_leftAttachment = base.transform.Find("LeftAttachment").gameObject;
		this.m_rightAttachment = base.transform.Find("RightAttachment").gameObject;
		this.m_topAttachment = base.transform.Find("TopAttachment").gameObject;
		this.m_bottomAttachment = base.transform.Find("BottomAttachment").gameObject;
		this.m_leftAttachment.SetActive(false);
		this.m_rightAttachment.SetActive(false);
		this.m_topAttachment.SetActive(false);
		this.m_bottomAttachment.SetActive(false);
		Transform transform = base.transform.Find("BottleVisualization");
		if (transform)
		{
			this.m_visualization = transform.gameObject;
		}
		this.m_origScale = base.transform.localScale;
		this.m_timeBoostStarted = -1000f;
		this.m_boostUsed = false;
		this.m_currentAlpha = 1f;
		this.m_currentAlpha2 = 1f;
		this.m_enabled = false;
		if (this.m_content2)
		{
			this.m_content2.material.color = new Color(0f, 0f, 0f, 0f);
		}
	}

	private void OnDestroy()
	{
		if (this.m_loopAudioObject)
		{
			Singleton<AudioManager>.Instance.StopLoopingEffect(this.m_loopAudioObject.GetComponent<AudioSource>());
			UnityEngine.Object.Destroy(this.m_loopAudioObject);
		}
	}

	public override void ChangeVisualConnections()
	{
		bool flag = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Up, this.m_gridRotation));
		bool flag2 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Down, this.m_gridRotation));
		bool flag3 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Left, this.m_gridRotation));
		bool flag4 = base.contraption.CanConnectTo(this, BasePart.Rotate(BasePart.Direction.Right, this.m_gridRotation));
		this.m_leftAttachment.SetActive(flag3);
		this.m_rightAttachment.SetActive(flag4);
		this.m_topAttachment.SetActive(flag);
		this.m_bottomAttachment.SetActive(flag2 || (!flag && !flag3 && !flag4));
		this.m_leftAttachment.GetComponent<BoxCollider>().isTrigger = !this.m_leftAttachment.activeInHierarchy;
		this.m_rightAttachment.GetComponent<BoxCollider>().isTrigger = !this.m_rightAttachment.activeInHierarchy;
		this.m_topAttachment.GetComponent<BoxCollider>().isTrigger = !this.m_topAttachment.activeInHierarchy;
		this.m_bottomAttachment.GetComponent<BoxCollider>().isTrigger = !this.m_bottomAttachment.activeInHierarchy;
	}

	public override BasePart.GridRotation AutoAlignRotation(BasePart.JointConnectionDirection target)
	{
		switch (target)
		{
		case BasePart.JointConnectionDirection.Right:
			return BasePart.GridRotation.Deg_90;
		case BasePart.JointConnectionDirection.Up:
			return BasePart.GridRotation.Deg_0;
		case BasePart.JointConnectionDirection.Left:
			return BasePart.GridRotation.Deg_90;
		case BasePart.JointConnectionDirection.Down:
			return BasePart.GridRotation.Deg_0;
		default:
			return BasePart.GridRotation.Deg_0;
		}
	}

	public override void Initialize()
	{
		base.contraption.ChangeOneShotPartAmount(this.m_partType, this.EffectDirection(), 1);
	}

	public void Update()
	{
		float num = Time.time - this.m_timeBoostStarted;
		if (this.m_boostUsed && this.m_content && this.m_currentAlpha > 0f)
		{
			this.m_currentAlpha -= Time.deltaTime;
			if (this.m_currentAlpha < 0f)
			{
				this.m_currentAlpha = 0f;
			}
			this.m_content.material.color = new Color(this.m_currentAlpha, this.m_currentAlpha, this.m_currentAlpha, this.m_currentAlpha);
			if (this.m_content2)
			{
				this.m_content2.material.color = new Color(1f - this.m_currentAlpha, 1f - this.m_currentAlpha, 1f - this.m_currentAlpha, 1f - this.m_currentAlpha);
			}
		}
		if (num < this.m_ignitionTime)
		{
			return;
		}
		if (this.m_boostUsed && this.m_content2 && this.m_currentAlpha2 > 0f)
		{
			this.m_currentAlpha2 -= Time.deltaTime;
			if (this.m_currentAlpha2 < 0f)
			{
				this.m_currentAlpha2 = 0f;
			}
			Color color = new Color(this.m_currentAlpha2, this.m_currentAlpha2, this.m_currentAlpha2, this.m_currentAlpha2);
			this.m_content2.material.color = color;
		}
	}

	public void FixedUpdate()
	{
		if (!this.m_enabled)
		{
			return;
		}
		float num = Time.time - this.m_timeBoostStarted;
		if (num < this.m_ignitionTime)
		{
			if (this.m_visualization)
			{
				this.m_visualization.transform.localPosition = UnityEngine.Random.insideUnitCircle * 0.1f;
			}
			return;
		}
		float num2 = 1f;
		if (num > this.m_ignitionTime)
		{
			if (this.m_boostUsed)
			{
				if (this.m_particlesIgnitionInstance && this.m_particlesIgnitionInstance.isPlaying)
				{
					this.m_particlesIgnitionInstance.Stop();
				}
				if (this.m_visualization)
				{
					Transform transform = this.m_visualization.transform.Find("Cork");
					if (transform)
					{
						transform.parent = base.transform.parent;
						transform.GetComponent<Cork>().Fly(-20f * base.transform.right, 200f, 0.75f);
					}
				}
			}
			if (num < this.m_ignitionTime + this.m_boostDuration + this.m_boostEndDuration)
			{
				if (!this.m_particlesFiringInstance.isPlaying)
				{
					this.m_particlesFiringInstance.Play();
				}
			}
			else if (this.m_particlesFiringInstance)
			{
				this.m_particlesFiringInstance.Stop();
			}
		}
		if (num > this.m_ignitionTime + this.m_boostDuration + this.m_boostEndDuration)
		{
			if (this.m_explodes)
			{
				this.Explode();
			}
			UnityEngine.Object.Destroy(this.m_particlesIgnitionInstance.gameObject);
			UnityEngine.Object.Destroy(this.m_particlesFiringInstance.gameObject);
			this.m_enabled = false;
		}
		if (num > this.m_ignitionTime + this.m_boostDuration)
		{
			num2 = 1f - (num - this.m_boostDuration - this.m_ignitionTime) / this.m_boostEndDuration;
		}
		float num3 = num2 * this.m_boostForce;
		Vector3 zero = Vector3.zero;
		Vector3 position = base.transform.position + zero * 0.5f;
		Vector3 vector = base.transform.TransformDirection(this.m_direction);
		num3 = this.LimitForceForSpeed(num3, vector);
		base.rigidbody.AddForceAtPosition(num3 * vector, position, ForceMode.Force);
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
		if (this.m_boostUsed)
		{
			return;
		}
		this.m_enabled = !this.m_enabled;
		this.m_particlesIgnitionInstance.Play();
		this.m_timeBoostStarted = Time.time;
		this.m_boostUsed = true;
		base.contraption.ChangeOneShotPartAmount(this.m_partType, this.EffectDirection(), -1);
		if (this.m_loopAudio != null)
		{
			float length;
			if (this.m_shakeAudio != null)
			{
				length = this.m_shakeAudio.clip.length;
				Singleton<AudioManager>.Instance.SpawnOneShotEffect(this.m_shakeAudio, base.transform);
			}
			else
			{
				length = this.m_launchAudio.clip.length;
			}
			base.StartCoroutine(CoroutineRunner.DelayActionSequence(delegate
			{
				this.m_loopAudioObject = Singleton<AudioManager>.Instance.SpawnLoopingEffect(this.m_loopAudio, base.transform);
				AudioSource loopAudioSource = this.m_loopAudioObject.GetComponent<AudioSource>();
				float originalVolume = loopAudioSource.volume;
				if (this.m_loopAudioTimeLimit > 0f)
				{
					base.StartCoroutine(CoroutineRunner.DeltaAction(this.m_loopAudioTimeLimit, false, delegate(float t)
					{
						loopAudioSource.volume = originalVolume * t;
					}));
				}
			}, length, false));
		}
		else
		{
			Singleton<AudioManager>.Instance.SpawnOneShotEffect(this.m_launchAudio, base.transform);
		}
		base.StartCoroutine(this.ShineRocketLight());
	}

	private IEnumerator ShineRocketLight()
	{
		this.pls = base.GetComponentInChildren<PointLightSource>();
		if (this.pls)
		{
			yield return new WaitForSeconds(this.m_ignitionTime);
			this.pls.isEnabled = true;
			yield return new WaitForSeconds(this.m_boostDuration + this.m_boostEndDuration);
			this.pls.isEnabled = false;
		}
		yield break;
	}

	public void Explode()
	{
		Collider[] array = Physics.OverlapSphere(base.transform.position, this.m_explosionRadius);
		foreach (Collider collider in array)
		{
			GameObject gameObject = this.FindParentWithRigidBody(collider.gameObject);
			if (gameObject != null)
			{
				int num = this.CountChildColliders(gameObject, 0);
				this.AddExplosionForce(gameObject, 1f / (float)num);
			}
			TNT component = collider.GetComponent<TNT>();
			if (component)
			{
				component.Explode();
			}
		}
		WPFMonoBehaviour.effectManager.CreateParticles(this.m_smokeCloud, base.transform.position - Vector3.forward * 12f, true);
		Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.tntExplosion, base.transform.position);
		this.CheckForTNTAchievement();
		base.renderer.enabled = false;
		base.StartCoroutine(this.ShineExplosionLight());
	}

	private GameObject FindParentWithRigidBody(GameObject obj)
	{
		if (obj.GetComponent<Rigidbody>())
		{
			return obj;
		}
		if (obj.transform.parent)
		{
			return this.FindParentWithRigidBody(obj.transform.parent.gameObject);
		}
		return null;
	}

	private int CountChildColliders(GameObject obj, int count)
	{
		if (obj.GetComponent<Collider>())
		{
			count++;
		}
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			count = this.CountChildColliders(obj.transform.GetChild(i).gameObject, count);
		}
		return count;
	}

	private void AddExplosionForce(GameObject target, float forceFactor)
	{
		Vector3 vector = target.transform.position - base.transform.position;
		float f = Mathf.Max(vector.magnitude, 1f);
		float num = forceFactor * this.m_explosionImpulse / Mathf.Pow(f, 1.5f);
		Rigidbody component = target.GetComponent<Rigidbody>();
		if (component.mass < 0.1f)
		{
			num *= component.mass;
		}
		else if (component.mass < 0.4f)
		{
			num *= component.mass / 0.4f;
		}
		component.AddForce(num * vector.normalized, ForceMode.Impulse);
	}

	public void CheckForTNTAchievement()
	{
		if (Singleton<SocialGameManager>.IsInstantiated())
		{
			int brokenTNTs = GameProgress.GetInt("Broken_TNTs", 0, GameProgress.Location.Local, null) + 1;
			GameProgress.SetInt("Broken_TNTs", brokenTNTs, GameProgress.Location.Local);
			List<string> list = new List<string>
			{
				"grp.BOOM_BOOM_III",
				"grp.BOOM_BOOM_II",
				"grp.BOOM_BOOM_I"
			};
			foreach (string achievementId in list)
			{
				Singleton<SocialGameManager>.Instance.TryReportAchievementProgress(achievementId, 100.0, (int limit) => brokenTNTs >= limit);
			}
		}
	}

	private IEnumerator ShineExplosionLight()
	{
		PointLightSource pls = base.GetComponentInChildren<PointLightSource>();
		if (pls)
		{
			pls.size = 4f;
			if (base.renderer)
			{
				base.renderer.enabled = false;
			}
			PointLightSource pointLightSource = pls;
			pointLightSource.onLightTurnOff = (Action)Delegate.Combine(pointLightSource.onLightTurnOff, new Action(delegate()
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}));
			pls.isEnabled = true;
			yield return new WaitForSeconds(pls.turnOnCurve[pls.turnOnCurve.length - 1].time);
			pls.isEnabled = false;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		yield break;
	}

	public Vector3 m_direction = Vector3.up;

	public bool m_enabled;

	public bool m_explodes;

	public float m_boostForce = 10f;

	public float m_ignitionTime = 1f;

	public float m_boostDuration = 2f;

	public float m_boostEndDuration = 0.5f;

	public float m_maximumSpeed;

	public float m_explosionImpulse;

	public float m_explosionRadius;

	public float m_loopAudioTimeLimit;

	public Transform m_particlesIgnition;

	public Transform m_particlesFiring;

	public Transform m_particlesSmoke;

	public AudioSource m_loopAudio;

	public AudioSource m_launchAudio;

	public AudioSource m_shakeAudio;

	public GameObject m_smokeCloud;

	protected bool m_boostUsed;

	protected Vector3 m_origScale;

	protected float m_timeBoostStarted;

	protected float m_currentScale;

	protected bool m_firedRocket;

	public ParticleSystem m_particlesIgnitionInstance;

	public ParticleSystem m_particlesFiringInstance;

	private GameObject m_leftAttachment;

	private GameObject m_rightAttachment;

	private GameObject m_topAttachment;

	private GameObject m_bottomAttachment;

	private GameObject m_visualization;

	private GameObject m_loopAudioObject;

	public Renderer m_content;

	public Renderer m_content2;

	private float m_currentAlpha;

	private float m_currentAlpha2;

	private PointLightSource pls;
}
