using System;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
	[Serializable]
	public class UpdateAvatarUrlRequest : PlayFabRequestCommon
	{
		public string ImageUrl;
	}
}
