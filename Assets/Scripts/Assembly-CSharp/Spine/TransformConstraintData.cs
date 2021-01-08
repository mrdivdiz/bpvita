using System;

namespace Spine
{
	public class TransformConstraintData
	{
		public TransformConstraintData(string name)
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

		public ExposedList<BoneData> Bones
		{
			get
			{
				return this.bones;
			}
		}

		public BoneData Target
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

		public float ScaleMix
		{
			get
			{
				return this.scaleMix;
			}
			set
			{
				this.scaleMix = value;
			}
		}

		public float ShearMix
		{
			get
			{
				return this.shearMix;
			}
			set
			{
				this.shearMix = value;
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

		public float OffsetX
		{
			get
			{
				return this.offsetX;
			}
			set
			{
				this.offsetX = value;
			}
		}

		public float OffsetY
		{
			get
			{
				return this.offsetY;
			}
			set
			{
				this.offsetY = value;
			}
		}

		public float OffsetScaleX
		{
			get
			{
				return this.offsetScaleX;
			}
			set
			{
				this.offsetScaleX = value;
			}
		}

		public float OffsetScaleY
		{
			get
			{
				return this.offsetScaleY;
			}
			set
			{
				this.offsetScaleY = value;
			}
		}

		public float OffsetShearY
		{
			get
			{
				return this.offsetShearY;
			}
			set
			{
				this.offsetShearY = value;
			}
		}

		public override string ToString()
		{
			return this.name;
		}

		internal string name;

		internal ExposedList<BoneData> bones = new ExposedList<BoneData>();

		internal BoneData target;

		internal float rotateMix;

		internal float translateMix;

		internal float scaleMix;

		internal float shearMix;

		internal float offsetRotation;

		internal float offsetX;

		internal float offsetY;

		internal float offsetScaleX;

		internal float offsetScaleY;

		internal float offsetShearY;
	}
}
