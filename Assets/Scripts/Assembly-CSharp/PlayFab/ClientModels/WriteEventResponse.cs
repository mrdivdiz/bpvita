using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class WriteEventResponse : PlayFabResultCommon
	{
		public string EventId;
	}
}
