public class PerfectFlightChallenge : Challenge
{
	public override ChallengeType Type
	{
		get
		{
			return Challenge.ChallengeType.PerfectFlight;
		}
	}

	public override bool IsCompleted()
	{
		return WPFMonoBehaviour.levelManager.ContraptionRunning && !WPFMonoBehaviour.levelManager.ContraptionRunning.IsBroken();
	}
}
