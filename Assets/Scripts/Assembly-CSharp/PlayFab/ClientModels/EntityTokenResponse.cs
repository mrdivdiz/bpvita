using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class EntityTokenResponse : PlayFabResultCommon
	{
		public EntityKey Entity;

		public string EntityToken;

		public DateTime? TokenExpiration;
	}
}
