using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class UpdateUserTitleDisplayNameRequest : PlayFabRequestCommon
	{
		public string DisplayName;
	}
}
