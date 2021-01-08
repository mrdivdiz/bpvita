using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class UnlockContainerItemRequest : PlayFabRequestCommon
	{
		public string CatalogVersion;

		public string CharacterId;

		public string ContainerItemId;
	}
}
