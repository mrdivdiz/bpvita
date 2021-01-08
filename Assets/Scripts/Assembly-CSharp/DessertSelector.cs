using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DessertSelector : MonoBehaviour, WidgetListener
{
	private void Awake()
	{
		if (DeviceInfo.IsDesktop)
		{
			this.m_PrizeProbability = this.m_PrizeProbabilityDesktop;
		}
		this.m_scrollList = this.m_menu.transform.Find("ScrollList").GetComponent<ScrollList>();
		this.m_scrollList.SetListener(this);
		this.m_hudCam = Singleton<GuiManager>.Instance.FindCamera();
		this.m_mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		this.m_kingPig = (UnityEngine.Object.FindObjectOfType(typeof(KingPig)) as KingPig).gameObject;
		CapsuleCollider component = GameObject.FindGameObjectWithTag("KingPigMouth").GetComponent<CapsuleCollider>();
		component.enabled = true;
		this.m_CurGrowScale = GameProgress.GetFloat("KingPigFeedScale", this.m_InitialScale, GameProgress.Location.Local, null);
		this.m_kingPig.transform.parent.localScale = this.m_CurGrowScale * Vector3.one;
		int value = Singleton<GameConfigurationManager>.Instance.GetValue<int>("king_pig_prize_probabilities", "Prize");
		if (value > 0)
		{
			this.m_PrizeProbability = (float)value / 100f;
		}
		float num = 0f;
		List<FeedingPrize> list;
		if (Singleton<BuildCustomizationLoader>.Instance.IsChina)
		{
			list = this.m_FeedingPrizesChina;
		}
		else if (Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			list = this.m_FeedingPrizesOdyssey;
		}
		else
		{
			list = this.m_FeedingPrizes;
		}
		foreach (FeedingPrize feedingPrize in list)
		{
			int value2 = Singleton<GameConfigurationManager>.Instance.GetValue<int>("king_pig_prize_probabilities", feedingPrize.type.ToString());
			if (value2 > 0)
			{
				feedingPrize.rangeWidth = (float)value2;
			}
			num += feedingPrize.rangeWidth;
		}
		this.m_totalRangeWidth = num;
		ScrapButton.Instance.EnableButton(false);
	}

	private void Start()
	{
		this.CreateDessertButtonList();
		this.m_kingPig.GetComponent<KingPig>().SetExpression(Pig.Expressions.Normal);
		KeyListener.keyPressed += this.HandleKeyPressed;
	}

	private void OnDestroy()
	{
		KeyListener.keyPressed -= this.HandleKeyPressed;
	}

	private void CreateDessertButtonList()
	{
		this.availableDessertsCount = 0;
		foreach (GameObject gameObject in this.m_gameData.m_desserts)
		{
			int num = GameProgress.DessertCount(gameObject.GetComponent<Dessert>().saveId);
			this.availableDessertsCount += num;
			if (num > 0)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.m_dessertButtonPrefab);
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(gameObject.GetComponent<Dessert>().prefabIcon);
				gameObject3.transform.parent = gameObject2.transform;
				gameObject3.transform.localScale = new Vector3(1.75f, 1.75f, 1f);
				gameObject3.transform.localPosition = new Vector3(0f, 0f, -0.1f);
				gameObject3.GetComponent<MeshRenderer>().sortingOrder = 1;
				gameObject2.GetComponent<DraggableButton>().Icon = gameObject3;
				gameObject2.GetComponent<DraggableButton>().DragIconPrefab = gameObject3;
				gameObject2.GetComponent<DraggableButton>().DragIconScale = 1.75f;
				gameObject2.GetComponent<DraggableButton>().DragObject = gameObject;
				Transform transform = gameObject2.transform.Find("PartCount");
				transform.GetComponent<TextMesh>().text = num.ToString();
				transform.GetComponent<MeshRenderer>().sortingOrder = 3;
				gameObject2.transform.parent = this.m_scrollList.transform;
				this.m_scrollList.AddButton(gameObject2.GetComponent<Widget>());
			}
		}
	}

	public void Select(Widget widget, object targetObject)
	{
	}

	public void StartDrag(Widget widget, object targetObject)
	{
		this.SetIdle(false);
		KingPig component = this.m_kingPig.GetComponent<KingPig>();
		component.followMouse = true;
		if (!this.IsEating())
		{
			component.SetExpression(Pig.Expressions.WaitForFood);
		}
		this.m_defaultExpression = Pig.Expressions.WaitForFood;
		EventManager.Send(new DragStartedEvent(BasePart.PartType.Balloon));
		this.m_draggingDessert = true;
		this.m_waitForFoodTimer = 1.5f;
	}

	public void CancelDrag(Widget widget, object targetObject)
	{
		this.SetIdle(true);
		this.m_kingPig.GetComponent<KingPig>().followMouse = false;
		if (!this.IsEating())
		{
			this.m_kingPig.GetComponent<KingPig>().SetExpression(Pig.Expressions.Normal);
		}
		this.m_defaultExpression = Pig.Expressions.Normal;
		this.m_draggingDessert = false;
	}

	private void DelayAction(Action action, float time = 1f)
	{
		base.StartCoroutine(this.DelayActionCorutine(action, time));
	}

	private IEnumerator DelayActionCorutine(Action action, float time)
	{
		yield return new WaitForSeconds(time);
		action();
		yield break;
	}

	public void Drop(Widget widget, Vector3 position, object targetObject)
	{
		this.SetIdle(true);
		this.m_kingPig.GetComponent<KingPig>().followMouse = false;
		this.m_defaultExpression = Pig.Expressions.Normal;
		this.m_draggingDessert = false;
		Vector3 vector = this.m_hudCam.WorldToScreenPoint(position);
		Vector3 position2 = this.m_mainCam.ScreenToWorldPoint(vector);
		position2.z = this.m_kingPig.transform.position.z;
		Rect rect = new Rect(0f, 0f, (float)this.m_hudCam.pixelWidth, (float)this.m_hudCam.pixelHeight);
		if (this.m_FoodPrefab && rect.Contains(vector))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_FoodPrefab, position2, Quaternion.identity);
			gameObject.GetComponent<DessertFood>().m_DessertButton = widget;
			gameObject.GetComponent<DessertFood>().m_DessertSelector = this;
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(widget.GetComponent<DraggableButton>().Icon, position2, Quaternion.identity);
			gameObject2.transform.parent = gameObject.transform;
			gameObject2.layer = 0;
			gameObject2.transform.localScale = new Vector3(2.5f, 2.5f, 1f);
			this.m_dessertInScene = gameObject;
		}
	}

	private void SetButtonCount(Widget button, int count)
	{
		Transform transform = button.transform.Find("PartCount");
		transform.GetComponent<TextMesh>().text = count.ToString();
	}

	private string GetKingPigTotalText()
	{
		return GameProgress.EatenDessertsCount().ToString();
	}

	private FeedingPrize SelectFeedingPrize()
	{
		float num = UnityEngine.Random.value * this.m_totalRangeWidth;
		float num2 = 0f;
		List<FeedingPrize> list;
		if (Singleton<BuildCustomizationLoader>.Instance.IsChina)
		{
			list = this.m_FeedingPrizesChina;
		}
		else if (Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
		{
			list = this.m_FeedingPrizesOdyssey;
		}
		else
		{
			list = this.m_FeedingPrizes;
		}
		foreach (FeedingPrize feedingPrize in list)
		{
			num2 += feedingPrize.rangeWidth;
			if (num <= num2)
			{
				return feedingPrize;
			}
		}
		return null;
	}

	private void CheckAchievements()
	{
		if (Singleton<SocialGameManager>.IsInstantiated())
		{
			Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.FEEDER", 100.0, (int limit) => GameProgress.EatenDessertsCount() >= limit);
		}
	}

	private FeedingPrize.PrizeType GiveReward(GameObject dessert)
	{
		FeedingPrize.PrizeType result = FeedingPrize.PrizeType.None;
		int num = GameProgress.EatenDessertsCount();
		if (UnityEngine.Random.value < this.m_PrizeProbability || num <= 1 || dessert.name == "GoldenCake")
		{
			FeedingPrize feedingPrize;
			if (num <= 1)
			{
                feedingPrize = null;
                foreach (FeedingPrize x in this.m_FeedingPrizes)
                {
                    if (x.type == FeedingPrize.PrizeType.SuperGlue)
                    {
                        feedingPrize = x;
                        break;
                    }
                }
			}
			else
			{
				feedingPrize = this.SelectFeedingPrize();
			}
			FeedingPrize feedingPrize2 = feedingPrize;
			if (dessert.name == "GoldenCake" && feedingPrize2.type == FeedingPrize.PrizeType.Junk)
			{
				feedingPrize2 = this.m_FeedingPrizes[1];
			}
			if (feedingPrize2 != null)
			{
				if (feedingPrize2.type != FeedingPrize.PrizeType.Junk && feedingPrize2.type != FeedingPrize.PrizeType.None)
				{
					GameObject gameObject = this.m_Reward.transform.Find("Offset/AnimationNode").gameObject;
					if (gameObject.transform.childCount > 0)
					{
						UnityEngine.Object.Destroy(gameObject.transform.GetChild(0).gameObject);
					}
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(feedingPrize2.icon, gameObject.transform.position, gameObject.transform.rotation);
					gameObject2.transform.parent = gameObject.transform;
					gameObject2.transform.localScale = Vector3.one * feedingPrize2.iconScale;
					CurrencyParticleBurst burst = null;
					string text = "King Pig feeding prize";
					switch (feedingPrize2.type)
					{
					case FeedingPrize.PrizeType.SuperGlue:
						GameProgress.AddSuperGlue(1);
						if (Singleton<IapManager>.Instance != null)
						{
							Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.SuperGlueSingle, 1, text);
						}
						break;
					case FeedingPrize.PrizeType.SuperMagnet:
						GameProgress.AddSuperMagnet(1);
						if (Singleton<IapManager>.Instance != null)
						{
							Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.SuperMagnetSingle, 1, text);
						}
						break;
					case FeedingPrize.PrizeType.TurboCharge:
						GameProgress.AddTurboCharge(1);
						if (Singleton<IapManager>.Instance != null)
						{
							Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.TurboChargeSingle, 1, text);
						}
						break;
					case FeedingPrize.PrizeType.SuperMechanic:
						GameProgress.AddBluePrints(1);
						if (Singleton<IapManager>.Instance != null)
						{
							Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.BlueprintSingle, 1, text);
						}
						break;
					case FeedingPrize.PrizeType.NightVision:
						GameProgress.AddNightVision(1);
						if (Singleton<IapManager>.Instance != null)
						{
							Singleton<IapManager>.Instance.SendFlurryInventoryGainEvent(IapManager.InAppPurchaseItemType.NightVisionSingle, 1, text);
						}
						break;
					case FeedingPrize.PrizeType.SnoutCoins:
					{
						int value = Singleton<GameConfigurationManager>.Instance.GetValue<int>("king_pig_snout_reward", "min");
						int value2 = Singleton<GameConfigurationManager>.Instance.GetValue<int>("king_pig_snout_reward", "max");
						int num2 = UnityEngine.Random.Range(value, value2 + 1);
						if (num2 > 0)
						{
							if (Singleton<DoubleRewardManager>.Instance.HasDoubleReward)
							{
								num2 *= 2;
							}
							GameProgress.AddSnoutCoins(num2);
							GameObject gameObject3 = GameObject.FindGameObjectWithTag("KingPigMouth");
							if (gameObject3 != null)
							{
								Camera main = Camera.main;
								Camera camera = Singleton<GuiManager>.Instance.FindCamera();
								if (main == null || camera == null)
								{
									break;
								}
								Vector3 a = gameObject3.transform.position * (1f / main.orthographicSize);
								gameObject2.transform.parent = null;
								gameObject2.transform.position = a * camera.orthographicSize;
							}
							burst = gameObject2.GetComponent<CurrencyParticleBurst>();
							if (burst != null)
							{
								burst.SetBurst(num2, 10f, true);
							}
						}
						break;
					}
					case FeedingPrize.PrizeType.Scrap:
					{
						int value3 = Singleton<GameConfigurationManager>.Instance.GetValue<int>("king_pig_scrap_reward", "min");
						int value4 = Singleton<GameConfigurationManager>.Instance.GetValue<int>("king_pig_scrap_reward", "max");
						int num3 = UnityEngine.Random.Range(value3, value4 + 1);
						if (num3 > 0)
						{
							GameProgress.AddScrap(num3);
							GameObject gameObject4 = GameObject.FindGameObjectWithTag("KingPigMouth");
							if (gameObject4 != null)
							{
								Camera main2 = Camera.main;
								Camera camera2 = Singleton<GuiManager>.Instance.FindCamera();
								if (main2 == null || camera2 == null)
								{
									break;
								}
								Vector3 a2 = gameObject4.transform.position * (1f / main2.orthographicSize);
								gameObject2.transform.parent = null;
								gameObject2.transform.position = a2 * camera2.orthographicSize;
							}
							burst = gameObject2.GetComponent<CurrencyParticleBurst>();
							if (burst != null)
							{
								burst.SetBurst(num3, 10f, true);
							}
						}
						break;
					}
					}
					if (feedingPrize2.type == FeedingPrize.PrizeType.SnoutCoins || feedingPrize2.type == FeedingPrize.PrizeType.Scrap)
					{
						this.DelayAction(delegate
						{
							if (burst != null)
							{
								burst.Burst();
							}
						}, 1.3f);
					}
					else
					{
						this.DelayAction(delegate
						{
							this.m_Reward.SetActive(true);
						}, this.m_GrowDuration);
					}
					if (PlayerProgressBar.Instance != null && Singleton<PlayerProgress>.IsInstantiated())
					{
						GameObject gameObject5 = GameObject.FindGameObjectWithTag("KingPigMouth");
						Vector3 vector = gameObject5.transform.position * (1f / this.m_mainCam.orthographicSize);
						vector *= this.m_hudCam.orthographicSize;
						PlayerProgressBar.Instance.DelayUpdate();
						int amount = Singleton<PlayerProgress>.Instance.AddExperience(PlayerProgress.ExperienceType.KingBurp);
						PlayerProgressBar.Instance.AddParticles(vector, amount, 1.3f, 0f, null);
					}
					if (Singleton<SocialGameManager>.IsInstantiated())
					{
						Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.KINGS_FAVORITE", 100.0);
					}
				}
				result = feedingPrize2.type;
			}
		}
		return result;
	}

	public bool IsEating()
	{
		return this.isEating;
	}

	private void SetIdle(bool isEnabled)
	{
		if (this.m_IsIdleEnabled != isEnabled)
		{
			if (isEnabled)
			{
				this.m_IdleTime = 0f;
			}
			this.m_IsIdleEnabled = isEnabled;
		}
	}

	private IEnumerator PlayChewingAnim(float time)
	{
		KingPig kp = this.m_kingPig.GetComponent<KingPig>();
		this.PlayKingPigExpressionAudioEffect(Pig.Expressions.Chew);
		yield return base.StartCoroutine(kp.PlayAnimation(Pig.Expressions.Chew, time));
		kp.SetExpression(this.m_defaultExpression);
		yield break;
	}

	private IEnumerator PlayChewThenShrinkAndBurpAnim(float chewTime, float burpTime, FeedingPrize.PrizeType prizeType)
	{
		KingPig kp = this.m_kingPig.GetComponent<KingPig>();
		this.PlayKingPigExpressionAudioEffect(Pig.Expressions.Chew);
		yield return base.StartCoroutine(kp.PlayAnimation(Pig.Expressions.Chew, chewTime));
		this.DelayAction(delegate
		{
			this.scaleAnimTime = 0f;
			if (prizeType == FeedingPrize.PrizeType.Junk || prizeType == FeedingPrize.PrizeType.None)
			{
				GameObject gameObject = GameObject.FindGameObjectWithTag("KingPigMouth");
				int num = UnityEngine.Random.Range(0, this.m_JunkPrizes.Length);
				Vector3 position = gameObject.transform.position;
				position.z = -2f;
				UnityEngine.Object.Instantiate<GameObject>(this.m_JunkPrizes[num], position, Quaternion.identity);
			}
		}, 0.2f);
		this.PlayKingPigExpressionAudioEffect(Pig.Expressions.Burp);
		yield return base.StartCoroutine(kp.PlayAnimation(Pig.Expressions.Burp, burpTime));
		kp.SetExpression(this.m_defaultExpression);
		yield break;
	}

	private IEnumerator PlayMissAnim(float time)
	{
		KingPig kp = this.m_kingPig.GetComponent<KingPig>();
		this.PlayKingPigExpressionAudioEffect(Pig.Expressions.Fear);
		yield return base.StartCoroutine(kp.PlayAnimation(Pig.Expressions.Fear, time));
		kp.SetExpression(this.m_defaultExpression);
		yield break;
	}

	private IEnumerator PlayIdleAnim()
	{
		KingPig kp = this.m_kingPig.GetComponent<KingPig>();
		Pig.Expressions idleExp = this.m_IdleExpressions[UnityEngine.Random.Range(0, this.m_IdleExpressions.Length)];
		this.PlayKingPigExpressionAudioEffect(idleExp);
		yield return base.StartCoroutine(kp.PlayAnimation(idleExp));
		kp.SetExpression(this.m_defaultExpression);
		yield break;
	}

	private void PlayKingPigExpressionAudioEffect(Pig.Expressions expr)
	{
		if (this.m_LastExpressionSound)
		{
			if (this.m_LastAudioExpression == expr)
			{
				return;
			}
			if (this.m_LastAudioExpression == Pig.Expressions.WaitForFood)
			{
				this.m_LastExpressionSound.Stop();
			}
		}
		PigExpressionSound pigExpressionSound = null;
        foreach (PigExpressionSound x in this.expressionSounds)
        {
            if (x.expression == expr)
            {
                pigExpressionSound = x;
                break;
            }
        }
		if (pigExpressionSound != null && pigExpressionSound.soundFx != null && pigExpressionSound.soundFx.Length > 0)
		{
			AudioSource effectSource = pigExpressionSound.soundFx[UnityEngine.Random.Range(0, pigExpressionSound.soundFx.Length)];
			this.m_LastExpressionSound = Singleton<AudioManager>.Instance.Play2dEffect(effectSource);
			this.m_LastAudioExpression = expr;
		}
	}

	public void MissDessert(Widget widget)
	{
		if (this.IsEating())
		{
			return;
		}
		this.m_defaultExpression = Pig.Expressions.Normal;
		base.StartCoroutine(this.PlayMissAnim(0.5f));
	}

	public void EatDessert(Widget widget)
	{
		if (this.IsEating() || widget == null)
		{
			return;
		}
		this.isEating = true;
		GameObject gameObject = (GameObject)widget.GetComponent<DraggableButton>().DragObject;
		GameProgress.EatDesserts(gameObject.GetComponent<Dessert>().saveId, 1);
		int num = GameProgress.DessertCount(gameObject.GetComponent<Dessert>().saveId);
		this.SetButtonCount(widget, num);
		this.CheckAchievements();
		this.availableDessertsCount--;
		base.StartCoroutine(this.PlayChewingAnim(1f));
		if (num <= 0)
		{
			if (widget.GetComponent<DraggableButton>().isDragging)
			{
				this.CancelDrag(widget, null);
			}
			this.m_scrollList.RemoveButton(widget);
		}
		FeedingPrize.PrizeType prizeType = this.GiveReward(gameObject);
		this.m_CurGrowScale = this.m_CurGrowScale * this.m_GrowStepMul + this.m_GrowStepAdd;
		if (this.m_CurGrowScale > this.m_GrowLimit || prizeType != FeedingPrize.PrizeType.None)
		{
			this.m_CurGrowScale = this.m_InitialScale;
			base.StartCoroutine(this.PlayChewThenShrinkAndBurpAnim(1f, this.m_GrowDuration, prizeType));
		}
		else
		{
			if (this.m_GrowSoundFx)
			{
				Singleton<AudioManager>.Instance.Play2dEffect(this.m_GrowSoundFx);
			}
			this.scaleAnimTime = 0f;
		}
		GameProgress.SetFloat("KingPigFeedScale", this.m_CurGrowScale, GameProgress.Location.Local);
		this.scaleStart = this.m_kingPig.transform.parent.localScale;
	}

	private void Update()
	{
		if (this.m_BuyButton != null)
		{
			if (Singleton<BuildCustomizationLoader>.Instance.IsChina && this.availableDessertsCount == 0)
			{
				this.m_BuyButton.SetActive(true);
			}
			else
			{
				this.m_BuyButton.SetActive(false);
			}
		}
		if (this.scaleAnimTime >= 0f)
		{
			this.scaleAnimTime += Time.deltaTime / this.m_GrowDuration;
			if (this.scaleAnimTime > 1f)
			{
				this.isEating = false;
				this.scaleAnimTime = -1f;
			}
			else
			{
				this.m_kingPig.transform.parent.localScale = Vector3.Lerp(this.scaleStart, Vector3.one * this.m_CurGrowScale, this.scaleAnimTime);
			}
		}
		if (this.m_IsIdleEnabled)
		{
			this.m_IdleTime += Time.deltaTime;
			if (this.m_IdleTime >= this.m_IdleTimeout)
			{
				this.m_IdleTime = this.m_IdleTimeout;
				this.m_IdleAnimTime += Time.deltaTime;
				if (this.m_IdleAnimTime > this.m_CurIdleAnimTimeOut)
				{
					this.m_IdleAnimTime = 0f;
					this.m_CurIdleAnimTimeOut = UnityEngine.Random.Range(this.m_IdleAnimTimeoutMin, this.m_IdleAnimTimeoutMax);
					base.StartCoroutine(this.PlayIdleAnim());
				}
			}
		}
		if (this.m_draggingDessert)
		{
			GuiManager.Pointer pointer = GuiManager.GetPointer();
			Vector3 position = this.m_mainCam.ScreenToWorldPoint(pointer.position);
			EventManager.Send(new DraggingPartEvent(BasePart.PartType.Balloon, position));
			KingPig component = this.m_kingPig.GetComponent<KingPig>();
			if (component.m_currentExpression == Pig.Expressions.Normal)
			{
				component.SetExpression(Pig.Expressions.WaitForFood);
			}
			if (component.m_currentExpression == Pig.Expressions.WaitForFood)
			{
				this.m_waitForFoodTimer -= Time.deltaTime;
				if (this.m_waitForFoodTimer <= 0f)
				{
					this.PlayKingPigExpressionAudioEffect(Pig.Expressions.WaitForFood);
					this.m_waitForFoodTimer = 7f;
				}
			}
		}
		else if (this.m_dessertInScene)
		{
			Vector3 position2 = this.m_dessertInScene.transform.position;
			EventManager.Send(new DraggingPartEvent(BasePart.PartType.Balloon, position2));
		}
	}

	private void HandleKeyPressed(KeyCode obj)
	{
	}

	private void OnApplicationPause(bool paused)
	{
		if (paused && this.m_scrollList)
		{
			this.m_scrollList.ResetSelection();
		}
	}

	public GameObject m_dessertButtonPrefab;

	public GameData m_gameData;

	public GameObject m_Reward;

	public GameObject m_FoodPrefab;

	public GameObject m_menu;

	public GameObject m_BuyButton;

	public float m_InitialScale = 3f;

	public float m_GrowStepMul = 1.1f;

	public float m_GrowStepAdd;

	public float m_GrowLimit = 6f;

	public float m_GrowDuration = 0.5f;

	private float m_CurGrowScale = 3f;

	private float scaleAnimTime = -1f;

	private Vector3 scaleStart = Vector3.one;

	private bool isEating;

	private Pig.Expressions m_defaultExpression;

	private bool m_draggingDessert;

	private float m_waitForFoodTimer;

	private GameObject m_dessertInScene;

	[Range(0f, 1f)]
	public float m_PrizeProbability = 0.1f;

	[Range(0f, 1f)]
	public float m_PrizeProbabilityDesktop = 0.25f;

	public List<FeedingPrize> m_FeedingPrizes = new List<FeedingPrize>();

	public List<FeedingPrize> m_FeedingPrizesChina = new List<FeedingPrize>();

	[SerializeField]
	private List<FeedingPrize> m_FeedingPrizesOdyssey = new List<FeedingPrize>();

	public GameObject[] m_JunkPrizes = new GameObject[0];

	private float m_totalRangeWidth = 100f;

	public float m_IdleTimeout = 5f;

	public float m_IdleAnimTimeoutMin = 5f;

	public float m_IdleAnimTimeoutMax = 10f;

	private float m_IdleTime;

	private float m_IdleAnimTime;

	private float m_CurIdleAnimTimeOut;

	private bool m_IsIdleEnabled = true;

	public Pig.Expressions[] m_IdleExpressions = new Pig.Expressions[]
	{
		Pig.Expressions.Blink,
		Pig.Expressions.Panting,
		Pig.Expressions.Laugh,
		Pig.Expressions.Snooze
	};

	public AudioSource m_GrowSoundFx;

	public PigExpressionSound[] expressionSounds;

	[HideInInspector]
	public readonly float KingPigInitialWeight = 100f;

	private ScrollList m_scrollList;

	private GameObject m_kingPig;

	private Camera m_hudCam;

	private Camera m_mainCam;

	private int availableDessertsCount;

	private GameObject m_Cursor;

	private AudioSource m_LastExpressionSound;

	private Pig.Expressions m_LastAudioExpression;
}
