using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CustomPartInfo
{
	public BasePart.PartType PartType
	{
		get
		{
			return this.partType;
		}
	}

	public List<BasePart> PartList
	{
		get
		{
			return this.customParts;
		}
	}

	[SerializeField]
	private BasePart.PartType partType;

	[SerializeField]
	private List<BasePart> customParts;
}
