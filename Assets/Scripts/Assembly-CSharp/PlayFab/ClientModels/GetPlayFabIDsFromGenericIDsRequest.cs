using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPlayFabIDsFromGenericIDsRequest : PlayFabRequestCommon
	{
		public List<GenericServiceId> GenericIDs;
	}
}
