using System;

namespace Spine
{
	public static class SkeletonExtensions
	{
		public static void PoseWithAnimation(this Skeleton skeleton, string animationName, float time, bool loop)
		{
			Animation animation = skeleton.data.FindAnimation(animationName);
			if (animation == null)
			{
				return;
			}
			animation.Apply(skeleton, 0f, time, loop, null);
		}

		public static void SetDrawOrderToSetupPose(this Skeleton skeleton)
		{
			Slot[] items = skeleton.slots.Items;
			int count = skeleton.slots.Count;
			ExposedList<Slot> drawOrder = skeleton.drawOrder;
			drawOrder.Clear(false);
			drawOrder.GrowIfNeeded(count);
			Array.Copy(items, drawOrder.Items, count);
			drawOrder.Count = count;
		}

		public static void SetColorToSetupPose(this Slot slot)
		{
			slot.r = slot.data.r;
			slot.g = slot.data.g;
			slot.b = slot.data.b;
			slot.a = slot.data.a;
		}

		public static void SetAttachmentToSetupPose(this Slot slot)
		{
			SlotData data = slot.data;
			slot.Attachment = slot.bone.skeleton.GetAttachment(data.name, data.attachmentName);
		}

		public static void SetSlotAttachmentToSetupPose(this Skeleton skeleton, int slotIndex)
		{
			Slot slot = skeleton.slots.Items[slotIndex];
			if (slot.data.attachmentName == null)
			{
				slot.Attachment = null;
			}
			else
			{
				slot.attachment = null;
				slot.Attachment = skeleton.GetAttachment(slotIndex, slot.data.attachmentName);
			}
		}

		public static void SetKeyedItemsToSetupPose(this Animation animation, Skeleton skeleton)
		{
			Timeline[] items = animation.timelines.Items;
			int i = 0;
			int num = items.Length;
			while (i < num)
			{
				items[i].SetToSetupPose(skeleton);
				i++;
			}
		}

		public static void SetToSetupPose(this Timeline timeline, Skeleton skeleton)
		{
			if (timeline != null)
			{
				if (timeline is RotateTimeline)
				{
					Bone bone = skeleton.bones.Items[((RotateTimeline)timeline).boneIndex];
					bone.rotation = bone.data.rotation;
				}
				else if (timeline is TranslateTimeline)
				{
					Bone bone2 = skeleton.bones.Items[((TranslateTimeline)timeline).boneIndex];
					bone2.x = bone2.data.x;
					bone2.y = bone2.data.y;
				}
				else if (timeline is ScaleTimeline)
				{
					Bone bone3 = skeleton.bones.Items[((ScaleTimeline)timeline).boneIndex];
					bone3.scaleX = bone3.data.scaleX;
					bone3.scaleY = bone3.data.scaleY;
				}
				else if (timeline is DeformTimeline)
				{
					Slot slot = skeleton.slots.Items[((DeformTimeline)timeline).slotIndex];
					slot.attachmentVertices.Clear(false);
				}
				else if (timeline is AttachmentTimeline)
				{
					skeleton.SetSlotAttachmentToSetupPose(((AttachmentTimeline)timeline).slotIndex);
				}
				else if (timeline is ColorTimeline)
				{
					skeleton.slots.Items[((ColorTimeline)timeline).slotIndex].SetColorToSetupPose();
				}
				else if (timeline is IkConstraintTimeline)
				{
					IkConstraintTimeline ikConstraintTimeline = (IkConstraintTimeline)timeline;
					IkConstraint ikConstraint = skeleton.ikConstraints.Items[ikConstraintTimeline.ikConstraintIndex];
					IkConstraintData data = ikConstraint.data;
					ikConstraint.bendDirection = data.bendDirection;
					ikConstraint.mix = data.mix;
				}
				else if (timeline is DrawOrderTimeline)
				{
					skeleton.SetDrawOrderToSetupPose();
				}
			}
		}
	}
}
