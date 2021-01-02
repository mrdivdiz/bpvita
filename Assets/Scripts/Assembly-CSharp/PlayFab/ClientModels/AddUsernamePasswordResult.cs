using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class AddUsernamePasswordResult : PlayFabResultCommon
	{
		public string Username;
	}
}
