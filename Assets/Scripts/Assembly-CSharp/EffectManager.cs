using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
	private void Awake()
	{
		this.gameData = Singleton<GameManager>.Instance.gameData;
		this.m_snapSprite = UnityEngine.Object.Instantiate<GameObject>(this.gameData.m_snapSprite);
		this.m_snapSprite.GetComponent<Renderer>().enabled = false;
		this.m_krakSprite = UnityEngine.Object.Instantiate<GameObject>(this.gameData.m_krakSprite);
		this.m_krakSprite.GetComponent<Renderer>().enabled = false;
		this.m_bangSprite = UnityEngine.Object.Instantiate<GameObject>(this.gameData.m_bangSprite);
		this.m_bangSprite.GetComponent<Renderer>().enabled = false;
		this.m_particleValues = this.m_particles.Values.GetEnumerator();
	}

	private void Update()
	{
		this.m_particleValues.Reset();
		while (this.m_particleValues.MoveNext())
		{
			this.m_particleValues.Current.Update();
		}
	}

	public void CreateParticles(GameObject prefab, Vector3 position, bool force = false)
	{
		this.CreateParticles(prefab.GetComponent<ParticleSystem>(), position, force);
	}

	public void CreateParticles(ParticleSystem prefab, Vector3 position, bool force = false)
	{
        ParticleManager particleManager = this.GetParticleManager(prefab);
		particleManager.CreateParticles(position, force);
	}

	public void ShowBreakEffect(GameObject sprite, Vector3 position, Quaternion rotation)
	{
		if (sprite == this.gameData.m_snapSprite)
		{
			if (!this.m_snapSprite.GetComponent<Renderer>().enabled)
			{
				this.m_snapSprite.transform.position = position;
				this.m_snapSprite.transform.rotation = rotation;
				this.m_snapSprite.GetComponent<TimedHide>().Show();
			}
		}
		else if (sprite == this.gameData.m_krakSprite)
		{
			if (!this.m_krakSprite.GetComponent<Renderer>().enabled)
			{
				this.m_krakSprite.transform.position = position;
				this.m_krakSprite.transform.rotation = rotation;
				this.m_krakSprite.GetComponent<TimedHide>().Show();
			}
		}
		else if (sprite == this.gameData.m_bangSprite && !this.m_bangSprite.GetComponent<Renderer>().enabled)
		{
			this.m_bangSprite.transform.position = position;
			this.m_bangSprite.transform.rotation = rotation;
			this.m_bangSprite.GetComponent<TimedHide>().Show();
		}
	}

	private ParticleManager GetParticleManager(ParticleSystem prefab)
	{
        ParticleManager particleManager;
		if (this.m_particles.TryGetValue(prefab, out particleManager))
		{
			return particleManager;
		}
		particleManager = new ParticleManager(prefab, base.gameObject);
		this.m_particles[prefab] = particleManager;
		this.m_particleValues = this.m_particles.Values.GetEnumerator();
		return particleManager;
	}

	private GameObject m_snapSprite;

	private GameObject m_krakSprite;

	private GameObject m_bangSprite;

	private GameData gameData;

	private Dictionary<ParticleSystem, ParticleManager> m_particles = new Dictionary<ParticleSystem, ParticleManager>();

	private IEnumerator<ParticleManager> m_particleValues;

	private class ParticleManager
	{
		public ParticleManager(ParticleSystem prefab, GameObject parent)
		{
			this.m_parent = parent;
			this.m_prefab = prefab;
		}

		public void Update()
		{
			if (this.m_playing.Count > 0)
			{
				ParticleSystem particleSystem = this.m_playing.Peek();
				if (!particleSystem.isPlaying)
				{
					this.m_playing.Dequeue();
					this.m_stopped.Enqueue(particleSystem);
				}
			}
		}

		public void CreateParticles(Vector3 position, bool force = false)
		{
			if (this.m_stopped.Count > 0)
			{
				ParticleSystem particleSystem = this.m_stopped.Dequeue();
				particleSystem.transform.position = position;
				particleSystem.time = 0f;
				particleSystem.Play();
				this.m_playing.Enqueue(particleSystem);
			}
			else if (this.m_playing.Count < this.maxSystems || force)
			{
				ParticleSystem component = UnityEngine.Object.Instantiate<GameObject>(this.m_prefab.gameObject, position, Quaternion.identity).GetComponent<ParticleSystem>();
				component.transform.parent = this.m_parent.transform;
				this.m_playing.Enqueue(component);
			}
		}

		private GameObject m_parent;

		private int maxSystems = 5;

		private ParticleSystem m_prefab;

		private Queue<ParticleSystem> m_playing = new Queue<ParticleSystem>();

		private Queue<ParticleSystem> m_stopped = new Queue<ParticleSystem>();
	}
}
