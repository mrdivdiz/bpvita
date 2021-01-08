using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyParticleEffect : MonoBehaviour
{
	private void Awake()
	{
		this.hitAudioSources = new List<AudioSource>();
		this.flyAudioSources = new List<AudioSource>();
		this.originalMoveTargetSize = this.moveTarget.localScale;
	}

	private void OnDisable()
	{
		if (this.currencyParticles == null)
		{
			return;
		}
		for (int i = 0; i < this.currencyParticles.Count; i++)
		{
			if (this.currencyParticles[i].tf != null)
			{
				this.currencyParticles[i].Destroy();
			}
		}
		this.currencyParticles = null;
		this.targetCurrencyButton.UpdateAmount(false);
	}

	public void SetTarget(ICurrencyParticleEffectTarget softCurrencyButton)
	{
		this.targetCurrencyButton = softCurrencyButton;
	}

	public void AddParticle(Vector3 position, Vector3 velocity, float delay = 0f)
	{
		if (delay > 0.01f)
		{
			base.StartCoroutine(this.DelayAddParticle(position, velocity, delay));
			return;
		}
		if (this.particlePrefab == null)
		{
			return;
		}
		if (this.currencyParticles == null)
		{
			this.currencyParticles = new List<CurrencyParticle>();
		}
		position.z = this.moveTarget.position.z + 0.1f;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.particlePrefab, position, Quaternion.identity);
		this.currencyParticles.Add(new CurrencyParticle(gameObject.transform, velocity));
		base.StartCoroutine(this.DelayFlySound(0.1f));
	}

	private IEnumerator DelayFlySound(float delay)
	{
		yield return this.WaitForRealSeconds(delay);
		this.PlayRandomParticleFlySound();
		yield break;
	}

	public void AddParticle(Transform target, Vector3 velocity, float delay = 0f)
	{
		if (delay > 0.01f)
		{
			base.StartCoroutine(this.DelayAddParticle(target, velocity, delay));
			return;
		}
		this.AddParticle(target.position, velocity, 0f);
	}

	private IEnumerator DelayAddParticle(Vector3 position, Vector3 velocity, float delay)
	{
		yield return this.WaitForRealSeconds(delay);
		this.AddParticle(position, velocity, 0f);
		yield break;
	}

	private IEnumerator DelayAddParticle(Transform target, Vector3 velocity, float delay)
	{
		yield return this.WaitForRealSeconds(delay);
		if (target != null)
		{
			this.AddParticle(target.position, velocity, 0f);
		}
		yield break;
	}

	private void Update()
	{
		if (this.moveTarget == null)
		{
			return;
		}
		this.moveTarget.localScale = Vector3.Lerp(this.moveTarget.localScale, this.originalMoveTargetSize, GameTime.RealTimeDelta * 5f);
		if (this.currencyParticles == null)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < this.currencyParticles.Count; i++)
		{
			if (this.currencyParticles[i].tf != null)
			{
				Vector3 vector = this.moveTarget.position - this.currencyParticles[i].tf.position;
				float num2 = Vector3.Distance(this.currencyParticles[i].tf.position, this.moveTarget.position);
				float d = this.velocityCurve.Evaluate(this.currencyParticles[i].totalLifeTime);
				this.currencyParticles[i].velocity = Vector3.Lerp(this.currencyParticles[i].velocity, vector.normalized * d, GameTime.RealTimeDelta * 4f);
				this.currencyParticles[i].Update();
				if (num2 < 1f)
				{
					this.PlayRandomCurrencyHitSound();
					this.currencyParticles[i].Destroy();
					num++;
					this.targetCurrencyButton.CurrencyParticleAdded(1);
					this.moveTarget.localScale = this.originalMoveTargetSize * 1.3f;
					if (this.collectParticleEffect != null)
					{
						this.collectParticleEffect.Emit(5);
					}
				}
			}
			else
			{
				num++;
			}
		}
		if (num == this.currencyParticles.Count)
		{
			this.currencyParticles = null;
			this.targetCurrencyButton.UpdateAmount(false);
		}
	}

	private void PlayRandomCurrencyHitSound()
	{
		if (this.lastPlayedHitSound + this.hitSoundCooldown > Time.realtimeSinceStartup)
		{
			return;
		}
		this.lastPlayedHitSound = Time.realtimeSinceStartup;
		int num = 0;
		if (this.hitAudioSources.Count > 0)
		{
			for (int i = this.hitAudioSources.Count - 1; i >= 0; i--)
			{
				if (this.hitAudioSources[i] == null)
				{
					this.hitAudioSources.RemoveAt(i);
					i++;
					break;
				}
				num++;
			}
		}
		if (num < 5)
		{
			this.hitAudioSources.Add(this.PlayRandomSound(this.targetCurrencyButton.GetHitSounds()));
		}
	}

	private void PlayRandomParticleFlySound()
	{
		if (this.lastPlayedFlySound + this.flySoundCooldown > Time.realtimeSinceStartup)
		{
			return;
		}
		this.lastPlayedFlySound = Time.realtimeSinceStartup;
		int num = 0;
		if (this.flyAudioSources.Count > 0)
		{
			for (int i = this.flyAudioSources.Count - 1; i >= 0; i--)
			{
				if (this.flyAudioSources[i] == null)
				{
					this.flyAudioSources.RemoveAt(i);
					i++;
					break;
				}
				num++;
			}
		}
		if (num < 5)
		{
			this.flyAudioSources.Add(this.PlayRandomSound(this.targetCurrencyButton.GetFlySounds()));
		}
	}

	private AudioSource PlayRandomSound(AudioSource[] audioSources)
	{
		if (audioSources != null && audioSources.Length > 0)
		{
			int num = UnityEngine.Random.Range(0, audioSources.Length);
			return Singleton<AudioManager>.Instance.Play2dEffect(audioSources[num]);
		}
		return null;
	}

	private void OnDestroy()
	{
		if (this.currencyParticles == null)
		{
			return;
		}
		for (int i = 0; i < this.currencyParticles.Count; i++)
		{
			if (this.currencyParticles[i] != null && this.currencyParticles[i].tf != null)
			{
				UnityEngine.Object.Destroy(this.currencyParticles[i].tf.gameObject);
			}
		}
		this.currencyParticles = null;
	}

	private IEnumerator WaitForRealSeconds(float seconds)
	{
		float stopTime = Time.realtimeSinceStartup + seconds;
		while (stopTime > Time.realtimeSinceStartup)
		{
			yield return null;
		}
		yield break;
	}

	[SerializeField]
	private GameObject particlePrefab;

	[SerializeField]
	private Transform moveTarget;

	[SerializeField]
	private ParticleSystem collectParticleEffect;

	[SerializeField]
	private AnimationCurve velocityCurve;

	private List<CurrencyParticle> currencyParticles;

	private ICurrencyParticleEffectTarget targetCurrencyButton;

	private Vector3 originalMoveTargetSize = Vector3.one;

	private List<AudioSource> hitAudioSources;

	private List<AudioSource> flyAudioSources;

	private float hitSoundCooldown = 0.2f;

	private float lastPlayedHitSound;

	private float flySoundCooldown = 0.2f;

	private float lastPlayedFlySound;

	private class CurrencyParticle
	{
		public CurrencyParticle(Transform _tf, Vector3 _velocity)
		{
			this.tf = _tf;
			this.velocity = _velocity;
			this.totalLifeTime = 0f;
		}

		public void Update()
		{
			if (this.tf)
			{
				this.tf.position += this.velocity * GameTime.RealTimeDelta;
			}
			this.totalLifeTime += GameTime.RealTimeDelta;
		}

		public void Destroy()
		{
			UnityEngine.Object.Destroy(this.tf.gameObject);
		}

		public Transform tf;

		public Vector3 velocity;

		public float totalLifeTime;
	}
}
