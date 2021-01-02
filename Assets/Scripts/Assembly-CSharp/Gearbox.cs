using System;
using UnityEngine;

public class Gearbox : BasePart
{
	public override void Awake()
	{
		base.Awake();
		this.activeSprite.SetActive(this.activated);
		this.inactiveSprite.SetActive(!this.activated);
		if (DeviceInfo.ActiveDeviceFamily != DeviceInfo.DeviceFamily.Ios)
		{
			this.achievementSent = true;
		}
		if (Singleton<AchievementData>.IsInstantiated() && Singleton<AchievementData>.Instance.GetAchievement("grp.LPA_GEARBOX").completed)
		{
			this.achievementSent = true;
		}
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
		return true;
	}

	public override bool CanBeEnclosed()
	{
		return true;
	}

	public override bool ValidatePart()
	{
		return this.m_enclosedInto != null;
	}

	public override void OnDetach()
	{
		base.OnDetach();
	}

	protected override void OnTouch()
	{
		Singleton<AudioManager>.Instance.SpawnOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.gearboxSwitch, base.transform.position);
		this.activated = !this.activated;
		this.activeSprite.SetActive(this.activated);
		this.inactiveSprite.SetActive(!this.activated);
		if (!this.achievementSent)
		{
			if (DeviceInfo.ActiveDeviceFamily == DeviceInfo.DeviceFamily.Ios)
			{
				Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.LPA_GEARBOX", 100.0);
			}
			this.achievementSent = true;
		}
	}

	public GameObject activeSprite;

	public GameObject inactiveSprite;

	private bool activated;

	private const string achievementId = "grp.LPA_GEARBOX";

	private bool achievementSent;
}
