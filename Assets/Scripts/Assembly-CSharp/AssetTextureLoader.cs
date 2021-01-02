using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AssetTextureLoader : MonoBehaviour
{
	private void Awake()
	{
		if (Bundle.initialized)
		{
			this.InitTextures();
		}
		else
		{
			Bundle.AssetBundlesLoaded = (Action)Delegate.Combine(Bundle.AssetBundlesLoaded, new Action(this.InitTextures));
		}
	}

	private void OnDestroy()
	{
		Bundle.AssetBundlesLoaded = (Action)Delegate.Remove(Bundle.AssetBundlesLoaded, new Action(this.InitTextures));
	}

	private void InitTextures()
	{
		GC.Collect();
		Resources.UnloadUnusedAssets();
		foreach (MaterialTexturePair materialTexturePair in this.materials)
		{
			materialTexturePair.material.mainTexture = materialTexturePair.bundleData.LoadValue<Texture2D>();
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	[SerializeField]
	private List<MaterialTexturePair> materials;

	[SerializeField]
	private BundleSelector bundleToUnload;
}
