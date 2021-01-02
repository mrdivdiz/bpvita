using System;

namespace Spine
{
	public class PathConstraintData
	{
		public PathConstraintData(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null.");
			}
			this.name = name;
		}

		public ExposedList<BoneData> Bones
		{
			get
			{
				return this.bones;
			}
		}

		public SlotData Target
		{
			get
			{
				return this.target;
			}
			set
			{
				this.target = value;
			}
		}

		public PositionMode PositionMode
		{
			get
			{
				return this.positionMode;
			}
			set
			{
				this.positionMode = value;
			}
		}

		public SpacingMode SpacingMode
		{
			get
			{
				return this.spacingMode;
			}
			set
			{
				this.spacingMode = value;
			}
		}

		public RotateMode RotateMode
		{
			get
			{
				return this.rotateMode;
			}
			set
			{
				this.rotateMode = value;
			}
		}

		public float OffsetRotation
		{
			get
			{
				return this.offsetRotation;
			}
			set
			{
				this.offsetRotation = value;
			}
		}

		public float Position
		{
			get
			{
				return this.position;
			}
			set
			{
				this.position = value;
			}
		}

		public float Spacing
		{
			get
			{
				return this.spacing;
			}
			set
			{
				this.spacing = value;
			}
		}

		public float RotateMix
		{
			get
			{
				return this.rotateMix;
			}
			set
			{
				this.rotateMix = value;
			}
		}

		public float TranslateMix
		{
			get
			{
				return this.translateMix;
			}
			set
			{
				this.translateMix = value;
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		internal string name;

		internal ExposedList<BoneData> bones = new ExposedList<BoneData>();

		internal SlotData target;

		internal PositionMode positionMode;

		internal SpacingMode spacingMode;

		internal RotateMode rotateMode;

		internal float offsetRotation;

		internal float position;

		internal float spacing;

		internal float rotateMix;

		internal float translateMix;
	}
}
