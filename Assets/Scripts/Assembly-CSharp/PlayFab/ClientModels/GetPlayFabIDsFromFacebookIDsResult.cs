using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayFabIDsFromFacebookIDsResult : PlayFabResultCommon
	{
		public List<FacebookPlayFabIdPair> Data;
	}
}
