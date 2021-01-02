using UnityEngine;

public class PartBox : OneTimeCollectable
{
	public static event Collected onCollected;

	public event Collect onCollect;

	public string TutorialShownKey
	{
		get
		{
			return "IsPartTutorialShown_" + this.partType.ToString();
		}
	}

	private void OnDataLoaded()
	{
		foreach (GameObject gameObject in WPFMonoBehaviour.gameData.m_parts)
		{
			BasePart component = gameObject.GetComponent<BasePart>();
			if (component.m_partType == this.partType)
			{
				if (this.partSpriteParent == null)
				{
					this.partSpriteParent = new GameObject(string.Format("PartVisualisation_{0}", this.partType));
				}
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(component.m_constructionIconSprite.gameObject);
				gameObject2.layer = base.gameObject.layer;
				this.partSprite = gameObject2.transform;
				this.partSprite.name = "PartVisualisation";
				this.partSprite.parent = this.partSpriteParent.transform;
				this.partSprite.localPosition = Vector3.zero;
				this.partSprite.localRotation = Quaternion.identity;
				this.partSprite.GetComponent<Renderer>().enabled = false;
				if (this.collectAnimation != null)
				{
					Animation animation = this.partSprite.gameObject.AddComponent<Animation>();
					animation.playAutomatically = false;
					animation.AddClip(this.collectAnimation, this.collectAnimation.name);
				}
			}
		}
		if (GameProgress.HasKey(string.Format("{0}_star_{1}", Singleton<GameManager>.Instance.CurrentSceneName, base.NameKey), GameProgress.Location.Local, null) && !GameProgress.HasKey(string.Format("{0}_part_{1}", Singleton<GameManager>.Instance.CurrentSceneName, base.NameKey), GameProgress.Location.Local, null))
		{
			GameProgress.AddPartBox(Singleton<GameManager>.Instance.CurrentSceneName, base.NameKey);
			GameProgress.AddSandboxParts(Singleton<GameManager>.Instance.CurrentSceneName, this.partType, this.count, true);
		}
	}

	public override bool IsDisabled()
	{
		return false;
	}

	protected override string GetNameKey()
	{
		string result = string.Empty;
		if (base.transform.parent != null && base.transform.parent.name.Contains("FloatingPartBox"))
		{
			result = base.transform.parent.name;
		}
		else if (base.transform.parent != null && base.transform.parent.name == "PartBoxes")
		{
			result = base.name;
		}
		else
		{
			this.DisableGoal(true);
		}
		return result;
	}

	public override void OnCollected()
	{
		int sandboxStarCollectCount = GameProgress.GetSandboxStarCollectCount(Singleton<GameManager>.Instance.CurrentSceneName, base.NameKey);
		if (sandboxStarCollectCount <= 1)
		{
			int num = Singleton<GameConfigurationManager>.Instance.GetValue<int>("star_box_snout_value", "amount");
			if (num > 0 && !Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
			{
				GameProgress.AddSandboxStar(Singleton<GameManager>.Instance.CurrentSceneName, base.NameKey, true);
				num = ((!Singleton<DoubleRewardManager>.Instance.HasDoubleReward) ? num : (num * 2));
				GameProgress.AddSnoutCoins(num);
				Singleton<PlayerProgress>.Instance.AddExperience(PlayerProgress.ExperienceType.PartBoxCollectedSandbox);
				base.ShowXPParticles();
				for (int i = 0; i < num; i++)
				{
					SnoutCoinSingle.Spawn(base.transform.position - Vector3.forward, 1f * (float)i);
				}
			}
			else if (sandboxStarCollectCount < 1)
			{
				GameProgress.AddSandboxStar(Singleton<GameManager>.Instance.CurrentSceneName, base.NameKey, false);
			}
		}
		if (!this.isGhost)
		{
			GameProgress.AddPartBox(Singleton<GameManager>.Instance.CurrentSceneName, base.NameKey);
			GameProgress.AddSandboxParts(Singleton<GameManager>.Instance.CurrentSceneName, this.partType, this.count, true);
			if (this.partSprite != null)
			{
				this.partSpriteParent.transform.position = base.transform.position - Vector3.forward * 2f;
				this.partSprite.GetComponent<Renderer>().enabled = true;
				if (this.partSprite.GetComponent<Animation>() != null && this.collectAnimation != null)
				{
					this.partSprite.GetComponent<Animation>().Play(this.collectAnimation.name);
				}
			}
			if (this.tutoPage != null)
			{
				if (GameProgress.GetBool(this.TutorialShownKey, false, GameProgress.Location.Local, null))
				{
					this.showTutorial = false;
				}
				else
				{
					this.showTutorial = true;
				}
			}
		}
		if (PartBox.onCollected != null)
		{
			PartBox.onCollected();
		}
		if (this.onCollect != null)
		{
			this.onCollect(this);
		}
	}

	protected override void OnUIEvent(UIEvent data)
	{
		base.OnUIEvent(data);
		if (this.showTutorial && data.type == UIEvent.Type.Building)
		{
			WPFMonoBehaviour.levelManager.m_levelCompleteTutorialBookPagePrefab = this.tutoPage;
			EventManager.Send(new UIEvent(UIEvent.Type.OpenTutorial));
			GameProgress.SetBool(this.TutorialShownKey, true, GameProgress.Location.Local);
			this.showTutorial = false;
		}
	}

	public BasePart.PartType partType;

	public int count;

	public GameObject tutoPage;

	public AnimationClip collectAnimation;

	private Transform partSprite;

	private GameObject partSpriteParent;

	private bool showTutorial;

	public delegate void Collected();

	public new delegate void Collect(PartBox sender);
}
