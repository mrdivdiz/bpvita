using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetTimeResult : PlayFabResultCommon
	{
		public DateTime Time;
	}
}
