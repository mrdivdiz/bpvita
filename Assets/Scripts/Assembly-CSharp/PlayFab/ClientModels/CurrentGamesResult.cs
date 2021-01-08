using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class CurrentGamesResult : PlayFabResultCommon
	{
		public int GameCount;

		public List<GameInfo> Games;

		public int PlayerCount;
	}
}
