using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : WPFMonoBehaviour
{
    public CoinsCollected CoinsCollectedNow
    {
        get
        {
            return this.coinsCollected;
        }
    }

    public void SetGoal(GoalChallenge challenge)
    {
        this.m_goal = challenge;
    }

    public void SetChallenges(List<Challenge> challenges)
    {
        this.m_challenges = challenges;
    }

    public void OpenObjectiveTutorial(string slot)
    {
        int num = int.Parse(slot) - 2;
        if (num >= 0 && num <= 1)
        {
            WPFMonoBehaviour.levelManager.m_levelCompleteTutorialBookPagePrefab = this.m_challenges[num].m_tutorialBookPage;
            EventManager.Send(new UIEvent(UIEvent.Type.OpenTutorial));
        }
        else
        {
            WPFMonoBehaviour.levelManager.m_levelCompleteTutorialBookPagePrefab = this.m_goal.TutorialPage;
            EventManager.Send(new UIEvent(UIEvent.Type.OpenTutorial));
        }
    }

    private void OnEnable()
    {
        if (Singleton<BuildCustomizationLoader>.Instance.IAPEnabled)
        {
            IapManager.onPurchaseSucceeded += this.HandleIapManageronPurchaseSucceeded;
        }
        KeyListener.keyPressed += this.HandleKeyListenerkeyPressed;
        if (this.m_music)
        {
            this.m_music.GetComponent<AudioSource>().Play();
        }
    }

    private void OnDisable()
    {
        if (Singleton<BuildCustomizationLoader>.IsInstantiated() && Singleton<BuildCustomizationLoader>.Instance.IAPEnabled)
        {
            IapManager.onPurchaseSucceeded -= this.HandleIapManageronPurchaseSucceeded;
        }
        KeyListener.keyPressed -= this.HandleKeyListenerkeyPressed;
    }

    private void HandleKeyListenerkeyPressed(KeyCode obj)
    {
        if (obj == KeyCode.Escape)
        {
            EventManager.Send(new UIEvent(UIEvent.Type.LevelSelection));
        }
    }

    private void HandleIapManageronPurchaseSucceeded(IapManager.InAppPurchaseItemType type)
    {
        if (type == IapManager.InAppPurchaseItemType.UnlockFullVersion || type == IapManager.InAppPurchaseItemType.UnlockTenLevels || type == IapManager.InAppPurchaseItemType.UnlockEpisode)
        {
            Singleton<GameManager>.Instance.LoadNextLevel();
        }
    }

    private void ReportLeaderboardScoreCallback(bool result)
    {
    }

    private void Awake()
    {
        this.doubleRewardButton.LevelComplete = this;
    }

    private IEnumerator Start()
    {
        this.bShakeCamera = false;
        PlayerProgressBar.Instance.CanLevelUp = false;
        this.m_objectiveOne.GetComponent<Collider>().enabled = false;
        this.m_objectiveTwo.GetComponent<Collider>().enabled = false;
        this.m_objectiveThree.GetComponent<Collider>().enabled = false;
        this.m_controlsPosition = this.m_controlsPanel.transform.position;
        this.m_controlsHidePosition = this.m_controlsPosition + new Vector3(0f, -5f, 0f);
        this.m_controlsPanel.transform.position = this.m_controlsHidePosition;
        this.m_starPanelPosition = this.m_starPanel.transform.position;
        this.m_starPanelHidePosition = this.m_starPanelPosition + new Vector3(0f, 12f, 0f);
        this.m_starPanel.transform.position = this.m_starPanelHidePosition;
        this.m_backgroundPosition = this.m_background.transform.position;
        this.m_backgroundHidePosition = this.m_backgroundPosition + new Vector3(0f, 12f, 0f);
        this.m_background.transform.position = this.m_backgroundHidePosition;
        this.m_hasDoubleRewards = Singleton<DoubleRewardManager>.Instance.HasDoubleReward;
        GameObject bestTimeStamp = base.transform.Find("StarPanel/NewBestTimeStamp").gameObject;
        bestTimeStamp.SetActive(false);
        GameObject resultTime = base.transform.Find("StarPanel/ResultTime").gameObject;
        if (!WPFMonoBehaviour.levelManager || WPFMonoBehaviour.levelManager.m_raceLevel)
        {
            Transform transform = base.transform.Find("Rewards/Pig");
            transform.Translate(0f, -1.4f, 0f);
            float num = (!WPFMonoBehaviour.levelManager) ? 124.56f : WPFMonoBehaviour.levelManager.TimeElapsed;
            string text = RaceTimeCounter.FormatTime(num);
            resultTime.GetComponent<TextMesh>().text = text;
            resultTime.transform.Find("ResultTimeShadow").GetComponent<TextMesh>().text = text;
            if (GameProgress.HasBestTime(Singleton<GameManager>.Instance.CurrentSceneName))
            {
                float bestTime = GameProgress.GetBestTime(Singleton<GameManager>.Instance.CurrentSceneName);
                if (num < bestTime)
                {
                    GameProgress.SetBestTime(Singleton<GameManager>.Instance.CurrentSceneName, num);
                    bestTimeStamp.SetActive(true);
                }
            }
            else
            {
                GameProgress.SetBestTime(Singleton<GameManager>.Instance.CurrentSceneName, num);
                bestTimeStamp.SetActive(true);
            }
            if (Singleton<SocialGameManager>.IsInstantiated())
            {
                long num2 = (long)((int)(num * 100f));
                if (num2 > 0L)
                {
                    Singleton<SocialGameManager>.Instance.ReportLeaderboardScore(Singleton<GameManager>.Instance.CurrentLevelLeaderboard(), num2, new Action<bool>(this.ReportLeaderboardScoreCallback));
                }
            }
        }
        else
        {
            resultTime.GetComponent<Renderer>().enabled = false;
            resultTime.transform.Find("ResultTimeShadow").GetComponent<Renderer>().enabled = false;
        }
        this.m_starOne.SetActive(false);
        this.m_starTwo.SetActive(false);
        this.m_starThree.SetActive(false);
        if (this.m_challenges.Count >= 2 && this.m_challenges[1].IsCompleted() && !this.m_challenges[0].IsCompleted())
        {
            Challenge value = this.m_challenges[0];
            this.m_challenges[0] = this.m_challenges[1];
            this.m_challenges[1] = value;
        }
        float waitTime = 0.1f;
        while (!Mathf.Approximately(Time.timeScale, 1f) || waitTime > 0f)
        {
            waitTime -= Time.deltaTime;
            yield return null;
        }
        base.StartCoroutine(this.ShowStarPanel(1.5f));
        float coinEffectDelay = 0.875f;
        int challenge0SnoutCoinsCount = Singleton<GameConfigurationManager>.Instance.GetValue<int>("level_complete_snout_reward", "One");
        int challenge1SnoutCoinsCount = Singleton<GameConfigurationManager>.Instance.GetValue<int>("level_complete_snout_reward", "Two");
        int challenge2SnoutCoinsCount = Singleton<GameConfigurationManager>.Instance.GetValue<int>("level_complete_snout_reward", "Three");
        if (this.m_hasDoubleRewards)
        {
            challenge0SnoutCoinsCount *= 2;
            challenge1SnoutCoinsCount *= 2;
            challenge2SnoutCoinsCount *= 2;
        }
        float firstStarTime = 2f;
        string currentScene = Singleton<GameManager>.Instance.CurrentSceneName;
        bool levelCompletedPreviously = GameProgress.IsLevelCompleted(currentScene);
        bool challenge1CompletedPreviously = GameProgress.IsChallengeCompleted(currentScene, this.m_challenges[0].ChallengeNumber);
        bool challenge2CompletedPreviously = GameProgress.IsChallengeCompleted(currentScene, this.m_challenges[1].ChallengeNumber);
        bool challenge0SnoutCoinsCollected = GameProgress.HasCollectedSnoutCoins(currentScene, 0);
        bool challenge1SnoutCoinsCollected = GameProgress.HasCollectedSnoutCoins(currentScene, this.m_challenges[0].ChallengeNumber);
        bool challenge2SnoutCoinsCollected = GameProgress.HasCollectedSnoutCoins(currentScene, this.m_challenges[1].ChallengeNumber);
        bool challenge1Completed = this.m_challenges.Count >= 1 && this.m_challenges[0].IsCompleted();
        bool challenge2Completed = this.m_challenges.Count >= 2 && this.m_challenges[1].IsCompleted();
        this.m_objectiveOne.SetChallenge(this.m_goal);
        if (!challenge0SnoutCoinsCollected)
        {
            GameProgress.SetChallengeCompleted(Singleton<GameManager>.Instance.CurrentSceneName, 0, true, challenge0SnoutCoinsCount > 0);
        }
        if (this.m_challenges.Count >= 1)
        {
            this.m_objectiveTwo.SetChallenge(this.m_challenges[0]);
        }
        if (this.m_challenges.Count >= 2)
        {
            this.m_objectiveThree.SetChallenge(this.m_challenges[1]);
        }
        int snoutCoins = 0;
        int totalStars = 0;
        if (levelCompletedPreviously)
        {
            totalStars++;
        }
        if (challenge1CompletedPreviously)
        {
            totalStars++;
        }
        if (challenge2CompletedPreviously)
        {
            totalStars++;
        }
        if (!levelCompletedPreviously)
        {
            totalStars++;
        }
        if (challenge1Completed && !challenge1CompletedPreviously)
        {
            totalStars++;
        }
        if (challenge2Completed && !challenge2CompletedPreviously)
        {
            totalStars++;
        }
        int starsInThisrun = 1;
        if (challenge1Completed)
        {
            starsInThisrun++;
        }
        if (challenge2Completed)
        {
            starsInThisrun++;
        }
        int starSoundIndex = totalStars - starsInThisrun;
        string previousStars = "0";
        string newStars = "0";
        int newStarsThisRun = 0;
        if (levelCompletedPreviously)
        {
            base.StartCoroutine(this.PlayOldStarEffects(this.m_objectiveOne, this.m_starOne, firstStarTime, true, WPFMonoBehaviour.gameData.commonAudioCollection.starEffects[starSoundIndex], "StarAppearing"));
            starSoundIndex++;
            previousStars = "1";
        }
        else
        {
            this.LevelCompletedForFirstTime();
            firstStarTime += 0.2f;
            base.StartCoroutine(this.PlayStarEffects(this.m_objectiveOne, this.m_starOne, null, firstStarTime, WPFMonoBehaviour.gameData.commonAudioCollection.starEffects[starSoundIndex], "StarAppearing"));
            starSoundIndex++;
            GameProgress.SetLevelCompleted(Singleton<GameManager>.Instance.CurrentSceneName);
            newStars = "1";
            newStarsThisRun++;
        }
        if (!challenge0SnoutCoinsCollected)
        {
            snoutCoins += challenge0SnoutCoinsCount;
            this.coinsCollected |= LevelComplete.CoinsCollected.Challenge1;
            if (SnoutButton.Instance && this.m_starOne)
            {
                for (int i = 0; i < challenge0SnoutCoinsCount; i++)
                {
                    SnoutButton.Instance.AddParticles(this.m_starOne, 1, firstStarTime + coinEffectDelay + 0.2f * (float)i, 0f);
                }
            }
        }
        this.m_objectiveOne.ShowSnoutReward(!challenge0SnoutCoinsCollected, challenge0SnoutCoinsCount, true);
        float secondStarTime = firstStarTime + 0.7f;
        if (challenge1CompletedPreviously)
        {
            bool snoutCoinsCollected = true;
            if (challenge1Completed && !challenge1SnoutCoinsCollected && challenge2SnoutCoinsCollected)
            {
                if (challenge2SnoutCoinsCount <= 0)
                {
                    snoutCoinsCollected = false;
                }
                snoutCoins += challenge2SnoutCoinsCount;
                this.coinsCollected |= LevelComplete.CoinsCollected.Challenge3;
                if (SnoutButton.Instance && this.m_starTwo)
                {
                    for (int j = 0; j < challenge2SnoutCoinsCount; j++)
                    {
                        SnoutButton.Instance.AddParticles(this.m_starTwo, 1, secondStarTime + coinEffectDelay + 0.2f * (float)j, 0f);
                    }
                }
            }
            else if (challenge1Completed && !challenge1SnoutCoinsCollected && !challenge2SnoutCoinsCollected)
            {
                if (challenge1SnoutCoinsCount <= 0)
                {
                    snoutCoinsCollected = false;
                }
                snoutCoins += challenge1SnoutCoinsCount;
                this.coinsCollected |= LevelComplete.CoinsCollected.Challenge2;
                if (SnoutButton.Instance && this.m_starTwo)
                {
                    for (int k = 0; k < challenge1SnoutCoinsCount; k++)
                    {
                        SnoutButton.Instance.AddParticles(this.m_starTwo, 1, secondStarTime + coinEffectDelay + 0.2f * (float)k, 0f);
                    }
                }
            }
            if (challenge1Completed && !challenge1SnoutCoinsCollected)
            {
                GameProgress.SetChallengeCompleted(Singleton<GameManager>.Instance.CurrentSceneName, this.m_challenges[0].ChallengeNumber, true, snoutCoinsCollected);
            }
            AudioSource starAudio = null;
            if (challenge1Completed)
            {
                starAudio = WPFMonoBehaviour.gameData.commonAudioCollection.starEffects[starSoundIndex];
                starSoundIndex++;
            }
            base.StartCoroutine(this.PlayOldStarEffects(this.m_objectiveTwo, this.m_starTwo, secondStarTime, challenge1Completed, starAudio, "StarAppearing2"));
            previousStars += ",2";
        }
        else if (challenge1Completed)
        {
            bool snoutCoinsCollected2 = true;
            if (!challenge1SnoutCoinsCollected && challenge2SnoutCoinsCollected)
            {
                if (challenge2SnoutCoinsCount <= 0)
                {
                    snoutCoinsCollected2 = false;
                }
                snoutCoins += challenge2SnoutCoinsCount;
                this.coinsCollected |= LevelComplete.CoinsCollected.Challenge3;
                if (SnoutButton.Instance && this.m_starTwo)
                {
                    for (int l = 0; l < challenge2SnoutCoinsCount; l++)
                    {
                        SnoutButton.Instance.AddParticles(this.m_starTwo, 1, secondStarTime + coinEffectDelay + 0.2f * (float)l, 0f);
                    }
                }
            }
            else if (!challenge1SnoutCoinsCollected && !challenge2SnoutCoinsCollected)
            {
                if (challenge1SnoutCoinsCount <= 0)
                {
                    snoutCoinsCollected2 = false;
                }
                snoutCoins += challenge1SnoutCoinsCount;
                this.coinsCollected |= LevelComplete.CoinsCollected.Challenge2;
                if (SnoutButton.Instance && this.m_starTwo)
                {
                    for (int m = 0; m < challenge1SnoutCoinsCount; m++)
                    {
                        SnoutButton.Instance.AddParticles(this.m_starTwo, 1, secondStarTime + coinEffectDelay + 0.2f * (float)m, 0f);
                    }
                }
            }
            base.StartCoroutine(this.PlayStarEffects(this.m_objectiveTwo, this.m_starTwo, this.m_challenges[0], secondStarTime, WPFMonoBehaviour.gameData.commonAudioCollection.starEffects[starSoundIndex], "StarAppearing2"));
            starSoundIndex++;
            GameProgress.SetChallengeCompleted(Singleton<GameManager>.Instance.CurrentSceneName, this.m_challenges[0].ChallengeNumber, true, snoutCoinsCollected2);
            newStars += ",2";
            newStarsThisRun++;
        }
        if (challenge1SnoutCoinsCollected)
        {
            this.m_objectiveTwo.ShowSnoutReward(false, 0, true);
        }
        else
        {
            this.m_objectiveTwo.ShowSnoutReward(true, (!challenge2SnoutCoinsCollected) ? challenge1SnoutCoinsCount : challenge2SnoutCoinsCount, true);
        }
        float thirdStarTime = secondStarTime + 0.7f;
        if (challenge2CompletedPreviously)
        {
            bool snoutCoinsCollected3 = true;
            if (challenge2Completed && !challenge2SnoutCoinsCollected && challenge1Completed)
            {
                if (challenge2SnoutCoinsCount <= 0)
                {
                    snoutCoinsCollected3 = false;
                }
                snoutCoins += challenge2SnoutCoinsCount;
                this.coinsCollected |= LevelComplete.CoinsCollected.Challenge3;
                if (SnoutButton.Instance && this.m_starThree)
                {
                    for (int n = 0; n < challenge2SnoutCoinsCount; n++)
                    {
                        SnoutButton.Instance.AddParticles(this.m_starThree, 1, thirdStarTime + coinEffectDelay + 0.2f * (float)n, 0f);
                    }
                }
            }
            else if (challenge2Completed && !challenge2SnoutCoinsCollected && !challenge1SnoutCoinsCollected)
            {
                if (challenge1SnoutCoinsCount <= 0)
                {
                    snoutCoinsCollected3 = false;
                }
                snoutCoins += challenge1SnoutCoinsCount;
                this.coinsCollected |= LevelComplete.CoinsCollected.Challenge2;
                if (SnoutButton.Instance && this.m_starThree)
                {
                    for (int num3 = 0; num3 < challenge1SnoutCoinsCount; num3++)
                    {
                        SnoutButton.Instance.AddParticles(this.m_starThree, 1, thirdStarTime + coinEffectDelay + 0.2f * (float)num3, 0f);
                    }
                }
            }
            if (challenge2Completed && !challenge2SnoutCoinsCollected)
            {
                GameProgress.SetChallengeCompleted(Singleton<GameManager>.Instance.CurrentSceneName, this.m_challenges[1].ChallengeNumber, true, snoutCoinsCollected3);
            }
            AudioSource starAudio2 = null;
            if (challenge2Completed)
            {
                starAudio2 = WPFMonoBehaviour.gameData.commonAudioCollection.starEffects[starSoundIndex];
                starSoundIndex++;
            }
            base.StartCoroutine(this.PlayOldStarEffects(this.m_objectiveThree, this.m_starThree, thirdStarTime, challenge2Completed, starAudio2, "StarAppearing3"));
            previousStars += ",3";
        }
        else if (challenge2Completed)
        {
            bool snoutCoinsCollected4 = true;
            if (!challenge2SnoutCoinsCollected && challenge1Completed)
            {
                if (challenge2SnoutCoinsCount <= 0)
                {
                    snoutCoinsCollected4 = false;
                }
                snoutCoins += challenge2SnoutCoinsCount;
                this.coinsCollected |= LevelComplete.CoinsCollected.Challenge3;
                if (SnoutButton.Instance && this.m_starThree)
                {
                    for (int num4 = 0; num4 < challenge2SnoutCoinsCount; num4++)
                    {
                        SnoutButton.Instance.AddParticles(this.m_starThree, 1, thirdStarTime + coinEffectDelay + 0.2f * (float)num4, 0f);
                    }
                }
            }
            else if (!challenge2SnoutCoinsCollected && !challenge1SnoutCoinsCollected)
            {
                if (challenge1SnoutCoinsCount <= 0)
                {
                    snoutCoinsCollected4 = false;
                }
                snoutCoins += challenge1SnoutCoinsCount;
                this.coinsCollected |= LevelComplete.CoinsCollected.Challenge2;
                if (SnoutButton.Instance && this.m_starThree)
                {
                    for (int num5 = 0; num5 < challenge1SnoutCoinsCount; num5++)
                    {
                        SnoutButton.Instance.AddParticles(this.m_starThree, 1, thirdStarTime + coinEffectDelay + 0.2f * (float)num5, 0f);
                    }
                }
            }
            base.StartCoroutine(this.PlayStarEffects(this.m_objectiveThree, this.m_starThree, this.m_challenges[1], thirdStarTime, WPFMonoBehaviour.gameData.commonAudioCollection.starEffects[starSoundIndex], "StarAppearing3"));
            starSoundIndex++;
            GameProgress.SetChallengeCompleted(Singleton<GameManager>.Instance.CurrentSceneName, this.m_challenges[1].ChallengeNumber, true, snoutCoinsCollected4);
            newStars += ",3";
            newStarsThisRun++;
        }
        if (challenge2SnoutCoinsCollected)
        {
            this.m_objectiveThree.ShowSnoutReward(false, 0, true);
        }
        else
        {
            this.m_objectiveThree.ShowSnoutReward(true, (!challenge1SnoutCoinsCollected && !challenge1Completed && challenge2Completed) ? challenge1SnoutCoinsCount : challenge2SnoutCoinsCount, true);
        }
        GameProgress.AddSnoutCoins(snoutCoins);
        bool isJokerLevel = LevelInfo.IsStarLevel(Singleton<GameManager>.Instance.CurrentEpisodeIndex, Singleton<GameManager>.Instance.CurrentLevel);
        PlayerProgress.ExperienceType xpTypeOneStar = (!isJokerLevel) ? PlayerProgress.ExperienceType.LevelComplete1Star : PlayerProgress.ExperienceType.JokerLevelComplete1Star;
        PlayerProgress.ExperienceType xpTypeTwoStars = (!isJokerLevel) ? PlayerProgress.ExperienceType.LevelComplete2Star : PlayerProgress.ExperienceType.JokerLevelComplete2Star;
        PlayerProgress.ExperienceType xpTypeThreeStars = (!isJokerLevel) ? PlayerProgress.ExperienceType.LevelComplete3Star : PlayerProgress.ExperienceType.JokerLevelComplete3Star;
        string sceneKey = Singleton<GameManager>.Instance.CurrentSceneName;
        if (GameProgress.ExperienceGiven(xpTypeOneStar, sceneKey) == 0)
        {
            GameProgress.ReportExperienceGiven(xpTypeOneStar, sceneKey);
            PlayerProgressBar.Instance.DelayUpdate();
            int count = Singleton<PlayerProgress>.Instance.AddExperience(xpTypeOneStar);
            this.AddExperienceParticles(this.m_starOne, count, firstStarTime + coinEffectDelay);
        }
        if ((challenge1CompletedPreviously || challenge1Completed || challenge2CompletedPreviously || challenge2Completed) && GameProgress.ExperienceGiven(xpTypeTwoStars, sceneKey) == 0)
        {
            GameProgress.ReportExperienceGiven(xpTypeTwoStars, sceneKey);
            PlayerProgressBar.Instance.DelayUpdate();
            int count2 = Singleton<PlayerProgress>.Instance.AddExperience(xpTypeTwoStars);
            this.AddExperienceParticles(this.m_starTwo, count2, secondStarTime + coinEffectDelay);
        }
        if (challenge1Completed && challenge2CompletedPreviously && GameProgress.ExperienceGiven(xpTypeThreeStars, sceneKey) == 0)
        {
            GameProgress.ReportExperienceGiven(xpTypeThreeStars, sceneKey);
            PlayerProgressBar.Instance.DelayUpdate();
            int count3 = Singleton<PlayerProgress>.Instance.AddExperience(xpTypeThreeStars);
            this.AddExperienceParticles(this.m_starTwo, count3, secondStarTime + coinEffectDelay);
        }
        else if (challenge1Completed && challenge2CompletedPreviously && GameProgress.ExperienceGiven(xpTypeThreeStars, sceneKey) == 0)
        {
            GameProgress.ReportExperienceGiven(xpTypeThreeStars, sceneKey);
            PlayerProgressBar.Instance.DelayUpdate();
            int count4 = Singleton<PlayerProgress>.Instance.AddExperience(xpTypeThreeStars);
            this.AddExperienceParticles(this.m_starThree, count4, thirdStarTime + coinEffectDelay);
        }
        else if ((challenge1CompletedPreviously || challenge1Completed) && (challenge2CompletedPreviously || challenge2Completed) && GameProgress.ExperienceGiven(xpTypeThreeStars, sceneKey) == 0)
        {
            GameProgress.ReportExperienceGiven(xpTypeThreeStars, sceneKey);
            PlayerProgressBar.Instance.DelayUpdate();
            int count5 = Singleton<PlayerProgress>.Instance.AddExperience(xpTypeThreeStars);
            this.AddExperienceParticles(this.m_starThree, count5, thirdStarTime + coinEffectDelay);
        }
        bool wasRowThreeStarred = Singleton<GameManager>.Instance.CurrentStarLevelUnlocked();
        GameProgress.SetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_stars", totalStars, GameProgress.Location.Local);
        bool isRowThreeStarred = Singleton<GameManager>.Instance.CurrentStarLevelUnlocked();
        this.m_jokerLevelUnlocked = (isRowThreeStarred && !wasRowThreeStarred);
        base.StartCoroutine(this.StartMusic(thirdStarTime + 1f, WPFMonoBehaviour.gameData.commonAudioCollection.starLoops[totalStars - 1]));
        base.StartCoroutine(this.ShowBackground(1.5f, thirdStarTime - 1.5f));
        BasePart.PartType newRacePart = this.GetNewRacePart(newStarsThisRun);
        if (newRacePart != BasePart.PartType.Unknown)
        {
            this.m_unlockedRaceLevelPart = newRacePart;
        }
        if (!this.ShowRewards(ref thirdStarTime))
        {
            base.StartCoroutine(this.ShowLonelyPig(thirdStarTime + 1f, totalStars, true));
        }
        if (WPFMonoBehaviour.levelManager != null)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("Goal");
            bool flag = gameObject != null && gameObject.transform.Find("Dessert") != null;
            if (flag)
            {
                string saveId = WPFMonoBehaviour.gameData.m_BonusDessert.GetComponent<Dessert>().saveId;
                GameProgress.AddDesserts(saveId, 1);
                WPFMonoBehaviour.levelManager.m_CollectedDessertsCount++;
            }
            if (WPFMonoBehaviour.levelManager.LevelDessertsCount > 0)
            {
                if (WPFMonoBehaviour.levelManager.m_CollectedDessertsCount >= WPFMonoBehaviour.levelManager.LevelDessertsCount && Singleton<SocialGameManager>.IsInstantiated())
                {
                    Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.CAKE_WALK", 100.0);
                    if (WPFMonoBehaviour.levelManager.ContraptionRunning.HasSuperMagnet)
                    {
                        bool flag2 = true;
                        foreach (Challenge x in this.m_challenges)
                        {
                            if (x.Type == Challenge.ChallengeType.Box && !x.IsCompleted())
                            {
                                flag2 = false;
                                break;
                            }
                        }
                        if (flag2)
                        {
                            Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.MAGNET_MASTER", 100.0);
                        }
                    }
                }
                this.ShowDessertButton();
            }
        }
        base.StartCoroutine(CoroutineRunner.DelayActionSequence(delegate
        {
            PlayerProgressBar.Instance.CanLevelUp = true;
        }, thirdStarTime + 1.5f, false));
        base.StartCoroutine(this.ShowControls(thirdStarTime + 1.5f));
        base.StartCoroutine(this.ShowEpisodeThreeStarred(thirdStarTime + 2f));
        if (WPFMonoBehaviour.levelManager)
        {
            LevelComplete.SendLevelCompleteEvent(previousStars, newStars);
        }
        if (Singleton<SocialGameManager>.IsInstantiated() && WPFMonoBehaviour.levelManager)
        {
            this.CheckLevelEndAchievements();
        }
        if ((challenge1Completed || challenge1CompletedPreviously) && this.m_challenges[0].Type == Challenge.ChallengeType.Time)
        {
            if (this.rewardVideoButton)
            {
                this.rewardVideoButton.SetActive(false);
            }
            if (this.extraCoinsRewardButton)
            {
                this.extraCoinsRewardButton.gameObject.SetActive(true);
            }
        }
        else if ((challenge2Completed || challenge2CompletedPreviously) && this.m_challenges[1].Type == Challenge.ChallengeType.Time)
        {
            if (this.rewardVideoButton)
            {
                this.rewardVideoButton.SetActive(false);
            }
            if (this.extraCoinsRewardButton)
            {
                this.extraCoinsRewardButton.gameObject.SetActive(true);
            }
        }
        else
        {
            bool flag3 = false;
            if (this.rewardVideoButton)
            {
                this.rewardVideoButton.SetActive(true);
                flag3 = true;
                this.hasTransformed = true;
            }
            if (this.extraCoinsRewardButton)
            {
                this.extraCoinsRewardButton.gameObject.SetActive(!flag3);
            }
        }
        if (this.m_buttonGridLayout)
        {
            this.m_buttonGridLayout.UpdateLayout();
        }
		PlayerPrefs.Save();
        yield break;
    }

    private void AddExperienceParticles(GameObject target, int count, float delay)
    {
        if (!target && !Singleton<PlayerProgress>.IsInstantiated() && !PlayerProgressBar.Instance)
        {
            return;
        }
        PlayerProgressBar.Instance.AddParticles(target, count, delay, 0f, null);
    }

    private BasePart.PartType GetNewRacePart(int newStars)
    {
        int num = GameProgress.GetAllStars() + GameProgress.GetRaceLevelUnlockedStars();
        BasePart.PartType partType = BasePart.PartType.Unknown;
        int num2 = 0;
        string race_level_id = string.Empty;
        foreach (RaceLevels.LevelUnlockablePartsData levelUnlockablePartsData in WPFMonoBehaviour.gameData.m_raceLevels.LevelUnlockables)
        {
            if (GameProgress.GetRaceLevelUnlocked(levelUnlockablePartsData.m_identifier))
            {
                for (int i = 0; i < levelUnlockablePartsData.m_tiers.Count; i++)
                {
                    if (levelUnlockablePartsData.m_tiers[i].m_starLimit > num - newStars && levelUnlockablePartsData.m_tiers[i].m_starLimit <= num && levelUnlockablePartsData.m_tiers[i].m_starLimit > num2)
                    {
                        partType = levelUnlockablePartsData.m_tiers[i].m_part;
                        num2 = levelUnlockablePartsData.m_tiers[i].m_starLimit;
                        this.m_raceLevelNumber = levelUnlockablePartsData;
                        race_level_id = levelUnlockablePartsData.m_identifier;
                    }
                }
            }
        }
        if (partType != BasePart.PartType.Unknown)
        {
            this.SendUnlockedRaceLevelPartFlurryEvent(Singleton<GameManager>.Instance.CurrentLevelIdentifier, race_level_id, partType.ToString());
        }
        return partType;
    }

    private bool ShowRewards(ref float delay)
    {
        if (this.m_jokerLevelUnlocked)
        {
            string text = LevelSelector.DifferentiatedLevelLabel(Singleton<GameManager>.Instance.GetCurrentRowJokerLevelIndex());
            EpisodeLevelInfo currentRowJokerLevel = Singleton<GameManager>.Instance.GetCurrentRowJokerLevel();
            string text2 = string.Empty;
            int currentEpisodeIndex = Singleton<GameManager>.Instance.CurrentEpisodeIndex;
            if (currentEpisodeIndex != 4)
            {
                if (currentEpisodeIndex != 5)
                {
                    text2 = "BonusLevelUnlock";
                }
                else
                {
                    text2 = "BonusLevelUnlockGolden";
                }
            }
            else
            {
                text2 = "BonusLevelUnlockHalloween";
            }
            Button component = base.transform.Find("Rewards").Find(text2).Find("Open").Find("JokerLevelButton").GetComponent<Button>();
            component.MethodToCall.SetMethod(base.gameObject.GetComponent<LevelComplete>(), "LoadJokerLevel", currentRowJokerLevel.sceneName);
            component.transform.Find("LevelNumber").GetComponent<TextMesh>().text = text;
            string currentLevelIdentifier = Singleton<GameManager>.Instance.CurrentLevelIdentifier;
            this.SendUnlockedBonusLevelFlurryEvent(currentLevelIdentifier, Singleton<GameManager>.Instance.CurrentEpisodeLabel + "-" + text);
            base.StartCoroutine(this.ShowUnlockedLevel(delay, text2));
        }
        else if (this.m_unlockedRaceLevelPart != BasePart.PartType.Unknown)
        {
            delay += 0.5f;
            base.StartCoroutine(this.ShowUnlockedRaceLevelPart(delay + 1f));
            delay += 0.5f;
        }
        else if (this.m_unlockedPart != BasePart.PartType.Unknown)
        {
            delay += 0.5f;
            base.StartCoroutine(this.ShowUnlockedPart(delay + 1f));
            delay += 0.5f;
        }
        else
        {
            if (!this.m_sandboxUnlocked)
            {
                return false;
            }
            Button component2 = base.transform.Find("Rewards/SandboxUnlock/Open/Sandbox").GetComponent<Button>();
            component2.MethodToCall.SetMethod(base.gameObject.GetComponent<LevelComplete>(), "LoadSandboxLevelSelection");
            base.StartCoroutine(this.ShowUnlockedSandbox(delay + 1f));
        }
        return true;
    }

    private void CheckLevelEndAchievements()
    {
        for (int i = 0; i < Singleton<GameManager>.Instance.gameData.m_episodeLevels.Count; i++)
        {
            if (Singleton<GameManager>.Instance.gameData.m_episodeLevels[i].Name == Singleton<GameManager>.Instance.CurrentEpisode)
            {
                if (Singleton<GameManager>.Instance.IsLastLevelInEpisode() && Singleton<GameManager>.Instance.gameData.m_episodeLevels[i].ClearAchievement != null)
                {
                    Singleton<SocialGameManager>.Instance.ReportAchievementProgress(Singleton<GameManager>.Instance.gameData.m_episodeLevels[i].ClearAchievement, 100.0);
                }
                if (Singleton<GameManager>.Instance.CurrentEpisodeThreeStarredNormalLevels() && Singleton<GameManager>.Instance.gameData.m_episodeLevels[i].ThreeStarAchievement != null)
                {
                    Singleton<SocialGameManager>.Instance.ReportAchievementProgress(Singleton<GameManager>.Instance.gameData.m_episodeLevels[i].ThreeStarAchievement, 100.0);
                }
                if (Singleton<GameManager>.Instance.CurrentEpisodeThreeStarredSpecialLevels() && Singleton<GameManager>.Instance.gameData.m_episodeLevels[i].SpecialThreeStarAchievement != null)
                {
                    Singleton<SocialGameManager>.Instance.ReportAchievementProgress(Singleton<GameManager>.Instance.gameData.m_episodeLevels[i].SpecialThreeStarAchievement, 100.0);
                }
            }
        }
        Action<List<string>> action;
        if (WPFMonoBehaviour.levelManager.IsPartTransported(BasePart.PartType.KingPig))
        {
            int n = GameProgress.GetInt("Transported_Kings", 0, GameProgress.Location.Local, null);
            n++;
            GameProgress.SetInt("Transported_Kings", n, GameProgress.Location.Local);
            action = delegate (List<string> achievements)
            {
                foreach (string achievementId in achievements)
                {
                    if (Singleton<SocialGameManager>.Instance.TryReportAchievementProgress(achievementId, 100.0, (int limit) => n >= limit))
                    {
                        break;
                    }
                }
            };
            action(new List<string>
            {
                "grp.HOGFFEUR",
                "grp.PIGSHAW"
            });
        }
        if (WPFMonoBehaviour.levelManager.IsPartTransported(BasePart.PartType.Pumpkin))
        {
            int num = GameProgress.GetInt("Transported_Pumpkins", 0, GameProgress.Location.Local, null);
            num++;
            GameProgress.SetInt("Transported_Pumpkins", num, GameProgress.Location.Local);
            Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.PUMPKIN_CHARIOT", 100.0);
        }
        if (!WPFMonoBehaviour.levelManager.ContraptionRunning.IsBroken())
        {
            int n = GameProgress.GetInt("Perfect_Completions", 0, GameProgress.Location.Local, null);
            n++;
            GameProgress.SetInt("Perfect_Completions", n, GameProgress.Location.Local);
            Singleton<SocialGameManager>.Instance.TryReportAchievementProgress("grp.SKILLED_PILOT", 100.0, (int limit) => n >= limit);
        }
        int partCount = WPFMonoBehaviour.levelManager.ContraptionProto.GetPartCount(BasePart.PartType.TNT);
        int partCount2 = WPFMonoBehaviour.levelManager.ContraptionProto.GetPartCount(BasePart.PartType.Pig);
        int partCount3 = WPFMonoBehaviour.levelManager.ContraptionProto.GetPartCount(BasePart.PartType.KingPig);
        if (partCount + partCount2 + partCount3 >= WPFMonoBehaviour.levelManager.ContraptionProto.Parts.Count && partCount >= 1)
        {
            Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.PORCINE_CANNONBALL", 100.0);
        }
        if (WPFMonoBehaviour.levelManager.ContraptionProto.FindPig().enclosedInto == null)
        {
            Singleton<SocialGameManager>.Instance.ReportAchievementProgress("grp.THINK_OUTSIDE_THE_BOX", 100.0);
        }
        Pig pig = WPFMonoBehaviour.levelManager.ContraptionRunning.FindPig() as Pig;
        float traveledDistance = pig.traveledDistance;
        float rolledDistance = pig.rolledDistance;
        GameProgress.SetFloat("traveledDistance", traveledDistance, GameProgress.Location.Local);
        GameProgress.SetFloat("rolledDistance", rolledDistance, GameProgress.Location.Local);
        action = delegate (List<string> achievements)
        {
            foreach (string achievementId in achievements)
            {
                if (Singleton<SocialGameManager>.Instance.TryReportAchievementProgress(achievementId, 100.0, (int limit) => traveledDistance > (float)limit))
                {
                    break;
                }
            }
        };
        action(new List<string>
        {
            "grp.TOURIST_III",
            "grp.TOURIST_II",
            "grp.TOURIST_I"
        });
        action = delegate (List<string> achievements)
        {
            foreach (string achievementId in achievements)
            {
                if (Singleton<SocialGameManager>.Instance.TryReportAchievementProgress(achievementId, 100.0, (int limit) => rolledDistance > (float)limit))
                {
                    break;
                }
            }
        };
        action(new List<string>
        {
            "grp.ROLLING_LOW_III",
            "grp.ROLLING_LOW_II",
            "grp.ROLLING_LOW_I"
        });
    }

    private void LevelCompletedForFirstTime()
    {
        if (WPFMonoBehaviour.levelManager)
        {
            foreach (LevelManager.PartCount partCount in WPFMonoBehaviour.levelManager.m_partsToUnlockOnCompletion)
            {
                GameProgress.AddSandboxParts(partCount.type, partCount.count, true);
                this.m_unlockedPart = partCount.type;
            }
            string sandboxToOpenForCurrentLevel = Singleton<GameManager>.Instance.SandboxToOpenForCurrentLevel;
            if (sandboxToOpenForCurrentLevel != string.Empty)
            {
                GameProgress.SetSandboxUnlocked(sandboxToOpenForCurrentLevel, true);
                GameProgress.UnlockButton("EpisodeButtonSandbox");
                this.m_sandboxUnlocked = true;
            }
            if (Singleton<GameManager>.Instance.CurrentEpisodeType == GameManager.EpisodeType.Race && Singleton<GameManager>.Instance.HasNextLevel())
            {
                GameProgress.SetRaceLevelUnlocked(Singleton<GameManager>.Instance.NextRaceLevel(), true);
            }
        }
        LevelComplete.SendLevelFirstCompleted();
    }

    private void OnDestroy()
    {
    }

    private void SetNextLevelButtons()
    {
        if (this.m_controlsPanel == null)
        {
            return;
        }
        string[] names = Enum.GetNames(typeof(NextButtonState));
        Transform[] array = new Transform[names.Length];
        NextButtonState nextButtonState = LevelComplete.NextButtonState.None;
        if (Singleton<GameManager>.Instance.HasCutScene())
        {
            nextButtonState = LevelComplete.NextButtonState.CutsceneButton;
        }
        else if (Singleton<GameManager>.Instance.HasNextLevel())
        {
            nextButtonState = LevelComplete.NextButtonState.NextLevelButton;
        }
        for (int i = 0; i < names.Length; i++)
        {
            Transform transform = this.m_controlsPanel.transform.Find("ButtonList/" + names[i]);
            array[i] = transform;
            if (transform != null)
            {
                transform.gameObject.SetActive(nextButtonState == (NextButtonState)i);
            }
        }
        if (nextButtonState != LevelComplete.NextButtonState.NextLevelButton)
        {
            if (nextButtonState == LevelComplete.NextButtonState.CutsceneButton)
            {
                if (array[(int)nextButtonState] != null)
                {
                    if (Singleton<GameManager>.Instance.LevelCount <= 15)
                    {
                        array[(int)nextButtonState].gameObject.SetActive(false);
                        return;
                    }
                    if (Singleton<GameManager>.Instance.IsLastLevelInEpisode())
                    {
                        array[(int)nextButtonState].GetComponent<Button>().MethodToCall.SetMethod(this, "LoadEndingCutscene");
                        if (Singleton<BuildCustomizationLoader>.Instance.IsChina && GameProgress.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_stars", 0, GameProgress.Location.Local, null) != 3)
                        {
                            array[(int)nextButtonState].gameObject.SetActive(false);
                            return;
                        }
                        GameProgress.SetInt(Singleton<GameManager>.Instance.EndingCutscene + "_played", 1, GameProgress.Location.Local);
                    }
                    else if (Singleton<GameManager>.Instance.HasMidCutsceneEnabled())
                    {
                        array[(int)nextButtonState].GetComponent<Button>().MethodToCall.SetMethod(this, "LoadMidCutscene");
                        if (Singleton<BuildCustomizationLoader>.Instance.IsChina && GameProgress.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_stars", 0, GameProgress.Location.Local, null) != 3)
                        {
                            array[(int)nextButtonState].gameObject.SetActive(false);
                            return;
                        }
                        GameProgress.SetInt(Singleton<GameManager>.Instance.MidCutscene + "_played", 1, GameProgress.Location.Local);
                    }
                    array[(int)nextButtonState].position -= Vector3.forward * 8f;
                }
            }
        }
    }

    private void ShowUnlockLevelRewardButton(Transform[] buttons)
    {
        buttons[2].localPosition -= Vector3.up * 4f;
        if (buttons[2] != null && WPFMonoBehaviour.gameData.m_unlockLevelAdButtonPrefab != null)
        {
            GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(WPFMonoBehaviour.gameData.m_unlockLevelAdButtonPrefab);
            gameObject.transform.parent = buttons[2];
            gameObject.transform.localPosition = -Vector3.forward * 2f;
        }
    }

    private IEnumerator ShowUnlockedLevel(float delay, string rewardBonusLevelName)
    {
        yield return new WaitForSeconds(delay);
        Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.jokerLevelUnlocked);
        RewardView part = GameObject.Find("Rewards").transform.Find("UnlockPart").GetComponent<RewardView>();
        part.Hide();
        RewardView reward = GameObject.Find("Rewards").transform.Find(rewardBonusLevelName).GetComponent<RewardView>();
        if (reward.HasLocked())
        {
            reward.ShowLocked();
            GameObject.Find("Rewards").GetComponent<Animation>().Play("RewardAnimation");
            yield return new WaitForSeconds(0.75f);
        }
        reward.transform.FindChildRecursively("JokerLevelButton").transform.Find("Lock").GetComponent<Animation>().Play("LevelCompleteLockAnimation");
        yield return new WaitForSeconds(0.75f);
        foreach (ParticleSystem particleSystem in GameObject.Find(rewardBonusLevelName).transform.Find("Open").GetComponentsInChildren<ParticleSystem>())
        {
            particleSystem.Play();
        }
        reward.ShowOpen();
        GameObject.Find("PigLevelCompleteBL").GetComponent<Animation>().wrapMode = WrapMode.Loop;
        GameObject.Find("PigLevelCompleteBL").GetComponent<Animation>().Play("PigLevelCompleteAnimation");
        GameObject.Find("Pig_ShadowBL").GetComponent<Animation>().wrapMode = WrapMode.Loop;
        GameObject.Find("Pig_ShadowBL").GetComponent<Animation>().Play("LevelCompleteShadowAnimation");
        yield break;
    }

    public void ResumeAnimations()
    {
        this.SetNextLevelButtons();
        int @int = GameProgress.GetInt(Singleton<GameManager>.Instance.CurrentSceneName + "_stars", 0, GameProgress.Location.Local, null);
        if (!GameProgress.IsChallengeCompleted(Singleton<GameManager>.Instance.CurrentSceneName, this.m_challenges[0].ChallengeNumber))
        {
            this.m_starTwo.GetComponent<Renderer>().enabled = false;
        }
        if (!GameProgress.IsChallengeCompleted(Singleton<GameManager>.Instance.CurrentSceneName, this.m_challenges[1].ChallengeNumber))
        {
            this.m_starThree.GetComponent<Renderer>().enabled = false;
        }
        if (!this.m_jokerLevelUnlocked && this.m_unlockedPart == BasePart.PartType.Unknown && this.m_unlockedRaceLevelPart == BasePart.PartType.Unknown && !this.m_sandboxUnlocked)
        {
            base.StartCoroutine(this.ShowLonelyPig(0f, @int, false));
        }
    }

    private IEnumerator ShowLonelyPig(float delay, int stars, bool bPlayRewardAnim = true)
    {
        yield return new WaitForSeconds(delay);
        Transform lonePig = base.transform.Find("Rewards/Pig/LonePig");
        Transform lp = base.transform.Find("Rewards/Pig/LonePig/LonePig1Star");
        Transform lp2 = base.transform.Find("Rewards/Pig/LonePig/LonePig2Star");
        Transform lp3 = base.transform.Find("Rewards/Pig/LonePig/LonePig3Star");
        ParticleSystem[] ps = base.transform.Find("Rewards/Pig/LonelyPigParticles").GetComponentsInChildren<ParticleSystem>();
        lonePig.GetComponent<Renderer>().enabled = true;
        lp.GetComponent<Renderer>().enabled = (stars == 1);
        lp2.GetComponent<Renderer>().enabled = (stars == 2);
        lp3.GetComponent<Renderer>().enabled = (stars == 3);
        if (bPlayRewardAnim)
        {
            base.transform.Find("Rewards").GetComponent<Animation>().Play("RewardAnimation");
            yield return new WaitForSeconds(0.65f);
        }
        if (stars >= 2)
        {
            foreach (ParticleSystem particleSystem in ps)
            {
                particleSystem.Play();
            }
        }
        yield return new WaitForSeconds(0.1f);
        if (stars == 1)
        {
            lp.GetComponent<Animation>().Play("LevelCompleteLonePig1Star");
        }
        else if (stars == 2)
        {
            lp2.GetComponent<Animation>().Play("LevelCompleteLonePig1Star");
        }
        else
        {
            lonePig.GetComponent<Animation>().Play("PigLevelCompleteAnimation");
            lp3.GetComponent<Animation>().Play("LevelCompleteLonePig1Star");
            yield return new WaitForSeconds(0.73f);
            for (; ; )
            {
                foreach (ParticleSystem particleSystem2 in ps)
                {
                    particleSystem2.Play();
                }
                yield return new WaitForSeconds(0.7f);
            }
        }
        yield break;
    }

    private void ShowDessertButton()
    {
        Transform transform = base.transform.FindChildRecursively("KingPigFeedButton");
        transform.gameObject.SetActive(WPFMonoBehaviour.levelManager.m_CollectedDessertsCount > 0);
        Transform transform2 = transform.Find("DessertReward");
        string text = "+" + WPFMonoBehaviour.levelManager.m_CollectedDessertsCount.ToString();
        transform2.Find("Icon/Text").GetComponent<TextMesh>().text = text;
        transform2.Find("Icon/Shadow").GetComponent<TextMesh>().text = text;
    }

    private IEnumerator ShowUnlockedSandbox(float delay)
    {
        yield return new WaitForSeconds(delay);
        Singleton<AudioManager>.Instance.Play2dEffect(WPFMonoBehaviour.gameData.commonAudioCollection.sandboxLevelUnlocked);
        RewardView part = GameObject.Find("Rewards").transform.Find("UnlockPart").GetComponent<RewardView>();
        part.Hide();
        RewardView reward = GameObject.Find("Rewards").transform.Find("SandboxUnlock").GetComponent<RewardView>();
        if (reward.HasLocked())
        {
            reward.ShowLocked();
            GameObject.Find("Rewards").GetComponent<Animation>().Play("RewardAnimation");
            yield return new WaitForSeconds(0.75f);
        }
        GameObject.Find("Sandbox").transform.Find("Lock").GetComponent<Animation>().Play("LevelCompleteLockAnimation");
        yield return new WaitForSeconds(0.6f);
        foreach (ParticleSystem particleSystem in GameObject.Find("SandboxUnlock").transform.Find("Open").GetComponentsInChildren<ParticleSystem>())
        {
            particleSystem.Play();
        }
        reward.ShowOpen();
        GameObject.Find("PigLevelCompleteSB").GetComponent<Animation>().wrapMode = WrapMode.Loop;
        GameObject.Find("PigLevelCompleteSB").GetComponent<Animation>().Play("PigLevelCompleteAnimation");
        GameObject.Find("Pig_ShadowSB").GetComponent<Animation>().wrapMode = WrapMode.Loop;
        GameObject.Find("Pig_ShadowSB").GetComponent<Animation>().Play("LevelCompleteShadowAnimation");
        yield break;
    }

    private IEnumerator ShowUnlockedPart(float delay)
    {
        yield return new WaitForSeconds(delay);
        RewardView reward = GameObject.Find("Rewards").transform.Find("UnlockPart").GetComponent<RewardView>();
        reward.ShowOpen();
        reward.SetPart(this.m_unlockedPart);
        GameObject.Find("Rewards").GetComponent<Animation>().Play("RewardAnimation");
        GameObject.Find("PigLevelComplete").GetComponent<Animation>().wrapMode = WrapMode.Loop;
        GameObject.Find("PigLevelComplete").GetComponent<Animation>().Play("PigLevelCompleteAnimation");
        GameObject.Find("Pig_Shadow").GetComponent<Animation>().wrapMode = WrapMode.Loop;
        GameObject.Find("Pig_Shadow").GetComponent<Animation>().Play("LevelCompleteShadowAnimation");
        yield break;
    }

    private IEnumerator ShowUnlockedRaceLevelPart(float delay)
    {
        yield return new WaitForSeconds(delay);
        RewardView reward = GameObject.Find("Rewards").transform.Find("UnlockRaceLevelPart").GetComponent<RewardView>();
        reward.ShowOpen();
        reward.SetPart(this.m_unlockedRaceLevelPart);
        if (this.m_raceLevelNumber != null)
        {
            reward.transform.Find("Open/RaceLevelButton/LevelNumber").GetComponent<TextMesh>().text = this.m_raceLevelNumber.m_levelNumber;
            reward.transform.Find("Open/RaceLevelButton").GetComponent<Button>().MethodToCall.SetParameter(this.m_raceLevelNumber.m_identifier);
        }
        GameObject.Find("Rewards").GetComponent<Animation>().Play("RewardAnimation");
        GameObject.Find("PigLevelComplete").GetComponent<Animation>().wrapMode = WrapMode.Loop;
        GameObject.Find("PigLevelComplete").GetComponent<Animation>().Play("PigLevelCompleteAnimation");
        GameObject.Find("Pig_Shadow").GetComponent<Animation>().wrapMode = WrapMode.Loop;
        GameObject.Find("Pig_Shadow").GetComponent<Animation>().Play("LevelCompleteShadowAnimation");
        yield break;
    }

    private IEnumerator ShowStarPanel(float delay)
    {
        yield return new WaitForSeconds(delay);
        float t = 0f;
        while (t < 1f)
        {
            t = Mathf.Min(t + Time.deltaTime / 0.3f, 1f);
            this.m_starPanel.transform.position = Vector3.Slerp(this.m_starPanelHidePosition, this.m_starPanelPosition, t);
            yield return 0;
        }
        yield break;
    }

    private IEnumerator ShowBackground(float delay1, float delay2)
    {
        yield return new WaitForSeconds(delay1);
        if (!WPFMonoBehaviour.levelManager || WPFMonoBehaviour.levelManager.m_raceLevel)
        {
            this.m_backgroundPosition.y = this.m_backgroundPosition.y - 1.6f;
        }
        float t = 0f;
        while (t < 1f)
        {
            t = Mathf.Min(t + Time.deltaTime / 0.3f, 1f);
            this.m_background.transform.position = Vector3.Slerp(this.m_backgroundHidePosition, this.m_backgroundPosition, t);
            yield return 0;
        }
        if (!WPFMonoBehaviour.levelManager || WPFMonoBehaviour.levelManager.m_raceLevel)
        {
            this.m_backgroundPosition.y = this.m_backgroundPosition.y + 1.6f;
        }
        yield return new WaitForSeconds(delay2);
        this.m_backgroundHidePosition = this.m_backgroundPosition;
        this.m_backgroundPosition.y = this.m_backgroundPosition.y - 12.5f;
        t = 0f;
        while (t < 1f)
        {
            t = Mathf.Min(t + Time.deltaTime / 0.3f, 1f);
            this.m_background.transform.position = Vector3.Slerp(this.m_backgroundHidePosition, this.m_backgroundPosition, t);
            yield return 0;
        }
        yield break;
    }

    private IEnumerator ShowControls(float delay)
    {
        this.SetNextLevelButtons();
        yield return new WaitForSeconds(delay);
        float t = 0f;
        while (t < 1f)
        {
            t = Mathf.Min(t + Time.deltaTime / 0.25f, 1f);
            this.m_controlsPanel.transform.position = Vector3.Slerp(this.m_controlsHidePosition, this.m_controlsPosition, t);
            yield return 0;
        }
        if (!this.m_hasDoubleRewards)
        {
            this.UpdateScreenPlacements(this.doubleRewardAnimation.transform.parent.gameObject);
            this.doubleRewardButton.gameObject.SetActive(true);
            this.doubleRewardButton.Show();
        }
        this.m_objectiveOne.GetComponent<Collider>().enabled = true;
        this.m_objectiveTwo.GetComponent<Collider>().enabled = true;
        this.m_objectiveThree.GetComponent<Collider>().enabled = true;
        if (SnoutButton.Instance != null)
        {
            SnoutButton.Instance.EnableButton(true);
        }
        yield break;
    }

    private void UpdateScreenPlacements(GameObject target)
    {
        ScreenPlacement[] componentsInChildren = target.GetComponentsInChildren<ScreenPlacement>();
        for (int i = 0; i < componentsInChildren.Length; i++)
        {
            componentsInChildren[i].gameObject.SetActive(false);
            componentsInChildren[i].gameObject.SetActive(true);
        }
    }

    private IEnumerator ShowEpisodeThreeStarred(float delay)
    {
        yield return new WaitForSeconds(delay);
        string episode = Singleton<GameManager>.Instance.CurrentEpisode;
        int episodeIndex = Singleton<GameManager>.Instance.CurrentEpisodeIndex;
        if (episode != string.Empty && Singleton<GameManager>.Instance.CurrentEpisodeThreeStarred() && !GameProgress.IsEpisodeThreeStarred(episode))
        {
            GameProgress.SetEpisodeThreeStarred(episode, true);
            this.m_episodeThreeStarStamp.GetComponent<Animation>().Play();
            GameObject gameObject = (!(episode == "RaceLevelSelection")) ? UnityEngine.Object.Instantiate<GameObject>(this.episodeTitles[episodeIndex]) : UnityEngine.Object.Instantiate<GameObject>(this.roadHogsTitle);
            gameObject.transform.parent = this.m_episodeThreeStarStamp.transform;
            gameObject.transform.localPosition = new Vector3(0f, 0.345f, 0f);
            gameObject.transform.rotation = Quaternion.identity;
        }
        yield break;
    }

    private IEnumerator PlayStarEffects(ObjectiveSlot objective, GameObject star, Challenge challenge, float delay, AudioSource starAudio, string anim)
    {
        yield return new WaitForSeconds(delay);
        base.StartCoroutine(this.PlayStarEffects(objective, star, 0.25f, starAudio, anim));
        yield break;
    }

    private IEnumerator ShakeCamera(float power)
    {
        GameObject go = GameObject.Find("CameraSystem");
        this.bShakeCamera = true;
        Vector3 originalPos = go.transform.position;
        while (this.bShakeCamera)
        {
            Vector2 newPosition = UnityEngine.Random.insideUnitCircle * power;
            Vector3 pos = go.transform.position;
            go.transform.position = new Vector3(pos.x + newPosition.x * Time.deltaTime, pos.y + newPosition.y * Time.deltaTime, pos.z);
            yield return new WaitForEndOfFrame();
        }
        go.transform.position = originalPos;
        yield break;
    }

    private IEnumerator PlayStarEffects(ObjectiveSlot objective, GameObject star, float delay, AudioSource starAudio, string anim)
    {
        yield return new WaitForSeconds(delay);
        star.SetActive(true);
        star.GetComponent<Animation>().Play(anim);
        yield return new WaitForSeconds(0.5f);
        Singleton<AudioManager>.Instance.Play2dEffect(starAudio);
        base.StartCoroutine(this.ShakeCamera(16f));
        foreach (ParticleSystem particleSystem in star.GetComponentsInChildren<ParticleSystem>())
        {
            particleSystem.Play();
        }
        yield return new WaitForSeconds(0.1f);
        objective.SetSucceeded();
        yield return new WaitForSeconds(0.2f);
        this.bShakeCamera = false;
        yield break;
    }

    private IEnumerator PlayOldStarEffects(ObjectiveSlot objective, GameObject star, float delay, bool completedInThisRun, AudioSource starAudio, string anim)
    {
        if (completedInThisRun)
        {
            yield return new WaitForSeconds(delay);
            star.SetActive(true);
            star.GetComponent<Animation>().Play(anim);
            yield return new WaitForSeconds(0.5f);
            if (starAudio)
            {
                Singleton<AudioManager>.Instance.Play2dEffect(starAudio);
            }
            base.StartCoroutine(this.ShakeCamera(16f));
            foreach (ParticleSystem particleSystem in star.GetComponentsInChildren<ParticleSystem>())
            {
                particleSystem.Play();
            }
            yield return new WaitForSeconds(0.1f);
            objective.SetSucceeded();
            yield return new WaitForSeconds(0.2f);
            this.bShakeCamera = false;
        }
        else
        {
            star.SetActive(true);
        }
        yield break;
    }

    private IEnumerator StartMusic(float delay, AudioSource music)
    {
        yield return new WaitForSeconds(delay);
        WPFMonoBehaviour.levelManager.StopAmbient();
        this.m_music = Singleton<AudioManager>.Instance.SpawnLoopingEffect(music, base.transform);
        yield break;
    }

    public void LoadJokerLevel(string levelName)
    {
        this.SendSpecialLevelEnteredFlurryEvent(Singleton<GameManager>.Instance.CurrentLevelIdentifier, levelName);
        Singleton<GameManager>.Instance.LoadStarLevelTransition(levelName);
    }

    public void LoadSandboxLevelSelection(string levelName)
    {
        this.SendSpecialLevelEnteredFlurryEvent(Singleton<GameManager>.Instance.CurrentLevelIdentifier, "0");
        Singleton<GameManager>.Instance.LoadSandboxLevelSelection();
    }

    public void LoadRaceLevel(string identifier)
    {
        this.SendSpecialLevelEnteredFlurryEvent(Singleton<GameManager>.Instance.CurrentLevelIdentifier, identifier);
        if (Bundle.IsBundleLoaded("Episode_Race_Levels"))
        {
            Singleton<GameManager>.Instance.LoadRaceLevelFromLevelCompleteMenu(identifier);
        }
        else
        {
            base.StartCoroutine(this.LoadRaceLevelDelayed(identifier));
        }
    }

    private IEnumerator LoadRaceLevelDelayed(string identifier)
    {
        if (!Bundle.IsBundleLoaded("Episode_Race_Levels"))
        {
            Bundle.LoadBundleAsync("Episode_Race_Levels", null);
        }
        while (!Bundle.IsBundleLoaded("Episode_Race_Levels"))
        {
            yield return null;
        }
        Singleton<GameManager>.Instance.LoadRaceLevelFromLevelCompleteMenu(identifier);
        yield break;
    }

    public void LoadEndingCutscene()
    {
        Singleton<GameManager>.Instance.LoadEndingCutscene();
    }

    public void LoadMidCutscene()
    {
        Singleton<GameManager>.Instance.LoadMidCutscene(false);
    }

    public void OpenUnlockFullVersionPurchasePage()
    {
        if (Singleton<BuildCustomizationLoader>.Instance.IAPEnabled)
        {
            Singleton<IapManager>.Instance.EnableUnlockFullVersionPurchasePage();
        }
    }

    public void SendUnlockedBonusLevelFlurryEvent(string played_id, string unlocked_id)
    {
    }

    public void SendUnlockedRaceLevelPartFlurryEvent(string played_level_id, string race_level_id, string part_id)
    {
    }

    public void SendSpecialLevelEnteredFlurryEvent(string played_level_id, string target_id)
    {
    }

    private static void SendLevelCompleteEvent(string previousStars, string newStars)
    {
    }

    private static void SendLevelFirstCompleted()
    {
    }

    private const string RACELEVEL_BUNDLE = "Episode_Race_Levels";

    [SerializeField]
    private GameObject m_starOne;

    [SerializeField]
    private GameObject m_starTwo;

    [SerializeField]
    private GameObject m_starThree;

    private GoalChallenge m_goal;

    private List<Challenge> m_challenges = new List<Challenge>();

    [SerializeField]
    private ObjectiveSlot m_objectiveOne;

    [SerializeField]
    private ObjectiveSlot m_objectiveTwo;

    [SerializeField]
    private ObjectiveSlot m_objectiveThree;

    [SerializeField]
    private GameObject m_controlsPanel;

    private Vector3 m_controlsPosition;

    [SerializeField]
    private GridLayout m_buttonGridLayout;

    private Vector3 m_hintHidePosition;

    private Vector3 m_hintPosition;

    private Vector3 m_controlsHidePosition;

    [SerializeField]
    private GameObject m_starPanel;

    private Vector3 m_starPanelPosition;

    private Vector3 m_starPanelHidePosition;

    [SerializeField]
    private GameObject m_background;

    private Vector3 m_backgroundPosition;

    private Vector3 m_backgroundHidePosition;

    private BasePart.PartType m_unlockedPart;

    private BasePart.PartType m_unlockedRaceLevelPart;

    private RaceLevels.LevelUnlockablePartsData m_raceLevelNumber;

    private bool m_sandboxUnlocked;

    [SerializeField]
    private GameObject m_episodeThreeStarStamp;

    private GameObject m_music;

    private bool m_jokerLevelUnlocked;

    private bool m_hasDoubleRewards;

    private bool challenge1CoinsCollected;

    private CoinsCollected coinsCollected;

    [SerializeField]
    private GameObject[] episodeTitles;

    [SerializeField]
    private GameObject roadHogsTitle;

    [SerializeField]
    private DoubleRewardButton doubleRewardButton;

    [SerializeField]
    private SkeletonAnimation doubleRewardAnimation;

    [SerializeField]
    private ExtraCoinsRewardButton extraCoinsRewardButton;

    private bool bShakeCamera;

    public GameObject homeButton;

    private float originalHomeButtonX;

    public GameObject controlsPanel;

    public GameObject rewardVideoButton;

    private float originalBackgroundScaleX;

    private bool hasTransformed;

    public GameObject pigFeedButton;

    [Flags]
    public enum CoinsCollected
    {
        None = 0,
        Challenge1 = 1,
        Challenge2 = 2,
        Challenge3 = 4
    }

    private enum NextButtonState
    {
        NextLevelButton,
        CutsceneButton,
        UnlockNextLevelButton,
        None
    }
}
