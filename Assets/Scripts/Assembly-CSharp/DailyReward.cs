using System;
using UnityEngine;

[Serializable]
public struct DailyReward
{
	[SerializeField]
	public PrizeType prize;

	[SerializeField]
	public int prizeCount;
}
