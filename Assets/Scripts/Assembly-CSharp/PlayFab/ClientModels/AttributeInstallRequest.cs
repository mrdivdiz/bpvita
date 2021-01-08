using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class AttributeInstallRequest : PlayFabRequestCommon
	{
		public string Adid;

		public string Idfa;
	}
}
