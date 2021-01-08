using System.Collections.Generic;
using UnityEngine;

public class TextMeshSpriteIcons : MonoBehaviour
{
	private void Awake()
	{
		this.Initialize();
	}

	private void Initialize()
	{
		if (this.initialized)
		{
			return;
		}
		this.textMesh = base.GetComponent<TextMesh>();
		this.originalText = ((!(this.textMesh == null)) ? this.textMesh.text : null);
		this.initialized = true;
	}

	private void TextUpdated()
	{
		this.UpdateIcons();
	}

	public void UpdateIcons()
	{
		this.Initialize();
		if (this.textMesh == null || string.IsNullOrEmpty(this.originalText))
		{
			return;
		}
		if (string.IsNullOrEmpty(this.originalText = this.textMesh.text))
		{
			return;
		}
		if (!this.ContainsTag())
		{
			return;
		}
		Renderer component = this.textMesh.GetComponent<Renderer>();
		this.textMesh.text = string.Empty;
		bool enabled = component.enabled;
		component.enabled = false;
		string text = this.originalText;
		RuntimeSpriteDatabase instance = Singleton<RuntimeSpriteDatabase>.Instance;
		List<Material> list = new List<Material>();
		foreach (string text2 in SpriteIconData.Instance.GetTags())
		{
			if (this.originalText.Contains(text2))
			{
				SpriteIconData.SpriteIcon spriteIcon = SpriteIconData.Instance.GetSpriteIcon(text2);
				SpriteData spriteData = instance.Find(spriteIcon.spriteId);
				Material atlasReference = spriteIcon.atlasReference;
				if (spriteData != null && atlasReference != null)
				{
					int num = -1;
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i] == atlasReference)
						{
							num = i + 1;
						}
					}
					if (num < 0)
					{
						list.Add(atlasReference);
						num = list.Count;
					}
					int num2 = Mathf.FloorToInt(spriteIcon.scale * (float)this.textMesh.font.fontSize);
					spriteIcon.quad = string.Format("<quad material={5} size={0} x={1:0.000} y={2:0.000} width={3:0.000} height={4:0.000} />", new object[]
					{
						num2,
						spriteData.uv.x,
						spriteData.uv.y,
						spriteData.uv.width,
						spriteData.uv.height,
						num
					});
					text = text.Replace(spriteIcon.tag, spriteIcon.quad);
				}
			}
		}
		if (list.Count > 0)
		{
			Material[] array = new Material[list.Count + 1];
			array[0] = component.sharedMaterials[0];
			int num3 = 1;
			foreach (Material material in list)
			{
				array[num3] = material;
				num3++;
			}
			component.sharedMaterials = array;
		}
		component.enabled = enabled;
		text = " " + text + " ";
		text = text.Replace("  ", " ");
		this.textMesh.text = text;
	}

	private bool ContainsTag()
	{
		if (string.IsNullOrEmpty(this.originalText))
		{
			return false;
		}
		foreach (string value in SpriteIconData.Instance.GetTags())
		{
			if (this.originalText.Contains(value))
			{
				return true;
			}
		}
		return false;
	}

	public static void EnsureSpriteIcon(TextMesh[] target)
	{
		if (target == null || target.Length <= 0)
		{
			return;
		}
		for (int i = 0; i < target.Length; i++)
		{
			TextMeshSpriteIcons.EnsureSpriteIcon(target[i]);
		}
	}

	public static void EnsureSpriteIcon(TextMesh target)
	{
		if (target == null)
		{
			return;
		}
		TextMeshSpriteIcons textMeshSpriteIcons = target.GetComponent<TextMeshSpriteIcons>();
		if (textMeshSpriteIcons == null)
		{
			textMeshSpriteIcons = target.gameObject.AddComponent<TextMeshSpriteIcons>();
		}
		textMeshSpriteIcons.UpdateIcons();
	}

	private TextMesh textMesh;

	private string originalText;

	private bool initialized;
}
