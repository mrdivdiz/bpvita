using System;
using System.Collections;
using System.Collections.Generic;
using CakeRace;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class CakeRaceMenu : WPFMonoBehaviour
{
	private static int CurrentSeasonIndex { get; set; }

	public static bool FindNewPlayer { get; set; }

	public static bool UseDefaultReplay { get; set; }

	public static bool IsCakeRaceMenuOpen { get; private set; }

	public static bool CakeRaceDisabled
	{
		get
		{
			return Singleton<GameConfigurationManager>.IsInstantiated() && Singleton<GameConfigurationManager>.Instance.GetValue<bool>("cake_race", "cake_race_disabled");
		}
	}

	public static bool IsTutorial
	{
		get
		{
			return GameProgress.GetInt("cake_race_total_wins", 0, GameProgress.Location.Local, null) < 3;
		}
	}

	public static string[] WeeklyTrackIdentifiers
	{
		get
		{
			int currentSeasonIndex = CakeRaceMenu.CurrentSeasonIndex;
			if (CakeRaceMenu.AllSeasonTracks != null && CakeRaceMenu.AllSeasonTracks.ContainsKey(currentSeasonIndex))
			{
				return CakeRaceMenu.AllSeasonTracks[currentSeasonIndex].ToArray();
			}
			return null;
		}
	}

	public static Dictionary<int, List<string>> AllSeasonTracks { get; private set; }

	private void Awake()
	{
		CakeRaceMenu.IsCakeRaceMenuOpen = true;
		EventManager.Connect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
		this.rewardPendingCup = PlayFabLeaderboard.LowestCup();
		Transform transform = base.transform.Find("HomeButton");
		if (transform != null)
		{
			this.backButton = transform.gameObject;
		}
	}

	private void OnDestroy()
	{
		CakeRaceMenu.IsCakeRaceMenuOpen = false;
		EventManager.Disconnect(new EventManager.OnEvent<PlayerChangedEvent>(this.OnPlayerChanged));
	}

	private void OnEnable()
	{
		TextMeshHelper.UpdateTextMeshes(this.daysLeftLabel, string.Empty, false);
		TextMeshHelper.UpdateTextMeshes(this.winsLabel, string.Empty, false);
		WPFMonoBehaviour.mainCamera.backgroundColor = this.skyColor;
		KeyListener.keyReleased += this.HandleKeyListenerkeyReleased;
		if (!CakeRaceMenu.CakeRaceDisabled)
		{
			this.SetLockScreen(true, string.Empty, true);
			Singleton<NetworkManager>.Instance.CheckAccess(delegate(bool online)
			{
				if (online && !HatchManager.HasLoginError)
				{
					this.InitRaceMenu();
				}
				else
				{
					this.SetLockScreen(true, this.offlineErrorKey, false);
				}
			});
		}
		else
		{
			this.SetLockScreen(true, this.cakeRaceDisabledErrorKey, false);
		}
		if (!GameProgress.GetBool("CakeRaceUnlockShown", false, GameProgress.Location.Local, null))
		{
			GameProgress.SetBool("CakeRaceUnlockShown", true, GameProgress.Location.Local);
		}
		this.InitSeasonTracks();
		bool active = false;
		if (this.infoLabel != null)
		{
			for (int i = 0; i < this.infoLabel.Length; i++)
			{
				if (this.infoLabel[i] != null)
				{
					this.infoLabel[i].gameObject.SetActive(active);
				}
			}
		}
		if (this.leaderboardButton != null)
		{
			Transform transform = this.leaderboardButton.transform.Find("Lock");
			if (CakeRaceMenu.IsTutorial)
			{
				transform.gameObject.SetActive(true);
				this.leaderboardButton.GetComponent<Button>().MethodToCall.Reset();
				this.leaderboardButton.AddComponent<ButtonAnimation>().ActivateAnimationName = "ButtonShake";
			}
			else
			{
				transform.gameObject.SetActive(false);
			}
			bool @bool = GameProgress.GetBool("leaderboard_opened", false, GameProgress.Location.Local, null);
			Transform transform2 = this.leaderboardButton.transform.Find("NewContentTag");
			transform2.gameObject.SetActive(!CakeRaceMenu.IsTutorial && !@bool);
		}
		this.UpdateCupIcon();
	}

	private void OnPlayerChanged(PlayerChangedEvent data)
	{
		if (Singleton<PlayerProgress>.IsInstantiated())
		{
			if (Singleton<PlayerProgress>.Instance.Level < PlayerLevelRequirement.GetRequiredLevel("cake_race"))
			{
				Singleton<GameManager>.Instance.LoadMainMenu(false);
			}
			else
			{
				Singleton<GameManager>.Instance.LoadCakeRaceMenu(false);
			}
		}
		else
		{
			Singleton<GameManager>.Instance.LoadMainMenu(false);
		}
	}

	private void InitSeasonTracks()
	{
		CakeRaceMenu.CurrentSeasonIndex = 0;
		CakeRaceMenu.AllSeasonTracks = new Dictionary<int, List<string>>();
		if (Singleton<GameConfigurationManager>.Instance.HasConfig("weekly_cake_race_tracks"))
		{
			ConfigData config = Singleton<GameConfigurationManager>.Instance.GetConfig("weekly_cake_race_tracks");
			for (int i = 0; i < config.Count; i++)
			{
				string key = i.ToString();
				if (config.HasKey(key))
				{
					string[] collection = config[key].Split(new char[]
					{
						','
					});
					List<string> value = new List<string>(collection);
					CakeRaceMenu.AllSeasonTracks.Add(i, value);
				}
			}
		}
	}

	private void InitRaceMenu()
	{
		if (CakeRaceMenu.FindNewPlayer && !this.lootCrateSlots.IsPopUpOpen())
		{
			this.SetInfoLabel("Seaching for new opponent...");
			this.StartRace();
			return;
		}
		this.UpdateWinCount();
		this.UpdateDaysLeft();
		this.SetInfoLabel("Connecting...");
		this.UpdateWeeklyTracks();
		if (!this.fetchingWeeklyTrackData)
		{
			this.SetInfoLabel("Ready to go");
		}
	}

	private void SetLockScreen(bool locked, string localeKey, bool loading)
	{
		if (this.lockScreen != null)
		{
			this.lockScreen.SetActive(locked);
			TextMesh[] componentsInChildren = this.lockScreen.GetComponentsInChildren<TextMesh>();
			TextMeshHelper.UpdateTextMeshes(componentsInChildren, localeKey, !string.IsNullOrEmpty(localeKey));
		}
		if (this.lockScreenLoading != null)
		{
			this.lockScreenLoading.SetActive(loading);
		}
	}

	private void UpdateCupIcon()
	{
		int num = -1;
		if (!CakeRaceMenu.IsTutorial)
		{
			num = CakeRaceMenu.GetCurrentLeaderboardCup() - PlayFabLeaderboard.Leaderboard.CakeRaceCupF;
		}
		for (int i = 0; i < this.cupIcons.Length; i++)
		{
			this.cupIcons[i].SetActive(num == i);
		}
	}

	private void UpdateWeeklyTracks()
	{
		if (this.fetchingWeeklyTrackData)
		{
			return;
		}
		this.fetchingWeeklyTrackData = true;
		Singleton<PlayFabManager>.Instance.MatchMaking.GetCakeRaceWeek(new Action<string, string>(this.OnCakeRaceWeekFetched));
	}

	private void OnCakeRaceWeekFetched(string week, string daysLeft)
	{
		if (!CakeRaceMenu.IsCakeRaceMenuOpen)
		{
			return;
		}
		this.fetchingWeeklyTrackData = false;
		int num = GameProgress.GetInt("cake_race_current_cup", (int)PlayFabLeaderboard.LowestCup(), GameProgress.Location.Local, null);
		int num2;
		if (int.TryParse(week, out num2))
		{
			int num3 = CakeRaceMenu.CurrentCakeRaceWeek();
			GameProgress.SetInt("cake_race_current_week", num2, GameProgress.Location.Local);
			if (!CakeRaceMenu.IsTutorial && num3 != num2)
			{
				PlayFabLeaderboard.Leaderboard currentLeaderboardCup = CakeRaceMenu.GetCurrentLeaderboardCup();
				Singleton<CakeRaceKingsFavorite>.Instance.ClearCurrentFavorite();
				CakeRaceMode.ClearPersonalBestData();
				CakeRaceMenu.ClearCloudTrackData();
				int cupIndexFromPlayerLevel = CakeRaceMenu.GetCupIndexFromPlayerLevel();
				if (num != cupIndexFromPlayerLevel)
				{
					num = cupIndexFromPlayerLevel;
					GameProgress.SetInt("cake_race_current_cup", num, GameProgress.Location.Local);
					GameProgress.SetBool("cake_race_show_cup_animation", true, GameProgress.Location.Local);
				}
				if (GameProgress.HasKey("cake_race_current_cup", GameProgress.Location.Local, null))
				{
					this.RewardCupPlayer(currentLeaderboardCup);
				}
				else
				{
					GameProgress.SetInt("cake_race_current_cup", num, GameProgress.Location.Local);
					base.StartCoroutine(this.WaitPopUpAndShowCupEndAnimation());
				}
			}
		}
		else
		{
			num2 = 0;
		}
		string str = "[CakeRaceMenu] current cup is ";
		PlayFabLeaderboard.Leaderboard leaderboard = (PlayFabLeaderboard.Leaderboard)num;
		UnityEngine.Debug.LogWarning(str + leaderboard.ToString());
		int num4 = 0;
		if (Singleton<GameConfigurationManager>.Instance.HasValue("cake_race", "week_offset"))
		{
			num4 = Singleton<GameConfigurationManager>.Instance.GetValue<int>("cake_race", "week_offset");
		}
		CakeRaceMenu.CurrentSeasonIndex = Mathf.Clamp(num2 + num4, 0, int.MaxValue) % CakeRaceMenu.WeeklyTrackIdentifiers.Length;
		if (!CakeRaceMenu.AllSeasonTracks.ContainsKey(CakeRaceMenu.CurrentSeasonIndex))
		{
			CakeRaceMenu.CurrentSeasonIndex = 0;
		}
		if (this.HasWeeklyData())
		{
			this.SetInfoLabel("Ready to go");
		}
		else
		{
			this.SetInfoLabel("Error fetching tracks");
		}
		this.UpdateDaysLeft();
		if (!this.isRewardingPlayer)
		{
			this.TryToUnlockCakeRaceLockScreen();
		}
	}

	private IEnumerator WaitPopUpAndShowCupEndAnimation()
	{
		WaitForSeconds wfs = new WaitForSeconds(0.1f);
		while (this.lootCrateSlots.IsPopUpOpen())
		{
			yield return wfs;
		}
		this.TryToShowCupEndAnimation(true);
		yield break;
	}

	private void TryToUnlockCakeRaceLockScreen()
	{
		bool locked = true;
		if (Singleton<GameConfigurationManager>.Instance.HasValue("cake_race", "version"))
		{
			string value = Singleton<GameConfigurationManager>.Instance.GetValue<string>("cake_race", "version");
			if (!string.IsNullOrEmpty(value) && value.Equals("1.0.0"))
			{
				locked = false;
			}
		}
		this.SetLockScreen(locked, this.cakeRaceVersionErrorKey, false);
	}

	public static int GetCupIndexFromPlayerLevel()
	{
		int num = (int)PlayFabLeaderboard.LowestCup();
		int level = Singleton<PlayerProgress>.Instance.Level;
		if (Singleton<PlayerProgress>.IsInstantiated())
		{
			for (int i = (int)PlayFabLeaderboard.HighestCup(); i >= (int)PlayFabLeaderboard.LowestCup(); i--)
			{
				string valueKey = i.ToString();
				if (Singleton<GameConfigurationManager>.Instance.HasValue("cake_race_cup_requirements", valueKey) && level >= Singleton<GameConfigurationManager>.Instance.GetValue<int>("cake_race_cup_requirements", valueKey))
				{
					return i;
				}
			}
		}
		return (int)PlayFabLeaderboard.LowestCup();
	}

	private void RewardCupPlayer(PlayFabLeaderboard.Leaderboard currentLeaderboard)
	{
		this.rewardPendingCup = currentLeaderboard;
		this.isRewardingPlayer = true;
		Singleton<PlayFabManager>.Instance.Leaderboard.GetLeaderboardAroundPlayer(this.rewardPendingCup, new Action<GetLeaderboardAroundPlayerResult>(this.OnRankFetched), new Action<PlayFabError>(this.OnRankError), true, 1);
	}

	private void TryToShowCupEndAnimation(bool forceShow = false)
	{
		if (forceShow || GameProgress.GetBool("cake_race_show_cup_animation", false, GameProgress.Location.Local, null))
		{
			GameProgress.SetBool("cake_race_show_cup_animation", false, GameProgress.Location.Local);
			this.OpenLeaderboardDialog();
			this.leaderboardDialog.ShowCupAnimation(GameProgress.GetInt("cake_race_current_cup", (int)PlayFabLeaderboard.LowestCup(), GameProgress.Location.Local, null));
		}
	}

	private void OnRankError(PlayFabError error)
	{
		if (!CakeRaceMenu.IsCakeRaceMenuOpen)
		{
			return;
		}
		this.rewardPendingCup = PlayFabLeaderboard.LowestCup();
		this.isRewardingPlayer = false;
		this.TryToUnlockCakeRaceLockScreen();
	}

	private IEnumerator WaitPopUpAndTryRankReward(GetLeaderboardAroundPlayerResult result)
	{
		WaitForSeconds wfs = new WaitForSeconds(0.1f);
		while (this.lootCrateSlots.IsPopUpOpen())
		{
			yield return wfs;
		}
		this.OnRankFetched(result);
		yield break;
	}

	private void OnRankFetched(GetLeaderboardAroundPlayerResult result)
	{
		if (!CakeRaceMenu.IsCakeRaceMenuOpen)
		{
			return;
		}
		if (this.lootCrateSlots.IsPopUpOpen())
		{
			base.StartCoroutine(this.WaitPopUpAndTryRankReward(result));
			return;
		}
		if (result.Leaderboard == null || (result.Leaderboard.Count > 0 && (result.Leaderboard[0].StatValue <= 0 || result.Leaderboard[0].Position >= 500)))
		{
			this.TryToShowCupEndAnimation(false);
			this.TryToUnlockCakeRaceLockScreen();
			return;
		}
		GameObject go = UnityEngine.Object.Instantiate<GameObject>(this.seasonEndDialogPopup, Vector3.zero, Quaternion.identity);
		go.transform.position += Vector3.back * 20f;
		this.seasonEndDialog = go.GetComponent<LeaderboardSeasonEndDialog>();
		this.seasonEndDialog.SetLoading(true);
		this.seasonEndDialog.onClose += delegate()
		{
			UnityEngine.Object.Destroy(go);
		};
		int currentCupIndex = (int)this.rewardPendingCup;
		int rank = result.Leaderboard[0].Position + 1;
		int @int = GameProgress.GetInt("cake_race_highest_rank", 0, GameProgress.Location.Local, null);
		if (@int <= 0 || rank < @int)
		{
			GameProgress.SetInt("cake_race_highest_rank", rank, GameProgress.Location.Local);
		}
		string text = string.Empty;
		if (rank != 1)
		{
			if (rank != 2)
			{
				if (rank == 3)
				{
					text = "cake_race_bronze_trophies_won";
				}
			}
			else
			{
				text = "cake_race_silver_trophies_won";
			}
		}
		else
		{
			text = "cake_race_gold_trophies_won";
		}
		if (!string.IsNullOrEmpty(text))
		{
			int int2 = GameProgress.GetInt(text, 0, GameProgress.Location.Local, null);
			GameProgress.SetInt(text, int2 + 1, GameProgress.Location.Local);
		}
		int seasonSnoutCoinReward = CakeRaceMenu.GetSeasonSnoutCoinReward(currentCupIndex, rank);
		if (seasonSnoutCoinReward > 0)
		{
			GameProgress.AddSnoutCoins(seasonSnoutCoinReward);
			int int3 = GameProgress.GetInt("cake_race_coins_won", 0, GameProgress.Location.Local, null);
			GameProgress.SetInt("cake_race_coins_won", int3 + seasonSnoutCoinReward, GameProgress.Location.Local);
		}
		LootCrateType crateType = CakeRaceMenu.GetSeasonCrateReward(currentCupIndex, rank);
		if (crateType != LootCrateType.None)
		{
			this.seasonEndDialog.onClose += delegate()
			{
				LootCrate.SpawnLootCrateOpeningDialog(crateType, 1, WPFMonoBehaviour.s_hudCamera, new Dialog.OnClose(this.OnDialogClosed), new LootCrate.AnalyticData(string.Format("{0}_reward", (PlayFabLeaderboard.Leaderboard)currentCupIndex), "0", LootCrate.AdWatched.NotApplicaple));
			};
		}
		else
		{
			this.seasonEndDialog.onClose += this.OnDialogClosed;
		}
		this.seasonEndDialog.SetCrateRankAndReward(crateType, rank, seasonSnoutCoinReward);
		this.isRewardingPlayer = false;
	}

	private void OnDialogClosed()
	{
		this.TryToShowCupEndAnimation(false);
		this.TryToUnlockCakeRaceLockScreen();
	}

	public static int GetSeasonSnoutCoinReward(int cupIndex, int rank)
	{
		if (rank <= 0)
		{
			return 0;
		}
		int num = 0;
		if (Singleton<GameConfigurationManager>.Instance.HasValue("cake_race_cup_reward_multipliers", cupIndex.ToString()))
		{
			num = Singleton<GameConfigurationManager>.Instance.GetValue<int>("cake_race_cup_reward_multipliers", cupIndex.ToString());
		}
		ConfigData config = Singleton<GameConfigurationManager>.Instance.GetConfig("cake_race_cup_snout_rewards");
		int num2 = 0;
		if (config != null && config.Keys != null && config.Keys.Length > 0)
		{
			int num3 = -1;
			int num4 = int.MaxValue;
			for (int i = 0; i < config.Keys.Length; i++)
			{
				int num5;
				if (int.TryParse(config.Keys[i], out num5) && num5 > 0 && num5 < num4 && rank <= num5)
				{
					num4 = num5;
					num3 = i;
				}
			}
			if (num3 >= 0 && num3 < config.Values.Length && int.TryParse(config.Values[num3], out num2))
			{
				num2 += Mathf.RoundToInt((float)num2 * (0.01f * (float)num));
			}
			else
			{
				num2 = 0;
			}
		}
		return num2;
	}

	public static LootCrateType GetSeasonCrateReward(int cupIndex, int rank)
	{
		LootCrateType result = LootCrateType.None;
		if (rank > 0 && rank <= 5 && Singleton<GameConfigurationManager>.Instance.HasValue("cake_race_cup_crate_rewards", cupIndex.ToString()))
		{
			result = (LootCrateType)Singleton<GameConfigurationManager>.Instance.GetValue<int>("cake_race_cup_crate_rewards", cupIndex.ToString());
		}
		return result;
	}

	private void OnDisable()
	{
		KeyListener.keyReleased -= this.HandleKeyListenerkeyReleased;
	}

	private void HandleKeyListenerkeyReleased(KeyCode obj)
	{
		if (Singleton<GuiManager>.Instance.enabled && obj == KeyCode.Escape)
		{
			this.GoToMainMenu();
		}
	}

	private void Update()
	{
		if (this.cloudRenderer != null)
		{
			this.currentOffset += GameTime.RealTimeDelta * this.cloudSpeed;
			if (this.currentOffset > 1f)
			{
				this.currentOffset -= 1f;
			}
			else if (this.currentOffset < -1f)
			{
				this.currentOffset += 1f;
			}
			this.cloudRenderer.material.SetTextureOffset("_MainTex", Vector2.right * this.currentOffset);
		}
	}

	private bool HasWeeklyData()
	{
		return CakeRaceMenu.WeeklyTrackIdentifiers != null && CakeRaceMenu.WeeklyTrackIdentifiers.Length >= 7;
	}

	public static bool IsWeeklyTrack(int index, string uniqueIdentifier, bool ignoreTutorial = false)
	{
		return CakeRaceMenu.GetTrackIndex(uniqueIdentifier, ignoreTutorial) == index;
	}

	private int GetWeeklyTrackIndex()
	{
		return this.currentWeeklyTrackIndex;
	}

	private int GenerateNewWeeklyTrackIndex()
	{
		if (CakeRaceMenu.WinCount >= 14)
		{
			this.currentWeeklyTrackIndex = UnityEngine.Random.Range(0, 7);
		}
		else
		{
			this.currentWeeklyTrackIndex = CakeRaceMenu.WinCount % 7;
		}
		return this.currentWeeklyTrackIndex;
	}

	public void StartRace()
	{
		if (CakeRaceMenu.WinCount < 0 || !this.HasWeeklyData())
		{
			this.SetInfoLabel("Error getting cake race data");
			this.UpdateWeeklyTracks();
			return;
		}
		CakeRaceMenu.FindNewPlayer = false;
		CakeRaceMenu.UseDefaultReplay = false;
		DateTime serverTime = Singleton<TimeManager>.Instance.ServerTime;
		DateTime value = serverTime;
		if (!GameProgress.HasKey("cake_race_first_day", GameProgress.Location.Local, null))
		{
			GameProgress.SetString("cake_race_first_day", value.ToShortDateString(), GameProgress.Location.Local);
		}
		else
		{
			value = DateTime.Parse(GameProgress.GetString("cake_race_first_day", string.Empty, GameProgress.Location.Local, null));
		}
		TimeSpan timeSpan = serverTime.Subtract(value);
		DateTime value2 = serverTime;
		if (GameProgress.HasKey("cake_race_last_played", GameProgress.Location.Local, null))
		{
			value2 = DateTime.Parse(GameProgress.GetString("cake_race_last_played", DateTime.MinValue.ToShortDateString(), GameProgress.Location.Local, null));
		}
		GameProgress.SetString("cake_race_last_played", serverTime.ToShortDateString(), GameProgress.Location.Local);
		int num = GameProgress.GetInt("cake_race_days_played", 1, GameProgress.Location.Local, null);
		if (serverTime.Subtract(value2).TotalHours > 12.0)
		{
			GameProgress.SetInt("cake_race_days_played", ++num, GameProgress.Location.Local);
		}
		this.GenerateNewWeeklyTrackIndex();
		if (CakeRaceMenu.IsTutorial)
		{
			CakeRaceMenu.UseDefaultReplay = true;
			this.OnReplayFetched(null);
		}
		else
		{
			this.FindOpponent();
		}
	}

	private void FindOpponent()
	{
		if (this.HasWeeklyData())
		{
			Singleton<GuiManager>.Instance.enabled = false;
			this.SetInfoLabel("Searching for opponent");
			string currentSeasonID = CakeRaceMode.GetCurrentSeasonID();
			string key = string.Format("Season_{0}_wins", currentSeasonID);
			string key2 = string.Format("Season_{0}_losses", currentSeasonID);
			int @int = GameProgress.GetInt(key, 0, GameProgress.Location.Local, null);
			int int2 = GameProgress.GetInt(key2, 0, GameProgress.Location.Local, null);
			Singleton<PlayFabManager>.Instance.MatchMaking.FindOpponentReplay(this.GetWeeklyTrackIndex(), Singleton<PlayerProgress>.Instance.Level, @int - int2, new Action<string>(this.OnReplayFetched));
		}
		else
		{
			this.SetInfoLabel("Error fetching tracks");
			this.UpdateWeeklyTracks();
		}
	}

	private void OnReplayFetched(string replayJson)
	{
		if (!CakeRaceMenu.IsCakeRaceMenuOpen)
		{
			return;
		}
		if (CakeRaceMenu.UseDefaultReplay || string.IsNullOrEmpty(replayJson))
		{
			this.LoadDefaultReplay();
		}
		else
		{
			UnityEngine.Debug.LogWarning("[OnReplayFetched]\n" + replayJson);
			Singleton<GuiManager>.Instance.enabled = true;
			CakeRaceReplay cakeRaceReplay = new CakeRaceReplay(replayJson);
			if (cakeRaceReplay.IsValid)
			{
				if (CakeRaceMenu.IsWeeklyTrack(this.currentWeeklyTrackIndex, cakeRaceReplay.UniqueIdentifier, false))
				{
					CakeRaceInfo? cakeRaceInfo;
					if (WPFMonoBehaviour.gameData.m_cakeRaceData.GetInfo(cakeRaceReplay.UniqueIdentifier, out cakeRaceInfo))
					{
						CakeRaceMode.OpponentReplay = cakeRaceReplay;
						this.SetInfoLabel("Opponent found");
						this.LoadCakeRaceLevel(cakeRaceInfo.Value);
					}
					else
					{
						this.SetInfoLabel("Opponent replay has unknown level");
						this.LoadDefaultReplay();
					}
				}
				else
				{
					this.SetInfoLabel("Opponent replay not from this week");
					this.LoadDefaultReplay();
				}
			}
			else
			{
				this.SetInfoLabel("Opponent replay is invalid");
				this.LoadDefaultReplay();
			}
		}
	}

	private void LoadDefaultReplay()
	{
		CakeRaceMenu.UseDefaultReplay = false;
		CakeRaceInfo? cakeRaceInfo;
		if (WPFMonoBehaviour.gameData.m_cakeRaceData.GetInfo(CakeRaceMenu.WeeklyTrackIdentifiers[this.GetWeeklyTrackIndex()], out cakeRaceInfo))
		{
			CakeRaceMode.OpponentReplay = new CakeRaceReplay(cakeRaceInfo.Value.Replay);
			CakeRaceMode.OpponentReplay.SetPlayerLevel(Singleton<PlayerProgress>.Instance.Level);
			CakeRaceMode.OpponentReplay.SetPlayerName("Hogster");
			UnityEngine.Debug.LogWarning("[OnReplayFetched] DefaultOpponent\n" + cakeRaceInfo.Value.Replay);
			this.SetInfoLabel("Default Opponent found");
			this.LoadCakeRaceLevel(cakeRaceInfo.Value);
		}
		else
		{
			this.SetInfoLabel("Error 404 for track " + CakeRaceMenu.WeeklyTrackIdentifiers[this.GetWeeklyTrackIndex()]);
		}
	}

	private void LoadCakeRaceLevel(CakeRaceInfo info)
	{
		CakeRaceMode.CurrentCakeRaceInfo = info;
		if (!string.IsNullOrEmpty(info.Identifier))
		{
			if (info.Identifier.StartsWith("S"))
			{
				LevelManager.GameModeIndex = 1;
				Singleton<GameManager>.Instance.LoadSandboxLevel(info.Identifier, 0);
				Singleton<GuiManager>.Instance.enabled = false;
			}
			else if (info.Identifier.StartsWith("R"))
			{
				LevelManager.GameModeIndex = 1;
				Singleton<GameManager>.Instance.LoadRaceLevel(info.Identifier);
				Singleton<GuiManager>.Instance.enabled = false;
			}
			else
			{
				this.SetInfoLabel("Replay not supported");
			}
		}
		else
		{
			this.SetInfoLabel("Level type not supported");
		}
	}

	private void UpdateWinCount()
	{
		if (CakeRaceMenu.WinCount >= 0)
		{
			this.SetWinCount(CakeRaceMenu.WinCount);
			return;
		}
		string key = "Statistics_" + PlayFabLeaderboard.Leaderboard.CakeRaceWins.ToString();
		if (GameProgress.HasKey(key, GameProgress.Location.Local, null))
		{
			this.SetWinCount(GameProgress.GetInt(key, 0, GameProgress.Location.Local, null));
		}
		else if (Singleton<PlayFabManager>.Instance.Initialized)
		{
			Singleton<PlayFabManager>.Instance.Leaderboard.GetScore(PlayFabLeaderboard.Leaderboard.CakeRaceWins, new Action<GetPlayerStatisticsResult>(this.OnWinCountSuccess), new Action<PlayFabError>(this.OnWinCountError));
		}
		else
		{
			this.SetWinCount(0);
		}
	}

	private void OnWinCountSuccess(GetPlayerStatisticsResult result)
	{
		if (!CakeRaceMenu.IsCakeRaceMenuOpen)
		{
			return;
		}
		string value = PlayFabLeaderboard.Leaderboard.CakeRaceWins.ToString();
		foreach (StatisticValue statisticValue in result.Statistics)
		{
			if (statisticValue.StatisticName.Equals(value))
			{
				this.SetWinCount(statisticValue.Value);
				return;
			}
		}
		this.SetWinCount(0);
	}

	private void OnWinCountError(PlayFabError error)
	{
		if (!CakeRaceMenu.IsCakeRaceMenuOpen)
		{
			return;
		}
		this.SetWinCount(0);
	}

	private void SetWinCount(int wins)
	{
		CakeRaceMenu.WinCount = wins;
		if (CakeRaceMenu.IsTutorial)
		{
			Localizer.LocaleParameters localeParameters = Singleton<Localizer>.Instance.Resolve(this.winsLabelKey, null);
			TextMeshHelper.UpdateTextMeshes(this.winsLabel, string.Format(localeParameters.translation, CakeRaceMenu.WinCount), false);
			TextMeshHelper.Wrap(this.winsLabel, (!TextMeshHelper.UsesKanjiCharacters()) ? 1 : 6);
		}
		else
		{
			TextMeshHelper.UpdateTextMeshes(this.winsLabel, string.Empty, false);
		}
	}

	private void UpdateDaysLeft()
	{
		string arg = string.Format("{0}", this.SeasonDaysLeft());
		Localizer.LocaleParameters localeParameters = Singleton<Localizer>.Instance.Resolve(this.daysLeftLabelKey, null);
		TextMeshHelper.UpdateTextMeshes(this.daysLeftLabel, string.Format(localeParameters.translation, arg), false);
		TextMeshHelper.Wrap(this.daysLeftLabel, 5);
	}

	private int SeasonDaysLeft()
	{
		return (0 - Singleton<TimeManager>.Instance.ServerTime.DayOfWeek + 7) % 7;
	}

	public void GoToMainMenu()
	{
		LevelManager.GameModeIndex = 0;
		Singleton<GameManager>.Instance.LoadMainMenu(false);
	}

	private void SetInfoLabel(string text = "")
	{
	}

	public void OpenLeaderboardDialog()
	{
		if (this.leaderboardDialogPrefab == null)
		{
			return;
		}
		if (this.leaderboardDialog == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.leaderboardDialogPrefab, 15f * Vector3.back + Vector3.down, Quaternion.identity);
			this.leaderboardDialog = gameObject.GetComponent<LeaderboardDialog>();
		}
		this.leaderboardDialog.Open();
		if (!GameProgress.GetBool("leaderboard_opened", false, GameProgress.Location.Local, null))
		{
			GameProgress.SetBool("leaderboard_opened", true, GameProgress.Location.Local);
			Transform transform = this.leaderboardButton.transform.Find("NewContentTag");
			transform.gameObject.SetActive(false);
		}
	}

	public static int GetTrackIndex(string uniqueIdentifier, bool ignoreTutorial = false)
	{
		string[] array = CakeRaceMenu.WeeklyTrackIdentifiers;
		if (ignoreTutorial)
		{
			if (CakeRaceMenu.AllSeasonTracks == null || !CakeRaceMenu.AllSeasonTracks.ContainsKey(CakeRaceMenu.CurrentSeasonIndex))
			{
				return -1;
			}
			array = CakeRaceMenu.AllSeasonTracks[CakeRaceMenu.CurrentSeasonIndex].ToArray();
		}
		if (array != null && array.Length > 0)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null && array[i].Equals(uniqueIdentifier))
				{
					return i;
				}
			}
		}
		return -1;
	}

	public static PlayFabLeaderboard.Leaderboard GetCurrentLeaderboardCup()
	{
		return (PlayFabLeaderboard.Leaderboard)GameProgress.GetInt("cake_race_current_cup", (int)PlayFabLeaderboard.LowestCup(), GameProgress.Location.Local, null);
	}

	public static int CurrentCakeRaceWeek()
	{
		return GameProgress.GetInt("cake_race_current_week", 0, GameProgress.Location.Local, null);
	}

	public static void ClearCloudTrackData()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		for (int i = 0; i < 7; i++)
		{
			dictionary.Add(string.Format("replay_track_{0}", i), string.Empty);
		}
		Singleton<PlayFabManager>.Instance.UpdateUserData(dictionary, UserDataPermission.Public);
	}

	[SerializeField]
	private Color skyColor;

	[SerializeField]
	private MeshRenderer cloudRenderer;

	[SerializeField]
	private float cloudSpeed = 0.1f;

	[SerializeField]
	private TextMesh[] infoLabel;

	[SerializeField]
	private TextMesh[] daysLeftLabel;

	[SerializeField]
	private string daysLeftLabelKey;

	[SerializeField]
	private TextMesh[] winsLabel;

	[SerializeField]
	private string winsLabelKey;

	[SerializeField]
	private LootCrateSlots lootCrateSlots;

	[SerializeField]
	private GameObject lockScreen;

	[SerializeField]
	private GameObject leaderboardButton;

	[SerializeField]
	private GameObject lockScreenLoading;

	[SerializeField]
	private string cakeRaceVersionErrorKey;

	[SerializeField]
	private string offlineErrorKey;

	[SerializeField]
	private string cakeRaceDisabledErrorKey;

	[SerializeField]
	private GameObject leaderboardDialogPrefab;

	[SerializeField]
	private GameObject seasonEndDialogPopup;

	[SerializeField]
	private GameObject[] cupIcons;

	private LeaderboardDialog leaderboardDialog;

	private LeaderboardSeasonEndDialog seasonEndDialog;

	private float currentOffset;

	private bool fetchingWeeklyTrackData;

	private bool isRewardingPlayer;

	private int currentWeeklyTrackIndex;

	private PlayFabLeaderboard.Leaderboard rewardPendingCup;

	private GameObject backButton;

	public static int WinCount = -1;

	public const string GAMEPROGRESS_CAKE_RACE_CUP_KEY = "cake_race_current_cup";

	public const string GAMEPROGRESS_CAKE_RACE_WEEK_KEY = "cake_race_current_week";

	private const string GAMEPROGRESS_SHOW_CUP_ANIMATION = "cake_race_show_cup_animation";

	public const string GAMEPROGRESS_GOLD_TROPHIES_WON = "cake_race_gold_trophies_won";

	public const string GAMEPROGRESS_SILVER_TROPHIES_WON = "cake_race_silver_trophies_won";

	public const string GAMEPROGRESS_BRONZE_TROPHIES_WON = "cake_race_bronze_trophies_won";

	public const string GAMEPROGRESS_CAKE_RACE_COINS_WON = "cake_race_coins_won";

	public const string GAMEPROGRESS_CAKE_RACE_HIGHEST_RANK = "cake_race_highest_rank";

	private const string WEEKLY_CAKE_RACE_TRACKS_KEY = "weekly_cake_race_tracks";

	private const string WEEKLY_CAKE_RACE_OFFSET_KEY = "week_offset";

	private const string CAKE_RACE_KEY = "cake_race";

	private const string CAKE_RACE_CUP_REQUIREMENTS = "cake_race_cup_requirements";

	private const string CAKE_RACE_CUP_SNOUT_REWARDS = "cake_race_cup_snout_rewards";

	private const string CAKE_RACE_CUP_REWARD_MULTIPLIERS = "cake_race_cup_reward_multipliers";

	private const string CAKE_RACE_CUP_CRATE_REWARDS = "cake_race_cup_crate_rewards";
}
