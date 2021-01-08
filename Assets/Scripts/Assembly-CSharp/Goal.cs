using System.Collections.Generic;
using UnityEngine;

public abstract class Goal : WPFMonoBehaviour
{
	protected virtual void Start()
	{
		EventManager.Connect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	protected virtual void OnDestroy()
	{
		EventManager.Disconnect(new EventManager.OnEvent<GameStateChanged>(this.OnGameStateChanged));
	}

	private void OnTriggerEnter(Collider col)
	{
		BasePart basePart = this.FindPart(col);
		if (basePart && (!(base.tag == "Goal") || !(col.transform.tag == "Sharp")))
		{
			WPFMonoBehaviour.levelManager.ContraptionRunning.FinishConnectedComponentSearch();
			this.CheckIfPartReachedGoal(basePart, col, BasePart.PartType.Pig);
			if (this.m_extraTargetPart != BasePart.PartType.Unknown)
			{
				this.CheckIfPartReachedGoal(basePart, col, this.m_extraTargetPart);
			}
		}
	}

	protected bool CheckIfPartReachedGoal(BasePart part, Collider collider, BasePart.PartType targetType)
	{
		BasePart basePart = WPFMonoBehaviour.levelManager.ContraptionRunning.FindPart(targetType);
		if (!basePart)
		{
			return false;
		}
		bool flag;
		if (targetType == BasePart.PartType.Pig)
		{
			flag = WPFMonoBehaviour.levelManager.ContraptionRunning.IsConnectedToPig(part, collider);
		}
		else
		{
			flag = WPFMonoBehaviour.levelManager.ContraptionRunning.IsConnectedTo(part, collider, basePart);
		}
		if (flag)
		{
			this.OnGoalEnter(basePart);
			return true;
		}
		List<BasePart> parts = WPFMonoBehaviour.levelManager.ContraptionRunning.Parts;
		for (int i = 0; i < parts.Count; i++)
		{
			BasePart basePart2 = parts[i];
			if (basePart2 && basePart2.ConnectedComponent == part.ConnectedComponent && Vector3.Distance(basePart2.Position, basePart.Position) < 2.5f)
			{
				this.OnGoalEnter(basePart);
				return true;
			}
		}
		return false;
	}

	protected BasePart FindPart(Collider collider)
	{
		Transform transform = collider.transform;
		while (transform != null)
		{
			BasePart component = transform.GetComponent<BasePart>();
			if (component)
			{
				return component;
			}
			transform = transform.parent;
		}
		return null;
	}

	private void OnGameStateChanged(GameStateChanged data)
	{
		if (data.state == LevelManager.GameState.Building)
		{
			this.OnReset();
		}
	}

	protected abstract void OnGoalEnter(BasePart part);

	protected abstract void OnReset();

	public BasePart.PartType m_extraTargetPart;
}
