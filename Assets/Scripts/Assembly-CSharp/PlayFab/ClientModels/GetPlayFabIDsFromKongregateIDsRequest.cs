using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayFabIDsFromKongregateIDsRequest : PlayFabRequestCommon
	{
		public List<string> KongregateIDs;
	}
}
