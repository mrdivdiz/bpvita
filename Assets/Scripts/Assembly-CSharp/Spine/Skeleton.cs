using System;
using System.Collections.Generic;

namespace Spine
{
	public class Skeleton
	{
		public Skeleton(SkeletonData data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data", "data cannot be null.");
			}
			this.data = data;
			this.bones = new ExposedList<Bone>(data.bones.Count);
			foreach (BoneData boneData in data.bones)
			{
				Bone item;
				if (boneData.parent == null)
				{
					item = new Bone(boneData, this, null);
				}
				else
				{
					Bone bone = this.bones.Items[boneData.parent.index];
					item = new Bone(boneData, this, bone);
					bone.children.Add(item);
				}
				this.bones.Add(item);
			}
			this.slots = new ExposedList<Slot>(data.slots.Count);
			this.drawOrder = new ExposedList<Slot>(data.slots.Count);
			foreach (SlotData slotData in data.slots)
			{
				Bone bone2 = this.bones.Items[slotData.boneData.index];
				Slot item2 = new Slot(slotData, bone2);
				this.slots.Add(item2);
				this.drawOrder.Add(item2);
			}
			this.ikConstraints = new ExposedList<IkConstraint>(data.ikConstraints.Count);
			this.ikConstraintsSorted = new ExposedList<IkConstraint>(data.ikConstraints.Count);
			foreach (IkConstraintData ikConstraintData in data.ikConstraints)
			{
				this.ikConstraints.Add(new IkConstraint(ikConstraintData, this));
			}
			this.transformConstraints = new ExposedList<TransformConstraint>(data.transformConstraints.Count);
			foreach (TransformConstraintData transformConstraintData in data.transformConstraints)
			{
				this.transformConstraints.Add(new TransformConstraint(transformConstraintData, this));
			}
			this.pathConstraints = new ExposedList<PathConstraint>(data.pathConstraints.Count);
			foreach (PathConstraintData pathConstraintData in data.pathConstraints)
			{
				this.pathConstraints.Add(new PathConstraint(pathConstraintData, this));
			}
			this.UpdateCache();
			this.UpdateWorldTransform();
		}

		public SkeletonData Data
		{
			get
			{
				return this.data;
			}
		}

		public ExposedList<Bone> Bones
		{
			get
			{
				return this.bones;
			}
		}

		public ExposedList<IUpdatable> UpdateCacheList
		{
			get
			{
				return this.updateCache;
			}
		}

		public ExposedList<Slot> Slots
		{
			get
			{
				return this.slots;
			}
		}

		public ExposedList<Slot> DrawOrder
		{
			get
			{
				return this.drawOrder;
			}
		}

		public ExposedList<IkConstraint> IkConstraints
		{
			get
			{
				return this.ikConstraints;
			}
		}

		public ExposedList<PathConstraint> PathConstraints
		{
			get
			{
				return this.pathConstraints;
			}
		}

		public ExposedList<TransformConstraint> TransformConstraints
		{
			get
			{
				return this.transformConstraints;
			}
		}

		public Skin Skin
		{
			get
			{
				return this.skin;
			}
			set
			{
				this.skin = value;
			}
		}

		public float R
		{
			get
			{
				return this.r;
			}
			set
			{
				this.r = value;
			}
		}

		public float G
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		public float B
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		public float A
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		public float Time
		{
			get
			{
				return this.time;
			}
			set
			{
				this.time = value;
			}
		}

