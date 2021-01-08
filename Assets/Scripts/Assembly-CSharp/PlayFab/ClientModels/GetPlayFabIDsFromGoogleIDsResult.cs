using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayFabIDsFromGoogleIDsResult : PlayFabResultCommon
	{
		public List<GooglePlayFabIdPair> Data;
	}
}
