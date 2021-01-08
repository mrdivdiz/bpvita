using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("GhostPlayer")]
public class GhostPlayer
{
	public List<Coord> PositionData
	{
		get
		{
			return this.Coords;
		}
	}

	public void AddPosition(float x, float y, float z)
	{
        Coord coord = new Coord();
		coord.x = x;
		coord.y = y;
		coord.z = z;
		this.Coords.Add(coord);
	}

	[XmlArray("Coords")]
	[XmlArrayItem("Coord")]
	protected List<Coord> Coords = new List<Coord>();

	public class Coord
	{
		[XmlAttribute("x")]
		public float x;

		[XmlAttribute("y")]
		public float y;

		[XmlAttribute("z")]
		public float z;
	}
}
