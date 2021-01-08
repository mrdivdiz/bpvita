using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetUserDataRequest : PlayFabRequestCommon
	{
		public uint? IfChangedFromDataVersion;

		public List<string> Keys;

		public string PlayFabId;
	}
}
