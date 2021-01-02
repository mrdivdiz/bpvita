using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetCharacterStatisticsRequest : PlayFabRequestCommon
	{
		public string CharacterId;
	}
}
