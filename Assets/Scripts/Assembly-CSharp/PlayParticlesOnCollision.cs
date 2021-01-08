using System.Collections.Generic;
using UnityEngine;

public class PlayParticlesOnCollision : WPFMonoBehaviour
{
	public bool Enabled
	{
		get
		{
			return this.m_enabled;
		}
		set
		{
			this.m_LastPlayTime = 0f;
			this.m_enabled = value;
		}
	}

	private bool HandleContactPoint(ContactPoint cp, Collision coll)
	{
		bool result = false;
		if ((this.m_CollisionLayerMask.value & 1 << cp.otherCollider.gameObject.layer) != 0)
		{
			if (Time.time - this.m_LastPlayTime >= this.m_Timeout && coll.relativeVelocity.magnitude > this.m_MinRelativeSpeed)
			{
				Vector3 point = cp.point;
				point.z += this.m_ZOffset;
				using (List<Action>.Enumerator enumerator = this.m_ActionList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						switch (enumerator.Current)
						{
						case PlayParticlesOnCollision.Action.PlayByEffectManager:
							WPFMonoBehaviour.effectManager.CreateParticles(this.m_ParticlesPrefab, point, false);
							break;
						case PlayParticlesOnCollision.Action.ShowEffectByEffectManager:
							WPFMonoBehaviour.effectManager.ShowBreakEffect(this.m_ParticlesPrefab, point, Quaternion.identity);
							break;
						case PlayParticlesOnCollision.Action.PlayParticleSystem:
							this.m_ParticlesPrefab.GetComponent<ParticleSystem>().Play();
							break;
						case PlayParticlesOnCollision.Action.Instantinate:
							UnityEngine.Object.Instantiate<GameObject>(this.m_ParticlesPrefab, point, Quaternion.identity);
							break;
						case PlayParticlesOnCollision.Action.SpawnAudioOneShotEffect:
							if (this.m_AudioOneShotEffect)
							{
								Singleton<AudioManager>.Instance.SpawnOneShotEffect(this.m_AudioOneShotEffect, point);
							}
							break;
						}
					}
				}
				this.m_LastPlayTime = Time.time;
			}
			result = !this.m_PlayOnEachContact;
		}
		return result;
	}

	private void HandleCollisionEvent(CollisionEvent collEvent, Collision coll)
	{
		if (this.m_enabled && this.m_CollisionEvent == collEvent)
		{
			foreach (ContactPoint cp in coll.contacts)
			{
				if (this.HandleContactPoint(cp, coll))
				{
					break;
				}
			}
		}
	}

	public void OnCollisionEnter(Collision coll)
	{
		this.HandleCollisionEvent(PlayParticlesOnCollision.CollisionEvent.Enter, coll);
	}

	public void OnCollisionStay(Collision coll)
	{
		this.HandleCollisionEvent(PlayParticlesOnCollision.CollisionEvent.Stay, coll);
	}

	public void OnCollisionExit(Collision coll)
	{
		this.HandleCollisionEvent(PlayParticlesOnCollision.CollisionEvent.Exit, coll);
	}

	private bool m_enabled = true;

	private float m_LastPlayTime;

	public List<Action> m_ActionList = new List<Action>();

	public GameObject m_ParticlesPrefab;

	public AudioSource m_AudioOneShotEffect;

	public LayerMask m_CollisionLayerMask;

	public float m_Timeout;

	public bool m_PlayOnEachContact;

	public CollisionEvent m_CollisionEvent;

	public float m_MinRelativeSpeed;

	public float m_ZOffset;

	public enum CollisionEvent
	{
		Enter,
		Stay,
		Exit
	}

	public enum Action
	{
		PlayByEffectManager,
		ShowEffectByEffectManager,
		PlayParticleSystem,
		Instantinate,
		SpawnAudioOneShotEffect
	}
}
