using System;
using UnityEngine;

[Serializable]
public class ShopRibbon
{
	public Ribbon ribbonType;

	public GameObject ribbon;

	public RuntimePlatform platform;

	public string itemId;

	public enum Ribbon
	{
		BestValue,
		MostPopular
	}
}
