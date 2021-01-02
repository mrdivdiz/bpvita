using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class AddGenericIDRequest : PlayFabRequestCommon
	{
		public GenericServiceId GenericId;
	}
}
