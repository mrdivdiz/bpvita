using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class UpdateUserTitleDisplayNameResult : PlayFabResultCommon
	{
		public string DisplayName;
	}
}
