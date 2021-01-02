using System;

public class Mushroom : PointLight
{
	public override void Awake()
	{
		this.activeSprite.SetActive(this.activated);
		this.inactiveSprite.SetActive(!this.activated);
		this.lightSource = base.GetComponent<PointLightSource>();
		this.lightSource.isEnabled = this.activated;
	}

	public override bool HasOnOffToggle()
	{
		return false;
	}

	public override bool CanBeEnabled()
	{
		return false;
	}

	public override bool IsEnabled()
	{
		return false;
	}

	public override void PostInitialize()
	{
		this.activated = true;
		this.activeSprite.SetActive(this.activated);
		this.inactiveSprite.SetActive(!this.activated);
		this.lightSource.isEnabled = this.activated;
		base.PostInitialize();
	}

	protected override void OnTouch()
	{
	}
}
