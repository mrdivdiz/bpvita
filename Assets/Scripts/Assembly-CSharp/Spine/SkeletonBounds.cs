using System;

namespace Spine
{
	public class SkeletonBounds
	{
		public SkeletonBounds()
		{
			this.BoundingBoxes = new ExposedList<BoundingBoxAttachment>();
			this.Polygons = new ExposedList<Polygon>();
		}

		public ExposedList<BoundingBoxAttachment> BoundingBoxes { get; private set; }

		public ExposedList<Polygon> Polygons { get; private set; }

		public float MinX
		{
			get
			{
				return this.minX;
			}
			set
			{
				this.minX = value;
			}
		}

		public float MinY
		{
			get
			{
				return this.minY;
			}
			set
			{
				this.minY = value;
			}
		}

		public float MaxX
		{
			get
			{
				return this.maxX;
			}
			set
			{
				this.maxX = value;
			}
		}

		public float MaxY
		{
			get
			{
				return this.maxY;
			}
			set
			{
				this.maxY = value;
			}
		}

		public float Width
		{
			get
			{
				return this.maxX - this.minX;
			}
		}

		public float Height
		{
			get
			{
				return this.maxY - this.minY;
			}
		}

		public void Update(Skeleton skeleton, bool updateAabb)
		{
			ExposedList<BoundingBoxAttachment> boundingBoxes = this.BoundingBoxes;
			ExposedList<Polygon> polygons = this.Polygons;
			ExposedList<Slot> slots = skeleton.slots;
			int count = slots.Count;
			boundingBoxes.Clear(true);
			int i = 0;
			int count2 = polygons.Count;
			while (i < count2)
			{
				this.polygonPool.Add(polygons.Items[i]);
				i++;
			}
			polygons.Clear(true);
			for (int j = 0; j < count; j++)
			{
				Slot slot = slots.Items[j];
				BoundingBoxAttachment boundingBoxAttachment = slot.attachment as BoundingBoxAttachment;
				if (boundingBoxAttachment != null)
				{
					boundingBoxes.Add(boundingBoxAttachment);
					int count3 = this.polygonPool.Count;
					Polygon polygon;
					if (count3 > 0)
					{
						polygon = this.polygonPool.Items[count3 - 1];
						this.polygonPool.RemoveAt(count3 - 1);
					}
					else
					{
						polygon = new Polygon();
					}
					polygons.Add(polygon);
					int num = boundingBoxAttachment.Vertices.Length;
					polygon.Count = num;
					if (polygon.Vertices.Length < num)
					{
						polygon.Vertices = new float[num];
					}
					boundingBoxAttachment.ComputeWorldVertices(slot, polygon.Vertices);
				}
			}
			if (updateAabb)
			{
				this.aabbCompute();
			}
		}

		private void aabbCompute()
		{
			float val = 2.14748365E+09f;
			float val2 = 2.14748365E+09f;
			float val3 = -2.14748365E+09f;
			float val4 = -2.14748365E+09f;
			ExposedList<Polygon> polygons = this.Polygons;
			int i = 0;
			int count = polygons.Count;
			while (i < count)
			{
				Polygon polygon = polygons.Items[i];
				float[] vertices = polygon.Vertices;
				int j = 0;
				int count2 = polygon.Count;
				while (j < count2)
				{
					float val5 = vertices[j];
					float val6 = vertices[j + 1];
					val = Math.Min(val, val5);
					val2 = Math.Min(val2, val6);
					val3 = Math.Max(val3, val5);
					val4 = Math.Max(val4, val6);
					j += 2;
				}
				i++;
			}
			this.minX = val;
			this.minY = val2;
			this.maxX = val3;
			this.maxY = val4;
		}

		public bool AabbContainsPoint(float x, float y)
		{
			return x >= this.minX && x <= this.maxX && y >= this.minY && y <= this.maxY;
		}

