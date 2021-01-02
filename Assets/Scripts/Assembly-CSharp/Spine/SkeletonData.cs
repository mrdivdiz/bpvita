using System;

namespace Spine
{
	public class SkeletonData
	{
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		public ExposedList<BoneData> Bones
		{
			get
			{
				return this.bones;
			}
		}

		public ExposedList<SlotData> Slots
		{
			get
			{
				return this.slots;
			}
		}

		public ExposedList<Skin> Skins
		{
			get
			{
				return this.skins;
			}
			set
			{
				this.skins = value;
			}
		}

		public Skin DefaultSkin
		{
			get
			{
				return this.defaultSkin;
			}
			set
			{
				this.defaultSkin = value;
			}
		}

		public ExposedList<EventData> Events
		{
			get
			{
				return this.events;
			}
			set
			{
				this.events = value;
			}
		}

		public ExposedList<Animation> Animations
		{
			get
			{
				return this.animations;
			}
			set
			{
				this.animations = value;
			}
		}

		public ExposedList<IkConstraintData> IkConstraints
		{
			get
			{
				return this.ikConstraints;
			}
			set
			{
				this.ikConstraints = value;
			}
		}

		public ExposedList<TransformConstraintData> TransformConstraints
		{
			get
			{
				return this.transformConstraints;
			}
			set
			{
				this.transformConstraints = value;
			}
		}

		public ExposedList<PathConstraintData> PathConstraints
		{
			get
			{
				return this.pathConstraints;
			}
			set
			{
				this.pathConstraints = value;
			}
		}

		public float Width
		{
			get
			{
				return this.width;
			}
			set
			{
				this.width = value;
			}
		}

		public float Height
		{
			get
			{
				return this.height;
			}
			set
			{
				this.height = value;
			}
		}

		public string Version
		{
			get
			{
				return this.version;
			}
			set
			{
				this.version = value;
			}
		}

		public string Hash
		{
			get
			{
				return this.hash;
			}
			set
			{
				this.hash = value;
			}
		}

		public BoneData FindBone(string boneName)
		{
			if (boneName == null)
			{
				throw new ArgumentNullException("boneName", "boneName cannot be null.");
			}
			ExposedList<BoneData> exposedList = this.bones;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				BoneData boneData = exposedList.Items[i];
				if (boneData.name == boneName)
				{
					return boneData;
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
			ExposedList<BoneData> exposedList = this.bones;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				if (exposedList.Items[i].name == boneName)
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		public SlotData FindSlot(string slotName)
		{
			if (slotName == null)
			{
				throw new ArgumentNullException("slotName", "slotName cannot be null.");
			}
			ExposedList<SlotData> exposedList = this.slots;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				SlotData slotData = exposedList.Items[i];
				if (slotData.name == slotName)
				{
					return slotData;
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
			ExposedList<SlotData> exposedList = this.slots;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				if (exposedList.Items[i].name == slotName)
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		public Skin FindSkin(string skinName)
		{
			if (skinName == null)
			{
				throw new ArgumentNullException("skinName", "skinName cannot be null.");
			}
			foreach (Skin skin in this.skins)
			{
				if (skin.name == skinName)
				{
					return skin;
				}
			}
			return null;
		}

		public EventData FindEvent(string eventDataName)
		{
			if (eventDataName == null)
			{
				throw new ArgumentNullException("eventDataName", "eventDataName cannot be null.");
			}
			foreach (EventData eventData in this.events)
			{
				if (eventData.name == eventDataName)
				{
					return eventData;
				}
			}
			return null;
		}

		public Animation FindAnimation(string animationName)
		{
			if (animationName == null)
			{
				throw new ArgumentNullException("animationName", "animationName cannot be null.");
			}
			ExposedList<Animation> exposedList = this.animations;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Animation animation = exposedList.Items[i];
				if (animation.name == animationName)
				{
					return animation;
				}
				i++;
			}
			return null;
		}

		public IkConstraintData FindIkConstraint(string constraintName)
		{
			if (constraintName == null)
			{
				throw new ArgumentNullException("constraintName", "constraintName cannot be null.");
			}
			ExposedList<IkConstraintData> exposedList = this.ikConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				IkConstraintData ikConstraintData = exposedList.Items[i];
				if (ikConstraintData.name == constraintName)
				{
					return ikConstraintData;
				}
				i++;
			}
			return null;
		}

		public TransformConstraintData FindTransformConstraint(string constraintName)
		{
			if (constraintName == null)
			{
				throw new ArgumentNullException("constraintName", "constraintName cannot be null.");
			}
			ExposedList<TransformConstraintData> exposedList = this.transformConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				TransformConstraintData transformConstraintData = exposedList.Items[i];
				if (transformConstraintData.name == constraintName)
				{
					return transformConstraintData;
				}
				i++;
			}
			return null;
		}

		public PathConstraintData FindPathConstraint(string constraintName)
		{
			if (constraintName == null)
			{
				throw new ArgumentNullException("constraintName", "constraintName cannot be null.");
			}
			ExposedList<PathConstraintData> exposedList = this.pathConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				PathConstraintData pathConstraintData = exposedList.Items[i];
				if (pathConstraintData.name.Equals(constraintName))
				{
					return pathConstraintData;
				}
				i++;
			}
			return null;
		}

		public int FindPathConstraintIndex(string pathConstraintName)
		{
			if (pathConstraintName == null)
			{
				throw new ArgumentNullException("pathConstraintName", "pathConstraintName cannot be null.");
			}
			ExposedList<PathConstraintData> exposedList = this.pathConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				if (exposedList.Items[i].name.Equals(pathConstraintName))
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		public override string ToString()
		{
			return this.name ?? base.ToString();
		}

		internal string name;

		internal ExposedList<BoneData> bones = new ExposedList<BoneData>();

		internal ExposedList<SlotData> slots = new ExposedList<SlotData>();

		internal ExposedList<Skin> skins = new ExposedList<Skin>();

		internal Skin defaultSkin;

		internal ExposedList<EventData> events = new ExposedList<EventData>();

		internal ExposedList<Animation> animations = new ExposedList<Animation>();

		internal ExposedList<IkConstraintData> ikConstraints = new ExposedList<IkConstraintData>();

		internal ExposedList<TransformConstraintData> transformConstraints = new ExposedList<TransformConstraintData>();

		internal ExposedList<PathConstraintData> pathConstraints = new ExposedList<PathConstraintData>();

		internal float width;

		internal float height;

		internal string version;

		internal string hash;

		internal string imagesPath;
	}
}
