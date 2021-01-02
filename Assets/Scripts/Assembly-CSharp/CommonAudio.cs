using System.Collections.Generic;
using UnityEngine;

public class CommonAudio : ScriptableObject
{
	public GameObject MusicTheme
	{
		get
		{
			return this.bundleMusicTheme.LoadValue<GameObject>();
		}
	}

	public GameObject LevelSelectionMusic
	{
		get
		{
			return this.bundleLevelSelectionMusic.LoadValue<GameObject>();
		}
	}

	public GameObject InFlightMusic
	{
		get
		{
			return this.bundleInFlightMusic.LoadValue<GameObject>();
		}
	}

	public GameObject BuildMusic
	{
		get
		{
			return this.bundleBuildMusic.LoadValue<GameObject>();
		}
	}

	public GameObject FeedingMusic
	{
		get
		{
			return this.bundleFeedingMusic.LoadValue<GameObject>();
		}
	}

	public GameObject AmbientJungle
	{
		get
		{
			return this.bundleAmbientJungle.LoadValue<GameObject>();
		}
	}

	public GameObject AmbientPlateau
	{
		get
		{
			return this.bundleAmbientPlateau.LoadValue<GameObject>();
		}
	}

	public GameObject AmbientCave
	{
		get
		{
			return this.bundleAmbientCave.LoadValue<GameObject>();
		}
	}

	public GameObject AmbientNight
	{
		get
		{
			return this.bundleAmbientNight.LoadValue<GameObject>();
		}
	}

	public GameObject AmbientMorning
	{
		get
		{
			return this.bundleAmbientMorning.LoadValue<GameObject>();
		}
	}

	public GameObject AmbientHalloween
	{
		get
		{
			return this.bundleAmbientHalloween.LoadValue<GameObject>();
		}
	}

	public GameObject AmbientMaya
	{
		get
		{
			return this.bundleAmbientMaya.LoadValue<GameObject>();
		}
	}

	public GameObject CakeRaceTheme
	{
		get
		{
			return this.bundleCakeRaceTheme.LoadValue<GameObject>();
		}
	}

	public GameObject XmasThemeSong
	{
		get
		{
			return this.bundleXmasThemeSong.LoadValue<GameObject>();
		}
	}

