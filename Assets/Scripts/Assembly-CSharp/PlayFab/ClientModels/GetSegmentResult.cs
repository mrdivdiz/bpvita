using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class GetSegmentResult : PlayFabResultCommon
	{
		public string ABTestParent;

		public string Id;

		public string Name;
	}
}
