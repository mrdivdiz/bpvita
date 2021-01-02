using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class LinkIOSDeviceIDRequest : PlayFabRequestCommon
	{
		public string DeviceId;

		public string DeviceModel;

		public bool? ForceLink;

		public string OS;
	}
}
