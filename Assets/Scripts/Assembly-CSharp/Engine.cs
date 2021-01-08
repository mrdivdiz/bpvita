using UnityEngine;

public class Engine : BasePart
{
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
		return this.m_running;
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

	public override void Initialize()
	{
		base.contraption.m_enginesAmount++;
		this.m_visualizationPart = base.transform.GetChild(0);
		this.m_visualizationPartPosition = this.m_visualizationPart.localPosition;
	}

	public override void OnDetach()
	{
		this.m_engineBroken = true;
		if (this.m_running)
		{
			this.SetEnabled(false);
		}
		base.contraption.m_enginesAmount--;
		this.audioManager.RemoveCombinedLoopingEffect(this.m_engineSound, this.loopingSound);
		base.OnDetach();
	}

	private void Start()
	{
		this.audioManager = Singleton<AudioManager>.Instance;
		BasePart.PartType partType = this.m_partType;
		if (partType != BasePart.PartType.EngineSmall)
		{
			if (partType != BasePart.PartType.Engine)
			{
				if (partType == BasePart.PartType.EngineBig)
				{
					//this.m_engineSound = WPFMonoBehaviour.gameData.commonAudioCollection.V8Engine;
				}
			}
			else
			{
				//this.m_engineSound = WPFMonoBehaviour.gameData.commonAudioCollection.engine;
			}
		}
		else if (base.HasTag("Alien"))
		{
			//this.m_engineSound = WPFMonoBehaviour.gameData.commonAudioCollection.alienEngineLoop;
		}
		else
		{
			//this.m_engineSound = WPFMonoBehaviour.gameData.commonAudioCollection.electricEngine;
		}
	}

	private void Update()
	{
		if (this.m_running && !this.loopingSound)
		{
			//this.loopingSound = this.audioManager.SpawnCombinedLoopingEffect(this.m_engineSound, base.gameObject.transform);
			//this.loopingSound.GetComponent<AudioSource>().pitch = Mathf.Clamp(0.8f + 0.1f * (float)base.contraption.m_enginesAmount, 0f, 1f);
		}
		else if (!this.m_running && this.loopingSound)
		{
			//this.audioManager.RemoveCombinedLoopingEffect(this.m_engineSound, this.loopingSound);
			//this.loopingSound = null;
		}
		if (this.m_running)
		{
			this.PlayEngineAnimation();
		}
	}

	private void PlayEngineAnimation()
	{
		if (Time.deltaTime > 0f)
		{
			this.m_visualizationPart.localPosition = this.m_visualizationPartPosition + (Vector3)UnityEngine.Random.insideUnitCircle * 0.1f;
		}
	}

	protected override void OnTouch()
	{
		if (base.contraption.ActivateAllPoweredParts(base.ConnectedComponent) == 0)
		{
			this.SetEnabled(!this.m_running);
		}
	}

	public override void SetEnabled(bool enabled)
	{
		this.m_running = (enabled && !this.m_engineBroken);
		if (this.smokeEmitter != null)
		{
			if (this.m_running)
			{
				this.smokeEmitter.Play();
			}
			else
			{
				this.smokeEmitter.Stop();
			}
		}
		if (this.flameEmitter != null)
		{
			if (this.m_running)
			{
				this.flameEmitter.Play();
			}
			else
			{
				this.flameEmitter.Stop();
			}
		}
	}

	public bool m_running;

	private Transform m_visualizationPart;

	private Vector3 m_visualizationPartPosition;

	private bool m_engineBroken;

	private GameObject loopingSound;

	private AudioSource m_engineSound;

	private AudioManager audioManager;

	public ParticleSystem smokeEmitter;

	public ParticleSystem flameEmitter;
}
