using System;
using UnityEngine;

[Serializable]
public class BundleDataObject
{
	public BundleDataObject()
	{
		this.assetBundle = string.Empty;
		this.assetName = string.Empty;
	}

	public string AssetBundle
	{
		get
		{
			return this.assetBundle;
		}
	}

	public string AssetName
	{
		get
		{
			return this.assetName;
		}
		set
		{
			this.assetName = value;
		}
	}

	public T LoadValue<T>() where T : UnityEngine.Object
    {
		string text = this.assetName;
		if (typeof(T) == typeof(GameObject))
		{
			text += ".prefab";
		}
		else if (typeof(T) == typeof(TextAsset))
		{
			text += ".bytes";
		}
		if (string.IsNullOrEmpty(this.assetName))
		{
			return default(T);
		}
		if (string.IsNullOrEmpty(this.assetBundle))
		{
			return Bundle.LoadObject<T>(text);
		}
		return Bundle.LoadObject<T>(this.assetBundle, text);
	}

	[SerializeField]
	private string assetBundle;

	[SerializeField]
	private string assetName;
}