	public void Initialize()
	{
		this.menuClick = this.GetAudioSource(this.bundleMenuClick);
		this.gadgetButtonClick = this.GetAudioSource(this.bundleGadgetButtonClick);
		this.menuHover = this.GetAudioSource(this.bundleMenuHover);
		this.goalBoxCollected = this.GetAudioSource(this.bundleGoalBoxCollected);
		this.bonusBoxCollected = this.GetAudioSource(this.bundleBonusBoxCollected);
		this.dessertCollected = this.GetAudioSource(this.bundleDessertCollected);
		this.placePart = this.GetAudioSource(this.bundlePlacePart);
		this.rotatePart = this.GetAudioSource(this.bundleRotatePart);
		this.dragPart = this.GetAudioSource(this.bundleDragPart);
		this.removePart = this.GetAudioSource(this.bundleRemovePart);
		this.clearBuildGrid = this.GetAudioSource(this.bundleClearBuildGrid);
		this.buildContraption = this.GetAudioSource(this.bundleBuildContraption);
		this.victory = this.GetAudioSource(this.bundleVictory);
		this.starEffects = this.GetAudioSource(this.bundleStarEffects);
		this.starLoops = this.GetAudioSource(this.bundleStarLoops);
		this.balloonPop = this.GetAudioSource(this.bundleBalloonPop);
		this.fan = this.GetAudioSource(this.bundleFan);
		this.propeller = this.GetAudioSource(this.bundlePropeller);
		this.motorWheelLoop = this.GetAudioSource(this.bundleMotorWheelLoop);
		this.normalWheelLoop = this.GetAudioSource(this.bundleNormalWheelLoop);
		this.smallWheelLoop = this.GetAudioSource(this.bundleSmallWheelLoop);
		this.woodenWheelLoop = this.GetAudioSource(this.bundleWoodenWheelLoop);
		this.stickyWheelLoop = this.GetAudioSource(this.bundleStickyWheelLoop);
		this.rotorLoop = this.GetAudioSource(this.bundleRotorLoop);
		this.bellowsPuff = this.GetAudioSource(this.bundleBellowsPuff);
		this.electricEngine = this.GetAudioSource(this.bundleElectricEngine);
		this.engine = this.GetAudioSource(this.bundleEngine);
		this.V8Engine = this.GetAudioSource(this.bundleV8Engine);
		this.bottleCork = this.GetAudioSource(this.bundleBottleCork);
		this.umbrellaOpen = this.GetAudioSource(this.bundleUmbrellaOpen);
		this.umbrellaClose = this.GetAudioSource(this.bundleUmbrellaClose);
		this.tntExplosion = this.GetAudioSource(this.bundleTntExplosion);
		this.sandbagCollision = this.GetAudioSource(this.bundleSandbagCollision);
		this.springBoxingGloveShoot = this.GetAudioSource(this.bundleSpringBoxingGloveShoot);
		this.springBoxingGloveWinding = this.GetAudioSource(this.bundleSpringBoxingGloveWinding);
		this.grapplingHookAttach = this.GetAudioSource(this.bundleGrapplingHookAttach);
		this.grapplingHookDetach = this.GetAudioSource(this.bundleGrapplingHookDetach);
		this.grapplingHookLaunch = this.GetAudioSource(this.bundleGrapplingHookLaunch);
		this.grapplingHookMiss = this.GetAudioSource(this.bundleGrapplingHookMiss);
		this.grapplingHookReeling = this.GetAudioSource(this.bundleGrapplingHookReeling);
		this.grapplingHookReset = this.GetAudioSource(this.bundleGrapplingHookReset);
		this.kickerDetach = this.GetAudioSource(this.bundleKickerDetach);
		this.SuperGlueApplied = this.GetAudioSource(this.bundleSuperGlueApplied);
		this.SuperMagnetApplied = this.GetAudioSource(this.bundleSuperMagnetApplied);
		this.TurboChargeApplied = this.GetAudioSource(this.bundleTurboChargeApplied);
		this.collisionMetalHit = this.GetAudioSource(this.bundleCollisionMetalHit);
		this.collisionMetalDamage = this.GetAudioSource(this.bundleCollisionMetalDamage);
		this.collisionMetalBreak = this.GetAudioSource(this.bundleCollisionMetalBreak);
		this.collisionWoodHit = this.GetAudioSource(this.bundleCollisionWoodHit);
		this.collisionWoodDamage = this.GetAudioSource(this.bundleCollisionWoodDamage);
		this.collisionWoodDestroy = this.GetAudioSource(this.bundleCollisionWoodDestroy);
		this.tutorialIn = this.GetAudioSource(this.bundleTutorialIn);
		this.tutorialOut = this.GetAudioSource(this.bundleTutorialOut);
		this.tutorialFlip = this.GetAudioSource(this.bundleTutorialFlip);
		this.cameraZoomIn = this.GetAudioSource(this.bundleCameraZoomIn);
		this.cameraZoomOut = this.GetAudioSource(this.bundleCameraZoomOut);
		this.jokerLevelUnlocked = this.GetAudioSource(this.bundleJokerLevelUnlocked);
		this.sandboxLevelUnlocked = this.GetAudioSource(this.bundleSandboxLevelUnlocked);
		this.birdWakeUp = this.GetAudioSource(this.bundleBirdWakeUp);
		this.birdShot = this.GetAudioSource(this.bundleBirdShot);
		this.slingshotStretched = this.GetAudioSource(this.bundleSlingshotStretched);
		this.partSlideOnIceLoop = this.GetAudioSource(this.bundlePartSlideOnIceLoop);
		this.motorWheelOnIceStart = this.GetAudioSource(this.bundleMotorWheelOnIceStart);
		this.motorWheelOnIceLoop = this.GetAudioSource(this.bundleMotorWheelOnIceLoop);
		this.gearboxSwitch = this.GetAudioSource(this.bundleGearboxSwitch);
		this.environmentFanStart = this.GetAudioSource(this.bundleEnvironmentFanStart);
		this.environmentFanLoop = this.GetAudioSource(this.bundleEnvironmentFanLoop);
		this.toggleNightVision = this.GetAudioSource(this.bundleToggleNightVision);
		this.toggleLamp = this.GetAudioSource(this.bundleToggleLamp);
		this.ancientPigDisappear = this.GetAudioSource(this.bundleAncientPigDisappear);
		this.goldenPigHit = this.GetAudioSource(this.bundleGoldenPigHit);
		this.goldenPigRoll = this.GetAudioSource(this.bundleGoldenPigRoll);
		this.secretStatueFound = this.GetAudioSource(this.bundleSecretStatueFound);
		this.pigFall = this.GetAudioSource(this.bundlePigFall);
		this.bridgeBreak = this.GetAudioSource(this.bundleBridgeBreak);
		this.pressureButtonClick = this.GetAudioSource(this.bundlePressureButtonClick);
		this.pressureButtonRelease = this.GetAudioSource(this.bundlePressureButtonRelease);
		this.collisionRockBreak = this.GetAudioSource(this.bundleCollisionRockBreak);
		this.snoutCoinHit = this.GetAudioSource(this.bundleSnoutCoinHit);
		this.snoutCoinFly = this.GetAudioSource(this.bundleSnoutCoinFly);
		this.snoutCoinPurchase = this.GetAudioSource(this.bundleSnoutCoinPurchase);
		this.snoutCoinIntro = this.GetAudioSource(this.bundleSnoutCoinIntro);
		this.snoutCoinUse = this.GetAudioSource(this.bundleSnoutCoinUse);
		this.snoutCoinUnlock = this.GetAudioSource(this.bundleSnoutCoinUnlock);
		this.inactiveButton = this.GetAudioSource(this.bundleInactiveButton);
		this.toggleEpisode = this.GetAudioSource(this.bundleToggleEpisode);
		this.snoutCoinCounterLoop = this.GetAudioSource(this.bundleSnoutCoinCounterLoop);
		this.craftAmbience = this.GetAudioSource(this.bundleCraftAmbience);
		this.craftEmpty = this.GetAudioSource(this.bundleCraftEmpty);
		this.craftLeverCrank = this.GetAudioSource(this.bundleCraftLeverCrank);
		this.machineIdles = this.GetAudioSource(this.bundleMachineIdles);
		this.machineIntro = this.GetAudioSource(this.bundleMachineIntro);
		this.craftPart = this.GetAudioSource(this.bundleCraftPart);
		this.ejectScrap = this.GetAudioSource(this.bundleEjectScrap);
		this.ejectScrapButton = this.GetAudioSource(this.bundleEjectScrapButton);
		this.insertScrap = this.GetAudioSource(this.bundleInsertScrap);
		this.lightBulb = this.GetAudioSource(this.bundleLightBulb);
		this.pullChain = this.GetAudioSource(this.bundlePullChain);
		this.releaseChain = this.GetAudioSource(this.bundleReleaseChain);
		this.goldenCrateHits = this.GetAudioSource(this.bundleGoldenCrateHits);
		this.metalCrateHits = this.GetAudioSource(this.bundleMetalCrateHits);
		this.woodenCrateHits = this.GetAudioSource(this.bundleWoodenCrateHits);
		this.salvagePart = this.GetAudioSource(this.bundleSalvagePart);
		this.bellowsFarts = this.GetAudioSource(this.bundleBellowsFarts);
		this.alienEngineLoop = this.GetAudioSource(this.bundleAlienEngineLoop);
		this.giftTNTExplosion = this.GetAudioSource(this.bundleGiftTNTExplosion);
		this.cratePillowHit = this.GetAudioSource(this.bundleCratePillowHit);
		this.pillowDrops = this.GetAudioSource(this.bundlePillowDrops);
		this.nutFly = this.GetAudioSource(this.bundleNutFly);
		this.nutHit = this.GetAudioSource(this.bundleNutHit);
		this.lootcrateEpicWow = this.GetAudioSource(this.bundleLootcrateEpicWow);
		this.partCraftedJingle = this.GetAudioSource(this.bundlePartCraftedJingle);
		this.rewardBounce = this.GetAudioSource(this.bundleRewardBounce);
		this.lootWheelTickSounds = this.GetAudioSource(this.bundleLootWheelTickSounds);
		this.lootWheelJackPot = this.GetAudioSource(this.bundleLootWheelJackPot);
		this.lootWheelPrizeFly = this.GetAudioSource(this.bundleLootWheelPrizeFly);
		this.lootWheelStarExplosion = this.GetAudioSource(this.bundleLootWheelStarExplosion);
		this.confetti = this.GetAudioSource(this.bundleConfetti);
		this.refereePigFall = this.GetAudioSource(this.bundleRefereePigFall);
		this.refereePigFallImpact = this.GetAudioSource(this.bundleRefereePigFallImpact);
		this.refereePigFlag = this.GetAudioSource(this.bundleRefereePigFlag);
		this.refereePigImpact = this.GetAudioSource(this.bundleRefereePigImpact);
		this.refereePigWhistle = this.GetAudioSource(this.bundleRefereePigWhistle);
		this.safeDrop = this.GetAudioSource(this.bundleSafeDrop);
		this.scoreCountDown = this.GetAudioSource(this.bundleScoreCountDown);
		this.scoreCountUp = this.GetAudioSource(this.bundleScoreCountUp);
		this.winTrumpet = this.GetAudioSource(this.bundleWinTrumpet);
		this.youWinPillowAppear = this.GetAudioSource(this.bundleYouWinPillowAppear);
		this.xpGain = this.GetAudioSource(this.bundleXPGain);
		this.ghostBalloonPop = this.GetAudioSource(this.bundleGhostBalloonPop);
		this.ghostBalloonWail = this.GetAudioSource(this.bundleGhostBalloonWail);
		this.marbleCrateHits = this.GetAudioSource(this.bundleMarbleCrateHits);
		this.glassCrateHits = this.GetAudioSource(this.bundleGlassCrateHits);
		this.timeBombAlarm = this.GetAudioSource(this.bundleTimeBombAlarm);
		this.alienLaserFire = this.GetAudioSource(this.bundleAlienLaserFire);
		this.alienFan = this.GetAudioSource(this.bundleAlienFan);
		this.alienRotor = this.GetAudioSource(this.bundleAlienRotor);
		this.jingleBell = this.GetAudioSource(this.bundleJingleBell);
		this.alienSodaBottleStart = this.GetAudioSource(this.bundleAlienSodaBottleStart);
		this.alienSodaBottleLoop = this.GetAudioSource(this.bundleAlienSodaBottleLoop);
		this.alienBeepBoop = this.GetAudioSource(this.bundleAlienBeepBoop);
		this.alienLanguage = this.GetAudioSource(this.bundleAlienLanguage);
		this.alienMachineReveal = this.GetAudioSource(this.bundleAlienMachineReveal);
		this.craftingSlime = this.GetAudioSource(this.bundleCraftingSlime);
		this.alienBellows = this.GetAudioSource(this.bundleAlienBellows);
		this.alienPunch = this.GetAudioSource(this.bundleAlienPunch);
		this.scoreAnticipation = this.GetAudioSource(this.bundleScoreAnticipation);
		this.scoreImpact = this.GetAudioSource(this.bundleScoreImpact);
		Bundle.UnloadAssetBundle(this.bundleEnvironmentFanLoop.AssetBundle, false);
	}

