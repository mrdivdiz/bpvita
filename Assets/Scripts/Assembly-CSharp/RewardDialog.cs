using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RewardDialog : MonoBehaviour
{
	private void Awake()
	{
		this.infoTxt = this.infoText.GetComponent<TextMesh>();
		this.infoTxt.text = string.Empty;
		this.claimBtnTxt = this.claimButtonText.GetComponent<TextMesh>();
		this.sb = new StringBuilder();
	}

	private void UpdateTextMeshLocale(TextMesh textMesh, string localeKey, int maxRowCharacters = -1, string postfix = "")
	{
		if (textMesh == null)
		{
			return;
		}
		textMesh.text = localeKey;
		TextMeshLocale component = textMesh.GetComponent<TextMeshLocale>();
		if (component != null)
		{
			component.RefreshTranslation(null);
			if (TextMeshHelper.UsesKanjiCharacters() && localeKey.Equals("REWARD_DAY"))
			{
				component.Postfix = string.Empty;
				textMesh.text = string.Format(textMesh.text, postfix.Replace(" ", string.Empty));
			}
			else
			{
				component.Postfix = ((!string.IsNullOrEmpty(postfix)) ? postfix : string.Empty);
			}
		}
		TextMeshHelper.Wrap(textMesh, maxRowCharacters, false);
	}

	private void OnApplicationFocus(bool focus)
	{
		if (focus)
		{
			this.UpdateTextMeshLocale(this.errorText, "REWARD_ERROR", 24, string.Empty);
		}
	}

	private void Start()
	{
		this.PopulateDailyRewards();
		this.UpdateScales();
		base.gameObject.SetActive(false);
	}

	private void OnEnable()
	{
		Singleton<GuiManager>.Instance.GrabPointer(this);
		Singleton<KeyListener>.Instance.GrabFocus(this);
		KeyListener.keyReleased += this.HandleKeyReleased;
		if (!Singleton<RewardSystem>.IsInstantiated())
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		base.StartCoroutine(this.OnEnableRoutine());
	}

	private void OnDisable()
	{
		RewardSystem.FreezeResetTime = false;
		base.StopAllCoroutines();
		if (Singleton<GuiManager>.Instance != null)
		{
			Singleton<GuiManager>.Instance.ReleasePointer(this);
		}
		if (Singleton<KeyListener>.Instance != null)
		{
			Singleton<KeyListener>.Instance.ReleaseFocus(this);
		}
		KeyListener.keyReleased -= this.HandleKeyReleased;
	}

	private IEnumerator OnEnableRoutine()
	{
		this.loadingIcon.gameObject.SetActive(true);
		this.rewardContainer.gameObject.SetActive(false);
		this.infoTxt.text = string.Empty;
		this.claimButtonRenderer.gameObject.SetActive(false);
		this.closeButton.gameObject.SetActive(false);
		this.errorText.GetComponent<Renderer>().enabled = false;
		this.hideFirstDayMask.enabled = true;
		this.timedOut = false;
		Singleton<RewardSystem>.Instance.RefreshData();
		this.panel.width = 16f;
		this.SetDayTexts(2);
		yield return null;
		this.SetDayTexts(-1);
		this.centerDayBG.localScale = Vector3.one + Vector3.right * 0.8f;
		float timeLeftToShowCloseButton = 2f;
		bool isShowingCloseButton = false;
		bool canShowCloseButton = true;
		float timeCounter = 0f;
		if (Application.internetReachability == NetworkReachability.NotReachable)
		{
			timeCounter = this.waitTime;
		}
		while (!Singleton<RewardSystem>.Instance.HasTime)
		{
			timeLeftToShowCloseButton -= Time.unscaledDeltaTime;
			if (!isShowingCloseButton && timeLeftToShowCloseButton <= 0f)
			{
				isShowingCloseButton = false;
				this.closeButton.gameObject.SetActive(true);
			}
			timeCounter += Time.unscaledDeltaTime;
			if (timeCounter > this.waitTime)
			{
				isShowingCloseButton = false;
				this.errorText.GetComponent<Renderer>().enabled = true;
				this.closeButton.gameObject.SetActive(true);
				this.loadingIcon.gameObject.SetActive(false);
				this.timedOut = true;
				yield return null;
				this.UpdateTextMeshLocale(this.errorText, "REWARD_ERROR", 24, string.Empty);
				yield break;
			}
			yield return null;
		}
		if (Singleton<RewardSystem>.Instance.IsRewardReady())
		{
			this.ReadyToClaim();
		}
		else
		{
			this.claimBtnTxt.text = string.Empty;
		}
		if (this.claimRewardSequencePlaying || this.waitingToClaimReward)
		{
			canShowCloseButton = false;
			this.closeButton.gameObject.SetActive(false);
		}
		RewardSystem.FreezeResetTime = true;
		this.rewardContainer.gameObject.SetActive(true);
		this.claimButtonRenderer.gameObject.SetActive(true);
		this.loadingIcon.gameObject.SetActive(false);
		this.PopulateDailyRewards();
		this.UpdateScales();
		this.SetDayActive(RewardSystem.CurrentLevel, true);
		if (!isShowingCloseButton && canShowCloseButton)
		{
			while (timeLeftToShowCloseButton > 0f)
			{
				timeLeftToShowCloseButton -= Time.deltaTime;
				yield return null;
			}
			this.closeButton.gameObject.SetActive(true);
		}
		yield break;
	}

	private void Update()
	{
		this.UpdateClaimText();
	}

	private void SetInfoText(PrizeType prizeType, bool isBundle = false)
	{
		string localeKey = string.Empty;
		if (isBundle)
		{
			localeKey = this.BundleRewardInfo;
		}
		else
		{
			if (!this.RewardInfos.ContainsKey(prizeType))
			{
				this.infoTxt.text = string.Empty;
				return;
			}
			localeKey = this.RewardInfos[prizeType];
		}
		this.UpdateTextMeshLocale(this.infoTxt, localeKey, (!Singleton<Localizer>.Instance.CurrentLocale.Equals("ja-JP")) ? 24 : 18, string.Empty);
	}

	private void PopulateDailyRewards()
	{
		List<DailyRewardBundle> rewards = Singleton<RewardSystem>.Instance.Rewards;
		if (this.dailyRewards != null)
		{
			for (int i = 0; i < this.dailyRewards.Length; i++)
			{
				if (this.dailyRewards[i] != null)
				{
					UnityEngine.Object.Destroy(this.dailyRewards[i].gameObject);
				}
			}
		}
		this.dailyRewards = new Transform[rewards.Count];
		UnityEngine.Object original = Resources.Load("UI/Amazon/DailyReward");
		for (int j = 0; j < rewards.Count; j++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(original) as GameObject;
			gameObject.transform.parent = this.rewardContainer.transform;
			gameObject.transform.localPosition = new Vector3((float)j * 6.8f, 0f);
			gameObject.layer = this.rewardContainer.gameObject.layer;
			Reward component = gameObject.GetComponent<Reward>();
			component.SetRewards(rewards[j].GetRewards(j));
			component.SetState(RewardSystem.GetRewardStateForDay(j));
			this.dailyRewards[j] = gameObject.transform;
		}
	}

	public void ClaimReward()
	{
		if (this.claimRewardSequencePlaying)
		{
			return;
		}
		if (Singleton<RewardSystem>.Instance.IsRewardReady())
		{
			this.claimBtnTxt.text = string.Empty;
			this.claimButtonSprite.m_id = this.claimButtonInactiveSprite;
			this.claimButtonSprite.RebuildMesh();
			this.claimButtonRenderer.gameObject.SetActive(false);
			this.SetDayActive(RewardSystem.CurrentLevel, false);
			Singleton<RewardSystem>.Instance.ClaimReward();
			if (this.collectSound != null && this.collectSound.GetComponent<AudioSource>() != null)
			{
				Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.collectSound.GetComponent<AudioSource>());
			}
		}
	}

	public void Open()
	{
		base.gameObject.SetActive(true);
		this.mainMenu.gameObject.SetActive(false);
	}

	public void Close()
	{
		if (this.waitingToClaimReward)
		{
			return;
		}
		RewardSystem.FreezeResetTime = false;
		base.gameObject.SetActive(false);
		this.mainMenu.gameObject.SetActive(true);
	}

	public void SetDayActive(int day, bool instant)
	{
		if (instant)
		{
			this.rewardContainer.localPosition = new Vector3(-(float)day * 6.8f, this.rewardContainer.localPosition.y);
			this.UpdateScales();
			this.panel.width = ((day > 0) ? 21f : 16f);
			this.hideFirstDayMask.enabled = (day <= 0);
			this.centerDayBG.localScale = Vector3.one + Vector3.right * ((day > 0) ? 0f : 0.8f);
			this.SetDayTexts(day);
			if (!Singleton<RewardSystem>.Instance.IsRewardReady())
			{
				this.UpdateTextMeshLocale(this.infoTxt, "REWARD_LATER", (!Singleton<Localizer>.Instance.CurrentLocale.Equals("ja-JP")) ? 24 : 18, string.Empty);
			}
		}
		else
		{
			Singleton<RewardSystem>.Instance.StartCoroutine(this.SetDay(day));
		}
	}

	private IEnumerator SetDay(int day)
	{
		this.closeButton.gameObject.SetActive(false);
		this.claimRewardSequencePlaying = true;
		this.waitingToClaimReward = false;
		yield return Singleton<RewardSystem>.Instance.StartCoroutine(this.ClaimRewardSequence(day));
		if (day + 1 >= RewardSystem.AmountOfDays)
		{
			Singleton<RewardSystem>.Instance.RefreshData();
			this.PopulateDailyRewards();
			day = -1;
		}
		bool isShowingCloseButton = false;
		float timeLeftToShowCloseButton = 2f;
		while (!Singleton<RewardSystem>.Instance.HasTime)
		{
			timeLeftToShowCloseButton -= Time.deltaTime;
			if (!isShowingCloseButton && timeLeftToShowCloseButton <= 0f)
			{
				isShowingCloseButton = false;
				this.closeButton.gameObject.SetActive(true);
			}
			yield return null;
		}
		float targetX = -(float)(day + 1) * 6.8f;
		float counter = 0f;
		float moveDistance = Mathf.Abs(this.rewardContainer.localPosition.x) - Mathf.Abs(targetX);
		float startX = this.rewardContainer.localPosition.x;
		if (this.moveSound != null && this.moveSound.GetComponent<AudioSource>() != null)
		{
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(this.moveSound.GetComponent<AudioSource>());
		}
		float startingPanelWidth = this.panel.width;
		float panelTargetWidth = (day >= 0) ? 21f : 16f;
		float startingDayBGWidth = this.centerDayBG.localScale.x - 1f;
		float dayBGTargetWidth = (day >= 0) ? 0f : 0.8f;
		bool updatedDayTexts = false;
		while (counter < this.translationTime)
		{
			this.panel.width = Mathf.Lerp(startingPanelWidth, panelTargetWidth, counter / (this.translationTime * 0.5f));
			this.centerDayBG.localScale = Vector3.one + Vector3.right * Mathf.Lerp(startingDayBGWidth, dayBGTargetWidth, (counter + 0.2f) / this.translationTime);
			this.rewardContainer.localPosition = new Vector3(startX + this.translationCurve.Evaluate(counter) * moveDistance, this.rewardContainer.localPosition.y, 0f);
			this.UpdateScales();
			if (!updatedDayTexts && counter > this.translationTime * 0.25f)
			{
				this.hideFirstDayMask.enabled = false;
				updatedDayTexts = true;
				this.SetDayTexts(day + 1);
			}
			yield return null;
			counter += Time.deltaTime;
		}
		this.hideFirstDayMask.enabled = (day < 0);
		this.panel.width = panelTargetWidth;
		this.rewardContainer.localPosition = new Vector3(targetX, this.rewardContainer.localPosition.y);
		this.UpdateScales();
		this.UpdateTextMeshLocale(this.infoTxt, "REWARD_LATER", (!Singleton<Localizer>.Instance.CurrentLocale.Equals("ja-JP")) ? 24 : 18, string.Empty);
		this.claimRewardSequencePlaying = false;
		this.claimButtonRenderer.gameObject.SetActive(true);
		this.closeButton.gameObject.SetActive(true);
		yield break;
	}

	private void SetDayTexts(int day)
	{
		for (int i = 0; i < this.dayTexts.Length; i++)
		{
			this.dayTexts[i].transform.parent.gameObject.SetActive((day == 0 && i == 1) || day > 0);
			int num = day + i;
			if (num < 1 || num > 30)
			{
				this.dayTexts[i].text = "-";
			}
			else if (i == 1 && day == 0)
			{
				this.dayTexts[i].transform.localScale = Vector3.one * this.GetLocalizationScale(true);
				this.SetDayText(this.dayTexts[i], "REWARD_FIRST_DAY", -1);
			}
			else
			{
				this.dayTexts[i].transform.localScale = Vector3.one * this.GetLocalizationScale(false);
				this.SetDayText(this.dayTexts[i], "REWARD_DAY", num);
			}
		}
	}

	private float GetLocalizationScale(bool firstDay)
	{
		if (Singleton<Localizer>.Instance == null)
		{
			return (!firstDay) ? 0.8f : 0.65f;
		}
		string currentLocale = Singleton<Localizer>.Instance.CurrentLocale;
		if (currentLocale != null)
		{
			if (currentLocale == "en-EN")
			{
				return (!firstDay) ? 1f : 0.8f;
			}
			if (currentLocale == "ja-JP")
			{
				return (!firstDay) ? 0.9f : 0.9f;
			}
			if (currentLocale == "zh-CN")
			{
				return (!firstDay) ? 1.3f : 1f;
			}
		}
		return (!firstDay) ? 0.8f : 0.65f;
	}

	private void SetDayText(TextMesh tm, string localeKey, int day)
	{
		this.UpdateTextMeshLocale(tm, localeKey, -1, (day <= 0) ? string.Empty : string.Format(" {0}", day));
	}

	private IEnumerator ClaimRewardSequence(int day)
	{
		if (this.dailyRewards == null || day < 0 || day >= this.dailyRewards.Length)
		{
			yield break;
		}
		Reward reward = this.dailyRewards[day].GetComponent<Reward>();
		if (reward == null || reward.RewardIcon == null)
		{
			yield break;
		}
		List<DailyReward> dailyReward = Singleton<RewardSystem>.Instance.Rewards[day].GetRewards(day);
		bool isBundle = dailyReward.Count > 1;
		foreach (DailyReward rew in dailyReward)
		{
			Animation rewardAnim = reward.GetComponentInChildren<Animation>();
			if (rewardAnim != null)
			{
				rewardAnim.Play();
			}
			Transform rewardTf = null;
			if (isBundle)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(reward.GetRewardPrefab(rew.prize), reward.RewardIcon.transform.position, Quaternion.identity);
				rewardTf = gameObject.transform;
			}
			else
			{
				rewardTf = reward.RewardIcon.transform;
			}
			reward.RewardIcon.claimNowSprite.SetActive(true);
			reward.RewardIcon.disabledSprite.SetActive(false);
			Vector3 originalIconPosition = rewardTf.localPosition;
			float startYIcon = originalIconPosition.y;
			Vector3 originalCountPosition = reward.RewardCount.transform.localPosition;
			float startYCount = originalCountPosition.y;
			reward.SetRewardCount(rew.prizeCount, "+");
			float fade = 0f;
			while (fade < 1f)
			{
				rewardTf.localPosition = new Vector3(rewardTf.localPosition.x, startYIcon + this.translationCurve.Evaluate(fade) * 2f, originalIconPosition.z - 0.5f);
				reward.RewardCount.transform.localPosition = new Vector3(reward.RewardCount.transform.localPosition.x, startYCount + this.translationCurve.Evaluate(fade) * 2f, originalCountPosition.z - 1f);
				fade += Time.deltaTime;
				yield return null;
			}
			rewardTf.localPosition = originalIconPosition;
			reward.RewardCount.transform.localPosition = originalCountPosition;
			if (isBundle)
			{
				UnityEngine.Object.Destroy(rewardTf.gameObject);
			}
		}
		reward.SetState(RewardSystem.GetRewardStateForDay(day));
		yield return new WaitForSeconds(0.2f);
		yield break;
	}

	private void UpdateScales()
	{
		if (this.dailyRewards == null)
		{
			return;
		}
		for (int i = 0; i < this.dailyRewards.Length; i++)
		{
			float num = Mathf.Clamp(Mathf.Abs(this.dailyRewards[i].position.x - base.transform.position.x), 0f, 11f) / 11f;
			num = this.scalingCurve.Evaluate(num);
			this.dailyRewards[i].localScale = new Vector3(num, num, 1f);
		}
	}

	private void UpdateClaimText()
	{
		if (this.timedOut || this.waitingToClaimReward || this.claimRewardSequencePlaying || !Singleton<RewardSystem>.Instance.HasTime)
		{
			return;
		}
		int num = Singleton<RewardSystem>.Instance.SecondsToNextReward();
		if (num == this.lastTimeUpdated)
		{
			return;
		}
		this.lastTimeUpdated = num;
		if (num > 0)
		{
			TimeSpan timeSpan = new TimeSpan(0, 0, num);
			this.sb.Remove(0, this.sb.Length);
			int num2 = Mathf.RoundToInt((float)timeSpan.TotalHours);
			int minutes = timeSpan.Minutes;
			int seconds = timeSpan.Seconds;
			if (num2 > 0)
			{
				this.sb.Append(string.Format("{0}h ", num2));
			}
			if (minutes > 0)
			{
				this.sb.Append(string.Format("{0}m ", minutes));
			}
			if (seconds >= 0)
			{
				this.sb.Append(string.Format("{0}s ", seconds));
			}
			this.claimBtnTxt.transform.localScale = Vector3.one * 0.16f;
			this.claimBtnTxt.text = this.sb.ToString();
			this.claimButtonSprite.m_id = this.claimButtonInactiveSprite;
			this.claimButtonSprite.RebuildMesh();
		}
		else
		{
			this.ReadyToClaim();
		}
	}

	private void ReadyToClaim()
	{
		this.waitingToClaimReward = true;
		this.closeButton.gameObject.SetActive(false);
		this.claimButtonSprite.m_id = this.claimButtonActiveSprite;
		this.claimButtonSprite.RebuildMesh();
		this.claimBtnTxt.gameObject.SetActive(true);
		this.UpdateTextMeshLocale(this.claimBtnTxt, "REWARD_CLAIM", -1, string.Empty);
		this.claimBtnTxt.transform.localScale = Vector3.one * 0.24f;
		int currentLevel = RewardSystem.CurrentLevel;
		if (this.dailyRewards == null || currentLevel < 0 || currentLevel >= this.dailyRewards.Length)
		{
			return;
		}
		Reward component = this.dailyRewards[currentLevel].GetComponent<Reward>();
		component.SetState(RewardSystem.GetRewardStateForDay(currentLevel));
		List<DailyReward> rewards = Singleton<RewardSystem>.Instance.Rewards[currentLevel].GetRewards(currentLevel);
		bool isBundle = rewards.Count > 1;
		this.SetInfoText(rewards[0].prize, isBundle);
	}

	private void HandleKeyReleased(KeyCode obj)
	{
		if (obj == KeyCode.Escape)
		{
			this.Close();
		}
	}

	private const string REWARD_PREFAB = "UI/Amazon/DailyReward";

	private const float OFFSET = 6.8f;

	private const float SCALING_WIDTH = 11f;

	private const string LOC_REWARD_FIRST_DAY = "REWARD_FIRST_DAY";

	private const string LOC_REWARD_DAY = "REWARD_DAY";

	private const string LOC_REWARD_CLAIM = "REWARD_CLAIM";

	private const string LOC_REWARD_LATER = "REWARD_LATER";

	private const string LOC_REWARD_ERROR = "REWARD_ERROR";

	public readonly string BundleRewardInfo = "IAP_BUNDLES_PAGE_TEXT";

	public readonly Dictionary<PrizeType, string> RewardInfos = new Dictionary<PrizeType, string>
	{
		{
			PrizeType.SuperGlue,
			"IAP_SUPER_GLUE_PAGE_TEXT"
		},
		{
			PrizeType.SuperMagnet,
			"IAP_SUPER_MAGNET_PAGE_TEXT"
		},
		{
			PrizeType.SuperMechanic,
			"IAP_SUPER_BLUEPRINT_PAGE_TEXT"
		},
		{
			PrizeType.TurboCharge,
			"IAP_TURBO_CHARGE_PAGE_TEXT"
		},
		{
			PrizeType.NightVision,
			"IAP_NIGHTVISION_PAGE_TEXT"
		}
	};

	[SerializeField]
	private Transform rewardContainer;

	[SerializeField]
	private Transform mainMenu;

	[SerializeField]
	private Transform closeButton;

	[SerializeField]
	private float translationTime;

	[SerializeField]
	private Transform loadingIcon;

	[SerializeField]
	private AnimationCurve translationCurve;

	[SerializeField]
	private AnimationCurve scalingCurve;

	[SerializeField]
	private AnimationCurve giveRewardCurve;

	[SerializeField]
	private GameObject infoText;

	[SerializeField]
	private GameObject claimButtonText;

	[SerializeField]
	private Renderer claimButtonRenderer;

	[SerializeField]
	private Sprite claimButtonSprite;

	[SerializeField]
	private string claimButtonActiveSprite;

	[SerializeField]
	private string claimButtonInactiveSprite;

	[SerializeField]
	private TextMesh[] dayTexts;

	[SerializeField]
	private TextMesh errorText;

	[SerializeField]
	private Transform centerDayBG;

	[SerializeField]
	private Renderer hideFirstDayMask;

	[SerializeField]
	private CustomSpritePanel panel;

	[SerializeField]
	private GameObject collectSound;

	[SerializeField]
	private GameObject moveSound;

	private TextMesh infoTxt;

	private TextMesh claimBtnTxt;

	private Transform[] dailyRewards;

	private bool claimRewardSequencePlaying;

	private bool waitingToClaimReward;

	private bool timedOut;

	private float waitTime = 15f;

	private StringBuilder sb;

	private int lastTimeUpdated;
}
