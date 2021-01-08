using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
	private void Start()
	{
		this.m_backgroundLayerFurther = GameObject.FindGameObjectsWithTag("ParallaxLayerFurther");
		this.m_backgroundLayerFar = GameObject.FindGameObjectsWithTag("ParallaxLayerFar");
		this.m_backgroundLayerNear = GameObject.FindGameObjectsWithTag("ParallaxLayerNear");
		this.m_backgroundLayerSky = GameObject.FindGameObjectsWithTag("ParallaxLayerSky");
		this.m_backgroundLayerFixedFollowCamera = GameObject.FindGameObjectsWithTag("ParallaxLayerFixedFollowCamera");
		int num = GameObject.FindGameObjectsWithTag("ParallaxLayerForeground").Length;
		this.m_backgroundLayerForeground = GameObject.FindGameObjectsWithTag("ParallaxLayerForeground");
		foreach (GameObject gameObject in this.m_backgroundLayerForeground)
		{
			gameObject.AddComponent<BaseTransform>();
		}
		foreach (GameObject gameObject2 in this.m_backgroundLayerFar)
		{
			gameObject2.AddComponent<BaseTransform>();
		}
		foreach (GameObject gameObject3 in this.m_backgroundLayerNear)
		{
			gameObject3.AddComponent<BaseTransform>();
		}
		foreach (GameObject gameObject4 in this.m_backgroundLayerFurther)
		{
			gameObject4.AddComponent<BaseTransform>();
		}
		foreach (GameObject gameObject5 in this.m_backgroundLayerSky)
		{
			gameObject5.AddComponent<BaseTransform>();
		}
		foreach (GameObject gameObject6 in this.m_backgroundLayerFixedFollowCamera)
		{
			gameObject6.AddComponent<BaseTransform>();
		}
		foreach (ParallaxCustomLayer parallaxCustomLayer in this.m_miscellanousLayer)
		{
			parallaxCustomLayer.layer.AddComponent<BaseTransform>();
		}
		if (num > 0)
		{
			this.m_fgLimitY = this.m_backgroundLayerForeground[0].transform.position.y;
		}
		this.m_oldPosition = base.transform.position;
	}

	private void SetHorizontalPosition(GameObject[] objects, float scale)
	{
		foreach (GameObject gameObject in objects)
		{
			Vector3 position = gameObject.transform.position;
			position.x = gameObject.GetComponent<BaseTransform>().position.x + this.m_offset.x * scale;
			gameObject.transform.position = position;
		}
	}

	private void Update()
	{
		float num = base.transform.position.x - this.m_oldPosition.x;
		float num2 = base.transform.position.y - this.m_oldPosition.y;
		this.m_offset.x = this.m_offset.x + num;
		if (num != 0f)
		{
			this.SetHorizontalPosition(this.m_backgroundLayerForeground, -0.4f);
			this.SetHorizontalPosition(this.m_backgroundLayerFurther, 0.7f);
			this.SetHorizontalPosition(this.m_backgroundLayerFar, 0.6f);
			this.SetHorizontalPosition(this.m_backgroundLayerNear, 0.4f);
			this.SetHorizontalPosition(this.m_backgroundLayerSky, 0.8f);
			this.SetHorizontalPosition(this.m_backgroundLayerFixedFollowCamera, 1f);
			for (int i = 0; i < this.m_miscellanousLayer.Count; i++)
			{
                ParallaxCustomLayer parallaxCustomLayer = this.m_miscellanousLayer[i];
				Vector3 position = parallaxCustomLayer.layer.transform.position;
				position.x = parallaxCustomLayer.layer.GetComponent<BaseTransform>().position.x + this.m_offset.x * parallaxCustomLayer.speedX;
				parallaxCustomLayer.layer.transform.position = position;
			}
		}
		if (num2 != 0f)
		{
			for (int j = 0; j < this.m_backgroundLayerForeground.Length; j++)
			{
				GameObject gameObject = this.m_backgroundLayerForeground[j];
				Vector3 vector = gameObject.transform.position;
				if (vector.y <= this.m_fgLimitY)
				{
					vector -= Vector3.up * num2 * 0.2f;
				}
				else
				{
					vector.y = this.m_fgLimitY;
				}
				gameObject.transform.position = vector;
			}
		}
		this.m_oldPosition = base.transform.position;
	}

	public void RegisterParallaxLayer(ParallaxCustomLayer pcl)
	{
		this.m_miscellanousLayer.Add(pcl);
		pcl.layer.AddComponent<BaseTransform>();
	}

	protected GameObject[] m_backgroundLayerFurther;

	protected GameObject[] m_backgroundLayerFar;

	protected GameObject[] m_backgroundLayerNear;

	protected GameObject[] m_backgroundLayerSky;

	protected GameObject[] m_backgroundLayerForeground;

	protected GameObject[] m_backgroundLayerFixedFollowCamera;

	protected float m_fgLimitY;

	protected List<ParallaxCustomLayer> m_miscellanousLayer = new List<ParallaxCustomLayer>();

	protected Vector3 m_offset;

	protected Vector3 m_oldPosition;

	public struct ParallaxCustomLayer
	{
		public GameObject layer;

		public float speedX;
	}
}
