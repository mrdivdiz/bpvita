using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class AddOrUpdateContactEmailRequest : PlayFabRequestCommon
	{
		public string EmailAddress;
	}
}
