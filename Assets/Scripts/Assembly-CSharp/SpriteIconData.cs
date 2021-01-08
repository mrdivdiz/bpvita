using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteIconData : MonoBehaviour
{
	public static SpriteIconData Instance
	{
		get
		{
			if (SpriteIconData._instance == null)
			{
				GameObject gameObject = Resources.Load<GameObject>("Utility/SpriteIconData");
				if (gameObject != null)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(gameObject);
					SpriteIconData._instance = gameObject2.GetComponent<SpriteIconData>();
				}
			}
			return SpriteIconData._instance;
		}
	}

	private void Awake()
	{
		SpriteIconData._instance = this;
	}

	public SpriteIcon GetSpriteIcon(string tag)
	{
		if (this.icons == null || string.IsNullOrEmpty(tag))
		{
			return null;
		}
		foreach (SpriteIcon spriteIcon in this.icons)
		{
			if (spriteIcon.tag.Equals(tag))
			{
				return spriteIcon;
			}
		}
		return null;
	}

	public List<string> GetTags()
	{
		if (this.iconTags == null || this.iconTags.Count == 0)
		{
			this.iconTags = new List<string>();
			foreach (SpriteIcon spriteIcon in this.icons)
			{
				this.iconTags.Add(spriteIcon.tag);
			}
		}
		return this.iconTags;
	}

	private static SpriteIconData _instance;

	[SerializeField]
	private List<SpriteIcon> icons;

	private List<string> iconTags;

	[Serializable]
	public class SpriteIcon
	{
		public SpriteIcon()
		{
			this.tag = string.Empty;
			this.spriteId = string.Empty;
			this.scale = 1f;
			this.atlasReference = null;
		}

		public string tag;

		public string spriteId;

		public float scale;

		public Material atlasReference;

		[HideInInspector]
		public string quad;
	}
}
