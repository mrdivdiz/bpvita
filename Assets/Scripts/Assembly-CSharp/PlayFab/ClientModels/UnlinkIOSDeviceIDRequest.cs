using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class UnlinkIOSDeviceIDRequest : PlayFabRequestCommon
	{
		public string DeviceId;
	}
}
