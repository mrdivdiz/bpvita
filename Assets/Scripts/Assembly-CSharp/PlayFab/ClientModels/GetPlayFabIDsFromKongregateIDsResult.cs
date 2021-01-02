using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayFabIDsFromKongregateIDsResult : PlayFabResultCommon
	{
		public List<KongregatePlayFabIdPair> Data;
	}
}
