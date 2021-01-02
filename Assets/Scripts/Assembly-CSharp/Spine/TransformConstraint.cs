using System;

namespace Spine
{
	public class TransformConstraint : IUpdatable
	{
		public TransformConstraint(TransformConstraintData data, Skeleton skeleton)
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
			this.rotateMix = data.rotateMix;
			this.translateMix = data.translateMix;
			this.scaleMix = data.scaleMix;
			this.shearMix = data.shearMix;
			this.bones = new ExposedList<Bone>();
			foreach (BoneData boneData in data.bones)
			{
				this.bones.Add(skeleton.FindBone(boneData.name));
			}
			this.target = skeleton.FindBone(data.target.name);
		}

		public TransformConstraintData Data
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

		public void Apply()
		{
			this.Update();
		}

		public void Update()
		{
			float num = this.rotateMix;
			float num2 = this.translateMix;
			float num3 = this.scaleMix;
			float num4 = this.shearMix;
			Bone bone = this.target;
			float a = bone.a;
			float b = bone.b;
			float c = bone.c;
			float d = bone.d;
			ExposedList<Bone> exposedList = this.bones;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Bone bone2 = exposedList.Items[i];
				if (num > 0f)
				{
					float a2 = bone2.a;
					float b2 = bone2.b;
					float c2 = bone2.c;
					float d2 = bone2.d;
					float num5 = (float)Math.Atan2((double)c, (double)a) - (float)Math.Atan2((double)c2, (double)a2) + this.data.offsetRotation * 0.0174532924f;
					if (num5 > 3.14159274f)
					{
						num5 -= 6.28318548f;
					}
					else if (num5 < -3.14159274f)
					{
						num5 += 6.28318548f;
					}
					num5 *= num;
					float num6 = MathUtils.Cos(num5);
					float num7 = MathUtils.Sin(num5);
					bone2.a = num6 * a2 - num7 * c2;
					bone2.b = num6 * b2 - num7 * d2;
					bone2.c = num7 * a2 + num6 * c2;
					bone2.d = num7 * b2 + num6 * d2;
				}
				if (num2 > 0f)
				{
					float num8;
					float num9;
					bone.LocalToWorld(this.data.offsetX, this.data.offsetY, out num8, out num9);
					bone2.worldX += (num8 - bone2.worldX) * num2;
					bone2.worldY += (num9 - bone2.worldY) * num2;
				}
				if (num3 > 0f)
				{
					float num10 = (float)Math.Sqrt((double)(bone2.a * bone2.a + bone2.c * bone2.c));
					float num11 = (float)Math.Sqrt((double)(a * a + c * c));
					float num12 = (num10 <= 1E-05f) ? 0f : ((num10 + (num11 - num10 + this.data.offsetScaleX) * num3) / num10);
					bone2.a *= num12;
					bone2.c *= num12;
					num10 = (float)Math.Sqrt((double)(bone2.b * bone2.b + bone2.d * bone2.d));
					num11 = (float)Math.Sqrt((double)(b * b + d * d));
					num12 = ((num10 <= 1E-05f) ? 0f : ((num10 + (num11 - num10 + this.data.offsetScaleY) * num3) / num10));
					bone2.b *= num12;
					bone2.d *= num12;
				}
				if (num4 > 0f)
				{
					float b3 = bone2.b;
					float d3 = bone2.d;
					float num13 = MathUtils.Atan2(d3, b3);
					float num14 = MathUtils.Atan2(d, b) - MathUtils.Atan2(c, a) - (num13 - MathUtils.Atan2(bone2.c, bone2.a));
					if (num14 > 3.14159274f)
					{
						num14 -= 6.28318548f;
					}
					else if (num14 < -3.14159274f)
					{
						num14 += 6.28318548f;
					}
					num14 = num13 + (num14 + this.data.offsetShearY * 0.0174532924f) * num4;
					float num15 = (float)Math.Sqrt((double)(b3 * b3 + d3 * d3));
					bone2.b = MathUtils.Cos(num14) * num15;
					bone2.d = MathUtils.Sin(num14) * num15;
				}
				i++;
			}
		}

		public override string ToString()
		{
			return this.data.name;
		}

		internal TransformConstraintData data;

		internal ExposedList<Bone> bones;

		internal Bone target;

		internal float rotateMix;

		internal float translateMix;

		internal float scaleMix;

		internal float shearMix;
	}
}
