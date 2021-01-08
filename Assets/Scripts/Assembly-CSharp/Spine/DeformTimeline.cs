using System;

namespace Spine
{
	public class DeformTimeline : CurveTimeline
	{
		public DeformTimeline(int frameCount) : base(frameCount)
		{
			this.frames = new float[frameCount];
			this.frameVertices = new float[frameCount][];
		}

		public int SlotIndex
		{
			get
			{
				return this.slotIndex;
			}
			set
			{
				this.slotIndex = value;
			}
		}

		public float[] Frames
		{
			get
			{
				return this.frames;
			}
			set
			{
				this.frames = value;
			}
		}

		public float[][] Vertices
		{
			get
			{
				return this.frameVertices;
			}
			set
			{
				this.frameVertices = value;
			}
		}

		public VertexAttachment Attachment
		{
			get
			{
				return this.attachment;
			}
			set
			{
				this.attachment = value;
			}
		}

		public void SetFrame(int frameIndex, float time, float[] vertices)
		{
			this.frames[frameIndex] = time;
			this.frameVertices[frameIndex] = vertices;
		}

		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha)
		{
			Slot slot = skeleton.slots.Items[this.slotIndex];
			VertexAttachment vertexAttachment = slot.attachment as VertexAttachment;
			if (vertexAttachment == null || !vertexAttachment.ApplyDeform(this.attachment))
			{
				return;
			}
			float[] array = this.frames;
			if (time < array[0])
			{
				return;
			}
			float[][] array2 = this.frameVertices;
			int num = array2[0].Length;
			ExposedList<float> attachmentVertices = slot.attachmentVertices;
			if (attachmentVertices.Count != num)
			{
				alpha = 1f;
			}
			if (attachmentVertices.Capacity < num)
			{
				attachmentVertices.Capacity = num;
			}
			attachmentVertices.Count = num;
			float[] items = attachmentVertices.Items;
			if (time >= array[array.Length - 1])
			{
				float[] array3 = array2[array.Length - 1];
				if (alpha < 1f)
				{
					for (int i = 0; i < num; i++)
					{
						float num2 = items[i];
						items[i] = num2 + (array3[i] - num2) * alpha;
					}
				}
				else
				{
					Array.Copy(array3, 0, items, 0, num);
				}
				return;
			}
			int num3 = Animation.binarySearch(array, time);
			float[] array4 = array2[num3 - 1];
			float[] array5 = array2[num3];
			float num4 = array[num3];
			float curvePercent = base.GetCurvePercent(num3 - 1, 1f - (time - num4) / (array[num3 - 1] - num4));
			if (alpha < 1f)
			{
				for (int j = 0; j < num; j++)
				{
					float num5 = array4[j];
					float num6 = items[j];
					items[j] = num6 + (num5 + (array5[j] - num5) * curvePercent - num6) * alpha;
				}
			}
			else
			{
				for (int k = 0; k < num; k++)
				{
					float num7 = array4[k];
					items[k] = num7 + (array5[k] - num7) * curvePercent;
				}
			}
		}

		internal int slotIndex;

		internal float[] frames;

		private float[][] frameVertices;

		internal VertexAttachment attachment;
	}
}
