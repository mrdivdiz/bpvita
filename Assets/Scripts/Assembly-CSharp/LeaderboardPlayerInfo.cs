using System.Collections.Generic;
using CakeRace;
using UnityEngine;

public class LeaderboardPlayerInfo : MonoBehaviour
{
	public int CakeRaceReplayCount
	{
		get
		{
			return (this.replayEntries != null) ? this.replayEntries.Count : 0;
		}
	}

	private void Init()
	{
		if (this.isInit)
		{
			return;
		}
		Transform transform = base.transform.Find("RankScore/RankLabel");
		if (transform != null)
		{
			this.rankLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		string[] array = new string[]
		{
			"1",
			"2",
			"3",
			"x"
		};
		this.rankBackgrounds = new MeshRenderer[4];
		for (int i = 0; i < this.rankBackgrounds.Length; i++)
		{
			transform = base.transform.Find("RankScore/RankIcons/" + array[i]);
			if (transform != null)
			{
				this.rankBackgrounds[i] = transform.GetComponent<MeshRenderer>();
			}
		}
		transform = base.transform.Find("RankScore/ScorePanel/ScoreLabel");
		if (transform != null)
		{
			this.scoreLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		transform = base.transform.Find("RankScore/Reward/CoinPrize/Amount");
		if (transform != null)
		{
			this.coinRewardLabel = transform.GetComponentsInChildren<TextMesh>();
		}
		this.rewardCrateContainer = base.transform.Find("RankScore/Reward/CratePrize");
		this.trophies = base.transform.Find("Trophies");
		if (this.trophies != null)
		{
			transform = this.trophies.Find("CoinsWonPanel/CoinsLabel");
			if (transform != null)
			{
				this.totalCoinsWonLabel = transform.GetComponentsInChildren<TextMesh>();
			}
			transform = this.trophies.Find("RankPanel/RankLabel");
			if (transform != null)
			{
				this.highestRankLabel = transform.GetComponentsInChildren<TextMesh>();
			}
			this.trophyIcons = new Transform[3];
			this.trophyAmountLabels = new List<TextMesh[]>();
			for (int j = 1; j <= 3; j++)
			{
				transform = this.trophies.Find(string.Format("Trophies/{0}", j));
				if (transform != null)
				{
					this.trophyIcons[j - 1] = transform;
				}
				transform = this.trophies.Find(string.Format("Trophies/{0}Amount", j));
				if (transform != null)
				{
					this.trophyAmountLabels.Add(transform.GetComponentsInChildren<TextMesh>());
				}
			}
		}
		this.scroller = base.GetComponent<VerticalScroller>();
		this.isInit = true;
	}

	public void SetRankScoreInfo(int rank, int score, bool isLocalPlayer = false)
	{
		this.Init();
		this.trophies.gameObject.SetActive(isLocalPlayer);
		this.scroller.SetLowerPadding((!isLocalPlayer) ? -5.5f : 2f);
		TextMeshHelper.UpdateTextMeshes(this.rankLabel, (rank > 0) ? rank.ToString() : "-", false);
		TextMeshHelper.UpdateTextMeshes(this.scoreLabel, (score > 0) ? string.Format("{0:n0}", score) : "-", false);
		for (int i = 0; i < this.rankBackgrounds.Length; i++)
		{
			if (this.rankBackgrounds[i] != null)
			{
				this.rankBackgrounds[i].enabled = (i + 1 == rank || (i == 3 && (rank > 3 || rank == 0)));
			}
		}
		if (isLocalPlayer)
		{
			this.UpdatePlayerStats();
		}
	}

	private void UpdatePlayerStats()
	{
		for (int i = 0; i < 3; i++)
		{
			int num = 0;
			if (i != 0)
			{
				if (i != 1)
				{
					if (i == 2)
					{
						num = GameProgress.GetInt("cake_race_bronze_trophies_won", 0, GameProgress.Location.Local, null);
					}
				}
				else
				{
					num = GameProgress.GetInt("cake_race_silver_trophies_won", 0, GameProgress.Location.Local, null);
				}
			}
			else
			{
				num = GameProgress.GetInt("cake_race_gold_trophies_won", 0, GameProgress.Location.Local, null);
			}
			this.trophyIcons[i].gameObject.SetActive(num > 0);
			TextMeshHelper.UpdateTextMeshes(this.trophyAmountLabels[i], (num <= 0) ? string.Empty : num.ToString(), false);
		}
		int @int = GameProgress.GetInt("cake_race_coins_won", 0, GameProgress.Location.Local, null);
		TextMeshHelper.UpdateTextMeshes(this.totalCoinsWonLabel, string.Format("[snout] {0}", @int), false);
		TextMeshSpriteIcons.EnsureSpriteIcon(this.totalCoinsWonLabel);
		int int2 = GameProgress.GetInt("cake_race_highest_rank", 0, GameProgress.Location.Local, null);
		TextMeshHelper.UpdateTextMeshes(this.highestRankLabel, (int2 <= 0) ? "-" : int2.ToString(), false);
	}

	public void SetRewards(LootCrateType crateType, int snoutCoins)
	{
		TextMeshHelper.UpdateTextMeshes(this.coinRewardLabel, snoutCoins.ToString(), false);
		for (int i = 0; i < this.rewardCrateContainer.childCount; i++)
		{
			Transform child = this.rewardCrateContainer.GetChild(i);
			child.gameObject.SetActive(child.name.Equals(crateType.ToString()));
		}
	}

	public void AddCakeRaceReplayEntry(int index, CakeRaceReplayEntry entry)
	{
		if (this.replayEntries == null)
		{
			this.replayEntries = new Dictionary<int, CakeRaceReplayEntry>();
		}
		if (!this.replayEntries.ContainsKey(index))
		{
			this.replayEntries.Add(index, entry);
		}
	}

	public void UpdateReplayEntry(int index, CakeRaceReplay replay)
	{
		if (this.replayEntries != null && this.replayEntries.ContainsKey(index) && this.replayEntries[index] != null)
		{
			if (replay == null || !replay.IsValid)
			{
				this.replayEntries[index].SetInfo(index, 0, 0, false);
			}
			else
			{
				this.replayEntries[index].SetInfo(index, replay);
			}
		}
	}

	private TextMesh[] rankLabel;

	private TextMesh[] scoreLabel;

	private TextMesh[] coinRewardLabel;

	private TextMesh[] totalCoinsWonLabel;

	private TextMesh[] highestRankLabel;

	private Transform trophies;

	private Transform[] trophyIcons;

	private MeshRenderer[] rankBackgrounds;

	private List<TextMesh[]> trophyAmountLabels;

	private Transform rewardCrateContainer;

	private Dictionary<int, CakeRaceReplayEntry> replayEntries;

	private VerticalScroller scroller;

	private bool isInit;
}
