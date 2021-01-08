using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LinkCustomIDRequest : PlayFabRequestCommon
	{
		public string CustomId;

		public bool? ForceLink;
	}
}