	private AudioSource GetAudioSource(BundleDataObject bundleDataObject)
	{
		GameObject gameObject = bundleDataObject.LoadValue<GameObject>();
		if (gameObject != null)
		{
			AudioSource component = gameObject.GetComponent<AudioSource>();
			this.AddLoadedBundle(bundleDataObject, component);
			return component;
		}
		return null;
	}

	private AudioSource[] GetAudioSource(BundleDataObject[] bundleDataObject)
	{
		List<AudioSource> list = new List<AudioSource>();
		for (int i = 0; i < bundleDataObject.Length; i++)
		{
			AudioSource audioSource = this.GetAudioSource(bundleDataObject[i]);
			if (audioSource != null)
			{
				this.AddLoadedBundle(bundleDataObject[i], audioSource);
				list.Add(audioSource);
			}
		}
		return list.ToArray();
	}

	private void AddLoadedBundle(BundleDataObject bundleDataObject, AudioSource source)
	{
		if (this.loadedSources == null)
		{
			this.loadedSources = new Dictionary<string, AudioSource>();
		}
		if (!this.loadedSources.ContainsKey(bundleDataObject.AssetName))
		{
			this.loadedSources.Add(bundleDataObject.AssetName, source);
		}
	}

	public AudioSource GetLoadedAudioSource(BundleDataObject bundleDataObject)
	{
		if (this.loadedSources == null || !this.loadedSources.ContainsKey(bundleDataObject.AssetName))
		{
			return null;
		}
		return this.loadedSources[bundleDataObject.AssetName];
	}

