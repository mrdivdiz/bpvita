using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetAccountInfoResult : PlayFabResultCommon
	{
		public UserAccountInfo AccountInfo;
	}
}
