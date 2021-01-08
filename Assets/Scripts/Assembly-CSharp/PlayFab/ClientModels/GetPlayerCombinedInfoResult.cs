using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayerCombinedInfoResult : PlayFabResultCommon
	{
		public GetPlayerCombinedInfoResultPayload InfoResultPayload;

		public string PlayFabId;
	}
}
