using System;
using UnityEngine;

public class Lantern : PointLight
{
	public override void Awake()
	{
		base.Awake();
		PointLightSource lightSource = this.lightSource;
		lightSource.onLightTurnOff = (Action)Delegate.Combine(lightSource.onLightTurnOff, new Action(this.OnLightOff));
		PointLightSource lightSource2 = this.lightSource;
		lightSource2.onLightTurnOn = (Action)Delegate.Combine(lightSource2.onLightTurnOn, new Action(this.OnLightOn));
	}

	private void OnDestroy()
	{
		if (this.lightSource == null)
		{
			return;
		}
		PointLightSource lightSource = this.lightSource;
		lightSource.onLightTurnOff = (Action)Delegate.Remove(lightSource.onLightTurnOff, new Action(this.OnLightOff));
		PointLightSource lightSource2 = this.lightSource;
		lightSource2.onLightTurnOn = (Action)Delegate.Remove(lightSource2.onLightTurnOn, new Action(this.OnLightOn));
	}

	private void OnLightOff()
	{
		this.enableFlicker = false;
	}

	private void OnLightOn()
	{
		this.enableFlicker = true;
		this.originalSize = this.lightSource.size;
		if (this.lightTransform == null)
		{
			this.lightTransform = this.lightSource.lightTransform;
		}
		if (this.lightCollider == null)
		{
			this.lightCollider = base.GetComponentInChildren<SphereCollider>();
		}
	}

	private void Update()
	{
		if (!this.enableFlicker || this.lightTransform == null)
		{
			return;
		}
		float num = Mathf.Sin(Time.realtimeSinceStartup * this.mainSinSpeed) * Mathf.Sin(Time.realtimeSinceStartup * this.subSinSpeed) * this.flicker;
		this.lightTransform.localScale = new Vector3(this.originalSize + num, this.originalSize + num, this.lightTransform.localScale.z);
		this.lightCollider.radius = this.originalSize + num;
	}

	[SerializeField]
	private float mainSinSpeed;

	[SerializeField]
	private float subSinSpeed;

	[SerializeField]
	private float flicker;

	private float originalSize;

	private bool enableFlicker;

	private Transform lightTransform;

	private SphereCollider lightCollider;
}
