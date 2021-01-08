using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DailyLevel
{
	public DailyLevel(int episodeIndex, int levelIndex)
	{
		this.episodeIndex = episodeIndex;
		this.levelIndex = levelIndex;
	}

	public int Count
	{
		get
		{
			return (this.collectablePositions != null) ? this.collectablePositions.Count : 0;
		}
	}

	public string GetKey()
	{
		return this.episodeIndex.ToString() + "-" + this.levelIndex.ToString();
	}

	public void AddPosition(Vector3 position)
	{
		this.SetPosition(int.MaxValue, position);
	}

	public void DeletePosition(int index)
	{
		if (index >= 0 && index < this.collectablePositions.Count)
		{
			this.collectablePositions.RemoveAt(index);
		}
	}

	public void SetPosition(int index, Vector3 position)
	{
		if (index < 0)
		{
			return;
		}
		if (this.collectablePositions == null)
		{
			this.collectablePositions = new List<Vector3>();
		}
		if (index < this.collectablePositions.Count)
		{
			this.collectablePositions[index] = position;
		}
		else
		{
			this.collectablePositions.Add(position);
		}
	}

	public bool GetPosition(int index, out Vector3 position)
	{
		position = Vector3.zero;
		if (this.collectablePositions == null || index < 0 || index >= this.collectablePositions.Count)
		{
			return false;
		}
		position = this.collectablePositions[index];
		return true;
	}

	public bool ValidPositionIndex(int index)
	{
		return this.collectablePositions != null && index >= 0 && index < this.collectablePositions.Count;
	}

	[SerializeField]
	private int episodeIndex;

	[SerializeField]
	private int levelIndex;

	[SerializeField]
	private List<Vector3> collectablePositions;
}