	[SerializeField]
	private BundleDataObject bundleMusicTheme;

	[SerializeField]
	private BundleDataObject bundleLevelSelectionMusic;

	[SerializeField]
	private BundleDataObject bundleInFlightMusic;

	[SerializeField]
	private BundleDataObject bundleBuildMusic;

	[SerializeField]
	private BundleDataObject bundleFeedingMusic;

	[SerializeField]
	private BundleDataObject bundleAmbientJungle;

	[SerializeField]
	private BundleDataObject bundleAmbientPlateau;

	[SerializeField]
	private BundleDataObject bundleAmbientCave;

	[SerializeField]
	private BundleDataObject bundleAmbientNight;

	[SerializeField]
	private BundleDataObject bundleAmbientMorning;

	[SerializeField]
	private BundleDataObject bundleAmbientHalloween;

	[SerializeField]
	private BundleDataObject bundleAmbientMaya;

	[SerializeField]
	private BundleDataObject bundleCakeRaceTheme;

	[SerializeField]
	private BundleDataObject bundleXmasThemeSong;

	[SerializeField]
	private BundleDataObject bundleMenuClick;

	[HideInInspector]
	public AudioSource menuClick;

	[SerializeField]
	private BundleDataObject bundleGadgetButtonClick;

	[HideInInspector]
	public AudioSource gadgetButtonClick;

	[SerializeField]
	private BundleDataObject bundleMenuHover;

	[HideInInspector]
	public AudioSource menuHover;

	[SerializeField]
	private BundleDataObject bundleGoalBoxCollected;

	[HideInInspector]
	public AudioSource goalBoxCollected;

	[SerializeField]
	private BundleDataObject bundleBonusBoxCollected;

	[HideInInspector]
	public AudioSource bonusBoxCollected;

	[SerializeField]
	private BundleDataObject bundleDessertCollected;

	[HideInInspector]
	public AudioSource dessertCollected;

	[SerializeField]
	private BundleDataObject bundlePlacePart;

	[HideInInspector]
	public AudioSource placePart;

	[SerializeField]
	private BundleDataObject bundleRotatePart;

	[HideInInspector]
	public AudioSource rotatePart;

	[SerializeField]
	private BundleDataObject bundleDragPart;

	[HideInInspector]
	public AudioSource dragPart;

	[SerializeField]
	private BundleDataObject bundleRemovePart;

	[HideInInspector]
	public AudioSource removePart;

	[SerializeField]
	private BundleDataObject bundleClearBuildGrid;

	[HideInInspector]
	public AudioSource clearBuildGrid;

	[SerializeField]
	private BundleDataObject bundleBuildContraption;

	[HideInInspector]
	public AudioSource buildContraption;

