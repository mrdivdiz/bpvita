using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode
{
    protected GameManager gameManager
    {
        get
        {
            return Singleton<GameManager>.Instance;
        }
    }

    protected GameData gameData
    {
        get
        {
            return WPFMonoBehaviour.gameData;
        }
    }

    public Contraption ContraptionProto { get; protected set; }

    public Contraption ContraptionRunning { get; protected set; }

    public int CurrentContraptionIndex { get; set; }

    public List<int> CurrentConstructionGridRows { get; protected set; }

    public List<CameraPreview.CameraControlPoint> Preview { get; protected set; }

    public Vector3 CameraOffset { get; protected set; }

    public Vector3 PreviewOffset { get; protected set; }

    public Vector3 ConstructionOffset { get; protected set; }

    public LevelManager.CameraLimits CameraLimits { get; protected set; }

    public GameObject GridCellPrefab { get; protected set; }

    public GameObject TutorialPage { get; protected set; }

    public void Initialize(LevelManager newLevelManager)
    {
        EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
        EventManager.Connect(new EventManager.OnEvent<Pig.PigOutOfBounds>(this.OnPigOutOfBounds));
        this.levelManager = newLevelManager;
        this.levelStart = WPFMonoBehaviour.FindSceneObjectOfType<LevelStart>();
        Vector3 position = (!this.levelStart) ? Vector3.zero : this.levelStart.transform.position;
        if (this.gameData.m_contraptionPrefab)
        {
            Transform transform = UnityEngine.Object.Instantiate(this.gameData.m_contraptionPrefab, position, Quaternion.identity);
            this.ContraptionProto = transform.GetComponent<Contraption>();
        }
        if (this.gameData.m_hudPrefab)
        {
            Transform transform2 = UnityEngine.Object.Instantiate(this.gameData.m_hudPrefab, position, Quaternion.identity);
            transform2.parent = this.levelManager.transform;
        }
        if (!this.ContraptionProto)
        {
            this.ContraptionProto = WPFMonoBehaviour.FindSceneObjectOfType<Contraption>();
        }
    }

    public virtual void CleanUp()
    {
        EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.ReceiveUIEvent));
        EventManager.Disconnect(new EventManager.OnEvent<Pig.PigOutOfBounds>(this.OnPigOutOfBounds));
    }

    private void ReceiveUIEvent(UIEvent data)
    {
        if (this.HandleUIEvent(data))
        {
            return;
        }
        switch (data.type)
        {
            case UIEvent.Type.Building:
                if (this.resourceUnloadTimer > 600f)
                {
                    this.resourceUnloadTimer = 0f;
                    Resources.UnloadUnusedAssets();
                }
                if (this.levelManager.m_sandbox && this.levelManager.ConstructionUI.UnlockedParts.Count > 0)
                {
                    this.StopRunningContraption();
                    this.levelManager.SetGameState(LevelManager.GameState.ShowingUnlockedParts);
                }
                else
                {
                    this.levelManager.SetGameState(LevelManager.GameState.Building);
                }
                break;
            case UIEvent.Type.Play:
                if (!this.levelManager.ConstructionUI.IsDragging())
                {
                    this.levelManager.CheckForLevelStartAchievements();
                    LevelManager.GameState gameState = (this.levelManager.gameState != LevelManager.GameState.Building) ? LevelManager.GameState.Continue : LevelManager.GameState.Running;
                    //if (this.levelManager.gameState == LevelManager.GameState.Building)
                    //{
                        //Singleton<AudioManager>.Instance.Play2dEffect(this.gameData.commonAudioCollection.buildContraption);
                    //}
                    this.levelManager.SetGameState(gameState);
                }
                break;
            case UIEvent.Type.LevelSelection:
                this.levelManager.SetGameState(LevelManager.GameState.Undefined);
                if (Singleton<GameManager>.Instance.CurrentEpisode != string.Empty)
                {
                    Singleton<GameManager>.Instance.LoadLevelSelection(Singleton<GameManager>.Instance.CurrentEpisode, true);
                }
                else
                {
                    Singleton<GameManager>.Instance.LoadEpisodeSelection(true);
                }
                break;
            case UIEvent.Type.NextLevel:
                this.levelManager.SetGameState(LevelManager.GameState.Undefined);
                Singleton<GameManager>.Instance.LoadNextLevel();
                break;
            case UIEvent.Type.Preview:
                {
                    LevelManager.GameState gameState2 = (this.levelManager.gameState != LevelManager.GameState.Running) ? LevelManager.GameState.PreviewWhileBuilding : LevelManager.GameState.PreviewWhileRunning;
                    this.levelManager.SetGameState(gameState2);
                    break;
                }
            case UIEvent.Type.Clear:
                this.levelManager.ConstructionUI.ClearContraption();
                break;
            case UIEvent.Type.Pause:
                {
                    LevelManager.GameState gameState3 = (this.levelManager.gameState != LevelManager.GameState.Running) ? LevelManager.GameState.PausedWhileBuilding : LevelManager.GameState.PausedWhileRunning;
                    this.levelManager.SetGameState(gameState3);
                    break;
                }
            case UIEvent.Type.ReplayLevel:
                this.levelManager.SetGameState(LevelManager.GameState.Undefined);
                if (this.levelManager.m_darkLevel)
                {
                    LightManager.enabledLightPositions = new List<Vector3>();
                    PointLightSource[] array = UnityEngine.Object.FindObjectsOfType<PointLightSource>();
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i].isEnabled)
                        {
                            LightManager.enabledLightPositions.Add(array[i].transform.position);
                        }
                    }
                }
                Singleton<GameManager>.Instance.ReloadCurrentLevel(true);
                break;
            case UIEvent.Type.ActivateRockets:
                {
                    Rocket[] componentsInChildren = this.ContraptionRunning.GetComponentsInChildren<Rocket>();
                    foreach (Rocket rocket in componentsInChildren)
                    {
                        rocket.ProcessTouch();
                    }
                    break;
                }
            case UIEvent.Type.ActivateEngines:
                {
                    Engine[] componentsInChildren2 = this.ContraptionRunning.GetComponentsInChildren<Engine>();
                    if (componentsInChildren2.Length > 0)
                    {
                        componentsInChildren2[0].ProcessTouch();
                    }
                    else
                    {
                        this.ContraptionRunning.m_pig.ProcessTouch();
                    }
                    break;
                }
            case UIEvent.Type.BackFromPreview:
                {
                    LevelManager.GameState gameState4 = (this.levelManager.gameState != LevelManager.GameState.PreviewWhileRunning) ? LevelManager.GameState.Building : LevelManager.GameState.Continue;
                    this.levelManager.SetGameState(gameState4);
                    break;
                }
            case UIEvent.Type.ContinueFromPause:
                {
                    LevelManager.GameState gameState5 = (this.levelManager.gameState != LevelManager.GameState.PausedWhileRunning) ? LevelManager.GameState.Building : LevelManager.GameState.Continue;
                    this.levelManager.SetGameState(gameState5);
                    break;
                }
            case UIEvent.Type.ReplayFlight:
                this.StopRunningContraption();
                this.levelManager.SetGameState(LevelManager.GameState.Running);
                break;
            case UIEvent.Type.QuestModeBuild:
                this.levelManager.PlaceBuildArea();
                this.levelManager.SetGameState(LevelManager.GameState.Building);
                break;
            case UIEvent.Type.OpenTutorial:
                this.levelManager.StateBeforeTutorial = this.levelManager.gameState;
                this.levelManager.SetGameState(LevelManager.GameState.TutorialBook);
                Singleton<AudioManager>.Instance.Play2dEffect(this.gameData.commonAudioCollection.tutorialIn);
                GameProgress.IncreaseTutorialBookOpenCount();
                this.tutorialBookOpened = true;
                break;
            case UIEvent.Type.CloseTutorial:
                Singleton<AudioManager>.Instance.Play2dEffect(this.gameData.commonAudioCollection.tutorialOut);
                if (this.levelManager.HasCompleted)
                {
                    this.levelManager.SetGameState(LevelManager.GameState.Completed);
                    this.levelManager.InGameGUI.LevelCompleteMenu.ResumeAnimations();
                }
                else
                {
                    this.levelManager.SetGameState(this.levelManager.StateBeforeTutorial);
                }
                break;
            case UIEvent.Type.Snapshot:
                this.levelManager.SetGameState(LevelManager.GameState.Snapshot);
                break;
            case UIEvent.Type.EpisodeSelection:
                Singleton<GameManager>.Instance.LoadEpisodeSelection(true);
                break;
            case UIEvent.Type.ApplySuperGlue:
                if (this.levelManager.m_SuperGlueAllowed)
                {
                    int num = GameProgress.SuperGlueCount();
                    if (num > 0 || this.ContraptionProto.HasRegularGlue)
                    {
                        num += ((!this.ContraptionProto.HasRegularGlue) ? -1 : 1);
                        GameProgress.SetSuperGlueCount(num);
                        GameProgress.Save();
                        if (this.ContraptionProto.HasRegularGlue)
                        {
                            this.ContraptionProto.RemoveSuperGlue();
                            if (this.ContraptionProto.HasPart(BasePart.PartType.Egg, BasePart.PartTier.Legendary))
                            {
                                this.ContraptionProto.ApplySuperGlue(Glue.Type.Alien);
                            }
                        }
                        else
                        {
                            this.ContraptionProto.ApplySuperGlue(Glue.Type.Regular);
                        }
                        EventManager.Send(new InGameBuildMenu.ApplySuperGlueEvent(num, this.ContraptionProto.HasRegularGlue));
                    }
                    else
                    {
                        this.levelManager.ShowPurchaseDialog(IapManager.InAppPurchaseItemType.SuperGlueSingle);
                    }
                }
                break;
            case UIEvent.Type.ApplySuperMagnet:
                if (this.levelManager.m_SuperMagnetAllowed)
                {
                    int num2 = GameProgress.SuperMagnetCount();
                    if (num2 > 0 || this.ContraptionProto.HasSuperMagnet)
                    {
                        num2 += ((!this.ContraptionProto.HasSuperMagnet) ? -1 : 1);
                        GameProgress.SetSuperMagnetCount(num2);
                        GameProgress.Save();
                        this.ContraptionProto.HasSuperMagnet = !this.ContraptionProto.HasSuperMagnet;
                        EventManager.Send(new InGameBuildMenu.ApplySuperMagnetEvent(num2, this.ContraptionProto.HasSuperMagnet));
                    }
                    else
                    {
                        this.levelManager.ShowPurchaseDialog(IapManager.InAppPurchaseItemType.SuperMagnetSingle);
                    }
                }
                break;
            case UIEvent.Type.ApplyTurboCharge:
                if (this.levelManager.m_TurboChargeAllowed)
                {
                    int num3 = GameProgress.TurboChargeCount();
                    if (num3 > 0 || this.ContraptionProto.HasTurboCharge)
                    {
                        num3 += ((!this.ContraptionProto.HasTurboCharge) ? -1 : 1);
                        GameProgress.SetTurboChargeCount(num3);
                        GameProgress.Save();
                        this.ContraptionProto.HasTurboCharge = !this.ContraptionProto.HasTurboCharge;
                        EventManager.Send(new InGameBuildMenu.ApplyTurboChargeEvent(num3, this.ContraptionProto.HasTurboCharge));
                    }
                    else
                    {
                        this.levelManager.ShowPurchaseDialog(IapManager.InAppPurchaseItemType.TurboChargeSingle);
                    }
                }
                break;
            case UIEvent.Type.LoadContraptionSlot1:
                this.LoadContraptionFromSlot(0);
                break;
            case UIEvent.Type.LoadContraptionSlot2:
                this.LoadContraptionFromSlot(1);
                break;
            case UIEvent.Type.LoadContraptionSlot3:
                this.LoadContraptionFromSlot(2);
                break;
            case UIEvent.Type.ApplyNightVision:
                if (this.levelManager.m_darkLevel && this.levelManager.LightManager != null)
                {
                    int num4 = GameProgress.NightVisionCount();
                    if (num4 > 0 || this.ContraptionProto.HasNightVision)
                    {
                        num4 += ((!this.ContraptionProto.HasNightVision) ? -1 : 1);
                        GameProgress.SetNightVisionCount(num4);
                        GameProgress.Save();
                        this.ContraptionProto.HasNightVision = !this.ContraptionProto.HasNightVision;
                        EventManager.Send(new InGameBuildMenu.ApplyNightVisionEvent(num4, this.ContraptionProto.HasNightVision));
                    }
                    else if (this.ContraptionProto.HasNightVision)
                    {
                        this.levelManager.ConstructionUI.ApplyNightVision(false);
                        num4++;
                        GameProgress.SetNightVisionCount(num4);
                        GameProgress.Save();
                        EventManager.Send(new InGameBuildMenu.ApplyNightVisionEvent(num4, this.ContraptionProto.HasNightVision));
                    }
                    else
                    {
                        this.levelManager.ShowPurchaseDialog(IapManager.InAppPurchaseItemType.NightVisionSingle);
                    }
                }
                break;
        }
    }

    public virtual void Update()
    {
        this.resourceUnloadTimer += Time.deltaTime;
    }

    public virtual void NotifyGoalReachedByPart(BasePart.PartType partType)
    {
        if (!this.levelManager.PartsInGoal.Contains(partType))
        {
            this.levelManager.PartsInGoal.Add(partType);
            if (partType == BasePart.PartType.Pig)
            {
                if (this.levelManager.EggRequired && !this.levelManager.PartsInGoal.Contains(BasePart.PartType.Egg))
                {
                    this.ContraptionRunning.SetCameraTarget(this.ContraptionRunning.FindPart(BasePart.PartType.Egg));
                }
                if (this.levelManager.PumpkinRequired && !this.levelManager.PartsInGoal.Contains(BasePart.PartType.Pumpkin))
                {
                    this.ContraptionRunning.SetCameraTarget(this.ContraptionRunning.FindPart(BasePart.PartType.Pumpkin));
                }
            }
        }
    }

    public virtual bool PlayerHasRequiredObjects()
    {
        if (this.levelManager.EggRequired)
        {
            return this.levelManager.PartsInGoal.Contains(BasePart.PartType.Pig) && this.levelManager.PartsInGoal.Contains(BasePart.PartType.Egg);
        }
        if (this.levelManager.PumpkinRequired)
        {
            return this.levelManager.PartsInGoal.Contains(BasePart.PartType.Pig) && this.levelManager.PartsInGoal.Contains(BasePart.PartType.Pumpkin);
        }
        return this.levelManager.PartsInGoal.Contains(BasePart.PartType.Pig);
    }

    public virtual void NotifyGoalReached()
    {
        this.levelManager.CompletionTime = this.levelManager.TimeElapsed;
        this.levelManager.HasCompleted = true;
        this.levelManager.SetGameState(LevelManager.GameState.Completed);
    }

    protected virtual void OnPigOutOfBounds(Pig.PigOutOfBounds data)
    {
        this.levelManager.SetGameState(LevelManager.GameState.Building);
    }

    protected void LoadContraptionFromSlot(int slotIndex)
    {
        if (this.ContraptionProto)
        {
            if (this.ContraptionProto.HasTurboCharge)
            {
                GameProgress.AddTurboCharge(1);
                EventManager.Send(new InGameBuildMenu.ApplyTurboChargeEvent(GameProgress.TurboChargeCount(), false));
            }
            if (this.ContraptionProto.HasNightVision)
            {
                GameProgress.AddNightVision(1);
                EventManager.Send(new InGameBuildMenu.ApplyNightVisionEvent(GameProgress.NightVisionCount(), false));
            }
            if (this.ContraptionProto.HasSuperGlue)
            {
                GameProgress.AddSuperGlue(1);
                EventManager.Send(new InGameBuildMenu.ApplySuperGlueEvent(GameProgress.SuperGlueCount(), false));
            }
            if (this.ContraptionProto.HasSuperMagnet)
            {
                GameProgress.AddSuperMagnet(1);
                EventManager.Send(new InGameBuildMenu.ApplySuperMagnetEvent(GameProgress.SuperMagnetCount(), false));
            }
            foreach (BasePart basePart in this.ContraptionProto.Parts)
            {
                this.ContraptionProto.DataSet.AddPart(basePart.m_coordX, basePart.m_coordY, (int)basePart.m_partType, basePart.customPartIndex, basePart.m_gridRotation, basePart.m_flipped);
            }
            this.ContraptionProto.SaveContraption(this.GetCurrentContraptionName());
            this.levelManager.ConstructionUI.ClearContraption();
            this.Destroy(this.ContraptionProto.gameObject);
            this.ContraptionProto = null;
        }
        this.CurrentContraptionIndex = slotIndex;
        Vector3 position = (!this.levelStart) ? Vector3.zero : this.levelStart.transform.position;
        if (this.gameData.m_contraptionPrefab)
        {
            Transform transform = UnityEngine.Object.Instantiate(this.gameData.m_contraptionPrefab, position, Quaternion.identity);
            this.ContraptionProto = transform.GetComponent<Contraption>();
        }
        this.levelManager.ConstructionUI.SetCurrentContraption();
        this.BuildContraption(WPFPrefs.LoadContraptionDataset(this.GetCurrentContraptionName()));
        foreach (ConstructionUI.PartDesc partDesc in this.levelManager.ConstructionUI.PartDescriptors)
        {
            EventManager.Send(new PartCountChanged(partDesc.part.m_partType, partDesc.CurrentCount));
        }
        this.levelManager.ConstructionUI.SetMoveButtonStates();
        this.levelManager.SetGameState(LevelManager.GameState.Building);
    }

    protected void StopRunningContraption()
    {
        if (this.ContraptionRunning)
        {
            this.ContraptionRunning.StopContraption();
            this.Destroy(this.ContraptionRunning.gameObject);
            this.ContraptionRunning = null;
        }
        List<GameObject> list = new List<GameObject>(GameObject.FindGameObjectsWithTag("ParticleEmitter"));
        foreach (GameObject go in list)
        {
            this.Destroy(go);
        }
    }

    public string GetContraptionNameAtSlot(int slotIndex)
    {
        string result;
        if (this.levelManager.m_sandbox && this.CurrentContraptionIndex > 0)
        {
            result = string.Format("{0}_{1}", Singleton<GameManager>.Instance.CurrentSceneName, this.CurrentContraptionIndex);
        }
        else if (this is CakeRaceMode)
        {
            int currentTrackIndex = (this as CakeRaceMode).CurrentTrackIndex;
            result = string.Format("cr_{0}_{1}", Singleton<GameManager>.Instance.CurrentSceneName, currentTrackIndex);
        }
        else
        {
            result = Singleton<GameManager>.Instance.CurrentSceneName;
        }
        return result;
    }

    public string GetCurrentContraptionName()
    {
        return this.GetContraptionNameAtSlot(this.CurrentContraptionIndex);
    }

    public void BuildContraption(ContraptionDataset cds)
    {
        if (cds == null || cds.ContraptionDatasetList == null)
        {
            return;
        }
        foreach (ContraptionDataset.ContraptionDatasetUnit contraptionDatasetUnit in cds.ContraptionDatasetList)
        {
            ConstructionUI.PartDesc partDesc = this.levelManager.ConstructionUI.FindPartDesc((BasePart.PartType)contraptionDatasetUnit.partType);
            if (partDesc != null)
            {
                BasePart customPart = this.gameData.GetCustomPart(partDesc.part.m_partType, contraptionDatasetUnit.customPartIndex);
                if (customPart != null)
                {
                    this.levelManager.BuildPart(contraptionDatasetUnit, customPart);
                    partDesc.useCount++;
                }
            }
        }
    }

    private void PreBuildContraption(ContraptionDataset cds)
    {
        foreach (ContraptionDataset.ContraptionDatasetUnit contraptionDatasetUnit in cds.ContraptionDatasetList)
        {
            GameObject part = this.gameData.GetPart((BasePart.PartType)contraptionDatasetUnit.partType);
            if (part)
            {
                BasePart component = part.GetComponent<BasePart>();
                BasePart basePart = this.levelManager.BuildPart(contraptionDatasetUnit, component);
                basePart.m_static = true;
                this.ContraptionProto.IncreaseStaticPartCount();
            }
        }
    }

    protected void Destroy(GameObject go)
    {
        UnityEngine.Object.Destroy(go);
    }

    public abstract void OnDataLoadedStart();

    public abstract void InitGameMode();

    public abstract void OnDataLoadedDone();

    public abstract LevelManager.GameState SetGameState(LevelManager.GameState currentState, LevelManager.GameState newState);

    protected abstract bool HandleUIEvent(UIEvent data);

    public abstract int GetPartCount(BasePart.PartType type);

    protected LevelManager levelManager;

    protected float resourceUnloadTimer;

    protected bool tutorialBookOpened;

    protected LevelStart levelStart;
}
