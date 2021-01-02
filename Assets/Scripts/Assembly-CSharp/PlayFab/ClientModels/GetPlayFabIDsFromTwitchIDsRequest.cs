using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayFabIDsFromTwitchIDsRequest : PlayFabRequestCommon
	{
		public List<string> TwitchIds;
	}
}
