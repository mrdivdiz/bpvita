using System.Collections;
using UnityEngine;

public class SecretStatue : OneTimeCollectable
{
	protected override void Start()
	{
		base.Start();
		this.pls = base.GetComponent<PointLightSource>();
		bool @bool = GameProgress.GetBool("SECRET_DISCOVERED_" + Singleton<GameManager>.Instance.CurrentSceneName + "_statue", false, GameProgress.Location.Local, null);
		if (@bool)
		{
			this.DisableGoal(true);
		}
	}

	private void OnTriggerEnter(Collider c)
	{
		this.CheckIfSeen(c);
	}

	private void OnTriggerStay(Collider c)
	{
		this.CheckIfSeen(c);
	}

	private void CheckIfSeen(Collider c)
	{
		if (this.disabled || WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Completed)
		{
			return;
		}
		LightTrigger component = c.GetComponent<LightTrigger>();
		if (component)
		{
			PointLightSource lightSource = component.LightSource;
			if (lightSource && lightSource.lightType == PointLightMask.LightType.PointLight)
			{
				this.Collect();
			}
			else if (lightSource.lightType == PointLightMask.LightType.BeamLight)
			{
				if (Vector3.Distance(base.transform.position, lightSource.beamArcCenter) < lightSource.colliderSize)
				{
					this.Collect();
				}
				else
				{
					float beamAngle = lightSource.beamAngle;
					Vector3 a = Vector3.up * base.transform.position.y + Vector3.right * base.transform.position.x;
					Vector3 b = Vector3.up * c.transform.position.y + Vector3.right * c.transform.position.x;
					Vector3 from = a - b;
					float num = Vector3.Angle(from, lightSource.transform.up);
					if (num < beamAngle * 0.5f)
					{
						this.Collect();
					}
				}
			}
		}
	}

	protected override void DisableGoal(bool disable = true)
	{
		this.disabled = disable;
		for (int i = 0; i < this.components.Length; i++)
		{
			if (this.components[i] is Collider)
			{
				(this.components[i] as Collider).enabled = !disable;
			}
		}
		this.pls.usesCurves = !disable;
		this.pls.isEnabled = disable;
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
		instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.secretStatueFound);
		Singleton<PlayerProgress>.Instance.AddExperience(PlayerProgress.ExperienceType.HiddenStatueFound);
		if (GameProgress.SecretStatueCount() == GameProgress.MaxStatueCount())
		{
			Singleton<PlayerProgress>.Instance.AddExperience(PlayerProgress.ExperienceType.AllHiddenStatuesFound);
		}
		this.collected = true;
		this.pls.isEnabled = this.collected;
		this.OnCollected();
	}

	public override void OnCollected()
	{
		base.StartCoroutine(this.ShowPopup());
		GameProgress.SetBool("SECRET_DISCOVERED_" + Singleton<GameManager>.Instance.CurrentSceneName + "_statue", true, GameProgress.Location.Local);
		GameProgress.AddSecretStatue();
		int count = GameProgress.SecretStatueCount();
		if (Singleton<SocialGameManager>.IsInstantiated())
		{
			Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.BELONGS_IN_MUSEUM", 100.0);
			Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.ARCHEOLOGIST", 100.0, (int limit) => count >= limit);
		}
	}

	private IEnumerator ShowPopup()
	{
		yield return new WaitForSeconds(0.5f);
		UnityEngine.Object.Instantiate<GameObject>(this.statuePopup.gameObject, WPFMonoBehaviour.hudCamera.transform.position + Vector3.forward * 50f, Quaternion.identity);
		yield break;
	}

	protected override string GetNameKey()
	{
		return string.Empty;
	}

	[SerializeField]
	private GameObject statuePopup;

	private PointLightSource pls;
}
