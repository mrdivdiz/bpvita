using System;
using System.Collections.Generic;

namespace Spine
{
	public class Skin
	{
		public Skin(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null.");
			}
			this.name = name;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public Dictionary<AttachmentKeyTuple, Attachment> Attachments
		{
			get
			{
				return this.attachments;
			}
		}

		public void AddAttachment(int slotIndex, string name, Attachment attachment)
		{
			if (attachment == null)
			{
				throw new ArgumentNullException("attachment", "attachment cannot be null.");
			}
			this.attachments[new AttachmentKeyTuple(slotIndex, name)] = attachment;
		}

		public Attachment GetAttachment(int slotIndex, string name)
		{
			Attachment result;
			this.attachments.TryGetValue(new AttachmentKeyTuple(slotIndex, name), out result);
			return result;
		}

		public void FindNamesForSlot(int slotIndex, List<string> names)
		{
			if (names == null)
			{
				throw new ArgumentNullException("names", "names cannot be null.");
			}
			foreach (AttachmentKeyTuple attachmentKeyTuple in this.attachments.Keys)
			{
				if (attachmentKeyTuple.slotIndex == slotIndex)
				{
					names.Add(attachmentKeyTuple.name);
				}
			}
		}

		public void FindAttachmentsForSlot(int slotIndex, List<Attachment> attachments)
		{
			if (attachments == null)
			{
				throw new ArgumentNullException("attachments", "attachments cannot be null.");
			}
			foreach (KeyValuePair<AttachmentKeyTuple, Attachment> keyValuePair in this.attachments)
			{
				if (keyValuePair.Key.slotIndex == slotIndex)
				{
					attachments.Add(keyValuePair.Value);
				}
			}
		}

		public override string ToString()
		{
			return this.name;
		}

		internal void AttachAll(Skeleton skeleton, Skin oldSkin)
		{
			foreach (KeyValuePair<AttachmentKeyTuple, Attachment> keyValuePair in oldSkin.attachments)
			{
				int slotIndex = keyValuePair.Key.slotIndex;
				Slot slot = skeleton.slots.Items[slotIndex];
				if (slot.attachment == keyValuePair.Value)
				{
					Attachment attachment = this.GetAttachment(slotIndex, keyValuePair.Key.name);
					if (attachment != null)
					{
						slot.Attachment = attachment;
					}
				}
			}
		}

		internal string name;

		private Dictionary<AttachmentKeyTuple, Attachment> attachments = new Dictionary<AttachmentKeyTuple, Attachment>(Skin.AttachmentKeyTupleComparer.Instance);

		public struct AttachmentKeyTuple
		{
			public AttachmentKeyTuple(int slotIndex, string name)
			{
				this.slotIndex = slotIndex;
				this.name = name;
				this.nameHashCode = this.name.GetHashCode();
			}

			public readonly int slotIndex;

			public readonly string name;

			internal readonly int nameHashCode;
		}

		private class AttachmentKeyTupleComparer : IEqualityComparer<AttachmentKeyTuple>
		{
			bool IEqualityComparer<AttachmentKeyTuple>.Equals(AttachmentKeyTuple o1, AttachmentKeyTuple o2)
			{
				return o1.slotIndex == o2.slotIndex && o1.nameHashCode == o2.nameHashCode && o1.name == o2.name;
			}

			int IEqualityComparer<AttachmentKeyTuple>.GetHashCode(AttachmentKeyTuple o)
			{
				return o.slotIndex;
			}

			internal static readonly AttachmentKeyTupleComparer Instance = new AttachmentKeyTupleComparer();
		}
	}
}
