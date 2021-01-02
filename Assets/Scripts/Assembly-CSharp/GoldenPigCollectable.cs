using UnityEngine;

public class GoldenPigCollectable : Collectable
{
	private void OnTriggerEnter(Collider col)
	{
		BasePart basePart = base.FindPart(col);
		if (basePart && (!(base.tag == "Goal") || !(col.transform.tag == "Sharp")))
		{
			WPFMonoBehaviour.levelManager.ContraptionRunning.FinishConnectedComponentSearch();
			base.CheckIfPartReachedGoal(basePart, col, BasePart.PartType.GoldenPig);
		}
	}
}
