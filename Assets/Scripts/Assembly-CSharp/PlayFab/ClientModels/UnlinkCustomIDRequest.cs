using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class UnlinkCustomIDRequest : PlayFabRequestCommon
	{
		public string CustomId;
	}
}
