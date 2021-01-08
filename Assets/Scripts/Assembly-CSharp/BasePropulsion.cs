using System.Collections.Generic;

public abstract class BasePropulsion : BasePart
{
	public override bool ValidatePart()
	{
		if (!WPFMonoBehaviour.levelManager.RequireConnectedContraption)
		{
			return true;
		}
		List<BasePart> list = base.contraption.FindNeighbours(this.m_coordX, this.m_coordY);
		int num = 0;
		foreach (BasePart basePart in list)
		{
			if (basePart.IsPartOfChassis())
			{
				num++;
			}
		}
		return num >= 1;
	}
}
