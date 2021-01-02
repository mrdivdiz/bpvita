namespace Spine
{
    public class VertexAttachment : Attachment
	{
		public VertexAttachment(string name) : base(name)
		{
		}

		public int[] Bones
		{
			get
			{
				return this.bones;
			}
			set
			{
				this.bones = value;
			}
		}

		public float[] Vertices
		{
			get
			{
				return this.vertices;
			}
			set
			{
				this.vertices = value;
			}
		}

		public int WorldVerticesLength
		{
			get
			{
				return this.worldVerticesLength;
			}
			set
			{
				this.worldVerticesLength = value;
			}
		}

		public void ComputeWorldVertices(Slot slot, float[] worldVertices)
		{
			this.ComputeWorldVertices(slot, 0, this.worldVerticesLength, worldVertices, 0);
		}

		public void ComputeWorldVertices(Slot slot, int start, int count, float[] worldVertices, int offset)
		{
			count += offset;
			Skeleton skeleton = slot.Skeleton;
			float num = skeleton.x;
			float num2 = skeleton.y;
			ExposedList<float> attachmentVertices = slot.attachmentVertices;
			float[] items = this.vertices;
			int[] array = this.bones;
			if (array == null)
			{
				if (attachmentVertices.Count > 0)
				{
					items = attachmentVertices.Items;
				}
				Bone bone = slot.bone;
				num += bone.worldX;
				num2 += bone.worldY;
				float a = bone.a;
				float b = bone.b;
				float c = bone.c;
				float d = bone.d;
				int num3 = start;
				for (int i = offset; i < count; i += 2)
				{
					float num4 = items[num3];
					float num5 = items[num3 + 1];
					worldVertices[i] = num4 * a + num5 * b + num;
					worldVertices[i + 1] = num4 * c + num5 * d + num2;
					num3 += 2;
				}
				return;
			}
			int j = 0;
			int num6 = 0;
			for (int k = 0; k < start; k += 2)
			{
				int num7 = array[j];
				j += num7 + 1;
				num6 += num7;
			}
			Bone[] items2 = skeleton.Bones.Items;
			if (attachmentVertices.Count == 0)
			{
				int l = offset;
				int num8 = num6 * 3;
				while (l < count)
				{
					float num9 = num;
					float num10 = num2;
					int num11 = array[j++];
					num11 += j;
					while (j < num11)
					{
						Bone bone2 = items2[array[j]];
						float num12 = items[num8];
						float num13 = items[num8 + 1];
						float num14 = items[num8 + 2];
						num9 += (num12 * bone2.a + num13 * bone2.b + bone2.worldX) * num14;
						num10 += (num12 * bone2.c + num13 * bone2.d + bone2.worldY) * num14;
						j++;
						num8 += 3;
					}
					worldVertices[l] = num9;
					worldVertices[l + 1] = num10;
					l += 2;
				}
			}
			else
			{
				float[] items3 = attachmentVertices.Items;
				int m = offset;
				int num15 = num6 * 3;
				int num16 = num6 << 1;
				while (m < count)
				{
					float num17 = num;
					float num18 = num2;
					int num19 = array[j++];
					num19 += j;
					while (j < num19)
					{
						Bone bone3 = items2[array[j]];
						float num20 = items[num15] + items3[num16];
						float num21 = items[num15 + 1] + items3[num16 + 1];
						float num22 = items[num15 + 2];
						num17 += (num20 * bone3.a + num21 * bone3.b + bone3.worldX) * num22;
						num18 += (num20 * bone3.c + num21 * bone3.d + bone3.worldY) * num22;
						j++;
						num15 += 3;
						num16 += 2;
					}
					worldVertices[m] = num17;
					worldVertices[m + 1] = num18;
					m += 2;
				}
			}
		}

		public virtual bool ApplyDeform(VertexAttachment sourceAttachment)
		{
			return this == sourceAttachment;
		}

		internal int[] bones;

		internal float[] vertices;

		internal int worldVerticesLength;
	}
}
