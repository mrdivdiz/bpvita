using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetContentDownloadUrlResult : PlayFabResultCommon
	{
		public string URL;
	}
}
