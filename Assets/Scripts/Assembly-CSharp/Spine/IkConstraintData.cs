using System;
using System.Collections.Generic;

namespace Spine
{
	public class IkConstraintData
	{
		public IkConstraintData(string name)
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

		public List<BoneData> Bones
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

		public int BendDirection
		{
			get
			{
				return this.bendDirection;
			}
			set
			{
				this.bendDirection = value;
			}
		}

		public float Mix
		{
			get
			{
				return this.mix;
			}
			set
			{
				this.mix = value;
			}
		}

		public override string ToString()
		{
			return this.name;
		}

		internal string name;

		internal List<BoneData> bones = new List<BoneData>();

		internal BoneData target;

		internal int bendDirection = 1;

		internal float mix = 1f;
	}
}
