using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class DeviceInfoRequest : PlayFabRequestCommon
	{
		public Dictionary<string, object> Info;
	}
}
