using UnityEngine;

public class RewardView : WPFMonoBehaviour
{
	private void Awake()
	{
		if (base.transform.Find("Locked"))
		{
			this.m_locked = base.transform.Find("Locked").gameObject;
			this.EnableRendererRecursively(this.m_locked, false);
		}
		this.m_open = base.transform.Find("Open").gameObject;
		this.EnableRendererRecursively(this.m_open, false);
	}

	private void OnEnable()
	{
		if (this.m_animationPlaying)
		{
			this.m_animationPlaying.Play();
			this.m_animationPlaying[this.m_animationPlaying.clip.name].time = this.m_animationTime;
		}
	}

	private void Update()
	{
		if (this.m_animationTimerStarted)
		{
			this.m_animationTimer -= Time.deltaTime;
			if (this.m_animationTimer <= 0f)
			{
				this.m_animationTimerStarted = false;
				if (this.m_animationNode)
				{
					Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.sandboxLevelUnlocked);
					this.m_animationNode.GetComponent<Animation>().Play();
					this.m_animationPlaying = this.m_animationNode.GetComponent<Animation>();
				}
				if (this.m_plusNode)
				{
					this.m_plusNode.GetComponent<Renderer>().enabled = false;
				}
			}
		}
		if (this.m_particleTimerStarted)
		{
			this.m_particleTimer -= Time.deltaTime;
			if (this.m_particleTimer <= 0f)
			{
				this.m_particleTimerStarted = false;
				if (this.m_particleNode)
				{
					this.m_particleNode.GetComponent<ParticleSystem>().Play();
				}
			}
		}
		if (this.m_animationPlaying)
		{
			if (this.m_animationPlaying.isPlaying)
			{
				this.m_animationTime = this.m_animationPlaying[this.m_animationPlaying.clip.name].time;
			}
			else
			{
				this.m_animationPlaying = null;
			}
		}
	}

	public void SetPart(BasePart.PartType type)
	{
		this.m_animationNode = base.transform.Find("Open").transform.Find("PartOffset").Find("AnimationNode").gameObject;
		this.m_plusNode = base.transform.Find("Open").transform.Find("PartOffset").transform.Find("Plus").gameObject;
		this.m_particleNode = base.transform.Find("Open").transform.Find("PartOffset").transform.Find("StarBurstEffect").gameObject;
		for (int i = 0; i < 3; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_partIconBackground);
			gameObject.transform.parent = this.m_animationNode.transform;
			int index = (!gameObject.GetComponent<Renderer>().sharedMaterial.name.StartsWith("IngameAtlas2")) ? 0 : 1;
			Material material = AtlasMaterials.Instance.PartQueueZMaterials[index];
			gameObject.GetComponent<Renderer>().material = material;
			gameObject.transform.localPosition = new Vector3(0f, 0f, 0.1f);
			gameObject.transform.localScale = 3f * Vector3.one;
		}
		GameObject part = this.m_gameData.GetPart(type);
        Sprite constructionIconSprite = part.GetComponent<BasePart>().m_constructionIconSprite;
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(constructionIconSprite.gameObject);
		int index2 = (!gameObject2.GetComponent<Renderer>().sharedMaterial.name.StartsWith("IngameAtlas2")) ? 0 : 1;
		Material material2 = AtlasMaterials.Instance.PartQueueZMaterials[index2];
		gameObject2.GetComponent<Renderer>().material = material2;
		gameObject2.transform.parent = this.m_animationNode.transform;
		gameObject2.transform.localPosition = Vector3.zero;
		gameObject2.transform.localScale = 2.75f * Vector3.one;
		this.m_animationTimerStarted = true;
		this.m_animationTimer = 2.8f;
		this.m_particleTimerStarted = true;
		this.m_particleTimer = 3.8f;
	}

	public bool HasLocked()
	{
		return this.m_locked != null;
	}

	public void ShowLocked()
	{
		this.EnableRendererRecursively(this.m_open, false);
		this.EnableRendererRecursively(this.m_locked, true);
	}

	public void ShowOpen()
	{
		if (this.m_locked)
		{
			this.EnableRendererRecursively(this.m_locked, false);
		}
		this.EnableRendererRecursively(this.m_open, true);
	}

	public void Hide()
	{
		this.EnableRendererRecursively(this.m_open, false);
		if (this.m_locked)
		{
			this.EnableRendererRecursively(this.m_locked, false);
		}
	}

	private void EnableRendererRecursively(GameObject obj, bool enable)
	{
		if (obj.GetComponent<Renderer>())
		{
			obj.GetComponent<Renderer>().enabled = enable;
		}
		if (obj.GetComponent<Collider>())
		{
			obj.GetComponent<Collider>().enabled = enable;
		}
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			this.EnableRendererRecursively(obj.transform.GetChild(i).gameObject, enable);
		}
	}

	public GameData m_gameData;

	public GameObject m_partIconBackground;

	private GameObject m_locked;

	private GameObject m_open;

	private GameObject m_animationNode;

	private GameObject m_plusNode;

	private GameObject m_particleNode;

	private bool m_animationTimerStarted;

	private float m_animationTimer;

	private bool m_particleTimerStarted;

	private float m_particleTimer;

	private Animation m_animationPlaying;

	private float m_animationTime;
}
