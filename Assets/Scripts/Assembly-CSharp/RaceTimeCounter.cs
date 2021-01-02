using System;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimeCounter : WPFMonoBehaviour
{
	private void Awake()
	{
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.ReceiveGameStateChangeEvent));
		this.timeCounter = base.transform.Find("TimeCounter").gameObject;
		this.timeText = this.timeCounter.GetComponent<TextMesh>();
		this.timeText.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
		this.timeTextShadow = this.timeCounter.transform.Find("TimeCounterShadow").GetComponent<TextMesh>();
		this.targetTime = base.transform.Find("TargetTime").gameObject;
		this.targetTimeText = this.targetTime.GetComponent<TextMesh>();
		this.targetTimeTextShadow = this.targetTime.transform.Find("TargetTimeShadow").GetComponent<TextMesh>();
		this.m_timeSeparator = base.transform.Find("TimeSeparator").gameObject;
	}

	private void Start()
	{
		this.m_timeLimits = WPFMonoBehaviour.levelManager.TimeLimits;
		this.UpdateTargetTime();
	}

	public static string FormatTime(float time)
	{
		time = ((time <= 3599.999f) ? time : 3599.999f);
		int num = (int)time;
		int num2 = (int)((time - (float)num) * 1000f) / 10;
		int num3 = num / 60;
		num -= num3 * 60;
		return string.Concat(new string[]
		{
			num3.ToString("D2"),
			":",
			num.ToString("D2"),
			":",
			num2.ToString("D2")
		});
	}

	private void UpdateTargetTime()
	{
		float num = -1f;
		int num2 = 2;
		if (WPFMonoBehaviour.levelManager.TimeElapsed <= this.m_timeLimits[0])
		{
			num = this.m_timeLimits[0];
			num2 = 0;
		}
		else if (WPFMonoBehaviour.levelManager.TimeElapsed <= this.m_timeLimits[1])
		{
			num = this.m_timeLimits[1];
			num2 = 1;
		}
		if (num != this.m_currentTargetTime)
		{
			this.m_currentTargetTime = num;
			num = Mathf.Min(num, 3599.99f);
			this.targetTimeText.GetComponent<Renderer>().material.color = this.m_colors[num2];
			TimeSpan timeSpan = TimeSpan.FromSeconds((double)num);
			string text;
			if (num >= 0f)
			{
				text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
			}
			else
			{
				text = string.Empty;
				if (this.m_timeSeparator.activeInHierarchy)
				{
					this.m_timeSeparator.SetActive(false);
				}
			}
			this.targetTimeText.text = text;
			this.targetTimeTextShadow.text = text;
		}
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
		if (!WPFMonoBehaviour.levelManager.m_raceLevel || !(WPFMonoBehaviour.levelManager.CurrentGameMode is BaseGameMode))
		{
			base.gameObject.SetActive(false);
		}
	}

	private void UpdateTime()
	{
		float timeElapsed = WPFMonoBehaviour.levelManager.TimeElapsed;
		string text = RaceTimeCounter.FormatTime(timeElapsed);
		this.timeText.text = text;
		this.timeTextShadow.text = text;
	}

	private void Update()
	{
		if (this.running)
		{
			this.UpdateTime();
			this.UpdateTargetTime();
		}
	}

	public Color[] m_colors = new Color[3];

	private GameObject timeCounter;

	private TextMesh timeText;

	private TextMesh timeTextShadow;

	private GameObject targetTime;

	private TextMesh targetTimeText;

	private TextMesh targetTimeTextShadow;

	private bool running;

	private List<float> m_timeLimits;

	private float m_currentTargetTime;

	private GameObject m_timeSeparator;
}
