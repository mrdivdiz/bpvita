using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class UnlinkAndroidDeviceIDRequest : PlayFabRequestCommon
	{
		public string AndroidDeviceId;
	}
}
