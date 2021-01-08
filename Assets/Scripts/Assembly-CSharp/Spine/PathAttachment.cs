namespace Spine
{
    public class PathAttachment : VertexAttachment
	{
		public PathAttachment(string name) : base(name)
		{
		}

		public float[] Lengths
		{
			get
			{
				return this.lengths;
			}
			set
			{
				this.lengths = value;
			}
		}

		public bool Closed
		{
			get
			{
				return this.closed;
			}
			set
			{
				this.closed = value;
			}
		}

		public bool ConstantSpeed
		{
			get
			{
				return this.constantSpeed;
			}
			set
			{
				this.constantSpeed = value;
			}
		}

		internal float[] lengths;

		internal bool closed;

		internal bool constantSpeed;
	}
}
