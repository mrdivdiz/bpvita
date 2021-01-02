using System;

namespace Spine
{
	public class PathConstraint : IUpdatable
	{
		public PathConstraint(PathConstraintData data, Skeleton skeleton)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data", "data cannot be null.");
			}
			if (skeleton == null)
			{
				throw new ArgumentNullException("skeleton", "skeleton cannot be null.");
			}
			this.data = data;
			this.bones = new ExposedList<Bone>(data.Bones.Count);
			foreach (BoneData boneData in data.bones)
			{
				this.bones.Add(skeleton.FindBone(boneData.name));
			}
			this.target = skeleton.FindSlot(data.target.name);
			this.position = data.position;
			this.spacing = data.spacing;
			this.rotateMix = data.rotateMix;
			this.translateMix = data.translateMix;
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

		public ExposedList<Bone> Bones
		{
			get
			{
				return this.bones;
			}
		}

		public Slot Target
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

		public PathConstraintData Data
		{
			get
			{
				return this.data;
			}
		}

		public void Apply()
		{
			this.Update();
		}

		public void Update()
		{
			PathAttachment pathAttachment = this.target.Attachment as PathAttachment;
			if (pathAttachment == null)
			{
				return;
			}
			float num = this.rotateMix;
			float num2 = this.translateMix;
			bool flag = num2 > 0f;
			bool flag2 = num > 0f;
			if (!flag && !flag2)
			{
				return;
			}
			PathConstraintData pathConstraintData = this.data;
			SpacingMode spacingMode = pathConstraintData.spacingMode;
			bool flag3 = spacingMode == SpacingMode.Length;
			RotateMode rotateMode = pathConstraintData.rotateMode;
			bool flag4 = rotateMode == RotateMode.Tangent;
			bool flag5 = rotateMode == RotateMode.ChainScale;
			int count = this.bones.Count;
			int num3 = (!flag4) ? (count + 1) : count;
			Bone[] items = this.bones.Items;
			ExposedList<float> exposedList = this.spaces.Resize(num3);
			ExposedList<float> exposedList2 = null;
			float num4 = this.spacing;
			if (flag5 || flag3)
			{
				if (flag5)
				{
					exposedList2 = this.lengths.Resize(count);
				}
				int i = 0;
				int num5 = num3 - 1;
				while (i < num5)
				{
					Bone bone = items[i];
					float num6 = bone.data.length;
					float num7 = num6 * bone.a;
					float num8 = num6 * bone.c;
					num6 = (float)Math.Sqrt((double)(num7 * num7 + num8 * num8));
					if (flag5)
					{
						exposedList2.Items[i] = num6;
					}
					exposedList.Items[++i] = ((!flag3) ? num4 : Math.Max(0f, num6 + num4));
				}
			}
			else
			{
				for (int j = 1; j < num3; j++)
				{
					exposedList.Items[j] = num4;
				}
			}
			float[] array = this.ComputeWorldPositions(pathAttachment, num3, flag4, pathConstraintData.positionMode == PositionMode.Percent, spacingMode == SpacingMode.Percent);
			Skeleton skeleton = this.target.Skeleton;
			float x = skeleton.x;
			float y = skeleton.y;
			float num9 = array[0];
			float num10 = array[1];
			float offsetRotation = pathConstraintData.offsetRotation;
			bool flag6 = rotateMode == RotateMode.Chain && offsetRotation == 0f;
			int k = 0;
			int num11 = 3;
			while (k < count)
			{
				Bone bone2 = items[k];
				bone2.worldX += (num9 - x - bone2.worldX) * num2;
				bone2.worldY += (num10 - y - bone2.worldY) * num2;
				float num12 = array[num11];
				float num13 = array[num11 + 1];
				float num14 = num12 - num9;
				float num15 = num13 - num10;
				if (flag5)
				{
					float num16 = exposedList2.Items[k];
					if (num16 != 0f)
					{
						float num17 = ((float)Math.Sqrt((double)(num14 * num14 + num15 * num15)) / num16 - 1f) * num + 1f;
						bone2.a *= num17;
						bone2.c *= num17;
					}
				}
				num9 = num12;
				num10 = num13;
				if (flag2)
				{
					float a = bone2.a;
					float b = bone2.b;
					float c = bone2.c;
					float d = bone2.d;
					float num18;
					if (flag4)
					{
						num18 = array[num11 - 1];
					}
					else if (exposedList.Items[k + 1] == 0f)
					{
						num18 = array[num11 + 2];
					}
					else
					{
						num18 = MathUtils.Atan2(num15, num14);
					}
					num18 -= MathUtils.Atan2(c, a) - offsetRotation * 0.0174532924f;
					float num19;
					float num20;
					if (flag6)
					{
						num19 = MathUtils.Cos(num18);
						num20 = MathUtils.Sin(num18);
						float length = bone2.data.length;
						num9 += (length * (num19 * a - num20 * c) - num14) * num;
						num10 += (length * (num20 * a + num19 * c) - num15) * num;
					}
					if (num18 > 3.14159274f)
					{
						num18 -= 6.28318548f;
					}
					else if (num18 < -3.14159274f)
					{
						num18 += 6.28318548f;
					}
					num18 *= num;
					num19 = MathUtils.Cos(num18);
					num20 = MathUtils.Sin(num18);
					bone2.a = num19 * a - num20 * c;
					bone2.b = num19 * b - num20 * d;
					bone2.c = num20 * a + num19 * c;
					bone2.d = num20 * b + num19 * d;
				}
				k++;
				num11 += 3;
			}
		}

