using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetCharacterInventoryRequest : PlayFabRequestCommon
	{
		public string CatalogVersion;

		public string CharacterId;
	}
}
