using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class UpdateCharacterStatisticsRequest : PlayFabRequestCommon
	{
		public string CharacterId;

		public Dictionary<string, int> CharacterStatistics;
	}
}
