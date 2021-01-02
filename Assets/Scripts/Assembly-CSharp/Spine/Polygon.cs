namespace Spine
{
    public class Polygon
	{
		public Polygon()
		{
			this.Vertices = new float[16];
		}

		public float[] Vertices { get; set; }

		public int Count { get; set; }
	}
}
