using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GameServerRegionsRequest : PlayFabRequestCommon
	{
		public string BuildVersion;

		public string TitleId;
	}
}
