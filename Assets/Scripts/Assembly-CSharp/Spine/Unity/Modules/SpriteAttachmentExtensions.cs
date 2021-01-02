using UnityEngine;

namespace Spine.Unity.Modules
{
    public static class SpriteAttachmentExtensions
	{
		public static Attachment AttachUnitySprite(this Skeleton skeleton, string slotName, UnityEngine.Sprite sprite, string shaderName = "Spine/Skeleton", bool applyPMA = true)
		{
			return skeleton.AttachUnitySprite(slotName, sprite, Shader.Find(shaderName), applyPMA);
		}

		public static Attachment AddUnitySprite(this SkeletonData skeletonData, string slotName, UnityEngine.Sprite sprite, string skinName = "", string shaderName = "Spine/Skeleton", bool applyPMA = true)
		{
			return skeletonData.AddUnitySprite(slotName, sprite, skinName, Shader.Find(shaderName), applyPMA);
		}

		public static RegionAttachment ToRegionAttachment(this UnityEngine.Sprite sprite, string shaderName = "Spine/Skeleton", bool applyPMA = true)
		{
			return sprite.ToRegionAttachment(Shader.Find(shaderName), applyPMA);
		}

		public static Attachment AttachUnitySprite(this Skeleton skeleton, string slotName, UnityEngine.Sprite sprite, Shader shader, bool applyPMA)
		{
			RegionAttachment regionAttachment = sprite.ToRegionAttachment(shader, applyPMA);
			skeleton.FindSlot(slotName).Attachment = regionAttachment;
			return regionAttachment;
		}

		public static Attachment AddUnitySprite(this SkeletonData skeletonData, string slotName, UnityEngine.Sprite sprite, string skinName, Shader shader, bool applyPMA)
		{
			RegionAttachment regionAttachment = sprite.ToRegionAttachment(shader, applyPMA);
			int slotIndex = skeletonData.FindSlotIndex(slotName);
			Skin skin = skeletonData.defaultSkin;
			if (skinName != string.Empty)
			{
				skin = skeletonData.FindSkin(skinName);
			}
			skin.AddAttachment(slotIndex, regionAttachment.Name, regionAttachment);
			return regionAttachment;
		}

		public static RegionAttachment ToRegionAttachment(this UnityEngine.Sprite sprite, Shader shader, bool applyPMA)
		{
			SpriteAttachmentLoader spriteAttachmentLoader = new SpriteAttachmentLoader(sprite, shader, applyPMA);
			return spriteAttachmentLoader.NewRegionAttachment(null, sprite.name, string.Empty);
		}
	}
}
