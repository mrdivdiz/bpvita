using System.Collections.Generic;
using UnityEngine;

public class SuperMagnet : WPFMonoBehaviour
{
	private void Start()
	{
		this.m_lastTimeCheckCollisions = 0f;
		this.m_collisions = new List<GameObject>(16);
		if (base.transform.Find(WPFMonoBehaviour.gameData.m_superMagnetEffect.name) == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_superMagnetEffect, base.transform.position, base.transform.rotation);
			gameObject.name = WPFMonoBehaviour.gameData.m_superMagnetEffect.name;
			gameObject.transform.parent = base.transform;
		}
	}

	private void OnDestroy()
	{
		Transform transform = base.transform.Find(WPFMonoBehaviour.gameData.m_superMagnetEffect.name);
		if (transform)
		{
			UnityEngine.Object.Destroy(transform.gameObject);
		}
	}

	private void Update()
	{
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Running && Time.time - this.m_lastTimeCheckCollisions > 0.5f)
		{
			Collider[] array = Physics.OverlapSphere(base.transform.position, this.m_radius);
			foreach (Collider collider in array)
			{
				if ((collider.GetComponent<OneTimeCollectable>() || collider.GetComponent<Collectable>()) && collider.GetComponent<SecretPlace>() == null && collider.GetComponent<SecretStatue>() == null && !this.m_collisions.Contains(collider.gameObject))
				{
					this.m_collisions.Add(collider.gameObject);
				}
			}
			this.m_lastTimeCheckCollisions = Time.time;
		}
	}

	private void FixedUpdate()
	{
		if (WPFMonoBehaviour.levelManager == null)
		{
			return;
		}
		if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Running && this.m_collisions != null)
		{
			for (int i = 0; i < this.m_collisions.Count; i++)
			{
				GameObject gameObject = this.m_collisions[i];
				if (!(gameObject == null))
				{
					Vector3 vector = base.transform.position - gameObject.transform.position;
					float num = Vector3.Distance(base.transform.position, gameObject.transform.position);
					float num2 = Mathf.Lerp(this.m_speedMax, this.m_speedMin, num / this.m_radius);
					gameObject.transform.position += Time.fixedDeltaTime * num2 * vector.normalized;
				}
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(base.transform.position, this.m_radius);
	}

	public float m_radius = 5f;

	public float m_speedMin = 3f;

	public float m_speedMax = 8f;

	private List<GameObject> m_collisions;

	private float m_lastTimeCheckCollisions;
}
