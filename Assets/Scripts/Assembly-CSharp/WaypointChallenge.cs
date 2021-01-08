public class WaypointChallenge : Challenge
{
	public override ChallengeType Type
	{
		get
		{
			return Challenge.ChallengeType.Box;
		}
	}

	public override bool IsCompleted()
	{
		return this.m_target.collected;
	}

	public Collectable m_target;
}
