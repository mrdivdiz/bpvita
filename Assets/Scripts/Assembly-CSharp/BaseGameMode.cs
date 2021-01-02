using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseGameMode : GameMode
{
    private string TutorialPromotionCount
    {
        get
        {
            return string.Format("{0}_{1}", "Tutorial_Promotion_Count", Singleton<GameManager>.Instance.CurrentSceneName);
        }
    }

    private string MechanicPromotionCount
    {
        get
        {
            return string.Format("{0} {1}", "Mechanic_Promotion_Count", Singleton<GameManager>.Instance.CurrentSceneName);
        }
    }

    public override void OnDataLoadedStart()
    {
        PartListing.Create().Close();
        int @int = GameProgress.GetInt("branded_reward_gift_time", 0, GameProgress.Location.Local, null);
        int num = 86400;
        if (Singleton<GameConfigurationManager>.IsInstantiated() && Singleton<GameConfigurationManager>.Instance.HasValue("branded_reward_cooldown", "time"))
        {
            num = Singleton<GameConfigurationManager>.Instance.GetValue<int>("branded_reward_cooldown", "time");
        }
        if (@int > 0 && Singleton<TimeManager>.Instance.CurrentEpochTime - @int > num)
        {
            GameProgress.DeleteKey("branded_reward_gift_time", GameProgress.Location.Local);
            GameProgress.DeleteKey("branded_reward_gifts_today", GameProgress.Location.Local);
        }
    }

    public override void InitGameMode()
    {
        base.CurrentConstructionGridRows = this.levelManager.m_constructionGridRows;
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
        Vector3 position = (!this.levelStart) ? Vector3.zero : this.levelStart.transform.position;
        this.levelManager.CreateGrid(num, newGridHeight, newGridXMin, newGridXMax, position);
        if (this.levelManager.ConstructionUI)
        {
            if (GameProgress.HasKey(SchematicButton.LastLoadedSlotKey, GameProgress.Location.Local, null))
            {
                base.CurrentContraptionIndex = GameProgress.GetInt(SchematicButton.LastLoadedSlotKey, 0, GameProgress.Location.Local, null);
            }
            base.BuildContraption(WPFPrefs.LoadContraptionDataset(base.GetCurrentContraptionName()));
        }
        foreach (ConstructionUI.PartDesc partDesc in this.levelManager.ConstructionUI.PartDescriptors)
        {
            EventManager.Send(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
        }
        GameObject gameObject = new GameObject("CollectibleStash");
        gameObject.transform.parent = this.levelManager.transform;
        this.FindChallenges();
        this.levelManager.m_CollectedDessertsCount = 0;
        this.PlaceDesserts(false);
        this.InitializeChallenges();
    }

    public override void OnDataLoadedDone()
    {
        this.levelManager.m_autoBuildUnlocked = (this.levelManager.m_oneStarContraption != null);
    }

    private void FindChallenges()
    {
        this.levelManager.Challenges = Challenge.Challenges;
    }

    private void InitializeChallenges()
    {
        for (int i = 0; i < this.levelManager.Challenges.Count; i++)
        {
            Challenge challenge = this.levelManager.Challenges[i];
            if (challenge.TimeLimit() > 0f)
            {
                this.levelManager.TimeLimits.Add(challenge.TimeLimit());
                if (this.levelManager.TimeLimit == 0f || challenge.TimeLimit() > this.levelManager.TimeLimit)
                {
                    this.levelManager.TimeLimit = challenge.TimeLimit();
                    this.levelManager.OriginalTimeLimit = this.levelManager.TimeLimit;
                }
            }
        }
    }

    private void PlaceDesserts(bool forceFillAllPlaces = false)
    {
        if (!GameProgress.GetBool("ChiefPigExploded", false, GameProgress.Location.Local, null) && !forceFillAllPlaces)
        {
            return;
        }
        GameObject gameObject = GameObject.Find("DessertPlaces");
        if (gameObject == null)
        {
            return;
        }
        if (forceFillAllPlaces || !this.levelManager.LoadDessertsPlacement(gameObject))
        {
            this.levelManager.UsedDessertPlaces.Clear();
            int max = base.gameData.m_desserts.Count - 1;
            DessertPlace[] array = UnityEngine.Object.FindObjectsOfType<DessertPlace>();
            if (array.Length > 0)
            {
                int num = array.Length - 1;
                while (--num >= 1)
                {
                    int num2 = UnityEngine.Random.Range(0, num + 1);
                    DessertPlace dessertPlace = array[num];
                    array[num] = array[num2];
                    array[num2] = dessertPlace;
                }
                int levelDessertsCount = this.levelManager.LevelDessertsCount;
                int num3 = (levelDessertsCount <= array.Length && !forceFillAllPlaces) ? levelDessertsCount : array.Length;
                int num4 = -1;
                if (UnityEngine.Random.Range(0, 100) == 50)
                {
                    num4 = UnityEngine.Random.Range(0, num3);
                }
                for (int i = 0; i < num3; i++)
                {
                    Transform transform = array[i].transform;
                    GameObject gameObject2 = base.gameData.m_desserts[UnityEngine.Random.Range(0, max)];
                    if (num4 == i)
                    {
                        gameObject2 = base.gameData.m_desserts[base.gameData.m_desserts.Count - 1];
                    }
                    else
                    {
                        gameObject2 = base.gameData.m_desserts[UnityEngine.Random.Range(0, max)];
                    }
                    GameObject gameObject3 = UnityEngine.Object.Instantiate(gameObject2, transform.position, transform.rotation);
                    gameObject3.name = gameObject2.name;
                    gameObject3.GetComponent<Dessert>().place = transform.GetComponent<DessertPlace>();
                    this.levelManager.UsedDessertPlaces.Add(transform.name, gameObject3.GetComponent<Dessert>().saveId);
                }
                if (this.levelManager.UsedDessertPlaces.Count > 0)
                {
                    int num5 = 0;
                    string[] array2 = new string[this.levelManager.UsedDessertPlaces.Count];
                    foreach (KeyValuePair<string, string> x in this.levelManager.UsedDessertPlaces)
                    {
                        array2[num5] = x.Key + ":" + x.Value;
                        num5++;
                    }
                    string value = string.Join(";", array2);
                    string key = Singleton<GameManager>.Instance.CurrentSceneName + "_dessert_placement";
                    GameProgress.SetString(key, value, GameProgress.Location.Local);
                }
            }
        }
    }

    public override void Update()
    {
        if (this.openTutorial && this.levelManager.gameState == LevelManager.GameState.Building)
        {
            this.openTutorial = false;
            EventManager.Send(new UIEvent(UIEvent.Type.OpenTutorial));
        }
        if (this.openMechanicGift && this.levelManager.gameState == LevelManager.GameState.Building)
        {
            this.openMechanicGift = false;
            this.levelManager.SetGameState(LevelManager.GameState.MechanicGiftScreen);
        }
        if (this.useBlueprint)
        {
            if (this.levelManager.gameState == LevelManager.GameState.Building && WPFMonoBehaviour.ingameCamera.IsShowingBuildGrid(0.1f))
            {
                this.useBlueprint = false;
                EventManager.Send(new UIEvent(UIEvent.Type.Blueprint));
            }
        }
        else if (this.useSuperBlueprint && this.levelManager.gameState == LevelManager.GameState.Building && WPFMonoBehaviour.ingameCamera.IsShowingBuildGrid(0.1f))
        {
            this.useSuperBlueprint = false;
            EventManager.Send(new UIEvent(UIEvent.Type.SuperBlueprint));
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
                        if (num < 3 && !GameProgress.IsLevelCompleted(Singleton<GameManager>.Instance.CurrentSceneName) && GameProgress.GetInt(this.TutorialPromotionCount, 0, GameProgress.Location.Local, null) == 0)
                        {
                            this.openTutorial = true;
                            num++;
                            GameProgress.SetInt("Tutorial_Promotion_Count", num, GameProgress.Location.Local);
                            GameProgress.SetInt(this.TutorialPromotionCount, 1, GameProgress.Location.Local);
                        }
                    }
                    bool @bool = GameProgress.GetBool(Singleton<GameManager>.Instance.CurrentSceneName + "_autobuild_available", false, GameProgress.Location.Local, null);
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
                    base.ContraptionProto.HasTurboCharge = false;
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
            case LevelManager.GameState.Completed:
                this.levelManager.InGameGUI.ShowCurrentMenu(false);
                base.ContraptionRunning.TurnOffAllPoweredParts();
                this.levelManager.PlayVictorySound();
                if (this.levelManager.EggRequired)
                {
                    this.levelManager.InGameGUI.LevelCompleteMenu.SetGoal(base.gameData.m_eggTransportGoal);
                }
                else if (this.levelManager.PumpkinRequired)
                {
                    this.levelManager.InGameGUI.LevelCompleteMenu.SetGoal(base.gameData.m_pumpkinTransportGoal);
                }
                else
                {
                    this.levelManager.InGameGUI.LevelCompleteMenu.SetGoal(base.gameData.m_basicGoal);
                }
                this.levelManager.InGameGUI.LevelCompleteMenu.SetChallenges(this.levelManager.Challenges);
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
                this.levelManager.UnlockedParts = new List<ConstructionUI.PartDesc>(this.levelManager.ConstructionUI.UnlockedParts);
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
        switch (data.type)
        {
            case UIEvent.Type.Building:
                this.levelManager.ConstructionUI.transform.position = this.levelManager.StartingPosition;
                this.levelManager.ContraptionProto.transform.position = this.levelManager.StartingPosition;
                this.levelManager.ConstructionUI.CheckUnlockedParts();
                break;
            case UIEvent.Type.LevelSelection:
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
                break;
            case UIEvent.Type.NextLevel:
                break;
            case UIEvent.Type.Pause:
                break;
            case UIEvent.Type.Blueprint:
                if (GameProgress.GetBool("PermanentBlueprint", false, GameProgress.Location.Local, null))
                {
                    if (this.levelManager.m_threeStarContraption.Count == 1)
                    {
                        GameProgress.SetBool(Singleton<GameManager>.Instance.CurrentSceneName + "_autobuild_available", true, GameProgress.Location.Local);
                    }
                    this.levelManager.SetGameState(LevelManager.GameState.AutoBuilding);
                }
                break;
            case UIEvent.Type.ReplayLevel:
                break;
            case UIEvent.Type.ContinueFromPause:
                break;
            case UIEvent.Type.CloseMechanicInfo:
                this.levelManager.SetGameState(LevelManager.GameState.Building);
                break;
            case UIEvent.Type.CloseMechanicInfoAndUseMechanic:
                this.levelManager.SetGameState(LevelManager.GameState.Building);
                Singleton<GuiManager>.Instance.IsEnabled = false;
                this.levelManager.UseBlueprint = true;
                break;
            case UIEvent.Type.SuperBlueprint:
                if (this.levelManager.SuperBluePrintsAllowed && this.levelManager.m_threeStarContraption.Count > 0 && this.levelManager.gameState == LevelManager.GameState.Building && WPFMonoBehaviour.ingameCamera.IsShowingBuildGrid(1f))
                {
                    bool flag = GameProgress.GetBool(Singleton<GameManager>.Instance.CurrentSceneName + "_autobuild_available", false, GameProgress.Location.Local, null);
                    int num = GameProgress.BluePrintCount();
                    if (num == 0 && !flag)
                    {
                        Singleton<GuiManager>.Instance.IsEnabled = true;
                        this.levelManager.ShowPurchaseDialog(IapManager.InAppPurchaseItemType.BlueprintSingle);
                    }
                    else
                    {
                        if (!flag && num > 0)
                        {
                            GameProgress.SetBluePrintCount(--num);
                            GameProgress.SetBool(Singleton<GameManager>.Instance.CurrentSceneName + "_autobuild_available", true, GameProgress.Location.Local);
                            flag = true;
                            GameProgress.Save();
                            EventManager.Send(new InGameBuildMenu.AutoBuildEvent(num, true));
                        }
                        GameObject superBuildSelection = this.levelManager.InGameGUI.BuildMenu.SuperBuildSelection;
                        if (flag && !superBuildSelection.gameObject.activeSelf)
                        {
                            GameObject autoBuildButton = this.levelManager.InGameGUI.BuildMenu.AutoBuildButton;
                            autoBuildButton.SetActive(false);
                            superBuildSelection.SetActive(true);
                        }
                        if (flag)
                        {
                            EventManager.Send(new UIEvent(UIEvent.Type.RotateSuperBluePrints));
                        }
                    }
                }
                break;
            case UIEvent.Type.RotateSuperBluePrints:
                {
                    int count = this.levelManager.m_threeStarContraption.Count;
                    string text = "ABCDEFGH";
                    this.levelManager.CurrentSuperBluePrint++;
                    if (this.levelManager.CurrentSuperBluePrint >= count)
                    {
                        this.levelManager.CurrentSuperBluePrint = 0;
                    }
                    GameObject superBuildSelection2 = this.levelManager.InGameGUI.BuildMenu.SuperBuildSelection;
                    if (superBuildSelection2 != null)
                    {
                        Transform transform = superBuildSelection2.transform.Find("AmountText");
                        Transform transform2 = superBuildSelection2.transform.Find("AmountTextShadow");
                        if (transform.GetComponent<TextMesh>().text == string.Empty)
                        {
                            this.levelManager.CurrentSuperBluePrint = 0;
                        }
                        transform.GetComponent<TextMesh>().text = text[this.levelManager.CurrentSuperBluePrint].ToString();
                        transform2.GetComponent<TextMesh>().text = text[this.levelManager.CurrentSuperBluePrint].ToString();
                    }
                    this.levelManager.SetGameState(LevelManager.GameState.SuperAutoBuilding);
                    if (!this.levelManager.FirstTime)
                    {
                        this.levelManager.FastBuilding = true;
                    }
                    else
                    {
                        this.levelManager.FirstTime = false;
                    }
                    break;
                }
            case UIEvent.Type.CloseMechanicInfoAndUseSuperMechanic:
                this.levelManager.SetGameState(LevelManager.GameState.Building);
                if (this.levelManager.SuperBluePrintsAllowed && this.levelManager.m_threeStarContraption.Count > 0)
                {
                    Singleton<GuiManager>.Instance.IsEnabled = false;
                    this.levelManager.UseSuperBlueprint = true;
                }
                else
                {
                    Singleton<GuiManager>.Instance.IsEnabled = true;
                }
                break;
        }
        return false;
    }

    public override int GetPartCount(BasePart.PartType type)
    {
        List<LevelManager.PartCount> partTypeCounts = this.levelManager.m_partTypeCounts;
        int num = 0;
        foreach (LevelManager.PartCount partCount in partTypeCounts)
        {
            if (partCount.type == type)
            {
                num += partCount.count;
                break;
            }
        }
        if (this.levelManager.m_sandbox)
        {
            if (!this.levelManager.m_collectPartBoxesSandbox)
            {
                num += GameProgress.GetSandboxPartCount(type);
            }
            num += GameProgress.GetSandboxPartCount(Singleton<GameManager>.Instance.CurrentSceneName, type);
        }
        return num;
    }

    private int retries;

    private bool openTutorial;

    private bool openMechanicGift;

    private bool useBlueprint;

    private bool useSuperBlueprint;

    private const string MECHANIC_PROMOTION_COUNT = "Mechanic_Promotion_Count";

    private const string MECHANIC_PROMOTION_TIME = "Last_Mechanic_Promotion_Time_Binary";

    private const string TUTORIAL_PROMOTION_COUNT = "Tutorial_Promotion_Count";

    private const string BRANDED_REWARD_GIFT_COUNT = "branded_reward_gifts_today";

    private const string BRANDED_REWARD_GIFT_TIME = "branded_reward_gift_time";

    private const string BRANDED_REWARD_COOLDOWN = "branded_reward_cooldown";
}
