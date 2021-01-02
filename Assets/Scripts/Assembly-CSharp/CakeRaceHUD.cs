using System;
using System.Collections;
using System.Collections.Generic;
using CakeRace;
using Spine.Unity;
using UnityEngine;

public class CakeRaceHUD : WPFMonoBehaviour
{
	private void Awake()
	{
		if (this.timer != null)
		{
			this.timerLabel = this.timer.GetComponentsInChildren<TextMesh>();
		}
		if (this.cakeBarAnimation != null)
		{
			this.cakeBarRenderer = this.cakeBarAnimation.GetComponent<MeshRenderer>();
		}
		EventManager.Connect(new EventManager.OnEvent<UIEvent>(this.OnUIEvent));
	}

	private void OnEnable()
	{
		if (WPFMonoBehaviour.levelManager.CurrentGameMode is CakeRaceMode)
		{
			this.cakeRaceMode = (WPFMonoBehaviour.levelManager.CurrentGameMode as CakeRaceMode);
			this.OnScoreUpdate(0);
			CakeRaceMode cakeRaceMode = this.cakeRaceMode;
			cakeRaceMode.ScoreUpdated = (Action<int>)Delegate.Combine(cakeRaceMode.ScoreUpdated, new Action<int>(this.OnScoreUpdate));
			CakeRaceMode cakeRaceMode2 = this.cakeRaceMode;
			cakeRaceMode2.CakeCollected = (Action<int>)Delegate.Combine(cakeRaceMode2.CakeCollected, new Action<int>(this.OnCakeCollected));
			if (this.raceMeters.Length > 0)
			{
				if (HatchManager.CurrentPlayer != null)
				{
					this.raceMeters[0].SetPlayerInfo("CAKE_RACE_YOU", Singleton<PlayerProgress>.Instance.Level, true);
				}
				else
				{
					this.raceMeters[0].SetPlayerInfo("EditorMode", Singleton<PlayerProgress>.Instance.Level, false);
				}
				this.raceMeters[0].ResetCakes();
			}
			if (this.raceMeters.Length > 1)
			{
				if (CakeRaceMode.IsPreviewMode)
				{
					this.raceMeters[1].SetPlayerInfo("PreviewMode", Singleton<PlayerProgress>.Instance.Level, false);
				}
				else if (CakeRaceMode.OpponentReplay != null)
				{
					this.raceMeters[1].SetPlayerInfo(CakeRaceMode.OpponentReplay.GetPlayerName(), CakeRaceMode.OpponentReplay.PlayerLevel, false);
				}
				this.raceMeters[1].ResetCakes();
			}
			base.StartCoroutine(this.CakeBarIntroSequence());
			if (!CakeRaceMode.IsPreviewMode)
			{
				base.StartCoroutine(this.PlayOpponentReplay());
			}
		}
		else
		{
			base.gameObject.SetActive(false);
		}
		if (base.gameObject.activeInHierarchy)
		{
			base.StartCoroutine(CoroutineRunner.DelayFrames(delegate
			{
				this.SetTimeBombMode(CakeRaceHUD.TimerMode.Intro, true, false);
				this.SetTimeBombMode(CakeRaceHUD.TimerMode.Normal, false, true);
			}, 1));
		}
	}

