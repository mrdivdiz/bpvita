using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayFabIDsFromTwitchIDsResult : PlayFabResultCommon
	{
		public List<TwitchPlayFabIdPair> Data;
	}
}
