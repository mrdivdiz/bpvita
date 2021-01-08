using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayFabIDsFromGameCenterIDsRequest : PlayFabRequestCommon
	{
		public List<string> GameCenterIDs;
	}
}
