using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
	public RewardIcon RewardIcon
	{
		get
		{
			return this.rewardIcon;
		}
	}

	public TextMesh RewardCount
	{
		get
		{
			return this.countTxt;
		}
	}

	private void Awake()
	{
		this.countTxt = this.rewardCount.GetComponent<TextMesh>();
		this.UpdateBackground(false);
	}

	private void UpdateBackground(bool lit = false)
	{
		this.rewardBG.SetActive(!lit);
		this.rewardBGLit.SetActive(lit);
	}

	public void SetRewards(List<DailyReward> rewards)
	{
		if (this.rewardIcon != null)
		{
			UnityEngine.Object.Destroy(this.rewardIcon.gameObject);
		}
		if (rewards.Count > 1)
		{
			this.rewardIcon = ((GameObject)UnityEngine.Object.Instantiate(Resources.Load("UI/Amazon/RewardBundle"))).GetComponent<RewardIcon>();
			this.SetRewardCount(0, "x");
		}
		else
		{
			if (rewards.Count <= 0)
			{
				return;
			}
			this.rewardIcon = UnityEngine.Object.Instantiate<GameObject>(this.GetRewardPrefab(rewards[0].prize)).GetComponent<RewardIcon>();
			this.SetRewardCount(rewards[0].prizeCount, "x");
		}
		this.rewardIcon.transform.parent = base.transform;
		this.rewardIcon.transform.localPosition = this.rewardPosition.localPosition;
		this.rewardIcon.SetButtonState(RewardIcon.State.NotAvailable);
	}

	public GameObject GetRewardPrefab(PrizeType prizeType)
	{
		if (this.rewardPrefabs == null)
		{
			this.rewardPrefabs = new Dictionary<PrizeType, GameObject>();
		}
		if (this.rewardPrefabs.ContainsKey(prizeType))
		{
			return this.rewardPrefabs[prizeType];
		}
		GameObject gameObject = null;
		switch (prizeType)
		{
		case PrizeType.SuperGlue:
			gameObject = (Resources.Load("UI/Amazon/RewardSuperGlue") as GameObject);
			break;
		case PrizeType.SuperMagnet:
			gameObject = (Resources.Load("UI/Amazon/RewardSuperMagnet") as GameObject);
			break;
		case PrizeType.TurboCharge:
			gameObject = (Resources.Load("UI/Amazon/RewardTurboCharger") as GameObject);
			break;
		case PrizeType.SuperMechanic:
			gameObject = (Resources.Load("UI/Amazon/RewardSuperMechanic") as GameObject);
			break;
		case PrizeType.NightVision:
			gameObject = (Resources.Load("UI/Amazon/RewardNightVision") as GameObject);
			break;
		}
		this.rewardPrefabs.Add(prizeType, gameObject);
		return gameObject;
	}

	public void SetState(RewardIcon.State newState)
	{
		if (this.rewardIcon == null)
		{
			return;
		}
		this.rewardIcon.SetButtonState(newState);
		this.claimedIcon.SetActive(newState == RewardIcon.State.Claimed);
		this.countTxt.gameObject.SetActive(newState != RewardIcon.State.Claimed);
		this.UpdateBackground(newState == RewardIcon.State.ClaimNow);
	}

	public void SetDayText(string textKey, int day)
	{
	}

	public void SetRewardCount(int count, string prefix = "x")
	{
		if (this.countTxt == null)
		{
			return;
		}
		if (count > 0)
		{
			this.countTxt.GetComponent<Renderer>().enabled = true;
			this.countTxt.text = string.Format("{0}{1}", prefix, count);
		}
		else
		{
			this.countTxt.text = string.Empty;
			this.countTxt.GetComponent<Renderer>().enabled = false;
		}
	}

	private const string GLUE_REWARD_PREFAB = "UI/Amazon/RewardSuperGlue";

	private const string MAGNET_REWARD_PREFAB = "UI/Amazon/RewardSuperMagnet";

	private const string MECHANIC_REWARD_PREFAB = "UI/Amazon/RewardSuperMechanic";

	private const string TURBO_REWARD_PREFAB = "UI/Amazon/RewardTurboCharger";

	private const string NIGHT_VISION_REWARD_PREFAB = "UI/Amazon/RewardNightVision";

	private const string BUNDLE_REWARD_PREFAB = "UI/Amazon/RewardBundle";

	[SerializeField]
	private Transform rewardPosition;

	[SerializeField]
	private GameObject rewardCount;

	[SerializeField]
	private GameObject claimedIcon;

	[SerializeField]
	private GameObject rewardBG;

	[SerializeField]
	private GameObject rewardBGLit;

	private TextMesh countTxt;

	private RewardIcon rewardIcon;

	private Dictionary<PrizeType, GameObject> rewardPrefabs;
}