	[SerializeField]
	private BundleDataObject bundleVictory;

	[HideInInspector]
	public AudioSource victory;

	[SerializeField]
	private BundleDataObject[] bundleStarEffects;

	[HideInInspector]
	public AudioSource[] starEffects;

	[SerializeField]
	private BundleDataObject[] bundleStarLoops;

	[HideInInspector]
	public AudioSource[] starLoops;

	[SerializeField]
	private BundleDataObject bundleBalloonPop;

	[HideInInspector]
	public AudioSource balloonPop;

	[SerializeField]
	private BundleDataObject bundleFan;

	[HideInInspector]
	public AudioSource fan;

	[SerializeField]
	private BundleDataObject bundlePropeller;

	[HideInInspector]
	public AudioSource propeller;

	[SerializeField]
	private BundleDataObject bundleMotorWheelLoop;

	[HideInInspector]
	public AudioSource motorWheelLoop;

	[SerializeField]
	private BundleDataObject bundleNormalWheelLoop;

	[HideInInspector]
	public AudioSource normalWheelLoop;

	[SerializeField]
	private BundleDataObject bundleSmallWheelLoop;

	[HideInInspector]
	public AudioSource smallWheelLoop;

	[SerializeField]
	private BundleDataObject bundleWoodenWheelLoop;

	[HideInInspector]
	public AudioSource woodenWheelLoop;

	[SerializeField]
	private BundleDataObject bundleStickyWheelLoop;

	[HideInInspector]
	public AudioSource stickyWheelLoop;

	[SerializeField]
	private BundleDataObject bundleRotorLoop;

	[HideInInspector]
	public AudioSource rotorLoop;

	[SerializeField]
	private BundleDataObject bundleBellowsPuff;

	[HideInInspector]
	public AudioSource bellowsPuff;

	[SerializeField]
	private BundleDataObject bundleElectricEngine;

	[HideInInspector]
	public AudioSource electricEngine;

	[SerializeField]
	private BundleDataObject bundleEngine;

	[HideInInspector]
	public AudioSource engine;

	[SerializeField]
	private BundleDataObject bundleV8Engine;

	[HideInInspector]
	public AudioSource V8Engine;

	[SerializeField]
	private BundleDataObject bundleBottleCork;

	[HideInInspector]
	public AudioSource bottleCork;

	[SerializeField]
	private BundleDataObject bundleUmbrellaOpen;

	[HideInInspector]
	public AudioSource umbrellaOpen;

	[SerializeField]
	private BundleDataObject bundleUmbrellaClose;

	[HideInInspector]
	public AudioSource umbrellaClose;

	[SerializeField]
	private BundleDataObject bundleTntExplosion;

	[HideInInspector]
	public AudioSource tntExplosion;

	[SerializeField]
	private BundleDataObject bundleSandbagCollision;

	[HideInInspector]
	public AudioSource sandbagCollision;

	[SerializeField]
	private BundleDataObject bundleSpringBoxingGloveShoot;

	[HideInInspector]
	public AudioSource springBoxingGloveShoot;

	[SerializeField]
	private BundleDataObject bundleSpringBoxingGloveWinding;

	[HideInInspector]
	public AudioSource springBoxingGloveWinding;

	[SerializeField]
	private BundleDataObject bundleGrapplingHookAttach;

	[HideInInspector]
	public AudioSource grapplingHookAttach;

	[SerializeField]
	private BundleDataObject bundleGrapplingHookDetach;

	[HideInInspector]
	public AudioSource grapplingHookDetach;

	[SerializeField]
	private BundleDataObject bundleGrapplingHookLaunch;

	[HideInInspector]
	public AudioSource grapplingHookLaunch;

	[SerializeField]
	private BundleDataObject bundleGrapplingHookMiss;

	[HideInInspector]
	public AudioSource grapplingHookMiss;

	[SerializeField]
	private BundleDataObject bundleGrapplingHookReeling;

	[HideInInspector]
	public AudioSource grapplingHookReeling;

	[SerializeField]
	private BundleDataObject bundleGrapplingHookReset;

	[HideInInspector]
	public AudioSource grapplingHookReset;

	[SerializeField]
	private BundleDataObject bundleKickerDetach;

	[HideInInspector]
	public AudioSource kickerDetach;

	[SerializeField]
	private BundleDataObject bundleSuperGlueApplied;

	[HideInInspector]
	public AudioSource SuperGlueApplied;

	[SerializeField]
	private BundleDataObject bundleSuperMagnetApplied;

	[HideInInspector]
	public AudioSource SuperMagnetApplied;

	[SerializeField]
	private BundleDataObject bundleTurboChargeApplied;

	[HideInInspector]
	public AudioSource TurboChargeApplied;

	[SerializeField]
	private BundleDataObject[] bundleCollisionMetalHit;

	[HideInInspector]
	public AudioSource[] collisionMetalHit;

	[SerializeField]
	private BundleDataObject[] bundleCollisionMetalDamage;

