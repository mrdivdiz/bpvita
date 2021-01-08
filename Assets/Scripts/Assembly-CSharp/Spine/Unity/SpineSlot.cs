namespace Spine.Unity
{
    public class SpineSlot : SpineAttributeBase
	{
		public SpineSlot(string startsWith = "", string dataField = "", bool containsBoundingBoxes = false)
		{
			this.startsWith = startsWith;
			this.dataField = dataField;
			this.containsBoundingBoxes = containsBoundingBoxes;
		}

		public bool containsBoundingBoxes;
	}
}
