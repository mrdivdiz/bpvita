using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class CollectionFilter
	{
		public List<Container_Dictionary_String_String> Excludes;

		public List<Container_Dictionary_String_String> Includes;
	}
}
