using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : WPFMonoBehaviour
{
	private void Start()
	{
		if (this.useCustomParallax)
		{
			ParallaxManager.ParallaxCustomLayer pcl = default(ParallaxManager.ParallaxCustomLayer);
			pcl.layer = base.gameObject;
			pcl.speedX = 1f;
			ParallaxManager parallaxManager = UnityEngine.Object.FindObjectOfType(typeof(ParallaxManager)) as ParallaxManager;
			parallaxManager.RegisterParallaxLayer(pcl);
		}
		for (int i = 0; i < this.m_maxClouds; i++)
		{
			this.SpawnCloud();
		}
	}

	private void SpawnCloud()
	{
		Vector3 vector = new Vector3(UnityEngine.Random.Range(-this.m_cloudLimits, this.m_cloudLimits), UnityEngine.Random.Range(-this.m_height, this.m_height), UnityEngine.Random.Range(0f, this.m_farPlane));
		vector += base.transform.position;
		Transform original = this.m_cloudSet[UnityEngine.Random.Range(0, this.m_cloudSet.Count)];
		Transform transform = UnityEngine.Object.Instantiate<Transform>(original, vector, Quaternion.identity);
		CloudMover component = transform.GetComponent<CloudMover>();
		component.m_velocity = this.m_cloudVelocity;
		component.m_limits = this.m_cloudLimits;
		this.m_currentClouds.Add(transform);
		transform.parent = base.transform;
	}

	public void OnDrawGizmosSelected()
	{
		Color blue = Color.blue;
		blue.a = 0.2f;
		Gizmos.color = blue;
		Vector3 center = base.transform.position + Vector3.forward * this.m_farPlane * 0.5f;
		Vector3 size = new Vector3(this.m_cloudLimits * 2f, this.m_height * 2f, this.m_farPlane);
		Gizmos.DrawCube(center, size);
		Gizmos.color = Color.white;
		Gizmos.DrawWireCube(center, size);
	}

	public List<Transform> m_cloudSet = new List<Transform>();

	public int m_maxClouds = 10;

	public float m_cloudVelocity = 10f;

	public float m_cloudLimits = 1000f;

	public float m_farPlane = 100f;

	public float m_height = 100f;

	public bool useCustomParallax = true;

	protected List<Transform> m_currentClouds = new List<Transform>();
}
