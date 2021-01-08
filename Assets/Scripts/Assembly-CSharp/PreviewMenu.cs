using System.Collections.Generic;
using UnityEngine;

public class PreviewMenu : WPFMonoBehaviour
{
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
		if (WPFMonoBehaviour.levelManager.m_sandbox || WPFMonoBehaviour.levelManager.CurrentGameMode is CakeRaceMode)
		{
			GameObject gameObject = base.transform.Find("ObjectivePanel").gameObject;
			gameObject.SetActive(false);
			this.UpdateChallenges();
		}
	}

	private void Start()
	{
		GameObject gameObject = base.transform.Find("ObjectivePanel").gameObject;
		if (WPFMonoBehaviour.levelManager.m_sandbox)
		{
			gameObject.SetActive(false);
			return;
		}
		this.m_objectiveOne = gameObject.transform.Find("ObjectiveSlot1").GetComponent<ObjectiveSlot>();
		this.m_objectiveTwo = gameObject.transform.Find("ObjectiveSlot2").GetComponent<ObjectiveSlot>();
		this.m_objectiveThree = gameObject.transform.Find("ObjectiveSlot3").GetComponent<ObjectiveSlot>();
		if (this.m_challenges.Count >= 2)
		{
			bool flag = GameProgress.IsChallengeCompleted(Singleton<GameManager>.Instance.CurrentSceneName, this.m_challenges[0].ChallengeNumber);
			bool flag2 = GameProgress.IsChallengeCompleted(Singleton<GameManager>.Instance.CurrentSceneName, this.m_challenges[1].ChallengeNumber);
			if (!flag && flag2)
			{
				Challenge value = this.m_challenges[0];
				this.m_challenges[0] = this.m_challenges[1];
				this.m_challenges[1] = value;
			}
		}
		if (this.m_challenges == null || this.m_challenges.Count == 0)
		{
			return;
		}
		string currentSceneName = Singleton<GameManager>.Instance.CurrentSceneName;
		bool flag3 = GameProgress.HasCollectedSnoutCoins(currentSceneName, 0);
		bool flag4 = GameProgress.HasCollectedSnoutCoins(currentSceneName, this.m_challenges[0].ChallengeNumber);
		bool flag5 = GameProgress.HasCollectedSnoutCoins(currentSceneName, this.m_challenges[1].ChallengeNumber);
		this.m_objectiveOne.ShowSnoutReward(!flag3, 1, false);
		this.m_objectiveTwo.ShowSnoutReward(!flag4, 1, false);
		this.m_objectiveThree.ShowSnoutReward(!flag5, 1, false);
		bool flag6 = GameProgress.IsLevelCompleted(Singleton<GameManager>.Instance.CurrentSceneName);
		if (flag6)
		{
			this.m_objectiveOne.SetSucceededImmediate();
		}
		this.m_objectiveOne.SetChallenge(this.m_goal);
		if (this.m_challenges.Count >= 1)
		{
			this.m_objectiveTwo.SetChallenge(this.m_challenges[0]);
			bool flag7 = GameProgress.IsChallengeCompleted(Singleton<GameManager>.Instance.CurrentSceneName, this.m_challenges[0].ChallengeNumber);
			if (flag7)
			{
				this.m_objectiveTwo.SetSucceededImmediate();
			}
		}
		if (this.m_challenges.Count >= 2)
		{
			this.m_objectiveThree.SetChallenge(this.m_challenges[1]);
			bool flag8 = GameProgress.IsChallengeCompleted(Singleton<GameManager>.Instance.CurrentSceneName, this.m_challenges[1].ChallengeNumber);
			if (flag8)
			{
				this.m_objectiveThree.SetSucceededImmediate();
			}
		}
	}

	public void UpdateChallenges()
	{
		if (WPFMonoBehaviour.levelManager.m_sandbox || WPFMonoBehaviour.levelManager.CurrentGameMode is CakeRaceMode)
		{
			return;
		}
		GameObject gameObject = base.transform.Find("ObjectivePanel").gameObject;
		this.m_challenges = WPFMonoBehaviour.levelManager.Challenges;
		this.m_objectiveTwo = gameObject.transform.Find("ObjectiveSlot2").GetComponent<ObjectiveSlot>();
		this.m_objectiveThree = gameObject.transform.Find("ObjectiveSlot3").GetComponent<ObjectiveSlot>();
		if (this.m_challenges.Count >= 1)
		{
			this.m_objectiveTwo.SetChallenge(this.m_challenges[0]);
		}
		if (this.m_challenges.Count >= 2)
		{
			this.m_objectiveThree.SetChallenge(this.m_challenges[1]);
		}
	}

	private GoalChallenge m_goal;

	private List<Challenge> m_challenges = new List<Challenge>();

	private ObjectiveSlot m_objectiveOne;

	private ObjectiveSlot m_objectiveTwo;

	private ObjectiveSlot m_objectiveThree;
}
