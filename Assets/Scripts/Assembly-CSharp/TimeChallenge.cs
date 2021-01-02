using UnityEngine;

public class TimeChallenge : Challenge
{
	public override ChallengeType Type
	{
		get
		{
			return Challenge.ChallengeType.Time;
		}
	}

	public override bool IsCompleted()
	{
		float num = Mathf.Floor(WPFMonoBehaviour.levelManager.CompletionTime * 100f) / 100f;
		return num <= this.m_targetTime;
	}

	public override float TimeLimit()
	{
		return this.m_targetTime;
	}

	public float m_targetTime;
}
