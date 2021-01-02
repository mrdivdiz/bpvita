using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetTitleDataRequest : PlayFabRequestCommon
	{
		public List<string> Keys;
	}
}
