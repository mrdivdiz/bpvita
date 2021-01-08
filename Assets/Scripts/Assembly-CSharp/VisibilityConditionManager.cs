using System;
using UnityEngine.SceneManagement;

public class VisibilityConditionManager : Singleton<VisibilityConditionManager>
{
	private void Awake()
	{
		base.SetAsPersistant();
		this.conditionCount = Enum.GetNames(typeof(VisibilityCondition.Condition)).Length;
		this.previousConditions = new bool[this.conditionCount];
		this.InitializeConditions();
		this.InitializeEvents();
		SceneManager.sceneLoaded += this.OnSceneLoaded;
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= this.OnSceneLoaded;
	}

	private void Update()
	{
		for (int i = 1; i < this.conditionCount; i++)
		{
			if (this.events[i] != null)
			{
				if (this.previousConditions[i] != this.check[i]())
				{
					this.previousConditions[i] = !this.previousConditions[i];
					this.events[i]((VisibilityCondition.Condition)i, this.previousConditions[i]);
				}
			}
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if (this.m_levelManager == null)
		{
			this.m_levelManager = UnityEngine.Object.FindObjectOfType<LevelManager>();
		}
		this.InitializeConditions();
	}

	public void SubscribeToConditionChange(ConditionChange onChange, VisibilityCondition.Condition condition)
	{
		if (condition == VisibilityCondition.Condition.None)
		{
			throw new ArgumentException(string.Format("Invalid Condition '{0}'", condition));
		}
		if (this.m_levelManager == null)
		{
			this.m_levelManager = UnityEngine.Object.FindObjectOfType<LevelManager>();
		}
		this.InitializeConditions();
        ConditionChange[] array = this.events;
		array[(int)condition] = (ConditionChange)Delegate.Combine(array[(int)condition], onChange);
		this.previousConditions[(int)condition] = this.check[(int)condition]();
		onChange(condition, this.previousConditions[(int)condition]);
	}

	public void UnsubscribeToConditionChange(ConditionChange onChange, VisibilityCondition.Condition condition)
	{
        ConditionChange[] array = this.events;
		array[(int)condition] = (ConditionChange)Delegate.Remove(array[(int)condition], onChange);
	}

	private void InitializeConditions()
	{
		this.check = new ConditionCheck[this.conditionCount];
		string autoBuild = Singleton<GameManager>.Instance.CurrentSceneName + "_autobuild_available";
		bool gameCenterAvailable = DeviceInfo.ActiveDeviceFamily == DeviceInfo.DeviceFamily.Ios;
		bool chiefPigExploded = GameProgress.GetBool("ChiefPigExploded", false, GameProgress.Location.Local, null);
		bool iapEnabled = Singleton<BuildCustomizationLoader>.Instance.IAPEnabled;
		bool isCheat = Singleton<BuildCustomizationLoader>.Instance.CheatsEnabled;
		bool isDebug = Singleton<BuildCustomizationLoader>.Instance.IsDevelopmentBuild;
		bool lessCheats = Singleton<BuildCustomizationLoader>.Instance.LessCheats;
		bool boughtFoD = GameProgress.GetSandboxUnlocked("S-F");
		this.check[0] = (() => false);
		this.check[1] = (() => this.m_levelManager != null && this.m_levelManager.ContraptionProto != null && this.m_levelManager.ContraptionProto.ValidateContraption() && this.m_levelManager.gameState != LevelManager.GameState.AutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.SuperAutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.ShowingUnlockedParts);
		this.check[2] = (() => this.m_levelManager != null && this.m_levelManager.ContraptionRunning != null && this.m_levelManager.ContraptionRunning.HasEngine && this.m_levelManager.ContraptionRunning.EnginePoweredPartTypeCount() > 1);
		this.check[3] = (() => true);
		this.check[4] = (() => this.m_levelManager != null && this.m_levelManager.gameState == LevelManager.GameState.PausedWhileRunning);
		this.check[5] = (() => this.m_levelManager != null && this.m_levelManager.ContraptionProto.DynamicPartCount() > 0);
		this.check[6] = (() => false);
		this.check[7] = (() => true);
		this.check[8] = (() => this.m_levelManager.gameState == LevelManager.GameState.PausedWhileRunning);
		this.check[9] = (() => true);
		this.check[10] = (() => true);
		this.check[11] = (() => true);
		this.check[12] = (() => true);
		this.check[13] = (() => false);
		this.check[14] = (() => this.m_levelManager != null && this.m_levelManager.m_autoBuildUnlocked && iapEnabled && this.m_levelManager.gameState != LevelManager.GameState.AutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.SuperAutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.ShowingUnlockedParts && !GameProgress.GetBool(autoBuild, false, GameProgress.Location.Local, null) && GameProgress.GetBool("PermanentBlueprint", false, GameProgress.Location.Local, null));
		this.check[15] = (() => this.m_levelManager != null && this.m_levelManager.TutorialBookPage != null && this.m_levelManager.gameState != LevelManager.GameState.AutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.SuperAutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.ShowingUnlockedParts);
		this.check[16] = (() => (this.m_levelManager != null && this.m_levelManager.gameState == LevelManager.GameState.AutoBuilding) || this.m_levelManager.gameState == LevelManager.GameState.SuperAutoBuilding);
		this.check[17] = (() => this.m_levelManager != null && this.m_levelManager.ContraptionProto != null && this.m_levelManager.ContraptionProto.DynamicPartCount() > 0 && this.m_levelManager.gameState != LevelManager.GameState.AutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.SuperAutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.ShowingUnlockedParts);
		this.check[18] = (() => this.m_levelManager != null && this.m_levelManager.gameState != LevelManager.GameState.AutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.SuperAutoBuilding);
		this.check[19] = (() => this.m_levelManager != null && this.m_levelManager.gameState != LevelManager.GameState.AutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.SuperAutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.ShowingUnlockedParts);
		this.check[20] = (() => iapEnabled);
		this.check[21] = (() => chiefPigExploded);
		this.check[22] = (() => this.m_levelManager != null && GameProgress.GetBool(autoBuild, false, GameProgress.Location.Local, null) && this.m_levelManager.gameState != LevelManager.GameState.AutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.SuperAutoBuilding);
		this.check[23] = (() => this.m_levelManager != null && this.m_levelManager.m_sandbox);
		this.check[24] = (() => this.m_levelManager != null && this.m_levelManager.m_sandbox && this.m_levelManager.gameState != LevelManager.GameState.AutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.SuperAutoBuilding && this.m_levelManager.gameState != LevelManager.GameState.ShowingUnlockedParts);
		this.check[28] = (() => gameCenterAvailable);
		this.check[29] = (() => Singleton<BuildCustomizationLoader>.Instance.IsContentLimited);
		this.check[30] = (() => Singleton<BuildCustomizationLoader>.Instance.IsHDVersion);
		this.check[31] = (() => Singleton<BuildCustomizationLoader>.Instance.IsOdyssey);
		this.check[32] = (() => DeviceInfo.ActiveDeviceFamily == DeviceInfo.DeviceFamily.Ios);
		this.check[33] = (() => isCheat);
		this.check[34] = (() => isDebug);
		this.check[35] = (() => FreeLootCrate.FreeShopLootCrateCollected);
		this.check[36] = CustomizationManager.HasNewParts;
		this.check[37] = (() => lessCheats);
		this.check[38] = (() => Singleton<NetworkManager>.IsInstantiated() && Singleton<NetworkManager>.Instance.HasNetworkAccess);
		this.check[39] = (() => boughtFoD);
		this.check[40] = (() => Singleton<DailyChallenge>.Instance.HasChallenge && Singleton<DailyChallenge>.Instance.Left == 0);
		this.check[41] = (() => this.m_levelManager != null && this.m_levelManager.CurrentGameMode is CakeRaceMode);
		this.check[42] = (() => Singleton<TimeManager>.IsInstantiated() && Singleton<TimeManager>.Instance.CurrentTime.Month == 12);
	}

	private void InitializeEvents()
	{
		this.events = new ConditionChange[this.conditionCount];
		for (int i = 1; i < this.conditionCount; i++)
		{
			this.events[i] = null;
		}
	}

	public bool GetState(VisibilityCondition.Condition condition)
	{
		return this.check[(int)condition]();
	}

	private LevelManager m_levelManager;

	private int conditionCount;

	private bool[] previousConditions;

	private ConditionCheck[] check;

	private ConditionChange[] events;

	private delegate bool ConditionCheck();

	public delegate void ConditionChange(VisibilityCondition.Condition condition, bool state);
}
