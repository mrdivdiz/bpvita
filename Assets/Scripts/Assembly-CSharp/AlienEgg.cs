using System;

public class AlienEgg : Egg
{
	public override void Initialize()
	{
		if (!base.contraption.HasRegularGlue)
		{
			base.contraption.ApplySuperGlue(Glue.Type.Alien);
			base.contraption.MakeUnbreakable();
		}
	}
}