		public bool AabbIntersectsSegment(float x1, float y1, float x2, float y2)
		{
			float num = this.minX;
			float num2 = this.minY;
			float num3 = this.maxX;
			float num4 = this.maxY;
			if ((x1 <= num && x2 <= num) || (y1 <= num2 && y2 <= num2) || (x1 >= num3 && x2 >= num3) || (y1 >= num4 && y2 >= num4))
			{
				return false;
			}
			float num5 = (y2 - y1) / (x2 - x1);
			float num6 = num5 * (num - x1) + y1;
			if (num6 > num2 && num6 < num4)
			{
				return true;
			}
			num6 = num5 * (num3 - x1) + y1;
			if (num6 > num2 && num6 < num4)
			{
				return true;
			}
			float num7 = (num2 - y1) / num5 + x1;
			if (num7 > num && num7 < num3)
			{
				return true;
			}
			num7 = (num4 - y1) / num5 + x1;
			return num7 > num && num7 < num3;
		}

		public bool AabbIntersectsSkeleton(SkeletonBounds bounds)
		{
			return this.minX < bounds.maxX && this.maxX > bounds.minX && this.minY < bounds.maxY && this.maxY > bounds.minY;
		}

		public bool ContainsPoint(Polygon polygon, float x, float y)
		{
			float[] vertices = polygon.Vertices;
			int count = polygon.Count;
			int num = count - 2;
			bool flag = false;
			for (int i = 0; i < count; i += 2)
			{
				float num2 = vertices[i + 1];
				float num3 = vertices[num + 1];
				if ((num2 < y && num3 >= y) || (num3 < y && num2 >= y))
				{
					float num4 = vertices[i];
					if (num4 + (y - num2) / (num3 - num2) * (vertices[num] - num4) < x)
					{
						flag = !flag;
					}
				}
				num = i;
			}
			return flag;
		}

		public BoundingBoxAttachment ContainsPoint(float x, float y)
		{
			ExposedList<Polygon> polygons = this.Polygons;
			int i = 0;
			int count = polygons.Count;
			while (i < count)
			{
				if (this.ContainsPoint(polygons.Items[i], x, y))
				{
					return this.BoundingBoxes.Items[i];
				}
				i++;
			}
			return null;
		}

		public BoundingBoxAttachment IntersectsSegment(float x1, float y1, float x2, float y2)
		{
			ExposedList<Polygon> polygons = this.Polygons;
			int i = 0;
			int count = polygons.Count;
			while (i < count)
			{
				if (this.IntersectsSegment(polygons.Items[i], x1, y1, x2, y2))
				{
					return this.BoundingBoxes.Items[i];
				}
				i++;
			}
			return null;
		}

		public bool IntersectsSegment(Polygon polygon, float x1, float y1, float x2, float y2)
		{
			float[] vertices = polygon.Vertices;
			int count = polygon.Count;
			float num = x1 - x2;
			float num2 = y1 - y2;
			float num3 = x1 * y2 - y1 * x2;
			float num4 = vertices[count - 2];
			float num5 = vertices[count - 1];
			for (int i = 0; i < count; i += 2)
			{
				float num6 = vertices[i];
				float num7 = vertices[i + 1];
				float num8 = num4 * num7 - num5 * num6;
				float num9 = num4 - num6;
				float num10 = num5 - num7;
				float num11 = num * num10 - num2 * num9;
				float num12 = (num3 * num9 - num * num8) / num11;
				if (((num12 >= num4 && num12 <= num6) || (num12 >= num6 && num12 <= num4)) && ((num12 >= x1 && num12 <= x2) || (num12 >= x2 && num12 <= x1)))
				{
					float num13 = (num3 * num10 - num2 * num8) / num11;
					if (((num13 >= num5 && num13 <= num7) || (num13 >= num7 && num13 <= num5)) && ((num13 >= y1 && num13 <= y2) || (num13 >= y2 && num13 <= y1)))
					{
						return true;
					}
				}
				num4 = num6;
				num5 = num7;
			}
			return false;
		}

		public Polygon getPolygon(BoundingBoxAttachment attachment)
		{
			int num = this.BoundingBoxes.IndexOf(attachment);
			return (num != -1) ? this.Polygons.Items[num] : null;
		}

		private ExposedList<Polygon> polygonPool = new ExposedList<Polygon>();

		private float minX;

		private float minY;

		private float maxX;

		private float maxY;
	}
}
