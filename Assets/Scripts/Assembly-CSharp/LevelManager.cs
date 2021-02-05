using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LevelManager : WPFMonoBehaviour
{
    public static int GameModeIndex { get; set; }

    public int LevelDessertsCount
    {
        get
        {
            return (this.m_DessertsCount < 0) ? WPFMonoBehaviour.gameData.m_LevelDessertsCount : this.m_DessertsCount;
        }
    }

    public GameState gameState
    {
        get
        {
            return this.m_gameState;
        }
        private set
        {
            this.m_gameState = value;
        }
    }

    public bool RequireConnectedContraption
    {
        get
        {
            return this.m_requireConnectedContraption;
        }
    }

    public Contraption ContraptionProto
    {
        get
        {
            return this.m_gameMode.ContraptionProto;
        }
    }

    public Contraption ContraptionRunning
    {
        get
        {
            return this.m_gameMode.ContraptionRunning;
        }
    }

    public ConstructionUI ConstructionUI
    {
        get
        {
            return this.m_constructionUI;
        }
    }

    public LightManager LightManager
    {
        get
        {
            return this.lightManager;
        }
    }

    public bool TimeStarted
    {
        get
        {
            return this.m_timeStarted;
        }
        set
        {
            this.m_timeStarted = value;
        }
    }

    public float TimeReward { get; set; }

    public float OriginalTimeLimit { get; set; }

    public float TimeLimit
    {
        get
        {
            return this.m_timeLimit;
        }
        set
        {
            this.m_timeLimit = value;
        }
    }

    public List<float> TimeLimits
    {
        get
        {
            return this.m_timeLimits;
        }
        set
        {
            this.m_timeLimits = value;
        }
    }

    public float CompletionTime
    {
        get
        {
            return this.m_completionTime;
        }
        set
        {
            this.m_completionTime = value;
        }
    }

    public bool HasCompleted
    {
        get
        {
            return this.m_completedLevel;
        }
        set
        {
            this.m_completedLevel = value;
        }
    }

    public int GridHeight
    {
        get
        {
            return this.m_gridHeight;
        }
    }

    public int GridWidth
    {
        get
        {
            return this.m_gridWidth;
        }
    }

    public int GridXMin
    {
        get
        {
            return this.m_gridXmin;
        }
    }

    public int GridXMax
    {
        get
        {
            return this.m_gridXmax;
        }
    }

    public Vector3 PreviewCenter
    {
        get
        {
            return this.m_previewCenter;
        }
        set
        {
            this.m_previewCenter = value;
        }
    }

    public Vector3 StartingPosition
    {
        get
        {
            return this.m_levelStart;
        }
    }

    public bool HasGroundIce
    {
        get
        {
            return this.m_hasIceGround;
        }
    }

    public bool EggRequired
    {
        get
        {
            return !this.m_sandbox && this.GetPartTypeCount(BasePart.PartType.Egg) > 0;
        }
    }

    public bool PumpkinRequired
    {
        get
        {
            return !this.m_sandbox && this.GetPartTypeCount(BasePart.PartType.Pumpkin) > 0;
        }
    }

    public List<Challenge> Challenges
    {
        get
        {
            return this.m_challenges;
        }
        set
        {
            this.m_challenges = value;
        }
    }

    public InGameGUI InGameGUI
    {
        get
        {
            return this.m_inGameGui;
        }
    }

    public Dictionary<string, string> UsedDessertPlaces
    {
        get
        {
            return this.m_UsedDessertPlaces;
        }
    }

    public List<int> CurrentConstructionGridRows
    {
        get
        {
            return this.m_gameMode.CurrentConstructionGridRows;
        }
    }

    public List<BasePart.PartType> PartsInGoal
    {
        get
        {
            return this.m_partsInGoal;
        }
    }

    public List<ConstructionUI.PartDesc> UnlockedParts
    {
        get
        {
            return this.m_unlockedParts;
        }
        set
        {
            this.m_unlockedParts = value;
        }
    }

    public float PartShowTimer
    {
        get
        {
            return this.m_partShowTimer;
        }
        set
        {
            this.m_partShowTimer = value;
        }
    }

    public int UnlockedPartIndex
    {
        get
        {
            return this.m_unlockedPartIndex;
        }
        set
        {
            this.m_unlockedPartIndex = value;
        }
    }

    public bool FastBuilding
    {
        get
        {
            return this.fastBuilding;
        }
        set
        {
            this.fastBuilding = value;
        }
    }

    public bool FirstTime
    {
        get
        {
            return this.m_firstTime;
        }
        set
        {
            this.m_firstTime = value;
        }
    }

    public GameState StateBeforeTutorial
    {
        get
        {
            return this.m_stateBeforeTutorial;
        }
        set
        {
            this.m_stateBeforeTutorial = value;
        }
    }

    public bool UseBlueprint
    {
        get
        {
            return this.m_useBlueprint;
        }
        set
        {
            this.m_useBlueprint = value;
        }
    }

    public bool UseSuperBlueprint
    {
        get
        {
            return this.m_useSuperBlueprint;
        }
        set
        {
            this.m_useSuperBlueprint = value;
        }
    }

    public int CurrentSuperBluePrint { get; set; }

    public Vector3 PigStartPosition { get; set; }

    public GameMode CurrentGameMode
    {
        get
        {
            return this.m_gameMode;
        }
    }

    public Vector3 PreviewOffset
    {
        get
        {
            return this.m_gameMode.PreviewOffset;
        }
    }

    public Vector3 CameraOffset
    {
        get
        {
            return this.m_gameMode.CameraOffset;
        }
    }

    public Vector3 ConstructionOffset
    {
        get
        {
            return this.m_gameMode.ConstructionOffset;
        }
    }

    public CameraLimits CurrentCameraLimits
    {
        get
        {
            return (this.CurrentGameMode.CameraLimits != null) ? this.CurrentGameMode.CameraLimits : this.m_cameraLimits;
        }
    }

    public GameObject GridCellPrefab
    {
        get
        {
            return (!(this.CurrentGameMode.GridCellPrefab == null)) ? this.CurrentGameMode.GridCellPrefab : this.m_gridCellPrefab;
        }
    }

    public GameObject TutorialBookPage
    {
        get
        {
            return (!(this.CurrentGameMode.TutorialPage == null)) ? this.CurrentGameMode.TutorialPage : this.m_tutorialBookPagePrefab;
        }
    }

    public bool SuperGlueAllowed
    {
        get
        {
            return this.m_SuperGlueAllowed || this.CurrentGameMode is CakeRaceMode;
        }
    }

    public bool SuperMagnetAllowed
    {
        get
        {
            return this.m_SuperMagnetAllowed || this.CurrentGameMode is CakeRaceMode;
        }
    }

    public bool TurboChargeAllowed
    {
        get
        {
            return this.m_TurboChargeAllowed || this.CurrentGameMode is CakeRaceMode;
        }
    }

    public bool SuperBluePrintsAllowed
    {
        get
        {
            return (Singleton<GameManager>.Instance.CurrentEpisodeIndex != 0 || Singleton<GameManager>.Instance.CurrentLevel != 0) && Singleton<GameManager>.Instance.CurrentEpisodeIndex != -1 && !this.m_sandbox && !(this.CurrentGameMode is CakeRaceMode);
        }
    }

    public Transform GoalPosition
    {
        get
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("Goal");
            if (gameObject)
            {
                return gameObject.transform;
            }
            return null;
        }
    }

    public List<CameraPreview.CameraControlPoint> CustomPreview
    {
        get
        {
            return (this.m_gameMode != null) ? this.m_gameMode.Preview : null;
        }
    }

    public float TimeElapsed { get; set; }

    public void AddTemporaryDynamicObject(GameObject obj)
    {
        this.m_temporaryDynamicObjects.Add(obj);
    }

    private void Awake()
    {
        if (!SingletonSpawner.SpawnDone)
        {
            UnityEngine.Object.Instantiate<GameObject>(this.m_gameData.singletonSpawner);
            base.StartCoroutine(this.DelayOnDataLoaded());
            return;
        }
        if (!LevelLoader.IsLoadingLevel())
        {
            this.OnDataLoaded();
        }
    }

    private void OnDestroy()
    {
        this.SetGameState(LevelManager.GameState.Undefined);
        if (this.m_gameMode != null)
        {
            this.m_gameMode.CleanUp();
        }
    }

    public static void IncentiveVideoShown()
    {
        float num = 240f;
        if (Singleton<GameConfigurationManager>.IsInstantiated() && Singleton<GameConfigurationManager>.Instance.HasValue("interstitial_cooldown", "time"))
        {
            num = Singleton<GameConfigurationManager>.Instance.GetValue<float>("interstitial_cooldown", "time");
        }
        LevelManager.nextInterstitialTime = Time.realtimeSinceStartup + num;
    }

    private IEnumerator DelayOnDataLoaded()
    {
        while ((!HatchManager.IsInitialized || !Bundle.initialized) && Bundle.checkingBundles)
        {
            yield return null;
        }
        this.OnDataLoaded();
        yield break;
    }

    private GameMode SetupGameMode()
    {
        int gameModeIndex = LevelManager.GameModeIndex;
        GameManager.EpisodeType episodeType = Singleton<GameManager>.Instance.CurrentEpisodeType;
        if (episodeType == GameManager.EpisodeType.Undefined)
        {
            if (this.m_raceLevel)
            {
                episodeType = GameManager.EpisodeType.Race;
            }
            else if (this.m_sandbox)
            {
                episodeType = GameManager.EpisodeType.Sandbox;
            }
            else
            {
                episodeType = GameManager.EpisodeType.Normal;
            }
        }
        bool flag = false;
        if (episodeType != GameManager.EpisodeType.Normal)
        {
            if (episodeType == GameManager.EpisodeType.Race || episodeType == GameManager.EpisodeType.Sandbox)
            {
                string currentLevelIdentifier = Singleton<GameManager>.Instance.CurrentLevelIdentifier;
                flag = (WPFMonoBehaviour.gameData.m_cakeRaceData.GetTrackCount(currentLevelIdentifier) > 0);
            }
        }
        else
        {
            int currentEpisodeIndex = Singleton<GameManager>.Instance.CurrentEpisodeIndex;
            int currentLevel = Singleton<GameManager>.Instance.CurrentLevel;
            flag = (WPFMonoBehaviour.gameData.m_cakeRaceData.GetTrackCount(currentEpisodeIndex, currentLevel) > 0);
        }
        if (gameModeIndex != 1)
        {
            return new BaseGameMode();
        }
        if (flag)
        {
            return new CakeRaceMode();
        }
        return new BaseGameMode();
    }

    public void OnDataLoaded()
    {
        this.m_gameMode = this.SetupGameMode();
        if (!GameObject.Find("LevelStub"))
        {
            Singleton<GameManager>.Instance.InitializeTestLevelState();
        }
        this.m_gameMode.Initialize(this);
        this.m_gameMode.OnDataLoadedStart();
        UnityEngine.Object.Instantiate<GameObject>(this.m_gameData.effectManager);
        if (this.m_inGameGuiPrefab)
        {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_inGameGuiPrefab);
            gameObject.name = this.m_inGameGuiPrefab.name;
            this.m_inGameGui = gameObject.GetComponent<InGameGUI>();
            Vector3 position = WPFMonoBehaviour.hudCamera.transform.position;
            this.m_inGameGui.transform.position = new Vector3(position.x, position.y, this.m_inGameGui.transform.position.z);
        }
        this.m_gameMode.InitGameMode();
        if (this.m_constructionUI != null)
        {
            this.m_constructionUI.SetMoveButtonStates();
        }
        DynamicObject[] array = UnityEngine.Object.FindObjectsOfType<DynamicObject>();
        foreach (DynamicObject dynamicObject in array)
        {
            GameObject gameObject2 = dynamicObject.gameObject;
            gameObject2.SetActive(false);
            this.m_dynamicObjects.Add(gameObject2);
        }
        this.SetGameState(LevelManager.GameState.Preview);
        if (base.GetComponent<AudioSource>() == null)
        {
            base.gameObject.AddComponent<AudioSource>();
        }
        GameObject gameObject3 = GameObject.FindGameObjectWithTag("World");
        string value = string.Empty;
        PositionSerializer component = gameObject3.GetComponent<PositionSerializer>();
        if (component && component.prefab)
        {
            value = component.prefab.name;
        }
        else
        {
            value = gameObject3.name;
        }
        GameProgress.SetString("MenuBackground", value, GameProgress.Location.Local);
        KeyListener.keyReleased += this.HandleKeyListenerkeyReleased;
        GameObject gameObject4 = null;
        if (GameObject.Find("Background_Jungle_01_SET"))
        {
            gameObject4 = WPFMonoBehaviour.gameData.commonAudioCollection.AmbientJungle;
        }
        else if (GameObject.Find("Background_Plateau_01_SET"))
        {
            gameObject4 = WPFMonoBehaviour.gameData.commonAudioCollection.AmbientPlateau;
        }
        else if (this.m_darkLevel || GameObject.Find("Background_Cave_01_SET 1"))
        {
            gameObject4 = WPFMonoBehaviour.gameData.commonAudioCollection.AmbientCave;
        }
        else if (GameObject.Find("Background_Night_01_SET 1"))
        {
            gameObject4 = WPFMonoBehaviour.gameData.commonAudioCollection.AmbientNight;
        }
        else if (GameObject.Find("Background_Forest_01_SET 1"))
        {
            gameObject4 = WPFMonoBehaviour.gameData.commonAudioCollection.AmbientMorning;
        }
        else if (GameObject.Find("Background_Halloween"))
        {
            gameObject4 = WPFMonoBehaviour.gameData.commonAudioCollection.AmbientHalloween;
        }
        else if (GameObject.Find("Background_MM_01_SET"))
        {
            gameObject4 = WPFMonoBehaviour.gameData.commonAudioCollection.AmbientMaya;
        }
        else if (GameObject.Find("Background_MM_Temple_01_SET_01"))
        {
            gameObject4 = WPFMonoBehaviour.gameData.commonAudioCollection.AmbientMaya;
        }
        AudioSource audioSource = (!gameObject4) ? null : gameObject4.GetComponent<AudioSource>();
        if (audioSource)
        {
            this.m_ambientSource = Singleton<AudioManager>.Instance.SpawnLoopingEffect(audioSource, base.transform);
        }
        if (this.m_levelStartAdDidPause)
        {
            GameTime.Pause(true);
        }
        this.TimeReward = 0f;
        if (this.m_darkLevel)
        {
            GameObject gameObject5 = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Lights/LightManager"));
            this.lightManager = gameObject5.GetComponent<LightManager>();
            this.lightManager.Init(this);
        }
        this.m_gameMode.OnDataLoadedDone();
        EventManager.Send(new GameLevelLoaded(Singleton<GameManager>.Instance.CurrentLevel, Singleton<GameManager>.Instance.CurrentEpisodeIndex));
    }

    private void Start()
    {
        this.audioManager = Singleton<AudioManager>.Instance;
        if (this.m_oneStarContraption != null)
        {
            this.m_threeStarContraption.Add(this.m_oneStarContraption);
        }
    }

    private void OnEnable()
    {
        EventManager.Connect(new EventManager.OnEvent<GadgetControlEvent>(this.ReceiveGadgetControlEvent));
        EventManager.Connect(new EventManager.OnEvent<Dessert.DessertCollectedEvent>(this.ReceiveDessertCollected));
    }

    private void OnDisable()
    {
        EventManager.Disconnect(new EventManager.OnEvent<GadgetControlEvent>(this.ReceiveGadgetControlEvent));
        EventManager.Disconnect(new EventManager.OnEvent<Dessert.DessertCollectedEvent>(this.ReceiveDessertCollected));
        KeyListener.keyReleased -= this.HandleKeyListenerkeyReleased;
    }

    private void HandleKeyListenerkeyReleased(KeyCode obj)
    {
        if (obj == KeyCode.Escape)
        {
            if (this.gameState == LevelManager.GameState.Building || this.gameState == LevelManager.GameState.Running)
            {
                EventManager.Send(new UIEvent(UIEvent.Type.Pause));
            }
            else if (this.gameState == LevelManager.GameState.PausedWhileBuilding || this.gameState == LevelManager.GameState.PausedWhileRunning)
            {
                EventManager.Send(new UIEvent(UIEvent.Type.ContinueFromPause));
            }
            else if (this.gameState == LevelManager.GameState.TutorialBook)
            {
                EventManager.Send(new UIEvent(UIEvent.Type.CloseTutorial));
            }
            else if (this.gameState == LevelManager.GameState.PreviewWhileBuilding)
            {
                this.SetGameState(LevelManager.GameState.Building);
            }
        }
    }

    public void CameraPreviewDone()
    {
        if (this.m_sandbox && this.m_constructionUI.UnlockedParts.Count > 0)
        {
            this.SetGameState(LevelManager.GameState.ShowingUnlockedParts);
        }
        else
        {
            this.SetGameState(LevelManager.GameState.Building);
        }
    }

    public void ReceiveGadgetControlEvent(GadgetControlEvent data)
    {
        this.ContraptionRunning.ActivatePartType(data.partType, data.direction);
    }

    public void CheckForLevelStartAchievements()
    {
        if (Singleton<SocialGameManager>.IsInstantiated())
        {
            Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.COMPLEX_COMPLEX", 100.0, (int limit) => this.ContraptionProto.Parts.Count >= limit);
            List<BasePart.PartType> pinkParts = new List<BasePart.PartType>();
            List<BasePart.PartType> boneParts = new List<BasePart.PartType>();
            List<BasePart.PartType> goldenParts = new List<BasePart.PartType>();
            List<BasePart.PartType> blackParts = new List<BasePart.PartType>();
            foreach (BasePart basePart in this.ContraptionProto.Parts)
            {
                if (basePart.tags != null && basePart.tags.Count > 0)
                {
                    if (!pinkParts.Contains(basePart.m_partType) && basePart.tags.Contains("Pink"))
                    {
                        pinkParts.Add(basePart.m_partType);
                    }
                    if (!boneParts.Contains(basePart.m_partType) && basePart.tags.Contains("Bone"))
                    {
                        boneParts.Add(basePart.m_partType);
                    }
                    if (!goldenParts.Contains(basePart.m_partType) && basePart.tags.Contains("Gold"))
                    {
                        goldenParts.Add(basePart.m_partType);
                    }
                    if (!blackParts.Contains(basePart.m_partType) && basePart.tags.Contains("Black"))
                    {
                        blackParts.Add(basePart.m_partType);
                    }
                }
            }
            if (pinkParts.Count > 0)
            {
                Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.PINK_BUILDER", 100.0, (int limit) => pinkParts.Count >= limit);
            }
            if (boneParts.Count > 0)
            {
                Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.BONE_BUILDER", 100.0, (int limit) => boneParts.Count >= limit);
            }
            if (goldenParts.Count > 0)
            {
                Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.GOLDEN_BUILDER", 100.0, (int limit) => goldenParts.Count >= limit);
            }
            if (blackParts.Count > 0)
            {
                Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.BLACK_BUILDER", 100.0, (int limit) => blackParts.Count >= limit);
            }
        }
    }

    public void PlaceBuildArea()
    {
        float x = this.m_gameMode.ContraptionProto.FindPig().transform.localPosition.x;
        Vector3 position = this.m_gameMode.ContraptionRunning.FindPig().transform.position;
        Vector3 vector = position;
        int layerMask = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit raycastHit;
        if (Physics.Raycast(new Ray(position, new Vector3(0f, -1f, 0f)), out raycastHit, 100f, layerMask))
        {
            vector.y = position.y - raycastHit.distance + 1.1f;
        }
        vector.x = position.x - x;
        int num = 0;
        int num2 = 0;
        for (int i = this.GridXMin; i <= this.GridXMax; i++)
        {
            int num3 = 0;
            for (int j = 0; j < this.GridHeight; j++)
            {
                for (int k = this.GridXMin - 1; k <= this.GridXMax + 1; k++)
                {
                    bool flag = !Physics.CheckSphere(vector + new Vector3((float)(k + i), (float)j, 0f), 0.55f, layerMask);
                    if (flag)
                    {
                        num3++;
                    }
                }
            }
            int num4 = num3;
            if (i == 0)
            {
                num4++;
            }
            if (num4 > num)
            {
                num = num4;
                num2 = i;
            }
        }
        vector.x += (float)num2;
        vector.z = 0f;
        this.m_constructionUI.transform.position = vector;
        this.m_gameMode.ContraptionProto.transform.position = vector;
    }

    public void ShowPurchaseDialog(IapManager.InAppPurchaseItemType iapType)
    {
        if (Singleton<BuildCustomizationLoader>.Instance.IsOdyssey)
        {
            return;
        }
        string spriteID = string.Empty;
        switch (iapType)
        {
            case IapManager.InAppPurchaseItemType.BlueprintSingle:
                spriteID = "ce80c724-b7f4-4df0-9f5b-46c4bc5a8599";
                break;
            case IapManager.InAppPurchaseItemType.SuperGlueSingle:
                spriteID = "5a3b2e58-b8c9-444e-a315-e7d76c5bbac0";
                break;
            case IapManager.InAppPurchaseItemType.SuperMagnetSingle:
                spriteID = "ac695667-b01a-4f46-b346-9225a78f6baf";
                break;
            case IapManager.InAppPurchaseItemType.TurboChargeSingle:
                spriteID = "67151809-a646-4a30-9a4e-5241ab0da385";
                break;
            case IapManager.InAppPurchaseItemType.NightVisionSingle:
                spriteID = "33e4b4c2-4626-4e65-8b5e-a1e9b0df563d";
                break;
        }
        this.m_inGameGui.Hide();
        Singleton<IapManager>.Instance.GetShop().ConfirmSinglePurchase(iapType.ToString(), spriteID, string.Empty, 1, delegate
        {
            this.m_inGameGui.Show();
            ResourceBar.Instance.ShowItem(ResourceBar.Item.SnoutCoin, false, true);
        });
    }

    public void OpenShop(string pageName)
    {
        if (Singleton<BuildCustomizationLoader>.Instance.IAPEnabled)
        {
            this.m_toolboxOpenUponShopActivation = this.m_inGameGui.BuildMenu.ToolboxButton.ToolboxOpen;
            this.m_inGameGui.Hide();
            Singleton<IapManager>.Instance.OpenShopPage(delegate
            {
                this.m_inGameGui.Show();
            }, pageName);
        }
    }

    private IEnumerator OpenBluePrint()
    {
        yield return 0;
        EventManager.Send(new UIEvent(UIEvent.Type.Blueprint));
        yield break;
    }

    public void StartAutoBuild(TextAsset contraptionQuality)
    {
        Singleton<GuiManager>.Instance.IsEnabled = false;
        this.ConstructionUI.ClearContraption();
        this.m_autoBuildData = WPFPrefs.LoadContraptionDataset(contraptionQuality);
        this.SetAutoBuildOrder(this.m_autoBuildData);
        this.m_autoBuildTimer = 0f;
        this.m_mechanicDustTimer = 0f;
        this.m_autoBuildIndex = 0;
        this.m_autoBuildPhase = 0;
        this.m_inGameGui.BuildMenu.PigMechanic.SetTime(0.6f);
        this.m_inGameGui.BuildMenu.PigMechanic.Play();
    }

    public void SetGameState(GameState newState)
    {
        GameState gameState = this.gameState;
        this.gameState = this.m_gameMode.SetGameState(this.gameState, newState);
        EventManager.Send(new GameStateChanged(this.gameState, gameState));
    }

    public void HandleSnapshotFinished()
    {
        this.m_inGameGui.ShowCurrentMenu(true);
        this.SetGameState(LevelManager.GameState.Continue);
        if (Singleton<SocialGameManager>.IsInstantiated())
        {
            Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.SHOW_OFF", 100.0);
        }
    }

    public void SetupDynamicObjects()
    {
        foreach (GameObject gameObject in this.m_dynamicObjectClones)
        {
            gameObject.SetActive(false);
            UnityEngine.Object.Destroy(gameObject);
        }
        this.m_dynamicObjectClones.Clear();
        foreach (GameObject gameObject2 in this.m_temporaryDynamicObjects)
        {
            gameObject2.SetActive(false);
            UnityEngine.Object.Destroy(gameObject2);
        }
        this.m_temporaryDynamicObjects.Clear();
        foreach (GameObject original in this.m_dynamicObjects)
        {
            GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(original);
            gameObject3.SetActive(true);
            this.m_dynamicObjectClones.Add(gameObject3);
        }
    }

    private void ReceiveDessertCollected(Dessert.DessertCollectedEvent eventData)
    {
        GameProgress.AddDesserts(eventData.dessert.saveId, 1);
        this.m_CollectedDessertsCount++;
        string key = Singleton<GameManager>.Instance.CurrentSceneName + "_dessert_placement";
        if (this.m_UsedDessertPlaces.Remove(eventData.dessert.place.name))
        {
            string value = string.Empty;
            if (this.m_UsedDessertPlaces.Count > 0)
            {
                int num = 0;
                string[] array = new string[this.m_UsedDessertPlaces.Count];
                foreach (KeyValuePair<string, string> x in this.m_UsedDessertPlaces)
                {
                    array[num] = x.Key + ":" + x.Value;
                    num++;
                }
                value = string.Join(";", array);
            }
            GameProgress.SetString(key, value, GameProgress.Location.Local);
        }
        if (Singleton<SocialGameManager>.IsInstantiated() && !LevelManager.isConfectionerReported)
        {
            if (Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.CONFECTIONER", 100.0, (int limit) => GameProgress.TotalDessertCount() > limit))
            {
                LevelManager.isConfectionerReported = true;
            }
        }
    }

    public bool LoadDessertsPlacement(GameObject dessertPlacesRoot)
    {
        if (dessertPlacesRoot == null)
        {
            return false;
        }
        string key = Singleton<GameManager>.Instance.CurrentSceneName + "_dessert_placement";
        this.m_UsedDessertPlaces.Clear();
        string @string = GameProgress.GetString(key, null, GameProgress.Location.Local, null);
        if (string.IsNullOrEmpty(@string))
        {
            return false;
        }
        string[] array = @string.Split(new char[]
        {
            ';'
        });
        if (array == null || array.Length <= 0)
        {
            return false;
        }
        DessertPlacePair[] array2 = new DessertPlacePair[array.Length];
        int num = 0;
        for (int i = 0; i < array.Length; i++)
        {
            string[] placeDessert = array[i].Split(new char[]
            {
                ':'
            }, 2);
            if (placeDessert == null || placeDessert.Length < 2 || string.IsNullOrEmpty(placeDessert[0]) || string.IsNullOrEmpty(placeDessert[1]))
            {
                this.m_UsedDessertPlaces.Clear();
                return false;
            }
            Transform transform = dessertPlacesRoot.transform.Find(placeDessert[0]);
            GameObject gameObject = WPFMonoBehaviour.gameData.m_desserts.Find((GameObject dessert) => dessert != null && dessert.GetComponent<Dessert>().saveId == placeDessert[1]);
            if (!(transform != null) || !(gameObject != null))
            {
                this.m_UsedDessertPlaces.Clear();
                return false;
            }
            array2[num].dessert = gameObject;
            array2[num].place = transform;
            num++;
            this.m_UsedDessertPlaces.Add(placeDessert[0], placeDessert[1]);
        }
        for (int j = 0; j < num; j++)
        {
            GameObject dessert2 = array2[j].dessert;
            Transform place = array2[j].place;
            GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(dessert2, place.position, place.rotation);
            gameObject2.name = dessert2.name;
            gameObject2.GetComponent<Dessert>().place = place.GetComponent<DessertPlace>();
        }
        return true;
    }

    public void NotifyGoalReachedByPart(BasePart.PartType partType)
    {
        this.m_gameMode.NotifyGoalReachedByPart(partType);
    }

    public bool PlayerHasRequiredObjects()
    {
        return this.m_gameMode.PlayerHasRequiredObjects();
    }

    public void NotifyGoalReached()
    {
        this.m_gameMode.NotifyGoalReached();
    }

    public bool IsPartTransported(BasePart.PartType partType)
    {
        BasePart basePart = this.m_gameMode.ContraptionRunning.FindPart(partType);
        if (basePart == null)
        {
            return false;
        }
        if (this.m_gameMode.ContraptionRunning.IsConnectedToPig(basePart, null))
        {
            return true;
        }
        if (basePart)
        {
            int connectedComponent = this.m_gameMode.ContraptionRunning.FindPig().ConnectedComponent;
            for (int i = 0; i < this.m_gameMode.ContraptionRunning.Parts.Count; i++)
            {
                if (this.m_gameMode.ContraptionRunning.Parts[i] != null && this.m_gameMode.ContraptionRunning.Parts[i].ConnectedComponent == connectedComponent && Vector3.Distance(basePart.Position, this.m_gameMode.ContraptionRunning.Parts[i].Position) < 2.5f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void NotifyStarCollected()
    {
        this.m_starCollected++;
    }

    public void CreateGrid(int newGridWidth, int newGridHeight, int newGridXMin, int newGridXMax, Vector3 position)
    {
        this.m_gridWidth = newGridWidth;
        this.m_gridHeight = newGridHeight;
        this.m_gridXmin = newGridXMin;
        this.m_gridXmax = newGridXMax;
        this.m_levelStart = position;
        if (WPFMonoBehaviour.gameData.m_constructionUIPrefab)
        {
            Transform transform = UnityEngine.Object.Instantiate<Transform>(WPFMonoBehaviour.gameData.m_constructionUIPrefab);
            transform.gameObject.name = WPFMonoBehaviour.gameData.m_constructionUIPrefab.name;
            if (transform)
            {
                this.m_constructionUI = transform.GetComponent<ConstructionUI>();
                transform.position = position;
            }
        }
    }

    public bool CanPlacePartAtGridCell(int x, int y)
    {
        if (x < this.m_gridXmin || x > this.m_gridXmax || y < 0 || y >= this.m_gridHeight)
        {
            return false;
        }
        int index = this.m_gridHeight - y - 1;
        int num = x - this.m_gridXmin;
        int num2 = this.CurrentConstructionGridRows[index];
        return (num2 & 1 << num) != 0;
    }

    public BasePart BuildPart(ContraptionDataset.ContraptionDatasetUnit cdu, BasePart partPrefab)
    {
        BasePart basePart = WPFMonoBehaviour.levelManager.ConstructionUI.SetPartAt(cdu.x, cdu.y, partPrefab, false);
        if (cdu.flipped)
        {
            basePart.SetFlipped(true);
        }
        else
        {
            basePart.SetRotation((BasePart.GridRotation)cdu.rot);
        }
        return basePart;
    }

    public int GetPartTypeCount(BasePart.PartType type)
    {
        if (UnityEngine.Application.isPlaying)
        {
            return this.m_gameMode.GetPartCount(type);
        }
        int num = 0;
        foreach (PartCount partCount in this.m_partTypeCounts)
        {
            if (partCount.type == type)
            {
                num += partCount.count;
                break;
            }
        }
        if (this.m_useSecondStarParts)
        {
            foreach (PartCount partCount2 in this.m_extraPartsForSecondStar)
            {
                if (partCount2.type == type)
                {
                    num += partCount2.count;
                    break;
                }
            }
        }
        if (this.m_sandbox && !(this.CurrentGameMode is CakeRaceMode))
        {
            if (!this.m_collectPartBoxesSandbox)
            {
                num += GameProgress.GetSandboxPartCount(type);
            }
            num += GameProgress.GetSandboxPartCount(Singleton<GameManager>.Instance.CurrentSceneName, type);
        }
        return num;
    }

    public void OnDrawGizmosSelected()
    {
        LevelStart levelStart = WPFMonoBehaviour.FindSceneObjectOfType<LevelStart>();
        Transform goalPosition = this.GoalPosition;
        if (levelStart && goalPosition)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(levelStart.transform.position, goalPosition.transform.position);
        }
        if (levelStart)
        {
            Gizmos.color = Color.green;
            Vector3 constructionOffset = this.m_constructionOffset;
            constructionOffset.z = 0f;
            Vector3 center = levelStart.transform.position + constructionOffset;
            float num = 1.33333337f;
            Camera component = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            float num2 = Mathf.Tan(component.fieldOfView * 0.0174532924f);
            float num3 = num2 * Mathf.Abs(this.m_constructionOffset.z);
            Vector3 size = new Vector3(num3, num3 / num, 0f);
            Gizmos.DrawWireCube(center, size);
        }
        if (goalPosition)
        {
            Gizmos.color = Color.green;
            Vector3 previewOffset = this.m_previewOffset;
            previewOffset.z = 0f;
            Vector3 center2 = goalPosition.transform.position + previewOffset;
            float num4 = 1.33333337f;
            Camera component2 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            float num5 = Mathf.Tan(component2.fieldOfView * 0.0174532924f);
            float num6 = num5 * Mathf.Abs(this.m_previewOffset.z);
            Vector3 size2 = new Vector3(num6, num6 / num4, 0f);
            Gizmos.DrawWireCube(center2, size2);
        }
    }

    public void Update()
    {
        GameState gameState = this.gameState;
        switch (gameState)
        {
            case LevelManager.GameState.Preview:
                this.UpdatePreview();
                break;
            case LevelManager.GameState.PreviewMoving:
                this.UpdatePreviewMoving();
                break;
            default:
                switch (gameState)
                {
                    case LevelManager.GameState.AutoBuilding:
                        break;
                    default:
                        if (gameState != LevelManager.GameState.SuperAutoBuilding)
                        {
                            goto IL_7C;
                        }
                        break;
                    case LevelManager.GameState.ShowingUnlockedParts:
                        this.UpdateShowUnlockedParts();
                        goto IL_7C;
                }
                this.UpdateAutoBuild();
                break;
            case LevelManager.GameState.Running:
                this.UpdateRunning();
                break;
        }
        IL_7C:
        if (GuiManager.GetPointer().down && GuiManager.GetPointer().onWidget)
        {
            EventManager.Send(default(UserInputEvent));
        }
        this.m_gameMode.Update();
    }

    private void UpdatePreview()
    {
        this.m_previewTime += Time.deltaTime * this.m_previewSpeed;
        bool flag = Input.touchCount > 0 || Input.GetMouseButtonDown(0);
        if (this.m_previewTime > this.m_previewWaitTime || flag)
        {
            this.SetGameState(LevelManager.GameState.PreviewMoving);
        }
    }

    private void UpdatePreviewMoving()
    {
        this.m_previewTime += Time.deltaTime * this.m_previewSpeed;
    }

    private void UpdateRunning()
    {
        if (this.m_timeStarted)
        {
            this.TimeElapsed += Time.deltaTime;
        }
        else if (Vector3.Distance(this.ContraptionRunning.FindPig().transform.position, this.PigStartPosition) >= 1f)
        {
            this.m_timeStarted = true;
        }
    }

    private void UpdateShowUnlockedParts()
    {
        if (!this.m_unlockedPartBackground)
        {
            this.m_unlockedPartBackground = new GameObject();
            this.m_unlockedPartBackground.transform.position = new Vector3(WPFMonoBehaviour.hudCamera.transform.position.x, WPFMonoBehaviour.hudCamera.transform.position.y, WPFMonoBehaviour.hudCamera.transform.position.z + 2f);
            float num = WPFMonoBehaviour.hudCamera.orthographicSize * 0.15f;
            this.m_unlockedPartBackground.transform.localScale = new Vector3(num, num, num);
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_partAppearBackground);
            gameObject.transform.parent = this.m_unlockedPartBackground.transform;
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localScale = Vector3.one;
            gameObject.GetComponent<Animation>().Play("BringInPartBox");
        }
        this.m_partShowTimer += Time.deltaTime;
        if (this.m_unlockedPartIndex == -1)
        {
            if (this.m_partShowTimer > 0.6f)
            {
                this.m_partShowTimer = 0f;
                this.m_unlockedPartIndex = 0;
            }
            return;
        }
        if (this.m_partShowTimer < 1.25f && this.m_unlockedPartIndex < this.m_unlockedParts.Count)
        {
            ConstructionUI.PartDesc partDesc = this.m_unlockedParts[this.m_unlockedPartIndex];
            if (!this.m_dragIcon)
            {
                this.m_dragIcon = new GameObject();
                float num2 = Vector3.Distance(this.m_constructionUI.GridPositionToGuiPosition(0, 0), this.m_constructionUI.GridPositionToGuiPosition(1, 0));
                this.m_dragIcon.transform.localScale = new Vector3(num2, num2, num2);
                this.m_dragIcon.transform.position = new Vector3(WPFMonoBehaviour.hudCamera.transform.position.x, WPFMonoBehaviour.hudCamera.transform.position.y, WPFMonoBehaviour.hudCamera.transform.position.z + 1f);
                GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(partDesc.part.m_constructionIconSprite.gameObject, new Vector3(1000f, 0f, 0f), Quaternion.identity);
                gameObject2.transform.parent = this.m_dragIcon.transform;
                gameObject2.transform.localScale = Vector3.one;
                gameObject2.transform.localPosition = Vector3.zero;
                gameObject2.AddComponent<Animation>();
                gameObject2.GetComponent<Animation>().AddClip(WPFMonoBehaviour.gameData.m_partAppearAnimation, "PartAppear");
                gameObject2.GetComponent<Animation>().Play("PartAppear");
            }
            if (this.m_partShowTimer > 0.75f)
            {
                Vector3 item = new Vector3(WPFMonoBehaviour.hudCamera.transform.position.x, WPFMonoBehaviour.hudCamera.transform.position.y, WPFMonoBehaviour.hudCamera.transform.position.z + 1f);
                GameObject gameObject3 = this.m_constructionUI.FindPartButton(partDesc.part.m_partType);
                if (gameObject3 == null)
                {
                    return;
                }
                Vector3 position = gameObject3.transform.position;
                position.z = WPFMonoBehaviour.hudCamera.transform.position.z + 1f;
                position.z = WPFMonoBehaviour.hudCamera.transform.position.z + 1f;
                List<Vector3> list = new List<Vector3>();
                list.Add(item);
                list.Add(item);
                list.Add(new Vector3(0.4f * item.x + 0.6f * position.x, 0.2f * item.y + 0.8f * position.y, item.z));
                list.Add(position);
                float t = MathsUtil.EaseInOutQuad(this.m_partShowTimer - 0.75f, 0f, 1f, 0.5f);
                this.m_dragIcon.transform.position = Tutorial.PositionOnSpline(list, t);
            }
        }
        else
        {
            if (this.m_unlockedPartIndex < this.m_unlockedParts.Count)
            {
                ConstructionUI.PartDesc partDesc2 = this.m_unlockedParts[this.m_unlockedPartIndex];
                this.m_constructionUI.AddUnlockedPart(partDesc2.part.m_partType, partDesc2.maxCount);
            }
            this.m_partShowTimer = 0f;
            this.m_unlockedPartIndex++;
            UnityEngine.Object.Destroy(this.m_dragIcon);
            this.m_dragIcon = null;
            if (this.m_unlockedPartIndex >= this.m_unlockedParts.Count)
            {
                this.m_unlockedPartBackground.transform.GetChild(0).GetComponent<Animation>().Play("BringOutPartBox");
                UnityEngine.Object.Destroy(this.m_unlockedPartBackground, 1f);
                this.m_unlockedPartBackground = null;
                this.SetGameState(LevelManager.GameState.Building);
            }
        }
    }

    private void UpdateAutoBuild()
    {
        this.m_autoBuildTimer += Time.deltaTime;
        if (this.m_autoBuildPhase == 0)
        {
            Vector3 b = this.m_constructionUI.RelativeLevelPositionToHudPosition(new Vector3((float)WPFMonoBehaviour.levelManager.GridXMax + 0.5f, -0.5f, 0f));
            Vector3 a = WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(new Vector3((float)Screen.width, 0f, 0f));
            a.x += 2.5f;
            a.y = b.y;
            a.z = b.z;
            if (this.m_autoBuildTimer <= ((!this.fastBuilding) ? 0.7f : this.mechanicAnimationTimerOverride))
            {
                float t = MathsUtil.EaseInOutQuad(this.m_autoBuildTimer, 0f, 1f, (!this.fastBuilding) ? 0.7f : this.mechanicAnimationTimerOverride);
                GameObject gameObject = GameObject.Find("PigMechanic");
                gameObject.transform.position = Vector3.Slerp(a, b, t);
                this.m_mechanicDustTimer += Time.deltaTime;
                if (this.m_mechanicDustTimer > 0.125f)
                {
                    this.m_mechanicDustTimer = 0f;
                    Vector3 position = WPFMonoBehaviour.hudCamera.WorldToScreenPoint(gameObject.transform.position + Vector3.down);
                    Vector3 position2 = Camera.main.ScreenToWorldPoint(position);
                    WPFMonoBehaviour.effectManager.CreateParticles(WPFMonoBehaviour.gameData.m_dustParticles, position2, false);
                }
            }
            else if (this.m_autoBuildTimer > ((!this.fastBuilding) ? 1f : this.mechanicAnimationTimerOverride))
            {
                this.m_autoBuildPhase = 1;
            }
        }
        else if (this.m_autoBuildPhase == 1)
        {
            if (this.m_autoBuildPart == null)
            {
                if (this.m_autoBuildTimer > ((!this.fastBuilding) ? 0.2f : this.animationTimerOverride))
                {
                    this.m_autoBuildTimer = 0f;
                    if (this.m_autoBuildIndex < this.m_autoBuildData.ContraptionDatasetList.Count)
                    {
                        ContraptionDataset.ContraptionDatasetUnit contraptionDatasetUnit = this.m_autoBuildData.ContraptionDatasetList[this.m_autoBuildIndex];
                        ConstructionUI.PartDesc partDesc = this.m_constructionUI.FindPartDesc((BasePart.PartType)contraptionDatasetUnit.partType);
                        if (partDesc != null)
                        {
                            partDesc.useCount++;
                            EventManager.Send(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
                        }
                        this.m_autoBuildPart = partDesc;
                        this.m_dragIcon = UnityEngine.Object.Instantiate<GameObject>(partDesc.part.m_constructionIconSprite.gameObject, new Vector3(1000f, 0f, 0f), Quaternion.identity);
                        float num = Vector3.Distance(this.m_constructionUI.GridPositionToGuiPosition(0, 0), this.m_constructionUI.GridPositionToGuiPosition(1, 0));
                        this.m_dragIcon.transform.localScale = new Vector3(num, num, num);
                    }
                    else
                    {
                        this.m_autoBuildPhase = 2;
                    }
                }
            }
            else if (this.m_autoBuildTimer < ((!this.fastBuilding) ? 0.2f : this.animationTimerOverride))
            {
                ContraptionDataset.ContraptionDatasetUnit contraptionDatasetUnit2 = this.m_autoBuildData.ContraptionDatasetList[this.m_autoBuildIndex];
                GameObject gameObject2 = GameObject.Find("PartSelector").GetComponent<PartSelector>().FindPartButton(this.m_autoBuildPart);
                Vector3 position3 = gameObject2.transform.position;
                position3.z = WPFMonoBehaviour.hudCamera.transform.position.z + 1f;
                Vector3 item = this.m_constructionUI.RelativeLevelPositionToHudPosition(new Vector3((float)contraptionDatasetUnit2.x, (float)contraptionDatasetUnit2.y, 0f));
                item.z = WPFMonoBehaviour.hudCamera.transform.position.z + 1f;
                List<Vector3> list = new List<Vector3>();
                list.Add(position3);
                list.Add(new Vector3(0.4f * position3.x + 0.6f * item.x, 0.2f * position3.y + 0.8f * item.y, position3.z));
                list.Add(item);
                float t2 = MathsUtil.EaseInOutQuad(this.m_autoBuildTimer, 0f, 1f, 0.2f);
                this.m_dragIcon.transform.position = Tutorial.PositionOnSpline(list, t2);
            }
            else if (this.m_autoBuildTimer > ((!this.fastBuilding) ? 0.2f : this.animationTimerOverride))
            {
                UnityEngine.Object.Destroy(this.m_dragIcon);
                ContraptionDataset.ContraptionDatasetUnit contraptionDatasetUnit3 = this.m_autoBuildData.ContraptionDatasetList[this.m_autoBuildIndex];
                BasePart basePart = this.BuildPart(contraptionDatasetUnit3, this.m_autoBuildPart.part);
                basePart.GetComponent<BasePart>().ChangeVisualConnections();
                this.ContraptionProto.RefreshNeighbours(basePart.m_coordX, basePart.m_coordY);
                Vector3 position4 = this.m_constructionUI.GridPositionToWorldPosition(contraptionDatasetUnit3.x, contraptionDatasetUnit3.y);
                position4.z += -1f;
                WPFMonoBehaviour.effectManager.CreateParticles(WPFMonoBehaviour.gameData.m_constructionParticles, position4, false);
                this.m_autoBuildIndex++;
                this.m_autoBuildPart = null;
                this.m_autoBuildTimer = 0f;
            }
        }
        else if (this.m_autoBuildPhase == 2)
        {
            Vector3 a2 = this.m_constructionUI.RelativeLevelPositionToHudPosition(new Vector3((float)WPFMonoBehaviour.levelManager.GridXMax + 0.5f, -0.5f, 0f));
            Vector3 b2 = WPFMonoBehaviour.hudCamera.ScreenToWorldPoint(new Vector3((float)Screen.width, 0f, 0f));
            b2.x += 2.5f;
            b2.y = a2.y;
            b2.z = a2.z;
            if (this.m_autoBuildTimer <= ((!this.fastBuilding) ? 0.7f : this.mechanicAnimationTimerOverride))
            {
                float t3 = MathsUtil.EaseInOutQuad(this.m_autoBuildTimer, 0f, 1f, (!this.fastBuilding) ? 0.7f : this.mechanicAnimationTimerOverride);
                GameObject gameObject3 = GameObject.Find("PigMechanic");
                gameObject3.transform.position = Vector3.Slerp(a2, b2, t3);
                this.m_mechanicDustTimer += Time.deltaTime;
                if (this.m_mechanicDustTimer > 0.125f)
                {
                    this.m_mechanicDustTimer = 0f;
                    Vector3 position5 = WPFMonoBehaviour.hudCamera.WorldToScreenPoint(gameObject3.transform.position + Vector3.down);
                    Vector3 position6 = Camera.main.ScreenToWorldPoint(position5);
                    WPFMonoBehaviour.effectManager.CreateParticles(WPFMonoBehaviour.gameData.m_dustParticles, position6, false);
                }
            }
            else
            {
                this.SetGameState(LevelManager.GameState.Building);
                this.m_constructionUI.SetMoveButtonStates();
                Singleton<GuiManager>.Instance.IsEnabled = true;
            }
        }
    }

    public void SetAutoBuildOrder(ContraptionDataset data)
    {
        int num = -1;
        List<ContraptionDataset.ContraptionDatasetUnit> contraptionDatasetList = data.ContraptionDatasetList;
        for (int i = 0; i < contraptionDatasetList.Count; i++)
        {
            if (contraptionDatasetList[i].partType == 10)
            {
                num = i;
                break;
            }
        }
        if (num != -1)
        {
            ContraptionDataset.ContraptionDatasetUnit value = contraptionDatasetList[contraptionDatasetList.Count - 1];
            contraptionDatasetList[contraptionDatasetList.Count - 1] = contraptionDatasetList[num];
            contraptionDatasetList[num] = value;
        }
    }

    public void PlayVictorySound()
    {
        //this.audioManager.Play2dEffect(Path.Combine(Application.dataPath, "AudioClip","unlock_secretlevel_v01.wav"));
		this.audioManager.Play2dEffect((AudioClip) Resources.Load("AudioAdd" + Path.DirectorySeparatorChar + "unlock_secretlevel_v01"));
    }

    private void OnApplicationFocus(bool focus)
    {
        Shop shop = Singleton<IapManager>.Instance.GetShop();
        if (focus)
        {
            return;
        }
        if (shop != null && (shop.gameObject.activeInHierarchy || shop.SnoutCoinShop.gameObject.activeInHierarchy))
        {
            return;
        }
        if ((this.gameState == LevelManager.GameState.Running || this.gameState == LevelManager.GameState.Building))
        {
            EventManager.Send(new UIEvent(UIEvent.Type.Pause));
        }
    }

    public void StopAmbient()
    {
        if (this.m_ambientSource != null)
        {
            Singleton<AudioManager>.Instance.StopLoopingEffect(this.m_ambientSource.GetComponent<AudioSource>());
        }
    }

    public void AddToTimeLimit(float time)
    {
        this.TimeReward = time;
        for (int i = 0; i < this.m_timeLimits.Count; i++)
        {
            List<float> timeLimits = this.m_timeLimits;
            int index = i;
            timeLimits[index] = timeLimits[index] + time;
            this.m_timeLimit += time;
        }
        for (int j = 0; j < this.m_challenges.Count; j++)
        {
            if (this.m_challenges[j].Type == Challenge.ChallengeType.Time)
            {
                (this.m_challenges[j] as TimeChallenge).m_targetTime += time;
            }
        }
    }

    public bool IsTimeChallengesCompleted()
    {
        for (int i = 0; i < this.m_challenges.Count; i++)
        {
            if (this.m_challenges[i].Type == Challenge.ChallengeType.Time && GameProgress.IsChallengeCompleted(Singleton<GameManager>.Instance.CurrentSceneName, this.m_challenges[i].ChallengeNumber) && this.m_challenges[i].IsCompleted())
            {
                return true;
            }
        }
        return false;
    }

    [HideInInspector]
    public int m_constructionUiRows = 1;

    [HideInInspector]
    public List<int> m_constructionGridRows = new List<int>();

    [HideInInspector]
    public List<int> m_secondStarConstructionGridRows = new List<int>();

    [HideInInspector]
    public List<PartCount> m_partTypeCounts = new List<PartCount>();

    [HideInInspector]
    public bool m_newHighscore;

    [HideInInspector]
    public GameObject m_levelCompleteTutorialBookPagePrefab;

    [HideInInspector]
    public bool m_gridForSecondStar;

    [HideInInspector]
    public int m_totalAvailableParts;

    [HideInInspector]
    public int m_totalDestroyedParts;

    public GameObject m_inGameGuiPrefab;

    public Vector3 m_cameraOffset = new Vector3(0f, 0f, -10f);

    public Vector3 m_constructionOffset = new Vector3(0f, 0f, -7f);

    public Vector3 m_previewOffset = new Vector3(0f, 0f, -10f);

    public float m_predictionOffset = 2f;

    public CameraLimits m_cameraLimits;

    public float m_previewZoomOut = 15f;

    public float m_previewMoveTime = 5f;

    public float m_previewWaitTime = 5f;

    public bool m_showPowerupTutorial;

    public Texture2D m_blueprintTexture;

    public ScoreLimits m_scoreLimits;

    public GameObject m_gridCellPrefab;

    public bool m_SuperGlueAllowed = true;

    public bool m_SuperMagnetAllowed = true;

    public bool m_TurboChargeAllowed = true;

    public float m_tutorialDelayBeforeHint = 3f;

    public float m_tutorialDelayAfterHint = 1.5f;

    public GameData m_gameData;

    public GUIStyle m_buttonStyle;

    public float m_previewSpeed;

    public float m_previewTime;

    public bool m_previewDragging;

    public Vector2 m_previewLastMousePos;

    public GameObject m_tutorialBookPagePrefab;

    public TextAsset m_prebuiltContraption;

    public TextAsset m_oneStarContraption;

    public List<TextAsset> m_threeStarContraption = new List<TextAsset>();

    public List<PartCount> m_partsToUnlockOnCompletion = new List<PartCount>();

    public bool m_showOnlyEngineButton;

    public bool m_disablePigCollisions;

    public List<PartCount> m_extraPartsForSecondStar = new List<PartCount>();

    public bool m_sandbox;

    public bool m_raceLevel;

    public bool m_collectPartBoxesSandbox;

    public bool m_darkLevel;

    public bool m_autoBuildUnlocked;

    public int m_CollectedDessertsCount;

    [SerializeField]
    private int m_DessertsCount = -1;

    [SerializeField]
    private float animationTimerOverride = 0.03f;

    [SerializeField]
    private float mechanicAnimationTimerOverride = 0.2f;

    private static float nextInterstitialTime = -1f;

    private const string INTERSTITIAL_COOLDOWN = "interstitial_cooldown";

    private bool m_levelStartAdDidPause;

    private bool m_requireConnectedContraption;

    private GameState m_gameState;

    private GameState m_stateBeforeTutorial;

    private List<BasePart.PartType> m_partsInGoal = new List<BasePart.PartType>();

    private int m_starCollected;

    private float m_completionTime;

    private bool m_completedLevel;

    private ConstructionUI m_constructionUI;

    private bool m_timeStarted;

    private AudioManager audioManager;

    private LightManager lightManager;

    private int m_gridHeight;

    private int m_gridWidth;

    private int m_gridXmin;

    private int m_gridXmax;

    private Vector3 m_previewCenter;

    private float m_lastTimePlayedCollisionSound;

    private InGameGUI m_inGameGui;

    private List<Challenge> m_challenges = new List<Challenge>();

    private float m_timeLimit;

    private List<float> m_timeLimits = new List<float>();

    private bool m_useSecondStarParts;

    private float m_autoBuildTimer;

    private float m_mechanicDustTimer;

    private int m_autoBuildIndex;

    private int m_autoBuildPhase;

    private float m_partShowTimer;

    private int m_unlockedPartIndex = -1;

    private List<ConstructionUI.PartDesc> m_unlockedParts;

    private GameObject m_unlockedPartBackground;

    private ContraptionDataset m_autoBuildData;

    private ConstructionUI.PartDesc m_autoBuildPart;

    private GameObject m_dragIcon;

    private int m_retries;

    private bool m_openTutorial;

    private bool m_openMechanicInfo;

    private bool m_openMechanicGift;

    private bool m_useBlueprint;

    private bool m_useSuperBlueprint;

    private bool m_tutorialBookOpened;

    private List<GameObject> m_dynamicObjects = new List<GameObject>();

    private List<GameObject> m_temporaryDynamicObjects = new List<GameObject>();

    private List<GameObject> m_dynamicObjectClones = new List<GameObject>();

    private Dictionary<string, string> m_UsedDessertPlaces = new Dictionary<string, string>();

    private Vector3 m_levelStart;

    private bool m_hasIceGround;

    private GameObject m_ambientSource;

    private bool fastBuilding;

    private bool m_firstTime = true;

    private GameMode m_gameMode;

    public bool m_toolboxOpenUponShopActivation;

    private static bool isConfectionerReported;

    [Serializable]
    public class CameraLimits
    {
        public Vector2 topLeft;

        public Vector2 size;
    }

    [Serializable]
    public class ScoreLimits
    {
        public int silverScore;

        public int goldScore;
    }

    [Serializable]
    public class PartCount
    {
        public BasePart.PartType type;

        public int count;
    }

    public enum GameState
    {
        Undefined,
        Building,
        Preview,
        PreviewMoving,
        PreviewWhileBuilding,
        PreviewWhileRunning,
        Running,
        Continue,
        Completed,
        PausedWhileRunning,
        PausedWhileBuilding,
        IngamePurchase,
        AutoBuilding,
        TutorialBook,
        ShowingUnlockedParts,
        Purchasing,
        Snapshot,
        MechanicInfoScreen,
        MechanicGiftScreen,
        SuperAutoBuilding,
        CustomizingPart,
        LootCrateOpening,
        CakeRaceExploding,
        CakeRaceCompleted
    }

    private struct DessertPlacePair
    {
        public GameObject dessert;

        public Transform place;
    }
}
