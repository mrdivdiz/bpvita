using System;

namespace Spine
{
	public class IkConstraint : IUpdatable
	{
		public IkConstraint(IkConstraintData data, Skeleton skeleton)
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
			this.mix = data.mix;
			this.bendDirection = data.bendDirection;
			this.bones = new ExposedList<Bone>(data.bones.Count);
			foreach (BoneData boneData in data.bones)
			{
				this.bones.Add(skeleton.FindBone(boneData.name));
			}
			this.target = skeleton.FindBone(data.target.name);
		}

		public IkConstraintData Data
		{
			get
			{
				return this.data;
			}
		}

		public ExposedList<Bone> Bones
		{
			get
			{
				return this.bones;
			}
		}

		public Bone Target
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

		public void Update()
		{
			this.Apply();
		}

		public void Apply()
		{
			Bone bone = this.target;
			ExposedList<Bone> exposedList = this.bones;
			int count = exposedList.Count;
			if (count != 1)
			{
				if (count == 2)
				{
					IkConstraint.Apply(exposedList.Items[0], exposedList.Items[1], bone.worldX, bone.worldY, this.bendDirection, this.mix);
				}
			}
			else
			{
				IkConstraint.Apply(exposedList.Items[0], bone.worldX, bone.worldY, this.mix);
			}
		}

		public override string ToString()
		{
			return this.data.name;
		}

		public static void Apply(Bone bone, float targetX, float targetY, float alpha)
		{
			Bone parent = bone.parent;
			float num = 1f / (parent.a * parent.d - parent.b * parent.c);
			float num2 = targetX - parent.worldX;
			float num3 = targetY - parent.worldY;
			float x = (num2 * parent.d - num3 * parent.b) * num - bone.x;
			float y = (num3 * parent.a - num2 * parent.c) * num - bone.y;
			float num4 = MathUtils.Atan2(y, x) * 57.2957764f - bone.shearX - bone.rotation;
			if (bone.scaleX < 0f)
			{
				num4 += 180f;
			}
			if (num4 > 180f)
			{
				num4 -= 360f;
			}
			else if (num4 < -180f)
			{
				num4 += 360f;
			}
			bone.UpdateWorldTransform(bone.x, bone.y, bone.rotation + num4 * alpha, bone.scaleX, bone.scaleY, bone.shearX, bone.shearY);
		}