		private float[] ComputeWorldPositions(PathAttachment path, int spacesCount, bool tangents, bool percentPosition, bool percentSpacing)
		{
			Slot slot = this.target;
			float num = this.position;
			float[] items = this.spaces.Items;
			float[] items2 = this.positions.Resize(spacesCount * 3 + 2).Items;
			bool closed = path.Closed;
			int num2 = path.WorldVerticesLength;
			int num3 = num2 / 6;
			int num4 = -1;
			float num5;
			float[] items3;
			if (!path.ConstantSpeed)
			{
				float[] array = path.Lengths;
				num3 -= ((!closed) ? 2 : 1);
				num5 = array[num3];
				if (percentPosition)
				{
					num *= num5;
				}
				if (percentSpacing)
				{
					for (int i = 0; i < spacesCount; i++)
					{
						items[i] *= num5;
					}
				}
				items3 = this.world.Resize(8).Items;
				int j = 0;
				int num6 = 0;
				int num7 = 0;
				while (j < spacesCount)
				{
					float num8 = items[j];
					num += num8;
					float num9 = num;
					if (closed)
					{
						num9 %= num5;
						if (num9 < 0f)
						{
							num9 += num5;
						}
						num7 = 0;
						goto IL_178;
					}
					if (num9 < 0f)
					{
						if (num4 != -2)
						{
							num4 = -2;
							path.ComputeWorldVertices(slot, 2, 4, items3, 0);
						}
						this.AddBeforePosition(num9, items3, 0, items2, num6);
					}
					else
					{
						if (num9 <= num5)
						{
							goto IL_178;
						}
						if (num4 != -3)
						{
							num4 = -3;
							path.ComputeWorldVertices(slot, num2 - 6, 4, items3, 0);
						}
						this.AddAfterPosition(num9 - num5, items3, 0, items2, num6);
					}
					IL_261:
					j++;
					num6 += 3;
					continue;
					IL_178:
					float num10;
					for (;;)
					{
						num10 = array[num7];
						if (num9 <= num10)
						{
							break;
						}
						num7++;
					}
					if (num7 == 0)
					{
						num9 /= num10;
					}
					else
					{
						float num11 = array[num7 - 1];
						num9 = (num9 - num11) / (num10 - num11);
					}
					if (num7 != num4)
					{
						num4 = num7;
						if (closed && num7 == num3)
						{
							path.ComputeWorldVertices(slot, num2 - 4, 4, items3, 0);
							path.ComputeWorldVertices(slot, 0, 4, items3, 4);
						}
						else
						{
							path.ComputeWorldVertices(slot, num7 * 6 + 2, 8, items3, 0);
						}
					}
					this.AddCurvePosition(num9, items3[0], items3[1], items3[2], items3[3], items3[4], items3[5], items3[6], items3[7], items2, num6, tangents || (j > 0 && num8 == 0f));
					goto IL_261;
				}
				return items2;
			}
			if (closed)
			{
				num2 += 2;
				items3 = this.world.Resize(num2).Items;
				path.ComputeWorldVertices(slot, 2, num2 - 4, items3, 0);
				path.ComputeWorldVertices(slot, 0, 2, items3, num2 - 4);
				items3[num2 - 2] = items3[0];
				items3[num2 - 1] = items3[1];
			}
			else
			{
				num3--;
				num2 -= 4;
				items3 = this.world.Resize(num2).Items;
				path.ComputeWorldVertices(slot, 2, num2, items3, 0);
			}
			float[] items4 = this.curves.Resize(num3).Items;
			num5 = 0f;
			float num12 = items3[0];
			float num13 = items3[1];
			float num14 = 0f;
			float num15 = 0f;
			float num16 = 0f;
			float num17 = 0f;
			float num18 = 0f;
			float num19 = 0f;
			int k = 0;
			int num20 = 2;
			while (k < num3)
			{
				num14 = items3[num20];
				num15 = items3[num20 + 1];
				num16 = items3[num20 + 2];
				num17 = items3[num20 + 3];
				num18 = items3[num20 + 4];
				num19 = items3[num20 + 5];
				float num21 = (num12 - num14 * 2f + num16) * 0.1875f;
				float num22 = (num13 - num15 * 2f + num17) * 0.1875f;
				float num23 = ((num14 - num16) * 3f - num12 + num18) * 0.09375f;
				float num24 = ((num15 - num17) * 3f - num13 + num19) * 0.09375f;
				float num25 = num21 * 2f + num23;
				float num26 = num22 * 2f + num24;
				float num27 = (num14 - num12) * 0.75f + num21 + num23 * 0.166666672f;
				float num28 = (num15 - num13) * 0.75f + num22 + num24 * 0.166666672f;
				num5 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
				num27 += num25;
				num28 += num26;
				num25 += num23;
				num26 += num24;
				num5 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
				num27 += num25;
				num28 += num26;
				num5 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
				num27 += num25 + num23;
				num28 += num26 + num24;
				num5 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
				items4[k] = num5;
				num12 = num18;
				num13 = num19;
				k++;
				num20 += 6;
			}
			if (percentPosition)
			{
				num *= num5;
			}
			if (percentSpacing)
			{
				for (int l = 0; l < spacesCount; l++)
				{
					items[l] *= num5;
				}
			}
			float[] array2 = this.segments;
			float num29 = 0f;
			int m = 0;
			int num30 = 0;
			int num31 = 0;
			int num32 = 0;
			while (m < spacesCount)
			{
				float num33 = items[m];
				num += num33;
				float num34 = num;
				if (closed)
				{
					num34 %= num5;
					if (num34 < 0f)
					{
						num34 += num5;
					}
					num31 = 0;
					goto IL_5C5;
				}
				if (num34 < 0f)
				{
					this.AddBeforePosition(num34, items3, 0, items2, num30);
				}
				else
				{
					if (num34 <= num5)
					{
						goto IL_5C5;
					}
					this.AddAfterPosition(num34 - num5, items3, num2 - 4, items2, num30);
				}
				IL_881:
				m++;
				num30 += 3;
				continue;
				IL_5C5:
				float num35;
				for (;;)
				{
					num35 = items4[num31];
					if (num34 <= num35)
					{
						break;
					}
					num31++;
				}
				if (num31 == 0)
				{
					num34 /= num35;
				}
				else
				{
					float num36 = items4[num31 - 1];
					num34 = (num34 - num36) / (num35 - num36);
				}
				if (num31 != num4)
				{
					num4 = num31;
					int n = num31 * 6;
					num12 = items3[n];
					num13 = items3[n + 1];
					num14 = items3[n + 2];
					num15 = items3[n + 3];
					num16 = items3[n + 4];
					num17 = items3[n + 5];
					num18 = items3[n + 6];
					num19 = items3[n + 7];
					float num21 = (num12 - num14 * 2f + num16) * 0.03f;
					float num22 = (num13 - num15 * 2f + num17) * 0.03f;
					float num23 = ((num14 - num16) * 3f - num12 + num18) * 0.006f;
					float num24 = ((num15 - num17) * 3f - num13 + num19) * 0.006f;
					float num25 = num21 * 2f + num23;
					float num26 = num22 * 2f + num24;
					float num27 = (num14 - num12) * 0.3f + num21 + num23 * 0.166666672f;
					float num28 = (num15 - num13) * 0.3f + num22 + num24 * 0.166666672f;
					num29 = (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
					array2[0] = num29;
					for (n = 1; n < 8; n++)
					{
						num27 += num25;
						num28 += num26;
						num25 += num23;
						num26 += num24;
						num29 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
						array2[n] = num29;
					}
					num27 += num25;
					num28 += num26;
					num29 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
					array2[8] = num29;
					num27 += num25 + num23;
					num28 += num26 + num24;
					num29 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
					array2[9] = num29;
					num32 = 0;
				}
				num34 *= num29;
				float num37;
				for (;;)
				{
					num37 = array2[num32];
					if (num34 <= num37)
					{
						break;
					}
					num32++;
				}
				if (num32 == 0)
				{
					num34 /= num37;
				}
				else
				{
					float num38 = array2[num32 - 1];
					num34 = (float)num32 + (num34 - num38) / (num37 - num38);
				}
				this.AddCurvePosition(num34 * 0.1f, num12, num13, num14, num15, num16, num17, num18, num19, items2, num30, tangents || (m > 0 && num33 == 0f));
				goto IL_881;
			}
			return items2;
		}

		private void AddBeforePosition(float p, float[] temp, int i, float[] output, int o)
		{
			float num = temp[i];
			float num2 = temp[i + 1];
			float x = temp[i + 2] - num;
			float y = temp[i + 3] - num2;
			float num3 = MathUtils.Atan2(y, x);
			output[o] = num + p * MathUtils.Cos(num3);
			output[o + 1] = num2 + p * MathUtils.Sin(num3);
			output[o + 2] = num3;
		}

		private void AddAfterPosition(float p, float[] temp, int i, float[] output, int o)
		{
			float num = temp[i + 2];
			float num2 = temp[i + 3];
			float x = num - temp[i];
			float y = num2 - temp[i + 1];
			float num3 = MathUtils.Atan2(y, x);
			output[o] = num + p * MathUtils.Cos(num3);
			output[o + 1] = num2 + p * MathUtils.Sin(num3);
			output[o + 2] = num3;
		}

		private void AddCurvePosition(float p, float x1, float y1, float cx1, float cy1, float cx2, float cy2, float x2, float y2, float[] output, int o, bool tangents)
		{
			if (p == 0f)
			{
				p = 0.0001f;
			}
			float num = p * p;
			float num2 = num * p;
			float num3 = 1f - p;
			float num4 = num3 * num3;
			float num5 = num4 * num3;
			float num6 = num3 * p;
			float num7 = num6 * 3f;
			float num8 = num3 * num7;
			float num9 = num7 * p;
			float num10 = x1 * num5 + cx1 * num8 + cx2 * num9 + x2 * num2;
			float num11 = y1 * num5 + cy1 * num8 + cy2 * num9 + y2 * num2;
			output[o] = num10;
			output[o + 1] = num11;
			if (tangents)
			{
				output[o + 2] = (float)Math.Atan2((double)(num11 - (y1 * num4 + cy1 * num6 * 2f + cy2 * num)), (double)(num10 - (x1 * num4 + cx1 * num6 * 2f + cx2 * num)));
			}
		}

		private const int NONE = -1;

		private const int BEFORE = -2;

		private const int AFTER = -3;

		internal PathConstraintData data;

		internal ExposedList<Bone> bones;

		internal Slot target;

		internal float position;

		internal float spacing;

		internal float rotateMix;

		internal float translateMix;

		internal ExposedList<float> spaces = new ExposedList<float>();

		internal ExposedList<float> positions = new ExposedList<float>();

		internal ExposedList<float> world = new ExposedList<float>();

		internal ExposedList<float> curves = new ExposedList<float>();

		internal ExposedList<float> lengths = new ExposedList<float>();

		internal float[] segments = new float[10];
	}
}
