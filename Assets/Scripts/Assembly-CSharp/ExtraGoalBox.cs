using System.Collections.Generic;
using UnityEngine;

public class ExtraGoalBox : GoalBox
{
	private void OnTriggerEnter(Collider col)
	{
		BasePart basePart = base.FindPart(col);
		if (basePart && (!(base.tag == "Goal") || !(col.transform.tag == "Sharp")))
		{
			WPFMonoBehaviour.levelManager.ContraptionRunning.FinishConnectedComponentSearch();
			if (this.m_extraTargetPart != BasePart.PartType.Unknown)
			{
				this.CheckIfPartReachedGoal(basePart, col, this.m_extraTargetPart);
			}
		}
	}

	protected new bool CheckIfPartReachedGoal(BasePart part, Collider collider, BasePart.PartType targetType)
	{
		BasePart basePart = WPFMonoBehaviour.levelManager.ContraptionRunning.FindPart(targetType);
		if (!basePart)
		{
			return false;
		}
		bool flag = WPFMonoBehaviour.levelManager.ContraptionRunning.IsConnectedTo(part, collider, basePart);
		if (flag)
		{
			this.OnGoalEnter(basePart);
			return true;
		}
		List<BasePart> parts = WPFMonoBehaviour.levelManager.ContraptionRunning.Parts;
		for (int i = 0; i < parts.Count; i++)
		{
			BasePart basePart2 = parts[i];
			if (basePart2 && basePart2.ConnectedComponent == part.ConnectedComponent)
			{
				this.OnGoalEnter(basePart);
				return true;
			}
		}
		return false;
	}

	protected override void OnGoalEnter(BasePart part)
	{
		if (this.collected)
		{
			return;
		}
		WPFMonoBehaviour.levelManager.NotifyGoalReachedByPart(part.m_partType);
		this.m_flagObject.GetComponent<Animation>().Play();
		if (this.m_goalAchievement)
		{
			this.m_goalAchievement.GetComponent<Animation>().Play();
		}
		this.m_goalParticles.Stop();
		this.collected = true;
		base.DisableGoal();
	}
}
