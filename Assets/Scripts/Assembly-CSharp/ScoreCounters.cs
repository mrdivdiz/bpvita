using UnityEngine;

public class ScoreCounters : WPFMonoBehaviour
{
	private void Awake()
	{
        EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChangeEvent));
        this.timeCounter = GameObject.Find("ScoreCounters/TimeCounter");
        this.timeText = GameObject.Find("ScoreCounters/TimeCounter/TimeCounter").GetComponent<TextMesh>();
        this.timeTextShadow = GameObject.Find("ScoreCounters/TimeCounter/TimeCounter/TimeCounterShadow").GetComponent<TextMesh>();
        this.rewardTimeCounter = this.rewardTimeCounterObject.GetComponent<RewardTimeCounter>();
    }

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChangeEvent));
	}

	private void ReceiveGameStateChangeEvent(GameStateChanged newState)
	{
		if (newState.state == LevelManager.GameState.Running)
		{
			this.running = true;
		}
		else
		{
			this.running = false;
		}
	}

	private void OnEnable()
	{
		if (WPFMonoBehaviour.levelManager && (WPFMonoBehaviour.levelManager.TimeLimit == 0f || WPFMonoBehaviour.levelManager.m_raceLevel))
		{
			this.timeCounter.SetActive(false);
		}
		else
		{
			this.timeCounter.SetActive(true);
			if (this.rewardTimeCounter.IsActive())
			{
				this.UpdateTime(WPFMonoBehaviour.levelManager.OriginalTimeLimit);
			}
			else
			{
				this.UpdateTime(WPFMonoBehaviour.levelManager.OriginalTimeLimit - WPFMonoBehaviour.levelManager.TimeElapsed);
			}
		}
	}

	private void UpdateTime(float timeLeft)
	{
		timeLeft = Mathf.Clamp(timeLeft, -99.999f, 99.999f);
		string str = " ";
		if (timeLeft < 0f)
		{
			timeLeft = -timeLeft;
			str = "+";
			if (!this.isTimerRed)
			{
				this.timeText.GetComponent<Renderer>().material.color = new Color(1f, 0.4f, 0.4f);
				this.isTimerRed = true;
			}
		}
		else if (this.isTimerRed)
		{
			this.timeText.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
			this.isTimerRed = false;
		}
		int num = (int)timeLeft;
		int num2 = (int)((timeLeft - (float)num) * 1000f) / 10;
		string text = str + num.ToString("D2") + "." + num2.ToString("D2");
		this.timeText.text = text;
		this.timeTextShadow.text = text;
	}

	private void Update()
	{
		if (this.running && this.timeCounter.activeSelf)
		{
			float time = Time.time;
			if (time - this.lastTimeUpdate > 0.03f)
			{
				if (this.rewardTimeCounter != null && this.rewardTimeCounter.IsActive())
				{
					this.rewardTimeCounter.UpdateTime();
					return;
				}
				this.lastTimeUpdate = time;
				this.UpdateTime(WPFMonoBehaviour.levelManager.TimeLimit - WPFMonoBehaviour.levelManager.TimeElapsed);
			}
		}
	}

	public GameObject rewardTimeCounterObject;

	private RewardTimeCounter rewardTimeCounter;

	private GameObject timeCounter;

	private TextMesh timeTextShadow;

	private TextMesh timeText;

	private bool running;

	private float lastTimeUpdate;

	private const bool showScoreFloaters = false;

	private bool isTimerRed;
}
