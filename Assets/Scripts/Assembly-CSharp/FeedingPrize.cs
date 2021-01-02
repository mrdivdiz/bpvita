using System;
using UnityEngine;

[Serializable]
public class FeedingPrize
{
	public string name;

	public PrizeType type;

	public float rangeWidth;

	public GameObject icon;

	public float iconScale = 2f;

	public enum PrizeType
	{
		None,
		Junk,
		SuperGlue,
		SuperMagnet,
		TurboCharge,
		SuperMechanic,
		PremiumPart,
		NightVision,
		SnoutCoins,
		Scrap
	}
}