	[HideInInspector]
	public AudioSource[] collisionMetalDamage;

	[SerializeField]
	private BundleDataObject[] bundleCollisionMetalBreak;

	[HideInInspector]
	public AudioSource[] collisionMetalBreak;

	[SerializeField]
	private BundleDataObject[] bundleCollisionWoodHit;

	[HideInInspector]
	public AudioSource[] collisionWoodHit;

	[SerializeField]
	private BundleDataObject[] bundleCollisionWoodDamage;

	[HideInInspector]
	public AudioSource[] collisionWoodDamage;

	[SerializeField]
	private BundleDataObject[] bundleCollisionWoodDestroy;

	[HideInInspector]
	public AudioSource[] collisionWoodDestroy;

	[SerializeField]
	private BundleDataObject bundleTutorialIn;

	[HideInInspector]
	public AudioSource tutorialIn;

	[SerializeField]
	private BundleDataObject bundleTutorialOut;

	[HideInInspector]
	public AudioSource tutorialOut;

	[SerializeField]
	private BundleDataObject bundleTutorialFlip;

	[HideInInspector]
	public AudioSource tutorialFlip;

	[SerializeField]
	private BundleDataObject bundleCameraZoomIn;

	[HideInInspector]
	public AudioSource cameraZoomIn;

	[SerializeField]
	private BundleDataObject bundleCameraZoomOut;

	[HideInInspector]
	public AudioSource cameraZoomOut;

	[SerializeField]
	private BundleDataObject bundleJokerLevelUnlocked;

	[HideInInspector]
	public AudioSource jokerLevelUnlocked;

	[SerializeField]
	private BundleDataObject bundleSandboxLevelUnlocked;

	[HideInInspector]
	public AudioSource sandboxLevelUnlocked;

	[SerializeField]
	private BundleDataObject bundleBirdWakeUp;

	[HideInInspector]
	public AudioSource birdWakeUp;

	[SerializeField]
	private BundleDataObject bundleBirdShot;

	[HideInInspector]
	public AudioSource birdShot;

	[SerializeField]
	private BundleDataObject bundleSlingshotStretched;

	[HideInInspector]
	public AudioSource slingshotStretched;

	[SerializeField]
	private BundleDataObject[] bundlePartSlideOnIceLoop;

	[HideInInspector]
	public AudioSource[] partSlideOnIceLoop;

	[SerializeField]
	private BundleDataObject bundleMotorWheelOnIceStart;

	[HideInInspector]
	public AudioSource motorWheelOnIceStart;

	[SerializeField]
	private BundleDataObject bundleMotorWheelOnIceLoop;

	[HideInInspector]
	public AudioSource motorWheelOnIceLoop;

	[SerializeField]
	private BundleDataObject bundleGearboxSwitch;

	[HideInInspector]
	public AudioSource gearboxSwitch;

	[SerializeField]
	private BundleDataObject bundleEnvironmentFanStart;

	[HideInInspector]
	public AudioSource environmentFanStart;

	[SerializeField]
	private BundleDataObject bundleEnvironmentFanLoop;

	[HideInInspector]
	public AudioSource environmentFanLoop;

	[SerializeField]
	private BundleDataObject bundleToggleNightVision;

	[HideInInspector]
	public AudioSource toggleNightVision;

	[SerializeField]
	private BundleDataObject bundleToggleLamp;

	[HideInInspector]
	public AudioSource toggleLamp;

	[SerializeField]
	private BundleDataObject bundleAncientPigDisappear;

	[HideInInspector]
	public AudioSource ancientPigDisappear;

	[SerializeField]
	private BundleDataObject[] bundleGoldenPigHit;

	[HideInInspector]
	public AudioSource[] goldenPigHit;

	[SerializeField]
	private BundleDataObject bundleGoldenPigRoll;

	[HideInInspector]
	public AudioSource goldenPigRoll;

	[SerializeField]
	private BundleDataObject bundleSecretStatueFound;

	[HideInInspector]
	public AudioSource secretStatueFound;

	[SerializeField]
	private BundleDataObject bundlePigFall;

	[HideInInspector]
	public AudioSource pigFall;

	[SerializeField]
	private BundleDataObject bundleBridgeBreak;

	[HideInInspector]
	public AudioSource bridgeBreak;

	[SerializeField]
	private BundleDataObject bundlePressureButtonClick;

	[HideInInspector]
	public AudioSource pressureButtonClick;

	[SerializeField]
	private BundleDataObject bundlePressureButtonRelease;

	[HideInInspector]
	public AudioSource pressureButtonRelease;

	[SerializeField]
	private BundleDataObject[] bundleCollisionRockBreak;

	[HideInInspector]
	public AudioSource[] collisionRockBreak;

	[SerializeField]
	private BundleDataObject[] bundleSnoutCoinHit;

	[HideInInspector]
	public AudioSource[] snoutCoinHit;

	[SerializeField]
	private BundleDataObject[] bundleSnoutCoinFly;

	[HideInInspector]
	public AudioSource[] snoutCoinFly;

