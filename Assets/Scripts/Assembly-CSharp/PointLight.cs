using System;
using UnityEngine;

public class PointLight : BasePart
{
	public override void Awake()
	{
		base.Awake();
		this.activeSprite.SetActive(this.activated);
		this.inactiveSprite.SetActive(!this.activated);
		this.lightSource = base.GetComponent<PointLightSource>();
	}

	public override bool CanBeEnabled()
	{
		return true;
	}

	public override bool HasOnOffToggle()
	{
		return true;
	}

	public override bool IsEnabled()
	{
		return this.activated;
	}

	public override bool IsIntegralPart()
	{
		return false;
	}

	public override bool CanBeEnclosed()
	{
		return true;
	}

	public override void OnDetach()
	{
		base.OnDetach();
	}

	protected override void OnTouch()
	{
		this.activated = !this.activated;
		this.activeSprite.SetActive(this.activated);
		this.inactiveSprite.SetActive(!this.activated);
		if (this.lightSource)
		{
			this.lightSource.isEnabled = this.activated;
		}
		if (base.rigidbody)
		{
			base.rigidbody.WakeUp();
		}
	}

	public GameObject activeSprite;

	public GameObject inactiveSprite;

	protected bool activated;

	protected PointLightSource lightSource;
}
