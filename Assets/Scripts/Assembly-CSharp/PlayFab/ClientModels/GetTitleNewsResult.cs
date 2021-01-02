using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetTitleNewsResult : PlayFabResultCommon
	{
		public List<TitleNewsItem> News;
	}
}