		public float X
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}

		public float Y
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		public bool FlipX
		{
			get
			{
				return this.flipX;
			}
			set
			{
				this.flipX = value;
			}
		}

		public bool FlipY
		{
			get
			{
				return this.flipY;
			}
			set
			{
				this.flipY = value;
			}
		}

		public Bone RootBone
		{
			get
			{
				return (this.bones.Count != 0) ? this.bones.Items[0] : null;
			}
		}

		public void UpdateCache()
		{
			ExposedList<IUpdatable> exposedList = this.updateCache;
			exposedList.Clear(true);
			ExposedList<Bone> exposedList2 = this.bones;
			int i = 0;
			int count = exposedList2.Count;
			while (i < count)
			{
				exposedList2.Items[i].sorted = false;
				i++;
			}
			ExposedList<IkConstraint> exposedList3 = this.ikConstraintsSorted;
			exposedList3.Clear(true);
			exposedList3.AddRange(this.ikConstraints);
			int count2 = exposedList3.Count;
			int j = 0;
			int num = count2;
			while (j < num)
			{
				IkConstraint ikConstraint = exposedList3.Items[j];
				Bone parent = ikConstraint.bones.Items[0].parent;
				int num2 = 0;
				while (parent != null)
				{
					parent = parent.parent;
					num2++;
				}
				ikConstraint.level = num2;
				j++;
			}
			for (int k = 1; k < count2; k++)
			{
				IkConstraint ikConstraint2 = exposedList3.Items[k];
				int level = ikConstraint2.level;
				int l;
				for (l = k - 1; l >= 0; l--)
				{
					IkConstraint ikConstraint3 = exposedList3.Items[l];
					if (ikConstraint3.level < level)
					{
						break;
					}
					exposedList3.Items[l + 1] = ikConstraint3;
				}
				exposedList3.Items[l + 1] = ikConstraint2;
			}
			int m = 0;
			int count3 = exposedList3.Count;
			while (m < count3)
			{
				IkConstraint ikConstraint4 = exposedList3.Items[m];
				Bone target = ikConstraint4.target;
				this.SortBone(target);
				ExposedList<Bone> exposedList4 = ikConstraint4.bones;
				Bone bone = exposedList4.Items[0];
				this.SortBone(bone);
				exposedList.Add(ikConstraint4);
				this.SortReset(bone.children);
				exposedList4.Items[exposedList4.Count - 1].sorted = true;
				m++;
			}
			ExposedList<PathConstraint> exposedList5 = this.pathConstraints;
			int n = 0;
			int count4 = exposedList5.Count;
			while (n < count4)
			{
				PathConstraint pathConstraint = exposedList5.Items[n];
				Slot target2 = pathConstraint.target;
				int index = target2.data.index;
				Bone bone2 = target2.bone;
				if (this.skin != null)
				{
					this.SortPathConstraintAttachment(this.skin, index, bone2);
				}
				if (this.data.defaultSkin != null && this.data.defaultSkin != this.skin)
				{
					this.SortPathConstraintAttachment(this.data.defaultSkin, index, bone2);
				}
				int num3 = 0;
				int count5 = this.data.skins.Count;
				while (num3 < count5)
				{
					this.SortPathConstraintAttachment(this.data.skins.Items[num3], index, bone2);
					num3++;
				}
				PathAttachment pathAttachment = target2.Attachment as PathAttachment;
				if (pathAttachment != null)
				{
					this.SortPathConstraintAttachment(pathAttachment, bone2);
				}
				ExposedList<Bone> exposedList6 = pathConstraint.bones;
				int count6 = exposedList6.Count;
				for (int num4 = 0; num4 < count6; num4++)
				{
					this.SortBone(exposedList6.Items[num4]);
				}
				exposedList.Add(pathConstraint);
				for (int num5 = 0; num5 < count6; num5++)
				{
					this.SortReset(exposedList6.Items[num5].children);
				}
				for (int num6 = 0; num6 < count6; num6++)
				{
					exposedList6.Items[num6].sorted = true;
				}
				n++;
			}
			ExposedList<TransformConstraint> exposedList7 = this.transformConstraints;
			int num7 = 0;
			int count7 = exposedList7.Count;
			while (num7 < count7)
			{
				TransformConstraint transformConstraint = exposedList7.Items[num7];
				this.SortBone(transformConstraint.target);
				ExposedList<Bone> exposedList8 = transformConstraint.bones;
				int count8 = exposedList8.Count;
				for (int num8 = 0; num8 < count8; num8++)
				{
					this.SortBone(exposedList8.Items[num8]);
				}
				exposedList.Add(transformConstraint);
				for (int num9 = 0; num9 < count8; num9++)
				{
					this.SortReset(exposedList8.Items[num9].children);
				}
				for (int num10 = 0; num10 < count8; num10++)
				{
					exposedList8.Items[num10].sorted = true;
				}
				num7++;
			}
			int num11 = 0;
			int count9 = exposedList2.Count;
			while (num11 < count9)
			{
				this.SortBone(exposedList2.Items[num11]);
				num11++;
			}
		}

		private void SortPathConstraintAttachment(Skin skin, int slotIndex, Bone slotBone)
		{
			foreach (KeyValuePair<Skin.AttachmentKeyTuple, Attachment> keyValuePair in skin.Attachments)
			{
				if (keyValuePair.Key.slotIndex == slotIndex)
				{
					this.SortPathConstraintAttachment(keyValuePair.Value, slotBone);
				}
			}
		}

		private void SortPathConstraintAttachment(Attachment attachment, Bone slotBone)
		{
			PathAttachment pathAttachment = attachment as PathAttachment;
			if (pathAttachment == null)
			{
				return;
			}
			int[] array = pathAttachment.bones;
			if (array == null)
			{
				this.SortBone(slotBone);
			}
			else
			{
				ExposedList<Bone> exposedList = this.bones;
				int i = 0;
				int num = array.Length;
				while (i < num)
				{
					this.SortBone(exposedList.Items[array[i]]);
					i++;
				}
			}
		}

		private void SortBone(Bone bone)
		{
			if (bone.sorted)
			{
				return;
			}
			Bone parent = bone.parent;
			if (parent != null)
			{
				this.SortBone(parent);
			}
			bone.sorted = true;
			this.updateCache.Add(bone);
		}

		private void SortReset(ExposedList<Bone> bones)
		{
			Bone[] items = bones.Items;
			int i = 0;
			int count = bones.Count;
			while (i < count)
			{
				Bone bone = items[i];
				if (bone.sorted)
				{
					this.SortReset(bone.children);
				}
				bone.sorted = false;
				i++;
			}
		}

		public void UpdateWorldTransform()
		{
			IUpdatable[] items = this.updateCache.Items;
			int i = 0;
			int count = this.updateCache.Count;
			while (i < count)
			{
				items[i].Update();
				i++;
			}
		}

		public void SetToSetupPose()
		{
			this.SetBonesToSetupPose();
			this.SetSlotsToSetupPose();
		}

		public void SetBonesToSetupPose()
		{
			Bone[] items = this.bones.Items;
			int i = 0;
			int count = this.bones.Count;
			while (i < count)
			{
				items[i].SetToSetupPose();
				i++;
			}
			IkConstraint[] items2 = this.ikConstraints.Items;
			int j = 0;
			int count2 = this.ikConstraints.Count;
			while (j < count2)
			{
				IkConstraint ikConstraint = items2[j];
				ikConstraint.bendDirection = ikConstraint.data.bendDirection;
				ikConstraint.mix = ikConstraint.data.mix;
				j++;
			}
			TransformConstraint[] items3 = this.transformConstraints.Items;
			int k = 0;
			int count3 = this.transformConstraints.Count;
			while (k < count3)
			{
				TransformConstraint transformConstraint = items3[k];
				TransformConstraintData transformConstraintData = transformConstraint.data;
				transformConstraint.rotateMix = transformConstraintData.rotateMix;
				transformConstraint.translateMix = transformConstraintData.translateMix;
				transformConstraint.scaleMix = transformConstraintData.scaleMix;
				transformConstraint.shearMix = transformConstraintData.shearMix;
				k++;
			}
			PathConstraint[] items4 = this.pathConstraints.Items;
			int l = 0;
			int count4 = this.pathConstraints.Count;
			while (l < count4)
			{
				PathConstraint pathConstraint = items4[l];
				PathConstraintData pathConstraintData = pathConstraint.data;
				pathConstraint.position = pathConstraintData.position;
				pathConstraint.spacing = pathConstraintData.spacing;
				pathConstraint.rotateMix = pathConstraintData.rotateMix;
				pathConstraint.translateMix = pathConstraintData.translateMix;
				l++;
			}
		}

		public void SetSlotsToSetupPose()
		{
			ExposedList<Slot> exposedList = this.slots;
			Slot[] items = exposedList.Items;
			this.drawOrder.Clear(true);
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				this.drawOrder.Add(items[i]);
				i++;
			}
			int j = 0;
			int count2 = exposedList.Count;
			while (j < count2)
			{
				items[j].SetToSetupPose();
				j++;
			}
		}

		public Bone FindBone(string boneName)
		{
			if (boneName == null)
			{
				throw new ArgumentNullException("boneName", "boneName cannot be null.");
			}
			ExposedList<Bone> exposedList = this.bones;
			Bone[] items = exposedList.Items;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Bone bone = items[i];
				if (bone.data.name == boneName)
				{
					return bone;
				}
				i++;
			}
			return null;
		}

		public int FindBoneIndex(string boneName)
		{
			if (boneName == null)
			{
				throw new ArgumentNullException("boneName", "boneName cannot be null.");
			}
			ExposedList<Bone> exposedList = this.bones;
			Bone[] items = exposedList.Items;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				if (items[i].data.name == boneName)
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		public Slot FindSlot(string slotName)
		{
			if (slotName == null)
			{
				throw new ArgumentNullException("slotName", "slotName cannot be null.");
			}
			ExposedList<Slot> exposedList = this.slots;
			Slot[] items = exposedList.Items;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Slot slot = items[i];
				if (slot.data.name == slotName)
				{
					return slot;
				}
				i++;
			}
			return null;
		}

		public int FindSlotIndex(string slotName)
		{
			if (slotName == null)
			{
				throw new ArgumentNullException("slotName", "slotName cannot be null.");
			}
			ExposedList<Slot> exposedList = this.slots;
			Slot[] items = exposedList.Items;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				if (items[i].data.name.Equals(slotName))
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		public void SetSkin(string skinName)
		{
			Skin skin = this.data.FindSkin(skinName);
			if (skin == null)
			{
				throw new ArgumentException("Skin not found: " + skinName, "skinName");
			}
			this.SetSkin(skin);
		}

		public void SetSkin(Skin newSkin)
		{
			if (newSkin != null)
			{
				if (this.skin != null)
				{
					newSkin.AttachAll(this, this.skin);
				}
				else
				{
					ExposedList<Slot> exposedList = this.slots;
					int i = 0;
					int count = exposedList.Count;
					while (i < count)
					{
						Slot slot = exposedList.Items[i];
						string attachmentName = slot.data.attachmentName;
						if (attachmentName != null)
						{
							Attachment attachment = newSkin.GetAttachment(i, attachmentName);
							if (attachment != null)
							{
								slot.Attachment = attachment;
							}
						}
						i++;
					}
				}
			}
			this.skin = newSkin;
		}

		public Attachment GetAttachment(string slotName, string attachmentName)
		{
			return this.GetAttachment(this.data.FindSlotIndex(slotName), attachmentName);
		}

		public Attachment GetAttachment(int slotIndex, string attachmentName)
		{
			if (attachmentName == null)
			{
				throw new ArgumentNullException("attachmentName", "attachmentName cannot be null.");
			}
			if (this.skin != null)
			{
				Attachment attachment = this.skin.GetAttachment(slotIndex, attachmentName);
				if (attachment != null)
				{
					return attachment;
				}
			}
			if (this.data.defaultSkin != null)
			{
				return this.data.defaultSkin.GetAttachment(slotIndex, attachmentName);
			}
			return null;
		}

		public void SetAttachment(string slotName, string attachmentName)
		{
			if (slotName == null)
			{
				throw new ArgumentNullException("slotName", "slotName cannot be null.");
			}
			ExposedList<Slot> exposedList = this.slots;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Slot slot = exposedList.Items[i];
				if (slot.data.name == slotName)
				{
					Attachment attachment = null;
					if (attachmentName != null)
					{
						attachment = this.GetAttachment(i, attachmentName);
						if (attachment == null)
						{
							throw new Exception("Attachment not found: " + attachmentName + ", for slot: " + slotName);
						}
					}
					slot.Attachment = attachment;
					return;
				}
				i++;
			}
			throw new Exception("Slot not found: " + slotName);
		}

		public IkConstraint FindIkConstraint(string constraintName)
		{
			if (constraintName == null)
			{
				throw new ArgumentNullException("constraintName", "constraintName cannot be null.");
			}
			ExposedList<IkConstraint> exposedList = this.ikConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				IkConstraint ikConstraint = exposedList.Items[i];
				if (ikConstraint.data.name == constraintName)
				{
					return ikConstraint;
				}
				i++;
			}
			return null;
		}

		public TransformConstraint FindTransformConstraint(string constraintName)
		{
			if (constraintName == null)
			{
				throw new ArgumentNullException("constraintName", "constraintName cannot be null.");
			}
			ExposedList<TransformConstraint> exposedList = this.transformConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				TransformConstraint transformConstraint = exposedList.Items[i];
				if (transformConstraint.data.name == constraintName)
				{
					return transformConstraint;
				}
				i++;
			}
			return null;
		}

		public PathConstraint FindPathConstraint(string constraintName)
		{
			if (constraintName == null)
			{
				throw new ArgumentNullException("constraintName", "constraintName cannot be null.");
			}
			ExposedList<PathConstraint> exposedList = this.pathConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				PathConstraint pathConstraint = exposedList.Items[i];
				if (pathConstraint.data.name.Equals(constraintName))
				{
					return pathConstraint;
				}
				i++;
			}
			return null;
		}

		public void Update(float delta)
		{
			this.time += delta;
		}

		internal SkeletonData data;

		internal ExposedList<Bone> bones;

		internal ExposedList<Slot> slots;

		internal ExposedList<Slot> drawOrder;

		internal ExposedList<IkConstraint> ikConstraints;

		internal ExposedList<IkConstraint> ikConstraintsSorted;

		internal ExposedList<TransformConstraint> transformConstraints;

		internal ExposedList<PathConstraint> pathConstraints;

		internal ExposedList<IUpdatable> updateCache = new ExposedList<IUpdatable>();

		internal Skin skin;

		internal float r = 1f;

		internal float g = 1f;

		internal float b = 1f;

		internal float a = 1f;

		internal float time;

		internal bool flipX;

		internal bool flipY;

		internal float x;

		internal float y;
	}
}
