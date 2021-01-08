using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GameServerRegionsResult : PlayFabResultCommon
	{
		public List<RegionInfo> Regions;
	}
}
