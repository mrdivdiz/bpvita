using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("ContraptionDataset")]
public class ContraptionDataset
{
	public List<ContraptionDatasetUnit> ContraptionDatasetList
	{
		get
		{
			return this.m_contraptionDataSet;
		}
	}

	public void AddPart(int x, int y, int partType, int customPartIndex, BasePart.GridRotation rotation, bool flipped)
	{
        ContraptionDatasetUnit contraptionDatasetUnit = new ContraptionDatasetUnit();
		contraptionDatasetUnit.x = x;
		contraptionDatasetUnit.y = y;
		contraptionDatasetUnit.partType = partType;
		contraptionDatasetUnit.customPartIndex = customPartIndex;
		contraptionDatasetUnit.rot = (int)rotation;
		contraptionDatasetUnit.flipped = flipped;
		this.m_contraptionDataSet.Add(contraptionDatasetUnit);
	}

	[XmlArray("ContraptionDatasetList")]
	[XmlArrayItem("ContraptionDatasetUnit")]
	protected List<ContraptionDatasetUnit> m_contraptionDataSet = new List<ContraptionDatasetUnit>();

	public class ContraptionDatasetUnit
	{
		[XmlAttribute("x")]
		public int x;

		[XmlAttribute("y")]
		public int y;

		[XmlAttribute("partType")]
		public int partType;

		[XmlAttribute("customPartIndex")]
		public int customPartIndex;

		[XmlAttribute("rot")]
		public int rot;

		[XmlAttribute("flipped")]
		public bool flipped;
	}
}
