using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SpriteAttachmentLoader : AttachmentLoader
	{
		public SpriteAttachmentLoader(UnityEngine.Sprite sprite, Shader shader, bool applyPMA)
		{
			if (sprite.packed && sprite.packingMode == SpritePackingMode.Tight)
			{
				return;
			}
			this.sprite = sprite;
			this.shader = shader;
			if (applyPMA)
			{
				try
				{
					Texture2D texture = sprite.texture;
					int instanceID = texture.GetInstanceID();
					if (!SpriteAttachmentLoader.premultipliedAtlasIds.Contains(instanceID))
					{
						Color[] pixels = texture.GetPixels();
						for (int i = 0; i < pixels.Length; i++)
						{
							Color color = pixels[i];
							float a = color.a;
							color.r *= a;
							color.g *= a;
							color.b *= a;
							pixels[i] = color;
						}
						texture.SetPixels(pixels);
						texture.Apply();
						SpriteAttachmentLoader.premultipliedAtlasIds.Add(instanceID);
					}
				}
				catch
				{
				}
			}
		}

		public RegionAttachment NewRegionAttachment(Skin skin, string name, string path)
		{
			RegionAttachment regionAttachment = new RegionAttachment(name);
			Texture2D texture = this.sprite.texture;
			int instanceID = texture.GetInstanceID();
			AtlasRegion atlasRegion;
			if (!SpriteAttachmentLoader.atlasTable.TryGetValue(instanceID, out atlasRegion))
			{
				Material material = new Material(this.shader);
				if (this.sprite.packed)
				{
					material.name = "Unity Packed Sprite Material";
				}
				else
				{
					material.name = this.sprite.name + " Sprite Material";
				}
				material.mainTexture = texture;
				atlasRegion = new AtlasRegion();
				AtlasPage atlasPage = new AtlasPage();
				atlasPage.rendererObject = material;
				atlasRegion.page = atlasPage;
				SpriteAttachmentLoader.atlasTable[instanceID] = atlasRegion;
			}
			Rect textureRect = this.sprite.textureRect;
			textureRect.x = Mathf.InverseLerp(0f, (float)texture.width, textureRect.x);
			textureRect.y = Mathf.InverseLerp(0f, (float)texture.height, textureRect.y);
			textureRect.width = Mathf.InverseLerp(0f, (float)texture.width, textureRect.width);
			textureRect.height = Mathf.InverseLerp(0f, (float)texture.height, textureRect.height);
			Bounds bounds = this.sprite.bounds;
			Vector2 vector = bounds.min;
			Vector2 vector2 = bounds.max;
			Vector2 vector3 = bounds.size;
			float num = 1f / this.sprite.pixelsPerUnit;
			bool rotate = false;
			if (this.sprite.packed)
			{
				rotate = (this.sprite.packingRotation == SpritePackingRotation.Any);
			}
			regionAttachment.SetUVs(textureRect.xMin, textureRect.yMax, textureRect.xMax, textureRect.yMin, rotate);
			regionAttachment.RendererObject = atlasRegion;
			regionAttachment.SetColor(Color.white);
			regionAttachment.ScaleX = 1f;
			regionAttachment.ScaleY = 1f;
			regionAttachment.RegionOffsetX = this.sprite.rect.width * (0.5f - SpriteAttachmentLoader.InverseLerp(vector.x, vector2.x, 0f)) * num;
			regionAttachment.RegionOffsetY = this.sprite.rect.height * (0.5f - SpriteAttachmentLoader.InverseLerp(vector.y, vector2.y, 0f)) * num;
			regionAttachment.Width = vector3.x;
			regionAttachment.Height = vector3.y;
			regionAttachment.RegionWidth = vector3.x;
			regionAttachment.RegionHeight = vector3.y;
			regionAttachment.RegionOriginalWidth = vector3.x;
			regionAttachment.RegionOriginalHeight = vector3.y;
			regionAttachment.UpdateOffset();
			return regionAttachment;
		}

		public MeshAttachment NewMeshAttachment(Skin skin, string name, string path)
		{
			return null;
		}

		public BoundingBoxAttachment NewBoundingBoxAttachment(Skin skin, string name)
		{
			return null;
		}

		public PathAttachment NewPathAttachment(Skin skin, string name)
		{
			return null;
		}

		private static float InverseLerp(float a, float b, float value)
		{
			return (value - a) / (b - a);
		}

		public static Dictionary<int, AtlasRegion> atlasTable = new Dictionary<int, AtlasRegion>();

		public static List<int> premultipliedAtlasIds = new List<int>();

		private UnityEngine.Sprite sprite;

		private Shader shader;
	}
}
