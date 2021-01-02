using System;
using UnityEngine;

namespace Spine.Unity.Modules
{
	public class AtlasRegionAttacher : MonoBehaviour
	{
		private void Awake()
		{
			SkeletonRenderer component = base.GetComponent<SkeletonRenderer>();
			component.OnRebuild = (SkeletonRenderer.SkeletonRendererDelegate)Delegate.Combine(component.OnRebuild, new SkeletonRenderer.SkeletonRendererDelegate(this.Apply));
		}

		private void Apply(SkeletonRenderer skeletonRenderer)
		{
			this.atlas = this.atlasAsset.GetAtlas();
			AtlasAttachmentLoader atlasAttachmentLoader = new AtlasAttachmentLoader(new Atlas[]
			{
				this.atlas
			});
			float scale = skeletonRenderer.skeletonDataAsset.scale;
			foreach (object obj in this.attachments)
			{
                SlotRegionPair slotRegionPair = (SlotRegionPair)obj;
				RegionAttachment regionAttachment = atlasAttachmentLoader.NewRegionAttachment(null, slotRegionPair.region, slotRegionPair.region);
				regionAttachment.Width = regionAttachment.RegionOriginalWidth * scale;
				regionAttachment.Height = regionAttachment.RegionOriginalHeight * scale;
				regionAttachment.SetColor(new Color(1f, 1f, 1f, 1f));
				regionAttachment.UpdateOffset();
				Slot slot = skeletonRenderer.skeleton.FindSlot(slotRegionPair.slot);
				slot.Attachment = regionAttachment;
			}
		}

		public AtlasAsset atlasAsset;

		public SlotRegionPair[] attachments;

		private Atlas atlas;

		[Serializable]
		public class SlotRegionPair
		{
			[SpineSlot("", "", false)]
			public string slot;

			[SpineAtlasRegion]
			public string region;
		}
	}
}
