public class NoChallenge : Challenge
{
	public override ChallengeType Type
	{
		get
		{
			return Challenge.ChallengeType.DontUseParts;
		}
	}

	public override bool IsCompleted()
	{
		return true;
	}
}
