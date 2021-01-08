using CakeRace;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CakeRaceMode : GameMode
{
    public bool IsRaceOn { get; private set; }

    public bool LocalPlayerIsWinner
    {
        get
        {
            return this.CurrentScore >= this.OpponentScore;
        }
    }

    public int CollectedCakes { get; private set; }

    public float RaceTimeLeft { get; private set; }

    public int CurrentScore { get; private set; }

    public int OpponentScore { get; set; }

    private float CollectMultiplier { get; set; }

    private float ExplodeMultiplier { get; set; }

    public int GainedXP
    {
        get
        {
            return this.gainedXP;
        }
    }

    private string TutorialPromotionCount
    {
        get
        {
            return string.Format("{0}_{1}", "Tutorial_Promotion_Count", base.gameManager.CurrentSceneName);
        }
    }

    private string MechanicPromotionCount
    {
        get
        {
            return string.Format("{0} {1}", "Mechanic_Promotion_Count", base.gameManager.CurrentSceneName);
        }
    }

    public static CakeRaceReplay OpponentReplay { get; set; }

    public static CakeRaceReplay CurrentReplay { get; set; }

    public static CakeRaceInfo CurrentCakeRaceInfo
    {
        get
        {
            return CakeRaceMode.cakeRaceInfo.Value;
        }
        set
        {
            CakeRaceMode.cakeRaceInfo = new CakeRaceInfo?(value);
        }
    }

    public static LootCrateType CurrentRewardCrate { get; private set; }

    public int CurrentTrackIndex
    {
        get
        {
            return CakeRaceMode.currentRaceTrackIndex;
        }
    }

    public static bool IsPreviewMode
    {
        get
        {
            return false;
        }
    }

    public override void InitGameMode()
    {
        CakeRaceInfo? cakeRaceInfo = CakeRaceMode.cakeRaceInfo;
        if (cakeRaceInfo == null)
        {
            this.FindCakeRaceInfo(CakeRaceMode.currentRaceTrackIndex);
        }
        else
        {
            CakeRaceMode.currentRaceTrackIndex = CakeRaceMode.cakeRaceInfo.Value.TrackIndex;
        }
        this.gainedXP = 0;
        this.IsRaceOn = false;
        this.InitScoreVariables();
        this.CreateCakes();
        this.CreateProps();
        base.Preview = this.CreatePreview();
        base.CurrentConstructionGridRows = CakeRaceMode.cakeRaceInfo.Value.Start.GridData;
        base.CameraLimits = CakeRaceMode.cakeRaceInfo.Value.CameraLimits;
        base.GridCellPrefab = CakeRaceMode.cakeRaceInfo.Value.GridCellPrefab;
        base.TutorialPage = CakeRaceMode.cakeRaceInfo.Value.TutorialBookPrefab;
        int num = 1;
        int newGridHeight = 1;
        for (int i = 0; i < base.CurrentConstructionGridRows.Count; i++)
        {
            if (base.CurrentConstructionGridRows[i] != 0)
            {
                int numberOfHighestBit = WPFMonoBehaviour.GetNumberOfHighestBit(base.CurrentConstructionGridRows[i]);
                if (numberOfHighestBit + 1 > num)
                {
                    num = numberOfHighestBit + 1;
                }
                newGridHeight = i + 1;
            }
        }
        int newGridXMin = -(num - 1) / 2;
        int newGridXMax = num / 2;
        this.levelManager.CreateGrid(num, newGridHeight, newGridXMin, newGridXMax, CakeRaceMode.cakeRaceInfo.Value.Start.Position);
        base.ContraptionProto.transform.position = CakeRaceMode.cakeRaceInfo.Value.Start.Position;
        this.InitParts();
        base.CameraOffset = new Vector3(0f, 15f, 0f);
        base.PreviewOffset = new Vector3(0f, 15f, 0f);
        base.ConstructionOffset = new Vector3(0f, 0f, 0f);
        this.timeRunning = false;
        if (this.levelManager.ConstructionUI)
        {
            if (GameProgress.HasKey(SchematicButton.LastLoadedSlotKey, GameProgress.Location.Local, null))
            {
                base.CurrentContraptionIndex = GameProgress.GetInt(SchematicButton.LastLoadedSlotKey, 0, GameProgress.Location.Local, null);
            }
            base.BuildContraption(WPFPrefs.LoadContraptionDataset(base.GetCurrentContraptionName()));
            foreach (ConstructionUI.PartDesc partDesc in this.levelManager.ConstructionUI.PartDescriptors)
            {
                EventManager.Send(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
            }
        }
        EventManager.Connect(new EventManager.OnEvent<TimeBomb.BombOutOfBounds>(this.OnBombOutOfBounds));
    }

    private void InitScoreVariables()
    {
        this.CollectMultiplier = 1f;
        this.ExplodeMultiplier = 0.1f;
    }

    private void InitParts()
    {
        if (this.parts != null)
        {
            return;
        }
        this.parts = new List<LevelManager.PartCount>(CakeRaceMode.cakeRaceInfo.Value.CustomParts);
        BasePart currentFavorite = Singleton<CakeRaceKingsFavorite>.Instance.CurrentFavorite;
        bool flag = false;
        bool flag2 = false;
        foreach (LevelManager.PartCount partCount in this.parts)
        {
            if (partCount.type == BasePart.PartType.TimeBomb)
            {
                flag = true;
                partCount.count = 1;
            }
            if (!flag2 && currentFavorite != null && partCount.type == currentFavorite.m_partType)
            {
                flag2 = true;
            }
        }
        if (!flag)
        {
            LevelManager.PartCount partCount2 = new LevelManager.PartCount();
            partCount2.type = BasePart.PartType.TimeBomb;
            partCount2.count = 1;
            this.parts.Add(partCount2);
        }
        if (!flag2 && currentFavorite != null)
        {
            LevelManager.PartCount partCount3 = new LevelManager.PartCount();
            partCount3.type = currentFavorite.m_partType;
            partCount3.count = 1;
            this.parts.Add(partCount3);
        }
    }

    public override void OnDataLoadedDone()
    {
        PartBox[] array = UnityEngine.Object.FindObjectsOfType<PartBox>();
        if (array != null && array.Length > 0)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].gameObject.SetActive(false);
            }
        }
        for (int j = 0; j < StarBox.StarBoxes.Count; j++)
        {
            StarBox.StarBoxes[j].gameObject.SetActive(false);
        }
        for (int k = 0; k < Challenge.Challenges.Count; k++)
        {
            Challenge.Challenges[k].gameObject.SetActive(false);
        }
        if (this.levelManager.GoalPosition != null)
        {
            this.levelManager.GoalPosition.gameObject.SetActive(false);
        }
        this.levelManager.m_sandbox = false;
        this.levelManager.m_raceLevel = false;
        Singleton<GuiManager>.Instance.enabled = true;
    }

    public override void OnDataLoadedStart()
    {
    }

    public override void CleanUp()
    {
        base.CleanUp();
        EventManager.Disconnect(new EventManager.OnEvent<TimeBomb.BombOutOfBounds>(this.OnBombOutOfBounds));
        CakeRaceMode.cakeRaceInfo = null;
    }

    public override void Update()
    {
        if (this.levelManager.gameState == LevelManager.GameState.Running && this.IsRaceOn)
        {
            if (this.timeRunning)
            {
                this.RaceTimeLeft -= Time.deltaTime;
                if (this.RaceTimeLeft <= 0f)
                {
                    this.EndRace(-1, true);
                }
            }
            else
            {
                this.timeRunning = ((base.ContraptionRunning.FindPig().transform.position - this.levelManager.PigStartPosition).magnitude >= 1f);
                if (this.timeRunning)
                {
                    EventManager.Send(new UIEvent(UIEvent.Type.CakeRaceTimerStarted));
                }
            }
        }
        base.Update();
    }

    public override LevelManager.GameState SetGameState(LevelManager.GameState currentState, LevelManager.GameState newState)
    {
        LevelManager.GameState gameState = currentState;
        switch (newState)
        {
            case LevelManager.GameState.Building:
                if (GameTime.IsPaused())
                {
                    GameTime.Pause(false);
                }
                if (currentState == LevelManager.GameState.Running || currentState == LevelManager.GameState.PausedWhileRunning)
                {
                    base.StopRunningContraption();
                    this.retries++;
                    if (this.retries == 3 && !this.levelManager.m_sandbox && !this.tutorialBookOpened)
                    {
                        int num = GameProgress.GetInt("Tutorial_Promotion_Count", 0, GameProgress.Location.Local, null);
                        if (num < 3 && !GameProgress.IsLevelCompleted(base.gameManager.CurrentSceneName) && GameProgress.GetInt(this.TutorialPromotionCount, 0, GameProgress.Location.Local, null) == 0)
                        {
                            this.openTutorial = true;
                            num++;
                            GameProgress.SetInt("Tutorial_Promotion_Count", num, GameProgress.Location.Local);
                            GameProgress.SetInt(this.TutorialPromotionCount, 1, GameProgress.Location.Local);
                        }
                    }
                    bool @bool = GameProgress.GetBool(base.gameManager.CurrentSceneName + "_autobuild_available", false, GameProgress.Location.Local, null);
                    bool bool2 = GameProgress.GetBool("PermanentBlueprint", false, GameProgress.Location.Local, null);
                    if (!this.levelManager.m_sandbox && this.retries % 5 == 0 && AdvertisementHandler.GetRewardNativeTexture() != null)
                    {
                        int @int = GameProgress.GetInt("branded_reward_gifts_today", 0, GameProgress.Location.Local, null);
                        int num2 = 2;
                        if (Singleton<GameConfigurationManager>.IsInstantiated() && Singleton<GameConfigurationManager>.Instance.HasValue("branded_reward_gift_count", "count"))
                        {
                            num2 = Singleton<GameConfigurationManager>.Instance.GetValue<int>("branded_reward_gift_count", "count");
                        }
                        if (@int < num2)
                        {
                            if (!GameProgress.HasKey("branded_reward_gift_time", GameProgress.Location.Local, null))
                            {
                                GameProgress.SetInt("branded_reward_gift_time", Singleton<TimeManager>.Instance.CurrentEpochTime, GameProgress.Location.Local);
                            }
                            GameProgress.SetInt("branded_reward_gifts_today", @int + 1, GameProgress.Location.Local);
                            this.openMechanicGift = true;
                        }
                    }
                    else if (!this.levelManager.m_sandbox && this.retries == 5 && ((!bool2 && !this.levelManager.SuperBluePrintsAllowed) || (!@bool && this.levelManager.SuperBluePrintsAllowed)) && Singleton<BuildCustomizationLoader>.Instance.IAPEnabled)
                    {
                        int num3 = GameProgress.GetInt("Mechanic_Promotion_Count", 0, GameProgress.Location.Local, null);
                        long num4 = Convert.ToInt64(GameProgress.GetString("Last_Mechanic_Promotion_Time_Binary", "0", GameProgress.Location.Local, null));
                        DateTime value = DateTime.Now;
                        if (num4 != 0L)
                        {
                            value = DateTime.FromBinary(num4);
                        }
                        else
                        {
                            GameProgress.SetString("Last_Mechanic_Promotion_Time_Binary", value.ToBinary().ToString(), GameProgress.Location.Local);
                        }
                        if ((DateTime.Now.Subtract(value).TotalMinutes > 1440.0 || num3 < 3) && !GameProgress.IsLevelCompleted(base.gameManager.CurrentSceneName) && GameProgress.GetInt(this.MechanicPromotionCount, 0, GameProgress.Location.Local, null) == 0)
                        {
                            if (num3 < 1)
                            {
                                GameProgress.AddBluePrints(1);
                            }
                            this.openMechanicInfo = true;
                            num3++;
                            GameProgress.SetInt("Mechanic_Promotion_Count", num3, GameProgress.Location.Local);
                            GameProgress.SetInt(this.MechanicPromotionCount, 1, GameProgress.Location.Local);
                            GameProgress.SetString("Last_Mechanic_Promotion_Time_Binary", DateTime.Now.ToBinary().ToString(), GameProgress.Location.Local);
                        }
                    }
                }
                if (this.levelManager.m_toolboxOpenUponShopActivation)
                {
                    this.levelManager.InGameGUI.BuildMenu.ToolboxButton.OnPressed();
                }
                this.levelManager.SetupDynamicObjects();
                base.ContraptionProto.SetVisible(true);
                if (this.levelManager.ConstructionUI)
                {
                    this.levelManager.ConstructionUI.SetEnabled(true, true);
                }
                this.ResetCakes();
                if (GameProgress.GetString("REPLAY_LEVEL", string.Empty, GameProgress.Location.Local, null) == SceneManager.GetActiveScene().name && LightManager.enabledLightPositions != null && LightManager.enabledLightPositions.Count > 0)
                {
                    PointLightSource[] array = UnityEngine.Object.FindObjectsOfType<PointLightSource>();
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (LightManager.enabledLightPositions.Contains(array[i].transform.position))
                        {
                            array[i].isEnabled = true;
                        }
                    }
                    GameProgress.SetString("REPLAY_LEVEL", string.Empty, GameProgress.Location.Local);
                }
                break;
            case LevelManager.GameState.Preview:
                if (GameTime.IsPaused())
                {
                    GameTime.Pause(false);
                }
                this.levelManager.m_previewSpeed = 1f;
                this.levelManager.m_previewTime = 0f;
                base.ContraptionProto.SetVisible(false);
                if (this.levelManager.ConstructionUI)
                {
                    this.levelManager.ConstructionUI.SetEnabled(false, true);
                }
                break;
            case LevelManager.GameState.PreviewMoving:
                this.levelManager.m_previewTime = 0f;
                base.ContraptionProto.SetVisible(false);
                if (this.levelManager.ConstructionUI)
                {
                    this.levelManager.ConstructionUI.SetEnabled(false, true);
                }
                this.levelManager.SetupDynamicObjects();
                break;
            case LevelManager.GameState.PreviewWhileBuilding:
                if (this.levelManager.EggRequired)
                {
                    this.levelManager.InGameGUI.PreviewMenu.SetGoal(base.gameData.m_eggTransportGoal);
                }
                else if (this.levelManager.PumpkinRequired)
                {
                    this.levelManager.InGameGUI.PreviewMenu.SetGoal(base.gameData.m_pumpkinTransportGoal);
                }
                else
                {
                    this.levelManager.InGameGUI.PreviewMenu.SetGoal(base.gameData.m_basicGoal);
                }
                this.levelManager.InGameGUI.PreviewMenu.SetChallenges(this.levelManager.Challenges);
                if (this.levelManager.ConstructionUI)
                {
                    this.levelManager.ConstructionUI.SetEnabled(false, true);
                }
                this.levelManager.PreviewCenter = base.ContraptionProto.transform.position;
                this.levelManager.m_previewDragging = false;
                break;
            case LevelManager.GameState.PreviewWhileRunning:
                this.levelManager.PreviewCenter = base.ContraptionRunning.transform.position;
                GameTime.Pause(true);
                this.levelManager.m_previewDragging = false;
                break;
            case LevelManager.GameState.Running:
                if (GameTime.IsPaused())
                {
                    GameTime.Pause(false);
                }
                this.levelManager.TimeElapsed = 0f;
                this.levelManager.PartsInGoal.Clear();
                this.levelManager.TimeStarted = false;
                this.levelManager.PigStartPosition = base.ContraptionProto.FindPig().transform.position;
                if (this.levelManager.ConstructionUI)
                {
                    this.levelManager.ConstructionUI.SetEnabled(false, false);
                }
                base.ContraptionRunning = base.ContraptionProto.Clone();
                base.ContraptionProto.SetVisible(false);
                if (base.ContraptionProto.HasRegularGlue)
                {
                    if (!base.ContraptionProto.HasGluedParts)
                    {
                        GameProgress.AddSuperGlue(1);
                    }
                    base.ContraptionProto.RemoveSuperGlue();
                }
                if (base.ContraptionProto.HasSuperMagnet)
                {
                    base.ContraptionProto.HasSuperMagnet = false;
                }
                if (base.ContraptionProto.HasNightVision)
                {
                    this.levelManager.LightManager.ToggleNightVision();
                    base.ContraptionProto.HasNightVision = false;
                }
                base.ContraptionRunning.StartContraption();
                if (base.ContraptionProto.HasTurboCharge)
                {
                    if (base.ContraptionRunning.PowerConsumption == 0f)
                    {
                        base.ContraptionRunning.HasTurboCharge = false;
                        GameProgress.AddTurboCharge(1);
                    }
                    base.ContraptionProto.HasTurboCharge = false;
                }
                if (gameState == LevelManager.GameState.Building)
                {
                    this.StartRace();
                }
                base.ContraptionRunning.SaveContraption(base.GetCurrentContraptionName());
                break;
            case LevelManager.GameState.Continue:
                if (GameTime.IsPaused())
                {
                    GameTime.Pause(false);
                }
                if (gameState == LevelManager.GameState.Building || gameState == LevelManager.GameState.PausedWhileBuilding)
                {
                    newState = LevelManager.GameState.Building;
                }
                else if (gameState == LevelManager.GameState.CustomizingPart)
                {
                    newState = LevelManager.GameState.CustomizingPart;
                }
                else if (!this.levelManager.HasCompleted && gameState == LevelManager.GameState.LootCrateOpening)
                {
                    newState = LevelManager.GameState.Running;
                }
                else
                {
                    newState = ((!this.levelManager.HasCompleted) ? LevelManager.GameState.Running : LevelManager.GameState.Completed);
                }
                break;
            case LevelManager.GameState.PausedWhileRunning:
                GameTime.Pause(true);
                break;
            case LevelManager.GameState.PausedWhileBuilding:
                GameTime.Pause(true);
                break;
            case LevelManager.GameState.AutoBuilding:
                this.levelManager.StartAutoBuild(this.levelManager.m_oneStarContraption);
                break;
            case LevelManager.GameState.ShowingUnlockedParts:
                GameTime.Pause(false);
                this.levelManager.UnlockedPartIndex = -1;
                this.levelManager.PartShowTimer = 0f;
                break;
            case LevelManager.GameState.Snapshot:
                GameTime.Pause(true);
                this.levelManager.InGameGUI.ShowCurrentMenu(false);
                WPFMonoBehaviour.ingameCamera.TakeSnapshot(new Action(this.levelManager.HandleSnapshotFinished));
                break;
            case LevelManager.GameState.SuperAutoBuilding:
                this.levelManager.StartAutoBuild(this.levelManager.m_threeStarContraption[this.levelManager.CurrentSuperBluePrint]);
                if (Singleton<SocialGameManager>.IsInstantiated())
                {
                    Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.CHIPS_FOR_WHIPS", 100.0);
                }
                break;
        }
        currentState = newState;
        return currentState;
    }

    protected override bool HandleUIEvent(UIEvent data)
    {
        UIEvent.Type type = data.type;
        if (type == UIEvent.Type.ReplayLevel)
        {
            base.StopRunningContraption();
            this.levelManager.SetGameState(LevelManager.GameState.Building);
            return true;
        }
        if (type != UIEvent.Type.NextLevel && type != UIEvent.Type.LevelSelection)
        {
            return false;
        }
        if (this.levelManager.gameState != LevelManager.GameState.PausedWhileRunning)
        {
            if (this.levelManager.gameState == LevelManager.GameState.PausedWhileBuilding)
            {
                if (this.levelManager.ContraptionProto.HasSuperGlue)
                {
                    GameProgress.AddSuperGlue(1);
                }
                if (this.levelManager.ContraptionProto.HasSuperMagnet)
                {
                    GameProgress.AddSuperMagnet(1);
                }
                if (this.levelManager.ContraptionProto.HasTurboCharge)
                {
                    GameProgress.AddTurboCharge(1);
                }
                if (this.levelManager.ContraptionProto.HasNightVision)
                {
                    GameProgress.AddNightVision(1);
                }
            }
            else if (this.levelManager.gameState == LevelManager.GameState.Completed)
            {
            }
        }
        if (GameTime.IsPaused())
        {
            GameTime.Pause(false);
        }
        if (data.type == UIEvent.Type.NextLevel)
        {
            CakeRaceMenu.FindNewPlayer = true;
        }
        this.levelManager.SetGameState(LevelManager.GameState.Undefined);
        Singleton<GameManager>.Instance.LoadCakeRaceMenu(true);
        return true;
    }

    protected void OnBombOutOfBounds(TimeBomb.BombOutOfBounds data)
    {
        this.showBombParticles = true;
    }

    protected override void OnPigOutOfBounds(Pig.PigOutOfBounds data)
    {
        this.EndRace(-1, true);
    }

    private void StartRace()
    {
        this.IsRaceOn = true;
        CakeRaceMode.CurrentReplay = new CakeRaceReplay(CakeRaceMode.cakeRaceInfo.Value.UniqueIdentifier, HatchManager.CurrentPlayer.PlayFabDisplayName, Singleton<PlayerProgress>.Instance.Level, this.HasKingsFavoritePart(), null);
        this.CurrentScore = 0;
        if (this.ScoreUpdated != null)
        {
            this.ScoreUpdated(this.CurrentScore);
        }
        this.RaceTimeLeft = (float)CakeRaceMode.cakeRaceInfo.Value.TimeLimit;
        this.CollectedCakes = 0;
        EventManager.Connect(new EventManager.OnEvent<TimeBombExplodeEvent>(this.OnTimeBombExplode));
    }

    private bool HasKingsFavoritePart()
    {
        BasePart currentFavorite = Singleton<CakeRaceKingsFavorite>.Instance.CurrentFavorite;
        if (currentFavorite == null)
        {
            return false;
        }
        foreach (BasePart basePart in base.ContraptionRunning.Parts)
        {
            if (basePart != null && basePart.m_partType == currentFavorite.m_partType && basePart.customPartIndex == currentFavorite.customPartIndex)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTimeBombExplode(TimeBombExplodeEvent data)
    {
        this.EndRace(-1, false);
    }

    private void EndRace(int cakeIndex, bool waitToExplode = true)
    {
        EventManager.Disconnect(new EventManager.OnEvent<TimeBombExplodeEvent>(this.OnTimeBombExplode));
        if (this.IsRaceOn && this.levelManager.gameState != LevelManager.GameState.CakeRaceCompleted)
        {
            int collectTime = this.RaceTimeLeftInHundrethOfSeconds();
            CakeRaceMode.CurrentReplay.SetCollectedCake(cakeIndex, collectTime);
            this.AddScore(CakeRaceReplay.CalculateCakeScore(cakeIndex < 0, collectTime, Singleton<PlayerProgress>.Instance.Level, this.HasKingsFavoritePart()));
            this.IsRaceOn = false;
            this.OpponentScore = 0;
            if (CakeRaceMode.OpponentReplay != null)
            {
                this.OpponentScore = CakeRaceReplay.TotalScore(CakeRaceMode.OpponentReplay);
            }
            PlayerProgressBar.Instance.DelayUpdate();
            this.gainedXP = Singleton<PlayerProgress>.Instance.AddExperience((!this.LocalPlayerIsWinner) ? PlayerProgress.ExperienceType.LoseCakeRace : PlayerProgress.ExperienceType.WinCakeRace);
            int num = GameProgress.GetInt("cake_race_total_wins", 0, GameProgress.Location.Local, null);
            if (!CakeRaceMode.IsPreviewMode && this.LocalPlayerIsWinner)
            {
                this.RewardCrate(num);
                Singleton<PlayFabManager>.Instance.Leaderboard.AddScore(PlayFabLeaderboard.Leaderboard.CakeRaceWins, 1);
                CakeRaceMenu.WinCount++;
            }
            else
            {
                CakeRaceMode.CurrentRewardCrate = LootCrateType.None;
            }
            int trackIndex = CakeRaceMenu.GetTrackIndex(CakeRaceMode.cakeRaceInfo.Value.UniqueIdentifier, false);
            if (this.IsPersonalBest(trackIndex, this.CurrentScore) && trackIndex >= 0 && trackIndex < 7)
            {
                string key = string.Format("replay_track_{0}", trackIndex);
                string text = CakeRaceMode.CurrentReplay.TrimmedString();
                Singleton<PlayFabManager>.Instance.UpdateUserData(new Dictionary<string, string>
                {
                    {
                        key,
                        text
                    }
                }, UserDataPermission.Public);
                this.SavePersonalBest(trackIndex, text);
                this.ReportCupScore(GameProgress.GetInt("cake_race_current_cup", (int)PlayFabLeaderboard.LowestCup(), GameProgress.Location.Local, null));
            }
            CoroutineRunner.Instance.StartCoroutine(this.EndingSequence(waitToExplode));
            int num2 = GameProgress.GetInt("cake_race_total_losses", 0, GameProgress.Location.Local, null);
            string currentSeasonID = CakeRaceMode.GetCurrentSeasonID();
            string key2 = string.Format("Season_{0}_wins", currentSeasonID);
            string key3 = string.Format("Season_{0}_losses", currentSeasonID);
            int num3 = GameProgress.GetInt(key2, 0, GameProgress.Location.Local, null);
            int num4 = GameProgress.GetInt(key3, 0, GameProgress.Location.Local, null);
            if (this.LocalPlayerIsWinner)
            {
                GameProgress.SetInt("cake_race_total_wins", ++num, GameProgress.Location.Local);
                GameProgress.SetInt(key2, ++num3, GameProgress.Location.Local);
            }
            else
            {
                GameProgress.SetInt("cake_race_total_losses", ++num2, GameProgress.Location.Local);
                GameProgress.SetInt(key3, ++num4, GameProgress.Location.Local);
            }
        }
    }

    private bool IsPersonalBest(int trackIndex, int score)
    {
        string key = string.Format("cake_race_track_{0}_pb_replay", trackIndex);
        int num = 0;
        if (GameProgress.HasKey(key, GameProgress.Location.Local, null))
        {
            CakeRaceReplay replay = new CakeRaceReplay(GameProgress.GetString(key, string.Empty, GameProgress.Location.Local, null));
            num = CakeRaceReplay.TotalScore(replay);
        }
        return num < score;
    }

    public CakeRaceReplay PersonalBest()
    {
        CakeRaceInfo? cakeRaceInfo = CakeRaceMode.cakeRaceInfo;
        if (cakeRaceInfo == null)
        {
            return null;
        }
        int trackIndex = CakeRaceMenu.GetTrackIndex(CakeRaceMode.cakeRaceInfo.Value.UniqueIdentifier, false);
        string key = string.Format("cake_race_track_{0}_pb_replay", trackIndex);
        if (GameProgress.HasKey(key, GameProgress.Location.Local, null))
        {
            return new CakeRaceReplay(GameProgress.GetString(key, string.Empty, GameProgress.Location.Local, null));
        }
        return null;
    }

    private void SavePersonalBest(int trackIndex, string replay)
    {
        string key = string.Format("cake_race_track_{0}_pb_replay", trackIndex);
        GameProgress.SetString(key, replay, GameProgress.Location.Local);
    }

    public static void ClearPersonalBestData()
    {
        for (int i = 0; i < 7; i++)
        {
            string key = string.Format("cake_race_track_{0}_pb_replay", i);
            GameProgress.DeleteKey(key, GameProgress.Location.Local);
        }
    }

    private void ReportCupScore(int cupIndex)
    {
        int num = 0;
        for (int i = 0; i < 7; i++)
        {
            string text = string.Format("cake_race_track_{0}_pb_replay", i);
            if (GameProgress.HasKey(text, GameProgress.Location.Local, null))
            {
                CakeRaceReplay cakeRaceReplay = new CakeRaceReplay(GameProgress.GetString(text, string.Empty, GameProgress.Location.Local, null));
                if (cakeRaceReplay.IsValid)
                {
                    int num2 = CakeRaceReplay.TotalScore(cakeRaceReplay);
                    num += num2;
                    UnityEngine.Debug.LogWarning("[CakeRaceMode] Track (" + text + ") score " + num2.ToString());
                }
            }
        }
        PlayFabLeaderboard.Leaderboard board = (PlayFabLeaderboard.Leaderboard)cupIndex;
        UnityEngine.Debug.LogWarning("[CakeRaceMode] ReportCupScore [" + board.ToString() + "] " + num.ToString());
        Singleton<PlayFabManager>.Instance.Leaderboard.AddScore(board, num, new Action<UpdatePlayerStatisticsResult>(this.OnCupScoreReported), new Action<PlayFabError>(this.OnCupScoreError));
    }

    private void OnCupScoreReported(UpdatePlayerStatisticsResult result)
    {
        UnityEngine.Debug.LogWarning("[CakeRaceMode] OnCupScoreReported");
    }

    private void OnCupScoreError(PlayFabError error)
    {
        UnityEngine.Debug.LogWarning("[CakeRaceMode] OnCupScoreError: " + error.ErrorMessage);
    }

    public static string GetCurrentSeasonID()
    {
        int @int = GameProgress.GetInt("cake_race_current_week", 0, GameProgress.Location.Local, null);
        return string.Format("{0:0000}_{1:0000}", @int, Singleton<TimeManager>.Instance.ServerTime.Year);
    }

    private IEnumerator EndingSequence(bool waitToExplode)
    {
        GadgetButtonList buttonList = this.levelManager.InGameGUI.FlightMenu.ButtonList;
        for (int i = 0; i < buttonList.Buttons.Count; i++)
        {
            buttonList.Buttons[i].Lock(true);
        }
        CoroutineRunner.Instance.StartCoroutine(CoroutineRunner.MoveObject(buttonList.transform, buttonList.transform.position + Vector3.down * 4f, 1.5f, false));
        Pig pig = this.levelManager.ContraptionRunning.FindPig() as Pig;
        pig.SetExpression(Pig.Expressions.Fear);
        this.levelManager.InGameGUI.CakeRaceHUD.SetTimeBombMode(CakeRaceHUD.TimerMode.TimesUp, true, false);
        if (waitToExplode)
        {
            Singleton<AudioManager>.Instance.Spawn2dOneShotEffect(base.gameData.commonAudioCollection.timeBombAlarm[0]);
        }
        this.levelManager.SetGameState(LevelManager.GameState.CakeRaceExploding);
        if (waitToExplode)
        {
            yield return new WaitForSeconds(3f);
        }
        if (this.showBombParticles)
        {
            this.ShowTimeBombParticles();
        }
        this.levelManager.SetGameState(LevelManager.GameState.CakeRaceCompleted);
        yield break;
    }

    private void ShowTimeBombParticles()
    {
        BasePart basePart = base.ContraptionRunning.FindPart(BasePart.PartType.TimeBomb);
        bool flag = WPFMonoBehaviour.mainCamera.transform.position.x < basePart.transform.position.x;
        Vector3 b = (!flag) ? new Vector3(-19f, 0f, 5f) : new Vector3(19f, 0f, 5f);
        Vector3 euler = (!flag) ? new Vector3(0f, 0f, -45f) : new Vector3(0f, 0f, 45f);
        GameObject gameObject = UnityEngine.Object.Instantiate(base.gameData.m_cakeRaceBombParticles);
        gameObject.transform.position = WPFMonoBehaviour.hudCamera.transform.position + b;
        gameObject.transform.rotation = Quaternion.Euler(euler);
    }

    private void RewardCrate(int rewardIndex)
    {
        LootCrateType lootCrateType = LootCrateType.Cardboard;
        if (Singleton<GameConfigurationManager>.Instance.HasValue("cake_race", "loot_crates"))
        {
            string[] array = Singleton<GameConfigurationManager>.Instance.GetValue<string>("cake_race", "loot_crates").Split(new char[]
            {
                ','
            });
            int num = rewardIndex % array.Length;
            int num2;
            if (array != null && array.Length > 0 && num >= 0 && int.TryParse(array[num], out num2))
            {
                lootCrateType = (LootCrateType)num2;
            }
        }
        CakeRaceMode.CurrentRewardCrate = lootCrateType;
        if (lootCrateType != LootCrateType.None)
        {
            LootCrateSlots.AddLootCrateToFreeSlot(lootCrateType);
        }
    }

    private void AddScore(int amount)
    {
        this.CurrentScore += amount;
        if (this.ScoreUpdated != null)
        {
            this.ScoreUpdated(this.CurrentScore);
        }
    }

    private void CreateCakes()
    {
        CakeRaceInfo? cakeRaceInfo = CakeRaceMode.cakeRaceInfo;
        if (cakeRaceInfo == null)
        {
            return;
        }
        if (this.cakes == null)
        {
            this.cakes = new List<Cake>();
            for (int i = 0; i < CakeRaceMode.cakeRaceInfo.Value.CakeLocations.Length; i++)
            {
                ObjectLocation objectLocation = CakeRaceMode.cakeRaceInfo.Value.CakeLocations[i];
                GameObject gameObject = UnityEngine.Object.Instantiate(objectLocation.Prefab, objectLocation.Position, objectLocation.Rotation);
                Cake component = gameObject.GetComponent<Cake>();
                UnityEngine.Debug.LogWarning("Add cake collected listener " + i.ToString());
                component.OnCakeCollected += this.OnCakeCollected;
                this.cakes.Add(component);
            }
        }
    }

    private void CreateProps()
    {
        CakeRaceInfo? cakeRaceInfo = CakeRaceMode.cakeRaceInfo;
        if (cakeRaceInfo == null)
        {
            return;
        }
        for (int i = 0; i < CakeRaceMode.cakeRaceInfo.Value.Props.Length; i++)
        {
            ObjectLocation objectLocation = CakeRaceMode.cakeRaceInfo.Value.Props[i];
            UnityEngine.Object.Instantiate(objectLocation.Prefab, objectLocation.Position, objectLocation.Rotation);
        }
    }

    private void InstantiateObjects(ObjectLocation[] locationData)
    {
    }

    private void ResetCakes()
    {
        for (int i = 0; i < this.cakes.Count; i++)
        {
            if (this.cakes[i] != null)
            {
                this.cakes[i].Reset();
            }
        }
    }

    private bool FindCakeRaceInfo(int trackIndex)
    {
        switch (base.gameManager.CurrentEpisodeType)
        {
            case GameManager.EpisodeType.Normal:
                {
                    int currentEpisodeIndex = base.gameManager.CurrentEpisodeIndex;
                    int currentLevel = base.gameManager.CurrentLevel;
                    int trackCount = base.gameData.m_cakeRaceData.GetTrackCount(currentEpisodeIndex, currentLevel);
                    if (trackIndex >= trackCount)
                    {
                        trackIndex = 0;
                    }
                    else if (trackIndex < 0)
                    {
                        trackIndex = trackCount - 1;
                    }
                    if (!base.gameData.m_cakeRaceData.GetInfo(currentEpisodeIndex, currentLevel, trackIndex, out CakeRaceMode.cakeRaceInfo))
                    {
                        return false;
                    }
                    break;
                }
            case GameManager.EpisodeType.Sandbox:
            case GameManager.EpisodeType.Race:
                {
                    string currentLevelIdentifier = base.gameManager.CurrentLevelIdentifier;
                    int trackCount2 = base.gameData.m_cakeRaceData.GetTrackCount(currentLevelIdentifier);
                    UnityEngine.Debug.LogWarning("[CakeRaceMode] track index " + trackIndex.ToString() + ", track count " + trackCount2.ToString());
                    if (trackIndex >= trackCount2)
                    {
                        trackIndex = 0;
                    }
                    else if (trackIndex < 0)
                    {
                        trackIndex = trackCount2 - 1;
                    }
                    if (!base.gameData.m_cakeRaceData.GetInfo(currentLevelIdentifier, trackIndex, out CakeRaceMode.cakeRaceInfo))
                    {
                        return false;
                    }
                    break;
                }
            default:
                return false;
        }
        CakeRaceMode.currentRaceTrackIndex = trackIndex;
        return true;
    }

    private void SetNextTrack()
    {
        this.FindCakeRaceInfo(CakeRaceMode.currentRaceTrackIndex + 1);
    }

    private void SetPreviousTrack()
    {
        this.FindCakeRaceInfo(CakeRaceMode.currentRaceTrackIndex - 1);
    }

    private List<CameraPreview.CameraControlPoint> CreatePreview()
    {
        List<CameraPreview.CameraControlPoint> list = new List<CameraPreview.CameraControlPoint>();
        for (int i = this.cakes.Count - 1; i >= 0; i--)
        {
            list.Add(new CameraPreview.CameraControlPoint
            {
                easing = CameraPreview.EasingAnimation.EasingInOut,
                position = this.cakes[i].transform.position,
                zoom = ((i >= CakeRaceMode.cakeRaceInfo.Value.CakeZoomLevels.Length) ? 6f : CakeRaceMode.cakeRaceInfo.Value.CakeZoomLevels[i])
            });
        }
        CameraPreview.CameraControlPoint cameraControlPoint = new CameraPreview.CameraControlPoint();
        cameraControlPoint.easing = CameraPreview.EasingAnimation.EasingInOut;
        cameraControlPoint.position = CakeRaceMode.cakeRaceInfo.Value.Start.Position;
        int a;
        int num;
        CakeRaceMode.cakeRaceInfo.Value.Start.GetGridSize(out a, out num);
        cameraControlPoint.zoom = (float)Mathf.Max(a, num) * 1f;
        cameraControlPoint.position += Vector2.up * (float)num * 0.45f;
        list.Add(cameraControlPoint);
        return list;
    }

    private void OnCakeCollected(Cake cake)
    {
        if (this.CakeCollected != null)
        {
            this.CakeCollected(0);
        }
        if (cake.CollectedByOtherPlayer)
        {
            return;
        }
        this.CollectedCakes++;
        if (this.CollectedCakes >= this.cakes.Count)
        {
            this.EndRace(cake.CakeIndex, true);
        }
        else
        {
            int collectTime = this.RaceTimeLeftInHundrethOfSeconds();
            CakeRaceMode.CurrentReplay.SetCollectedCake(cake.CakeIndex, collectTime);
            this.AddScore(CakeRaceReplay.CalculateCakeScore(false, collectTime, Singleton<PlayerProgress>.Instance.Level, this.HasKingsFavoritePart()));
        }
    }

    public int RaceTimeLeftInHundrethOfSeconds()
    {
        return Mathf.FloorToInt(this.RaceTimeLeft * 100f);
    }

    private void OnTimeOut()
    {
    }

    public override int GetPartCount(BasePart.PartType type)
    {
        if (this.parts == null)
        {
            this.InitParts();
        }
        for (int i = 0; i < this.parts.Count; i++)
        {
            if (this.parts[i].type == type)
            {
                return this.parts[i].count;
            }
        }
        return 0;
    }

    private List<Cake> cakes;

    private int retries;

    private int gainedXP;

    private bool openTutorial;

    private bool openMechanicInfo;

    private bool timeRunning;

    private bool showBombParticles;

    private List<LevelManager.PartCount> parts;

    public Action<int> ScoreUpdated;

    public Action<int> CakeCollected;

    public Action<int> TrackChanged;

    private const string MECHANIC_PROMOTION_COUNT = "Mechanic_Promotion_Count";

    private const string MECHANIC_PROMOTION_TIME = "Last_Mechanic_Promotion_Time_Binary";

    private const string TUTORIAL_PROMOTION_COUNT = "Tutorial_Promotion_Count";

    private const string BRANDED_REWARD_GIFT_COUNT = "branded_reward_gifts_today";

    private const string BRANDED_REWARD_GIFT_TIME = "branded_reward_gift_time";

    private const string BRANDED_REWARD_COOLDOWN = "branded_reward_cooldown";

    private bool openMechanicGift;

    private static int currentRaceTrackIndex;

    private static CakeRaceInfo? cakeRaceInfo;
}
