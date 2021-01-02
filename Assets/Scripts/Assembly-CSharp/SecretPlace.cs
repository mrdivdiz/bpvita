using System.Collections;
using UnityEngine;

public class SecretPlace : OneTimeCollectable
{
	protected override void Start()
	{
		base.Start();
		this.m_disablingGoal = false;
		bool @bool = GameProgress.GetBool("SECRET_DISCOVERED_" + Singleton<GameManager>.Instance.CurrentSceneName, false, GameProgress.Location.Local, null);
		if (@bool)
		{
			this.DisableGoal(true);
		}
	}

	public override void Collect()
	{
		if (this.collected)
		{
			return;
		}
		if (this.collectedEffect)
		{
			UnityEngine.Object.Instantiate<ParticleSystem>(this.collectedEffect, base.transform.position, base.transform.rotation);
		}
		AudioManager instance = Singleton<AudioManager>.Instance;
		instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.bonusBoxCollected);
		Singleton<PlayerProgress>.Instance.AddExperience(PlayerProgress.ExperienceType.HiddenSkullFound);
		if (GameProgress.SecretSkullCount() == GameProgress.MaxSkullCount())
		{
			Singleton<PlayerProgress>.Instance.AddExperience(PlayerProgress.ExperienceType.AllHiddenSkullsFound);
		}
		this.collected = true;
		this.m_disablingGoal = true;
		this.m_animationTimer = 0f;
		this.OnCollected();
	}

	private void Update()
	{
		if (this.m_disablingGoal)
		{
			this.m_animationTimer += Time.deltaTime;
			if (this.m_animationTimer < 0.2f)
			{
				base.transform.localScale += Vector3.one * Time.deltaTime;
			}
			else if (this.m_animationTimer < 1f)
			{
				base.transform.localScale -= Vector3.one * Time.deltaTime;
			}
			else
			{
				this.DisableGoal(true);
				this.m_disablingGoal = false;
			}
		}
	}

	public override void OnCollected()
	{
		base.StartCoroutine(this.ShowPopup());
		GameProgress.SetBool("SECRET_DISCOVERED_" + Singleton<GameManager>.Instance.CurrentSceneName, true, GameProgress.Location.Local);
		GameProgress.AddSecretSkull();
		int n = GameProgress.SecretSkullCount();
		if (Singleton<SocialGameManager>.IsInstantiated())
		{
			Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.BRUSH", 100.0);
			Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.IS_IT_SECRET", 100.0, (int limit) => n >= limit);
			Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.SECRET_ADMIRER", 100.0, (int limit) => n >= limit);
			Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.MASTER_EXPLORER", 100.0, (int limit) => n >= limit);
			Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.MEGA_MASTER_EXPLORER", 100.0, (int limit) => n >= limit);
		}
	}

	private IEnumerator ShowPopup()
	{
		yield return new WaitForSeconds(0.5f);
		UnityEngine.Object.Instantiate<GameObject>(this.m_skullPopup.gameObject, WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 50f, Quaternion.identity);
		yield break;
	}

	protected override string GetNameKey()
	{
		return string.Empty;
	}

	private bool m_disablingGoal;

	private float m_animationTimer;

	[SerializeField]
	private SkullPopup m_skullPopup;
}
