using System;

namespace Spine
{
	public class Bone : IUpdatable
	{
		public Bone(BoneData data, Skeleton skeleton, Bone parent)
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
			this.skeleton = skeleton;
			this.parent = parent;
			this.SetToSetupPose();
		}

		public BoneData Data
		{
			get
			{
				return this.data;
			}
		}

		public Skeleton Skeleton
		{
			get
			{
				return this.skeleton;
			}
		}

		public Bone Parent
		{
			get
			{
				return this.parent;
			}
		}

		public ExposedList<Bone> Children
		{
			get
			{
				return this.children;
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

		public float AppliedRotation
		{
			get
			{
				return this.appliedRotation;
			}
			set
			{
				this.appliedRotation = value;
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

		public float A
		{
			get
			{
				return this.a;
			}
		}

		public float B
		{
			get
			{
				return this.b;
			}
		}

		public float C
		{
			get
			{
				return this.c;
			}
		}

		public float D
		{
			get
			{
				return this.d;
			}
		}

		public float WorldX
		{
			get
			{
				return this.worldX;
			}
		}

		public float WorldY
		{
			get
			{
				return this.worldY;
			}
		}

		public float WorldSignX
		{
			get
			{
				return this.worldSignX;
			}
		}

		public float WorldSignY
		{
			get
			{
				return this.worldSignY;
			}
		}

		public float WorldRotationX
		{
			get
			{
				return MathUtils.Atan2(this.c, this.a) * 57.2957764f;
			}
		}

		public float WorldRotationY
		{
			get
			{
				return MathUtils.Atan2(this.d, this.b) * 57.2957764f;
			}
		}

		public float WorldScaleX
		{
			get
			{
				return (float)Math.Sqrt((double)(this.a * this.a + this.c * this.c)) * this.worldSignX;
			}
		}

		public float WorldScaleY
		{
			get
			{
				return (float)Math.Sqrt((double)(this.b * this.b + this.d * this.d)) * this.worldSignY;
			}
		}

		public void Update()
		{
			this.UpdateWorldTransform(this.x, this.y, this.rotation, this.scaleX, this.scaleY, this.shearX, this.shearY);
		}

		public void UpdateWorldTransform()
		{
			this.UpdateWorldTransform(this.x, this.y, this.rotation, this.scaleX, this.scaleY, this.shearX, this.shearY);
		}

		public void UpdateWorldTransform(float x, float y, float rotation, float scaleX, float scaleY, float shearX, float shearY)
		{
			this.appliedRotation = rotation;
			float degrees = rotation + 90f + shearY;
			float num = MathUtils.CosDeg(rotation + shearX) * scaleX;
			float num2 = MathUtils.CosDeg(degrees) * scaleY;
			float num3 = MathUtils.SinDeg(rotation + shearX) * scaleX;
			float num4 = MathUtils.SinDeg(degrees) * scaleY;
			Bone bone = this.parent;
			if (bone == null)
			{
				Skeleton skeleton = this.skeleton;
				if (skeleton.flipX)
				{
					x = -x;
					num = -num;
					num2 = -num2;
				}
				if (skeleton.flipY != Bone.yDown)
				{
					y = -y;
					num3 = -num3;
					num4 = -num4;
				}
				this.a = num;
				this.b = num2;
				this.c = num3;
				this.d = num4;
				this.worldX = x;
				this.worldY = y;
				this.worldSignX = (float)Math.Sign(scaleX);
				this.worldSignY = (float)Math.Sign(scaleY);
				return;
			}
			float num5 = bone.a;
			float num6 = bone.b;
			float num7 = bone.c;
			float num8 = bone.d;
			this.worldX = num5 * x + num6 * y + bone.worldX;
			this.worldY = num7 * x + num8 * y + bone.worldY;
			this.worldSignX = bone.worldSignX * (float)Math.Sign(scaleX);
			this.worldSignY = bone.worldSignY * (float)Math.Sign(scaleY);
			if (this.data.inheritRotation && this.data.inheritScale)
			{
				this.a = num5 * num + num6 * num3;
				this.b = num5 * num2 + num6 * num4;
				this.c = num7 * num + num8 * num3;
				this.d = num7 * num2 + num8 * num4;
			}
			else
			{
				if (this.data.inheritRotation)
				{
					num5 = 1f;
					num6 = 0f;
					num7 = 0f;
					num8 = 1f;
					do
					{
						float num9 = MathUtils.CosDeg(bone.appliedRotation);
						float num10 = MathUtils.SinDeg(bone.appliedRotation);
						float num11 = num5 * num9 + num6 * num10;
						num6 = num6 * num9 - num5 * num10;
						num5 = num11;
						num11 = num7 * num9 + num8 * num10;
						num8 = num8 * num9 - num7 * num10;
						num7 = num11;
						if (!bone.data.inheritRotation)
						{
							break;
						}
						bone = bone.parent;
					}
					while (bone != null);
					this.a = num5 * num + num6 * num3;
					this.b = num5 * num2 + num6 * num4;
					this.c = num7 * num + num8 * num3;
					this.d = num7 * num2 + num8 * num4;
				}
				else if (this.data.inheritScale)
				{
					num5 = 1f;
					num6 = 0f;
					num7 = 0f;
					num8 = 1f;
					do
					{
						float num12 = MathUtils.CosDeg(bone.appliedRotation);
						float num13 = MathUtils.SinDeg(bone.appliedRotation);
						float num14 = bone.scaleX;
						float num15 = bone.scaleY;
						float num16 = num12 * num14;
						float num17 = num13 * num15;
						float num18 = num13 * num14;
						float num19 = num12 * num15;
						float num20 = num5 * num16 + num6 * num18;
						num6 = num6 * num19 - num5 * num17;
						num5 = num20;
						num20 = num7 * num16 + num8 * num18;
						num8 = num8 * num19 - num7 * num17;
						num7 = num20;
						if (num14 >= 0f)
						{
							num13 = -num13;
						}
						num20 = num5 * num12 + num6 * num13;
						num6 = num6 * num12 - num5 * num13;
						num5 = num20;
						num20 = num7 * num12 + num8 * num13;
						num8 = num8 * num12 - num7 * num13;
						num7 = num20;
						if (!bone.data.inheritScale)
						{
							break;
						}
						bone = bone.parent;
					}
					while (bone != null);
					this.a = num5 * num + num6 * num3;
					this.b = num5 * num2 + num6 * num4;
					this.c = num7 * num + num8 * num3;
					this.d = num7 * num2 + num8 * num4;
				}
				else
				{
					this.a = num;
					this.b = num2;
					this.c = num3;
					this.d = num4;
				}
				if (this.skeleton.flipX)
				{
					this.a = -this.a;
					this.b = -this.b;
				}
				if (this.skeleton.flipY != Bone.yDown)
				{
					this.c = -this.c;
					this.d = -this.d;
				}
			}
		}

		public void SetToSetupPose()
		{
			BoneData boneData = this.data;
			this.x = boneData.x;
			this.y = boneData.y;
			this.rotation = boneData.rotation;
			this.scaleX = boneData.scaleX;
			this.scaleY = boneData.scaleY;
			this.shearX = boneData.shearX;
			this.shearY = boneData.shearY;
		}

		public float WorldToLocalRotationX
		{
			get
			{
				Bone bone = this.parent;
				if (bone == null)
				{
					return this.rotation;
				}
				float num = bone.a;
				float num2 = bone.b;
				float num3 = bone.c;
				float num4 = bone.d;
				float num5 = this.a;
				float num6 = this.c;
				return MathUtils.Atan2(num * num6 - num3 * num5, num4 * num5 - num2 * num6) * 57.2957764f;
			}
		}

		public float WorldToLocalRotationY
		{
			get
			{
				Bone bone = this.parent;
				if (bone == null)
				{
					return this.rotation;
				}
				float num = bone.a;
				float num2 = bone.b;
				float num3 = bone.c;
				float num4 = bone.d;
				float num5 = this.b;
				float num6 = this.d;
				return MathUtils.Atan2(num * num6 - num3 * num5, num4 * num5 - num2 * num6) * 57.2957764f;
			}
		}

		public void RotateWorld(float degrees)
		{
			float num = this.a;
			float num2 = this.b;
			float num3 = this.c;
			float num4 = this.d;
			float num5 = MathUtils.CosDeg(degrees);
			float num6 = MathUtils.SinDeg(degrees);
			this.a = num5 * num - num6 * num3;
			this.b = num5 * num2 - num6 * num4;
			this.c = num6 * num + num5 * num3;
			this.d = num6 * num2 + num5 * num4;
		}

		public void UpdateLocalTransform()
		{
			Bone bone = this.parent;
			if (bone == null)
			{
				this.x = this.worldX;
				this.y = this.worldY;
				this.rotation = MathUtils.Atan2(this.c, this.a) * 57.2957764f;
				this.scaleX = (float)Math.Sqrt((double)(this.a * this.a + this.c * this.c));
				this.scaleY = (float)Math.Sqrt((double)(this.b * this.b + this.d * this.d));
				float num = this.a * this.d - this.b * this.c;
				this.shearX = 0f;
				this.shearY = MathUtils.Atan2(this.a * this.b + this.c * this.d, num) * 57.2957764f;
				return;
			}
			float num2 = bone.a;
			float num3 = bone.b;
			float num4 = bone.c;
			float num5 = bone.d;
			float num6 = 1f / (num2 * num5 - num3 * num4);
			float num7 = this.worldX - bone.worldX;
			float num8 = this.worldY - bone.worldY;
			this.x = num7 * num5 * num6 - num8 * num3 * num6;
			this.y = num8 * num2 * num6 - num7 * num4 * num6;
			float num9 = num6 * num5;
			float num10 = num6 * num2;
			float num11 = num6 * num3;
			float num12 = num6 * num4;
			float num13 = num9 * this.a - num11 * this.c;
			float num14 = num9 * this.b - num11 * this.d;
			float num15 = num10 * this.c - num12 * this.a;
			float num16 = num10 * this.d - num12 * this.b;
			this.shearX = 0f;
			this.scaleX = (float)Math.Sqrt((double)(num13 * num13 + num15 * num15));
			if (this.scaleX > 0.0001f)
			{
				float num17 = num13 * num16 - num14 * num15;
				this.scaleY = num17 / this.scaleX;
				this.shearY = MathUtils.Atan2(num13 * num14 + num15 * num16, num17) * 57.2957764f;
				this.rotation = MathUtils.Atan2(num15, num13) * 57.2957764f;
			}
			else
			{
				this.scaleX = 0f;
				this.scaleY = (float)Math.Sqrt((double)(num14 * num14 + num16 * num16));
				this.shearY = 0f;
				this.rotation = 90f - MathUtils.Atan2(num16, num14) * 57.2957764f;
			}
			this.appliedRotation = this.rotation;
		}

		public void WorldToLocal(float worldX, float worldY, out float localX, out float localY)
		{
			float num = this.a;
			float num2 = this.b;
			float num3 = this.c;
			float num4 = this.d;
			float num5 = 1f / (num * num4 - num2 * num3);
			float num6 = worldX - this.worldX;
			float num7 = worldY - this.worldY;
			localX = num6 * num4 * num5 - num7 * num2 * num5;
			localY = num7 * num * num5 - num6 * num3 * num5;
		}

		public void LocalToWorld(float localX, float localY, out float worldX, out float worldY)
		{
			worldX = localX * this.a + localY * this.b + this.worldX;
			worldY = localX * this.c + localY * this.d + this.worldY;
		}

		public override string ToString()
		{
			return this.data.name;
		}

		public static bool yDown;

		internal BoneData data;

		internal Skeleton skeleton;

		internal Bone parent;

		internal ExposedList<Bone> children = new ExposedList<Bone>();

		internal float x;

		internal float y;

		internal float rotation;

		internal float scaleX;

		internal float scaleY;

		internal float shearX;

		internal float shearY;

		internal float appliedRotation;

		internal float a;

		internal float b;

		internal float worldX;

		internal float c;

		internal float d;

		internal float worldY;

		internal float worldSignX;

		internal float worldSignY;

		internal bool sorted;
	}
}
