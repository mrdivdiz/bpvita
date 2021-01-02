using System;
using System.Collections;
using System.Collections.Generic;
using CakeRace;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class LeaderboardDialog : TextDialog
{
	public bool ShowingCupAnimation
	{
		get
		{
			return this.showingCupAnimationPhase >= 0;
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (this.titleLabel == null)
		{
			Transform transform = this.dialogRoot.transform.Find("Title/Label");
			if (transform != null)
			{
				this.titleLabel = transform.GetComponentsInChildren<TextMesh>();
			}
		}
		Transform transform2 = this.dialogRoot.transform.Find("ListContainer");
		this.leaderboardListScroller = transform2.GetComponent<VerticalScroller>();
		Transform transform3 = this.dialogRoot.transform.Find("ListContainer/SingleRankGrid");
		if (transform3 != null)
		{
			this.singleRanksGrid = transform3.GetComponent<GridLayout>();
		}
		Transform transform4 = this.dialogRoot.transform.Find("ListContainer/Top50Grid");
		if (transform4 != null)
		{
			this.top50Grid = transform4.GetComponent<GridLayout>();
		}
		if (this.leaderboardEntries == null)
		{
			this.DecreaseLeaderboardScrollerHeight(this.top50Grid.VerticalGap);
			this.leaderboardEntries = new Dictionary<int, LeaderboardEntry>();
			if (this.singleRanks != null)
			{
				int num = this.singleRanks.Length;
			}
			for (int i = 0; i < this.TotalEntryCount(); i++)
			{
				string name = string.Format("{0:0000}", i);
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>((i < 50) ? this.entryPrefab : this.singleEntryPrefab);
				gameObject.transform.parent = ((i < 50) ? this.top50Grid.transform : this.singleRanksGrid.transform);
				gameObject.transform.SetAsLastSibling();
				gameObject.name = name;
				LeaderboardEntry component = gameObject.transform.GetComponent<LeaderboardEntry>();
				component.Init(this);
				component.ParentGrid = ((i < 50) ? this.top50Grid : this.singleRanksGrid);
				this.leaderboardEntries.Add(i, component);
				if (transform4 != null)
				{
					VerticalScrollButton component2 = gameObject.transform.GetComponent<VerticalScrollButton>();
					component2.SetScroller(this.leaderboardListScroller);
				}
			}
		}
		this.UpdateGridLayout();
		if (this.playerInfo == null)
		{
			transform2 = this.dialogRoot.transform.Find("PlayerInfoContainer");
			VerticalScroller component3 = transform2.GetComponent<VerticalScroller>();
			transform4 = transform2.Find("ReplayGrid");
			if (transform4 != null)
			{
				this.replayGrid = transform4.GetComponent<GridLayout>();
			}
			this.playerInfo = transform2.gameObject.AddComponent<LeaderboardPlayerInfo>();
			for (int j = 0; j < 7; j++)
			{
				string name2 = string.Format("{0:0000}", j);
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.cakeRaceReplayEntryPrefab);
				gameObject2.transform.parent = this.replayGrid.transform;
				gameObject2.transform.SetAsLastSibling();
				gameObject2.name = name2;
				CakeRaceReplayEntry component4 = gameObject2.transform.GetComponent<CakeRaceReplayEntry>();
				component4.SetDialog(this);
				this.playerInfo.AddCakeRaceReplayEntry(j, component4);
				if (this.replayGrid != null && j > 0)
				{
					component3.AddHeight(this.replayGrid.VerticalGap);
				}
			}
		}
		this.replayGrid.UpdateLayout();
		if (this.cupInfo == null)
		{
			transform2 = this.dialogRoot.transform.Find("CupInfoContainer");
			this.cupInfo = transform2.gameObject.AddComponent<LeaderboardCupInfo>();
			this.cupInfo.Init(this);
		}
		base.StartCoroutine(this.FetchLeaderboard());
		this.SetTitle(this.GetCupAndSeasonTitle());
		this.UpdateDaysLeft();
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.OnReceivedUIEvent));
	}

	private IEnumerator FetchLeaderboard()
	{
		this.ChangeView(LeaderboardDialog.LeaderboardView.Loading, string.Empty);
		this.loadingView = LeaderboardDialog.LeaderboardView.List;
		this.currentLeaderboard = null;
		this.currentPlayerLeaderboard = null;
		Singleton<PlayFabManager>.Instance.Leaderboard.GetLeaderboard(CakeRaceMenu.GetCurrentLeaderboardCup(), new Action<GetLeaderboardResult>(this.OnTopLeaderboardResult), new Action<PlayFabError>(this.OnLeaderboardError), false, 0, this.topRanks);
		Singleton<PlayFabManager>.Instance.Leaderboard.GetLeaderboardAroundPlayer(CakeRaceMenu.GetCurrentLeaderboardCup(), new Action<GetLeaderboardAroundPlayerResult>(this.OnPlayerLeaderboardResult), new Action<PlayFabError>(this.OnLeaderboardError), false, 1);
		while (this.currentLeaderboard == null || this.currentPlayerLeaderboard == null)
		{
			yield return null;
		}
		if (this.currentView == LeaderboardDialog.LeaderboardView.Loading && this.loadingView == LeaderboardDialog.LeaderboardView.List)
		{
			this.UpdateLeaderboard(this.currentLeaderboard, this.currentPlayerLeaderboard);
		}
		yield break;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.OnReceivedUIEvent));
	}

	public new void Close()
	{
		if (this.showingCupAnimationPhase == 0)
		{
			return;
		}
		if (this.showingCupAnimationPhase == 1 || this.currentView == LeaderboardDialog.LeaderboardView.List || this.loadingView == LeaderboardDialog.LeaderboardView.List || this.currentView == LeaderboardDialog.LeaderboardView.Error)
		{
			this.showingCupAnimationPhase = -1;
			base.Close();
		}
		else if (this.currentView == LeaderboardDialog.LeaderboardView.PlayerInfo || this.currentView == LeaderboardDialog.LeaderboardView.CupInfo)
		{
			this.ChangeView(LeaderboardDialog.LeaderboardView.List, this.GetCupAndSeasonTitle());
		}
		else
		{
			this.ChangeView(this.previousView, this.previousTitle);
		}
	}

	private void OnReceivedUIEvent(UIEvent data)
	{
		switch (data.type)
		{
		case UIEvent.Type.OpenedLootWheel:
		case UIEvent.Type.OpenedSnoutCoinShop:
			base.Hide();
			break;
		case UIEvent.Type.ClosedLootWheel:
			if (!Singleton<IapManager>.Instance.IsShopPageOpened() && !SnoutCoinShopPopup.DialogOpen)
			{
				base.Show();
			}
			break;
		case UIEvent.Type.ClosedSnoutCoinShop:
			if (!LootWheelPopup.DialogOpen)
			{
				base.Show();
			}
			break;
		}
	}

	private void SetTitle(string title)
	{
		TextMeshHelper.UpdateTextMeshes(this.titleLabel, title, false);
	}

	private string GetCupAndSeasonTitle()
	{
		Localizer.LocaleParameters localeParameters = Singleton<Localizer>.Instance.Resolve("LEADERBOARDS_TITLE", null);
		Localizer.LocaleParameters localeParameters2 = Singleton<Localizer>.Instance.Resolve(string.Format("CUP_{0:00}_NAME", (int)CakeRaceMenu.GetCurrentLeaderboardCup()), null);
		return string.Format(localeParameters.translation, localeParameters2.translation, CakeRaceMenu.CurrentCakeRaceWeek());
	}

	private int TotalEntryCount()
	{
		int num = 0;
		if (this.singleRanks != null)
		{
			num = this.singleRanks.Length;
		}
		return this.topRanks + num + 1;
	}

	private int HighestRankEntry()
	{
		if (this.singleRanks != null && this.singleRanks.Length > 0)
		{
			return this.singleRanks[this.singleRanks.Length - 1];
		}
		return this.topRanks;
	}

	private void ChangeView(LeaderboardView newView, string newTitle = "")
	{
		UnityEngine.Debug.LogWarning("[LeaderboardDialog] ChangeView(" + newView.ToString() + ")");
		this.loadingView = LeaderboardDialog.LeaderboardView.Loading;
		this.previousTitle = this.currentTitle;
		this.previousView = this.currentView;
		if (!string.IsNullOrEmpty(newTitle))
		{
			this.currentTitle = newTitle;
		}
		this.currentView = newView;
		if (this.viewContainers == null)
		{
			return;
		}
		int num = (int)this.currentView;
		for (int i = 0; i < this.viewContainers.Length; i++)
		{
			if (this.viewContainers[i] != null)
			{
				this.viewContainers[i].SetActive(num == i);
			}
		}
		if (!string.IsNullOrEmpty(newTitle))
		{
			this.SetTitle(newTitle);
		}
		this.cupButton.SetActive(this.currentView != LeaderboardDialog.LeaderboardView.CupInfo && this.currentView != LeaderboardDialog.LeaderboardView.Loading);
	}

	private int GetKeyFromIndex(int index)
	{
		if (index < 0)
		{
			return this.TotalEntryCount() - 1;
		}
		if (index < this.topRanks)
		{
			return index;
		}
		int num = index - this.topRanks;
		if (this.singleRanks != null && num >= 0 && num < this.singleRanks.Length)
		{
			return this.singleRanks[num];
		}
		return -1;
	}

	private int GetIndexFromRank(int rank)
	{
		if (rank <= this.topRanks)
		{
			return rank - 1;
		}
		if (this.singleRanks != null && this.singleRanks.Length > 0)
		{
			for (int i = 0; i < this.singleRanks.Length; i++)
			{
				if (rank == this.singleRanks[i])
				{
					return this.topRanks + i;
				}
			}
		}
		return -1;
	}

	public void IncreaseLeaderboardScrollerHeight(float value)
	{
		this.leaderboardListScroller.AddHeight(value);
	}

	public void DecreaseLeaderboardScrollerHeight(float value)
	{
		this.leaderboardListScroller.AddHeight(-value);
	}

	private void UpdateLeaderboard(List<PlayerLeaderboardEntry> leaderboard, List<PlayerLeaderboardEntry> player)
	{
		if ((this.entryPrefab == null || this.top50Grid == null || this.singleRanks == null) && !this.ShowingCupAnimation)
		{
			this.ChangeView(LeaderboardDialog.LeaderboardView.Error, string.Empty);
		}
		this.localPlayerRank = ((player.Count <= 0) ? -1 : ((player[0].StatValue <= 0) ? -1 : player[0].Position));
		LeaderboardEntry leaderboardEntry = null;
		for (int i = 0; i < this.topRanks; i++)
		{
			int keyFromIndex = this.GetKeyFromIndex(i);
			if (this.leaderboardEntries.ContainsKey(keyFromIndex))
			{
				if (i < leaderboard.Count)
				{
					if (HatchManager.CurrentPlayer.PlayFabID.Equals(leaderboard[i].PlayFabId))
					{
						leaderboardEntry = this.leaderboardEntries[keyFromIndex];
					}
					this.leaderboardEntries[keyFromIndex].SetInfo(leaderboard[i].PlayFabId, leaderboard[i].DisplayName, leaderboard[i].StatValue, leaderboard[i].Position);
				}
				else
				{
					this.leaderboardEntries[keyFromIndex].SetInfo(string.Empty, "- empty -", 0, i);
				}
				this.leaderboardEntries[keyFromIndex].SetRewards(CakeRaceMenu.GetSeasonCrateReward((int)CakeRaceMenu.GetCurrentLeaderboardCup(), i + 1), CakeRaceMenu.GetSeasonSnoutCoinReward((int)CakeRaceMenu.GetCurrentLeaderboardCup(), i + 1));
			}
		}
		for (int j = 0; j < this.singleRanks.Length; j++)
		{
			int indexFromRank = this.GetIndexFromRank(this.singleRanks[j]);
			if (this.leaderboardEntries.ContainsKey(indexFromRank))
			{
				this.leaderboardEntries[indexFromRank].SetInfo(string.Empty, "- empty -", 0, this.singleRanks[j]);
			}
		}
		for (int k = 0; k < this.singleRanks.Length; k++)
		{
			if (this.localPlayerRank <= this.topRanks && this.localPlayerRank >= 0)
			{
				break;
			}
			int indexFromRank2 = this.GetIndexFromRank(this.singleRanks[k]);
			int num = this.singleRanks[k] - 1;
			if (this.leaderboardEntries.ContainsKey(indexFromRank2))
			{
				if (this.localPlayerRank <= num && this.localPlayerRank >= 0)
				{
					leaderboardEntry = this.leaderboardEntries[indexFromRank2];
					leaderboardEntry.SetInfo(player[0].PlayFabId, player[0].DisplayName, player[0].StatValue, this.localPlayerRank);
					leaderboardEntry.SetRewards(CakeRaceMenu.GetSeasonCrateReward((int)CakeRaceMenu.GetCurrentLeaderboardCup(), this.localPlayerRank + 1), CakeRaceMenu.GetSeasonSnoutCoinReward((int)CakeRaceMenu.GetCurrentLeaderboardCup(), this.localPlayerRank + 1));
					break;
				}
				if (num < leaderboard.Count)
				{
					this.leaderboardEntries[indexFromRank2].SetInfo(leaderboard[num].PlayFabId, leaderboard[num].DisplayName, leaderboard[num].StatValue, num);
					this.leaderboardEntries[indexFromRank2].SetRewards(CakeRaceMenu.GetSeasonCrateReward((int)CakeRaceMenu.GetCurrentLeaderboardCup(), num + 1), CakeRaceMenu.GetSeasonSnoutCoinReward((int)CakeRaceMenu.GetCurrentLeaderboardCup(), num + 1));
				}
			}
		}
		if (this.localPlayerRank < 0)
		{
			int keyFromIndex2 = this.GetKeyFromIndex((leaderboard.Count > 0) ? -1 : 0);
			leaderboardEntry = this.leaderboardEntries[keyFromIndex2];
			leaderboardEntry.SetInfo(HatchManager.CurrentPlayer.PlayFabID, HatchManager.CurrentPlayer.PlayFabDisplayName, 0, -1);
			leaderboardEntry.SetRewards(LootCrateType.None, 0);
		}
		else if (this.localPlayerRank >= this.HighestRankEntry())
		{
			int keyFromIndex3 = this.GetKeyFromIndex(-1);
			leaderboardEntry = this.leaderboardEntries[keyFromIndex3];
			leaderboardEntry.SetInfo(player[0].PlayFabId, player[0].DisplayName, player[0].StatValue, this.localPlayerRank);
			leaderboardEntry.SetRewards(CakeRaceMenu.GetSeasonCrateReward((int)CakeRaceMenu.GetCurrentLeaderboardCup(), this.localPlayerRank + 1), CakeRaceMenu.GetSeasonSnoutCoinReward((int)CakeRaceMenu.GetCurrentLeaderboardCup(), this.localPlayerRank + 1));
		}
		else
		{
			int keyFromIndex4 = this.GetKeyFromIndex(-1);
			this.leaderboardEntries[keyFromIndex4].SetInfo(string.Empty, "- empty -", 0, -1);
		}
		if (!this.ShowingCupAnimation)
		{
			this.ChangeView(LeaderboardDialog.LeaderboardView.List, string.Empty);
		}
		this.UpdateGridLayout();
		this.PositionLeaderboard(leaderboardEntry);
	}

	private void UpdateGridLayout()
	{
		this.top50Grid.UpdateLayout();
		this.singleRanksGrid.UpdateLayout();
		Transform transform = null;
		for (int i = 0; i < this.top50Grid.transform.childCount; i++)
		{
			Transform child = this.top50Grid.transform.GetChild(i);
			if (child.gameObject.activeSelf)
			{
				transform = child;
			}
		}
		if (transform != null)
		{
			this.singleRanksGrid.transform.position = transform.transform.position + Vector3.down * this.singleRanksGrid.VerticalGap;
		}
	}

	private void PositionLeaderboard(LeaderboardEntry target)
	{
		if (target == null)
		{
			return;
		}
		Transform transform = null;
		for (int i = 0; i < this.top50Grid.transform.childCount; i++)
		{
			Transform child = this.top50Grid.transform.GetChild(i);
			if (child.gameObject.activeSelf)
			{
				transform = child;
			}
		}
		if (transform == null)
		{
			return;
		}
		float num = this.leaderboardListScroller.UpperBound;
		Transform transform2 = target.transform;
		num -= transform2.localPosition.y;
		num -= (Mathf.Abs(this.leaderboardListScroller.UpperBound) + Mathf.Abs(this.leaderboardListScroller.LowerBound)) / 2f;
		this.singleRanksGrid.transform.position = transform.transform.position + Vector3.down * this.singleRanksGrid.VerticalGap;
		if (transform2.parent == this.singleRanksGrid.transform)
		{
			num -= transform.transform.localPosition.y + this.singleRanksGrid.VerticalGap;
		}
		num = Mathf.Clamp(num, this.leaderboardListScroller.UpperBound, this.leaderboardListScroller.LowerBound + this.leaderboardListScroller.TotalHeight);
		this.top50Grid.transform.localPosition = new Vector3(0f, num);
		this.singleRanksGrid.transform.position = transform.transform.position + Vector3.down * this.singleRanksGrid.VerticalGap;
	}

	private void OnTopLeaderboardResult(GetLeaderboardResult result)
	{
		this.currentLeaderboard = result.Leaderboard;
	}

	private void OnPlayerLeaderboardResult(GetLeaderboardAroundPlayerResult result)
	{
		this.currentPlayerLeaderboard = result.Leaderboard;
	}

	private void OnLeaderboardError(PlayFabError error)
	{
		if (this.currentView == LeaderboardDialog.LeaderboardView.Loading && this.loadingView == LeaderboardDialog.LeaderboardView.List)
		{
			this.ChangeView(LeaderboardDialog.LeaderboardView.Error, string.Empty);
		}
	}

	public void ShowPlayerInfo(string playerName, int playerScore, int playerRank, string playfabID)
	{
		string[] array = playerName.Split(new char[]
		{
			'|'
		});
		this.ChangeView(LeaderboardDialog.LeaderboardView.Loading, array[0]);
		this.loadingView = LeaderboardDialog.LeaderboardView.PlayerInfo;
		this.playerInfo.SetRankScoreInfo(playerRank + 1, playerScore, playfabID.Equals(HatchManager.CurrentPlayer.PlayFabID));
		this.playerInfo.SetRewards(CakeRaceMenu.GetSeasonCrateReward((int)CakeRaceMenu.GetCurrentLeaderboardCup(), playerRank + 1), CakeRaceMenu.GetSeasonSnoutCoinReward((int)CakeRaceMenu.GetCurrentLeaderboardCup(), playerRank + 1));
		Singleton<PlayFabManager>.Instance.Users.GetUserReplays(playfabID, new Action<GetUserDataResult>(this.OnPlayerInfoResult), new Action<PlayFabError>(this.OnPlayerInfoError));
	}

	private void UpdatePlayerInfo(Dictionary<string, UserDataRecord> replayData)
	{
		if (replayData == null)
		{
			this.ChangeView(LeaderboardDialog.LeaderboardView.List, string.Empty);
			return;
		}
		for (int i = 0; i < this.playerInfo.CakeRaceReplayCount; i++)
		{
			string text = string.Format("replay_track_{0}", i);
			if (replayData.ContainsKey(text))
			{
				CakeRaceReplay cakeRaceReplay = new CakeRaceReplay(replayData[text].Value);
				UnityEngine.Debug.LogWarning(string.Concat(new string[]
				{
					"[UpdatePlayerInfo] replay [",
					text,
					"][",
					replayData[text].Value,
					"]"
				}));
				this.playerInfo.UpdateReplayEntry(i, (!CakeRaceMenu.IsWeeklyTrack(i, cakeRaceReplay.UniqueIdentifier, true)) ? null : cakeRaceReplay);
			}
			else
			{
				this.playerInfo.UpdateReplayEntry(i, null);
			}
		}
		this.ChangeView(LeaderboardDialog.LeaderboardView.PlayerInfo, string.Empty);
	}

	private void OnPlayerInfoResult(GetUserDataResult result)
	{
		if (this.currentView == LeaderboardDialog.LeaderboardView.Loading && this.loadingView == LeaderboardDialog.LeaderboardView.PlayerInfo)
		{
			this.UpdatePlayerInfo(result.Data);
		}
	}

	private void OnPlayerInfoError(PlayFabError error)
	{
		if (this.currentView == LeaderboardDialog.LeaderboardView.Loading && this.loadingView == LeaderboardDialog.LeaderboardView.PlayerInfo)
		{
			this.UpdatePlayerInfo(null);
		}
	}

	private void UpdateDaysLeft()
	{
		string arg = string.Format("{0}", this.SeasonDaysLeft());
		Localizer.LocaleParameters localeParameters = Singleton<Localizer>.Instance.Resolve(this.daysLeftKey, null);
		TextMeshHelper.UpdateTextMeshes(this.daysLeftTextMesh, string.Format(localeParameters.translation, arg), false);
	}

	private int SeasonDaysLeft()
	{
		return (0 - Singleton<TimeManager>.Instance.ServerTime.DayOfWeek + 7) % 7;
	}

	public void OpenCupView()
	{
		this.ChangeView(LeaderboardDialog.LeaderboardView.CupInfo, this.GetCakeRaceCupsTitle());
	}

	public void ShowCupAnimation(int cupIndex)
	{
		this.showingCupAnimationPhase = 0;
		this.OpenCupView();
		this.cupInfo.ShowCupAnimation(cupIndex, delegate
		{
			this.showingCupAnimationPhase = 1;
		});
	}

	private string GetCakeRaceCupsTitle()
	{
		Localizer.LocaleParameters localeParameters = Singleton<Localizer>.Instance.Resolve("CR_CUP_TITLE", null);
		return localeParameters.translation;
	}

	[SerializeField]
	private GameObject entryPrefab;

	[SerializeField]
	private GameObject singleEntryPrefab;

	[SerializeField]
	private GameObject cakeRaceReplayEntryPrefab;

	[SerializeField]
	private GameObject[] viewContainers;

	[SerializeField]
	private GameObject cupButton;

	[SerializeField]
	private TextMesh[] daysLeftTextMesh;

	[SerializeField]
	private string daysLeftKey;

	[SerializeField]
	private int topRanks = 50;

	[SerializeField]
	private int[] singleRanks;

	private GridLayout top50Grid;

	private GridLayout singleRanksGrid;

	private GridLayout replayGrid;

	private string previousTitle = string.Empty;

	private string currentTitle = string.Empty;

	private LeaderboardView previousView = LeaderboardDialog.LeaderboardView.List;

	private LeaderboardView currentView = LeaderboardDialog.LeaderboardView.List;

	private LeaderboardView loadingView = LeaderboardDialog.LeaderboardView.List;

	private Dictionary<int, LeaderboardEntry> leaderboardEntries;

	private Dictionary<int, CakeRaceReplayEntry> cakeRaceReplayEntries;

	private LeaderboardPlayerInfo playerInfo;

	private LeaderboardCupInfo cupInfo;

	private int fetchingSingleLeaderboardEntryPosition = -1;

	private TextMesh[] titleLabel;

	private int showingCupAnimationPhase = -1;

	private int localPlayerRank = -1;

	private VerticalScroller leaderboardListScroller;

	private List<PlayerLeaderboardEntry> currentLeaderboard;

	private List<PlayerLeaderboardEntry> currentPlayerLeaderboard;

	private bool snoutCoinShopChangedToCupView;

	private enum LeaderboardView
	{
		Error,
		Loading,
		List,
		PlayerInfo,
		CupInfo
	}
}
