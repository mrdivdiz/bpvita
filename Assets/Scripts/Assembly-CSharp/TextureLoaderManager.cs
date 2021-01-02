using System.Collections;

public class TextureLoaderManager : Singleton<TextureLoaderManager>
{
	private void Start()
	{
		base.SetAsPersistant();
	}

	private IEnumerator Unloader()
	{
		yield return null;
		yield break;
	}

	private const string TEXTURE_LOADER_PREFAB = "Prefabs/TextureLoader";

	public BundleSelector m_textureBundle;
}
