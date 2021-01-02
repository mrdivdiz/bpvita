using System.Collections;
using Spine.Unity;
using UnityEngine;

public class CakeRaceComplete : WPFMonoBehaviour
{
	private void Awake()
	{
		this.originalControlsPanelPosition = this.controlsPanel.localPosition;
		this.controlsPanel.localPosition = this.originalControlsPanelPosition - Vector3.up * 10f;
	}

	private void Start()
	{
		this.bannerAnimation.state.Event += this.OnAnimationEvent;
		this.judgeAnimation.state.Event += this.OnAnimationEvent;
		this.scoreAnimation.state.Event += this.OnAnimationEvent;
	}

	private void OnEnable()
	{
		this.cakeRaceMode = (WPFMonoBehaviour.levelManager.CurrentGameMode as CakeRaceMode);
		if (this.cakeRaceMode == null)
		{
			return;
		}
		this.bannerRenderer = this.bannerAnimation.transform.GetComponent<MeshRenderer>();
		this.judgeRenderer = this.judgeAnimation.transform.GetComponent<MeshRenderer>();
		this.scoreRenderer = this.scoreAnimation.transform.GetComponent<MeshRenderer>();
		this.pillowRenderer = this.pillowSprite.GetComponent<MeshRenderer>();
		this.bannerRenderer.enabled = false;
		this.judgeRenderer.enabled = false;
		this.scoreRenderer.enabled = false;
		this.pillowRenderer.enabled = false;
		if (this.retryButton)
		{
			this.retryButton.SetActive(false);
		}
		for (int i = 0; i < this.hornAnimations.Length; i++)
		{
			this.hornAnimations[i].gameObject.SetActive(false);
		}
		base.StartCoroutine(this.CakeRaceEndScreenSequence());
	}

	private void OnDisabled()
	{
		if (this.bannerRenderer)
		{
			this.bannerRenderer.enabled = false;
		}
		this.hornAnimations[0].state.Event -= this.OnAnimationEvent;
	}

	private void OnDestroy()
	{
		this.bannerAnimation.state.Event -= this.OnAnimationEvent;
		this.judgeAnimation.state.Event -= this.OnAnimationEvent;
		this.scoreAnimation.state.Event -= this.OnAnimationEvent;
	}