		public static void Apply(Bone parent, Bone child, float targetX, float targetY, int bendDir, float alpha)
		{
			if (alpha == 0f)
			{
				child.UpdateWorldTransform();
				return;
			}
			float x = parent.x;
			float y = parent.y;
			float num = parent.scaleX;
			float num2 = parent.scaleY;
			float num3 = child.scaleX;
			int num4;
			int num5;
			if (num < 0f)
			{
				num = -num;
				num4 = 180;
				num5 = -1;
			}
			else
			{
				num4 = 0;
				num5 = 1;
			}
			if (num2 < 0f)
			{
				num2 = -num2;
				num5 = -num5;
			}
			int num6;
			if (num3 < 0f)
			{
				num3 = -num3;
				num6 = 180;
			}
			else
			{
				num6 = 0;
			}
			float x2 = child.x;
			float num7 = parent.a;
			float num8 = parent.b;
			float num9 = parent.c;
			float num10 = parent.d;
			bool flag = Math.Abs(num - num2) <= 0.0001f;
			float num11;
			float num12;
			float num13;
			if (!flag)
			{
				num11 = 0f;
				num12 = num7 * x2 + parent.worldX;
				num13 = num9 * x2 + parent.worldY;
			}
			else
			{
				num11 = child.y;
				num12 = num7 * x2 + num8 * num11 + parent.worldX;
				num13 = num9 * x2 + num10 * num11 + parent.worldY;
			}
			Bone parent2 = parent.parent;
			num7 = parent2.a;
			num8 = parent2.b;
			num9 = parent2.c;
			num10 = parent2.d;
			float num14 = 1f / (num7 * num10 - num8 * num9);
			float num15 = targetX - parent2.worldX;
			float num16 = targetY - parent2.worldY;
			float num17 = (num15 * num10 - num16 * num8) * num14 - x;
			float num18 = (num16 * num7 - num15 * num9) * num14 - y;
			num15 = num12 - parent2.worldX;
			num16 = num13 - parent2.worldY;
			float num19 = (num15 * num10 - num16 * num8) * num14 - x;
			float num20 = (num16 * num7 - num15 * num9) * num14 - y;
			float num21 = (float)Math.Sqrt((double)(num19 * num19 + num20 * num20));
			float num22 = child.data.length * num3;
			float num24;
			float num25;
			if (flag)
			{
				num22 *= num;
				float num23 = (num17 * num17 + num18 * num18 - num21 * num21 - num22 * num22) / (2f * num21 * num22);
				if (num23 < -1f)
				{
					num23 = -1f;
				}
				else if (num23 > 1f)
				{
					num23 = 1f;
				}
				num24 = (float)Math.Acos((double)num23) * (float)bendDir;
				num7 = num21 + num22 * num23;
				num8 = num22 * MathUtils.Sin(num24);
				num25 = MathUtils.Atan2(num18 * num7 - num17 * num8, num17 * num7 + num18 * num8);
			}
			else
			{
				num7 = num * num22;
				num8 = num2 * num22;
				float num26 = num7 * num7;
				float num27 = num8 * num8;
				float num28 = num17 * num17 + num18 * num18;
				float num29 = MathUtils.Atan2(num18, num17);
				num9 = num27 * num21 * num21 + num26 * num28 - num26 * num27;
				float num30 = -2f * num27 * num21;
				float num31 = num27 - num26;
				num10 = num30 * num30 - 4f * num31 * num9;
				if (num10 >= 0f)
				{
					float num32 = (float)Math.Sqrt((double)num10);
					if (num30 < 0f)
					{
						num32 = -num32;
					}
					num32 = -(num30 + num32) / 2f;
					float num33 = num32 / num31;
					float num34 = num9 / num32;
					float num35 = (Math.Abs(num33) >= Math.Abs(num34)) ? num34 : num33;
					if (num35 * num35 <= num28)
					{
						num16 = (float)Math.Sqrt((double)(num28 - num35 * num35)) * (float)bendDir;
						num25 = num29 - MathUtils.Atan2(num16, num35);
						num24 = MathUtils.Atan2(num16 / num2, (num35 - num21) / num);
						goto IL_4FA;
					}
				}
				float num36 = 0f;
				float num37 = float.MaxValue;
				float x3 = 0f;
				float num38 = 0f;
				float num39 = 0f;
				float num40 = 0f;
				float x4 = 0f;
				float num41 = 0f;
				num15 = num21 + num7;
				num10 = num15 * num15;
				if (num10 > num40)
				{
					num39 = 0f;
					num40 = num10;
					x4 = num15;
				}
				num15 = num21 - num7;
				num10 = num15 * num15;
				if (num10 < num37)
				{
					num36 = 3.14159274f;
					num37 = num10;
					x3 = num15;
				}
				float num42 = (float)Math.Acos((double)(-(double)num7 * num21 / (num26 - num27)));
				num15 = num7 * MathUtils.Cos(num42) + num21;
				num16 = num8 * MathUtils.Sin(num42);
				num10 = num15 * num15 + num16 * num16;
				if (num10 < num37)
				{
					num36 = num42;
					num37 = num10;
					x3 = num15;
					num38 = num16;
				}
				if (num10 > num40)
				{
					num39 = num42;
					num40 = num10;
					x4 = num15;
					num41 = num16;
				}
				if (num28 <= (num37 + num40) / 2f)
				{
					num25 = num29 - MathUtils.Atan2(num38 * (float)bendDir, x3);
					num24 = num36 * (float)bendDir;
				}
				else
				{
					num25 = num29 - MathUtils.Atan2(num41 * (float)bendDir, x4);
					num24 = num39 * (float)bendDir;
				}
			}
			IL_4FA:
			float num43 = MathUtils.Atan2(num11, x2) * (float)num5;
			float rotation = parent.rotation;
			num25 = (num25 - num43) * 57.2957764f + (float)num4 - rotation;
			if (num25 > 180f)
			{
				num25 -= 360f;
			}
			else if (num25 < -180f)
			{
				num25 += 360f;
			}
			parent.UpdateWorldTransform(x, y, rotation + num25 * alpha, parent.scaleX, parent.scaleY, 0f, 0f);
			rotation = child.rotation;
			num24 = ((num24 + num43) * 57.2957764f - child.shearX) * (float)num5 + (float)num6 - rotation;
			if (num24 > 180f)
			{
				num24 -= 360f;
			}
			else if (num24 < -180f)
			{
				num24 += 360f;
			}
			child.UpdateWorldTransform(x2, num11, rotation + num24 * alpha, child.scaleX, child.scaleY, child.shearX, child.shearY);
		}

		internal IkConstraintData data;

		internal ExposedList<Bone> bones = new ExposedList<Bone>();

		internal Bone target;

		internal float mix;

		internal int bendDirection;

		internal int level;
	}
}
