using System.Collections;
using UnityEngine;

public class RewardPigRescuePopup : MonoBehaviour
{
	private static RewardType CurrentRewardType
	{
		get
		{
			return (RewardType)GameProgress.GetInt("PigRescueRewardType", -1, GameProgress.Location.Local, null);
		}
	}

	private static int CurrentRewardCount
	{
		get
		{
			return GameProgress.GetInt("PigRescueRewardCount", -1, GameProgress.Location.Local, null);
		}
	}

	public static bool HasRewardPending
	{
		get
		{
			return RewardPigRescuePopup.CurrentRewardType != RewardPigRescuePopup.RewardType.None && RewardPigRescuePopup.CurrentRewardCount >= 0;
		}
	}

	public static void SetRewardData(RewardType rewardType, int rewardCount)
	{
		GameProgress.SetInt("PigRescueRewardType", (int)rewardType, GameProgress.Location.Local);
		GameProgress.SetInt("PigRescueRewardCount", rewardCount, GameProgress.Location.Local);
	}

	public static void CheckReward(GameObject go, string callbackMethodName)
	{
	}

	public static void ProcessReward(string rewardData)
	{
		string[] array = rewardData.Split(new char[]
		{
			','
		});
		if (array.Length != 2 || string.IsNullOrEmpty(array[0]) || string.IsNullOrEmpty(array[1]))
		{
			return;
		}
		int num;
		if (!int.TryParse(array[0], out num) || num < 0 || num > 4)
		{
			return;
		}
        RewardType rewardType = (RewardType)num;
		int rewardCount;
		if (!int.TryParse(array[1], out rewardCount))
		{
			return;
		}
		RewardPigRescuePopup.SetRewardData(rewardType, rewardCount);
	}

	private void OnEnable()
	{
		if (this.rewardIcons == null || !RewardPigRescuePopup.HasRewardPending)
		{
			this.ClosePopup();
			return;
		}
		int currentRewardType = (int)RewardPigRescuePopup.CurrentRewardType;
		for (int i = 0; i < this.rewardIcons.Length; i++)
		{
			if (this.rewardIcons[i] != null)
			{
				this.rewardIcons[i].enabled = (i == currentRewardType);
			}
		}
		this.rewardCountText.text = string.Format("x{0}", RewardPigRescuePopup.CurrentRewardCount);
	}

	private void OnDisable()
	{
		if (this.isClaimSequence)
		{
			this.ClosePopup();
		}
	}

	public void ClaimReward()
	{
        RewardType currentRewardType = RewardPigRescuePopup.CurrentRewardType;
		int currentRewardCount = RewardPigRescuePopup.CurrentRewardCount;
		GameProgress.DeleteKey("PigRescueRewardType", GameProgress.Location.Local);
		GameProgress.DeleteKey("PigRescueRewardCount", GameProgress.Location.Local);
		if (currentRewardType == RewardPigRescuePopup.RewardType.None || currentRewardCount <= 0)
		{
			return;
		}
		switch (currentRewardType)
		{
		case RewardPigRescuePopup.RewardType.Turbo:
			GameProgress.AddTurboCharge(currentRewardCount);
			break;
		case RewardPigRescuePopup.RewardType.Glue:
			GameProgress.AddSuperGlue(currentRewardCount);
			break;
		case RewardPigRescuePopup.RewardType.Magnet:
			GameProgress.AddSuperMagnet(currentRewardCount);
			break;
		case RewardPigRescuePopup.RewardType.Nightvision:
			GameProgress.AddNightVision(currentRewardCount);
			break;
		case RewardPigRescuePopup.RewardType.Supermechanic:
			GameProgress.AddBluePrints(currentRewardCount);
			break;
		}
		base.StartCoroutine(this.ClaimSequence());
	}

	private IEnumerator ClaimSequence()
	{
		this.isClaimSequence = true;
		Transform rewardIcons = base.transform.Find("RewardIcons");
		if (rewardIcons != null)
		{
			Transform countTransform = rewardIcons.Find("RewardCountText");
			if (countTransform != null)
			{
				TextMesh component = countTransform.GetComponent<TextMesh>();
				if (component != null)
				{
					component.text = component.text.Replace("x", "+");
				}
			}
			Animation anim = rewardIcons.GetComponent<Animation>();
			if (anim != null)
			{
				anim.Play("RewardClaim");
				while (anim.IsPlaying("RewardClaim"))
				{
					yield return null;
				}
			}
		}
		this.isClaimSequence = false;
		this.ClosePopup();
		yield break;
	}

	private void ClosePopup()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public MeshRenderer[] rewardIcons;

	public TextMesh rewardCountText;

	private const string PIG_RESCUE_REWARD_TYPE_KEY = "PigRescueRewardType";

	private const string PIG_RESCUE_REWARD_COUNT_KEY = "PigRescueRewardCount";

	private bool isClaimSequence;

	public enum RewardType
	{
		None = -1,
		Turbo,
		Glue,
		Magnet,
		Nightvision,
		Supermechanic
	}
}
