using System.Collections.Generic;
using UnityEngine;

public class AddChallenges : MonoBehaviour
{
	private void Awake()
	{
		LevelComplete component = GameObject.Find("InGameLevelCompleteMenu").GetComponent<LevelComplete>();
		component.SetGoal(this.m_goal);
		component.SetChallenges(this.m_challenges);
	}

	public GoalChallenge m_goal;

	public List<Challenge> m_challenges;
}
