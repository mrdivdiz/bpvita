using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetPublisherDataRequest : PlayFabRequestCommon
	{
		public List<string> Keys;
	}
}
