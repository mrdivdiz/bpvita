public class TransportChallenge : Challenge
{
	public override ChallengeType Type
	{
		get
		{
			return Challenge.ChallengeType.Transport;
		}
	}

	public override bool IsCompleted()
	{
		return WPFMonoBehaviour.levelManager.IsPartTransported(this.partToTransport);
	}

	public BasePart.PartType partToTransport;
}