	private void OnAnimationEvent(Spine.AnimationState state, int trackIndex, Spine.Event e)
	{
		AudioSource audioSource = null;
		string name = e.Data.Name;
		switch (name)
		{
		case "refereePig_fall":
			audioSource = WPFMonoBehaviour.gameData.commonAudioCollection.refereePigFall;
			goto IL_282;
		case "refereePig_flag":
			audioSource = WPFMonoBehaviour.gameData.commonAudioCollection.refereePigFlag;
			goto IL_282;
		case "refereePig_impact":
			audioSource = WPFMonoBehaviour.gameData.commonAudioCollection.refereePigImpact;
			goto IL_282;
		case "refereePig_whistle":
			audioSource = WPFMonoBehaviour.gameData.commonAudioCollection.refereePigWhistle;
			goto IL_282;
		case "safe_drop":
			audioSource = WPFMonoBehaviour.gameData.commonAudioCollection.safeDrop;
			goto IL_282;
		case "you_win_pillow_appear":
			audioSource = WPFMonoBehaviour.gameData.commonAudioCollection.youWinPillowAppear;
			goto IL_282;
		case "refereePig_fall_impact":
			audioSource = WPFMonoBehaviour.gameData.commonAudioCollection.refereePigFallImpact;
			goto IL_282;
		case "Anticipation":
			audioSource = WPFMonoBehaviour.gameData.commonAudioCollection.scoreAnticipation[0];
			goto IL_282;
		case "win_trumpet":
		{
			AudioSource[] winTrumpet = WPFMonoBehaviour.gameData.commonAudioCollection.winTrumpet;
			audioSource = winTrumpet[UnityEngine.Random.Range(0, winTrumpet.Length)];
			goto IL_282;
		}
		case "confetti1":
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.confettiParticlesPrefab);
			LayerHelper.SetSortingLayer(gameObject, "Popup", true);
			LayerHelper.SetLayer(gameObject, base.gameObject.layer, true);
			gameObject.transform.position = WPFMonoBehaviour.hudCamera.ViewportToWorldPoint(new Vector3(0.333333343f, 0f));
			goto IL_282;
		}
		case "confetti2":
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.confettiParticlesPrefab);
			LayerHelper.SetSortingLayer(gameObject2, "Popup", true);
			LayerHelper.SetLayer(gameObject2, base.gameObject.layer, true);
			gameObject2.transform.position = WPFMonoBehaviour.hudCamera.ViewportToWorldPoint(new Vector3(0.6666667f, 0f));
			goto IL_282;
		}
		}
		audioSource = null;
		IL_282:
		if (audioSource != null)
		{
			Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(audioSource);
		}
	}

	private IEnumerator CakeRaceEndScreenSequence()
	{
		TextMeshHelper.UpdateTextMeshes(this.bannerLabel, string.Empty, false);
		this.SetScoreLabels(-1, -1);
		this.SetNameLabels(string.Empty, string.Empty, false);
		yield return new WaitForSeconds(0.5f);
		bool winner = this.cakeRaceMode.LocalPlayerIsWinner;
		this.judgeAnimation.state.SetAnimation(0, this.judgeAnimationIntro, false);
		this.judgeAnimation.state.AddAnimation(0, this.judgeAnimationIdle, true, 0f);
		yield return null;
		this.judgeRenderer.enabled = true;
		yield return new WaitForSeconds(1f);
		this.scoreAnimation.state.SetAnimation(0, (!winner) ? this.scoreAnimationOpponentWins : this.scoreAnimationPlayerWins, false);
		this.scoreAnimation.state.Event += this.OnScoreAnimationEvent;
		yield return null;
		this.scoreRenderer.enabled = true;
		yield return new WaitForSeconds(1f);
		this.judgeAnimation.state.SetAnimation(0, (!winner) ? this.judgeAnimationOpponentWins : this.judgeAnimationPlayerWins, false);
		this.judgeAnimation.state.AddAnimation(0, (!winner) ? this.judgeAnimationOpponentWinsIdle : this.judgeAnimationPlayerWinsIdle, true, 0f);
		yield return new WaitForSeconds(2f);
		this.SetScoreLabels(this.cakeRaceMode.CurrentScore, this.cakeRaceMode.OpponentScore);
		this.SetNameLabels("CAKE_RACE_YOU", CakeRaceMode.OpponentReplay.GetPlayerName(), true);
		WPFMonoBehaviour.levelManager.StopAmbient();
		Singleton<AudioManager>.Instance.SpawnLoopingEffect(WPFMonoBehaviour.gameData.commonAudioCollection.starLoops[(!winner) ? 0 : 1], base.transform);
		this.bannerAnimation.state.SetAnimation(0, (!winner) ? this.bannerAnimationOpponentWins : this.bannerAnimationPlayerWins, false);
		yield return null;
		Localizer.LocaleParameters winLabelParams = Singleton<Localizer>.Instance.Resolve((!winner) ? this.bannerLoseLocalizationKey : this.bannerWinLocalizationKey, null);
		TextMeshHelper.UpdateTextMeshes(this.bannerLabel, winLabelParams.translation, false);
		yield return null;
		this.bannerRenderer.enabled = true;
		if (winner)
		{
			for (int i = 0; i < this.hornAnimations.Length; i++)
			{
				this.hornAnimations[i].gameObject.SetActive(true);
				this.hornAnimations[i].state.SetAnimation(0, this.hornAnimationPlayerWins, false);
			}
			this.pillowRenderer.enabled = true;
			this.hornAnimations[0].state.Event += this.OnAnimationEvent;
			yield return null;
		}
		this.nextOpponentButton.SetActive(!this.cakeRaceMode.LocalPlayerIsWinner);
		yield return new WaitForSeconds(0.5f);
		Vector3 fromPosition = this.controlsPanel.localPosition;
		float fade = 0f;
		while (fade < 1f)
		{
			fade += GameTime.RealTimeDelta * 2f;
			this.controlsPanel.localPosition = Vector3.Lerp(fromPosition, this.originalControlsPanelPosition, fade);
			yield return null;
		}
		this.controlsPanel.localPosition = this.originalControlsPanelPosition;
		if (PlayerProgressBar.Instance)
		{
			float burstRate = (float)this.cakeRaceMode.GainedXP / 0.6f;
			PlayerProgressBar.Instance.AddParticles(this.scoreAnimation.gameObject, this.cakeRaceMode.GainedXP, 0f, burstRate, null);
		}
		this.SpawnReward();
		yield break;
	}

	private void OnScoreAnimationEvent(Spine.AnimationState state, int trackIndex, Spine.Event e)
	{
		if (e.Data.Name != "Score")
		{
			return;
		}
		this.scoreAnimation.state.Event -= this.OnScoreAnimationEvent;
		int opponentScore = this.cakeRaceMode.OpponentScore;
		int currentScore = this.cakeRaceMode.CurrentScore;
		float num = this.maxScore.position.x - this.minScore.position.x;
		float num2 = (this.maxScore.position.x + this.minScore.position.x) / 2f;
		float num3;
		if (this.cakeRaceMode.OpponentScore > this.cakeRaceMode.CurrentScore)
		{
			num3 = -1f + (float)this.cakeRaceMode.CurrentScore / (float)this.cakeRaceMode.OpponentScore;
		}
		else
		{
			num3 = 1f - (float)this.cakeRaceMode.OpponentScore / (float)this.cakeRaceMode.CurrentScore;
		}
		Vector3 position = this.scoreSliderOverride.position;
		position.x = num2 + num / 2f * num3;
		this.scoreSliderOverride.position = position;
		Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(WPFMonoBehaviour.gameData.commonAudioCollection.scoreImpact);
	}

	private void SpawnReward()
	{
		if (CakeRaceMode.CurrentRewardCrate == LootCrateType.None)
		{
			return;
		}
		GameObject go = LootCrateGraphicSpawner.CreateCrate(CakeRaceMode.CurrentRewardCrate, this.cakeHolder, new Vector3(0.6f, 0f, -0.2f), Vector3.one * 0.65f, Quaternion.Euler(new Vector3(0f, 0f, -90f)));
		LayerHelper.SetLayer(go, base.gameObject.layer, true);
	}

	private void SetScoreLabels(int score, int opponentScore)
	{
		if (this.leftScore != null)
		{
			TextMeshHelper.UpdateTextMeshes(this.leftScore, (score >= 0) ? string.Format("{0:n0}", score) : string.Empty, false);
		}
		if (this.rightScore != null)
		{
			TextMeshHelper.UpdateTextMeshes(this.rightScore, (opponentScore >= 0) ? string.Format("{0:n0}", opponentScore) : string.Empty, false);
		}
	}

	private void SetNameLabels(string left, string right, bool refreshLocalization)
	{
		if (this.leftName != null)
		{
			TextMeshHelper.UpdateTextMeshes(this.leftName, left, refreshLocalization);
		}
		if (this.rightName != null)
		{
			TextMeshHelper.UpdateTextMeshes(this.rightName, right, false);
		}
	}

	private const string REFEREE_PIG_FALL = "refereePig_fall";

	private const string REFEREE_PIG_IMPACT = "refereePig_impact";

	private const string REFEREE_PIG_FALL_IMPACT = "refereePig_fall_impact";

	private const string REFEREE_PIG_WHISTLE = "refereePig_whistle";

	private const string REFEREE_PIG_FLAG = "refereePig_flag";

	private const string SAFE_DROP = "safe_drop";

	private const string WIN_TRUMPET = "win_trumpet";

	private const string PILLOW_APPEAR = "you_win_pillow_appear";

	private const string CONFETTI1 = "confetti1";

	private const string CONFETTI2 = "confetti2";

	private const string SCORE_ANTICIPATION = "Anticipation";

	private const string SCORE = "Score";

	[SerializeField]
	private SkeletonAnimation bannerAnimation;

	private MeshRenderer bannerRenderer;

	[SerializeField]
	private string bannerAnimationPlayerWins;

	[SerializeField]
	private string bannerAnimationOpponentWins;

	[SerializeField]
	private TextMesh[] bannerLabel;

	[SerializeField]
	private string bannerWinLocalizationKey;

	[SerializeField]
	private string bannerLoseLocalizationKey;

	[SerializeField]
	private SkeletonAnimation judgeAnimation;

	private MeshRenderer judgeRenderer;

	[SerializeField]
	private string judgeAnimationIntro;

	[SerializeField]
	private string judgeAnimationIdle;

	[SerializeField]
	private string judgeAnimationPlayerWins;

	[SerializeField]
	private string judgeAnimationOpponentWins;

	[SerializeField]
	private string judgeAnimationPlayerWinsIdle;

	[SerializeField]
	private string judgeAnimationOpponentWinsIdle;

	[SerializeField]
	private SkeletonAnimation scoreAnimation;

	private MeshRenderer scoreRenderer;

	[SerializeField]
	private string scoreAnimationPlayerWins;

	[SerializeField]
	private string scoreAnimationOpponentWins;

	[SerializeField]
	private SkeletonAnimation[] hornAnimations;

	[SerializeField]
	private string hornAnimationPlayerWins;

	[SerializeField]
	private GameObject confettiParticlesPrefab;

	[SerializeField]
	private TextMesh[] leftScore;

	[SerializeField]
	private TextMesh[] leftName;

	[SerializeField]
	private TextMesh[] rightScore;

	[SerializeField]
	private TextMesh[] rightName;

	[SerializeField]
	private Transform controlsPanel;

	[SerializeField]
	private GameObject nextOpponentButton;

	[SerializeField]
	private GameObject retryButton;

	[SerializeField]
	private Transform cakeHolder;

	[SerializeField]
	private GameObject pillowSprite;

	private MeshRenderer pillowRenderer;

	[SerializeField]
	private Transform minScore;

	[SerializeField]
	private Transform maxScore;

	[SerializeField]
	private Transform scoreSliderOverride;

	private CakeRaceMode cakeRaceMode;

	private Vector3 originalControlsPanelPosition = Vector3.zero;
}
