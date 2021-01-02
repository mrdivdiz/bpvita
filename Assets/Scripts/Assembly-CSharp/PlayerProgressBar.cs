using System;
using UnityEngine;

public class PlayerProgressBar : MonoBehaviour, ICurrencyParticleEffectTarget
{
	public static PlayerProgressBar Instance
	{
		get
		{
			return PlayerProgressBar.instance;
		}
	}

	public bool CanLevelUp
	{
		set
		{
			this.canLevelUp = value;
			if (this.canLevelUp && this.currentState == PlayerProgressBar.State.WaitingLevelInactive)
			{
				this.SetState(PlayerProgressBar.State.WaitingLevelActive);
			}
			else if (!this.canLevelUp && this.currentState == PlayerProgressBar.State.WaitingLevelActive)
			{
				this.SetState(PlayerProgressBar.State.WaitingLevelInactive);
			}
		}
	}

	public bool Visible
	{
		get
		{
			return ResourceBar.Instance.IsItemActive(ResourceBar.Item.PlayerProgress);
		}
	}

	public bool Enabled
	{
		get
		{
			return ResourceBar.Instance.IsItemEnabled(ResourceBar.Item.PlayerProgress);
		}
	}

	private void Awake()
	{
		PlayerProgressBar.instance = this;
		this.currentState = PlayerProgressBar.State.None;
		this.SetState(PlayerProgressBar.State.Regular);
		this.resourceBarItem = base.GetComponent<ResourceBarItem>();
		this.effect = base.GetComponent<CurrencyParticleEffect>();
		this.effect.SetTarget(this);
		this.maxFill = this.experienceFillMeter.localScale.x;
		EventManager.Connect(new EventManager.OnEvent<PlayerProgressEvent>(this.OnPlayerProgress));
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.OnReceivedUIEvent));
		EventManager.Connect(new EventManager.OnEvent<LevelLoadedEvent>(this.OnLevelLoaded));
		EventManager.Connect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
	}

	private void OnPlayerChanged(PlayerChangedEvent data)
	{
		this.delayUpdate = false;
		this.SetState(PlayerProgressBar.State.Regular);
		this.UpdateAmount(true);
	}

	private void OnEnable()
	{
		this.nextUpdate = Time.realtimeSinceStartup + 2f;
		this.UpdateAmount(true);
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<PlayerProgressEvent>(this.OnPlayerProgress));
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.OnReceivedUIEvent));
		EventManager.Disconnect(new EventManager.OnEvent<LevelLoadedEvent>(this.OnLevelLoaded));
		EventManager.Disconnect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
	}

	private void OnPlayerProgress(PlayerProgressEvent data)
	{
		if (!this.delayUpdate)
		{
			this.targetExperience = data.experience;
		}
		this.currentRealExperience = data.experience;
	}

	private void OnReceivedUIEvent(UIEvent data)
	{
		if (!Singleton<GameManager>.IsInstantiated())
		{
			return;
		}
		if (Singleton<GameManager>.Instance.GetGameState() == GameManager.GameState.MainMenu)
		{
			ResourceBar.Instance.ShowItem(ResourceBar.Item.PlayerProgress, false, false);
			return;
		}
		UIEvent.Type type = data.type;
		if (type != UIEvent.Type.OpenedLootWheel)
		{
			if (type == UIEvent.Type.ClosedLootWheel)
			{
				if (Singleton<PlayerProgress>.Instance.LevelUpPending && ResourceBar.Instance.IsItemEnabled(ResourceBar.Item.PlayerProgress))
				{
					this.SetState(PlayerProgressBar.State.WaitingLevelActive);
				}
				else if (Singleton<PlayerProgress>.Instance.LevelUpPending && !ResourceBar.Instance.IsItemEnabled(ResourceBar.Item.PlayerProgress))
				{
					this.SetState(PlayerProgressBar.State.WaitingLevelInactive);
				}
				else
				{
					this.SetState(PlayerProgressBar.State.Regular);
				}
			}
		}
		else
		{
			this.SetState(PlayerProgressBar.State.Regular);
			this.UpdateAmount(true);
		}
	}

	private void OnLevelLoaded(LevelLoadedEvent data)
	{
		GameManager.GameState currentGameState = data.currentGameState;
		if (currentGameState == GameManager.GameState.MainMenu)
		{
			this.UpdateAmount(true);
		}
		this.UpdateAmount(false);
	}

	public void LevelUp()
	{
		Singleton<PlayerProgress>.Instance.CheckLevelUp();
	}

	public void DelayUpdate()
	{
		this.delayUpdate = true;
	}

	public void AddParticles(GameObject target, int amount, float delay = 0f, float burstRate = 0f, Action<bool> onFinished = null)
	{
		this.delayUpdate = false;
		if (this.effect == null)
		{
			return;
		}
		float num = 0f;
		for (int i = 0; i < amount; i++)
		{
			if (!Mathf.Approximately(burstRate, 0f) && burstRate > 0f)
			{
				num += 1f / burstRate;
			}
			this.effect.AddParticle(target.transform, UnityEngine.Random.insideUnitCircle.normalized * UnityEngine.Random.Range(5f, 25f), delay + num);
		}
		if (onFinished != null)
		{
			this.particlesRemaining = amount;
			this.onFinished = onFinished;
		}
	}

	public void AddParticles(Vector3 position, int amount, float delay = 0f, float burstRate = 0f, Action<bool> onFinished = null)
	{
		this.delayUpdate = false;
		if (this.effect == null)
		{
			return;
		}
		float num = 0f;
		for (int i = 0; i < amount; i++)
		{
			if (!Mathf.Approximately(burstRate, 0f) && burstRate > 0f)
			{
				num += 1f / burstRate;
			}
			this.effect.AddParticle(position, UnityEngine.Random.insideUnitCircle.normalized * UnityEngine.Random.Range(20f, 25f), delay + num);
		}
		if (onFinished != null)
		{
			this.particlesRemaining = amount;
			this.onFinished = onFinished;
		}
	}

	private void Update()
	{
		if (!Singleton<PlayerProgress>.IsInstantiated())
		{
			return;
		}
		if (this.currentExperience == Singleton<PlayerProgress>.Instance.ExperienceToNextLevel && Singleton<PlayerProgress>.Instance.LevelUpPending && this.currentState == PlayerProgressBar.State.Regular)
		{
			this.SetState((!ResourceBar.Instance.IsItemEnabled(ResourceBar.Item.PlayerProgress) || !this.canLevelUp) ? PlayerProgressBar.State.WaitingLevelInactive : PlayerProgressBar.State.WaitingLevelActive);
		}
		if (this.currentExperience != this.targetExperience && Time.realtimeSinceStartup >= this.nextUpdate && this.resourceBarItem.IsShowing && this.currentState == PlayerProgressBar.State.Regular)
		{
			this.nextUpdate = Time.realtimeSinceStartup + SoftCurrencyButton.updateInterval;
			int deltaAmount = SoftCurrencyButton.GetDeltaAmount(this.currentExperience, this.targetExperience);
			if (this.currentExperience < this.targetExperience)
			{
				this.currentExperience += deltaAmount;
			}
			else if (this.currentExperience > this.targetExperience)
			{
				this.currentExperience -= deltaAmount;
			}
			int experienceToNextLevel = Singleton<PlayerProgress>.Instance.ExperienceToNextLevel;
			int level = Singleton<PlayerProgress>.Instance.Level;
			this.currentExperience = Mathf.Min(this.currentExperience, experienceToNextLevel);
			TextMeshHelper.UpdateTextMeshes(this.levelLabel, level.ToString(), false);
			TextMeshHelper.UpdateTextMeshes(this.experienceLabel, string.Format("{0}/{1}", this.currentExperience, experienceToNextLevel), false);
			float d = Mathf.Clamp((float)this.currentExperience / (float)experienceToNextLevel, 0.001f, 1f);
			this.experienceFillMeter.localScale = Vector3.forward + Vector3.up + Vector3.right * d * this.maxFill;
		}
	}

	private void SetLevelUpText()
	{
		TextMeshHelper.UpdateTextMeshes(this.experienceLabel, "LOOT_WHEEL_TITLE", true);
	}

	private void EnableWobble(bool enable)
	{
		if (enable)
		{
			this.pulseAnimation.Play();
		}
		else
		{
			this.pulseAnimation.Stop();
			base.transform.localScale = Vector3.one;
		}
	}

	private void EnableShine(bool enable)
	{
		this.shine.SetActive(enable);
	}

	private void SetState(State state)
	{
		if (state == this.currentState)
		{
			return;
		}
		if (state != PlayerProgressBar.State.Regular)
		{
			if (state != PlayerProgressBar.State.WaitingLevelActive)
			{
				if (state == PlayerProgressBar.State.WaitingLevelInactive)
				{
					this.EnableWobble(false);
					this.EnableShine(true);
					this.SetLevelUpText();
				}
			}
			else
			{
				this.EnableWobble(true);
				this.EnableShine(true);
				this.SetLevelUpText();
			}
		}
		else
		{
			this.EnableWobble(false);
			this.EnableShine(false);
		}
		this.currentState = state;
	}

	public void CurrencyParticleAdded(int amount = 1)
	{
		this.targetExperience += amount;
		this.particlesRemaining = Mathf.Clamp(this.particlesRemaining - amount, 0, int.MaxValue);
		if (this.onFinished != null && this.particlesRemaining <= 0)
		{
			this.onFinished(this.Visible);
			this.UpdateAmount(true);
			this.onFinished = null;
		}
	}

	public void UpdateAmount(bool force = false)
	{
		if (!Singleton<PlayerProgress>.IsInstantiated())
		{
			return;
		}
		this.nextUpdate = Time.realtimeSinceStartup;
		this.targetExperience = this.currentRealExperience;
		if (force && this.currentState == PlayerProgressBar.State.Regular)
		{
			int experienceToNextLevel = Singleton<PlayerProgress>.Instance.ExperienceToNextLevel;
			this.currentRealExperience = Singleton<PlayerProgress>.Instance.Experience;
			this.targetExperience = this.currentRealExperience;
			this.currentExperience = this.targetExperience;
			TextMeshHelper.UpdateTextMeshes(this.levelLabel, Singleton<PlayerProgress>.Instance.Level.ToString(), false);
			if (Singleton<PlayerProgress>.Instance.LevelUpPending)
			{
				this.experienceFillMeter.localScale = Vector3.forward + Vector3.up + Vector3.right * this.maxFill;
				if (ResourceBar.Instance.IsItemEnabled(ResourceBar.Item.PlayerProgress) && this.canLevelUp)
				{
					this.SetState(PlayerProgressBar.State.WaitingLevelActive);
				}
				else
				{
					this.SetState(PlayerProgressBar.State.WaitingLevelInactive);
				}
			}
			else
			{
				TextMeshHelper.UpdateTextMeshes(this.experienceLabel, string.Format("{0}/{1}", this.targetExperience, experienceToNextLevel), false);
				float d = Mathf.Clamp((float)this.currentExperience / (float)experienceToNextLevel, 0.001f, 1f);
				this.experienceFillMeter.localScale = Vector3.forward + Vector3.up + Vector3.right * d * this.maxFill;
			}
		}
	}

	private void OnEnableButton(GameObject sender)
	{
		if (this.currentState == PlayerProgressBar.State.WaitingLevelInactive)
		{
			this.SetState(PlayerProgressBar.State.WaitingLevelActive);
		}
	}

	private void OnDisableButton(GameObject sender)
	{
		if (this.currentState == PlayerProgressBar.State.WaitingLevelActive)
		{
			this.SetState(PlayerProgressBar.State.WaitingLevelInactive);
		}
	}

	public AudioSource[] GetHitSounds()
	{
		return WPFMonoBehaviour.gameData.commonAudioCollection.xpGain;
	}

	public AudioSource[] GetFlySounds()
	{
		return WPFMonoBehaviour.gameData.commonAudioCollection.nutFly;
	}

	private static PlayerProgressBar instance;

	private const string LEVEL_UP_LOCALIZATION_KEY = "LOOT_WHEEL_TITLE";

	[SerializeField]
	private Transform experienceFillMeter;

	[SerializeField]
	private TextMesh[] experienceLabel;

	[SerializeField]
	private TextMesh[] levelLabel;

	[SerializeField]
	private Animation pulseAnimation;

	[SerializeField]
	private GameObject shine;

	private float maxFill = 15f;

	private bool delayUpdate;

	private Action<bool> onFinished;

	private bool canLevelUp = true;

	private int particlesRemaining;

	private CurrencyParticleEffect effect;

	private int targetExperience;

	private int currentExperience;

	private int currentRealExperience;

	private float nextUpdate;

	private ResourceBarItem resourceBarItem;

	private State currentState;

	private enum State
	{
		None,
		Regular,
		WaitingLevelActive,
		WaitingLevelInactive
	}
}
