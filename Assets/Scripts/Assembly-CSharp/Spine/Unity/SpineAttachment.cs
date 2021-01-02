using System;

namespace Spine.Unity
{
	public class SpineAttachment : SpineAttributeBase
	{
		public SpineAttachment(bool currentSkinOnly = true, bool returnAttachmentPath = false, bool placeholdersOnly = false, string slotField = "", string dataField = "")
		{
			this.currentSkinOnly = currentSkinOnly;
			this.returnAttachmentPath = returnAttachmentPath;
			this.placeholdersOnly = placeholdersOnly;
			this.slotField = slotField;
			this.dataField = dataField;
		}

		public static Hierarchy GetHierarchy(string fullPath)
		{
			return new Hierarchy(fullPath);
		}

		public static Attachment GetAttachment(string attachmentPath, SkeletonData skeletonData)
		{
            Hierarchy hierarchy = SpineAttachment.GetHierarchy(attachmentPath);
			if (hierarchy.name == string.Empty)
			{
				return null;
			}
			return skeletonData.FindSkin(hierarchy.skin).GetAttachment(skeletonData.FindSlotIndex(hierarchy.slot), hierarchy.name);
		}

		public static Attachment GetAttachment(string attachmentPath, SkeletonDataAsset skeletonDataAsset)
		{
			return SpineAttachment.GetAttachment(attachmentPath, skeletonDataAsset.GetSkeletonData(true));
		}

		public bool returnAttachmentPath;

		public bool currentSkinOnly;

		public bool placeholdersOnly;

		public string slotField = string.Empty;

		public struct Hierarchy
		{
			public Hierarchy(string fullPath)
			{
				string[] array = fullPath.Split(new char[]
				{
					'/'
				}, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 0)
				{
					this.skin = string.Empty;
					this.slot = string.Empty;
					this.name = string.Empty;
					return;
				}
				if (array.Length < 2)
				{
					throw new Exception("Cannot generate Attachment Hierarchy from string! Not enough components! [" + fullPath + "]");
				}
				this.skin = array[0];
				this.slot = array[1];
				this.name = string.Empty;
				for (int i = 2; i < array.Length; i++)
				{
					this.name += array[i];
				}
			}

			public string skin;

			public string slot;

			public string name;
		}
	}
}
