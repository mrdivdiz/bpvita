using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTNTBox : WPFMonoBehaviour
{
	private void OnCollisionEnter(Collision c)
	{
		float magnitude = c.relativeVelocity.magnitude;
		if (magnitude > this.m_triggerSpeed)
		{
			this.Explode();
		}
	}

	public void Explode()
	{
		if (!this.m_triggered)
		{
			this.m_triggered = true;
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
			base.StartCoroutine(this.ShineLight());
		}
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

	private IEnumerator ShineLight()
	{
		PointLightSource pls = base.GetComponentInChildren<PointLightSource>();
		if (pls)
		{
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

	public float m_explosionImpulse;

	public float m_explosionRadius;

	public float m_triggerSpeed;

	public GameObject m_smokeCloud;

	public GameObject m_explosionSpark;

	protected bool m_triggered;
}