	private void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<UIEvent>(this.OnUIEvent));
	}

	private void InitTimeBombAnimations()
	{
		float seconds = this.cakeRaceMode.RaceTimeLeft / 2f;
		base.StartCoroutine(CoroutineRunner.DelayActionSequence(delegate
		{
			this.SetTimeBombMode(CakeRaceHUD.TimerMode.Intermediate, false, true);
		}, seconds, false));
		float seconds2 = this.cakeRaceMode.RaceTimeLeft - 10f;
		base.StartCoroutine(CoroutineRunner.DelayActionSequence(delegate
		{
			this.SetTimeBombMode(CakeRaceHUD.TimerMode.Critical, false, true);
		}, seconds2, false));
	}

	private string GetPlayerName(string playerName)
	{
		string result = "guest";
		if (!string.IsNullOrEmpty(playerName))
		{
			if (playerName.Contains("|"))
			{
				string[] array = HatchManager.CurrentPlayer.PlayFabDisplayName.Split(new char[]
				{
					'|'
				});
				result = array[0];
			}
			else
			{
				result = playerName;
			}
		}
		return result;
	}

	private IEnumerator PlayOpponentReplay()
	{
		if (this.raceMeters.Length <= 1 || CakeRaceMode.OpponentReplay == null)
		{
			yield break;
		}
		this.cakeRaceMode.OpponentScore = 0;
		this.raceMeters[1].SetScoreLabel(string.Format("{0:n0}", this.cakeRaceMode.OpponentScore));
		bool[] collected = new bool[CakeRaceMode.OpponentReplay.GetCollectedCakeCount()];
		for (int i = 0; i < collected.Length; i++)
		{
			collected[i] = false;
		}
		int collectedCount = 0;
		while (collectedCount < CakeRaceMode.OpponentReplay.GetCollectedCakeCount())
		{
			yield return null;
			for (int j = 0; j < collected.Length; j++)
			{
				int num = this.cakeRaceMode.RaceTimeLeftInHundrethOfSeconds();
				int cakeCollectTime = CakeRaceMode.OpponentReplay.GetCakeCollectTime(j);
				if (!collected[j] && cakeCollectTime >= 0 && cakeCollectTime >= num)
				{
					collected[j] = true;
					collectedCount++;
					this.cakeRaceMode.OpponentScore += CakeRaceReplay.CalculateCakeScore(false, cakeCollectTime, CakeRaceMode.OpponentReplay.PlayerLevel, CakeRaceMode.OpponentReplay.HasKingsFavoritePart);
					this.raceMeters[1].EatCake();
					this.raceMeters[1].SetScoreLabel(string.Format("{0:n0}", this.cakeRaceMode.OpponentScore));
				}
			}
		}
		yield break;
	}

	public void SetTimeBombMode(TimerMode mode, bool clearAnimations, bool loopAnimation)
	{
		if (clearAnimations)
		{
			this.timeBombAnimation.state.ClearTracks();
		}
		string text = string.Empty;
		for (int i = 0; i < this.bombAnimations.Count; i++)
		{
			if (this.bombAnimations[i].Mode == mode)
			{
				text = this.bombAnimations[i].Animation;
				break;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			this.timeBombAnimation.state.SetAnimation(this.timeBombAnimation.state.Tracks.Count, text, loopAnimation);
		}
	}

	private void OnDisable()
	{
		if (this.cakeRaceMode != null)
		{
			CakeRaceMode cakeRaceMode = this.cakeRaceMode;
			cakeRaceMode.ScoreUpdated = (Action<int>)Delegate.Remove(cakeRaceMode.ScoreUpdated, new Action<int>(this.OnScoreUpdate));
			CakeRaceMode cakeRaceMode2 = this.cakeRaceMode;
			cakeRaceMode2.CakeCollected = (Action<int>)Delegate.Remove(cakeRaceMode2.CakeCollected, new Action<int>(this.OnCakeCollected));
		}
		base.StopAllCoroutines();
	}

	private IEnumerator CakeBarIntroSequence()
	{
		this.cakeBarRenderer.enabled = false;
		yield return null;
		if (this.cakeBarAnimation != null)
		{
			this.cakeBarAnimation.state.SetAnimation(0, this.cakeBarIntroAnimation, false);
		}
		yield return null;
		this.cakeBarRenderer.enabled = true;
		yield break;
	}

	private void Update()
	{
		if (this.cakeRaceMode != null)
		{
			this.SetTimerLabel(this.cakeRaceMode.RaceTimeLeft);
		}
	}

	private void SetTimerLabel(float totalSeconds)
	{
		if (this.timerLabel == null || this.timerLabel.Length < 2)
		{
			return;
		}
		totalSeconds = Mathf.Clamp(totalSeconds, 0f, totalSeconds);
		int num = Mathf.FloorToInt(totalSeconds / 60f);
		int num2 = Mathf.FloorToInt(totalSeconds % 60f);
		int num3 = (int)(100f * (totalSeconds - (float)(num * 60 + num2)));
		this.timerLabel[0].text = string.Format("{0:00}:{1:00}:{2:00}", num, num2, num3);
		this.timerLabel[1].text = this.timerLabel[0].text;
	}

	private void OnScoreUpdate(int newScore)
	{
		this.raceMeters[0].SetScoreLabel(string.Format("{0:n0}", newScore));
	}

	private void OnCakeCollected(int index)
	{
		this.raceMeters[0].EatCake();
	}

	private void OnUIEvent(UIEvent data)
	{
		UIEvent.Type type = data.type;
		if (type == UIEvent.Type.CakeRaceTimerStarted)
		{
			this.InitTimeBombAnimations();
		}
	}

	[SerializeField]
	private List<TimerModePair> bombAnimations;

	[SerializeField]
	private SkeletonAnimation cakeBarAnimation;

	[SerializeField]
	private string cakeBarIntroAnimation;

	[SerializeField]
	private CakeRaceMeter[] raceMeters;

	[SerializeField]
	private SkeletonAnimation timeBombAnimation;

	[SerializeField]
	private GameObject timer;

	private MeshRenderer cakeBarRenderer;

	private CakeRaceMode cakeRaceMode;

	private TextMesh[] timerLabel;

	private const string TIMER_FORMAT = "{0:00}:{1:00}:{2:00}";

	private const string SCORE_FORMAT = "{0:n0}";

	public enum TimerMode
	{
		Intro,
		Normal,
		Intermediate,
		Critical,
		TimesUp
	}

	[Serializable]
	private struct TimerModePair
	{
		public TimerMode Mode
		{
			get
			{
				return this.m_mode;
			}
		}

		public string Animation
		{
			get
			{
				return this.m_animation;
			}
		}

		[SerializeField]
		private TimerMode m_mode;

		[SerializeField]
		private string m_animation;
	}
}
