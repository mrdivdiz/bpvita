namespace Spine.Unity
{
    public class SpineEvent : SpineAttributeBase
	{
		public SpineEvent(string startsWith = "", string dataField = "")
		{
			this.startsWith = startsWith;
			this.dataField = dataField;
		}
	}
}
