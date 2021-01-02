using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class ReportPlayerClientResult : PlayFabResultCommon
	{
		public int SubmissionsRemaining;
	}
}
