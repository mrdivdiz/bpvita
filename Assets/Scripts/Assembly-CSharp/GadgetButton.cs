using UnityEngine;

public class GadgetButton : Button
{
	public bool Enabled
	{
		get
		{
			return this.m_enabled;
		}
		set
		{
            this.colliders = base.GetComponentsInChildren<Collider>();
            this.renderers = base.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < this.colliders.Length; i++)
			{
				this.colliders[i].enabled = value;
			}
			for (int j = 0; j < this.renderers.Length; j++)
			{
				this.renderers[j].enabled = value;
			}
			this.m_enabled = value;
		}
	}

	public VisibilityCondition VisibilityCondition
	{
		get
		{
			return this.visibilityCondition;
		}
	}

	public override bool AllowMultitouch()
	{
		return true;
	}

	public float PlacementOrder
	{
		get
		{
			return this.m_placementOrder;
		}
		set
		{
			this.m_placementOrder = value;
			this.m_stateUpdateTimer = 0.01f * this.m_placementOrder;
		}
	}

	protected override void ButtonAwake()
	{
		this.m_spriteAnimation = base.gameObject.AddComponent<SpriteAnimation>();
		this.m_spriteAnimation.CopyFrom(this.m_buttonAnimationPrefab);
		if (this.soundEffect == null)
		{
			this.soundEffect = Singleton<GameManager>.Instance.gameData.commonAudioCollection.gadgetButtonClick;
		}
		this.levelManager = WPFMonoBehaviour.levelManager;
		this.colliders = base.GetComponentsInChildren<Collider>();
		this.renderers = base.GetComponentsInChildren<Renderer>();
		this.visibilityCondition = base.GetComponent<VisibilityCondition>();
	}

	protected override void OnActivate()
	{
		base.OnActivate();
		if ((this.m_partType == BasePart.PartType.RedRocket || this.m_partType == BasePart.PartType.Rocket) && Singleton<SocialGameManager>.IsInstantiated())
		{
			Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.CRASH_COURSE", 100.0, (int limit) => this.levelManager.ContraptionProto.GetPartCount(this.m_partType) >= limit);
		}
		EventManager.Send(new GadgetControlEvent(this.m_partType, this.m_direction));
	}

	private void OnEnable()
	{
		this.m_gadgetSprite = base.transform.Find("Gadget").gameObject;
		this.UpdateState();
	}

	protected override void ButtonUpdate()
	{
		this.m_stateUpdateTimer += Time.deltaTime;
		if (this.m_stateUpdateTimer >= 0.2f)
		{
			this.UpdateState();
			this.m_stateUpdateTimer = 0f;
		}
		if (this.m_partsEnabled)
		{
			this.m_enabledTimer += Time.deltaTime;
			if (this.m_partType == BasePart.PartType.Bellows)
			{
				Vector3 localScale = this.m_gadgetSprite.transform.localScale;
				localScale.y = Bellows.CompressionScale(this.m_enabledTimer);
				this.m_gadgetSprite.transform.localScale = localScale;
				if (this.m_enabledTimer > 0.8f + ((!Bellows.HasAlienBellows) ? 0.3f : 0.15f))
				{
					this.m_enabledTimer = 0f;
				}
			}
			else
			{
				this.m_gadgetSprite.transform.localPosition = (Vector3)UnityEngine.Random.insideUnitCircle * 0.075f + new Vector3(0f, 0f, -0.1f);
			}
		}
	}

	public void UpdateState()
	{
		if (this.m_partType != BasePart.PartType.Engine)
		{
			this.UpdateGadgetState();
		}
		else if (this.levelManager && this.levelManager.ContraptionRunning)
		{
			bool flag = this.levelManager.ContraptionRunning.AllPoweredPartsEnabled();
			if (flag)
			{
				this.m_spriteAnimation.Play("On");
			}
			else
			{
				this.m_spriteAnimation.Play("Off");
			}
			this.m_partsEnabled = flag;
		}
	}

	private void UpdateGadgetState()
	{
		if (!this.levelManager || !this.levelManager.ContraptionRunning)
		{
			return;
		}
		bool flag = (this.m_partTier != BasePart.PartTier.Regular) ? this.levelManager.ContraptionRunning.AnyPartsEnabled(this.m_partType, this.m_partTier, this.m_direction) : this.levelManager.ContraptionRunning.AnyPartsEnabled(this.m_partType, this.m_direction);
		if (!flag && this.m_partsEnabled)
		{
			this.m_gadgetSprite.transform.localPosition = new Vector3(0f, 0f, -0.1f);
			this.m_gadgetSprite.transform.localScale = Vector3.one;
			this.m_enabledTimer = 0f;
		}
		if (flag != this.m_partsEnabled)
		{
			if (flag)
			{
				this.m_spriteAnimation.Play("On");
			}
			else
			{
				this.m_spriteAnimation.Play("Off");
			}
		}
		this.m_partsEnabled = flag;
		if (this.m_partType != BasePart.PartType.Engine)
		{
			if (!this.levelManager.m_showOnlyEngineButton)
			{
				this.Enabled = this.levelManager.ContraptionRunning.HasActiveParts(this.m_partType, this.m_direction);
			}
			else
			{
				this.Enabled = false;
			}
		}
	}

	public BasePart.PartType m_partType;

	public BasePart.Direction m_direction;

	public BasePart.PartTier m_partTier;

	public SpriteAnimation m_buttonAnimationPrefab;

	private float m_placementOrder;

	private LevelManager levelManager;

	private GameObject m_gadgetSprite;

	private float m_stateUpdateTimer;

	private bool m_partsEnabled;

	private bool m_enabled;

	private float m_enabledTimer;

	private SpriteAnimation m_spriteAnimation;

	private Collider[] colliders;

	private Renderer[] renderers;

	private VisibilityCondition visibilityCondition;
}
