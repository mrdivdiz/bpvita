using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spine.Unity.Modules
{
	public class CustomSkin : MonoBehaviour
	{
		private void Start()
		{
			this.skeletonRenderer = base.GetComponent<SkeletonRenderer>();
			Skeleton skeleton = this.skeletonRenderer.skeleton;
			this.customSkin = new Skin("CustomSkin");
			foreach (SkinPair skinPair in this.skinItems)
			{
				Attachment attachment = SpineAttachment.GetAttachment(skinPair.sourceAttachmentPath, this.skinSource);
				this.customSkin.AddAttachment(skeleton.FindSlotIndex(skinPair.targetSlot), skinPair.targetAttachment, attachment);
			}
			skeleton.SetSkin(this.customSkin);
		}

		public SkeletonDataAsset skinSource;

		[FormerlySerializedAs("skinning")]
		public SkinPair[] skinItems;

		public Skin customSkin;

		private SkeletonRenderer skeletonRenderer;

		[Serializable]
		public class SkinPair
		{
			[SpineAttachment(false, true, false, "", "skinSource")]
			[FormerlySerializedAs("sourceAttachment")]
			public string sourceAttachmentPath;

			[SpineSlot("", "", false)]
			public string targetSlot;

			[SpineAttachment(true, false, true, "", "")]
			public string targetAttachment;
		}
	}
}
