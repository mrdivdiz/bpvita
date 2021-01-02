public class AlienPointLight : PointLight
{
	private void OnDestroy()
	{
		if (LightManager.Instance && LightManager.Instance.NightVisionOn)
		{
			LightManager.Instance.ToggleNightVision();
		}
	}

	protected override void OnTouch()
	{
		base.OnTouch();
		if (!base.contraption.HasNightVision && LightManager.Instance != null && (this.activated ^ LightManager.Instance.NightVisionOn))
		{
			LightManager.Instance.ToggleNightVision();
		}
	}
}
