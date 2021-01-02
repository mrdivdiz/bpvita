using System;

namespace Spine
{
	public class BoneData
	{
		public BoneData(int index, string name, BoneData parent)
		{
			if (index < 0)
			{
				throw new ArgumentException("index must be >= 0", "index");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null.");
			}
			this.index = index;
			this.name = name;
			this.parent = parent;
		}

		public int Index
		{
			get
			{
				return this.index;
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public BoneData Parent
		{
			get
			{
				return this.parent;
			}
		}

		public float Length
		{
			get
			{
				return this.length;
			}
			set
			{
				this.length = value;
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

		public float Rotation
		{
			get
			{
				return this.rotation;
			}
			set
			{
				this.rotation = value;
			}
		}

		public float ScaleX
		{
			get
			{
				return this.scaleX;
			}
			set
			{
				this.scaleX = value;
			}
		}

		public float ScaleY
		{
			get
			{
				return this.scaleY;
			}
			set
			{
				this.scaleY = value;
			}
		}

		public float ShearX
		{
			get
			{
				return this.shearX;
			}
			set
			{
				this.shearX = value;
			}
		}

		public float ShearY
		{
			get
			{
				return this.shearY;
			}
			set
			{
				this.shearY = value;
			}
		}

		public bool InheritRotation
		{
			get
			{
				return this.inheritRotation;
			}
			set
			{
				this.inheritRotation = value;
			}
		}

		public bool InheritScale
		{
			get
			{
				return this.inheritScale;
			}
			set
			{
				this.inheritScale = value;
			}
		}

		public override string ToString()
		{
			return this.name;
		}

		internal int index;

		internal string name;

		internal BoneData parent;

		internal float length;

		internal float x;

		internal float y;

		internal float rotation;

		internal float scaleX = 1f;

		internal float scaleY = 1f;

		internal float shearX;

		internal float shearY;

		internal bool inheritRotation = true;

		internal bool inheritScale = true;
	}
}
