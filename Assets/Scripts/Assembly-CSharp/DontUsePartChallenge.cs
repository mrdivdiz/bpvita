public class DontUsePartChallenge : Challenge
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
		return !WPFMonoBehaviour.levelManager.ContraptionProto.HasPart(this.m_partType);
	}

	private void Start()
	{
		if (this.m_icons.Count >= 1)
		{
			this.m_icons[0].icon = WPFMonoBehaviour.gameData.GetPart(this.m_partType).GetComponent<BasePart>().m_constructionIconSprite.gameObject;
		}
	}

	public BasePart.PartType m_partType;
}
