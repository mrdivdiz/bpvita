using System;

namespace PlayFab.Json
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class JsonProperty : Attribute
	{
		public string PropertyName;

		public NullValueHandling NullValueHandling;
	}
}
