using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSheetMapping : MonoBehaviour
{
	public List<AtlasContents> GetSourcesByAtlasTexture()
	{
		List<AtlasContents> list = new List<AtlasContents>();
		HashSet<Texture> hashSet = new HashSet<Texture>();
		foreach (SheetMapping sheetMapping in this.m_data)
		{
			hashSet.Add(sheetMapping.atlas.mainTexture);
		}
		foreach (Texture atlasTexture in hashSet)
		{
            AtlasContents sourcesForAtlasTexture = this.GetSourcesForAtlasTexture(atlasTexture);
			list.Add(sourcesForAtlasTexture);
		}
		return list;
	}

	public AtlasContents GetSourcesForAtlasTexture(Texture atlasTexture)
	{
        AtlasContents atlasContents = new AtlasContents();
		atlasContents.atlasTexture = atlasTexture;
		atlasContents.atlasTexture = atlasTexture;
		foreach (SheetMapping sheetMapping in this.m_data)
		{
			if (sheetMapping.atlas.mainTexture == atlasTexture)
			{
				atlasContents.sources.Add(sheetMapping.source);
			}
		}
		return atlasContents;
	}

	public Material FindAtlasFor(Material material)
	{
		foreach (SheetMapping sheetMapping in this.m_data)
		{
			if (sheetMapping.source == material || sheetMapping.atlas == material)
			{
				return sheetMapping.atlas;
			}
		}
		return null;
	}

	public bool IsSource(Material material)
	{
		for (int i = 0; i < this.m_data.Count; i++)
		{
			if (this.m_data[i].source == material)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsAtlas(Material material)
	{
		for (int i = 0; i < this.m_data.Count; i++)
		{
			if (this.m_data[i].atlas == material)
			{
				return true;
			}
		}
		return false;
	}

	public const string AssetPath = "Assets/Data/Materials/GUISystem/SpriteSheetMapping.prefab";

	public List<SheetMapping> m_data;

	[Serializable]
	public class SheetMapping
	{
		public Material source;

		[HideInInspector]
		public string sourceId;

		public Material atlas;
	}

	public class AtlasContents
	{
		public Texture atlasTexture;

		public List<Material> sources = new List<Material>();
	}
}
