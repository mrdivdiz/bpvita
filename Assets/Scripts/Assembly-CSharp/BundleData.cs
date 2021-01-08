using UnityEngine;

public class BundleData : ScriptableObject
{
	public string BundleName
	{
		get
		{
			return this.bundleName;
		}
	}

	public string[] Assets
	{
		get
		{
			return this.bundleAssets;
		}
	}

	public void SetData(string bundleName, string[] assets)
	{
		this.bundleName = bundleName;
		this.bundleAssets = assets;
	}

	[SerializeField]
	private string bundleName;

	[SerializeField]
	private string[] bundleAssets;

	[SerializeField]
	private bool includeInBuild;
}
