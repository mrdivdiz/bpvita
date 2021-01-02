using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayFabIDsFromGoogleIDsRequest : PlayFabRequestCommon
	{
		public List<string> GoogleIDs;
	}
}
