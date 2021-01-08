using UnityEngine;

public class LeaderboardEntry : MonoBehaviour
{
	public GridLayout ParentGrid { get; set; }

	private void Awake()
	{
		Transform transform = base.transform.Find("PlayerLabel");
		if (transform != null)
		{
			this.nameLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		transform = base.transform.Find("ScoreLabel");
		if (transform != null)
		{
			this.scoreLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		transform = base.transform.Find("RankLabel");
		if (transform != null)
		{
			this.rankLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		transform = base.transform.Find("Background");
		if (transform != null)
		{
			this.otherPlayerBackground = transform.GetComponent<MeshRenderer>();
		}
		transform = base.transform.Find("BackgroundYou");
		if (transform != null)
		{
			this.currentPlayerBackground = transform.GetComponent<MeshRenderer>();
		}
		transform = base.transform.Find("BackgroundYou/InfoButton");
		if (transform != null)
		{
			this.currentPlayerInfoButton = transform.GetComponent<MeshRenderer>();
		}
		this.coinPrizeContainer = base.transform.Find("CoinPrize");
		transform = this.coinPrizeContainer.Find("Amount");
		if (transform != null)
		{
			this.coinPrizeLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		this.coinPrizeContainer.gameObject.SetActive(false);
	}

	public void Init(LeaderboardDialog parentDialog)
	{
		this.dialog = parentDialog;
		base.gameObject.SetActive(false);
		this.heightAdded = false;
	}

	public void Show(bool show = true)
	{
		base.gameObject.SetActive(show);
		if (show && !this.heightAdded)
		{
			this.dialog.IncreaseLeaderboardScrollerHeight(this.ParentGrid.VerticalGap);
			this.heightAdded = true;
		}
		else if (!show && this.heightAdded)
		{
			this.dialog.DecreaseLeaderboardScrollerHeight(this.ParentGrid.VerticalGap);
			this.heightAdded = false;
		}
	}

	public void SetInfo(string playFabId, string name, int score, int rank)
	{
		this.playFabId = playFabId;
		this.playerName = name;
		this.playerScore = score;
		this.playerRank = rank;
		if (string.IsNullOrEmpty(playFabId))
		{
			this.Show(false);
			return;
		}
		this.Show(true);
		bool flag = playFabId.Equals(HatchManager.CurrentPlayer.PlayFabID);
		string format = (!flag) ? "{0}" : string.Format("{0} ({1})", this.GetLocalizedPlayerName(), "{0}");
		string[] array = name.Split(new char[]
		{
			'|'
		});
		if (array != null && array.Length > 0)
		{
			this.playerName = string.Format(format, array[0]);
		}
		else
		{
			this.playerName = string.Format(format, name);
		}
		TextMeshHelper.UpdateTextMeshes(this.nameLabel, this.playerName, false);
		TextMeshHelper.UpdateTextMeshes(this.scoreLabel, string.Format("{0:n0}", score), false);
		if (rank >= 0)
		{
			this.SetRank(rank + 1);
		}
		else
		{
			this.SetRank(rank);
		}
		if (this.otherPlayerBackground != null)
		{
			this.otherPlayerBackground.enabled = !flag;
		}
		if (this.currentPlayerBackground != null)
		{
			this.currentPlayerBackground.enabled = flag;
		}
		if (this.currentPlayerInfoButton != null)
		{
			this.currentPlayerInfoButton.enabled = flag;
		}
	}

	public void SetRewards(LootCrateType crateType, int coinAmount)
	{
		for (int i = 0; i < this.crateIcons.Length; i++)
		{
			if (this.crateIcons[i] != null)
			{
				this.crateIcons[i].SetActive(crateType != LootCrateType.None && i == Mathf.Clamp((int)crateType, 0, 6));
			}
		}
		if (this.coinPrizeContainer != null)
		{
			TextMeshHelper.UpdateTextMeshes(this.coinPrizeLabel, coinAmount.ToString(), false);
			this.coinPrizeContainer.gameObject.SetActive(coinAmount > 0);
		}
	}

	private void SetRank(int rank)
	{
		TextMeshHelper.ForceWrapText(this.rankLabel, (rank >= 0) ? rank.ToString() : "-", 3);
		this.rankLabel[0].transform.localScale = ((rank < 100) ? new Vector3(0.12f, 0.12f) : new Vector3(0.09f, 0.09f));
		if (this.rankIcons != null && this.trophyIcons != null)
		{
			if (rank < 0)
			{
				rank = 4;
			}
			for (int i = 0; i < this.rankIcons.Length; i++)
			{
				if (this.rankIcons[i] != null)
				{
					this.rankIcons[i].enabled = (i + 1 == Mathf.Clamp(rank, 1, 4));
				}
				if (i < this.trophyIcons.Length && this.trophyIcons[i] != null)
				{
					this.trophyIcons[i].enabled = (i + 1 == Mathf.Clamp(rank, 1, 4));
				}
			}
		}
	}

	private string GetLocalizedPlayerName()
	{
		Localizer.LocaleParameters localeParameters = Singleton<Localizer>.Instance.Resolve("YOUR_NAME_LEADERBOARDS", null);
		return localeParameters.translation;
	}

	public void VerticalScrollButtonActivate()
	{
		if (this.dialog != null && !string.IsNullOrEmpty(this.playFabId))
		{
			this.dialog.ShowPlayerInfo(this.playerName, this.playerScore, this.playerRank, this.playFabId);
		}
	}

	[SerializeField]
	private MeshRenderer[] rankIcons;

	[SerializeField]
	private MeshRenderer[] trophyIcons;

	[SerializeField]
	private GameObject[] crateIcons;

	private string playFabId = string.Empty;

	private string playerName = string.Empty;

	private int playerRank = int.MaxValue;

	private int playerScore;

	private TextMesh[] nameLabel;

	private TextMesh[] scoreLabel;

	private TextMesh[] rankLabel;

	private TextMesh[] coinPrizeLabel;

	private MeshRenderer otherPlayerBackground;

	private MeshRenderer currentPlayerBackground;

	private MeshRenderer currentPlayerInfoButton;

	private Transform coinPrizeContainer;

	private LeaderboardDialog dialog;

	private bool heightAdded;
}
