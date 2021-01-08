using System;

namespace Spine
{
	public class Slot
	{
		public Slot(SlotData data, Bone bone)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data", "data cannot be null.");
			}
			if (bone == null)
			{
				throw new ArgumentNullException("bone", "bone cannot be null.");
			}
			this.data = data;
			this.bone = bone;
			this.SetToSetupPose();
		}

		public SlotData Data
		{
			get
			{
				return this.data;
			}
		}

		public Bone Bone
		{
			get
			{
				return this.bone;
			}
		}

		public Skeleton Skeleton
		{
			get
			{
				return this.bone.skeleton;
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

		public Attachment Attachment
		{
			get
			{
				return this.attachment;
			}
			set
			{
				if (this.attachment == value)
				{
					return;
				}
				this.attachment = value;
				this.attachmentTime = this.bone.skeleton.time;
				this.attachmentVertices.Clear(false);
			}
		}

		public float AttachmentTime
		{
			get
			{
				return this.bone.skeleton.time - this.attachmentTime;
			}
			set
			{
				this.attachmentTime = this.bone.skeleton.time - value;
			}
		}

		public ExposedList<float> AttachmentVertices
		{
			get
			{
				return this.attachmentVertices;
			}
			set
			{
				this.attachmentVertices = value;
			}
		}

		public void SetToSetupPose()
		{
			this.r = this.data.r;
			this.g = this.data.g;
			this.b = this.data.b;
			this.a = this.data.a;
			if (this.data.attachmentName == null)
			{
				this.Attachment = null;
			}
			else
			{
				this.attachment = null;
				this.Attachment = this.bone.skeleton.GetAttachment(this.data.index, this.data.attachmentName);
			}
		}

		public override string ToString()
		{
			return this.data.name;
		}

		internal SlotData data;

		internal Bone bone;

		internal float r;

		internal float g;

		internal float b;

		internal float a;

		internal Attachment attachment;

		internal float attachmentTime;

		internal ExposedList<float> attachmentVertices = new ExposedList<float>();
	}
}
