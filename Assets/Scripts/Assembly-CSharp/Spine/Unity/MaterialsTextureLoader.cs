using System.IO;
using UnityEngine;

namespace Spine.Unity
{
    public class MaterialsTextureLoader : TextureLoader
	{
		public MaterialsTextureLoader(AtlasAsset atlasAsset)
		{
			this.atlasAsset = atlasAsset;
		}

		public void Load(AtlasPage page, string path)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
			Material material = null;
			foreach (Material material2 in this.atlasAsset.materials)
			{
				if (material2.mainTexture == null)
				{
					return;
				}
				if (material2.mainTexture.name == fileNameWithoutExtension)
				{
					material = material2;
					break;
				}
			}
			if (material == null)
			{
				return;
			}
			page.rendererObject = material;
			if (page.width == 0 || page.height == 0)
			{
				page.width = material.mainTexture.width;
				page.height = material.mainTexture.height;
			}
		}

		public void Unload(object texture)
		{
		}

		private AtlasAsset atlasAsset;
	}
}
