using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetCharacterStatisticsResult : PlayFabResultCommon
	{
		public Dictionary<string, int> CharacterStatistics;
	}
}
