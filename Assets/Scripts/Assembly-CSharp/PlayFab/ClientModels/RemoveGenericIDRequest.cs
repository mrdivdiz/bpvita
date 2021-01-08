using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class RemoveGenericIDRequest : PlayFabRequestCommon
	{
		public GenericServiceId GenericId;
	}
}
