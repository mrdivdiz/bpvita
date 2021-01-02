using UnityEngine;

public class RewardTimeCounter : WPFMonoBehaviour
{
	private void Awake()
	{
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChangeEvent));
		this.m_timeText = this.m_timeRewardText.GetComponent<TextMesh>();
		this.m_timeTextShadow = this.m_timeRewardTextShadow.GetComponent<TextMesh>();
	}

	private void Start()
	{
	}

	public bool IsActive()
	{
		return base.gameObject.activeInHierarchy && this.m_isRunning;
	}

	public bool IsRunning()
	{
		return base.gameObject.activeInHierarchy && this.m_isRunning;
	}

	public void GiveReward(bool activates)
	{
		if (!this.m_isSetuped)
		{
			this.m_timeReward = (float)RewardVideoManager.TimeToReward;
			this.UpdateText(this.m_timeReward);
			this.SetupCounter();
			this.m_isRunning = true;
		}
		if (activates)
		{
			base.gameObject.SetActive(true);
		}
	}

	private void OnEnable()
	{
		if (!base.gameObject.activeSelf || !this.m_isSetuped)
		{
			base.gameObject.SetActive(false);
		}
	}

	private void ReceiveGameStateChangeEvent(GameStateChanged newState)
	{
		if (newState.state == LevelManager.GameState.Running)
		{
			if (RewardVideoManager.AddTimeRewardCounterOnLevelStart)
			{
				this.GiveReward(true);
				RewardVideoManager.AddTimeRewardCounterOnLevelStart = false;
			}
			if (this.m_isSetuped && this.m_wasStopped && this.m_needRestart)
			{
				this.m_isRunning = true;
				this.m_needRestart = false;
			}
		}
		else if (newState.state == LevelManager.GameState.Building && this.m_isSetuped)
		{
			this.UpdateText(this.m_timeReward);
			this.m_timeReward = (float)RewardVideoManager.TimeToReward;
			this.m_timeLeft = this.m_timeReward;
			this.Stop();
		}
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChangeEvent));
	}

	private void Stop()
	{
		this.m_wasStopped = true;
		this.m_isRunning = false;
		this.m_timeLeft = 0f;
		this.m_needRestart = true;
		this.m_timeRewardText.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
	}

	public void UpdateTime()
	{
		if (!WPFMonoBehaviour.levelManager.TimeStarted)
		{
			return;
		}
		this.m_timeLeft -= Time.deltaTime;
		if (this.m_wasStopped)
		{
			this.m_timeLeft = this.m_timeReward;
			this.m_wasStopped = false;
			this.m_timeRewardText.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
		}
		if (this.m_timeLeft <= 1.401298E-45f)
		{
			this.m_wasStopped = true;
			this.m_isRunning = false;
			this.m_timeLeft = 0f;
			this.m_timeRewardText.GetComponent<Renderer>().material.color = new Color(1f, 0.4f, 0.4f);
		}
		this.UpdateText(this.m_timeLeft);
	}

	private void SetupCounter()
	{
		this.SetTime((float)RewardVideoManager.TimeToReward);
		this.m_timerBackgroundOldYPosition = this.m_timerBackground.transform.localPosition.y;
		this.m_timerBackgroundNewYPosition = -0.88f;
		this.m_timerBackgroundOldYScale = this.m_timerBackground.transform.localScale.y;
		this.m_timerBackgroundNewYScale = 1.8f;
		this.m_timerDefaultScale = this.m_timeRewardText.transform.localScale;
		this.m_timeRewardText.transform.localScale = Vector3.zero;
		this.m_animationRunning = true;
		this.m_isSetuped = true;
	}

	private void Update()
	{
		if (this.m_animationRunning)
		{
			this.m_timerBackground.transform.localPosition = new Vector3(this.m_timerBackground.transform.localPosition.x, Mathf.SmoothStep(this.m_timerBackgroundOldYPosition, this.m_timerBackgroundNewYPosition, this.m_elapsedAnimationTime / this.m_animationTime), this.m_timerBackground.transform.localPosition.z);
			this.m_timerBackground.transform.localScale = new Vector3(this.m_timerBackground.transform.localScale.x, Mathf.SmoothStep(this.m_timerBackgroundOldYScale, this.m_timerBackgroundNewYScale, this.m_elapsedAnimationTime / this.m_animationTime), this.m_timerBackground.transform.localScale.z);
			this.m_timeRewardText.transform.localScale = Vector3.Lerp(Vector3.zero, this.m_timerDefaultScale, this.m_elapsedAnimationTime / this.m_animationTime);
			this.m_elapsedAnimationTime += Time.deltaTime;
			if (this.m_elapsedAnimationTime >= this.m_animationTime)
			{
				this.m_animationRunning = false;
				this.m_elapsedAnimationTime = 0f;
			}
		}
	}

	private void UpdateText(float time)
	{
		int num = (int)time;
		int num2 = (int)((time - (float)num) * 1000f) / 10;
		string text = "+" + num.ToString("D2") + "." + num2.ToString("D2");
		if (this.m_timeText)
		{
			this.m_timeText.text = text;
			this.m_timeTextShadow.text = text;
		}
	}

	public void SetTime(float timeAdd)
	{
		this.m_timeReward = timeAdd;
	}

	public GameObject m_timeRewardText;

	public GameObject m_timeRewardTextShadow;

	public GameObject m_rewardVideoButtonObject;

	public GameObject m_timerBackground;

	private TextMesh m_timeText;

	private TextMesh m_timeTextShadow;

	private float m_timeReward;

	private float m_timeLeft;

	private bool m_wasStopped = true;

	private bool m_isRunning;

	private bool m_isSetuped;

	private bool m_needRestart;

	private bool m_animationRunning;

	private float m_timerBackgroundOldYPosition;

	private float m_timerBackgroundNewYPosition;

	private float m_timerBackgroundOldYScale;

	private float m_timerBackgroundNewYScale;

	private Vector3 m_timerDefaultScale;

	private float m_animationTime = 0.25f;

	private float m_elapsedAnimationTime;
}
