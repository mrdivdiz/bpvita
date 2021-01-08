using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameCenterManager : MonoBehaviour, ISocialProvider
{
    public static event Action<bool> onAuthenticationSucceeded;

    public Dictionary<string, AchievementDataStruct> Achievements
    {
        get
        {
            return this.m_achievementList;
        }
    }

    public bool Authenticated
    {
        get
        {
            return Social.localUser.authenticated;
        }
    }

    private void Awake()
    {
        SocialGameManager.RegisterProvider(this);
    }

    private void Start()
    {
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.m_achievementPopup.gameObject);
        this.m_achievementPopup = gameObject.GetComponent<AchievementPopup>();
    }

    private void OnEnable()
    {
        EventManager.Connect(new EventManager.OnEvent<LevelLoadedEvent>(this.ReceiveLevelLoadedEvent));
    }

    private void OnDisable()
    {
        EventManager.Disconnect(new EventManager.OnEvent<LevelLoadedEvent>(this.ReceiveLevelLoadedEvent));
    }

    private void ReceiveLevelLoadedEvent(LevelLoadedEvent data)
    {
        if (!this.m_started && data.currentGameState == GameManager.GameState.MainMenu)
        {
            this.m_started = true;
            base.StartCoroutine(this.WaitForInterstitialToClose());
        }
    }

    private IEnumerator WaitForInterstitialToClose()
    {
        this.Authenticate();
        base.StartCoroutine(this.SyncAchievementData());
        yield break;
    }

    public void Authenticate()
    {
        Social.localUser.Authenticate(new Action<bool>(this.AuthenticationSucceeded));
    }

    public void ShowAchievementsView()
    {
        if (this.Authenticated && !Application.isEditor)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            this.Authenticate();
        }
    }

    public void ShowLeaderboardsView()
    {
        if (this.Authenticated && !Application.isEditor)
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            this.Authenticate();
        }
    }

    public void LoadAchievements()
    {
        if (this.Authenticated && !Application.isEditor)
        {
            Social.LoadAchievements(new Action<IAchievement[]>(this.AchievementsDidLoad));
        }
    }

    public void LoadLeaderboardScores()
    {
        if (this.Authenticated && !Application.isEditor)
        {
            foreach (string id in this.m_leaderboardIDs)
            {
                ILeaderboard lb = Social.CreateLeaderboard();
                lb.id = id;
                lb.LoadScores(delegate (bool result)
                {
                    LeaderboardDataStruct value = default(LeaderboardDataStruct);
                    value.title = lb.title;
                    value.rank = lb.localUserScore.rank;
                    long.TryParse(lb.localUserScore.formattedValue, out value.score);
                    this.m_leaderboardList.Add(lb.id, value);
                });
            }
        }
    }

    public void LoadScoreForLeaderboard(string leaderboardId)
    {
    }

    public void ReportAchievementProgress(string achievementId, double progress)
    {
        if (this.Authenticated && !Application.isEditor)
        {
            AchievementQueueBlock item;
            item.id = achievementId;
            item.progress = progress;
            AchievementData.AchievementDataHolder achievement = Singleton<AchievementData>.Instance.GetAchievement(achievementId);
            achievement.progress = ((progress <= achievement.progress) ? achievement.progress : progress);
            achievement.completed = (progress >= 100.0);
            Singleton<AchievementData>.Instance.SetAchievement(achievementId, achievement);
            this.m_achievementsQueue.Add(item);
        }
    }

    public void ReportLeaderboardScore(string leaderboardId, long score, Action<bool> handler)
    {
        if (this.Authenticated && !Application.isEditor)
        {
            Social.ReportScore(score, leaderboardId, handler);
        }
    }

    public void ResetAchievementData()
    {
    }

    public void SyncAllAchievementsNow()
    {
        Dictionary<string, double> achievementsProgress = Singleton<AchievementData>.Instance.AchievementsProgress;
        foreach (KeyValuePair<string, double> keyValuePair in achievementsProgress)
        {
            if (keyValuePair.Value > 0.0)
            {
                this.ReportAchievementProgress(keyValuePair.Key, keyValuePair.Value);
            }
        }
    }

    public bool ViewsActive()
    {
        return false;
    }

    public void CloseViews()
    {
    }

    private void AchievementsDidLoad(IAchievement[] achievementsList)
    {
        foreach (IAchievement achievement in achievementsList)
        {
            AchievementDataStruct value = default(AchievementDataStruct);
            value.percentComplete = achievement.percentCompleted;
            value.completed = achievement.completed;
            value.hidden = achievement.hidden;
            this.m_achievementList.Add(achievement.id, value);
        }
        Social.LoadAchievementDescriptions(new Action<IAchievementDescription[]>(this.AchievementDescriptionsDidLoad));
    }

    private void AchievementDescriptionsDidLoad(IAchievementDescription[] achievementsList)
    {
        foreach (IAchievementDescription achievementDescription in achievementsList)
        {
            AchievementDataStruct achievementDataStruct = this.Achievements[achievementDescription.id];
            achievementDataStruct.title = achievementDescription.title;
            achievementDataStruct.description = achievementDescription.achievedDescription;
        }
    }

    private void AchievementReportDidComplete(bool success)
    {
        if (this.m_achievementsQueue.Count <= 0)
        {
            return;
        }
        if (!this.m_achievementsQueue[0].id.Equals(this.m_currentlySyncing))
        {
            return;
        }
        if (success)
        {
            AchievementData.AchievementDataHolder achievement = Singleton<AchievementData>.Instance.GetAchievement(this.m_achievementsQueue[0].id);
            if (this.m_achievementsQueue[0].progress >= 100.0 && !achievement.synced)
            {
                this.m_achievementPopup.Show(this.m_achievementsQueue[0].id);
                achievement.synced = true;
                Singleton<AchievementData>.Instance.SetAchievement(this.m_achievementsQueue[0].id, achievement);
            }
        }
        this.m_currentlySyncing = null;
        this.m_achievementsQueueSemaphore = false;
        this.m_achievementsQueue.RemoveAt(0);
    }

    private void AuthenticationSucceeded(bool success)
    {
        if (success)
        {
            this.SyncAllAchievementsNow();
        }
        if (GameCenterManager.onAuthenticationSucceeded != null)
        {
            GameCenterManager.onAuthenticationSucceeded(success);
        }
    }

    private IEnumerator SyncAchievementData()
    {
        for (; ; )
        {
            if (this.m_achievementsQueue.Count > 0 && !this.m_achievementsQueueSemaphore && string.IsNullOrEmpty(this.m_currentlySyncing))
            {
                this.m_currentlySyncing = this.m_achievementsQueue[0].id;
                this.m_achievementsQueueSemaphore = true;
                Social.ReportProgress(this.m_achievementsQueue[0].id, this.m_achievementsQueue[0].progress, new Action<bool>(this.AchievementReportDidComplete));
            }
            else
            {
                yield return new WaitForSeconds(3f);
            }
        }
        yield break;
    }

    [SerializeField]
    private AchievementPopup m_achievementPopup;

    private Dictionary<string, AchievementDataStruct> m_achievementList = new Dictionary<string, AchievementDataStruct>();

    private Dictionary<string, LeaderboardDataStruct> m_leaderboardList = new Dictionary<string, LeaderboardDataStruct>();

    private List<AchievementQueueBlock> m_achievementsQueue = new List<AchievementQueueBlock>();

    private bool m_achievementsQueueSemaphore;

    private bool m_started;

    private string m_currentlySyncing;

    public List<string> m_leaderboardIDs = new List<string>();

    public struct AchievementQueueBlock
    {
        public string id;

        public double progress;
    }

    public struct AchievementDataStruct
    {
        public string title;

        public string description;

        public double percentComplete;

        public bool completed;

        public bool hidden;
    }

    public struct LeaderboardDataStruct
    {
        public string title;

        public int rank;

        public long score;
    }
}
