using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class LootCrateButton : Widget
{
	public int GainedXP { get; set; }

	private void Awake()
	{
		this.gameData = WPFMonoBehaviour.gameData;
		this.rewardElements = new List<LootRewardElement>();
		this.skeletonAnimation = base.GetComponentInChildren<SkeletonAnimation>();
		this.collider = base.GetComponent<Collider>();
		string format = "Root/SkeletonUtility-Root/root/Item{0}_Adjustment/Item{0}/Item{0}_Socket{1}";
		this.iconRoots = new Transform[this.maxRewardCount];
		this.backfaceRoots = new Transform[this.maxRewardCount];
		for (int i = 1; i <= this.maxRewardCount; i++)
		{
			Transform transform = base.transform.Find(string.Format(format, i, string.Empty));
			Transform transform2 = base.transform.Find(string.Format(format, i, 2));
			this.iconRoots[i - 1] = transform;
			this.backfaceRoots[i - 1] = transform2;
		}
		if (this.backfacePrefab != null && this.backfaceRoots != null && this.backfaceRoots.Length > 0)
		{
			for (int j = 0; j < this.backfaceRoots.Length; j++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.backfacePrefab);
				gameObject.transform.parent = this.backfaceRoots[j];
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = this.backfacePrefab.transform.localScale;
			}
		}
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.pointerPrefab);
		GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.clickPrefab);
		gameObject2.layer = base.gameObject.layer;
		gameObject3.layer = base.gameObject.layer;
		gameObject2.GetComponentInChildren<Renderer>().sortingLayerName = "Popup";
		gameObject3.GetComponentInChildren<Renderer>().sortingLayerName = "Popup";
		Tutorial.SetOrderInLayer(gameObject2, 3002);
		Tutorial.SetOrderInLayer(gameObject3, 3002);
		this.pointer = new Tutorial.Pointer(gameObject2, gameObject3);
		this.pointer.Show(false);
	}

	private void OnDestroy()
	{
		this.skeletonAnimation.state.Event -= this.OnAnimationEvent;
	}

	private void Start()
	{
		this.canBeHit = false;
	}

	public void Init(LootCrateType crateType)
	{
		this.openIndex = -1;
		this.hitCounter = 0;
		this.collider.enabled = true;
		this.lootCrateType = crateType;
		int num = (int)this.lootCrateType;
		this.skeletonAnimation.initialSkinName = this.skinNames[num];
		this.skeletonAnimation.Initialize(true);
		this.skeletonAnimation.state.Event -= this.OnAnimationEvent;
		this.skeletonAnimation.state.Event += this.OnAnimationEvent;
	}

	public void PlayIntro()
	{
		this.skeletonAnimation.state.SetAnimation(0, this.introAnimationName, false);
		this.skeletonAnimation.state.Complete += this.OnIntroEnd;
	}

	private void OnIntroEnd(Spine.AnimationState state, int trackIndex, int loopCount)
	{
		this.skeletonAnimation.state.Complete -= this.OnIntroEnd;
		this.skeletonAnimation.state.SetAnimation(0, this.idleAnimationName, true);
		this.canBeHit = true;
		this.tutorial = this.CreateTutorial();
		base.StartCoroutine(this.TutorialCoroutine());
	}

	protected override void OnInput(InputEvent input)
	{
		if (this.canBeHit && input.type == InputEvent.EventType.Press)
		{
			if (this.hitAnimationNames != null && this.hitCounter < this.hitAnimationNames.Length)
			{
				if (this.tutorialRunning)
				{
					base.StopAllCoroutines();
				}
				base.StartCoroutine(this.TutorialCoroutine());
				this.skeletonAnimation.state.SetAnimation(0, this.hitAnimationNames[this.hitCounter], false);
				this.PlayHitSound(this.hitCounter);
				this.hitCounter++;
			}
			else if (this.openAnimationNames != null)
			{
				if (this.openIndex < 0 || this.openIndex >= this.openAnimationNames.Length)
				{
					this.openIndex = 0;
				}
				this.skeletonAnimation.state.SetAnimation(0, this.openAnimationNames[this.openIndex], false);
				this.PlayHitSound(this.hitCounter);
				this.skeletonAnimation.state.End += this.OnOpenEnd;
				this.tutorialRunning = false;
				this.canBeHit = false;
				this.collider.enabled = false;
				if (this.onOpeningStart != null)
				{
					this.onOpeningStart();
				}
			}
			else if (this.onOpeningDone != null)
			{
				this.onOpeningDone();
			}
		}
	}

	private void OnOpenEnd(Spine.AnimationState state, int trackIndex)
	{
		this.skeletonAnimation.state.End -= this.OnOpenEnd;
		if (this.onOpeningDone != null)
		{
			this.onOpeningDone();
		}
		base.StartCoroutine(this.ScrapDuplicateParts());
	}

	private IEnumerator ScrapDuplicateParts()
	{
		int index = 0;
		foreach (LootRewardElement element in this.rewardElements)
		{
			if (element.IsDuplicatePart)
			{
				yield return element.WaitJumpAnimation();
				element.PlayScrapAnimation();
				float fade = 2f;
				while (fade > 0f)
				{
					fade -= GameTime.RealTimeDelta;
					yield return null;
				}
				if (element.BlingEffect != null)
				{
					element.BlingEffect.Stop();
				}
				for (int i = this.iconRoots[index].childCount - 1; i >= 0; i--)
				{
					this.iconRoots[index].GetChild(i).gameObject.SetActive(true);
				}
			}
			index++;
		}
		yield break;
	}

	public void SetScrapIcon(int index, GameObject iconPrefab, string label)
	{
		if (index >= 0 && index < this.rewardElements.Count)
		{
			GameObject gameObject = this.SetIcon(index, iconPrefab, label, 0, false, false);
			if (gameObject != null)
			{
				gameObject.SetActive(false);
			}
		}
	}

	public GameObject SetIcon(int index, GameObject iconPrefab, string label = "", int lootRewardPrefabIndex = 0, bool isDuplicatePart = false, bool addToRewardsList = true)
	{
		if (this.iconRoots == null || index < 0 || index >= this.iconRoots.Length || iconPrefab == null || this.lootRewardPrefabs == null || lootRewardPrefabIndex < 0 || lootRewardPrefabIndex >= this.lootRewardPrefabs.Length)
		{
			return null;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.lootRewardPrefabs[lootRewardPrefabIndex]);
		gameObject.transform.parent = this.iconRoots[index];
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = this.lootRewardPrefabs[lootRewardPrefabIndex].transform.localScale;
		LootRewardElement component = gameObject.GetComponent<LootRewardElement>();
		if (component != null && addToRewardsList)
		{
			component.IsDuplicatePart = isDuplicatePart;
			component.InitElement(this);
			this.rewardElements.Add(component);
		}
		Transform transform = gameObject.transform.Find("Label");
		if (transform)
		{
			if (string.IsNullOrEmpty(label))
			{
				transform.gameObject.SetActive(false);
			}
			else
			{
				TextMesh component2 = transform.GetComponent<TextMesh>();
				if (component2)
				{
					component2.text = label;
				}
			}
		}
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(iconPrefab);
		if (component != null)
		{
			gameObject2.transform.parent = component.IconRoot;
		}
		else
		{
			gameObject2.transform.parent = gameObject.transform;
		}
		gameObject2.transform.localPosition = -Vector3.forward * 0.5f;
		gameObject2.transform.localScale = Vector3.one;
		Renderer[] componentsInChildren = gameObject2.GetComponentsInChildren<Renderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].sortingLayerName = "Popup";
			componentsInChildren[i].sortingOrder = 1;
		}
		if (addToRewardsList)
		{
			this.openIndex++;
		}
		return gameObject;
	}

	private Tutorial.PointerTimeLine CreateTutorial()
	{
		Tutorial.PointerTimeLine pointerTimeLine = new Tutorial.PointerTimeLine(this.pointer);
		List<Vector3> list = new List<Vector3>();
		list.Add(this.tutorialTarget.position + 21f * Vector3.down);
		list.Add(this.tutorialTarget.position);
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.1f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Move(list, 2.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Press());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.5f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Release());
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Wait(0.75f));
		pointerTimeLine.AddEvent(new Tutorial.PointerTimeLine.Hide());
		return pointerTimeLine;
	}

	private IEnumerator TutorialCoroutine()
	{
		float time = 0f;
		this.tutorialRunning = true;
		this.pointer.Show(false);
		while (time < this.tutorialDelay)
		{
			time += Time.unscaledDeltaTime;
			yield return null;
		}
		this.tutorial.Start();
		while (this.tutorialRunning)
		{
			if (!this.tutorial.IsFinished())
			{
				this.tutorial.Update();
			}
			else
			{
				this.tutorial.Start();
			}
			yield return null;
		}
		this.pointer.Show(false);
		yield break;
	}

	private void PlayHitSound(int index)
	{
		AudioSource audioSource = null;
		switch (this.lootCrateType)
		{
		case LootCrateType.Wood:
		case LootCrateType.Cardboard:
			audioSource = this.gameData.commonAudioCollection.woodenCrateHits[index];
			break;
		case LootCrateType.Metal:
		case LootCrateType.Bronze:
			audioSource = this.gameData.commonAudioCollection.metalCrateHits[index];
			break;
		case LootCrateType.Gold:
			audioSource = this.gameData.commonAudioCollection.goldenCrateHits[index];
			break;
		case LootCrateType.Glass:
			audioSource = this.gameData.commonAudioCollection.glassCrateHits[index];
			break;
		case LootCrateType.Marble:
			audioSource = this.gameData.commonAudioCollection.marbleCrateHits[index];
			break;
		}
		if (audioSource != null)
		{
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(audioSource);
		}
	}

	private void OnAnimationEvent(Spine.AnimationState state, int trackIndex, Spine.Event e)
	{
		string name = e.Data.Name;
		if (name != null)
		{
			if (!(name == "Pillow_Drop"))
			{
				if (!(name == "Crate_Drop"))
				{
					if (!(name == "Crate_Explosion"))
					{
						if (name == "Item_Bounce")
						{
							AudioSource[] rewardBounce = this.gameData.commonAudioCollection.rewardBounce;
							Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(rewardBounce[UnityEngine.Random.Range(0, rewardBounce.Length)]);
							if (this.bounceEffect)
							{
								this.bounceEffect.Emit(1);
							}
						}
					}
					else
					{
						if (this.explosionEffect)
						{
							this.explosionEffect.Emit(5);
						}
						AudioSource audioSource = Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.openLaugh[UnityEngine.Random.Range(0, this.openLaugh.Length)]);
						if (audioSource != null)
						{
							audioSource.transform.position = WPFMonoBehaviour.hudCamera.transform.position;
						}
					}
				}
				else
				{
					AudioSource[] cratePillowHit = this.gameData.commonAudioCollection.cratePillowHit;
					AudioSource audioSource2 = Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(cratePillowHit[UnityEngine.Random.Range(0, cratePillowHit.Length)]);
					if (audioSource2 != null)
					{
						audioSource2.transform.position = WPFMonoBehaviour.hudCamera.transform.position;
					}
					if (PlayerProgressBar.Instance && this.pillow && this.GainedXP > 0)
					{
						PlayerProgressBar.Instance.AddParticles(this.pillow, this.GainedXP, 0f, 0f, null);
					}
				}
			}
			else
			{
				AudioSource[] pillowDrops = this.gameData.commonAudioCollection.pillowDrops;
				AudioSource audioSource3 = Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(pillowDrops[UnityEngine.Random.Range(0, pillowDrops.Length)]);
				if (audioSource3 != null)
				{
					audioSource3.transform.position = WPFMonoBehaviour.hudCamera.transform.position;
				}
			}
		}
	}

	private IEnumerator DelayedPlay(SkeletonAnimation target, string animation, float delay)
	{
		for (float counter = 0f; counter < delay; counter += Time.unscaledDeltaTime)
		{
			yield return null;
		}
		target.state.SetAnimation(0, animation, false);
		yield break;
	}

	[SerializeField]
	private string[] skinNames;

	[SerializeField]
	private GameObject pointerPrefab;

	[SerializeField]
	private GameObject clickPrefab;

	[SerializeField]
	private Transform tutorialTarget;

	[SerializeField]
	private GameObject pillow;

	[SerializeField]
	private GameObject[] lootRewardPrefabs;

	[SerializeField]
	private GameObject backfacePrefab;

	[SerializeField]
	private SkeletonAnimation skeletonAnimation;

	[SerializeField]
	private float tutorialDelay;

	[SerializeField]
	private string introAnimationName;

	[SerializeField]
	private string idleAnimationName;

	[SerializeField]
	private string[] hitAnimationNames;

	[SerializeField]
	private string[] openAnimationNames;

	[SerializeField]
	private int maxRewardCount = 8;

	[SerializeField]
	private ParticleSystem explosionEffect;

	[SerializeField]
	private ParticleSystem bounceEffect;

	[SerializeField]
	private AudioSource[] openLaugh;

	private Transform[] iconRoots;

	private Transform[] backfaceRoots;

	private List<LootRewardElement> rewardElements;

	private Tutorial.Pointer pointer;

	private Tutorial.PointerTimeLine tutorial;

	private bool tutorialRunning;

	private bool canBeHit;

	private int hitCounter;

	private int openIndex = -1;

	private Collider collider;

	private LootCrateType lootCrateType;

	private GameData gameData;

	public Action onOpeningDone;

	public Action onOpeningStart;
}
