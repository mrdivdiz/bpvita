using System;
using System.Collections;
using UnityEngine;

public class ExplodingGrapplingHookProjectile : WPFMonoBehaviour
{
	private void Start()
	{
		this.m_triggered = false;
		this.m_renderer = base.GetComponentInChildren<Renderer>();
		EventManager.Connect<UIEvent>(new EventManager.OnEvent<UIEvent>(this.OnUIEvent));
		this.m_forceDirection = base.transform.parent.TransformDirection(Vector3.right).normalized;
		base.rigidbody.AddForceAtPosition(this.m_forceDirection * this.m_force, Vector3.zero, ForceMode.Impulse);
		if (base.rigidbody == null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			base.StartCoroutine(this.TTL(this.m_ttl));
		}
	}

	private void OnDestroy()
	{
		EventManager.Disconnect<UIEvent>(new EventManager.OnEvent<UIEvent>(this.OnUIEvent));
	}

	private void OnCollisionEnter(Collision collision)
	{
		this.Explode();
	}

	private void FixedUpdate()
	{
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
			base.StartCoroutine(this.ShineLight());
			if (this.OnExplosion != null)
			{
				this.OnExplosion();
			}
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

	private IEnumerator ShineLight()
	{
		PointLightSource pls = base.GetComponentInChildren<PointLightSource>();
		if (pls)
		{
			if (this.m_renderer != null)
			{
				this.m_renderer.enabled = false;
			}
			PointLightSource pointLightSource = pls;
			pointLightSource.onLightTurnOff = (Action)Delegate.Combine(pointLightSource.onLightTurnOff, new Action(delegate()
			{
				base.gameObject.SetActive(false);
			}));
			pls.isEnabled = true;
			yield return new WaitForSeconds(pls.turnOnCurve[pls.turnOnCurve.length - 1].time);
			pls.isEnabled = false;
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		yield break;
	}

	private IEnumerator TTL(float ttl)
	{
		float current = 0f;
		while (current < ttl)
		{
			current += Time.deltaTime;
			yield return null;
		}
		this.Explode();
		yield break;
	}

	private void OnUIEvent(UIEvent data)
	{
		if (data.type == UIEvent.Type.Building)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public Action OnExplosion;

	[SerializeField]
	private float m_explosionImpulse;

	[SerializeField]
	private float m_explosionRadius;

	[SerializeField]
	private float m_force;

	[SerializeField]
	private float m_ttl;

	[SerializeField]
	private GameObject m_smokeCloud;

	private bool m_triggered;

	private Renderer m_renderer;

	private Vector3 m_forceDirection;
}