	[SerializeField]
	private BundleDataObject bundleSnoutCoinPurchase;

	[HideInInspector]
	public AudioSource snoutCoinPurchase;

	[SerializeField]
	private BundleDataObject bundleSnoutCoinIntro;

	[HideInInspector]
	public AudioSource snoutCoinIntro;

	[SerializeField]
	private BundleDataObject bundleSnoutCoinUse;

	[HideInInspector]
	public AudioSource snoutCoinUse;

	[SerializeField]
	private BundleDataObject bundleSnoutCoinUnlock;

	[HideInInspector]
	public AudioSource snoutCoinUnlock;

	[SerializeField]
	private BundleDataObject bundleInactiveButton;

	[HideInInspector]
	public AudioSource inactiveButton;

	[SerializeField]
	private BundleDataObject bundleToggleEpisode;

	[HideInInspector]
	public AudioSource toggleEpisode;

	[SerializeField]
	private BundleDataObject bundleSnoutCoinCounterLoop;

	[HideInInspector]
	public AudioSource snoutCoinCounterLoop;

	[SerializeField]
	private BundleDataObject bundleCraftAmbience;

	[HideInInspector]
	public AudioSource craftAmbience;

	[SerializeField]
	private BundleDataObject bundleCraftEmpty;

	[HideInInspector]
	public AudioSource craftEmpty;

	[SerializeField]
	private BundleDataObject bundleCraftLeverCrank;

	[HideInInspector]
	public AudioSource craftLeverCrank;

	[SerializeField]
	private BundleDataObject[] bundleMachineIdles;

	[HideInInspector]
	public AudioSource[] machineIdles;

	[SerializeField]
	private BundleDataObject bundleMachineIntro;

	[HideInInspector]
	public AudioSource machineIntro;

	[SerializeField]
	private BundleDataObject bundleCraftPart;

	[HideInInspector]
	public AudioSource craftPart;

	[SerializeField]
	private BundleDataObject bundleEjectScrap;

	[HideInInspector]
	public AudioSource ejectScrap;

	[SerializeField]
	private BundleDataObject bundleEjectScrapButton;

	[HideInInspector]
	public AudioSource ejectScrapButton;

	[SerializeField]
	private BundleDataObject bundleInsertScrap;

	[HideInInspector]
	public AudioSource insertScrap;

	[SerializeField]
	private BundleDataObject bundleLightBulb;

	[HideInInspector]
	public AudioSource lightBulb;

	[SerializeField]
	private BundleDataObject bundlePullChain;

	[HideInInspector]
	public AudioSource pullChain;

	[SerializeField]
	private BundleDataObject bundleReleaseChain;

	[HideInInspector]
	public AudioSource releaseChain;

	[SerializeField]
	private BundleDataObject[] bundleGoldenCrateHits;

	[HideInInspector]
	public AudioSource[] goldenCrateHits;

	[SerializeField]
	private BundleDataObject[] bundleMetalCrateHits;

	[HideInInspector]
	public AudioSource[] metalCrateHits;

	[SerializeField]
	private BundleDataObject[] bundleWoodenCrateHits;

	[HideInInspector]
	public AudioSource[] woodenCrateHits;

	[SerializeField]
	private BundleDataObject bundleSalvagePart;

	[HideInInspector]
	public AudioSource salvagePart;

	[SerializeField]
	private BundleDataObject[] bundleBellowsFarts;

	[HideInInspector]
	public AudioSource[] bellowsFarts;

	[SerializeField]
	private BundleDataObject bundleAlienEngineLoop;

	[HideInInspector]
	public AudioSource alienEngineLoop;

	[SerializeField]
	private BundleDataObject bundleGiftTNTExplosion;

	[HideInInspector]
	public AudioSource giftTNTExplosion;

	[SerializeField]
	private BundleDataObject[] bundleCratePillowHit;

	[HideInInspector]
	public AudioSource[] cratePillowHit;

	[SerializeField]
	private BundleDataObject[] bundlePillowDrops;

	[HideInInspector]
	public AudioSource[] pillowDrops;

	[SerializeField]
	private BundleDataObject[] bundleNutFly;

	[HideInInspector]
	public AudioSource[] nutFly;

	[SerializeField]
	private BundleDataObject[] bundleNutHit;

	[HideInInspector]
	public AudioSource[] nutHit;

	[SerializeField]
	private BundleDataObject bundleLootcrateEpicWow;

	[HideInInspector]
	public AudioSource lootcrateEpicWow;

	[SerializeField]
	private BundleDataObject bundlePartCraftedJingle;

	[HideInInspector]
	public AudioSource partCraftedJingle;

	[SerializeField]
	private BundleDataObject[] bundleRewardBounce;

	[HideInInspector]
	public AudioSource[] rewardBounce;

	[SerializeField]
	private BundleDataObject[] bundleLootWheelTickSounds;

	[HideInInspector]
	public AudioSource[] lootWheelTickSounds;

	[SerializeField]
	private BundleDataObject bundleLootWheelJackPot;

