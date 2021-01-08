using System.Collections;
using Spine.Unity;
using UnityEngine;

public class LeaderboardSeasonEndDialog : TextDialog
{
	protected override void Awake()
	{
		base.Awake();
		Transform transform = this.dialogRoot.transform.Find("TitleRibbon/TitleLabel");
		if (transform != null)
		{
			this.titleLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		transform = this.dialogRoot.transform.Find("RewardContainer/RankLabel");
		if (transform != null)
		{
			this.rankLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		transform = this.dialogRoot.transform.Find("RewardContainer/RewardLabel");
		if (transform != null)
		{
			this.rewardLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		Localizer.LocaleParameters localeParameters = Singleton<Localizer>.Instance.Resolve(this.titleLocalizationKey, null);
		TextMeshHelper.UpdateTextMeshes(this.titleLabel, string.Format(localeParameters.translation, CakeRaceMenu.CurrentCakeRaceWeek() - 1), false);
	}

	public void SetLoading(bool loading)
	{
		this.isLoading = loading;
		this.loadingState.SetActive(loading);
		this.rewardState.SetActive(!loading);
	}

	public void SetCrateRankAndReward(LootCrateType crateType, int rank, int reward)
	{
		this.reward = reward;
		Localizer.LocaleParameters localeParameters = Singleton<Localizer>.Instance.Resolve(this.rankLocalizationKey, null);
		TextMeshHelper.UpdateTextMeshes(this.rankLabel, string.Format(localeParameters.translation, rank), false);
		TextMeshHelper.Wrap(this.rankLabel, 15);
		Localizer.LocaleParameters localeParameters2 = Singleton<Localizer>.Instance.Resolve(this.snoutRewardLocalizationKey, null);
		TextMeshHelper.UpdateTextMeshes(this.rewardLabel, string.Format(localeParameters2.translation, reward), false);
		TextMeshSpriteIcons.EnsureSpriteIcon(this.rewardLabel);
		TextMeshHelper.Wrap(this.rewardLabel, 15);
		this.lootCrate.gameObject.SetActive(crateType != LootCrateType.None);
		this.barrelContainer.SetActive(crateType == LootCrateType.None);
		if (crateType != LootCrateType.None)
		{
			this.lootCrate.initialSkinName = crateType.ToString();
			this.lootCrate.Initialize(true);
			this.lootCrate.state.SetAnimation(0, "Idle", true);
			this.lootCrate.Update(Time.deltaTime);
		}
		this.SetLoading(false);
	}

	private void OnDestroy()
	{
	}

	public new void Close()
	{
		if (this.isLoading)
		{
			return;
		}
		base.Close();
		if (this.reward > 0)
		{
			CoroutineRunner.Instance.StartCoroutine(this.SnoutCoinBurst(this.reward));
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private IEnumerator SnoutCoinBurst(int reward)
	{
		GameObject go = new GameObject("CurrencyParticleBurst");
		go.transform.position = Vector3.zero;
		SnoutButton.Instance.AddParticles(go, Mathf.Clamp(reward, 1, 50), 0f, (float)Mathf.Clamp(reward, 1, 50));
		yield return new WaitForSeconds(10f);
		if (go != null)
		{
			UnityEngine.Object.Destroy(go);
		}
		yield break;
	}

	[SerializeField]
	private string titleLocalizationKey;

	[SerializeField]
	private string rankLocalizationKey;

	[SerializeField]
	private string snoutRewardLocalizationKey;

	[SerializeField]
	private GameObject rewardState;

	[SerializeField]
	private GameObject loadingState;

	[SerializeField]
	private SkeletonAnimation lootCrate;

	[SerializeField]
	private GameObject barrelContainer;

	private TextMesh[] titleLabel;

	private TextMesh[] rankLabel;

	private TextMesh[] rewardLabel;

	private bool isLoading;

	private int reward;
}
