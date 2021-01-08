using UnityEngine;

namespace Spine.Unity
{
    public abstract class SpineAttributeBase : PropertyAttribute
	{
		public string dataField = string.Empty;

		public string startsWith = string.Empty;
	}
}