	[HideInInspector]
	public AudioSource lootWheelJackPot;

	[SerializeField]
	private BundleDataObject bundleLootWheelPrizeFly;

	[HideInInspector]
	public AudioSource lootWheelPrizeFly;

	[SerializeField]
	private BundleDataObject bundleLootWheelStarExplosion;

	[HideInInspector]
	public AudioSource lootWheelStarExplosion;

	[SerializeField]
	private BundleDataObject bundleConfetti;

	[HideInInspector]
	public AudioSource confetti;

	[SerializeField]
	private BundleDataObject bundleRefereePigFall;

	[HideInInspector]
	public AudioSource refereePigFall;

	[SerializeField]
	private BundleDataObject bundleRefereePigFallImpact;

	[HideInInspector]
	public AudioSource refereePigFallImpact;

	[SerializeField]
	private BundleDataObject bundleRefereePigFlag;

	[HideInInspector]
	public AudioSource refereePigFlag;

	[SerializeField]
	private BundleDataObject bundleRefereePigImpact;

	[HideInInspector]
	public AudioSource refereePigImpact;

	[SerializeField]
	private BundleDataObject bundleRefereePigWhistle;

	[HideInInspector]
	public AudioSource refereePigWhistle;

	[SerializeField]
	private BundleDataObject bundleSafeDrop;

	[HideInInspector]
	public AudioSource safeDrop;

	[SerializeField]
	private BundleDataObject[] bundleScoreCountDown;

	[HideInInspector]
	public AudioSource[] scoreCountDown;

	[SerializeField]
	private BundleDataObject[] bundleScoreCountUp;

	[HideInInspector]
	public AudioSource[] scoreCountUp;

	[SerializeField]
	private BundleDataObject[] bundleWinTrumpet;

	[HideInInspector]
	public AudioSource[] winTrumpet;

	[SerializeField]
	private BundleDataObject bundleYouWinPillowAppear;

	[HideInInspector]
	public AudioSource youWinPillowAppear;

	[SerializeField]
	private BundleDataObject[] bundleXPGain;

	[HideInInspector]
	public AudioSource[] xpGain;

	[SerializeField]
	private BundleDataObject[] bundleGhostBalloonPop;

	[HideInInspector]
	public AudioSource[] ghostBalloonPop;

	[SerializeField]
	private BundleDataObject[] bundleGhostBalloonWail;

	[HideInInspector]
	public AudioSource[] ghostBalloonWail;

	[SerializeField]
	private BundleDataObject[] bundleMarbleCrateHits;

	[HideInInspector]
	public AudioSource[] marbleCrateHits;

	[SerializeField]
	private BundleDataObject[] bundleGlassCrateHits;

	[HideInInspector]
	public AudioSource[] glassCrateHits;

	[SerializeField]
	private BundleDataObject[] bundleTimeBombAlarm;

	[HideInInspector]
	public AudioSource[] timeBombAlarm;

	[SerializeField]
	private BundleDataObject[] bundleAlienLaserFire;

	[HideInInspector]
	public AudioSource[] alienLaserFire;

	[SerializeField]
	private BundleDataObject bundleAlienFan;

	[HideInInspector]
	public AudioSource alienFan;

	[SerializeField]
	private BundleDataObject bundleAlienRotor;

	[HideInInspector]
	public AudioSource alienRotor;

	[SerializeField]
	private BundleDataObject bundleJingleBell;

	[HideInInspector]
	public AudioSource jingleBell;

	[SerializeField]
	private BundleDataObject bundleAlienSodaBottleStart;

	[HideInInspector]
	public AudioSource alienSodaBottleStart;

	[SerializeField]
	private BundleDataObject bundleAlienSodaBottleLoop;

	[HideInInspector]
	public AudioSource alienSodaBottleLoop;

	[SerializeField]
	private BundleDataObject bundleAlienBeepBoop;

	[HideInInspector]
	public AudioSource alienBeepBoop;

	[SerializeField]
	private BundleDataObject[] bundleAlienLanguage;

	[HideInInspector]
	public AudioSource[] alienLanguage;

	[SerializeField]
	private BundleDataObject bundleAlienMachineReveal;

	[HideInInspector]
	public AudioSource alienMachineReveal;

	[SerializeField]
	private BundleDataObject bundleCraftingSlime;

	[HideInInspector]
	public AudioSource craftingSlime;

	[SerializeField]
	private BundleDataObject[] bundleAlienBellows;

	[HideInInspector]
	public AudioSource[] alienBellows;

	[SerializeField]
	private BundleDataObject bundleAlienPunch;

	[HideInInspector]
	public AudioSource alienPunch;

	[SerializeField]
	private BundleDataObject[] bundleScoreAnticipation;

	[HideInInspector]
	public AudioSource[] scoreAnticipation;

	[SerializeField]
	private BundleDataObject bundleScoreImpact;

	[HideInInspector]
	public AudioSource scoreImpact;

	private Dictionary<string, AudioSource> loadedSources;
}
