using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LinkAndroidDeviceIDRequest : PlayFabRequestCommon
	{
		public string AndroidDevice;

		public string AndroidDeviceId;

		public bool? ForceLink;

		public string OS;
	}
}
