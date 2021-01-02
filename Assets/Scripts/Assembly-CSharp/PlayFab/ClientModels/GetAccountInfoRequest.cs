using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetAccountInfoRequest : PlayFabRequestCommon
	{
		public string Email;

		public string PlayFabId;

		public string TitleDisplayName;

		public string Username;
	}
}
