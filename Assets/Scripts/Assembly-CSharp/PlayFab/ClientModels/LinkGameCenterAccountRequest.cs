using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LinkGameCenterAccountRequest : PlayFabRequestCommon
	{
		public bool? ForceLink;

		public string GameCenterId;
	}
}
