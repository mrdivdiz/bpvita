using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteReference))]
public class SpriteFont : MonoBehaviour
{
	public SpriteSymbol GetSymbol(char c)
	{
		return this.m_charToSpriteSymbol[c];
	}

	public void Initialize(RuntimeSpriteDatabase db)
	{
		this.m_charToSpriteSymbol.Clear();
		int count = this.m_symbols.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.m_symbols[i].spriteId != string.Empty)
			{
				SpriteData spriteData = db.Find(this.m_symbols[i].spriteId);
				this.m_symbols[i].spriteData = spriteData;
				if (spriteData == null)
				{
				}
				this.m_charToSpriteSymbol.Add(this.m_symbols[i].symbol[0], this.m_symbols[i]);
				Rect uv = spriteData.uv;
				Vector2[] array = new Vector2[4];
				array[0].x = uv.x;
				array[0].y = uv.y;
				array[1].x = uv.x;
				array[1].y = uv.y + uv.height;
				array[2].x = uv.x + uv.width;
				array[2].y = uv.y + uv.height;
				array[3].x = uv.x + uv.width;
				array[3].y = uv.y;
				this.m_symbols[i].uv = array;
			}
		}
	}

	public Dictionary<char, SpriteSymbol> m_charToSpriteSymbol = new Dictionary<char, SpriteSymbol>();

	public List<SpriteSymbol> m_symbols = new List<SpriteSymbol>();

	[Serializable]
	public class SpriteSymbol
	{
		public string symbol = string.Empty;

		public string spriteId = string.Empty;

		public float spriteScaleX = 1f;

		public float spriteScaleY = 1f;

		[NonSerialized]
		public Vector2[] uv;

		[HideInInspector]
		[NonSerialized]
		public SpriteData spriteData;
	}
}
