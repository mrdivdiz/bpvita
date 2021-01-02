using System;
using UnityEngine;

[Serializable]
public class BundleSelector
{
	public BundleSelector()
	{
		this.assetBundle = string.Empty;
	}

	public string AssetBundle
	{
		get
		{
			return this.assetBundle;
		}
	}

	public void LoadAssetBundle()
	{
	}

	public void UnloadAssetBundle()
	{
	}

	[SerializeField]
	private string assetBundle;
}
