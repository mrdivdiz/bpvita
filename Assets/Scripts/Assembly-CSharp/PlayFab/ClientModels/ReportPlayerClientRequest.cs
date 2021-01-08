using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ReportPlayerClientRequest : PlayFabRequestCommon
	{
		public string Comment;

		public string ReporteeId;
	}
}
