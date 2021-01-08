using UnityEngine;

public class RewardVideoButton : WPFMonoBehaviour
{
    private void Awake()
    {
        if (!RewardVideoManager.AddTimeRewardOnLevelStart)
        {
            RewardVideoManager.HadRewardAlready = false;
        }
        EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChange));
    }

    private void Update()
    {
        if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Running && this.updateRunning)
        {
            float num = WPFMonoBehaviour.levelManager.TimeLimit - WPFMonoBehaviour.levelManager.TimeElapsed;
            if (num < 0.3f)
            {
                if (num > 1.401298E-45f)
                {
                    base.transform.localScale = new Vector3(num / 0.3f, num / 0.3f, 1f);
                }
                else
                {
                    this.hideThisSession = true;
                    base.transform.localScale = Vector3.zero;
                    this.updateRunning = false;
                }
            }
        }
    }

    private void AddTime()
    {
        WPFMonoBehaviour.levelManager.AddToTimeLimit((float)RewardVideoManager.TimeToReward);
        RewardVideoManager.AddTimeRewardOnLevelStart = false;
        RewardVideoManager.HadRewardAlready = true;
        this.ShowTimer();
    }

    private void ShowTimer()
    {
        if (this.m_timerCounter)
        {
            this.m_timerCounter.GetComponent<RewardTimeCounter>().GiveReward(true);
        }
    }

    private void ShowButton()
    {
        this.SetTimeToButton();
        base.gameObject.SetActive(true);
    }

    private void SetTimeToButton()
    {
        Transform transform = base.gameObject.transform.Find("TimeRewardCount");
        if (!transform)
        {
            return;
        }
        Transform transform2 = transform.Find("TimeRewardCountShadow");
        if (transform != null && transform2 != null)
        {
            TextMesh component = transform.GetComponent<TextMesh>();
            TextMesh component2 = transform2.GetComponent<TextMesh>();
            if (component != null && component2 != null)
            {
                string text = string.Format(this.m_timeFormat, RewardVideoManager.TimeToReward);
                component.text = text;
                component2.text = text;
            }
        }
    }

    private void ReceiveGameStateChange(GameStateChanged uiEvent)
    {
        LevelManager.GameState state = uiEvent.state;
        if (state == LevelManager.GameState.Building)
        {
            this.hideThisSession = false;
            RewardVideoManager.TimeToReward = 2;
            if (RewardVideoManager.AddTimeRewardOnLevelStart)
            {
                RewardVideoManager.AddTimeRewardOnLevelStart = false;
                RewardVideoManager.HadRewardAlready = true;
                RewardVideoManager.AddTimeRewardCounterOnLevelStart = true;
                if (GameTime.IsPaused())
                {
                    GameTime.Pause(false);
                }
                this.AddTime();
            }
            else if (!base.gameObject.activeInHierarchy && this.IsAllowedToShow())
            {
                this.ShowButton();
            }
        }
    }

    public bool IsAllowedToShow()
    {
        return WPFMonoBehaviour.levelManager.TimeLimit > 0f && !WPFMonoBehaviour.levelManager.m_raceLevel && !RewardVideoManager.HadRewardAlready && !WPFMonoBehaviour.levelManager.IsTimeChallengesCompleted();
    }

    private void OnDestroy()
    {
        EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChange));
        RewardVideoManager.AddTimeRewardCounterOnLevelStart = false;
    }

    public void AddRewardOnRetryLevel()
    {
        if (RewardVideoManager.HadRewardAlready)
        {
            RewardVideoManager.AddTimeRewardOnLevelStart = true;
        }
    }

    public void StartRewardVideo()
    {
        if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Completed)
        {
            if (!base.gameObject.activeInHierarchy)
            {
                return;
            }
            RewardVideoManager.HadRewardAlready = true;
            if (WPFMonoBehaviour.levelManager.gameState == LevelManager.GameState.Completed)
            {
                this.AddRewardOnRetryLevel();
                EventManager.Send(new UIEvent(UIEvent.Type.ReplayLevel));
                return;
            }
            this.AddTime();
            if (this.m_previewMenu)
            {
                PreviewMenu component = this.m_previewMenu.GetComponent<PreviewMenu>();
                if (component)
                {
                    component.UpdateChallenges();
                }
            }
        }
        else
        {
            base.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (!this.hideThisSession)
        {
            base.transform.localScale = Vector3.one;
        }
        this.updateRunning = true;
        if (!this.IsAllowedToShow())
        {
            base.gameObject.SetActive(false);
        }
        if (RewardVideoManager.HadRewardAlready)
        {
            this.ShowTimer();
        }
        this.SetTimeToButton();
    }

    private void Start()
    {
        if (RewardVideoManager.HadRewardAlready)
        {
            this.ShowTimer();
        }
        if (WPFMonoBehaviour.levelManager.TimeLimit <= 1.401298E-45f || WPFMonoBehaviour.levelManager.m_raceLevel || RewardVideoManager.HadRewardAlready || WPFMonoBehaviour.levelManager.IsTimeChallengesCompleted())
        {
            base.gameObject.SetActive(false);
        }
        else
        {
            this.SetTimeToButton();
        }
    }

    public GameObject m_timerCounter;

    public GameObject m_previewMenu;

    public string m_timeFormat;

    private bool hideThisSession;

    private bool updateRunning = true;
}
